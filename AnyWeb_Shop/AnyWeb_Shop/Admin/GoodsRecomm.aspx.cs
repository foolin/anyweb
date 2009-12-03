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
using Common.Agent;
using Admin.Framework;

public partial class GoodsRecomm : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
        string goodsid = Request.Params["gid"] + "";
        if ( goodsid != "" && Request.Params["type"] != null )
        {
            bool t = Request.Params["type"].ToLower()=="1" ? false : true;
            using ( GoodsAgent ga = new GoodsAgent() )
            {
                if ( ga.GoodsRecommend( int.Parse(goodsid) , t ) > 0 )
                {
                    Response.Write( "0" );

                }
                else
                {
                    Response.Write( "1" );
                }
            }
        }
    }
}
