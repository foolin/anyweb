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
using Common.Agent;
using Common.Common;
using Studio.Web;

public partial class AdvancedSearch : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        repCate.DataSource = new CategoryAgent().GetCategoryList();
        repCate.DataBind();
    }


}
