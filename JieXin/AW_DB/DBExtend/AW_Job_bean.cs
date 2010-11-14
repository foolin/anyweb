using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Job_bean
	{
        private List<AW_Job_bean> _Children;
        public List<AW_Job_bean> Children
        {
            get
            {
                return _Children;
            }
            set
            {
                _Children = value;
            }
        }
	}
}
