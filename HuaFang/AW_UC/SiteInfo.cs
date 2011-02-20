using System;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;

namespace AnyWell.AW_UC
{
    public class SiteInfo : ItemControlBase
    {
        public int _siteInfoID;
        /// <summary>
        /// 栏目编号
        /// </summary>
        public int SiteInfoID
        {
            get
            {
                if( !HasInit )
                {
                    if( this._siteInfoID == 0 )
                    {
                        int.TryParse( this.ContextItem( "SITEINFOID" ), out this._siteInfoID );
                    }
                    HasInit = true;
                }
                return this._siteInfoID;
            }
            set
            {
                _siteInfoID = value;
            }
        }

        protected override object GetItemObject()
        {
            AW_SiteInfo_bean bean;

            if( this.SiteInfoID == 0 )
            {
                goErrorPage();

            }

            //从上下文中读取信息，如果该信息存在的话
            if( HttpContext.Current.Items[ "SITEINFO_" + this.SiteInfoID ] != null )
            {
                bean = ( AW_SiteInfo_bean ) HttpContext.Current.Items[ "SITEINFO_" + this.SiteInfoID ];
            }
            else
            {
                bean = AW_SiteInfo_bean.funcGetByID( this.SiteInfoID );
                HttpContext.Current.Items.Add( "SITEINFO_" + this.SiteInfoID, bean );
            }
            if( bean == null )
            {
                goErrorPage();
            }

            return bean;
        }
    }
}
