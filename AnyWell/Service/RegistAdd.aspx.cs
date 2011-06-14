using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class RegistAdd : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        AW_Regist_bean bean = new AW_Regist_bean();
        AW_Regist_dao dao = new AW_Regist_dao();
        bean.fdRegiEmail = QF( "email" ).Trim();
        if( dao.funcCheckEmailExist( SiteID, bean.fdRegiEmail ) )
        {
            Fail( "error:Email已经存在！" );
        }
        bean.fdRegiAppellation = int.Parse( QF( "appellation" ) );
        bean.fdRegiSurname = QF( "surname" ).Trim();
        bean.fdRegiName = QF( "name" ).Trim();
        bean.fdRegiPosition = QF( "position" ).Trim();
        bean.fdRegiPositionType = int.Parse( QF( "positionType" ) );
        bean.fdRegiCompany = QF( "company" ).Trim();
        bean.fdRegiAddress = QF( "address" ).Trim();
        bean.fdRegiCountry = int.Parse( QF( "country" ) );
        bean.fdRegiPost = QF( "post" ).Trim();
        bean.fdRegiPhone = QF( "phohe" ).Trim();
        bean.fdRegiFax = QF( "fax" ).Trim();
        bean.fdRegiMobile = QF( "mobile" ).Trim();
        bean.fdRegiWebSite = QF( "webSite" ).Trim().ToLower();
        if( !string.IsNullOrEmpty( bean.fdRegiWebSite ) && !bean.fdRegiWebSite.StartsWith( "http://" ) )
        {
            bean.fdRegiWebSite = "http://" + bean.fdRegiWebSite;
        }
        bean.fdRegiBusiness = QF( "business" );
        if( bean.fdRegiBusiness.Contains( "9" ) )
        {
            bean.fdRegiBusiness += ":" + QF( "business_other" ).Trim();
        }
        bean.fdRegiTarget1 = QF( "target1" );
        if( bean.fdRegiTarget1.Contains( "4" ) )
        {
            bean.fdRegiTarget1 += ":" + QF( "target1_other" ).Trim();
        }
        bean.fdRegiTarget2 = QF( "target2" );
        bean.fdRegiTarget3 = QF( "target3" );
        if( bean.fdRegiTarget3.Contains( "10" ) )
        {
            bean.fdRegiTarget3 += ":" + QF( "target3_other" ).Trim();
        }
        bean.fdRegiTarget4 = QF( "target4" );
        bean.fdRegiTarget5 = QF( "target5" );
        if( bean.fdRegiTarget5.Contains( "7" ) )
        {
            bean.fdRegiTarget5 += ":" + QF( "target5_other" ).Trim();
        }
        bean.fdRegiTarget6 = QF( "target6" );
        if( bean.fdRegiTarget6.Contains( "3" ) )
        {
            bean.fdRegiTarget6 += ":" + QF( "target6_other" ).Trim();
        }
        bean.fdRegiFunction = QF( "function" );
        if( bean.fdRegiFunction.Contains( "9" ) )
        {
            bean.fdRegiFunction += ":" + QF( "function_other" ).Trim();
        }
        bean.fdRegiPurpose = QF( "purpose" );
        if( bean.fdRegiPurpose.Contains( "7" ) )
        {
            bean.fdRegiPurpose += ":" + QF( "purpose_other" ).Trim();
        }
        bean.fdRegiDecision = int.Parse( QF( "decision" ) );
        bean.fdRegiBudget = int.Parse( QF( "budget" ) );
        bean.fdRegiFrom = QF( "from" );
        if( bean.fdRegiFrom.Contains( "10" ) )
        {
            bean.fdRegiFrom += ":" + QF( "from_other" ).Trim();
        }
        bean.fdRegiInterest = int.Parse( QF( "interest" ) );
        bean.fdRegiID = dao.funcNewID();
        bean.fdRegiSiteID = SiteID;
        if( dao.funcInsert( bean ) > 0 )
        {
            Context.Items.Add( "Context_Regist", bean );
            string templatePath = string.Format( "~/Contorls/Regist/{0}.ascx", SiteID );
            BuildPage( templatePath );
        }
        else
        {
            Fail( "error:观众预登记注册失败，请稍候再试！" );
        }
    }
}
