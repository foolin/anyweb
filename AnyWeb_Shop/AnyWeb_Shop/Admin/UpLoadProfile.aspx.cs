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
using Admin.Framework;
using System.IO;

public partial class UpLoadProfile :AdminBase
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (Request.Files.Count == 0 || Request.Files[0].ContentLength == 0)
        {
            Failed("没有上传附件");
            return;
        }

        try
        {
            UploadFile();
        }
        catch (Exception ex)
        {
            Failed(String.Format("{1}：\n{0}", ex.Message, "上传文件失败,请将以下信息报告给商脉通系统管理员"));
        }
    }

    private void UploadFile()
    {
        string url = "";
        HttpPostedFile file1 = Request.Files[0];
        int maxsize = 2097152; //2M
        if (file1.ContentLength > maxsize)
        {
            Failed("您上传的文件太大");
            return;
        }

        string filename = Path.GetFileName(file1.FileName);
        string imgPath = Server.MapPath(ShopInfo.DataPath + "\\profile");
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

        url = this.ShopInfo.Url + ShopInfo.DataPath.Substring(1) + "/profile/" + fileName.Substring(fileName.LastIndexOf('\\') + 1);
        Response.Write("<script language='javascript'>if(parent)parent.uploadOk('" + url + "');</script>");
    }


    bool MatchType(HttpPostedFile file)
    {
        return true;
        bool matchType = false;
        if (Request.QueryString["type"] == null)
        {
            return matchType;
        }
        else
        {
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
    }

    void Failed(string msg)
    {
        Response.Write(String.Format("<script language='javascript'>alert('{0}');</script>", msg));
        Response.Write("<script language='javascript'>parent.close();</script>");
    }
}