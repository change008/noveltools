﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NovelCollProjectutils;

namespace NovelCollProject.plugin.web_quanshuwu
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
            pageFeature.InjectUrlRule(PageTypeEnum.StartupPage, @"REG:quanshuwu.com/nonono$");
            pageFeature.InjectUrlRule(PageTypeEnum.ListPage1, @"REG:quanshuwu.com/\w+/\d+.aspx\?chapterlist");
            pageFeature.InjectUrlRule(PageTypeEnum.DetailPage1, @"REG:quanshuwu.com/article/\d+.aspx");
            //pageFeature.InjectUrlRule(PageTypeEnum.DetailPage2, @"REG:hkslg520.com/\d+/\d+/\d+_\d+.html");
        }


        public override void Load(bool isUTF8, int bookId = 0)
        {
            if (PageFeature.MatchURL(Url) == PageTypeEnum.ListPage1)
            {
                SetUserAgent("Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.101 Safari/537.36");
                SetCookie("__cfduid=d391f7c8b72292e77ebe6b060fe3a922a1499519064; readrecord=4697%2C3698719%2C%u5C71%u6751%u540D%u533B%2C%u7B2C17%u7AE0%20%u5192%u9669%u4E00%u8BD5%2C2017-12-08%2022%3A31%3A05%244231%2C3161714%2C%u4E61%u6751%u6B32%u7231%2C%u7B2C%u4E8C%u7AE0%20%u55B7%u8840%u7684%u4E00%u5E55%2C2017-12-08%2022%3A33%3A02%243301%2C2444133%2C%u6843%u82B1%u6751%u7684%u5973%u4EBA%2C%u7B2C%u4E00%u7AE0%20%u8272%u80C6%u5305%u5929%uFF01%2C2017-12-08%2022%3A36%3A25%242669%2C1945884%2C%u6751%u957F%u7684%u540E%u9662%2C%u7B2C5%u7AE0%20%u795E%u5947%u6280%u827A%2C2017-12-08%2022%3A39%3A03%242567%2C1875073%2C%u4E61%u8273%u5C0F%u6751%u533B%2C%u7B2C%u4E00%u7AE0%20%u5A18%u4EEC%u7684%u5C41%u80A1%u86CB%u5B50%2C2017-12-08%2022%3A39%3A44%242499%2C1810708%2C%u5C71%u6751%u7F8E%u8272%2C%u7B2C132%20%u5148%u6BCD%u540E%u59731%2C2017-12-08%2022%3A58%3A21%242442%2C1760520%2C%u8D70%u6751%u5AB3%u5987%u597D%u7F8E%2C%u7B2C1%u7AE0%20%u5A36%u4E86%u6F02%u4EAE%u5AB3%u5987%2C2017-12-08%2022%3A59%3A23%241554%2C1095065%2C%u4E61%u6751%u5C0F%u533B%u5E08%2C%u7B2C13%u7AE0%20%u522B%u803D%u8BEF%u8001%u5B50%u9493%u9C7C%2C2017-12-08%2023%3A06%3A28%241515%2C1068044%2C%u4E61%u91CE%u8FF7%u60C5%u5C0F%u6751%u533B%2C2.%u5341%u4E8C%20%u9EC4%u7EC6%u7EC6%u7684%u5938%u5956%2C2017-12-08%2023%3A10%3A00%24; Hm_lvt_8ed59c79ed5a528066e1f1dda31e672c=1512739981; Hm_lpvt_8ed59c79ed5a528066e1f1dda31e672c=1512746079");
                SetHost("www.quanshuwu.com");
            }
            else
            {
                SetUserAgent("Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.101 Safari/537.36");
                SetCookie("__cfduid=d391f7c8b72292e77ebe6b060fe3a922a1499519064; readrecord=4697%2C3698719%2C%u5C71%u6751%u540D%u533B%2C%u7B2C17%u7AE0%20%u5192%u9669%u4E00%u8BD5%2C2017-12-08%2022%3A31%3A05%244231%2C3161714%2C%u4E61%u6751%u6B32%u7231%2C%u7B2C%u4E8C%u7AE0%20%u55B7%u8840%u7684%u4E00%u5E55%2C2017-12-08%2022%3A33%3A02%243301%2C2444133%2C%u6843%u82B1%u6751%u7684%u5973%u4EBA%2C%u7B2C%u4E00%u7AE0%20%u8272%u80C6%u5305%u5929%uFF01%2C2017-12-08%2022%3A36%3A25%242669%2C1945884%2C%u6751%u957F%u7684%u540E%u9662%2C%u7B2C5%u7AE0%20%u795E%u5947%u6280%u827A%2C2017-12-08%2022%3A39%3A03%242567%2C1875073%2C%u4E61%u8273%u5C0F%u6751%u533B%2C%u7B2C%u4E00%u7AE0%20%u5A18%u4EEC%u7684%u5C41%u80A1%u86CB%u5B50%2C2017-12-08%2022%3A39%3A44%242499%2C1810708%2C%u5C71%u6751%u7F8E%u8272%2C%u7B2C132%20%u5148%u6BCD%u540E%u59731%2C2017-12-08%2022%3A58%3A21%242442%2C1760520%2C%u8D70%u6751%u5AB3%u5987%u597D%u7F8E%2C%u7B2C1%u7AE0%20%u5A36%u4E86%u6F02%u4EAE%u5AB3%u5987%2C2017-12-08%2022%3A59%3A23%241554%2C1095065%2C%u4E61%u6751%u5C0F%u533B%u5E08%2C%u7B2C13%u7AE0%20%u522B%u803D%u8BEF%u8001%u5B50%u9493%u9C7C%2C2017-12-08%2023%3A06%3A28%241515%2C1068044%2C%u4E61%u91CE%u8FF7%u60C5%u5C0F%u6751%u533B%2C2.%u5341%u4E8C%20%u9EC4%u7EC6%u7EC6%u7684%u5938%u5956%2C2017-12-08%2023%3A10%3A00%24; Hm_lvt_8ed59c79ed5a528066e1f1dda31e672c=1512739981; Hm_lpvt_8ed59c79ed5a528066e1f1dda31e672c=1512746079");
                SetHost("www.quanshuwu.com");
            }
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
            Match tempMatch = null;//*[@id="readlist"]/ul
            HtmlNode linkNodes = documentNode.SelectSingleNode("//div[@id=\"readlist\"]/ul/li");
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
            HtmlNodeCollection linkNodes = documentNode.SelectNodes("//div[@id=\"readlist\"]/ul/li");
            if (linkNodes != null)
            {
                links = new List<Hashtable>();
                foreach (var liNode in linkNodes)
                {
                    var title = liNode.SelectSingleNode("a")?.InnerText;
                    var url = liNode.SelectSingleNode("a")?.GetAttributeValue("href", "");
                    if (string.IsNullOrEmpty(url))
                        continue;
                    reg = new Regex(@"(\d+).aspx");
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
            tempNode = documentNode.SelectSingleNode("//div[@id=\"content\"]");
            if (tempNode != null)
            {
                tempString = tempNode.InnerHtml;
                tempString = HTMLUtil.RemoveHtmlContent(tempString, "div", "style", "script", "h1");
                //tempString = HTMLUtil.RemoveHtmlTag(tempString, "p", "img", "br");
                tempString = tempString.Replace("\r\n", "").Replace("\t", "");
                returndata.Add(CollectionFieldName.Chap_Content, tempString);

                //移除无效字符,用来计算长度
                tempInnerText = HTMLUtil.RemoveHtmlTag(tempString).Replace("&nbsp;", "");
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
