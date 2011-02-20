using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Studio.Web;
using AnyWell.AW_DL;
using System.Web;

namespace AnyWell.AW_UC
{
    public class ArticleList : ListControlBase
    {
        int _columnID = 0;
        /// <summary>
        /// 获取或设置栏目编号
        /// </summary>
        [Description("设置栏目编号")]
        public virtual int ColumnID
        {
            get
            {
                if (this._columnID == 0)
                {
                    int.TryParse(this.ContextItem("COLUMNID"), out this._columnID);
                }
                return this._columnID;
            }
            set { _columnID = value; }
        }

        private bool _getChild = false;
        /// <summary>
        /// 级联获取下级栏目的文章
        /// </summary>
        [Description("是否级联获取下级栏目的文章"), DefaultValue(false)]
        public bool GetChild
        {
            get { return _getChild; }
            set { _getChild = value; }
        }

        private bool _getContent = false;
        /// <summary>
        /// 获取文章内容
        /// </summary>
        [Description("是否获取文章内容"), DefaultValue(false)]
        public bool GetContent
        {
            get { return _getContent; }
            set { _getContent = value; }
        }

        private string _pagerID;
        /// <summary>
        /// 获取或设置分页控件的ID
        /// </summary>
        [Description("设置关联的分页控件ID")]
        public string PagerID
        {
            get { return _pagerID; }
            set { _pagerID = value; }
        }

        protected virtual Pager Pager
        {
            get
            {
                if (string.IsNullOrEmpty(this.PagerID) == false)
                {
                    return (Pager)this.Parent.FindControl(this.PagerID);
                }
                else
                {
                    return null;
                }
            }
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
                List<AW_Article_bean> articles;
                if (this.Pager == null)
                {
                    articles = new AW_Article_dao().funcGetArticleListByUC(this.ColumnID, this.TopCount, this.GetChild, this.Where, this.Order,this.CacheName,this.GetContent);
                }
                else
                {
                    int recordCount = 0;
                    articles = new AW_Article_dao().funcGetArticleListByUC(this.ColumnID, this.GetChild, this.Where, this.Order, this.Pager.PageID, this.Pager.PageSize, out recordCount,this.GetContent);
                    this.Pager.RecordCount = recordCount;
                }
                return articles;
            }
        }
    }
}
