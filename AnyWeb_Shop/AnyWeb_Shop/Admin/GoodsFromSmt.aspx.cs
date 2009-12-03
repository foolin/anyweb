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
using Common.Agent;
using Studio.Web;
using System.Net;
using System.IO;

public partial class GoodsFromSmt : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
        
    }


    protected override void OnPreRender(EventArgs e)
    {
        using ( GoodsAgent ga = new GoodsAgent() )
        {
            string pname = Request.QueryString["pName"]+"";
            int recordcount = 0;
            repSmtGoods.DataSource = ga.GetSmtGoods( PN1.PageSize , PN1.PageIndex , pname,out recordcount );
            repSmtGoods.DataBind();
            PN1.SetPage( recordcount );
        }
    }

    protected void btnSave_Click(object sender , EventArgs e)
    {
  
        int status = 1;
        if ( rad1.Checked )
        {
            status = 4;
        }
        string photos = Request.Form["image"] + "";

        if ( Request.Form["chkPro"] + "" != "" && Request.Form["chkChoose"] + "" != "" )
        {
            using ( GoodsAgent ga = new GoodsAgent() )
            {
                if ( ga.AddSmtGoods( photos , Request.Form["chkPro"] , Request.Form["chkChoose"] , status ) > 0 )
                {
                    this.AddLog( Common.Common.EventID.Insert , "导入商脉通产品" , "成功导入" + photos.Split( ',' ).Length + "个商品" );
                    WebAgent.SuccAndGo( "成功导入" + photos.Split(',').Length + "个商品。" , Request.RawUrl );
              
                }
            }
        }
        else
        {
            WebAgent.AlertAndBack( "请选择。" );
        }
    }

  
    protected void btnSearch_Click(object sender , EventArgs e)
    {
        Response.Redirect( "GoodsFromSmt.aspx?pName=" + txtSearch.Text );
    }
}
