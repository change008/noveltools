﻿using System;
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
            CollctionModelList.Add(model_1003);
            CollctionModelList.Add(model_1004);
            CollctionModelList.Add(model_1005);
            CollctionModelList.Add(model_1006);
            CollctionModelList.Add(model_1007);
            CollctionModelList.Add(model_1008);
            CollctionModelList.Add(model_1009);
            CollctionModelList.Add(model_1010);
            CollctionModelList.Add(model_1011);
            CollctionModelList.Add(model_1012);
            CollctionModelList.Add(model_1013);
            CollctionModelList.Add(model_1014);
            CollctionModelList.Add(model_1015);
            CollctionModelList.Add(model_1016);
            CollctionModelList.Add(model_1017);
        }

        #region 采集小说配置
        /// <summary>
        /// 春野小村医_1002 连载中 
        /// </summary>
        public static CollectionModel model_1002 = new CollectionModel(
            1,
            "web_hkslg520",
            "http://www.hkslg520.com/167/167695/?chapterlist", 
            1002,
            "春野小村医",
            @"回乡小农民无意得神农咒语，开始了自己强悍的人生。青山绿水，他要打造一片人间乐土。钱要有，美女更要有！村花校花、人妻少妇……等等，我今晚该在哪个房间睡？",
            "http://m.hkslg520.com/modules/article/images/nocover.jpg",
            "chunyexiaocunyi", 
            "nothing");

        /// <summary>
        /// 透视小村医_1003 --已完结
        /// </summary>
        public static CollectionModel model_1003 = new CollectionModel(
            2,
            "web_ziyouge",
            "http://www.ziyouge.com/zy/12/12122/index.html?chapterlist",
            1003,
            "透视小村医",
            @"穷屌丝小农民，凭着神针入体，拥有透视功能。 从而，种田，看病，经商雄霸一方。 坐拥花丛，脚踢枭雄。 激情热血，美艳盈怀。 透视小村医，带你装比带你飞。",
            "http://t.ziyouge.com/12/12122/12122s.jpg",
            "toushixiaocunyi",
            "nothing");

        /// <summary>
        /// 美艳冥妻_1004 --已完结
        /// </summary>
        public static CollectionModel model_1004 = new CollectionModel(
            2,
            "web_yikanxiaoshuo",
            "http://www.yikanxiaoshuo.com/yikan/337699/",
            1004,
            "美艳冥妻",
            @"堂哥结婚，新娘子很漂亮，我和几个堂兄弟闹洞房的时候头脑发热做出了荒唐事，以至于喜事变成了丧事……",
            "http://img.yikanxiaoshuo.com/337/337699/337699s.jpg",
            "meiyanmingqi",
            "nothing");

        /// <summary>
        /// 小村那些事_1005 --连载中 //"http://www.wxguan.com/wenzhang/75/75123/?chapterlist",
        /// </summary>
        public static CollectionModel model_1005 = new CollectionModel(
            1,
            "web_lwxs",
            "http://www.lwxs.com/shu/41/41439/?chapterlist",  
            1005,
            "小村那些事",
            @"自从村子里出了个杨小宝，乡村生活开始丰富了起来。比如帮寡妇马老师家里打打旱井。帮美女丽丽赶跑追求她的流氓。帮隔壁雪梅婶婶治愈多年不育的顽疾。帮村里修通了通往镇上的大路。乡亲们，姐妹们，我杨小宝来了！",
            "http://danhuang.zhanlve5.com/static/image/s_cover.jpg",
            "xiaocunnaxieshi",
            "nothing");

        /// <summary>
        /// 妇科小村医_1006 --已完结
        /// </summary>
        public static CollectionModel model_1006 = new CollectionModel(
            2,
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
            1,
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
            1,
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
            1,
            "web_qb520",
            "http://www.qb520.org/xiaoshuo/9/9621/?chapterlist",
            1009,
            "假面娇妻",
            @"结婚纪念日妻子晚归，李泽发现了妻子身上的异常。而当李泽确定妻子不仅在上班期间洗过澡，而且身上还少了某样东西时，李泽意识到妻子可能已经出轨……",
            "http://danhuang.zhanlve5.com/static/image/s_cover.jpg",
            "jiamianjiaoqi",
            "nothing");

        /// <summary>
        /// 我在殡仪馆工作的那些事_1010 --未完结
        /// </summary>
        public static CollectionModel model_1010 = new CollectionModel(
            1,
            "web_shumanwu",
            "http://www.shumanwu.net/1/1888/index.html?chapterlist",
            1010,
            "神秘殡仪馆的一些事",
            @"有一天殡仪馆里来了一具身名牌的漂亮女尸，我把这套香奈儿偷了回去，送给了女朋友，接着，一连串的邪门事情发生了……接连的死亡，一步步逼近我跟大胖，我们又该如何逃脱死神的追逐？",
            "http://www.shumanwu.net/files/article/image//1/1888/1888s.jpg",
            "shenmibinyiguan",
            "nothing");

        /// <summary>
        /// 堕落女友_1011 --已完结
        /// </summary>
        public static CollectionModel model_1011 = new CollectionModel(
            2,
            "web_qqkanshu",
            "http://www.qqkanshu.com/duoluonvyou/?chapterlist",
            1011,
            "沉沦的女友",
            @"我们的感情历经坎坷与猜忌，在不断成熟起来的年纪，我跟女友的感情是不是能够在这种纸醉金迷的世界中义无反顾的走下去，这不是我与女友感情的磨难，更是对现实与世界的抗争。",
            "http://www.qqkanshu//uploads/temp/wd/duoluonvyou.png",
            "chenlunnvyou",
            "nothing");

        /// <summary>
        /// 今晚有料_1012 --连载中, 原今夜有戏
        /// </summary>
        public static CollectionModel model_1012 = new CollectionModel(
            1,
            "web_51cxw",
            "http://www.51cxw.cn/cxw7195/?chapterlist",
            1012,
            "今晚有料",
            @"因为尴尬的事情，我装作聋哑人做了上门女婿。    各位书友要是觉得《今夜有戏》还不错的话请不要忘记向您QQ群和微博里的朋友推荐哦！",
            "http://danhuang.zhanlve5.com/static/image/mycover_a.jpg",
            "jinwanyouliao",
            "nothing");

        /// <summary>
        /// 感谢青春_1013 --已完结, 原白姐
        /// </summary>
        public static CollectionModel model_1013 = new CollectionModel(
            2,
            "web_126shu",
            "http://www.126shu.com/65549/?chapterlist",
            1013,
            "感谢青春",
            @"感谢青春，让我在一无所有的年纪，遇到了青春靓丽的你。 ",
            "http://danhuang.zhanlve5.com/static/image/mycover_a.jpg",
            "ganxieqingchun",
            "nothing");

        /// <summary>
        /// 多娇山村_1014 --已完结, 
        /// </summary>
        public static CollectionModel model_1014 = new CollectionModel(
            2,
            "web_ybdu",
            "http://www.ybdu.com/xiaoshuo/18/18562/?chapterlist",
            1014,
            "多娇山村",
            @"他是一个小农民，他艳福不浅，美女、熟妇纷至沓来。他外表憨厚，却独具野心，他财运滚滚，赚钱赚到手发软。",
            "http://danhuang.zhanlve5.com/static/image/mycover_a.jpg",
            "duojiaoshancun",
            "nothing");
        #endregion

        /// <summary>
        /// 血色爱恋 原名 血色浪漫_1015 --已完结, 
        /// </summary>
        public static CollectionModel model_1015 = new CollectionModel(
            2,
            "web_yrnew",
            "http://www.yrnew.net/plugin.php?id=jameson_read&contrl=index&act=book&book_id=66",
            1015,
            "血色爱恋",
            @"十八岁之前，我过着非人的生活，直到尊严被极度践踏的生日夜…… 我努力冲向未来……",
            "http://danhuang.zhanlve5.com/static/image/mycover_a.jpg",
            "xueseailian",
            "nothing");

        /// <summary>
        /// 邪魔保镖 原名 妖孽保镖_1016 --已完结, 
        /// </summary>
        public static CollectionModel model_1016 = new CollectionModel(
            2,
            "web_qb5200",
            "http://www.qb5200.org/xiaoshuo/68/68506/?chapterlist",
            1016,
            "邪魔保镖",
            @"这货工作之余揽私活儿，一个人承接多位美女的保护任务；他敢于狂吃窝边草，当然还有窝外的草，以及其他草、所有草。一个妖孽如谜的男人，一群形形色色的女人，演绎了万花丛中的一段段离奇韵事。",
            "http://danhuang.zhanlve5.com/static/image/mycover_a.jpg",
            "xiemobaobiao",
            "nothing");

        /// <summary>
        /// 生态园里的爱恋 原名 寡嫂_1017 --已完结, 
        /// </summary>
        public static CollectionModel model_1017 = new CollectionModel(
            1,
            "web_lwtxt",
            "http://www.lwtxt.net/book/48/48138/?chapterlist",
            1017,
            "生态园里的爱恋",
            @"我没有血缘关系的哥不幸死了，为了保护年轻漂亮的嫂子，两年前我因为她差点杀人，逃出山村。 现在回来了，我继续要保护嫂子，跟她一起过人生。但却碰上了生态园的成熟美艳女经理，俏丽的小护士，还有村里的小妖女和生态园的贵妇女客人，让我十八岁的青春很多彩",
            "http://danhuang.zhanlve5.com/static/image/mycover_a.jpg",
            "shengtaiyuan",
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
        public CollectionModel(int status, string plugin, string url, int collectionId, string name, string intr, string coverImgs, string uniqueFlag, string remark,bool isUtf8 = false)
        {
            this.status = status;
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
        /// status 状态0:未上线, 1:连载中, 2:已完结, 
        /// </summary>
        public int status { get; set; }

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
