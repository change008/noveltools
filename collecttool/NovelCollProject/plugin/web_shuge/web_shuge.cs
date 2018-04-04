using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NovelCollProjectutils;

namespace NovelCollProject.plugin.web_shuge
{
    class Page : PageBase
    {
        private static string[] RY = new string[]
        {
            "//script"
        };

        public object HtmlUtil { get; private set; }



        /// <summary>
        ///添加页面特征规则 
        /// </summary>
        /// <param name="pageFeature"></param>
        protected override void buildPageFeatureRules(PageFeature pageFeature)
        {
            pageFeature.InjectUrlRule(PageTypeEnum.StartupPage, @"REG:sangwu.org/nonono$");
            pageFeature.InjectUrlRule(PageTypeEnum.DetailPage1, @"REG:shuge.net/\w+/\d+/\d+/\d+.html");
            pageFeature.InjectUrlRule(PageTypeEnum.ListPage1, @"REG:shuge.net/\w+/\d+/\d+/$");
            
        }


        //public override void Load(bool isUTF8, int bookId = 0)
        //{
        //    if (PageFeature.MatchURL(Url) == PageTypeEnum.ListPage1)
        //    {
        //        SetUserAgent("Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.101 Safari/537.36");
        //        SetCookie("bdshare_firstime=1504105500426; UM_distinctid=15e33ac8f56278-03d2267dbb7495-3e64430f-1fa400-15e33ac8f57343; bookid=201390; chapterid=1163094; chaptername=%25u7B2C1300%25u7AE0%2520%25u79BB%25u95F4; Hm_lvt_4637b2d5be4ce91be6f61441d61e1074=1504105502,1504365699; visid_incap_1353717=C4b3czGIQRuyH9jTVpsfTgcp3lkAAAAAQUIPAAAAAABm88jsSE8+H5txZQlWxcnM; incap_ses_432_1353717=ex4TLf4UoDoeOzk7ocb+BQcp3lkAAAAABFiQWPIG5SX2ClZBbP1jig==; CNZZDATA1257130134=1018383422-1504100451-null%7C1507727860");
        //        SetHost("www.23us.cc");
        //    }
        //    else
        //    {
        //        SetUserAgent("Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.101 Safari/537.36");
        //        SetCookie("bdshare_firstime=1504105500426; UM_distinctid=15e33ac8f56278-03d2267dbb7495-3e64430f-1fa400-15e33ac8f57343; bookid=201390; chapterid=1163094; chaptername=%25u7B2C1300%25u7AE0%2520%25u79BB%25u95F4; Hm_lvt_4637b2d5be4ce91be6f61441d61e1074=1504105502,1504365699; visid_incap_1353717=C4b3czGIQRuyH9jTVpsfTgcp3lkAAAAAQUIPAAAAAABm88jsSE8+H5txZQlWxcnM; incap_ses_432_1353717=ex4TLf4UoDoeOzk7ocb+BQcp3lkAAAAABFiQWPIG5SX2ClZBbP1jig==; CNZZDATA1257130134=1018383422-1504100451-null%7C1507727860");
        //        SetHost("www.23us.cc");
        //    }
        //    base.Load(isUTF8, bookId);
        //}



