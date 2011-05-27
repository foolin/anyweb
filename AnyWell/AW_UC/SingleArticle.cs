using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using AnyWell.AW_DL;

namespace AnyWell.AW_UC
{
    public class SingleArticle : ItemControlBase
    {
        private int _ColumnID;
        /// <summary>
        /// 栏目编号
        /// </summary>
        public int ColumnID
        {
            get
            {
                if( _ColumnID == 0 )
                {
                    int.TryParse( QS( "cid" ), out _ColumnID );
                }
                return _ColumnID;
            }
            set
            {
                _ColumnID = value;
            }
        }

        private int _pageID = 0;
        [Description( "内容分页" ), Browsable( false )]
        public virtual int PageID
        {
            get
            {
                if( _pageID == 0 && Context.Request.QueryString[ "dpid" ] != null )
                {
                    int.TryParse( Context.Request.QueryString[ "dpid" ], out _pageID );
                }
                if( _pageID <= 0 )
                {
                    _pageID = 1;
                }
                return _pageID;
            }
            set
            {
                _pageID = value;
            }
        }

        protected override object GetItemObject()
        {
            AW_SingleArticle_bean article;

            if( this.ColumnID == 0 )
            {
                return "单篇文档栏目不存在！";
            }

            article = new AW_SingleArticle_dao().funcGetSingleArticle( this.ColumnID );

            if( article == null )
            {
                return "单篇文档栏目不存在！";
            }

            if( article.PageCount > 1 )
            {
                article.fdSingContent = article.Contents[ this.PageID - 1 ];
            }

            return article;
        }
    }
}
