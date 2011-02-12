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
using Studio.Web;
using System.IO;

public partial class Admin_RecruitList : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        txtKey.Text = QS( "key" );
        int recordCount = 0;
        compRep.DataSource = new AW_Recruit_dao().funcGetRecruitList( txtKey.Text, PN1.PageSize, PN1.PageIndex, out recordCount );
        compRep.DataBind();
        PN1.SetPage(recordCount);
    }

}
