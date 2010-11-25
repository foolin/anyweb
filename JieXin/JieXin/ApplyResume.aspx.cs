using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class ApplyResume : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string msg = "";
        if( this.LoginUser == null )
        {
            msg = string.Format( "alert(\"请先登录！\");window.location=\"/Login.aspx?back={0}\";", Request.UrlReferrer );
            WriteScript( msg );
            return;
        }
        if( string.IsNullOrEmpty( QS( "ids" ) ) || !WebAgent.IsInt32( QS( "ids" ) ) )
        {
            msg = "alert(\"请选择要申请的职位！\")";
            WriteScript( msg );
            return;
        }
        if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) )
        {
            msg = "alert(\"请选择要投递的简历！\")";
            WriteScript( msg );
            return;
        }

        AW_Resume_bean resume = new AW_Resume_dao().funcGetResumeById( int.Parse( QS( "id" ) ) );
        if( resume == null || resume.fdResuUserID != this.LoginUser.fdUserID )
        {
            msg = "alert(\"简历不存在，请重新选择！\")";
            WriteScript( msg );
            return;
        }

        List<int> list = RemoveExistId( QS( "ids" ), resume.fdResuID );
        using( AW_Apply_dao dao = new AW_Apply_dao() )
        {
            foreach( int id in list )
            {
                AW_Apply_bean bean = new AW_Apply_bean();
                bean.fdApplID = dao.funcNewID();
                bean.fdApplUserID = this.LoginUser.fdUserID;
                bean.fdApplRecrID = id;
                bean.fdApplResuID = resume.fdResuID;
                bean.fdApplCreateAt = DateTime.Now;
                dao.funcInsert( bean );
            }
        }
        WriteScript( "alert(\"所选职位申请成功！\");" );
    }

    /// <summary>
    /// 移除已收藏的职位
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    protected List<int> RemoveExistId( string ids, int resuId )
    {
        List<int> existList = new AW_Apply_dao().funcGetExistIds( this.LoginUser.fdUserID, resuId, ids );
        List<int> list = new List<int>();
        if( existList == null )
        {
            foreach( string id in ids.Split( ',' ) )
            {
                list.Add( int.Parse( id ) );
            }
        }
        else
        {
            foreach( string id in ids.Split( ',' ) )
            {
                if( !existList.Contains( int.Parse( id ) ) )
                {
                    list.Add( int.Parse( id ) );
                }
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
