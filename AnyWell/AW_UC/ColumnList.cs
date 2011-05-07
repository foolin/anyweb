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
        public int _siteID;
        /// <summary>
        /// 站点编号
        /// </summary>
        public int SiteID
        {
            get
            {
                int.TryParse( QS( "sid" ), out _siteID );
                return _siteID;
            }
            set
            {
                _siteID = value;
            }
        }
        public int _columnID;
        /// <summary>
        /// 栏目编号
        /// </summary>
        public int ColumnID
        {
            get
            {
                if( _columnID != -1 && _columnID == 0 )
                {
                    int.TryParse( QS( "cid" ), out _columnID );
                }
                return _columnID;
            }
            set
            {
                _columnID = value;
            }
        }

        private bool _getParent = false;
        /// <summary>
        /// 获取或设置是否返回同级栏目
        /// </summary>
        [Description( "设置是否返回同级栏目" )]
        public bool GetParent
        {
            get
            {
                return _getParent;
            }
            set
            {
                _getParent = value;
            }
        }

        protected override object GetDataObject()
        {
            AW_Site_bean site;
            AW_Column_bean column;
            if( SiteID == 0 )
            {
                return "站点不存在！";
            }
            site = new AW_Site_dao().funcGetSiteInfo( SiteID );
            if( site == null )
            {
                return "站点不存在！";
            }
            if( this.ColumnID == 0 )
            {
                return "栏目不存在！";
            }

            if( this.ColumnID != -1 )
            {
                column = new AW_Column_dao().funcGetColumnInfo( ColumnID );
                if( column == null )
                {
                    return "栏目不存在！";
                }
                if( GetParent )
                {
                    return column.Parent == null ? site.Columns : column.Parent.Children;
                }
                else
                {
                    return column.Children;
                }
            }
            else
            {
                return site.Columns;
            }
        }
    }
}
