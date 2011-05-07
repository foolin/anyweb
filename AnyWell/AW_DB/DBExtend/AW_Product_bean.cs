using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Product_bean
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
	}
}
