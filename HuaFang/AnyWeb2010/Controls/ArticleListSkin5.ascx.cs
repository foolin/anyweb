﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Controls_ArticleListSkin5 : System.Web.UI.UserControl
{
    protected void Page_Load( object sender, EventArgs e )
    {
        List<AW_Article_bean> list = new AW_Article_dao().funcGetArticleListByUC( columnID, 4, true, "", "", "", false );
        rep1.DataSource = list.Count > 2 ? list.GetRange( 0, 2 ) : list;
        rep1.DataBind();
        rep2.DataSource = list.Count > 2 ? list.GetRange( 2, list.Count - 2 ) : null;
        rep2.DataBind();
    }

    private int _columnID;
    /// <summary>
    /// 栏目编号
    /// </summary>
    public int columnID
    {
        get
        {
            return _columnID;
        }
        set
        {
            _columnID = value;
        }
    }
}
