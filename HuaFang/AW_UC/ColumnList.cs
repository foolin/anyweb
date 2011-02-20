using System;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.ComponentModel;
using Studio.Web;
using System.Web;

namespace AnyWell.AW_UC
{
    public class ColumnList : ListControlBase
    {
        public int _columnID;
        /// <summary>
        /// 栏目编号
        /// </summary>
        public int ColumnID
        {
            get
            {
                if (this.FromArticle)
                {
                    int articleID = 0;
                    AW_Article_bean article = new AW_Article_bean();
                    int.TryParse(this.ContextItem("ARTICLEID"), out articleID);
                    if (articleID == 0)
                    {
                        goErrorPage();
                    }
                    else
                    {
                        if (HttpContext.Current.Items["ARTICLE_" + articleID] != null)
                        {
                            article = (AW_Article_bean)HttpContext.Current.Items["ARTICLE_" + articleID];
                        }
                        else
                        {
                            article = AW_Article_bean.funcGetByID(articleID);
                            HttpContext.Current.Items.Add("ARTICLE_" + articleID, article);
                        }
                        this._columnID = article.fdArtiColumnID;
                    }
                }
                else if (this._columnID == 0)
                {
                    int.TryParse(this.ContextItem("COLUMNID"), out this._columnID);
                }
                return this._columnID;
            }
            set { _columnID = value; }
        }

        private bool _getParent = false;
        /// <summary>
        /// 获取或设置是否返回同级栏目
        /// </summary>
        [Description("设置是否返回同级栏目")]
        public bool GetParent
        {
            get { return _getParent; }
            set { _getParent = value; }
        }

        private bool _fromArticle = false;
        /// <summary>
        /// 是否文章中读取栏目编号
        /// </summary>
        public bool FromArticle
        {
            get { return _fromArticle; }
            set { _fromArticle = value; }
        }

        protected override object GetDataObject()
        {
            if (this.ColumnID == 0)
            {
                goErrorPage();
                return null;
            }
            else
            {
                if (this.ColumnID != -1)
                {
                    AW_Column_bean bean = AW_Column_bean.funcGetByID(this.ColumnID);
                    if (bean == null)
                    {
                        goErrorPage();
                        return null;
                    }
                }
                return new AW_Column_dao().funcGetColumnListByUC(this.ColumnID, this.GetParent, this.TopCount, this.Where, this.Order, this.CacheName);
            }
        }
    }
}
