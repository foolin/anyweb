using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Site_bean
	{
        private List<AW_Column_bean> _Columns;
        /// <summary>
        /// 子栏目
        /// </summary>
        public List<AW_Column_bean> Columns
        {
            get
            {
                return _Columns;
            }
            set
            {
                _Columns = value;
            }
        }

        /// <summary>
        /// 从站点缓存里面获取栏目对象
        /// </summary>
        /// <param name="list"></param>
        /// <param name="columnID"></param>
        /// <returns></returns>
        public AW_Column_bean funcGetColumnByID( List<AW_Column_bean> list, int columnID )
        {
            foreach( AW_Column_bean column in list )
            {
                if( column.fdColuID == columnID )
                    return column;
                else
                {
                    if( column.Children != null && column.Children.Count > 0 )
                    {
                        AW_Column_bean child = funcGetColumnByID( column.Children, columnID );
                        if( child != null )
                            return child;
                    }
                }
            }
            return null;
        }
	}
}
