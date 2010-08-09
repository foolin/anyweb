using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.ComponentModel;
using Studio.Web;
using AnyWeb.AW_DL;

namespace AnyWeb.AW_UC
{
    /// <summary>
    /// 普通分页组件,可定制显示的导航文字和样式
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

        [Browsable(false)]
        public override int PageSize
        {
            get
            {
                return 1;
            }
        }

        [Browsable(false)]
        public override int RecordCount
        {
            get
            {
                int did = 0, pageCount = 1;
                //int.TryParse(Context.Request.QueryString["did"], out did);
                //if (did > 0)
                //{
                    object result = new AW_Article_dao().funcGetField(1031, "fdArtiContent");
                    if (result != null && result != DBNull.Value)
                    {
                        pageCount = WebAgent.Split(result.ToString(), "<!-- pagebreak -->").Length;
                    }
                //}
                return pageCount;
            }
        }
    }
}
