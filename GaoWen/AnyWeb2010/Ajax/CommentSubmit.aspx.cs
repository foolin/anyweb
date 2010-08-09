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
using Studio.Web;

/// <summary>
/// 提交评论，如果未登录，则登录
/// </summary>
public partial class Ajax_CommentSubmit : ShopAjaxBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.Form.Count == 0)
                ExecuteFalse(1, "程序错误！");

        string email = HttpUtility.UrlDecode(QF("email"));
        string pwd = QF("pwd");
        string score = QF("score");
        string content = HttpUtility.UrlDecode(QF("content"));
        string goodId = QF("id");
        string urlref = HttpUtility.UrlDecode(QF("urlref"));


        AW_Member_bean member = (new AW_Member_dao()).funcGetMemberFromCookie();
        if (member == null)
        {
            if (email == "" || pwd == "")
            {
                ExecuteFalse(2, "邮件帐号或密码不能为空");
            }
            member = new AW_Member_dao().funcLogin(1, email, pwd);
            if (member == null)
            {
                ExecuteFalse(3, "邮件帐号或密码错误");
            }
            else if (member.fdMembStatus != 1)
            {
                ExecuteFalse(4, "帐号被锁定请联系管理员");
            }
        }

        if ((new AW_Goods_Comment_dao()).funcCheckMemberHasCommentToday(int.Parse(goodId), member.fdMembID) == true)
            ExecuteFalse(5, "您已提交过评论,请勿重复提交");

        AW_Goods_Comment_bean bean = new AW_Goods_Comment_bean();
        bean.fdCommContent = content;
        bean.fdCommCreateAt = DateTime.Now;
        bean.fdCommGoodsID = int.Parse(goodId);
        bean.fdCommScore = int.Parse(score);
        bean.fdCommIP = Request.UserHostAddress;
        bean.fdCommMemberID = member.fdMembID;
        bean.fdCommUserName = member.fdMembName;
        bean.fdCommUrlRef = urlref;
        bean.fdCommArea = "";
        using (AW_Goods_Comment_dao dao = new AW_Goods_Comment_dao())
        {
            bean.fdCommID = dao.funcNewID();
            dao.funcInsert(bean);
        }

        //商品评论数+1
        new AW_Goods_dao().funcAddCommentCount(bean.fdCommGoodsID);

        //更新商品评分
        (new AW_Goods_dao()).funcScore(bean.fdCommGoodsID, bean.fdCommScore);

        ExecuteSucc("提交评论成功");
    }
}
