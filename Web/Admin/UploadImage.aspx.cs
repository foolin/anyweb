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
using System.IO;

public partial class UploadImage : AdminBase
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        
    }

    protected override void OnPreRender(EventArgs e)
    {
        if (Request.Files.Count == 0 || Request.Files[0].ContentLength == 0)
        {
            Failed("请选择一个文件");
            return;
        }

        try
        {
            UploadFile();
        }
        catch (Exception ex)
        {
            Failed(String.Format("{1}：\n{0}", ex.Message, "上传文件失败"));
        }
    }

    private void UploadFile()
    {
        string url = "";
        HttpPostedFile file1 = Request.Files[0];
        int maxsize = 104857600; //100M
        if (file1.ContentLength > maxsize)
        {
            Failed("文件大小不能超过100M");
            return;
        }

        string imgPath = Server.MapPath("\\SiteData\\images");
        if (!Directory.Exists(imgPath))
        {
            Directory.CreateDirectory(imgPath);
        }

        if (!MatchType(file1))
        {
            Failed("文件格式只能是" + Request.QueryString["type"]);
            return;
        }

        string fileName = imgPath + "\\" + Studio.Web.WebAgent.NewKey() + file1.FileName.Substring(file1.FileName.LastIndexOf('.'));

        file1.SaveAs(fileName);

        file1.InputStream.Close();

        url = "/SiteData/images/" + fileName.Substring(fileName.LastIndexOf('\\') + 1);
        Response.Write("<script language='javascript'>if(parent)parent.uploadOk('" + url.Replace(@"\", "/") + "');</script>");
    }

    bool MatchType(HttpPostedFile file)
    {
        bool matchType = false;
        if (Request.QueryString["type"] == null)
        {
            return matchType;
        }

        string[] types = Request.QueryString["type"].Split(',');

        foreach (string type in types)
        {
            if (file.FileName.ToLower().EndsWith(type))
            {
                matchType = true;
                break;
            }
        }

        return matchType;
    }

    void Failed(string msg)
    {
        Response.Write(String.Format("<script language='javascript'>alert('{0}');</script>", msg));
        Response.Write("<script language='javascript'>parent.close();</script>");
    }
}
