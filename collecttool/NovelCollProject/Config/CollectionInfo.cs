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
            CollctionModelList.Add(model_1003);
        }

        /// <summary>
        /// 春野小村医_1002
        /// </summary>
        public static CollectionModel model_1002 = new CollectionModel(
            "web_hkslg520",
            "http://www.hkslg520.com/167/167695/?chapterlist", 
            1002,
            "春野小村医",
            @"回乡小农民无意得神农咒语，开始了自己强悍的人生。青山绿水，他要打造一片人间乐土。钱要有，美女更要有！村花校花、人妻少妇……等等，我今晚该在哪个房间睡？",
            "http://m.hkslg520.com/modules/article/images/nocover.jpg",
            "chunyexiaocunyi", 
            "nothing");

        /// <summary>
        /// 美艳冥妻_1004 --已完结
        /// </summary>
        public static CollectionModel model_1004 = new CollectionModel(
            "web_yikanxiaoshuo",
            "http://www.yikanxiaoshuo.com/yikan/337699/",
            1004,
            "美艳冥妻",
            @"堂哥结婚，新娘子很漂亮，我和几个堂兄弟闹洞房的时候头脑发热做出了荒唐事，以至于喜事变成了丧事……",
            "http://img.yikanxiaoshuo.com/337/337699/337699s.jpg",
            "meiyanmingqi",
            "nothing");


        /// <summary>
        /// 透视小村医_1003 --已完结
        /// </summary>
        public static CollectionModel model_1003 = new CollectionModel(
            "web_ziyouge",
            "http://www.ziyouge.com/zy/12/12122/index.html?chapterlist",
            1003,
            "透视小村医",
            @"穷屌丝小农民，凭着神针入体，拥有透视功能。 从而，种田，看病，经商雄霸一方。 坐拥花丛，脚踢枭雄。 激情热血，美艳盈怀。 透视小村医，带你装比带你飞。",
            "http://t.ziyouge.com/12/12122/12122s.jpg",
            "toushixiaocunyi",
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
