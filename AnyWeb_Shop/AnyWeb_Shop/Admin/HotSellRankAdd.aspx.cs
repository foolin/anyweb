﻿using System;
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
using Common.Common;
using Common.Agent;

public partial class Admin_HotSellRankAdd : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (QS("ids").ToString() + "" != "")
        {
            string reqIds = QS("ids").ToString();
            int count = 0;
            count = new HotSellRankAgent().GetGoodsCount();
            string[] arrIds = reqIds.Split(",".ToCharArray());  //按逗号将数据分割成一个数组
            if (arrIds.Length > 20)
                WebAgent.AlertAndBack("选择畅销商品最多20条！");
            if (count + arrIds.Length > 20)
            {
                //WebAgent.Alert("畅销商品数目已经超过20条，你必须删除" + (count + arrIds.Length - 20).ToString() + "条商品");
                lblTips.Text = "畅销商品数目已经超过<font color='blue'>20</font>条，你必须删除<font color='blue'>" + (count + arrIds.Length - 20).ToString() + "</font>条商品,才能继续添加！";
                lblTips2.Text = "新添加畅销商品数目为<font color='blue'>" + arrIds.Length.ToString() + "</font>条，已有畅销商品数目<font color='blue'>" + count.ToString() + "</font>条，已经超过<font color='blue'>20</font>条，你必须删除<font color='blue'>" + (count + arrIds.Length - 20).ToString() + "</font>条商品,才能继续添加！";
                txbAddIds.Text = reqIds.ToString(); //保存传入增加为商品的ID
              

            }
            else
            {
                using (HotSellRankAgent hsr = new HotSellRankAgent())
                {
                    for (int i = 0; i < arrIds.Length; i++ )
                        hsr.AddGoods(int.Parse(arrIds[i]));
                    this.AddLog(EventID.Insert, "添加畅销产品", "批量添加畅销产品，编号:" + reqIds);
                    WebAgent.SuccAndGo("添加畅销产品" + reqIds + "成功。", "HotSellRankList.aspx");
                }
            }
        }
        else
        {
            WebAgent.AlertAndBack("你未选择任何ID");
        }

        btnDel.Attributes["onclick"] = "javascript:return confirm('确定删除,是否继续？');";

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

    protected void btnDel_Click(object sender, EventArgs e)
    {
        if (Request.Form["ids"] + "" != "")
        {
            string[] arrIds = txbAddIds.Text.ToString().Split(",".ToCharArray());  //按逗号将数据分割成一个数组
            //判断是否选中够三条信息
            int hasCount = new HotSellRankAgent().GetGoodsCount();  //存在记录数
            int mustDelCount = arrIds.Length + hasCount - 20;              //必须删除记录数
            int selDelCount = Request.Form["ids"].ToString().Split(",".ToCharArray()).Length;  //选中删除记录数
            if (selDelCount < mustDelCount)
            {
                WebAgent.AlertAndBack("你选中删除的数目" + selDelCount.ToString() + "条，必须删除" + mustDelCount.ToString() + "条！");
            }
            using (HotSellRankAgent hsr = new HotSellRankAgent())
            {
                hsr.DeleteGoods(Request.Form["ids"]);
                this.AddLog(EventID.Delete, "批量删除畅销产品", "批量删除产品，编号:" + Request.Form["ids"]);
                for (int i = 0; i < arrIds.Length; i++)
                    hsr.AddGoods(int.Parse(arrIds[i]));
                this.AddLog(EventID.Insert, "添加畅销产品", "批量添加产品，编号:" + txbAddIds.Text.ToString());
                WebAgent.SuccAndGo("删除畅销产品[" + Request.Form["ids"] + "]，并添加畅销产品[" + txbAddIds.Text.ToString() + "]成功。", "HotSellRankList.aspx");
            }
        }
        else
        {
            WebAgent.FailAndGo("请在要删除的项前打勾。", "HotSellRankList.aspx");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("GoodsList.aspx");
    }

}
