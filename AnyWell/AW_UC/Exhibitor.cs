using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using AnyWell.AW_DL;

namespace AnyWell.AW_UC
{
    public class Exhibitor : ItemControlBase
    {
        private int _exhibitorID;
        /// <summary>
        /// 展商编号
        /// </summary>
        public int ExhibitorID
        {
            get
            {
                if( _exhibitorID == 0 )
                {
                    int.TryParse( QS( "did" ), out _exhibitorID );
                }
                return _exhibitorID;
            }
            set
            {
                _exhibitorID = value;
            }
        }

        private int _pageID = 0;
        [Description( "内容分页" ), Browsable( false )]
        public virtual int PageID
        {
            get
            {
                if( _pageID == 0 && Context.Request.QueryString[ "dpid" ] != null )
                {
                    int.TryParse( Context.Request.QueryString[ "dpid" ], out _pageID );
                }
                if( _pageID <= 0 )
                {
                    _pageID = 1;
                }
                return _pageID;
            }
            set
            {
                _pageID = value;
            }
        }

        protected override object GetItemObject()
        {
            AW_Exhibitor_bean exhibitor;

            if( this.ExhibitorID == 0 )
            {
                return "展商不存在！";
            }

            exhibitor = AW_Exhibitor_bean.funcGetByID( this.ExhibitorID );

            if( exhibitor == null )
            {
                return "展商不存在！";
            }

            if( exhibitor.PageCount > 1 )
            {
                exhibitor.fdExhiContent = exhibitor.Contents[ this.PageID - 1 ];
            }

            switch( this.ItemType )
            {
                case ItemObjectType.Next:
                    {

                        exhibitor = new AW_Exhibitor_dao().funcGetNextExhibitorByUC( exhibitor );
                        break;
                    }
                case ItemObjectType.Previous:
                    {
                        exhibitor = new AW_Exhibitor_dao().funcGetPreviousExhibitorByUC( exhibitor );
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return exhibitor;
        }
    }
}
