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
using AnyWeb.AnyWeb_DL;

public partial class Admin_Content_PhotoList : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        drpSort.DataSource = new SortAgent().GetSortListByPhoto();
        drpSort.DataBind();
        drpSort.Items.Insert(0, new ListItem("所有类别", "0"));

        if (QS("s") != "")
            drpSort.SelectedValue = QS("s");
        if (QS("n") != "")
            txtName.Text = QS("n");

        int RecordCount = 0;
        repPhoto.DataSource = new PhotoAgent().GetPhotoList(int.Parse(drpSort.SelectedValue), txtName.Text, PN1.PageSize, PN1.PageIndex, out RecordCount);
        repPhoto.DataBind();
        PN1.SetPage(RecordCount);
    }
}
