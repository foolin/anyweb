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

public partial class Admin_FileFolderAdd : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        string path = QS("path");
        litPath.Text += path.Length > 0 ? path.Replace("/", "\\") : "\\";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "")
            WebAgent.AlertAndBack("请输入目录名");

        string validKeys = "\\/:*?\"<>|";
        for (int i = 0; i < validKeys.Length; i++)
        {
            if (txtName.Text.Contains(validKeys.Substring(i, 1)))
                WebAgent.AlertAndBack("目录名还有非法字符");
        }

        string path = QS("path") + "/" + txtName.Text;
        path = path.Replace("\\", "/").Replace("//", "/");

        if (path.Contains("../"))
            WebAgent.AlertAndBack("目录名还有非法字符");


        DirectoryInfo di = new DirectoryInfo(Server.MapPath(path));
        if (di.Exists)
            WebAgent.AlertAndBack("目录名已经存在");

        di.Create();
        WebAgent.SuccAndGo("添加目录成功", "FileList.aspx?path=" + QS("path"));

    }
}
