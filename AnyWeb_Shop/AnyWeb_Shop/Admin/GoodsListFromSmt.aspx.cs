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

public partial class GoodsListFromSmt : AdminBase
{
    DataView dv;
    int times = 0;
    protected void Page_Load(object sender , EventArgs e)
    {

        if ( !IsPostBack )
        {
            DataTable dt = ( new GoodsAgent() ).GetSmtCategory();

            dv = new DataView();

            if ( dt != null )
            {
                dv.Table = dt;
                inittree( null , 0 );
            }
        }
        
    }

    private void inittree(TreeNode tn , int parentid)
    {
        times++;
        if ( times >= 30 )
        {
            return;
        }
        dv.RowFilter = "ParentID = " + parentid;

        foreach ( DataRowView drv in dv )
        {
            TreeNode node = new TreeNode();
            if ( tn == null )
            {
                node.Text = drv["CategoryName"].ToString();
                node.Value = drv["CategoryID"].ToString();

                node.Expanded = false;

                this.tvCategory.Nodes.Add( node );
                inittree( node , (int)drv["CategoryID"] );
            }
            else
            {
                node.Text = drv["CategoryName"].ToString();
                node.Value = drv["CategoryID"].ToString();

                node.Expanded = false;
                tn.ChildNodes.Add( node );
                inittree( node , (int)drv["CategoryID"] );
            }

        }
    }


    protected void btnSave_Click(object sender , EventArgs e)
    {
        string nodevalue="",nodetext="";

        int status = 1;
        if ( rad1.Checked )
        {
            status = 4;
        }
        if ( tvCategory.CheckedNodes.Count > 0 )
        {
            foreach ( TreeNode tn in tvCategory.CheckedNodes )
            {
               
                 nodevalue += tn.Value + ',';
                 nodetext += tn.Text + ',';
                
            }
            if ( Request.Form["chkChoose"] + "" != "" )
            {
                string nvalue = nodevalue.Substring( 0 , nodevalue.Length - 1 );
                using ( GoodsAgent ga = new GoodsAgent() )
                {
                    int count = ga.AddSmtGoodsList( int.Parse( Request.Form["chkChoose"] ) , nvalue , nvalue.Split( ',' ).Length ,status);
                    if ( count > 0 )
                    {
                        this.AddLog( Common.Common.EventID.Insert , "批量导入商脉通商品" , "成功导入" + count + "个产品，导入的商品类别有：" + nodetext );
                        WebAgent.AlertAndBack( "成功导入" + count + "个产品。" );
                    }
                    else if ( count ==  0 )
                    {
                        WebAgent.AlertAndBack("该类别下无任何商品" );
                    }
                }
            }
            else
            {
                WebAgent.AlertAndBack( "请选择项。" );
            }

        }

    }
}
