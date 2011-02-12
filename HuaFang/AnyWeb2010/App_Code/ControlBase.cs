using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///ControlBase 的摘要说明
/// </summary>
public class ControlBase : System.Web.UI.UserControl
{
    public ControlBase()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 获取工作年限
    /// </summary>
    /// <param name="expId"></param>
    /// <returns></returns>
    protected string getExpString( int expId )
    {
        switch( expId )
        {
            case 1:
                return "1年以下";
            case 2:
                return "1-2年";
            case 3:
                return "2-5年";
            case 4:
                return "5-10年";
            case 5:
                return "10年以上";
            default:
                return "";
        }
    }

    /// <summary>
    /// 获取证件类型
    /// </summary>
    /// <param name="identId"></param>
    /// <returns></returns>
    protected string getIdentString( int identId )
    {
        switch( identId )
        {
            case 1:
                return "身份证";
            case 2:
                return "军人证";
            case 3:
                return "香港身份证";
            case 4:
                return "其他";
            default:
                return "";
        }
    }

    /// <summary>
    /// 获取年薪
    /// </summary>
    /// <param name="salaryId"></param>
    /// <returns></returns>
    protected string getSalaryString( int salaryId )
    {
        switch( salaryId )
        {
            case 1:
                return "2万以下";
            case 2:
                return "2-3万";
            case 3:
                return "3-4万";
            case 4:
                return "4-5万";
            case 5:
                return "5-6万";
            case 6:
                return "6-8万";
            case 7:
                return "8-10万";
            case 8:
                return "10-15万";
            case 9:
                return "15-30万";
            case 10:
                return "30-50万";
            case 11:
                return "50-100万";
            case 12:
                return "100万以上";
            default:
                return "";
        }
    }

    /// <summary>
    /// 获取币种
    /// </summary>
    /// <param name="currTypeID"></param>
    /// <returns></returns>
    protected string getCurrTypeString( int currTypeID )
    {
        switch( currTypeID )
        {
            case 1:
                return "人民币";
            case 2:
                return "港币";
            case 3:
                return "美元";
            case 4:
                return "日元";
            case 5:
                return "欧元";
            case 6:
                return "其它";
            default:
                return "";
        }
    }

    /// <summary>
    /// 获取求职状态
    /// </summary>
    /// <param name="currSituId"></param>
    /// <returns></returns>
    protected string getCurrSituString( int currSituId )
    {
        switch( currSituId )
        {
            case 1:
                return "目前正在找工作";
            case 2:
                return "半年内无换工作的计划";
            case 3:
                return "一年内无换工作的计划";
            case 4:
                return "观望有好的机会再考虑";
            case 5:
                return "我暂时不想找工作";
            default:
                return "";
        }
    }

    /// <summary>
    /// 获取国家地区
    /// </summary>
    /// <param name="countryId"></param>
    /// <returns></returns>
    protected string getCountryString( int countryId )
    {
        switch( countryId )
        {
            case 1:
                return "大陆";
            case 2:
                return "香港";
            case 3:
                return "澳门";
            case 4:
                return "台湾";
            case 5:
                return "国外";
            default:
                return "";
        }
    }

    /// <summary>
    /// 获取婚姻状况
    /// </summary>
    /// <param name="marryId"></param>
    /// <returns></returns>
    protected string getMarryString( int marryId )
    {
        switch( marryId )
        {
            case 1:
                return "未婚";
            case 2:
                return "已婚";
            default:
                return "";
        }
    }

    /// <summary>
    /// 获取学历
    /// </summary>
    /// <param name="degreeId"></param>
    /// <returns></returns>
    protected string getDegreeString( int degreeId )
    {
        switch( degreeId )
        {
            case 1:
                return "初中";
            case 2:
                return "高中";
            case 3:
                return "中技";
            case 4:
                return "中专";
            case 5:
                return "大专";
            case 6:
                return "本科";
            case 7:
                return "MBA";
            case 8:
                return "硕士";
            case 9:
                return "博士";
            case 10:
                return "其他";
            default:
                return "";
        }
    }

    /// <summary>
    /// 获取公司规模
    /// </summary>
    /// <param name="dimensionId"></param>
    /// <returns></returns>
    protected string getDimensionString( int dimensionId )
    {
        switch( dimensionId )
        {
            case 1:
                return "少于50人";
            case 2:
                return "50-150人";
            case 3:
                return "150-500人";
            case 4:
                return "500人以上";
            default:
                return "";
        }
    }

