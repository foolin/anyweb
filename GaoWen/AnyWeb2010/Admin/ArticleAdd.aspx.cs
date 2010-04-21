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
using AnyWeb.AW_DL;



public partial class Admin_ArticleAdd : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        foreach (AW_Column_bean bean1 in (new AW_Column_dao()).funcGetColumns())
        {
            drpColumn.Items.Add(new ListItem(bean1.fdColuName, bean1.fdColuID.ToString()));
            foreach (AW_Column_bean bean2 in bean1.Children)
            {
                drpColumn.Items.Add(new ListItem(bean1.fdColuName + "-" + bean2.fdColuName, bean2.fdColuID.ToString()));
            }
        }

        ListItem li = drpColumn.Items.FindByValue(QS("cid"));
        if (li != null) li.Selected = true;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtTitle.Text))
            WebAgent.AlertAndBack("标题不能为空");

        if (String.IsNullOrEmpty(txtContent.Text))
            WebAgent.AlertAndBack("内容不能为空");

        if (string.IsNullOrEmpty(txtSort.Text))
            WebAgent.AlertAndBack("排序不能为空");

        if (!WebAgent.IsInt32(txtSort.Text.Trim()))
            WebAgent.AlertAndBack("排序格式不正确");

        using (AW_Article_dao dao = new AW_Article_dao())
        {

            AW_Article_bean bean = new AW_Article_bean();
            bean.fdArtiID = dao.funcNewID();
            bean.fdArtiColumnID = int.Parse(drpColumn.SelectedValue);
            bean.fdArtiTitle = txtTitle.Text.Trim();
            bean.fdArtiContent = txtContent.Text;
            bean.fdArtiSort = int.Parse(txtSort.Text.Trim());
            if (bean.fdArtiSort == 0)
                bean.fdArtiSort = bean.fdArtiID * 100;
            
            int record = dao.funcInsert(bean);
            if (record > 0)
            {
                Studio.Web.WebAgent.SuccAndGo("添加成功", "ArticleList.aspx?cid=" + bean.fdArtiColumnID.ToString());
            }
        }
    }
}
