using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;
using Studio.Web;

namespace AnyWell.AW_DL
{
	public partial class AW_Article_bean
	{
        private AW_Column_bean _Column;
        /// <summary>
        /// 所属栏目
        /// </summary>
        public AW_Column_bean Column
        {
            get
            {
                return _Column;
            }
            set
            {
                _Column = value;
            }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status
        {
            get
            {
                switch( fdArtiStatus )
                {
                    case 0:
                        return "新稿";
                    case 1:
                        return "已改";
                    case 2:
                        return "已发";
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// 内容页数
        /// </summary>
        public int PageCount
        {
            get
            {
                return WebAgent.Split( fdArtiContent, "<!-- pagebreak -->" ).Length;
            }
        }

        private string[] _Contents;
        /// <summary>
        /// 内容分段
        /// </summary>
        public string[] Contents
        {
            get
            {
                if( _Contents == null )
                {
                    if( this.PageCount == 1 )
                    {
                        _Contents = new string[] { this.fdArtiContent };
                    }
                    else
                    {
                        _Contents = WebAgent.Split( this.fdArtiContent, "<!-- pagebreak -->" );
                    }
                }
                return _Contents;
            }
        }

        /// <summary>
        /// 访问路径
        /// </summary>
        public string Url
        {
            get
            {
                return string.Format( "{0}{1}.html", Column.VirtualPath, fdArtiID );
            }
        }
	}
}
