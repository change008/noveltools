using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelCollProject.model;

namespace NovelCollProject
{
    /// <summary>
    /// 配置的采集信息,配置采集链接,采集id,采集类型等数据,替换数据库配置数据
    /// </summary>
    public class CollectionInfo
    {
        public static List<CollectionModel> CollctionModelList = new List<CollectionModel>();
        static CollectionInfo()
        {
            //采集信息添加到采集列表中
            CollctionModelList.Add(model1);
        }

        /// <summary>
        /// "plugin1"平台的小说"乡村色情"采集对象
        /// </summary>
        public static CollectionModel model1 = new CollectionModel(
            "web_hunhun520",
            "http://www.hunhun520.com/book/zhanguoxiuluochuan/?chapter=", 
            1001, 
            "战国修罗传", 
            @"无敌流，信长路线。
    好吧，已经写烂的剧情又被我这没有节操的人重写了。希望这一次，咱的节操是满格状态吧。
    各位书友要是觉得《战国修罗传》还不错的话请不要忘记向您QQ群和微博里的朋友推荐哦！战国修罗传最新章节, 战国修罗传无弹窗, 战国修罗传全文阅读.",
            "http://www.hunhun520.com/file/novel/cover/31/31857.jpg",
            "zhanguoxiuluochuan", 
            "nothing");

        /// <summary>
        /// "plugin2"平台的小说"乡村色情1"采集对象
        /// </summary>
        public static CollectionModel model2 = new CollectionModel("plugin2", "http://www.baidu.com", 1, "name", "intr", "cover", "unique", "remark");

    }

    /// <summary>
    /// 采集model
    /// </summary>
    [Serializable()]
    public class CollectionModel
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="name"></param>
        /// <param name="intr"></param>
        /// <param name="coverImgs"></param>
        /// <param name="uniqueFlag"></param>
        /// <param name="remark"></param>
        public CollectionModel(string plugin, string url, int collectionId, string name, string intr, string coverImgs, string uniqueFlag, string remark)
        {
            this.Url = url;
            this.CollectionId = collectionId;
            this.Name = name;
            this.Intr = intr;
            this.CoverImgs = coverImgs;
            this.UniqueFlag = uniqueFlag;
            this.Remark = remark;
            this.Plugin = plugin;
            this.chapterList = new List<wxchapter>();
        }
        /// <summary>
        /// url地址--代表章节列表页url地址--章节初始url列表地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 采集组件
        /// </summary>
        public string Plugin { get; set; }

        /// <summary>
        /// 采集id
        /// </summary>
        public int CollectionId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Intr { get; set; }

        /// <summary>
        /// 封面图
        /// </summary>
        public string CoverImgs { get; set; }

        /// <summary>
        /// 唯一标识
        /// </summary>
        public string UniqueFlag { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否utf8编码
        /// </summary>
        public bool IsUTF8 { get; set; }

        /// <summary>
        /// 字数
        /// </summary>
        public int ContentLen { get; set; }


        /// <summary>
        /// 章节列表信息
        /// </summary>
        public List<wxchapter> chapterList { get; set; }

        /// <summary>
        /// 根据当前最新章节列表数据&当前线上最新章节id数据获取下一个章节数据,算法就是查找到当前线上最大章节数据然后取其下一个章节的数据信息
        /// </summary>
        /// <param name="chapterList"></param>
        /// <param name="maxchapterid"></param>
        public static wxchapter GetNextChapter(List<wxchapter> chapterList, string maxchapterid)
        {
            if (chapterList == null || chapterList.Count == 0)
            {
                return null;
            }

            if (string.IsNullOrEmpty(maxchapterid))
            {
                return chapterList.First();
            }

            bool isCurrent = false;
            foreach (var item in chapterList)
            {
                if (isCurrent)
                {
                    return item;
                }

                if (String.Equals(item.Id.ToString(), maxchapterid, StringComparison.CurrentCultureIgnoreCase))
                {
                    isCurrent = true;
                }
            }
            return null;
        }
    }
}
