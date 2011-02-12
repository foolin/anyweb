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

using Studio.Web;
using AnyWell.AW_DL;
using System.Collections.Generic;


public partial class Admin_GoodsSort : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        int goodsId = 0;
        int previewId = 0;
        int nextId = 0;

        if (QS("id") != "" && WebAgent.IsInt32(QS("id")))
            goodsId = int.Parse(QS("id"));

        if (QS("previewid") != "" && WebAgent.IsInt32(QS("previewid")))
            previewId = int.Parse(QS("previewid"));

        if (QS("nextid") != "" && WebAgent.IsInt32(QS("nextid")))
            nextId = int.Parse(QS("nextid"));

        if (goodsId > 0 && (previewId > 0 || nextId > 0))
        {
            using (AW_Goods_dao dao = new AW_Goods_dao())
            {
                AW_Goods_bean good = AW_Goods_bean.funcGetByID(goodsId);
                if (good == null)
                {
                    return;
                }
                dao.funcSortGoods(goodsId, nextId, previewId);
                this.AddLog(EventType.Update, "修改商品排序", "修改商品[" + good.fdGoodName + "]排序");
                Response.Write("ok");
            }
        }
        else
        {
            Response.Write("parmaters null");
        }
    }
}
