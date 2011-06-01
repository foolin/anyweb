using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Exhibitor_ExhibitorAdd : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = "新建展商";
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
        }
    }

    protected void btnSaveAndContinue_Click( object sender, EventArgs e )
    {
        AddExhibitor();
        Response.Write( string.Format( "<script type=\"text/javascript\">parent.addExhibitorOK({0},\"{1}\",true);</script>", CurrentColumn.fdColuSiteID, CurrentColumn.ColumnIDPath ) );
        Response.End();
    }

    protected void btnSave_Click( object sender, EventArgs e )
    {
        AddExhibitor();
        Response.Write( string.Format( "<script type=text/javascript>parent.addExhibitorOK({0},\"{1}\");</script>", CurrentColumn.fdColuSiteID, CurrentColumn.ColumnIDPath ) );
        Response.End();
    }

    private void AddExhibitor()
    {
        int sort = 0;

        if( !int.TryParse( txtSort.Text.Trim(), out sort ) || sort < 0 )
        {
            Fail( "展商排序格式错误，请输入非负整数！", true );
        }

        AW_Exhibitor_dao dao = new AW_Exhibitor_dao();
        AW_Exhibitor_bean bean = new AW_Exhibitor_bean();
        bean.fdExhiID = dao.funcNewID();
        bean.fdExhiName = txtName.Text.Trim();
        bean.fdExhiEnName = txtEnName.Text.Trim();
        bean.fdExhiColuID = CurrentColumn.fdColuID;
        bean.fdExhiNumber = txtNumber.Text.Trim();
        bean.fdExhiType = int.Parse( drpType.SelectedValue );
        bean.fdExhiUrl = txtUrl.Text.Trim().ToLower();
        if( !string.IsNullOrEmpty( bean.fdExhiUrl ) && !bean.fdExhiUrl.StartsWith( "http://" ) )
        {
            bean.fdExhiUrl = "http://" + bean.fdExhiUrl;
        }
        bean.fdExhiContent = txtContent.Text;
        bean.fdExhiCreateAt = DateTime.Now;
        if( sort == 0 )
        {
            bean.fdExhiSort = bean.fdExhiID * 10;
        }
        else
        {
            bean.fdExhiSort = sort;
        }

        if( dao.funcInsert( bean ) > 0 )
        {
            AddLog( EventType.Insert, "添加展商", string.Format( "栏目[{0}]添加展商:[{1}({2})]", CurrentColumn.fdColuName, bean.fdExhiName, bean.fdExhiID ) );
        }
        else
        {
            Fail( "展商添加失败，请稍候再试！", true );
        }
    }
}
