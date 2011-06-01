using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Exhibitor_ExhibitorEdit : PageAdmin
{
    protected AW_Exhibitor_bean bean;
    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = "修改展商";
        int id = 0;
        int.TryParse( QS( "id" ), out id );
        if( id == 0 )
        {
            Fail( "展商不存在！" );
        }

        bean = AW_Exhibitor_bean.funcGetByID( id );

        if( bean == null )
        {
            Fail( "展商不存在！" );
        }

        CurrentColumn = new AW_Column_dao().funcGetColumnInfo( bean.fdExhiColuID );

        if( !IsPostBack )
        {
            txtName.Text = bean.fdExhiName;
            txtEnName.Text = bean.fdExhiName;
            txtNumber.Text = bean.fdExhiNumber;
            drpType.SelectedValue = bean.fdExhiType.ToString();
            txtUrl.Text = bean.fdExhiUrl;
            txtContent.Text = bean.fdExhiContent;
            txtSort.Text = bean.fdExhiSort.ToString();
        }
    }

    protected void btnSave_Click( object sender, EventArgs e )
    {
        int sort = 0;

        if( !int.TryParse( txtSort.Text.Trim(), out sort ) || sort < 0 )
        {
            Fail( "展商排序格式错误，请输入非负整数！", true );
        }

        AW_Exhibitor_dao dao = new AW_Exhibitor_dao();
        bean.fdExhiName = txtName.Text.Trim();
        bean.fdExhiEnName = txtEnName.Text.Trim();
        bean.fdExhiNumber = txtNumber.Text.Trim();
        bean.fdExhiType = int.Parse( drpType.SelectedValue );
        bean.fdExhiUrl = txtUrl.Text.Trim().ToLower();
        if( !string.IsNullOrEmpty( bean.fdExhiUrl ) && !bean.fdExhiUrl.StartsWith( "http://" ) )
        {
            bean.fdExhiUrl = "http://" + bean.fdExhiUrl;
        }
        bean.fdExhiContent = txtContent.Text;
        if( sort == 0 )
        {
            bean.fdExhiSort = bean.fdExhiID * 10;
        }
        else
        {
            bean.fdExhiSort = sort;
        }

        if( dao.funcUpdate( bean ) > 0 )
        {
            AddLog( EventType.Update, "修改展商", string.Format( "栏目[{0}]修改展商:[{1}({2})]", CurrentColumn.fdColuName, bean.fdExhiName, bean.fdExhiID ) );
            Response.Write( "<script type=text/javascript>parent.editExhibitorOK();</script>" );
            Response.End();
        }
        else
        {
            Fail( "展商修改失败，请稍候再试！", true );
        }
    }
}
