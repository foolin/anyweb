using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;


public class PageBase : Page
{
    public PageBase()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    protected string QS(string key)
    {
        return Request.QueryString[key] + "";
    }

    protected string QF(string key)
    {
        return Request.Form[key] + "";
    }

    protected string getDegreeStr(int DegreeId)
    {
        switch (DegreeId)
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
                return "其他";
        }
    }
}
