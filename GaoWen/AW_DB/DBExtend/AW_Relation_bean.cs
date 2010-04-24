using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_Relation_bean
	{
        private AW_Column_bean _column;
        public AW_Column_bean Column
        {
            get { return _column; }
            set { _column = value; }
        }
	}
}
