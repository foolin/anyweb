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
using AnyWeb.AW_DL;

public partial class Admin_FileAdd : ShopAdmin
{

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        string path = QS("path");
        litPath.Text += path.Length > 0 ? path.Replace("/", "\\") : "\\";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (file1.PostedFile.ContentLength > 0)
        {
            string extension = Path.GetExtension(file1.PostedFile.FileName).ToLower();
            string extensions = ".jpg.gif.png.bmp.zip.rar.doc.xls.ppt.pdf.txt";
            if (extensions.Contains(extension) == false)
            {
                WebAgent.AlertAndBack("您的文件系统不允许上传");
            }

            string file = QS("path") + "/" + Path.GetFileName(file1.PostedFile.FileName);
            file = file.Replace("\\", "/").Replace("//", "/");
            FileInfo fi = new FileInfo(Server.MapPath(file));
            if (fi.Exists)
            {
                if (radio1.Checked)
                {
                    file = QS("path") + "/" + Path.GetFileNameWithoutExtension(file1.PostedFile.FileName) + "_" + GetRadiumFileName() + extension;
                    file = file.Replace("\\", "/").Replace("//", "/");
                    file1.PostedFile.SaveAs(Server.MapPath(file));
                    WebAgent.SuccAndGo("上传文件成功", "FileList.aspx?path=" + QS("path"));
                }
                else if (radio2.Checked)
                {
                    File.Delete(file);
                    file1.PostedFile.SaveAs(Server.MapPath(file));
                    WebAgent.SuccAndGo("上传覆盖文件成功", "FileList.aspx?path=" + QS("path"));
                }
                else
                {
                    WebAgent.AlertAndBack("您上传的文件名已经存在");
                }
            }
            else
            {
                file1.PostedFile.SaveAs(Server.MapPath(file));
                WebAgent.SuccAndGo("上传文件成功", "FileList.aspx?path=" + QS("path"));
            }

        }
    }

    protected string GetRadiumFileName()
    {
        return DateTime.Now.ToString("yyyyMMddHHmmss") + (new Random()).Next(10000,99999).ToString();
    }
}
