using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Admin.Framework;
using Studio.Web;
using Common.Agent;
using Common.Common;
using System.IO;
using System.Collections.Generic;

public partial class Admin_GiftPackGoodsAdd : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (QS("pid") + "" == "")
        {
            WebAgent.AlertAndBack("非法大礼包ID！");
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        Response.Redirect("GiftPackGoodsAdd.aspx?pid="+ QS("pid").ToString() +"&goodsName=" + txtName.Text + "&cid=" + int.Parse(drpType.SelectedValue) + "&status=" + int.Parse(drpStatus.SelectedValue));
    }

    public string CheckStatus(int status)
    {
        string s = "";
        if (status == 1)
        {
            s = "<font color='green'>有货</font>";
        }
        if (status == 2)
        {
            s = "<font color='red'>缺货</font>";
        }
        if (status == 3)
        {
            s = "<font color='gray'>过期</font>";
        }
        if (status == 4)
        {
            s = "<font color='gray'>不显示在首页</font>";
        }
        return s;
    }

    protected void drpType_DataBound(object sender, EventArgs e)
    {
        ListItem item = new ListItem("所有商品", "0");
        drpType.Items.Insert(0, item);
        int cid = 0;
        if (WebAgent.IsInt32(QS("cid")))
        {
            cid = int.Parse(QS("cid"));
        }
        drpType.SelectedValue = cid.ToString();
    }

    protected void ods3_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.OutputParameters["recordCount"] != null)
        {
            int record = (int)e.OutputParameters["recordCount"];
            PN1.SetPage(record);

        }
        drpStatus.SelectedValue = QS("status");
    }

    protected void ods3_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (WebAgent.IsInt32(QS("cid")))
        {
            e.InputParameters["categoryID"] = int.Parse(QS("cid"));
        }

        if (WebAgent.IsInt32(QS("status")))
        {
            e.InputParameters["status"] = int.Parse(QS("status"));
        }

        if (QS("recommd") + "" != "")
        {
            e.InputParameters["isrecommend"] = bool.Parse(QS("recommd").ToString());
        }
        if (QS("promot") + "" != "")
        {
            e.InputParameters["ispromoted"] = bool.Parse(QS("promot").ToString());
        }
        e.InputParameters["goodsName"] = QS("goodsName");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if(QS("pid") + "" == "" || !WebAgent.IsInt32(QS("pid"))){
            WebAgent.AlertAndBack("大礼包ID参数错误");
        }
        if ((Request.Form["ids"] + "") == "")
        {
            WebAgent.AlertAndBack("请选择要添加选项");
        }
        string addGoodsIds = (string)Request.Form["ids"]; //添加Ids
        GiftPackageAgent gpAgent = new GiftPackageAgent();
        GiftPackage gp = gpAgent.GetGiftPackageByID(int.Parse(QS("pid")));
        if(gp == null)
        {
            WebAgent.AlertAndBack("大礼包ID参数错误，不存在该大礼包");
        }

        string[] arrGoodsIds = gp.GoodsIds.Split(",".ToCharArray());
        string[] arrAddGoodsIds = addGoodsIds.Split(",".ToCharArray());
        string newGoodsIds = "";

        //添加商品
        List<string> list = new List<string>();
        for (int i = 0; i < arrGoodsIds.Length; i++)
        {
            list.Add(arrGoodsIds[i]);
        }
        for (int i = 0; i < arrAddGoodsIds.Length; i++)//遍历数组成员  
        {
            if (!list.Contains(arrAddGoodsIds[i]))//对每个成员做一次新数组查询如果没有相等的则加到新数组
            {
                list.Add(arrAddGoodsIds[i]);
            }
        }
        for (int i = 0; i < list.Count; i++)//遍历数组成员  
        {
            if (list[i] != "")
            {
                newGoodsIds = newGoodsIds + list[i] + ",";
            }
        }
        if (newGoodsIds.Substring(newGoodsIds.Length - 1, 1) == ",")
        {
            newGoodsIds = newGoodsIds.Substring(0, newGoodsIds.Length - 1);
        }
        //WebAgent.AlertAndBack("OldIds:"+ gp.GoodsIds +" addIds:"+addGoodsIds+" newIds:"+newGoodsIds);
        gp.GoodsIds = newGoodsIds;
        if (gpAgent.UpdateGiftPackage(gp) > 0)
        {
            this.AddLog(EventID.Insert, "添加大礼包产品", "批量添加大礼包产品，编号:" + addGoodsIds);
            WebAgent.SuccAndGo("添加大礼包产品成功", "GiftPackGoodsEdit.aspx?pid="+QS("pid"));
        }
        else
        {
            WebAgent.FailAndGo("批量添加大礼包产品失败！");
        }

    }


}
