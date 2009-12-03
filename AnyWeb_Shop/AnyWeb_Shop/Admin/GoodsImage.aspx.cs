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
using Studio.Web;
using Common.Agent;
using Common.Common;

public partial class GoodsImage : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
        boxAll.Checked = false;
    }
    protected void btnSave_Click(object sender , EventArgs e)
    {
        UploadImg();
    }

    protected void UploadImg()
    { 
        int maxSize = 1024 * 1024 * 2;
        int maxW = 120 , maxH = 120 , count = 0;
        string photo="";
        for ( int i = 1 ; i <= 5 ; i++ )
        {
            FileUpload fileControl = (FileUpload)Master.FindControl( "cph1" ).FindControl( "File" + i.ToString() );
            TextBox fileName = (TextBox)Master.FindControl( "cph1" ).FindControl( "txtName" + i.ToString() );

            if ( fileControl != null )
            {
                HttpPostedFile file = fileControl.PostedFile;

                string name = file.FileName;

                if ( file != null && file.ContentLength > 0 )
                {
                    if ( file.ContentLength > maxSize )
                    {
                        WebAgent.Alert("图片[" + name + "]太大，当前允许2M");
                        continue;
                    }

                    string folder = Server.MapPath( ShopInfo.DataPath + "/Goods" );

                    if ( !Directory.Exists( folder ) )
                    {
                        Directory.CreateDirectory( folder );
                    }

                    string newkey = WebAgent.NewKey();
                    string photos = folder + "\\S_" + newkey + file.FileName.Substring( file.FileName.LastIndexOf( '.' ) );
                    photo = "/ShopData/" + ShopInfo.ID + "/Goods/S_" + newkey + file.FileName.Substring( file.FileName.LastIndexOf( '.' ) );

                    if ( WebAgent.IsInt32( QS( "goodsid" ) ) )
                    {
                        GoodsImages gi = new GoodsImages();
                        gi.ImageName = fileName.Text;
                        gi.ImageUrl = photo;
                        gi.GoodsID = int.Parse( QS( "goodsid" ) );

                        count = new GoodsAgent().AddGoodsImage( gi );
                    }
                    WebAgent.SaveFile( file , photos , maxW , maxH , true );

                }
            }   
        }
        if ( count > 0 )
        {
            this.AddLog( EventID.Insert , "添加商品相关图片" , "成功添加了商品编号为" + QS( "goodsid" ) + "的相关图片" );
            
            WebAgent.SuccAndGo( "上传成功" , Request.RawUrl );
        }
    }

    protected void ods1_Selecting(object sender , ObjectDataSourceSelectingEventArgs e)
    {
        if ( WebAgent.IsInt32( QS( "goodsid" ) ) )
        {
            e.InputParameters["goodsid"] = int.Parse( QS( "goodsid" ) );
        }
    }

    protected void btnDel_Click(object sender , EventArgs e)
    {
        if ( Request.Form["ids"] + "" != "" )
        {
            using ( GoodsAgent ga = new GoodsAgent() )
            {
                if ( ga.GoodsImagesDelete( Request.Form["ids"] , Request.Form["ids"].Split( ',' ).Length ) > 0 )
                {
                    this.AddLog( EventID.Delete , "删除商品相关图片" , "删除了编号为" + QS( "goodsid" ) + "的商品的相关图片" );

                    WebAgent.SuccAndGo( "删除成功。" , Request.RawUrl );
                }
            }
        }
        else
        {
            WebAgent.FailAndGo( "请先选中要删除的项。" , Request.RawUrl );
        }
    }
}
