using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Plugins_Subscribe_Subscribe : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int sid = 0;
            foreach (AW_Site_bean site in new AW_Site_dao().funcGetSites())
            {
                drpSite.Items.Add(new ListItem(site.fdSiteName, site.fdSiteID.ToString()));
            }
            int.TryParse(QS("sid"), out sid);
            if (sid != 0)
            {
                drpSite.SelectedValue = sid.ToString();
            }
        }
        else
        {
            AW_Subscribe_bean bean = new AW_Subscribe_bean();
            AW_Subscribe_dao dao = new AW_Subscribe_dao();
            bean.fdSubsID = dao.funcNewID();
            bean.fdSubsSiteID = int.Parse(drpSite.SelectedValue);
            bean.fdSubsCompany = txtCompany.Text.Trim();
            bean.fdSubsSurname = txtSurname.Text.Trim();
            bean.fdSubsName = txtName.Text.Trim();
            bean.fdSubsEmail = txtEmail.Text.Trim().ToLower();
            bean.fdSubsSort = bean.fdSubsID * 10;
            if (dao.funcInsert(bean) > 0)
            {
                AddLog(EventType.Insert, "添加订阅", string.Format("添加订阅:{0}({1})", bean.fdSubsCompany, bean.fdSubsID));
                Response.Write(string.Format("<script type=text/javascript>parent.addSubscribeOK({0});</script>", bean.fdSubsSiteID));
                Response.End();
            }
        }
    }
}
