using System;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;

namespace AnyWell.AW_UC
{
    public class Column : ItemControlBase
    {
        public int _columnID;
        /// <summary>
        /// 栏目编号
        /// </summary>
        public int ColumnID
        {
            get
            {
                if( _columnID == 0 )
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

        protected override object GetItemObject()
        {
            AW_Column_bean bean;

            if( this.ColumnID == 0 )
            {
                return "栏目不存在！";
            }

            bean = new AW_Column_dao().funcGetColumnInfo( this.ColumnID );

            if( bean == null )
            {
                return "栏目不存在！";
            }

            return bean;
        }
    }
}
