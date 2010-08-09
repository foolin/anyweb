using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using AnyWeb.AW_DL;
using Studio.Web;


/// <summary>
/// 获取商品评论/得分列表
/// </summary>
public partial class Ajax_CommentList : ShopAjaxBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int pageSize = 10;
        int pageIndex = 1;
        int recordCount = 0;
        int goodsID = 0;

        if (QS("id") != "" && WebAgent.IsInt32(QS("id")))
            goodsID = int.Parse(QS("id"));
        if(QS("pagesize") != "" && WebAgent.IsInt32(QS("pagesize")))
            pageSize = int.Parse(QS("pagesize"));
        if(QS("page") != "" && WebAgent.IsInt32(QS("page")))
            pageIndex = int.Parse(QS("page"));

        if (goodsID == 0)
            return;

        List<AW_Goods_Comment_bean> list = null;
        using (AW_Goods_Comment_dao dao = new AW_Goods_Comment_dao())
        {
            list = dao.funcGetCommentList(goodsID, pageSize, pageIndex);
            recordCount = dao.propCount;
        }

        Response.Clear();
        Response.Write("comment_records = " + recordCount.ToString() + ";");
        Response.Write("comment_data = new Array("+list.Count.ToString()+");");
        for (int i = 0; i < list.Count;i++ )
        {
            Response.Write("comment_data[" + i.ToString() + "] = " + list[i].funcToJosn() + ";");
        }
        Response.End();
    }
}
