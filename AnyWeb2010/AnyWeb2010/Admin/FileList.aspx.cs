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

public partial class Admin_FileList : PageAdmin
{
    protected string rootPath
    {
        get { return Server.MapPath("/"); }
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        string path = QS("path").Replace("\\", "/").Replace("//", "/");
        if (path.Contains("..")) Response.Redirect("FileList.aspx?1=1");
        txtPath.Text = "D:";
        txtPath.Text += path == "" ? "\\" : path.Replace("/", "\\");

        if (path.ToLower().StartsWith("/controls") || path.ToLower().StartsWith("/css") || path.ToLower().StartsWith("/shopcart")
            || path.ToLower().StartsWith("/images") || path.ToLower().StartsWith("/js") || path.ToLower().StartsWith("/member")
            || path.ToLower().StartsWith("/files") || path.ToLower().StartsWith("/public") || path.ToLower().StartsWith("/ajax")
            || path == "" || path == "/")
        {
            DirectoryInfo di = new DirectoryInfo(rootPath + path.Replace("/", "\\"));
            if (!di.Exists) Response.Redirect("FileList.aspx?1=1");

            if (PN1.PageIndex == 1)
            {
                repFolders.DataSource = di.GetDirectories();
                repFolders.DataBind();
            }

            repFiles.DataSource = PN1.GetCurrentPage(di.GetFiles());
            repFiles.DataBind();
        }
        else
        {
            WebAgent.FailAndGo("该目录不允许查看","filelist.aspx");
        }

    }

    /// <summary>
    /// 获取文件大小
    /// </summary>
    /// <param name="len"></param>
    /// <returns></returns>
    protected string GetFileLength(long len)
    {
        string temp = "";
        if (len / 1024 / 1024 > 0)
            temp = ((float)len / (float)1024 / (float)1024).ToString("0.0 MB");
        else if (len / 1024 > 0)
            temp = ((float)len / (float)1024).ToString("0.0 KB");
        else
            temp = ((float)len / (float)1024).ToString("0.0 B");
        return temp;
    }

    /// <summary>
    /// 获取目录的相对目录
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    protected string GetFolderRelativePath(string path)
    {
        if (rootPath.Length >= path.Length)
            return "/";
        else
            return "/" + path.Substring(rootPath.Length).Replace("\\", "/");
    }

    /// <summary>
    /// 获取文件的相对访问路径
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    protected string GetFileRelativePath(string path)
    {
        if (rootPath.Length >= path.Length)
            return "/";
        else
            return "/" + path.Substring(rootPath.Length).Replace("\\", "/");
    }

    /// <summary>
    /// 获取上一级目录的访问路径
    /// </summary>
    /// <returns></returns>
    protected string GetUpperFolderPath()
    {
        string path = QS("path");
        if (path.Length <= 1)
            return "";

        DirectoryInfo di = new DirectoryInfo(rootPath + path.Replace("/", "\\"));
        if (di.Exists)
        {
            return GetFolderRelativePath(di.Parent.FullName);
        }
        else
        {
            return "";
        }
    }
}
