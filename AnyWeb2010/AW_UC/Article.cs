using System;
using System.Collections.Generic;
using System.Web;
using FortuneAge.AW_UC;
using System.ComponentModel;
using AnyWeb.AW_DL;
using Studio.Web;

namespace AnyWeb.AW_UC
{
    /// <summary>
    /// 单个文章组件，可展示单一篇文章的某个属性或一组属性，同时添加ArticlePager置标可实现内容分页
    /// </summary>
    public class Article : ItemControlBase
    {
        private int _pageID = 0;
        [Description("内容分页"), Browsable(false)]
        public virtual int PageID
        {
            get
            {
                if (_pageID == 0 && Context.Request.QueryString["dpid"] != null)
                {
                    int.TryParse(Context.Request.QueryString["dpid"], out _pageID);
                }
                if (_pageID <= 0)
                {
                    _pageID = 1;
                }
                return _pageID;
            }
            set { _pageID = value; }
        }


        protected override object GetItemObject()
        {
            switch (this.ItemType)
            {
                case ItemObjectType.Next:
                    {

                        return new AW_Article_dao().funcGetNextArticle(this.RecID);
                    }
                case ItemObjectType.Previous:
                    {
                        return new AW_Article_dao().funcGetPreviousArticle(this.RecID);
                    }
                default:
                    {
                        break;
                    }
            }

            AW_Article_bean article = AW_Article_bean.funcGetByID(this.RecID);
            if (article == null)
            {
                return null;
            }
            string[] Content = WebAgent.Split(article.fdArtiContent, "<!-- pagebreak -->");
            if (Content.Length > 1)
            {
                article.fdArtiContent = Content[this.PageID - 1];
            }

            return article;
        }
    }
}
