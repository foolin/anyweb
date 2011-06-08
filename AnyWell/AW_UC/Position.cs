using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using AnyWell.AW_DL;

namespace AnyWell.AW_UC
{
    public class Position : Control, INamingContainer
    {
        /// <summary>
        /// 获取或设置分隔符
        /// </summary>
        string _splitText = "&gt;";
        [Description( "设置分隔符" ), DefaultValue( "&gt;" )]
        public virtual string SplitText
        {
            get
            {
                return _splitText;
            }
            set
            {
                _splitText = value;
            }
        }

        string GetPosition()
        {
            int cid = 0;
            int.TryParse( Context.Request.QueryString[ "cid" ], out cid );

            if( cid == 0 )
            {
                return "<a href=\"/index.html\">首页</a>";
            }

            AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( cid );
            if( column == null )
            {
                return "栏目不存在！";
            }

            StringBuilder sb = new StringBuilder();
            sb.Insert( 0, string.Format( "{0}<a href=\"{1}\">{2}</a>", SplitText, column.Url, column.fdColuName ) );
            AW_Column_bean parent = column.Parent;
            while( parent != null )
            {
                sb.Insert( 0, string.Format( "{0}<a href=\"{1}\">{2}</a>", SplitText, parent.Url, parent.fdColuName ) );
                parent = parent.Parent;
            }
            sb.Insert( 0, "<a href=\"/index.html\">首页</a>" );
            return sb.ToString();
        }

        protected override void Render( HtmlTextWriter writer )
        {
            writer.Write( this.GetPosition() );
        }
    }
}
