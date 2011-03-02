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

using AnyWell.AW_DL;

public partial class Admin_CommentList : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        compGoodsName.Text = QS("gname");
        compUserName.Text = QS("uname");
        compIp.Text = QS("ip");
        compReply.Text = QS("reply");

        using (AW_Goods_Comment_dao dao = new AW_Goods_Comment_dao())
        {
            compRep.DataSource = dao.funcCommentSearch(
                compGoodsName.Text.Trim()
                , compUserName.Text.Trim()
                , compIp.Text.Trim()
                , compReply.SelectedValue
                , PN1.PageSize
                , PN1.PageIndex
                );
            compRep.DataBind();
            PN1.SetPage(dao.propCount);
        }

    }

}
