using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_Product_ProductEdit : PageAdmin
{
    protected AW_Product_bean bean;
    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = "修改产品";
        int id = 0;
        int.TryParse( QS( "id" ), out id );
        if( id == 0 )
        {
            Fail( "产品不存在！" );
        }

        bean = AW_Product_bean.funcGetByID( id );

        if( bean == null )
        {
            Fail( "产品不存在！" );
        }

        //引用产品
        if( bean.fdProdType == 1 )
        {
            Response.Redirect( "ProductEdit.aspx?id=" + bean.fdProdSourceID );
        }

        CurrentColumn = new AW_Column_dao().funcGetColumnInfo( bean.fdProdColuID );

        if( !IsPostBack )
        {
            txtName.Text = bean.fdProdName;
            lblColumn.Text = CurrentColumn.fdColuName;
            txtContent.Text = bean.fdProdContent;
            txtDesc.Text = bean.fdProdDescription;
            txtCreateAt.Text = bean.fdProdCreateAt.ToString( "yyyy-MM-dd HH:mm" );
            txtSort.Text = bean.fdProdSort.ToString();
            chkEnableComment.Checked = bean.fdProdCanComment == 0 ? true : false;
        }
    }

    protected void btnSave_Click( object sender, EventArgs e )
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
        bean.fdProdName = txtName.Text.Trim();
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
        if( dao.funcUpdate( bean ) > 0 )
        {
            AddLog( EventType.Update, "修改产品", string.Format( "栏目[{0}]修改产品:[{1}({2})]", CurrentColumn.fdColuName, bean.fdProdName, bean.fdProdID ) );
            Response.Write( "<script type=text/javascript>parent.editProductOK();</script>" );
            Response.End();
        }
        else
        {
            Fail( "产品修改失败，请稍候再试！", true );
        }
    }
}
