using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using System.Web.UI.MobileControls;

public partial class AddFavorite : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string msg = "";
        if( this.LoginUser == null )
        {
            msg = string.Format("alert(\"请先登录！\");window.location=\"/Login.aspx?back={0}\";", Request.UrlReferrer );
            WriteScript( msg );
            return;
        }
        if( string.IsNullOrEmpty( QS( "ids" ) ) )
        {
            msg = "alert(\"请选择要收藏的职位！\")";
            WriteScript( msg );
            return;
        }

        List<int> list = RemoveExistId( QS( "ids" ) );
        using( AW_Favorite_dao dao = new AW_Favorite_dao() )
        {
            foreach( int id in list )
            {
                AW_Favorite_bean bean = new AW_Favorite_bean();
                bean.fdFavoID = dao.funcNewID();
                bean.fdFavoUserID = this.LoginUser.fdUserID;
                bean.fdFavoRecrID = id;
                bean.fdFavoCreateAt = DateTime.Now;
                dao.funcInsert( bean );
            }
        }
        WriteScript( "alert(\"所选职位收藏成功！\");" );
    }

    /// <summary>
    /// 移除已收藏的编号
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    protected List<int> RemoveExistId( string ids )
    {
        List<int> existList = new AW_Favorite_dao().funcGetExistIds( this.LoginUser.fdUserID, ids );
        List<int> list = new List<int>();
        foreach( string id in ids.Split( ',' ) )
        {
            if( !existList.Contains( int.Parse( id ) ) )
            {
                list.Add( int.Parse( id ) );
            }
        }
        return list;
    }

    protected void WriteScript( string Script )
    {
        Response.Clear();
        Response.Write( Script );
        Response.End();
    }
}
