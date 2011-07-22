using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using AnyWell.AW_DL;

namespace BLOG.tiny_mce
{
    public partial class UpLoadProfile : System.Web.UI.Page
    {
        string path = "";
        protected void Page_Load(object sender, System.EventArgs e)
        {
            
        }

        protected override void OnPreRender(EventArgs e)
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
            string url = "";
            HttpPostedFile file1 = Request.Files[0];
            string vPath = Request.ApplicationPath + "/Files/Others/";
            string savePath = Server.MapPath( vPath );
            if( !Directory.Exists( savePath ) )
            {
                Directory.CreateDirectory( savePath );
            }
            path = savePath + DL_helper.funcGetTicks().ToString() + Path.GetExtension( file1.FileName );

            file1.SaveAs( path );

            url = String.Format("http://{0}{1}{2}",
                Request.Url.Host,
                Request.Url.Port == 80 ? "" : (":" + Request.Url.Port.ToString()),
                path
                );

            Response.Write("<script language='javascript'>if(parent)parent.uploadOk('" + url + "');</script>");
        }

        private string GetPath()
        {
            throw new NotImplementedException();
        }


        bool MatchType(HttpPostedFile file)
        {
            return true;
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
}
