using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using AnyWell.AW_DL;

namespace AnyWell.AW_UC
{
    /// <summary>
    /// 文章内容分页组件
    /// </summary>
    public class CPager : Pager
    {
        public CPager()
        {
            this.PageIDKey = "dpid";
            this.ShowGo = false;
            this.SummaryText = "";
            this.FirstPageText = this.LastPageText = "";
            this.SplitSize = 100;
        }

        [Browsable( false )]
        public override int PageSize
        {
            get
            {
                return 1;
            }
        }

        [Browsable( false )]
        public override int RecordCount
        {
            get
            {
                int pageCount = 1;
                if( Context.Items[ "OBJECTTYPE" ] != null )
                {
                    //单篇文档栏目
                    if( ( ColumnType ) Context.Items[ "OBJECTTYPE" ] == ColumnType.Single )
                    {
                        int cid = 0;
                        int.TryParse( Context.Request.QueryString[ "cid" ], out cid );
                        AW_SingleArticle_bean article = new AW_SingleArticle_dao().funcGetSingleArticle( cid );
                        pageCount = article.PageCount;
                    }
                    else
                    {
                        int did = 0;
                        int.TryParse( Context.Request.QueryString[ "did" ], out did );
                        switch( ( ColumnType ) Context.Items[ "OBJECTTYPE" ] )
                        {
                            case ColumnType.Article:
                                AW_Article_bean article = AW_Article_bean.funcGetByID( did, "fdArtiContent" );
                                pageCount = article.PageCount;
                                break;
                            default:
                                pageCount = 0;
                                break;
                        }
                    }
                }
                return pageCount;
            }
        }
    }
}
