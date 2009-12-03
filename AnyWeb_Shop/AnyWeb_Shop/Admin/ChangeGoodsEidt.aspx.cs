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
using Studio.Web;
using Common.Common;
using System.IO;
using Common.Agent;

public partial class ChangeGoodsEidt : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
     {
        if ( !IsPostBack )
        {
            switch ( QS( "mode" ) )
            {
                case "update":
                    this.fv1.ChangeMode( FormViewMode.Edit );
                    litTitle.Text = "编辑积分礼品";
                    break;
                case "delete":
                    if ( WebAgent.IsInt32( QS( "cid" ) ) )
                    {
                        using ( ChangeGoodsAgent ca = new ChangeGoodsAgent() )
                        {
                            ChangeGoods cg = new ChangeGoods();
                            cg.ID = int.Parse( QS( "cid" ) );
                            if ( ca.DeleteChangeGoods( cg ) > 0 )
                            {
                                Response.Redirect("ChangeGoodsList.aspx" );
                            }
                        }
                    }
                    break;
                default:
                    this.fv1.ChangeMode( FormViewMode.Insert );
                    litTitle.Text = "添加积分礼品";
                    break;
            }
        }
    }
    protected void ods3_Selecting(object sender , ObjectDataSourceSelectingEventArgs e)
    {
        if(WebAgent.IsInt32(QS("cid")))
        {
            e.InputParameters["cid"] = int.Parse(QS( "cid" ));
        }
    }

    protected void ods3_Inserting(object sender , ObjectDataSourceMethodEventArgs e)
    {
        FileUpload img = (FileUpload)fv1.FindControl( "txtImage" );

        TextBox txtEndTime = (TextBox)fv1.FindControl( "txtEndTime" );
     
        ChangeGoods gs = (ChangeGoods)e.InputParameters[0];

        gs.EndTime = txtEndTime.Text == "" ? DateTime.Now.AddYears( 1 ):DateTime.Parse(txtEndTime.Text) ;

         if ( img != null )
        {
            gs.Image = this.GetProductImg(img);
        }
    }

    protected void ods3_Inserted(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( EventID.Insert , "添加积分礼品" , "添加积分礼品");

            WebAgent.SuccAndGo( "添加成功。" , "ChangeGoodsList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "添加失败,请重试。" , "ChangeGoodsList.aspx" );
        }
    }

    protected void ods3_Updating(object sender , ObjectDataSourceMethodEventArgs e)
    {

        ChangeGoods gs = (ChangeGoods)e.InputParameters[0];

        FileUpload img = (FileUpload)fv1.FindControl( "txtImage" );

        if ( img != null )
        {
            string imgurl = this.GetProductImg( img );

            if ( imgurl != "" )
            {
                gs.Image = imgurl;
            }
        }

    }

    protected void ods3_Updated(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( EventID.Update , "修改积分礼品" , "修改积分礼品，礼品编号：" + QS( "cid" ) );

            WebAgent.SuccAndGo( "修改成功。" , "ChangeGoodsList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "添加失败,请重试。" , "ChangeGoodsList.aspx" );
        }
    }

    /// <summary>
    /// 图片处理
    /// </summary>
    /// <param name="img"></param>
    /// <returns></returns>
    //public string GetProductImg()
    //{
    //    string photo = "";

    //    FileUpload img = (FileUpload)fv1.FindControl( "txtImage" );

    //    if ( img.HasFile )
    //    {
    //        int maxSize = 1024 * 1024 * 2;
    //        int maxW = 120 , maxH = 120;

    //        HttpPostedFile file = img.PostedFile;
    //        string folder = Server.MapPath( ShopInfo.DataPath + "/Goods" );

    //        if ( !Directory.Exists( folder ) )
    //        {
    //            Directory.CreateDirectory( folder );
    //        }

    //        string newkey = WebAgent.NewKey();
    //        string photos = folder + "\\S_" + newkey + file.FileName.Substring( file.FileName.LastIndexOf( '.' ) );
    //        photo = "/ShopData/" + ShopInfo.ID + "/Goods/S_" + newkey + file.FileName.Substring( file.FileName.LastIndexOf( '.' ) );
    //        if ( file.ContentLength > maxSize )
    //        {
    //            WebAgent.FailAndGo( "图片太大，当前允许10M." );
    //        }

    //        WebAgent.SaveFile( file , photos , maxW , maxH , true );
    //    }
    //    return photo;
    //}


    protected void ods3_Deleted(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( EventID.Update , "删除积分礼品" , "删除积分礼品，礼品编号：" + QS( "cid" ) );

            WebAgent.SuccAndGo( "修改成功。" , "ChangeGoodsList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "添加失败,请重试。" , "ChangeGoodsList.aspx" );
        }
    }
}
