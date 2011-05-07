using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_Product_ProductAdd : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = "新建产品";
        int cid = 0;
        int.TryParse( QS( "cid" ), out cid );
        if( cid == 0 )
        {
            Fail( "栏目不存在！" );
        }
        CurrentColumn = new AW_Column_dao().funcGetColumnInfo( cid );
        if( CurrentColumn == null )
        {
            Fail( "栏目不存在！" );
        }

        if( !IsPostBack )
        {
            lblColumn.Text = CurrentColumn.fdColuName;
            txtCreateAt.Text = DateTime.Now.ToString( "yyyy-MM-dd HH:mm" );
        }
    }

    protected void btnSaveAndContinue_Click( object sender, EventArgs e )
    {
        AddProduct();
        Response.Write( string.Format( "<script type=\"text/javascript\">parent.addProductOK({0},\"{1}\",true);</script>", CurrentColumn.fdColuSiteID, CurrentColumn.ColumnIDPath ) );
        Response.End();
    }

    protected void btnSave_Click( object sender, EventArgs e )
    {
        AddProduct();
        Response.Write( string.Format( "<script type=text/javascript>parent.addProductOK({0},\"{1}\");</script>", CurrentColumn.fdColuSiteID, CurrentColumn.ColumnIDPath ) );
        Response.End();
    }

    private void AddProduct()
    {
        DateTime createAt;
        int sort = 0;
        string productPic = QF( "txtPic" ).Trim();
        if( !DateTime.TryParse( txtCreateAt.Text, out createAt ) )
        {
            Fail( "创建时间格式不正确！", true );
        }

        if( !int.TryParse( txtSort.Text.Trim(), out sort ) || sort < 0 )
        {
            Fail( "产品排序格式错误，请输入非负整数！", true );
        }

        AW_Product_dao dao = new AW_Product_dao();
        AW_Product_bean bean = new AW_Product_bean();
        bean.fdProdID = dao.funcNewID();
        bean.fdProdName = txtName.Text.Trim();
        bean.fdProdColuID = CurrentColumn.fdColuID;
        bean.fdProdCode = txtCode.Text.Trim();
        bean.fdProdContent = txtContent.Text;
        bean.fdProdCreateAt = createAt;
        bean.fdProdCanComment = chkEnableComment.Checked ? 0 : 1;
        if( chkDesc.Checked )
        {
            string str = WebAgent.GetText( bean.fdProdContent );
            bean.fdProdDescription = str.Length > 2000 ? str.Substring( 0, 2000 ) : str;
        }
        else
        {
            bean.fdProdDescription = txtDesc.Text;
        }

        if( sort == 0 )
        {
            bean.fdProdSort = bean.fdProdID * 10;
        }
        else
        {
            bean.fdProdSort = sort;
        }
        bean.fdProdImage = productPic;
        if( dao.funcInsert( bean ) > 0 )
        {
            AddLog( EventType.Insert, "添加产品", string.Format( "栏目[{0}]添加产品:[{1}({2})]", CurrentColumn.fdColuName, bean.fdProdName, bean.fdProdID ) );
        }
        else
        {
            Fail( "产品添加失败，请稍候再试！", true );
        }
    }
}
