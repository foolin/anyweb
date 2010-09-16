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
using System.IO;
using Studio.Web;
using AnyWell.AW_DL;
using Studio.IO;
using System.Text;

public partial class Admin_FileEdit : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        litPath.Text = (QS("path") + "/" + QS("link")).Replace("//","/");
        string extensions = ".txt.aspx.htm.html.ascx";

        FileInfo fi = new FileInfo(Server.MapPath(litPath.Text));
        if (!fi.Exists)
        {
            WebAgent.AlertAndBack("文件不存在");
        }
        else if (!extensions.Contains(fi.Extension.ToLower()))
        {
            WebAgent.AlertAndBack("文件类型不允许修改");
        }
        else
        {
            txtContent.Text = FileAgent.ReadText(fi.FullName, Encoding.Default);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FileAgent.WriteText(Server.MapPath(litPath.Text), txtContent.Text, false);
        WebAgent.SuccAndGo("保存成功", "filelist.aspx?path=" + QS("path"));
    }
}
