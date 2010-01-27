using System;
using System.Collections.Generic;
using System.Web;

namespace AnyWeb.AW_DL
{
    public partial class AW_Article_bean
    {
        private AW_Column_bean _Column;

        public AW_Column_bean Column
        {
            get { return _Column; }
            set { _Column = value; }
        }
    }
}