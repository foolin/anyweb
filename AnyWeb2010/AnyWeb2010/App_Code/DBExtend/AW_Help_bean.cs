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
	public partial class AW_Help_bean
	{
        private string _fdTypeName;

        public string fdTypeName
        {
            get { return _fdTypeName; }
            set { _fdTypeName = value; }
        }
	}
}
