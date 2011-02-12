using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Data;
using Studio.Web;

namespace AnyWell.AW_DL
{
	public partial class AW_Admin_bean
	{
        /// <summary>
        /// 用户级别
        /// </summary>
        public AdminLevel Level
        {
            get
            {
                return (AdminLevel)this.fdAdmiLevel;
            }
            set 
            {
                this.fdAdmiLevel = (int)value;
            }
        }


        private List<int> _purviews;
        /// <summary>
        /// 权限
        /// </summary>
        public List<int> Purviews
        {
            get 
            { 
                return _purviews; 
            }
        }

        /// <summary>
        /// 设置权限
        /// </summary>
        public void funcSetPurviews()
        {
            if (this.Level == AdminLevel.Administrator)
            {
                _purviews = null;
            }
            else
            {
                _purviews = new List<int>();
                foreach(string key in this.fdAdmiPurview.Split(new string[1]{","}, StringSplitOptions.RemoveEmptyEntries))
                {
                    if(WebAgent.IsInt32(key))
                        _purviews.Add(int.Parse(key));
                }
            }
        }
	}

    public enum AdminLevel : int
    {
        Administrator = 1,
        Normal = 2
    }
}
