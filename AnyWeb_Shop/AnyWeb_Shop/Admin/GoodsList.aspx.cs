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
using Common.Agent;

public partial class GoodsList :AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
        btnDel.Attributes["onclick"] = "javascript:return confirm('确定删除,是否继续？');";
    }
    

    protected void btnSearch_Click(object sender , EventArgs e)
    {
       
        Response.Redirect( "GoodsList.aspx?goodsName=" + txtName.Text + "&cid=" + int.Parse(drpType.SelectedValue) + "&status=" + int.Parse(drpStatus.SelectedValue) );
    }

    protected void drpType_DataBound(object sender , EventArgs e)
    {
        ListItem item = new ListItem( "所有商品","0" );
        drpType.Items.Insert( 0 , item );
        int cid = 0;
        if ( WebAgent.IsInt32( QS( "cid" ) ) )
        {
            cid = int.Parse(QS( "cid" ));
        }
        drpType.SelectedValue = cid.ToString();
    }

    protected void ods3_Selected(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( e.OutputParameters["recordCount"] != null )
        {
            int record = (int)e.OutputParameters["recordCount"];
            PN1.SetPage( record );

        }
        drpStatus.SelectedValue = QS( "status" );
    }

    protected void ods3_Selecting(object sender , ObjectDataSourceSelectingEventArgs e)
    {
        if ( WebAgent.IsInt32( QS( "cid" ) ) )
        {
              e.InputParameters["categoryID"]= int.Parse( QS( "cid" ) );
        }

        if ( WebAgent.IsInt32( QS( "status" ) ) )
        {
            e.InputParameters["status"] = int.Parse( QS( "status" ) );
        }

        if ( QS( "recommd" ) +""!="" )
        {
            e.InputParameters["isrecommend"] = bool.Parse(QS( "recommd" ).ToString());
        }
        if (QS("promot") + "" != "")
        {
            e.InputParameters["ispromoted"] = bool.Parse(QS("promot").ToString());
        }
        e.InputParameters["goodsName"] = QS( "goodsName" );
    }

    protected void btnDel_Click(object sender , EventArgs e)
    {
        if ( Request.Form["ids"] + "" != "" )
        {
             using(GoodsAgent ga=new GoodsAgent())
            {
                ga.DeleteGoods( Request.Form["ids"] , Request.Form["ids"].Split( ',' ).Length );

                this.AddLog( EventID.Delete , "批量删除订单" , "批量删除订单,订单编号:"+Request.Form["ids"] );

                WebAgent.SuccAndGo( "删除成功。" , "GoodsList.aspx");
            }
        }
        else
        {
            WebAgent.FailAndGo("请在要删除的项前打勾。", "GoodsList.aspx");
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        
        if ( QS( "goodsName" ) != null )
        {
            this.txtName.Text = QS( "goodsName" );
        }
    }
    public string CheckStatus(int status , DateTime outDate)
    {
        string s = "";
        if ( status == 1 )
        {
            s = "<font color='green'>有货</font>";
        }
        if ( status == 2 )
        {
            s = "<font color='red'>缺货</font>";
        }
        if ( status == 3 || outDate < DateTime.Now )
        {
            s = "<font color='gray'>过期</font>";
        }
        if ( status == 4 )
        {
            s = "<font color='gray'>不显示在首页</font>";
        }
        return s;
    }

    protected void btnRec_Click(object sender, EventArgs e)
    {
        if (Request.Form["ids"] + "" != "")
        {
            using (GoodsAgent ga = new GoodsAgent())
            {
                ga.GoodsRecommends(Request.Form["ids"], true);

                this.AddLog(EventID.Delete, "批量推荐商品", "批量推荐商品,商品编号:" + Request.Form["ids"]);

                WebAgent.SuccAndGo("推荐商品成功。", "GoodsList.aspx");
            }
        }
        else
        {
            WebAgent.FailAndGo("请在要推荐的商品项前打勾。", "GoodsList.aspx");
        }
    }
    protected void btnCancelRec_Click(object sender, EventArgs e)
    {
        if (Request.Form["ids"] + "" != "")
        {
            using (GoodsAgent ga = new GoodsAgent())
            {
                ga.GoodsRecommends(Request.Form["ids"], false);

                this.AddLog(EventID.Delete, "取消批量推荐商品", "取消批量推荐商品,商品编号:" + Request.Form["ids"]);

                WebAgent.SuccAndGo("取消推荐商品成功。", "GoodsList.aspx");
            }
        }
        else
        {
            WebAgent.FailAndGo("请在要取消推荐的商品项前打勾。", "GoodsList.aspx");
        }
    }

    protected void btnPro_Click(object sender, EventArgs e)
    {
        if (Request.Form["ids"] + "" != "")
        {
            using (GoodsAgent ga = new GoodsAgent())
            {
                ga.GoodsPromotions(Request.Form["ids"], false);

                this.AddLog(EventID.Delete, "取消批量促销商品", "取消批量促销商品,商品编号:" + Request.Form["ids"]);

                WebAgent.SuccAndGo("取消促销商品成功。", "GoodsList.aspx");
            }
        }
        else
        {
            WebAgent.FailAndGo("请在要取消促销的商品项前打勾。", "GoodsList.aspx");
        }
    }
}
