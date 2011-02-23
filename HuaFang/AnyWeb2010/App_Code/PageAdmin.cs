using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Studio.Web;
using AnyWell.Configs;
using AnyWell.AW_DL;
using System.Collections.Generic;

/// <summary>
///ShopAdmin 的摘要说明
/// </summary>
public class PageAdmin : Page
{
    private AW_Admin_bean _adminInfo;
    /// <summary>
    /// 管理员信息
    /// </summary>
    public AW_Admin_bean AdminInfo
    {
        get { return _adminInfo; }
        set { _adminInfo = value; }
    }

    protected override void OnPreLoad( EventArgs e )
    {
        if( !this.IsPostBack && Request.UrlReferrer != null )
        {
            ViewState[ "REFURL" ] = Request.UrlReferrer.PathAndQuery;
        }
    }

    protected override void OnPreInit( EventArgs e )
    {
        _adminInfo = (new AW_Admin_dao()).funcGetAdminFromCookie();
        if (_adminInfo == null)
            Response.Redirect("~/Admin/Login.aspx");
    }

    protected string RefUrl
    {
        get
        {
            return (string)ViewState["REFURL"];
        }
    }

    static PageAdmin()
    {
        Validator.ScriptSrc = "js/validator1.2.js";
    }

    protected string QS(string key)
    {
        return Request.QueryString[key] + "";
    }

    protected string QF(string key)
    {
        return Request.Form[key] + "";
    }

    protected void SetUploadForm()
    {
        HtmlForm form1 = (HtmlForm)this.Master.FindControl("form1");
        form1.Enctype = "multipart/form-data";
    }

    /// <summary>
    /// 添加操作日志
    /// </summary>
    /// <param name="type"></param>
    /// <param name="name"></param>
    /// <param name="description"></param>
    protected void AddLog(EventType type, string name, string description)
    {
        using (AW_Log_dao dao = new AW_Log_dao())
        {
            AW_Log_bean log = new AW_Log_bean();
            log.fdLogID = dao.funcNewID();
            log.fdLogType = (int)type;
            log.fdLogName = name;
            log.fdLogDesc = description;
            log.fdLogAccount = AdminInfo.fdAdmiAccount;
            log.fdLogIP = Request.UserHostAddress;
            log.fdLogCreateAt = DateTime.Now;
            dao.funcInsert(log);
        }
    }

    /// <summary>
    /// 设置文章标签
    /// </summary>
    /// <param name="article"></param>
    /// <param name="tags"></param>
    protected void SetTags( AW_Article_bean article, string tags )
    {
        AW_Tag_dao tagdao = new AW_Tag_dao();
        AW_Tag_Associated_dao dao = new AW_Tag_Associated_dao();
        if( article.TagList.Count == 0 )
        {
            if( tags.Length > 0 )
            {
                foreach( string tag in tags.Split( ',' ) )
                {
                    int tagId = tagdao.funcGetTagByName( tag );
                    if( tagId > 0 ) //标签已存在                             
                    {
                        AW_Tag_Associated_bean bean = new AW_Tag_Associated_bean();
                        bean.fdTaAsID = dao.funcNewID();
                        bean.fdTaAsTagID = tagId;
                        bean.fdTaAsDataID = article.fdArtiID;
                        bean.fdTaAsType = 0;
                        dao.funcInsert( bean );
                    }
                    else
                    {
                        //添加标签
                        AW_Tag_bean tagbean = new AW_Tag_bean();
                        tagbean.fdTagID = tagdao.funcNewID();
                        tagbean.fdTagName = tag;
                        tagbean.fdTagSort = tagbean.fdTagID * 100;
                        tagdao.funcInsert( tagbean );
                        //添加关联
                        AW_Tag_Associated_bean bean = new AW_Tag_Associated_bean();
                        bean.fdTaAsID = dao.funcNewID();
                        bean.fdTaAsTagID = tagbean.fdTagID;
                        bean.fdTaAsDataID = article.fdArtiID;
                        bean.fdTaAsType = 0;
                    }
                }
            }
        }
        else
        {
            //添除已删除的标签关联
            List<AW_Tag_bean> listTemp = new List<AW_Tag_bean>( article.TagList );
            foreach( AW_Tag_bean tagbean in article.TagList )
            {
                bool exist = false;
                foreach( string tag in tags.Split( ',' ) )
                {
                    if( tagbean.fdTagName == tag )
                    {
                        exist = true;
                        break;
                    }
                }
                if( !exist )
                {
                    dao.funcDelAssociated( tagbean.fdTagID, article.fdArtiID, 0 );
                    listTemp.Remove( tagbean );
                }
            }
            article.TagList = listTemp;
            //增加新标签关联
            foreach( string tag in tags.Split( ',' ) )
            {
                bool exist = false;
                foreach( AW_Tag_bean tagbean in article.TagList )
                {
                    if( tagbean.fdTagName == tag )
                    {
                        exist = true;
                        break;
                    }
                }
                if( !exist )
                {
                    int tagId = tagdao.funcGetTagByName( tag );
                    if( tagId > 0 ) //标签已存在                             
                    {
                        AW_Tag_Associated_bean bean = new AW_Tag_Associated_bean();
                        bean.fdTaAsID = dao.funcNewID();
                        bean.fdTaAsTagID = tagId;
                        bean.fdTaAsDataID = article.fdArtiID;
                        bean.fdTaAsType = 0;
                        dao.funcInsert( bean );
                    }
                    else
                    {
                        //添加标签
                        AW_Tag_bean tagbean = new AW_Tag_bean();
                        tagbean.fdTagID = tagdao.funcNewID();
                        tagbean.fdTagName = tag;
                        tagbean.fdTagSort = tagbean.fdTagID * 100;
                        tagdao.funcInsert( tagbean );
                        //添加关联
                        AW_Tag_Associated_bean bean = new AW_Tag_Associated_bean();
                        bean.fdTaAsID = dao.funcNewID();
                        bean.fdTaAsTagID = tagbean.fdTagID;
                        bean.fdTaAsDataID = article.fdArtiID;
                        bean.fdTaAsType = 0;
                    }
                }
            }
        }
    }
}