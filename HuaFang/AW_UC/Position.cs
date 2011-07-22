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

        string _homeText = "首页";
        [Description( "设置首页名称" ), DefaultValue( "首页" )]
        public virtual string HomeText
        {
            get
            {
                return _homeText;
            }
            set
            {
                _homeText = value;
            }
        }

        bool _hasLink = false;
        [Description( "设置尾部是否包含链接" ), DefaultValue( false )]
        public virtual bool HasLink
        {
            get
            {
                return _hasLink;
            }
            set
            {
                _hasLink = value;
            }
        }

        string GetPosition()
        {
            int cid = 0;
            int.TryParse( (string)Context.Items[ "COLUMNID" ], out cid );

            if( cid == 0 )
            {
                return string.Format( "<a href=\"/index.aspx\">{0}</a>", HomeText );
            }

            AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( cid );
            if( column == null )
            {
                return "栏目不存在！";
            }

            StringBuilder sb = new StringBuilder();
            if( HasLink )
            {
                sb.Insert( 0, string.Format( "{0}<a href=\"{1}\">{2}</a>", SplitText, column.fdColuPath, column.fdColuName ) );
            }
            else
            {
                sb.Insert( 0, string.Format( "{0}<span>{1}</span>", SplitText, column.fdColuName ) );
            }
            AW_Column_bean parent = column.Parent;
            while( parent != null )
            {
                sb.Insert( 0, string.Format( "{0}<a href=\"{1}\">{2}</a>", SplitText, parent.fdColuPath, parent.fdColuName ) );
                parent = parent.Parent;
            }
            sb.Insert( 0, string.Format( "<a href=\"/index.aspx\">{0}</a>", HomeText ) );
            return sb.ToString();
        }

        protected override void Render( HtmlTextWriter writer )
        {
            writer.Write( this.GetPosition() );
        }
    }
}
