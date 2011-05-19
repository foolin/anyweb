using System;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;

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
                if( _articleID == 0 )
                {
                    int.TryParse( QS( "did" ), out _articleID );
                }
                return _articleID;
            }
            set
            {
                _articleID = value;
            }
        }

        protected override object GetItemObject()
        {
            AW_Article_bean article;

            if( this.ArticleID == 0 )
            {
                return "文档不存在！";
            }

            article = AW_Article_bean.funcGetByID( this.ArticleID );

            if( article == null )
            {
                return "文档不存在！";
            }

            switch( this.ItemType )
            {
                case ItemObjectType.Next:
                    {

                        article = new AW_Article_dao().funcGetNextArticleByUC( article );
                        break;
                    }
                case ItemObjectType.Previous:
                    {
                        article = new AW_Article_dao().funcGetPreviousArticleByUC( article );
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return article;
        }
    }
}
