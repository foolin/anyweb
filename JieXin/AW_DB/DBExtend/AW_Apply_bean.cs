using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Apply_bean
	{
        private AW_Resume_bean _resume;
        public AW_Resume_bean Resume
        {
            get
            {
                return _resume;
            }
            set
            {
                _resume = value;
            }
        }

        private AW_Recruit_bean _recruit;
        public AW_Recruit_bean Recruit
        {
            get
            {
                return _recruit;
            }
            set
            {
                _recruit = value;
            }
        }
	}
}
