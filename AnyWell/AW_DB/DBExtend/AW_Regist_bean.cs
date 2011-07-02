using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Regist_bean
	{
        /// <summary>
        /// 称谓
        /// </summary>
        public string Appellation
        {
            get
            {
                switch( fdRegiAppellation )
                {
                    case 1:
                        return "先生";
                    case 2:
                        return "小姐";
                    case 3:
                        return "女士";
                    default:
                        return "博士";
                }
            }
        }

        /// <summary>
        /// 职务类型
        /// </summary>
        public string PositionType
        {
            get
            {
                switch( fdRegiPositionType )
                {
                    case 1:
                        return "高级管理层（执行总裁、总裁、企业法人）";
                    case 2:
                        return "董事，总经理，副经理";
                    case 3:
                        return "中级管理层（零售部经理，部门经理等）";
                    case 4:
                        return "经理（销售经理，市场部经理等）";
                    case 5:
                        return "采购部（产品部经理、一般买家）";
                    default:
                        return "其他";
                }
            }
        }

        /// <summary>
        /// 国家/地区
        /// </summary>
        public string Country
        {
            get
            {
                switch( fdRegiCountry )
                {
                    case 86:
                        return "中国大陆";
                    case 852:
                        return "中国香港";
                    case 853:
                        return "中国澳门";
                    case 886:
                        return "中国台湾";
                    case 93:
                        return "阿富汗";
                    case 355:
                        return "阿尔巴尼亚";
                    case 213:
                        return "阿尔及利亚";
                    case 376:
                        return "安道尔";
                    case 244:
                        return "安哥拉";
                    case 1264:
                        return "安圭拉岛英";
                    case 54:
                        return "阿根廷";
                    case 374:
                        return "亚美尼亚";
                    case 297:
                        return "阿鲁巴岛";
                    case 247:
                        return "阿森松(英)";
                    case 61:
                        return "澳大利亚";
                    case 43:
                        return "奥地利";
                    case 994:
                        return "阿塞拜疆";
                    case 1242:
                        return "巴哈马";
                    case 973:
                        return "巴林";
                    case 880:
                        return "孟加拉国";
                    case 1246:
                        return "巴巴多斯";
                    case 375:
                        return "白俄罗斯";
                    case 32:
                        return "比利时";
                    case 501:
                        return "伯利兹";
                    case 229:
                        return "贝宁";
                    case 1441:
                        return "百慕大群岛";
                    case 975:
                        return "不丹";
                    case 591:
                        return "玻利维亚";
                    case 387:
                        return "波黑";
                    case 267:
                        return "博茨瓦纳";
                    case 55:
                        return "巴西";
                    case 673:
                        return "文莱";
                    case 359:
                        return "保加利亚";
                    case 226:
                        return "布基纳法索";
                    case 95:
                        return "缅甸";
                    case 257:
                        return "布隆迪";
                    case 855:
                        return "柬埔寨";
                    case 237:
                        return "喀麦隆";
                    case 10:
                        return "加拿大";
                    case 238:
                        return "佛得角";
                    case 1345:
                        return "开曼群岛";
                    case 236:
                        return "中非";
                    case 235:
                        return "乍得";
                    case 56:
                        return "智利";
                    case 57:
                        return "哥伦比亚";
                    case 269:
                        return "科摩罗";
                    case 242:
                        return "刚果";
                    case 682:
                        return "科克群岛";
                    case 506:
                        return "哥斯达黎加";
                    case 385:
                        return "克罗地亚";
                    case 53:
                        return "古巴";
                    case 357:
                        return "塞浦路斯";
                    case 420:
                        return "捷克";
                    case 45:
                        return "丹麦";
                    case 253:
                        return "吉布提";
                    case 1767:
                        return "多米尼加";
                    case 1809:
                        return "多米尼加共和国";
                    case 593:
                        return "厄瓜多尔";
                    case 20:
                        return "埃及";
                    case 503:
                        return "萨尔瓦多";
                    case 240:
                        return "赤道几内亚";
                    case 291:
                        return "厄立特里亚";
                    case 372:
                        return "爱沙尼亚";
                    case 251:
                        return "埃塞俄比亚";
                    case 500:
                        return "福克兰群岛";
                    case 679:
                        return "斐济";
                    case 358:
                        return "芬兰";
                    case 33:
                        return "法国";
                    case 594:
                        return "法属圭亚那";
                    case 241:
                        return "加蓬";
                    case 220:
                        return "冈比亚";
                    case 995:
                        return "格鲁吉亚";
                    case 49:
                        return "德国";
                    case 233:
                        return "加纳";
                    case 350:
                        return "直布罗陀";
                    case 30:
                        return "希腊";
                    case 299:
                        return "格陵兰岛";
                    case 1473:
                        return "格林纳达";
                    case 1671:
                        return "关岛";
                    case 502:
                        return "危地马拉";
                    case 224:
                        return "几内亚";
                    case 245:
                        return "几内亚比绍";
                    case 592:
                        return "圭亚那";
                    case 509:
                        return "海地";
                    case 504:
                        return "洪都拉斯";
                    case 36:
                        return "匈牙利";
                    case 354:
                        return "冰岛";
                    case 91:
                        return "印度";
                    case 62:
                        return "印度尼西亚";
                    case 98:
                        return "伊朗";
                    case 964:
                        return "伊拉克";
                    case 353:
                        return "爱尔兰";
                    case 972:
                        return "以色列";
                    case 39:
                        return "意大利";
                    case 225:
                        return "科特迪瓦";
                    case 1876:
                        return "牙买加";
                    case 81:
                        return "日本";
                    case 962:
                        return "约旦";
                    case 7:
                        return "哈萨克斯坦";
                    case 254:
                        return "肯尼亚";
                    case 686:
                        return "基里巴斯";
                    case 82:
                        return "韩国";
                    case 965:
                        return "科威特";
                    case 996:
                        return "吉尔吉斯坦";
                    case 856:
                        return "老挝";
                    case 371:
                        return "拉脱维亚";
                    case 961:
                        return "黎巴嫩";
                    case 266:
                        return "莱索托";
                    case 231:
                        return "利比里亚";
                    case 218:
                        return "利比亚";
                    case 423:
                        return "列支敦士登";
                    case 370:
                        return "立陶宛";
                    case 352:
                        return "卢森保";
                    case 389:
                        return "马其顿";
                    case 261:
                        return "马达加斯加";
                    case 265:
                        return "马拉维";
                    case 60:
                        return "马来西亚";
                    case 960:
                        return "马尔代夫";
                    case 223:
                        return "马里";
                    case 356:
                        return "马耳他";
                    case 670:
                        return "马里亚纳群岛";
                    case 692:
                        return "马绍尔群岛";
                    case 596:
                        return "马提尼克";
                    case 222:
                        return "毛里塔尼亚";
                    case 230:
                        return "毛里求斯";
                    case 270:
                        return "马约特岛";
                    case 52:
                        return "墨西哥";
                    case 373:
                        return "摩尔多瓦";
                    case 377:
                        return "摩纳哥";
                    case 976:
                        return "蒙古";
                    case 1664:
                        return "蒙特塞拉特岛";
                    case 212:
                        return "摩洛哥";
                    case 258:
                        return "莫桑比克";
                    case 264:
                        return "纳米比亚";
                    case 674:
                        return "瑙鲁";
                    case 977:
                        return "尼泊尔";
                    case 31:
                        return "荷兰";
                    case 64:
                        return "新西兰";
                    case 505:
                        return "尼加拉瓜";
                    case 227:
                        return "尼日尔";
                    case 234:
                        return "尼日利亚";
                    case 683:
                        return "纽埃岛(新)";
                    case 672:
                        return "诺福克岛";
                    case 850:
                        return "朝鲜";
                    case 47:
                        return "挪威";
                    case 968:
                        return "阿曼";
                    case 92:
                        return "巴基斯坦";
                    case 507:
                        return "巴拿马";
                    case 675:
                        return "巴布亚新几内亚";
                    case 595:
                        return "巴拉圭";
                    case 51:
                        return "秘鲁";
                    case 63:
                        return "菲律宾";
                    case 48:
                        return "波兰";
                    case 351:
                        return "葡萄牙";
                    case 1787:
                        return "波多黎各";
                    case 974:
                        return "卡塔尔";
                    case 262:
                        return "留尼汪岛";
                    case 40:
                        return "罗马尼亚";
                    case 8:
                        return "俄罗斯";
                    case 250:
                        return "卢旺达";
                    case 685:
                        return "萨摩亚";
                    case 378:
                        return "圣马力诺";
                    case 966:
                        return "沙特阿拉伯";
                    case 221:
                        return "塞内加尔";
                    case 248:
                        return "塞舌尔";
                    case 232:
                        return "塞拉利昂";
                    case 65:
                        return "新加坡";
                    case 421:
                        return "斯洛伐克";
                    case 386:
                        return "斯洛文尼亚";
                    case 677:
                        return "所罗门群岛";
                    case 252:
                        return "索马里";
                    case 27:
                        return "南非";
                    case 34:
                        return "西班牙";
                    case 94:
                        return "斯里兰卡";
                    case 290:
                        return "圣赫勒拿";
                    case 1758:
                        return "圣卢西亚";
                    case 249:
                        return "苏丹";
                    case 597:
                        return "苏里南";
                    case 268:
                        return "斯威士兰";
                    case 46:
                        return "瑞典";
                    case 41:
                        return "瑞士";
                    case 963:
                        return "叙利亚";
                    case 255:
                        return "坦桑尼亚";
                    case 66:
                        return "泰国";
                    case 228:
                        return "多哥";
                    case 690:
                        return "托克劳群岛(新)";
                    case 676:
                        return "汤加";
                    case 216:
                        return "突尼斯";
                    case 90:
                        return "土耳其";
                    case 993:
                        return "土库曼斯坦";
                    case 688:
                        return "图瓦卢";
                    case 971:
                        return "阿联酋";
                    case 256:
                        return "乌干达";
                    case 380:
                        return "乌克兰";
                    case 44:
                        return "英国";
                    case 1:
                        return "美国";
                    case 598:
                        return "乌拉圭";
                    case 998:
                        return "乌兹别克斯坦";
                    case 678:
                        return "瓦努阿图";
                    case 379:
                        return "梵蒂冈";
                    case 58:
                        return "委内瑞拉";
                    case 84:
                        return "越南";
                    case 1808:
                        return "威克岛(美)";
                    case 967:
                        return "也门";
                    case 381:
                        return "南斯拉夫";
                    case 243:
                        return "扎伊尔";
                    case 260:
                        return "赞比亚";
                    case 263:
                        return "津巴布韦";
                    default:
                        return "未知";
                }
            }
        }

        /// <summary>
        /// 阁下主要的业务类别是
        /// </summary>
        public string Business
        {
            get
            {
                string[] business = fdRegiBusiness.Split( ':' );
                if( business.Length == 2 )
                {
                    return "其他，请注明：" + business[ 1 ];
                }
                else
                {
                    switch( business[0] )
                    {
                        case "1":
                            return "相关生产企业";
                        case "2":
                            return "电视购物等新渠道商";
                        case "3":
                            return "各类电器经销商、超市、连锁店、商场";
                        case "4":
                            return "相关政府部门、协会组织";
                        case "5":
                            return "各类电器出口商";
                        case "6":
                            return "相关就人员";
                        case "7":
                            return "各类电器维修、服务企业";
                        case "8":
                            return "相关出版物、媒体";
                        case "9" :
                            return "礼品采购商、制造商";
                        default:
                            return "";
                    }
                }
            }
        }

        /// <summary>
        /// 黑色家电
        /// </summary>
        public string Target1
        {
            get
            {
                string strTemp = "";
                string[] target = fdRegiTarget1.Split( ':' );
                foreach( string str in target[ 0 ].Split( ',' ) )
                {
                    switch( str )
                    {
                        case "1":
                            strTemp += "电视机;";
                            break;
                        case "2":
                            strTemp += "录像机、VCD和DVD;";
                            break;
                        case "3":
                            strTemp += "音响;";
                            break;
                        default:
                            break;
                    }
                }
                if( target.Length == 2 )
                {
                    strTemp += "其他，请注明:" + target[ 1 ];
                }
                return strTemp;
            }
        }

        /// <summary>
        /// 白色家电
        /// </summary>
        public string Target2
        {
            get
            {
                string strTemp = "";
                foreach( string str in fdRegiTarget2.Split( ',' ) )
                {
                    switch( str )
                    {
                        case "1":
                            strTemp += "空调;";
                            break;
                        case "2":
                            strTemp += "冰柜;";
                            break;
                        case "3":
                            strTemp += "电冰箱;";
                            break;
                        case "4":
                            strTemp += "洗衣机;";
                            break;
                        default:
                            break;
                    }
                }
                return strTemp;
            }
        }

        /// <summary>
        /// 小家电
        /// </summary>
        public string Target3
        {
            get
            {
                string strTemp = "";
                string[] target = fdRegiTarget3.Split( ':' );
                foreach( string str in target[ 0 ].Split( ',' ) )
                {
                    switch( str )
                    {
                        case "1":
                            strTemp += "电磁炉;";
                            break;
                        case "2":
                            strTemp += "电吹风;";
                            break;
                        case "3":
                            strTemp += "电热水器;";
                            break;
                        case "4":
                            strTemp += "电暖器和暖风机;";
                            break;
                        case "5":
                            strTemp += "电风扇和换气扇;";
                            break;
                        case "6":
                            strTemp += "加湿器和抽湿器;";
                            break;
                        case "7":
                            strTemp += "吸尘器;";
                            break;
                        case "8":
                            strTemp += "干衣机;";
                            break;
                        case "9":
                            strTemp += "电熨斗;";
                            break;
                        default:
                            break;
                    }
                }
                if( target.Length == 2 )
                {
                    strTemp += "其他，请注明:" + target[ 1 ];
                }
                return strTemp;
            }
        }

        /// <summary>
        /// 厨房及浴室家电
        /// </summary>
        public string Target4
        {
            get
            {
                string strTemp = "";
                foreach( string str in fdRegiTarget4.Split( ',' ) )
                {
                    switch( str )
                    {
                        case "1":
                            strTemp += "微波炉;";
                            break;
                        case "2":
                            strTemp += "榨汁机和搅拌机;";
                            break;
                        case "3":
                            strTemp += "燃气炉具;";
                            break;
                        case "4":
                            strTemp += "咖啡机和面包机;";
                            break;
                        case "5":
                            strTemp += "吸油烟机;";
                            break;
                        case "6":
                            strTemp += "电热水壶和浴霸;";
                            break;
                        case "7":
                            strTemp += "消毒柜;";
                            break;
                        case "8":
                            strTemp += "面包机;";
                            break;
                        case "9":
                            strTemp += "饮水机;";
                            break;
                        case "10":
                            strTemp += "电热水壶;";
                            break;
                        case "11":
                            strTemp += "电饭煲和洗碗机;";
                            break;
                        case "12":
                            strTemp += "浴霸;";
                            break;
                        case "13":
                            strTemp += "电烤箱;";
                            break;
                        default:
                            break;
                    }
                }
                return strTemp;
            }
        }

        /// <summary>
        /// 家电配件
        /// </summary>
        public string Target5
        {
            get
            {
                string strTemp = "";
                string[] target = fdRegiTarget5.Split( ':' );
                foreach( string str in target[ 0 ].Split( ',' ) )
                {
                    switch( str )
                    {
                        case "1":
                            strTemp += "压缩机;";
                            break;
                        case "2":
                            strTemp += "元器件;";
                            break;
                        case "3":
                            strTemp += "电机;";
                            break;
                        case "4":
                            strTemp += "包装印刷;";
                            break;
                        case "5":
                            strTemp += "原材料;";
                            break;
                        case "6":
                            strTemp += "模具;";
                            break;
                        default:
                            break;
                    }
                }
                if( target.Length == 2 )
                {
                    strTemp += "其他，请注明:" + target[ 1 ];
                }
                return strTemp;
            }
        }

        /// <summary>
        /// 服务及刊物
        /// </summary>
        public string Target6
        {
            get
            {
                string strTemp = "";
                string[] target = fdRegiTarget6.Split( ':' );
                foreach( string str in target[ 0 ].Split( ',' ) )
                {
                    switch( str )
                    {
                        case "1":
                            strTemp += "服务公司;";
                            break;
                        case "2":
                            strTemp += "媒体及刊物;";
                            break;
                        default:
                            break;
                    }
                }
                if( target.Length == 2 )
                {
                    strTemp += "其他，请注明:" + target[ 1 ];
                }
                return strTemp;
            }
        }

        /// <summary>
        /// 阁下主要的工作职能
        /// </summary>
        public string Function
        {
            get
            {
                string strTemp = "";
                string[] function = fdRegiFunction.Split( ':' );
                foreach( string str in function[ 0 ].Split( ',' ) )
                {
                    switch( str )
                    {
                        case "1":
                            strTemp += "研究与发展管理;";
                            break;
                        case "2":
                            strTemp += "市场管理;";
                            break;
                        case "3":
                            strTemp += "总经理;";
                            break;
                        case "4":
                            strTemp += "生产 / 制造;";
                            break;
                        case "5":
                            strTemp += "采购管理;";
                            break;
                        case "6":
                            strTemp += "顾问;";
                            break;
                        case "7":
                            strTemp += "销售管理;";
                            break;
                        case "8":
                            strTemp += "工程 / 设计 ;";
                            break;
                        default:
                            break;
                    }
                }
                if( function.Length == 2 )
                {
                    strTemp += "其他，请注明:" + function[ 1 ];
                }
                return strTemp;
            }
        }

        /// <summary>
        /// 阁下参观的目的
        /// </summary>
        public string Purpose
        {
            get
            {
                string strTemp = "";
                string[] purpose = fdRegiPurpose.Split( ':' );
                foreach( string str in purpose[ 0 ].Split( ',' ) )
                {
                    switch( str )
                    {
                        case "1":
                            strTemp += "采购产品;";
                            break;
                        case "2":
                            strTemp += "寻找OEM;";
                            break;
                        case "3":
                            strTemp += "收集信息;";
                            break;
                        case "4":
                            strTemp += "寻找代理或经销商;";
                            break;
                        case "5":
                            strTemp += "商务会谈;";
                            break;
                        case "6":
                            strTemp += "市场分析;";
                            break;
                        default:
                            break;
                    }
                }
                if( purpose.Length == 2 )
                {
                    strTemp += "其他，请注明:" + purpose[ 1 ];
                }
                return strTemp;
            }
        }

        /// <summary>
        /// 阁下是否参与决策贵司的购买/推荐产品权
        /// </summary>
        public string Decision
        {
            get
            {
                switch( fdRegiDecision )
                {
                    case 1:
                        return "是";
                    default:
                        return "否";
                }
            }
        }

        /// <summary>
        /// 如果是，阁下的采购预算大概为?
        /// </summary>
        public string Budget
        {
            get
            {
                switch( fdRegiBudget )
                {
                    case 1:
                        return "50000美元 – 250000美元";
                    case 2:
                        return "250001美元 – 500000美元";
                    case 3:
                        return "500001美元 – 1百万美元";
                    case 4:
                        return "1百万美元以上";
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// 阁下获知“顺德家电展”的渠道?
        /// </summary>
        public string From
        {
            get
            {
                string strTemp = "";
                string[] from = fdRegiFrom.Split( ':' );
                foreach( string str in from[ 0 ].Split( ',' ) )
                {
                    switch( str )
                    {
                        case "1":
                            strTemp += "参展商邀请;";
                            break;
                        case "2":
                            strTemp += "同事;";
                            break;
                        case "3":
                            strTemp += "网络;";
                            break;
                        case "4":
                            strTemp += "邮寄宣传资料;";
                            break;
                        case "5":
                            strTemp += "展会主办方邀请;";
                            break;
                        case "6":
                            strTemp += "行业商会;";
                            break;
                        case "7":
                            strTemp += "电子展迅;";
                            break;
                        case "8":
                            strTemp += "行业出版物;";
                            break;
                        case "9":
                            strTemp += "报纸;";
                            break;
                        default:
                            break;
                    }
                }
                if( from.Length == 2 )
                {
                    strTemp += "其他，请注明:" + from[ 1 ];
                }
                return strTemp;
            }
        }

        /// <summary>
        /// 阁下是否对我们的论坛和会议感兴趣？
        /// </summary>
        public string Interest
        {
            get
            {
                switch( fdRegiInterest )
                {
                    case 1:
                        return "是";
                    default:
                        return "否";
                }
            }
        }
	}
}
