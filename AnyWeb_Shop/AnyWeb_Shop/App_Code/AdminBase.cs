using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Common.Common;
using Common.Agent;
using System.IO;
using Studio.Web;
/// <summary>
/// 基类,其中包含一些全局的方法

/// </summary>
namespace Admin.Framework
{
    public class AdminBase : Page
    {
        
        public AdminBase()
        {
            this.Load += new EventHandler(AdminBase_Load);

        }

        /// <summary>
        /// 获取返回路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AdminBase_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.UrlReferrer == null)
                {
                    ViewState["BACK"] = "/Admin/Default.aspx";
                }
                else
                {
                    ViewState["BACK"] = Request.UrlReferrer.ToString();
                }
            }
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected string QS(string key)
        {
            if (Request.QueryString[key] == null)
            {
                return "";
            }
            else
            {
                return Request.QueryString[key].ToString();
            }
        }

        /// <summary>
        /// 获取商店信息
        /// </summary>
        public Common.Common.Shop ShopInfo
        {
            get
            {
               return (Common.Common.Shop)Context.Items["SHOP_INFO"];
            }
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="eventtype">类型</param>
        /// <param name="eventname">名称</param>
        /// <param name="description">描述</param>
        protected void AddLog(EventID eventtype, string eventname, string description)
        {
            EventLog el = new EventLog();

            el.ShopID = ShopInfo.ID;
            el.FromIP = System.Web.HttpContext.Current.Request.UserHostAddress;
            el.EventName = eventname;
            el.EventType = eventtype;
            el.Description = description;

            (new EventLogAgent()).AddLog(el);
        }

        protected override void OnInit(EventArgs e)
        {
            if (this.RequireSignIn == true && Request.Cookies["USERACC"] == null)
            {
                WebAgent.FailAndGo("未登陆,禁止查看该页面!","/Admin/login.aspx?back="+this.Request.RawUrl);
            }

          

            if ( Request.Cookies["USERACC"] != null && Request.Cookies["SHOPID"] != null )
            {
                if ( this.ShopInfo.AdminAcc != Request.Cookies["USERACC"].Value && Request.Cookies["USERACC"].Value.ToLower() != "superadmin" )
                {
                    WebAgent.FailAndGo("admin.anyp.com/login.aspx", "您不是管理员,无权操作商城,请用管理员帐号登陆");
                }
                this.AddLog( EventID.Login , "由商城后台进入" , "由商城后台进入" );
            }

          
            
            base.OnInit(e);
        }

        public virtual bool RequireSignIn
        {
            get { return true; }
        }

        /// <summary>
        /// 上传商品图片
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public string GetProductImg( FileUpload img )
        {
            string photo = "";
            if ( img.HasFile )
            {
                int maxSize = 1024 * 1024 * 2;
                int maxW = 120 , maxH = 120;

                HttpPostedFile file = img.PostedFile;
                if ( file.FileName.ToString().Substring( file.FileName.ToString().IndexOf( '.' ) , 4 ).ToLower().Equals( ".bmp" ) )
                {
                    WebAgent.FailAndGo( "当前不支持bmp格式图片." );
                }
                string folder = Server.MapPath( ShopInfo.DataPath + "/Goods" );

                if ( !Directory.Exists( folder ) )
                {
                    Directory.CreateDirectory( folder );
                }

                string newkey = WebAgent.NewKey();
                string photos = folder + "\\S_" + newkey + file.FileName.Substring( file.FileName.LastIndexOf( '.' ) );
                photo = "/ShopData/" + ShopInfo.ID + "/Goods/S_" + newkey + file.FileName.Substring( file.FileName.LastIndexOf( '.' ) );
                if ( file.ContentLength > maxSize )
                {
                    WebAgent.FailAndGo( "图片太大，当前允许2M." );
                }

                WebAgent.SaveFile( file , photos , maxW , maxH , true );
            }
            return photo;
        }

        /// <summary>
        /// 获得链接图片
        /// </summary>
        /// <returns></returns>
        public string GetLinkImg(FileUpload img)
        {
            string photo = "";

            int maxSize = 1024 * 1024 * 2;
            if ( img.HasFile )
            {
                HttpPostedFile file = img.PostedFile;

                if ( file.FileName.ToString().Substring( file.FileName.ToString().IndexOf( '.' ) , 4 ).ToLower().Equals( ".bmp" ) )
                {
                    WebAgent.FailAndGo( "当前不支持bmp格式图片." );
                }

                string folder = Server.MapPath( ShopInfo.DataPath + "/Link/" );

                if ( !Directory.Exists( folder ) )
                {
                    Directory.CreateDirectory( folder );
                }
                if ( file.ContentLength > maxSize )
                {
                    WebAgent.FailAndGo( "图片太大，当前允许2M." );
                }
                string newkey = WebAgent.NewKey();

                string photos = folder + newkey + file.FileName.Substring( file.FileName.LastIndexOf( '.' ) );

                photo = ShopInfo.DataPath + "/Link/" + newkey + file.FileName.Substring( file.FileName.LastIndexOf( '.' ) );

                file.SaveAs( photos );

            }

            return photo;
        }
    }
}
