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
	public partial class AW_SingleArticle_bean
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
        /// 内容页数
        /// </summary>
        public int PageCount
        {
            get
            {
                return WebAgent.Split( fdSingContent, "<!-- pagebreak -->" ).Length;
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
                        _Contents = new string[] { this.fdSingContent };
                    }
                    else
                    {
                        _Contents = WebAgent.Split( this.fdSingContent, "<!-- pagebreak -->" );
                    }
                }
                return _Contents;
            }
        }
	}
}
