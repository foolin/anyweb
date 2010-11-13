using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class User_Index : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
    {
        using( AW_Resume_dao dao = new AW_Resume_dao() )
        {
            this._resuCount = dao.funcGetResumeCount( this.LoginUser.fdUserID );
            this._lastUpdate = dao.funcGetLastUpdateTime( this.LoginUser.fdUserID );
            rep.DataSource = dao.funcGetResumeList( this.LoginUser.fdUserID );
            rep.DataBind();
        }
    }

    private int _resuCount;
    public int resuCount
    {
        get
        {
            return _resuCount;
        }
        set
        {
            _resuCount = value;
        }
    }

    private DateTime _lastUpdate;
    public DateTime lastUpdate
    {
        get
        {
            return _lastUpdate;
        }
        set
        {
            _lastUpdate = value;
        }
    }
}
