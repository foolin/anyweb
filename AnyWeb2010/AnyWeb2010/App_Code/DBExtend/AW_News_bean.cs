using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWeb.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_News_bean
	{
        private AW_News_Column_bean _Column;

        public AW_News_Column_bean Column
        {
            get { return _Column; }
            set { _Column = value; }
        }

	}
}
