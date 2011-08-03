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
using Studio.Web;
using AnyWell.Configs;

namespace BLOG.tiny_mce
{
    public partial class uploadimage : System.Web.UI.Page
    {
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
            string url = "";
            string fileName = DL_helper.funcGetTicks().ToString();
            string vPath = Request.ApplicationPath + "Files/Others/";
            string savePath = Server.MapPath( vPath );
            if( !Directory.Exists( savePath ) )
            {
                Directory.CreateDirectory( savePath );
            }
            string path = savePath + fileName + Path.GetExtension(Request.Files[0].FileName);
            string thumbPath = savePath + "s_" + fileName + Path.GetExtension( Request.Files[ 0 ].FileName );
            int thumbWidth = 460, thumbHeight = 716;
            //Request.Files[0].SaveAs(Server.MapPath(path));

            ImageWaterMark wm = new ImageWaterMark();
            switch( GeneralConfigs.GetConfig().ImageWatermarkType )
            {
                case 0:
                    if( GeneralConfigs.GetConfig().ArticleImageWidth > 0 )
                    {
                        WebAgent.MakeThumbnail( path, thumbPath, thumbWidth, thumbHeight, "W", WebAgent.GetImageType( Path.GetExtension( Request.Files[ 0 ].FileName ) ) );
                    }
                    break;
                case 1:
                    wm.SaveWaterMarkImageByText(
                        Request.Files[ 0 ],
                        fileName,
                        savePath,
                        GeneralConfigs.GetConfig().ImageWatermarkText,
                        GeneralConfigs.GetConfig().ImageWatermarkFontFamily,
                        GeneralConfigs.GetConfig().ImageWatermarkFontsize,
                        GeneralConfigs.GetConfig().ImageWatermarkFontColor,
                        GeneralConfigs.GetConfig().ImageWatermarkShadowColor,
                        wm.GetTextCSS( GeneralConfigs.GetConfig().ImageWatermarkFontCss ),
                        GeneralConfigs.GetConfig().ImageWatermarkTransparency,
                        3,
                        -3,
                        GeneralConfigs.GetConfig().ImageWatermarkAngle,
                        wm.GetImageAlign( GeneralConfigs.GetConfig().ImageWatermarkPosition ),
                        0,
                        0,
                        thumbWidth,
                        thumbHeight,
                        true
                        );
                    break;
                case 2:
                    wm.SaveWaterMarkImageByPic(
                        Request.Files[ 0 ],
                        fileName,
                        savePath,
                        Server.MapPath( GeneralConfigs.GetConfig().ImageWatermarkUrl ),
                        GeneralConfigs.GetConfig().ImageWatermarkAngle,
                        wm.GetImageAlign( GeneralConfigs.GetConfig().ImageWatermarkPosition ),
                        0,
                        0,
                        thumbWidth,
                        thumbHeight,
                        true
                        );
                    break;
                default:
                    break;
            }


            //url = String.Format("http://{0}{1}{2}",
            //    Request.Url.Host,
            //    Request.Url.Port == 80 ? "" : (":" + Request.Url.Port.ToString()),
            //    vPath + "s_" + fileName + Path.GetExtension( Request.Files[ 0 ].FileName )
            //    );
            url = vPath + "s_" + fileName + Path.GetExtension( Request.Files[ 0 ].FileName );
            Response.Write("<script language='javascript'>if(parent)parent.ImageDialog.uploadOk('" + url + "');</script>");
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
            //Response.Write("<script language='javascript'>parent.close();</script>");
        }

        string GetPath()
        {
            if (Request.ApplicationPath == "/")
                return "";
            else
                return Request.ApplicationPath;
        }
    }
}