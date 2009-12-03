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
using Common.Common;
using System.IO;
using Studio.Web;
using Studio.Security;
using Common.Agent;

public partial class BasicInfoManage : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ods3_Updating(object sender , ObjectDataSourceMethodEventArgs e)
    {
        Shop s = (Shop)e.InputParameters[0];

        HiddenField hidLogo = (HiddenField)this.fv1.FindControl( "hidLogo" );
      
        FileUpload logo = (FileUpload)this.fv1.FindControl( "fileLog" );

        int maxSize = 1024 * 1024 * 2;
        int maxW = 120 , maxH = 120;

        if ( logo.HasFile )
        {
            string photo = "";

            HttpPostedFile file = logo.PostedFile;
            if ( file.FileName.ToString().Substring( file.FileName.ToString().IndexOf( '.' ) , 4 ).ToLower().Equals( ".bmp" ) )
            {
                WebAgent.FailAndGo( "当前不支持bmp格式图片." );
            }

            string folder = Server.MapPath( ShopInfo.DataPath );
            if ( !Directory.Exists( folder ) )
            {
                Directory.CreateDirectory( folder );
            }
            string photourl = folder + "\\Logo" + file.FileName.Substring( file.FileName.LastIndexOf( '.' ) );

            photo = "/Logo" + file.FileName.Substring( file.FileName.LastIndexOf( '.' ) );

            if ( file.ContentLength > maxSize )
            {
                WebAgent.FailAndGo( "图片太大，当前允许2M." );
            }

            file.SaveAs( photourl );

            s.Logo = photo;
        }
        else
        {
            s.Logo = hidLogo.Value;
        }
    }
    protected void ods3_Updated(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {

            this.AddLog( EventID.Update , "修改商店基本资料" , "修改商店基本资料" );

            WebAgent.SuccAndGo( "修改成功。" , Request.RawUrl);
        }
        else
        {
            WebAgent.FailAndGo( "修改失败。" , Request.RawUrl);
        }
    }

    protected void btnDelImg_Click(object sender , EventArgs e)
    {
        //logo存放目录
        HiddenField hidLogo = (HiddenField)fv1.FindControl( "hidLogo" );
        if ( hidLogo != null )
        {
            string img = hidLogo.Value;
            if ( img != "" )
            {
               
               File.Delete( HttpContext.Current.Server.MapPath( ShopInfo.DataPath + img ) );
               
            }
        }
        using ( ShopAgent ua = new ShopAgent() )
        {
            if ( ua.DelShopLog() > 0 )
            {
                WebAgent.SuccAndGo( "删除成功" , "BasicInfoManage.aspx" );
            }
        }
    }
}
