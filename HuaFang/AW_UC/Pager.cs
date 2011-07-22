using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace AnyWell.AW_UC
{
    /// <summary>
    /// 普通分页组件,可定制显示的导航文字和样式
    /// </summary>
    public class Pager : Control, INamingContainer
    {
        /// <summary>
        /// 当前分页控件在页面中出现的顺序
        /// </summary>
        int _index = 0;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //从路径中获取当前页码
            string url = Context.Request.Url.PathAndQuery;
            if (string.IsNullOrEmpty(this.UrlFormat) == true)
            {
                this.UrlFormat = this.PageIDKey + "={0}";
            }
            string reg = "(?<=" + this.UrlFormat.Substring(0, this.UrlFormat.IndexOf("{0}")) + ")\\d+";
            if (Regex.IsMatch(url, reg))
            {
                _pageID = int.Parse(Regex.Match(url, reg).Value);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            int pagerCount = 0;
            if(Context.Items["PAGERCOUNT"] != null)
                pagerCount = (int)Context.Items["PAGERCOUNT"];
            _index = pagerCount;
            Context.Items["PAGERCOUNT"] = pagerCount++; //记录当前页面请求中创建的分页控件个数
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (Context != null)
            {
                if (this.RecordCount > 0)
                {
                    RendNavigator(writer);
                    if (_index == 0 && this.ShowGo == true) //输出Go按钮
                    {
                        writer.Write( "<script language='javascript'>function GoToPage(url,pid){if(pid.search(/^[0-9]+$/)==-1){alert(\"页码格式错误，只能输入数字类型！\");return;}if(pid<1)pid=1;if(pid>" + PageCount + ")pid=" + PageCount + "; document.location = url.replace('_pid', pid).replace('_1.','.');}</script>" );
                    }
                }
            }
            else
            {
                writer.Write("");
            }
        }

        protected virtual void RendNavigator(HtmlTextWriter writer)
        {
            if (this.RecordCount > this.PageSize)
            {
                switch (this.StyleID)
                {
                    case 1:
                        {
                            RendNavigator1( writer );
                            break;
                        }
                    case 5:
                        {
                            RendNavigator5( writer );
                            break;
                        }
                    case 6:
                        {
                            RendNavigator6( writer );
                            break;
                        }
                    default:
                        {
                            RendNavigator1(writer);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// 获取某一页的Url路径
        /// </summary>
        /// <param name="pageID"></param>
        /// <returns></returns>
        protected virtual string GetPageUrl(int pageID)
        {
            if (pageID == 1)
            {
                return this.UrlPrefix.Replace("__pid", "").Replace("_pid", "1");//第一页不显示_1
            }
            else
            {
                return this.UrlPrefix.Replace("_pid", pageID.ToString());
            }
        }

        /// <summary>
        /// 显示第1种样式
        /// </summary>
        /// <param name="writer"></param>
        protected virtual void RendNavigator1(HtmlTextWriter writer)
        {
            int begin, end, pages = this.PageCount;

            writer.Write("<div id=\"pager{0}\">", _index + 1);
            if (string.IsNullOrEmpty(this.SummaryText) == false)
            {
                writer.Write("<span class='summary'>{0}</span>", this.SummaryText.Replace("[n]", this.RecordCount.ToString()).Replace("[c]", this.PageID.ToString()).Replace("[t]", this.PageCount.ToString()));
            }
            writer.Write("<span class='pages'>");
            writer.Write("<a {0}>{1}</a>", PageID > 1 ? String.Format("href='{0}' title='{1}'", GetPageUrl(1), this.GoTip.Replace("[n]", "1")) : "disabled", this.FirstPageText);
            writer.Write("<a {0}>{1}</a>", PageID > 1 ? String.Format("href='{0}' title='{1}'", GetPageUrl(PageID - 1), this.GoTip.Replace("[n]", (PageID - 1).ToString())) : "disabled", this.PrePageText);

            if (pages > this.SplitSize)
            {
                if (PageID % this.SplitSize == 0)
                {
                    begin = PageID - this.SplitSize + 1;
                    end = PageID;
                }
                else
                {
                    begin = PageID / this.SplitSize * this.SplitSize + 1;
                    end = PageID / this.SplitSize * this.SplitSize + this.SplitSize;
                }

                if (end > pages)
                {
                    end = pages;
                }

                if (PageID > this.SplitSize)
                {
                    writer.Write("<a href='{0}' title='{1}'>...</a>", GetPageUrl(begin - 1), this.GoTip.Replace("[n]", (begin - 1).ToString()));
                }
            }
            else
            {
                begin = 1;
                end = pages;
            }

            for (int i = begin; i <= end; i++)
            {
                if (i == PageID)
                    writer.Write("<font color='red'><strong>{0}</strong></font>", i);
                else
                    writer.Write("<a href='{0}' title='{1}'>{2}</a>", GetPageUrl(i),this.GoTip.Replace("[n]", i.ToString()), i);
            }

            if (pages > end)
            {
                writer.Write("<a href='{0}' title='{1}'>...</a>", GetPageUrl(end + 1), this.GoTip.Replace("[n]", (end + 1).ToString()));
            }

            writer.Write("<a {0}>{1}</a>", PageID < pages ? String.Format("href='{0}' title='{1}'", GetPageUrl(PageID + 1), this.GoTip.Replace("[n]", (PageID + 1).ToString())) : "disabled", this.NextPageText);
            writer.Write("<a {0}>{1}</a>", PageID < pages ? String.Format("href='{0}' title='{1}'", GetPageUrl(pages), this.GoTip.Replace("[n]", pages.ToString())) : "disabled", this.LastPageText);

            if (this.ShowGo == true)
            {
                writer.Write("<span><input type='text' value='{0}' style='width:25px'><input type='button' value='Go' onclick='javascript:GoToPage(\"" + _urlPrefix + "\", this.previousSibling.value);'></span>", PageID);
            }
            writer.Write("</span>");
            writer.Write("</div>");
        }

        void RendNavigator5( HtmlTextWriter writer )
        {
            int begin, end, pages = PageCount;

            writer.Write( "<a {0}>&lt;</a>", PageID > 1 ? String.Format( "href='{0}' title='上一页'", GetPageUrl( PageID - 1 ) ) : "disabled" );
            if( PageCount > 9 )
            {
                if( PageID - 4 >= 1 && PageID + 4 <= PageCount )
                {
                    begin = PageID - 4;
                    end = PageID + 4;
                }
                else if( PageID - 4 <= 0 )
                {
                    begin = 1;
                    end = 9;
                }
                else
                {
                    end = PageID + 4 > PageCount ? PageCount : PageID + 4;
                    begin = end - 8;
                }
            }
            else
            {
                begin = 1;
                end = pages;
            }

            for( int i = begin; i <= end; i++ )
            {
                if( i == PageID )
                    writer.Write( "<a href=\"{0}\" class=\"cur\">{1}</a>", GetPageUrl( i ), i );
                else
                    writer.Write( "<a href=\"{0}\">{1}</a>", GetPageUrl( i ), i );
            }
            writer.Write( "<a {0}>&gt;</a>", PageID < pages ? String.Format( "href='{0}' title='下一页'", GetPageUrl( PageID + 1 ) ) : "disabled" );
        }

        void RendNavigator6( HtmlTextWriter writer )
        {
            int pages = PageCount;

            writer.Write( "<a class=\"Pagination_L\" {0}></a>", PageID > 1 ? String.Format( "href='{0}' title='上一页'", GetPageUrl( PageID - 1 ) ) : "disabled" );
            writer.Write( "<a class=\"Pagination_R\" {0}></a>", PageID < pages ? String.Format( "href='{0}' title='下一页'", GetPageUrl( PageID + 1 ) ) : "disabled" );
            writer.Write( "<span>共{0}页</span><span class=\"Pagination-nopa\">/</span>", pages );
            writer.Write( "<span class=\"Pagination-nopa\">第<input type=\"text\" class=\"ipt-simple\" value=\"{0}\">页</span><button class=\"btn-simple btn-simple2\" onclick=\"javascript:GoToPage('" + UrlPrefix + "' , this.parentNode.children[4].children[0].value);\">GO</button>", PageID );
        }

        #region Attributes
        string _pageIDKey = "pid";
        /// <summary>
        /// 获取或设置分页参数
        /// </summary>
        [Description("分页标记(url参数)"), DefaultValue("pid")]
        public virtual string PageIDKey
        {
            get { return _pageIDKey; }
            set { if (value != null)_pageIDKey = value; }
        }

        private int _pageID = 1;
        /// <summary>
        /// 获取当前页码
        /// </summary>
        [Description("当前页码"), DefaultValue(1)]
        public virtual int PageID
        {
            get { return _pageID; }
        }

        private string _urlFormat;
        /// <summary>
        /// 获取或设置页面Url格式
        /// </summary>
        [Description("URL格式")]
        public virtual string UrlFormat
        {
            get {
                if (string.IsNullOrEmpty(_urlFormat) && Context != null && string.IsNullOrEmpty(Context.Request.QueryString["urlformat"]) == false)
                {
                    _urlFormat = Context.Request.QueryString["urlformat"];
                }
                return _urlFormat; 
            }
            set { _urlFormat = value; }
        }

        private int _recordCount;
        /// <summary>
        /// 获取或设置总记录数
        /// </summary>
        [Description("总记录数")]
        public virtual int RecordCount
        {
            get { return _recordCount; }
            set { _recordCount = value; }
        }

        /// <summary>
        /// 获取或设置每页记录数
        /// </summary>
        int _pageSize = 20;
        [Description("每页记录数"), DefaultValue(20)]
        public virtual int PageSize
        {
            get { return _pageSize; }
            set { if (value > 0 && value <= 50001)_pageSize = value; }
        }

        /// <summary>
        /// 获取或设置页码分组时每组页码数
        /// </summary>
        int _splitSize = 10;
        [Description("页码分组时每组页码数"), DefaultValue(10)]
        public virtual int SplitSize
        {
            get { return _splitSize; }
            set { _splitSize = value; }
        }

        private bool _showGo = true;
        /// <summary>
        /// 获取或设置是否显示Go按钮
        /// </summary>
        [Description("是否显示Go按钮"), DefaultValue(true)]
        public virtual bool ShowGo
        {
            get { return _showGo; }
            set { _showGo = value; }
        }

        private string _goTip = "转到第[n]页";
        /// <summary>
        /// 获取或设置页面跳转提示
        /// </summary>
        [Description("页面跳转提示"), DefaultValue("转到第[n]页")]
        public virtual string GoTip
        {
            get { return _goTip; }
            set { _goTip = value; }
        }

        private string _summaryText = "共[n]条记录,当前显示第[c]页,共[t]页";
        /// <summary>
        /// 获取或设置记录汇总文本
        /// </summary>
        [Description("记录汇总文本"), DefaultValue("共[n]条记录,当前显示第[c]页,共[t]页")]
        public virtual string SummaryText
        {
            get { return _summaryText; }
            set { _summaryText = value; }
        }

        private string _prePageText = "前一页";
        /// <summary>
        /// 获取或设置“前一页”显示文本
        /// </summary>
        [Description("记录前一页显示文本"), DefaultValue("前一页")]
        public virtual string PrePageText
        {
            get { return _prePageText; }
            set { _prePageText = value; }
        }

        private string _nextPageText = "后一页";
        /// <summary>
        /// 获取或设置“后一页”显示文本
        /// </summary>
        [Description("记录后一页显示文本"), DefaultValue("后一页")]
        public virtual string NextPageText
        {
            get { return _nextPageText; }
            set { _nextPageText = value; }
        }

        private string _firstPageText = "首页";
        /// <summary>
        /// 获取或设置“首页”显示文本
        /// </summary>
        [Description("记录首页显示文本"), DefaultValue("首页")]
        public virtual string FirstPageText
        {
            get { return _firstPageText; }
            set { _firstPageText = value; }
        }
        private string _lastPageText = "末页";
        /// <summary>
        /// 获取或设置“末页”显示文本
        /// </summary>
        [Description("记录末页显示文本"), DefaultValue("末页")]
        public virtual string LastPageText
        {
            get { return _lastPageText; }
            set { _lastPageText = value; }
        }

        private int _pageCount;
        /// <summary>
        /// 获取总页数
        /// </summary>
        [Browsable(false)]
        public virtual int PageCount
        {
            get
            {
                if (_pageCount == 0 && this.RecordCount > 0)
                {
                    _pageCount = Convert.ToInt32(Math.Ceiling(this.RecordCount * 1.0 / this.PageSize));
                    if (_pageCount == 0) _pageCount = 1;
                }
                return _pageCount;
            }
        }

        private string _urlPrefix;
        /// <summary>
        /// 获取替换页码后的Url格式
        /// </summary>
        [Browsable(false)]
        public virtual string UrlPrefix
        {
            get
            {
                if (string.IsNullOrEmpty(_urlPrefix) && Context != null && string.IsNullOrEmpty(Context.Request.QueryString["urlprefix"]) == false)
                {
                    _urlPrefix = Context.Request.QueryString["urlprefix"];
                }

                if (string.IsNullOrEmpty(_urlPrefix))
                {
                    string query = Context.Request.QueryString.ToString();
                    if (string.IsNullOrEmpty(this.UrlFormat) == true)
                    {
                        this.UrlFormat = this.PageIDKey + "={0}";
                    }
                    string reg = "(?<=" + this.UrlFormat.Substring(0, this.UrlFormat.IndexOf("{0}")) + ")\\d+";

                    if (Regex.IsMatch(query, reg))
                    {
                        _urlPrefix = "?" + Regex.Replace(query, reg, "_pid");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(query) == false)
                        {
                            _urlPrefix = "?" + query + '&' + this.PageIDKey + "=_pid";
                        }
                        else
                        {
                            _urlPrefix = "?" + this.PageIDKey + "=_pid";
                        }
                    }
                }
                return _urlPrefix;
            }
            set
            {
                _urlPrefix = value;
            }
        }

        /// <summary>
        /// 获取或设置样式编号
        /// </summary>
        int _styleID = 1;
        [Description("样式编号"), DefaultValue(2)]
        public virtual int StyleID
        {
            get
            {
                return _styleID;
            }
            set { _styleID = value; }
        }
        #endregion
    }
}
