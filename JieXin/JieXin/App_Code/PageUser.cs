using System;
using System.Collections.Generic;
using System.Web;
using AnyWell.AW_DL;

/// <summary>
///PageUser 的摘要说明
/// </summary>
public class PageUser : PageBase
{
    public PageUser()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    protected override void OnPreInit( EventArgs e )
    {
        base.OnPreInit( e );
        if( this.LoginUser == null )
        {
            Response.Redirect( "/login.aspx" );
        }
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
    protected string getCurrTypeString(int currTypeID)
    {
        switch( currTypeID )
        {
            case 1:
                return "港币";
            case 2:
                return "美元";
            case 3:
                return "日元";
            case 4:
                return "欧元";
            case 5:
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
}
