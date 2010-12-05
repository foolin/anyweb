using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Recruit_bean
	{
        /// <summary>
        /// 访问路径
        /// </summary>
        public string fdRecrPath
        {
            get
            {
                return string.Format("/r/{0}.aspx", this.fdRecrID);
            }
        }


        private int _fdRecrCount;
        /// <summary>
        /// 简历数
        /// </summary>
        public int fdRecrCount
        {
            get{return _fdRecrCount;}
            set{_fdRecrCount = value;}
        }
			
	}
}
