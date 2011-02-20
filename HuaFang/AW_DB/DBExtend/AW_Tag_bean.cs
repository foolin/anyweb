using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Tag_bean
	{
        private int _fdArtiCount = 0;
        /// <summary>
        /// 关联文章数
        /// </summary>
        public int fdArtiCount
        {
            get{return _fdArtiCount;}
            set{_fdArtiCount = value;}
        }

        private int _fdGoodCount = 0;
        /// <summary>
        /// 关联产品数
        /// </summary>
        public int fdGoodCount
        {
            get{ return _fdGoodCount; }
            set{ _fdGoodCount = value;}
        }
	}
}
