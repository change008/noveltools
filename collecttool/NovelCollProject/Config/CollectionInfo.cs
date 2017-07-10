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
            CollctionModelList.Add(model_1002);
            CollctionModelList.Add(model_1005);
            CollctionModelList.Add(model_1006);
            CollctionModelList.Add(model_1007);
            CollctionModelList.Add(model_1008);
            CollctionModelList.Add(model_1009);
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
        /// 小村那些事_1005 --连载中 //"http://www.wxguan.com/wenzhang/75/75123/?chapterlist",
        /// </summary>
        public static CollectionModel model_1005 = new CollectionModel(
            "web_lwxs",
            "http://www.lwxs.com/shu/41/41439/?chapterlist",  
            1005,
            "小村那些事",
            @"自从村子里出了个杨小宝，乡村生活开始丰富了起来。比如帮寡妇马老师家里打打旱井。帮美女丽丽赶跑追求她的流氓。帮隔壁雪梅婶婶治愈多年不育的顽疾。帮村里修通了通往镇上的大路。乡亲们，姐妹们，我杨小宝来了！",
            "http://danhuang.zhanlve5.com/static/image/s_cover.jpg",
            "xiaocunnaxieshi",
            "nothing");

        /// <summary>
        /// 妇科小村医_1006 --完结
        /// </summary>
        public static CollectionModel model_1006 = new CollectionModel(
            "web_quanshuwu",
            "http://www.quanshuwu.com/book/2714.aspx?chapterlist",
            1006,
            "妇科小村医",
            @"游手好闲的牛大壮意外学到了很多巫术风水等知识，从此，走上了一条风流快活的人生之路。",
            "http://danhuang.zhanlve5.com/static/image/s_cover.jpg",
            "fukexiaocunyi",
            "nothing",
            true);



        /// <summary>
        /// 神棍小村医_1007 --未完结
        /// </summary>
        public static CollectionModel model_1007 = new CollectionModel(
            "web_ziyouge",
            "http://www.ziyouge.com/zy/13/13066/index.html?chapterlist",
            1007,
            "神棍小村医",
            @"山村少年方小宇，因砸破奇石获异能，从此精通医术、风水、看相和鉴宝。 他点中了事业桃花双旺的风水宝地。开塘办厂建电站，带领乡亲奔小康。护士警花女教师，村花校花留守妇，模特明星女老总，桃花运来挡不住……",
            "http://danhuang.zhanlve5.com/static/image/s_cover.jpg",
            "shengunxiaocunyi",
            "nothing");

        /// <summary>
        /// 我把自己卖给了富婆_1008 --未完结
        /// </summary>
        public static CollectionModel model_1008 = new CollectionModel(
            "web_lingyu",
            "http://www.lingyu.org/wjsw/26/26325/?chapterlist",
            1008,
            "我把自己卖给了富婆",
            @"白富美出十万想要找个傻子结婚，我为了还债被迫装傻入赘豪门。本以为婚后可以过上梦幻般的生活，可没想到，自己迎来的不是桃花，而是厄运...",
            "http://danhuang.zhanlve5.com/static/image/s_cover.jpg",
            "wobazijimaigeilefupo",
            "nothing");

        /// <summary>
        /// 假面娇妻_1009 --未完结
        /// </summary>
        public static CollectionModel model_1009 = new CollectionModel(
            "web_qb520",
            "http://www.qb520.org/xiaoshuo/9/9621/?chapterlist",
            1009,
            "假面娇妻",
            @"结婚纪念日妻子晚归，李泽发现了妻子身上的异常。而当李泽确定妻子不仅在上班期间洗过澡，而且身上还少了某样东西时，李泽意识到妻子可能已经出轨……",
            "http://danhuang.zhanlve5.com/static/image/s_cover.jpg",
            "jiamianjiaoqi",
            "nothing");






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
        public CollectionModel(string plugin, string url, int collectionId, string name, string intr, string coverImgs, string uniqueFlag, string remark,bool isUtf8 = false)
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
            this.IsUTF8 = isUtf8;
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