    /// <summary>
    /// 获取公司性质
    /// </summary>
    /// <param name="typeId"></param>
    /// <returns></returns>
    protected string getCompanyTypeString( int typeId )
    {
        switch( typeId )
        {
            case 1:
                return "外资(欧美)";
            case 2:
                return "外资(非欧美)";
            case 3:
                return "合资(欧美)";
            case 4:
                return "合资(非欧美)";
            case 5:
                return "国企";
            case 6:
                return "民营公司";
            case 7:
                return "外企代表处";
            case 8:
                return "政府机关";
            case 9:
                return "事业单位";
            case 10:
                return "非盈利机构";
            case 11:
                return "其它性质";
            default:
                return "";
        }
    }

    /// <summary>
    /// 获取语言类别
    /// </summary>
    /// <param name="typeId"></param>
    /// <returns></returns>
    protected string getLangTypeString( int typeId )
    {
        switch( typeId )
        {
            case 1:
                return "英语";
            case 2:
                return "日语";
            case 3:
                return "俄语";
            case 4:
                return "阿拉伯语";
            case 5:
                return "法语";
            case 6:
                return "德语";
            case 7:
                return "西班牙语";
            case 8:
                return "葡萄牙语";
            case 9:
                return "意大利语";
            case 10:
                return "韩语/朝鲜语";
            case 11:
                return "普通话";
            case 12:
                return "粤语";
            case 13:
                return "闽南语";
            case 14:
                return "上海话";
            case 15:
                return "其它";
            default:
                return "";
        }
    }

    /// <summary>
    /// 获取语言能力
    /// </summary>
    /// <param name="abilId"></param>
    /// <returns></returns>
    protected string getLangAbilityString( int abilId )
    {
        switch( abilId )
        {
            case 1:
                return "不限";
            case 2:
                return "一般";
            case 3:
                return "良好";
            case 4:
                return "熟练";
            case 5:
                return "精通";
            default:
                return "";
        }
    }

    /// <summary>
    /// 获取英语等级
    /// </summary>
    /// <param name="levelId"></param>
    /// <returns></returns>
    protected string getEnLevelString( int levelId )
    {
        switch( levelId )
        {
            case 1:
                return "未参加";
            case 2:
                return "未通过";
            case 3:
                return "英语四级";
            case 4:
                return "英语六级";
            case 5:
                return "专业四级";
            case 6:
                return "专业八级";
            default:
                return "";
        }
    }

    /// <summary>
    /// 获取日文等级
    /// </summary>
    /// <param name="levelId"></param>
    /// <returns></returns>
    protected string getJpLevelString( int levelId )
    {
        switch( levelId )
        {
            case 1:
                return "无";
            case 2:
                return "一级";
            case 3:
                return "二级";
            case 4:
                return "三级";
            case 5:
                return "四级";
            default:
                return "";
        }
    }

    /// <summary>
    /// 获取技能熟练程度
    /// </summary>
    /// <param name="skillId"></param>
    /// <returns></returns>
    protected string getSkillLevelString( int skillId )
    {
        switch( skillId )
        {
            case 1:
                return "精通";
            case 2:
                return "熟练";
            case 3:
                return "一般";
            case 4:
                return "了解";
            default:
                return "";
        }
    }

    /// <summary>
    /// 获取工作类型
    /// </summary>
    /// <param name="typeId"></param>
    /// <returns></returns>
    public string getObjeType( int typeId )
    {
        switch( typeId )
        {
            case 1:
                return "全职";
            case 2:
                return "兼职";
            case 3:
                return "实习";
            case 4:
                return "全/兼职";
            default:
                return "";
        }
    }

    /// <summary>
    /// 获取期望月薪
    /// </summary>
    /// <param name="saleId"></param>
    /// <returns></returns>
    public string getObjeSaleryString( int saleId )
    {
        switch( saleId )
        {
            case 1:
                return "1500以下";
            case 2:
                return "1500-1999";
            case 3:
                return "2000-2999";
            case 4:
                return "3000-4499";
            case 5:
                return "4500-5999";
            case 6:
                return "6000-7999";
            case 7:
                return "8000-9999";
            case 8:
                return "10000-14999";
            case 9:
                return "15000-19999";
            case 10:
                return "20000-29999";
            case 11:
                return "30000-49999";
            case 12:
                return "50000及以上";
            default:
                return "";
        }
    }

    /// <summary>
    /// 获取到岗时间
    /// </summary>
    /// <param name="timeId"></param>
    /// <returns></returns>
    public string getEntryTimeString( int timeId )
    {
        switch( timeId )
        {
            case 1:
                return "即时";
            case 2:
                return "一周以内";
            case 3:
                return "一个月内";
            case 4:
                return "1-3个月";
            case 5:
                return "三个月后";
            case 6:
                return "待定";
            default:
                return "";
        }
    }
}
