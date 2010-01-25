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

using AnyWeb.AW_DL;

public partial class Ajax_CommentEdit : ShopAjaxBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AW_Member_bean member = new AW_Member_dao().funcGetMemberFromCookie();
        if (member == null)
            ExecuteFalse(1, "请先登陆！");

        int commentId = 0;
        int.TryParse(QF("id"), out commentId);
        AW_Goods_Comment_bean comment = new AW_Goods_Comment_dao().funcGetMemberComment(commentId, member.fdMembID);
        if (comment == null)
            ExecuteFalse(2, "评论不存在！");

        int score = 0;
        bool enableRecalculate = false;
        if (int.TryParse(QF("score"), out score))
        {
            enableRecalculate = comment.fdCommScore != score;
            comment.fdCommScore = score;
        }

        comment.fdCommUserName = member.fdMembName;
        comment.fdCommContent =HttpUtility.UrlDecode( QF("content"));
        comment.fdCommIP = Request.UserHostAddress;
        comment.fdCommCreateAt = DateTime.Now;

        int record = new AW_Goods_Comment_dao().funcUpdate(comment);
        if (record > 0)
        {
            if (enableRecalculate) new AW_Goods_dao().funcScore(comment.fdCommGoodsID);//重新计算商品平均分
            ExecuteSucc("修改评论成功！");
        }
        else
            ExecuteFalse(3, "修改评论失败！");
    }
}
