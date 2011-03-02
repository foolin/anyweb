﻿using System;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Web;

namespace AnyWell.AW_UC
{
    /// <summary>
    /// 单个文章组件，可展示单一篇文章的某个属性或一组属性
    /// </summary>
    public class Article : ItemControlBase
    {
        private int _articleID;
        /// <summary>
        /// 文章编号
        /// </summary>
        public int ArticleID
        {
            get
            {
                if( !this.HasInit )
                {
                    if( this._articleID == 0 )
                    {
                        int.TryParse( this.ContextItem( "ARTICLEID" ), out this._articleID );
                    }
                    switch( this.ItemType )
                    {
                        case ItemObjectType.Next:
                            {

                                this._articleID = new AW_Article_dao().funcGetNextArticleIDByUC( this._articleID );
                                break;
                            }
                        case ItemObjectType.Previous:
                            {
                                this._articleID = new AW_Article_dao().funcGetPreviousArticleIDByUC( this._articleID );
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                    this.HasInit = true;
                }
                return this._articleID;
            }
            set { _articleID = value; }
        }

        protected override object GetItemObject()
        {
            AW_Article_bean article;

            if (this.ArticleID == 0)
            {
                if (this.ItemType == ItemObjectType.Current)
                {
                    goErrorPage();
                    return null;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                //从上下文中读取该文章，如果该文章存在的话
                if (HttpContext.Current.Items["ARTICLE_" + this.ArticleID] != null)
                {
                    article = (AW_Article_bean)HttpContext.Current.Items["ARTICLE_" + this.ArticleID];
                }
                else
                {
                    article = AW_Article_bean.funcGetByID(this.ArticleID);
                    HttpContext.Current.Items.Add("ARTICLE_" + this.ArticleID, article);
                }

                if (article == null && this.ItemType == ItemObjectType.Current)
                {
                    HttpContext.Current.Response.Redirect("/Error.aspx");
                    return null;
                }
            }

            return article;
        }
    }
}