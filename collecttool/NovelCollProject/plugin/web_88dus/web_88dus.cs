using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NovelCollProjectutils;

namespace NovelCollProject.plugin.web_88dus
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
            pageFeature.InjectUrlRule(PageTypeEnum.ListPage1, @"REG:88dus.com/\w+/\d+/\d+/\?chapterlist");
            pageFeature.InjectUrlRule(PageTypeEnum.DetailPage1, @"REG:88dus.com/\w+/\d+/\d+/\d+.html");
        }


        public override void Load(bool isUTF8, int bookId = 0)
        {
            //if (PageFeature.MatchURL(Url) == PageTypeEnum.ListPage1)
            //{
            //    SetUserAgent("Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.101 Safari/537.36");
            //    SetCookie("cid=8BMAWXTX; BDTUJIAID=a686ad2dbad217926251d9345191dfbc; UM_distinctid=163edbff7fbfe-01419ccc8dad96-4446062d-1fa400-163edbff7fc190; tiexueusersource=4; Hm_lvt_c8d128c127cc299c41e73a24f1158b7c=1531726049; Hm_lvt_a467f9c99186a66ce83cf7ad63b6ff23=1531726189; jphuser=1; __utma=247579266.1141053711.1531726511.1531726511.1531726511.1; __utmc=247579266; __utmz=247579266.1531726511.1.1.utmcsr=tiexue.net|utmccn=(referral)|utmcmd=referral|utmcct=/; tx_abtest=6; uservisitnum=1; Hm_lpvt_c8d128c127cc299c41e73a24f1158b7c=1531796154; uicon=12945208:jpg; p=IsAdmin%3dFalse%26IsHeader%3dTrue%26UserID%3d828090%26UserName%3d%e5%b0%8f%e7%bc%96R%26Expire%3d1563436232%26TxNet2%3d3CE3A03134ABB7ABABD6150518673CE502ECB751E2198F26AB131AD18A372FA8; _testrefer=other; _logck=325D637B129DE21548D70618061D7C8D; Hm_lpvt_a467f9c99186a66ce83cf7ad63b6ff23=1531814608");
            //    SetHost("affair.book.tiexue.net");
            //}
            //else
            //{
            //    SetUserAgent("Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.101 Safari/537.36");
            //    SetCookie("cid=8BMAWXTX; BDTUJIAID=a686ad2dbad217926251d9345191dfbc; UM_distinctid=163edbff7fbfe-01419ccc8dad96-4446062d-1fa400-163edbff7fc190; tiexueusersource=4; Hm_lvt_c8d128c127cc299c41e73a24f1158b7c=1531726049; Hm_lvt_a467f9c99186a66ce83cf7ad63b6ff23=1531726189; jphuser=1; __utma=247579266.1141053711.1531726511.1531726511.1531726511.1; __utmc=247579266; __utmz=247579266.1531726511.1.1.utmcsr=tiexue.net|utmccn=(referral)|utmcmd=referral|utmcct=/; tx_abtest=6; uservisitnum=1; Hm_lpvt_c8d128c127cc299c41e73a24f1158b7c=1531796154; uicon=12945208:jpg; p=IsAdmin%3dFalse%26IsHeader%3dTrue%26UserID%3d828090%26UserName%3d%e5%b0%8f%e7%bc%96R%26Expire%3d1563436232%26TxNet2%3d3CE3A03134ABB7ABABD6150518673CE502ECB751E2198F26AB131AD18A372FA8; _testrefer=other; _logck=325D637B129DE21548D70618061D7C8D; Hm_lpvt_a467f9c99186a66ce83cf7ad63b6ff23=1531814608");
            //    SetHost("affair.book.tiexue.net");
            //}
            base.Load(isUTF8, bookId);
        }



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
            HtmlNodeCollection linkNodes = documentNode.SelectNodes("//div[@class='mulu']/ul/li");
            if (linkNodes != null)
            {
                links = new List<Hashtable>();
                foreach (var liNode in linkNodes)
                {
                    var title = liNode.SelectSingleNode("a")?.InnerText;
                    var url = liNode.SelectSingleNode("a")?.GetAttributeValue("href", "");
                    if (string.IsNullOrEmpty(url))
                        continue;
                    reg = new Regex(@"(\d+).html");
                    m = reg.Match(url);
                    string flag = reg.Replace(m.Value, "$1");
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
            tempNode = documentNode.SelectSingleNode("//div[@class='yd_text2']");
            if (tempNode != null)
            {
                tempString = tempNode.InnerHtml;
                tempString = HTMLUtil.RemoveHtmlContent(tempString, "div", "style", "script","dt","a");
                tempString = tempString.ToLower();
                //tempString = HTMLUtil.RemoveHtmlTag(tempString, "p", "img", "br");
                tempString = tempString.Replace("\r\n", "").Replace("\t", "");             

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
