using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Studio.Web;

namespace AnyWeb.tiny_mce
{

    public partial class UploadProfile : AdminBase
    {
        string path = "";
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Request.Files.Count == 0 || Request.Files[0].ContentLength == 0)
            {
                Failed("请选择文件");
                return;
            }

            try
            {
                UploadFile();
            }
            catch (Exception ex)
            {
                Failed(String.Format("{1}：\n{0}", ex.Message, "上传文件错误"));
            }
        }




        private void UploadFile()
        {
            HttpPostedFile file1 = Request.Files[0];
            path = "/SiteData/profile";
            if (!Directory.Exists(Server.MapPath(path))) Directory.CreateDirectory(Server.MapPath(path));
            path += "/" + WebAgent.NewKey() + Path.GetExtension(file1.FileName);
            file1.SaveAs(Server.MapPath(path));
            Response.Write("<script language='javascript'>if(parent)parent.uploadOk('" + path + "');</script>");
        }

        private string GetPath()
        {
            throw new NotImplementedException();
        }


        bool MatchType(HttpPostedFile file)
        {
            return true;
        }

        void Failed(string msg)
        {
            Response.Write(String.Format("<script language='javascript'>alert('{0}');</script>", msg));
            Response.Write("<script language='javascript'>parent.close();</script>");
        }
    }
}