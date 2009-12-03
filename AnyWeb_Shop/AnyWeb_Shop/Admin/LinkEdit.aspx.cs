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
using Common.Common;
using Common.Agent;

public partial class LinkEdit : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
        if ( !IsPostBack )
        {
            switch ( QS( "mode" ) )
            {
                case "update":
                    this.fv1.ChangeMode( FormViewMode.Edit );
                    litTitle.Text = "编辑链接";
                    break;
                case "delete":
                    if ( WebAgent.IsInt32( QS( "lid" ) ) )
                    {
                        using ( LinkAgent la = new LinkAgent() )
                        {
                            Link l = new Link();
                            l.ID = int.Parse( QS( "lid" ) );
                            if ( la.LinkDelete(l) > 0 )
                            {
                                WebAgent.SuccAndGo( "删除成功" , "LinkList.aspx" );
                            }
                        }
                    }
                    break;
                default:
                    this.fv1.ChangeMode( FormViewMode.Insert );
                    litTitle.Text = "添加链接";
                    break;
            }
        }
    }
    protected void ods3_Inserting(object sender , ObjectDataSourceMethodEventArgs e)
    {
        Link l =(Link)e.InputParameters[0];
        l.LinkType = 1;
        FileUpload img = (FileUpload)fv1.FindControl( "fileImg" );

        if ( img != null )
        {
          l.Image = this.GetLinkImg(img);
        }
    }

    protected void ods3_Deleted(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( EventID.Update , "删除链接" , "删除链接,链接编号：" + QS( "lid" ) );

            WebAgent.SuccAndGo( "删除成功." , "LinkList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "删除失败." , "LinkList.aspx" );
        }
    }
    protected void ods3_Updating(object sender , ObjectDataSourceMethodEventArgs e)
    {
        Link l = (Link)e.InputParameters[0];

        HiddenField hidimg=(HiddenField)fv1.FindControl("hidImg");

        FileUpload img = (FileUpload)fv1.FindControl( "fileImg" );
        if ( img != null )
        { 
             l.Image= this.GetLinkImg(img);
        }
        if ( l.Image == "" && hidimg != null )
        {
            l.Image = hidimg.Value;
        }
    }
    protected void ods3_Updated(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( EventID.Update , "修改链接" , "修改链接,链接编号：" + QS( "lid" ) );

            WebAgent.SuccAndGo( "修改成功." , "LinkList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "修改失败." , ViewState["BACK"].ToString() );
        }
    }
    protected void ods3_Inserted(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( EventID.Insert , "添加链接" , "添加链接" );

            WebAgent.SuccAndGo( "添加成功." , "LinkList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "添加失败." , ViewState["BACK"].ToString() );
        }
    }

    ///// <summary>
    ///// 获得链接图片
    ///// </summary>
    ///// <returns></returns>
    //public string GetLinkImg()
    //{
    //    string photo = "";

    //    FileUpload img = (FileUpload)fv1.FindControl("fileImg");

    //    if ( img.HasFile )
    //    {
    //        HttpPostedFile file = img.PostedFile;
    //        string folder = Server.MapPath( ShopInfo.DataPath+"/Link/" );

    //        if ( !Directory.Exists( folder ) )
    //        {
    //            Directory.CreateDirectory( folder );
    //        }

    //        string newkey = WebAgent.NewKey();

    //        string photos = folder + newkey + file.FileName.Substring( file.FileName.LastIndexOf( '.' ) );

    //        photo = folder + newkey + file.FileName.Substring( file.FileName.LastIndexOf( '.' ) );

    //        file.SaveAs( photos );

    //    }

    //    return photo;
    //}

    protected void btnDelImg_Click(object sender , EventArgs e)
    {
        using ( LinkAgent la = new LinkAgent() )
        {
            Link lk = la.GetLinkByID( int.Parse( QS( "lid" ) ) );
            
            lk.ID = int.Parse( QS( "lid" ) );
            lk.Image = "";

            if ( la.LinkUpdate( lk ) > 0 )
            {
                WebAgent.SuccAndGo( "删除成功." ,Request.RawUrl);
            }
            
        }
    }
}
