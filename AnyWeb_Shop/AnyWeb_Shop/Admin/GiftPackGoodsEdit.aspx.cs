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

public partial class Admin_GiftPackGoodsEdit : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (QS("pid") + "" == "")
        {
            WebAgent.AlertAndBack("非法大礼包ID！");
        }
        GiftPackage gp = new GiftPackageAgent().GetGiftPackageByID(int.Parse(QS("pid")));
        if (gp == null)
        {
            WebAgent.AlertAndBack("不存在该大礼包");
        }
        hlkGiftPackage.Text = gp.PackName;
        hlkGiftPackage.NavigateUrl = "GiftPackageEdit.aspx?mode=select&packID="+QS("pid");
        btnDel.Attributes["onclick"] = "javascript:return confirm('确定删除，是否继续？');";
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
        if (QS("pid") + "" == "" || !WebAgent.IsInt32(QS("pid")))
        {
            WebAgent.AlertAndBack("大礼包ID参数错误");
        }
        if (Request.Form["ids"] + "" == "")
        {
            WebAgent.AlertAndBack("请选择需要删除项");
        }
        string delGoodsIds = Request.Form["ids"].ToString(); //删除Ids
        string goodsIds = "";
        string[] arrDelGoodsIds;
        string[] arrGoodsIds;

        GiftPackageAgent gpAgent = new GiftPackageAgent();
        GiftPackage gp = gpAgent.GetGiftPackageByID(int.Parse(QS("pid")));
        if (gp == null)
        {
            WebAgent.AlertAndBack("大礼包ID参数错误，不存在该大礼包");
        }
        arrDelGoodsIds = delGoodsIds.Split(",".ToCharArray());
        arrGoodsIds = gp.GoodsIds.Split(",".ToCharArray());
        for (int i = 0; i < arrDelGoodsIds.Length; i++)
        {
            for (int j = 0; j < arrGoodsIds.Length; j++)
            {
                if (arrGoodsIds[j] == arrDelGoodsIds[i])
                {
                    arrGoodsIds[j] = "-1";
                }
            }
        }
        for (int i = 0; i < arrGoodsIds.Length; i++)
        {
            if (arrGoodsIds[i] != "-1")
            {
                goodsIds += arrGoodsIds[i].ToString() + ",";
            }
        }
        if (goodsIds+"" !="" && goodsIds.Substring(goodsIds.Length - 1, 1) == ",")
        {
            goodsIds = goodsIds.Substring(0, goodsIds.Length - 1);
        }
        //商品
        gp.GoodsIds = goodsIds;
        if (gpAgent.UpdateGiftPackage(gp) > 0)
        {
            this.AddLog(EventID.Insert, "更新大礼包产品", "批量更新大礼包产品，编号:" + goodsIds);
            WebAgent.SuccAndGo("删除大礼包产品成功。", "GiftPackGoodsEdit.aspx?pid="+ QS("pid"));
        }
        else
        {
            WebAgent.FailAndGo("批量删除大礼包产品失败！");
        }
    }
}
