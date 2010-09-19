using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Article_bean
	{
        private AW_Column_bean _Column;
        public AW_Column_bean Column
        {
            get { return _Column; }
            set { _Column = value; }
        }

        public string fdArtiPath
        {
            get 
            {
                return string.Format("/a/{0}.aspx", this.fdArtiID);
            }
        }
	}
}