        /// <summary>
        /// 解析页面内容
        /// </summary>
        /// <param name="htmlstring"></param>
        protected override void parseHtmlString(string htmlstring, int bookId = 0)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlstring);
            switch (PageType)
            {
                case PageTypeEnum.StartupPage:
                    FinalData = parseStartupPage(document.DocumentNode);
                    break;
                case PageTypeEnum.ListPage1:
                    FinalData = parseListPage(document.DocumentNode);
                    break;
                case PageTypeEnum.DetailPage1:
                    FinalData = parseDetailPage1(document.DocumentNode);
                    break;
                case PageTypeEnum.DetailPage2:
                    FinalData = parseDetailPage2(document.DocumentNode);
                    break;
            }
        }

        /// <summary>
        /// 解析开始页
        /// </summary>
        /// <param name="documentNode"></param>
        /// <returns></returns>
        private Hashtable parseStartupPage(HtmlNode documentNode)
        {
            Hashtable ht = new Hashtable();
            Regex tempReg = null;
            Match tempMatch = null;
            HtmlNode linkNodes = documentNode.SelectSingleNode("//uv[@class='chapter-list']/li[@class='chapter']");
            if (linkNodes != null)
            {
                var title = linkNodes.InnerText;
                ht.Add(CollectionFieldName.Novel_Name, title);
            }
            linkNodes = documentNode.SelectSingleNode("//div[@id='fmimg']/img");
            if (linkNodes != null)
            {
                var imgUrl = linkNodes?.GetAttributeValue("src", "");
                ht.Add(CollectionFieldName.Novel_CoverImgs, imgUrl);
            }
            linkNodes = documentNode.SelectSingleNode("//meta[@property='og:novel:category']");
            if (linkNodes != null)
            {
                var tag = linkNodes?.GetAttributeValue("content", "");
                ht.Add(CollectionFieldName.Novel_Tag, tag);
            }
           
            var url = InternalRealUrl + "?chapter=";
            ht.Add(CollectionFieldName.Url, url);
           
            tempReg = new Regex(@"/(\w+)/$");
            tempMatch = tempReg.Match(InternalRealUrl);
            if (tempMatch.Success)
            {
                ht.Add(CollectionFieldName.Novel_UniqueFlag, tempReg.Replace(tempMatch.Value, "$1"));
            }
            Hashtable returndata = new Hashtable();
            if (ht != null)
                returndata.Add(CollectionFieldName.BookInfo, ht);
            return returndata;
        }

        /// <summary>
        /// 解析列表页内容--解析章节列表数据
        /// </summary>
        /// <param name="documentNode"></param>
        /// <returns></returns>
        private Hashtable parseListPage(HtmlNode documentNode)
        {
            List<Hashtable> links = null;
            List<string> multipage = null;
            Regex reg;
            Match m;
            HtmlNodeCollection linkNodes = documentNode.SelectNodes("//div[@id='list']/dl/dd");
            if (linkNodes != null)
            {
                links = new List<Hashtable>();

                bool start = false;
                foreach (var liNode in linkNodes)
                {
                    var title = liNode.SelectSingleNode("a")?.InnerText;
                    var url = liNode.SelectSingleNode("a")?.GetAttributeValue("href", "");
                    if (string.IsNullOrEmpty(url))
                        continue;

                    reg = new Regex(@"(\d+).html");
                    m = reg.Match(url);
                    string flag = reg.Replace(m.Value, "$1");

                    if (!start && flag == "23616548")
                    {
                        start = true;
                    }
                    

                    if (!start)
                    {
                        continue;
                    }

                    




                    Hashtable ht = new Hashtable();
                    ht.Add(CollectionFieldName.Chap_Title, title);
                    ht.Add(CollectionFieldName.Url, url);
                    ht.Add(CollectionFieldName.Chap_UniqueFlag, flag);

                    links.Add(ht);
                }
            }
            

            Hashtable returndata = new Hashtable();
            if (links != null)
                returndata.Add(CollectionFieldName.Items, links);
            if (multipage != null)
                returndata.Add(CollectionFieldName.Pages, multipage);
            return returndata;
        }
        /// <summary>
        /// 解析明细页内容
        /// </summary>
        /// <param name="documentNode"></param>
        /// <returns></returns>
        private Hashtable parseDetailPage1(HtmlNode documentNode)
        {
            List<string> multipage = null;
            Hashtable returndata = new Hashtable();
            HtmlNode tempNode = null;
            string tempString = null;
            string tempInnerText = null;
            Regex tempReg = null;
            Match tempMatch = null;
            tempNode = documentNode.SelectSingleNode("//div[@id='content']");
            if (tempNode != null)
            {
                tempString = tempNode.InnerHtml;
                tempString = HTMLUtil.RemoveHtmlContent(tempString, "div", "style", "script","dt","a");
                tempString = tempString.ToLower();
                //tempString = HTMLUtil.RemoveHtmlTag(tempString, "p", "img", "br");
                tempString = tempString.Replace("\r\n", "").Replace("\t", "")
                    .Replace("本站访问地址http://www.ziyouge.com 任意搜索引擎内输入:紫幽阁 即可访问!", "")
                    .Replace("http://www.ziyouge.com", "")
                    .Replace("紫幽阁", "")
                    .Replace("wanben.me", "")
                    .Replace("ziyouge.com", "")
                    .Replace("ziyouge", "")
                    .Replace("http://", "")
                    .Replace("http", "")
                    .Replace("紫Ｙou阁 ＷwＷ.ZiyouＧＥ.com", "")
                    .Replace("WWw.ZiyoUgE.com", "")
                    .Replace("品书网", "")
                    .Replace("www.vodtw.com", "")
                    .Replace("本书来自", "")
                    .Replace("/html/book/19/19092/","")
                    .Replace("大家想继续看我的书，可以加我微信gdy3208新书出了，我会第一时间发动态通知大家！","")
                    .Replace("本站重要通知:请使用本站的免费小说app,无广告、破防盗版、更新快,会员同步书架,请关注微信公众号 appxsyd (按住三秒复制) 下载免费阅读器!!","")
                    .Replace("本站重要通知: 请使用本站的免费小说app,无广告、破防盗版、更新快,会员同步书架,请关注微信公众号 gegegengxin (按住三秒复制)下载免费阅读器!!", "")
                    .Replace("本站重要通知:", "")
                    .Replace("请使用本站的免费小说", "")
                    .Replace("app", "")
                    .Replace("无广告、破防盗版、更新快,会员同步书架", "")
                    .Replace("请关注微信公众号", "")
                    .Replace("appxsyd", "")
                    .Replace("gegegengxin", "")
                    .Replace("(按住三秒复制)", "")
                    .Replace("(按住三秒复制)", "")
                    .Replace("下载免费阅读器", "")
                ;             

                  //正则替换域名
                  string pattern = @"(?=.{3,255}$)[a-zA-Z0-9][-a-zA-Z0-9]{0,62}(\.[a-zA-Z0-9][-a-zA-Z0-9]{0,62})+";
                tempString = Regex.Replace(tempString, pattern, "");

                string pattern1 = @"&lt;.+&gt;";
                tempString = Regex.Replace(tempString, pattern1, "");

                returndata.Add(CollectionFieldName.Chap_Content, tempString);

                //移除无效字符,用来计算长度
                tempInnerText = HTMLUtil.RemoveHtmlTag(tempString).Replace("&nbsp;", "").Replace("feisuz", "")
                    .Replace("作者的话:", "").Replace("新书，求收藏求推荐", "").Replace("本书红薯网首发,请勿转载!", "");
                if (!string.IsNullOrEmpty(tempInnerText))
                {
                    returndata.Add(CollectionFieldName.Chap_ContentLen, tempInnerText.Length);
                    string into = "";
                    if (tempInnerText.Length > 40)
                    {
                        into = tempInnerText.Substring(0, 40) + "...";
                    }
                    else
                    {
                        into = tempInnerText;
                    }
                    returndata.Add(CollectionFieldName.Chap_Intro, into);
                    int price = (tempString.Length / 1000) * 5;
                    if (price == 0)
                        price = 5;
                    if (price > 15)
                        price = 15;
                    returndata.Add(CollectionFieldName.Chap_Pirce, price);
                }
                returndata.Add(CollectionFieldName.Chap_Status, ChapterStatus.ChapterStatus_OnLine);
                returndata.Add(CollectionFieldName.Chap_ChapterType, ChapterType.ChapterType_Free);
                tempInnerText = tempNode.InnerText;

            }
            return returndata;
        }

        /// <summary>
        /// 解析明细页内容
        /// </summary>
        /// <param name="documentNode"></param>
        /// <returns></returns>
        private Hashtable parseDetailPage2(HtmlNode documentNode)
        {
            return null;
        }
    }
}
