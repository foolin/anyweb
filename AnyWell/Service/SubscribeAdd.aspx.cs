using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class SubscribeAdd : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        AW_Subscribe_bean bean = new AW_Subscribe_bean();
        AW_Subscribe_dao dao = new AW_Subscribe_dao();
        bean.fdSubsCompany = QF( "company" );
        bean.fdSubsSurname = QF( "surname" );
        bean.fdSubsName = QF( "name" );
        bean.fdSubsEmail = QF( "email" );
        if( dao.funcCheckEmailExist( SiteID, bean.fdSubsEmail ) )
        {
            if( Language == "ch" )
            {
                WebAgent.AlertAndBack( "电子邮件已存在！" );
            }
            else
            {
                WebAgent.AlertAndBack( "The email already exists！" );
            }
        }
        bean.fdSubsID = dao.funcNewID();
        bean.fdSubsSort = bean.fdSubsID * 10;
        bean.fdSubsSiteID = SiteID;
        if( dao.funcInsert( bean ) > 0 )
        {
            if( Language == "ch" )
            {
                WebAgent.SuccAndGo( "电子展讯订阅注册成功！" );
            }
            else
            {
                WebAgent.SuccAndGo( "Registered success！" );
            }
        }
        else
        {
            if( Language == "ch" )
            {
                WebAgent.AlertAndBack( "电子展讯订阅注册失败，请稍候再试！" );
            }
            else
            {
                WebAgent.AlertAndBack( "Registered failure, please try again later！" );
            }
        }
    }
}
