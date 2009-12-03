using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Common.Agent;
using Common.Common;
using Admin.Framework;
using Studio.Web;

public partial class User_Agreement:AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        Agreement a = (new AgreementAgent()).GetAgreement();

        if (a != null)
            this.txtAgreement.Text = a.Content; 
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if ((new AgreementAgent()).UpdateAgreement(this.txtAgreement.Text) > 0)
        {
            WebAgent.SuccAndGo("设置成功",Request.Url.ToString());
        }
    }
}
