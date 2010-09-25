using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
    public partial class AW_ScrollAD_bean : Bean_Base
    {
        private int _fdScrollAdID = 0;
        /// <summary>
        /// 广告编号
        /// </summary>
        public int fdScrollAdID
        {
            get { return _fdScrollAdID; }
            set { _fdScrollAdID = value; }
        }
        private string _fdScrollAdName = "";
        /// <summary>
        /// 广告名称 100 nvarchar
        /// </summary>
        public string fdScrollAdName
        {
            get { return _fdScrollAdName; }
            set { _fdScrollAdName = value; }
        }
        private string _fdScrollAdPic = "";
        /// <summary>
        /// 广告图片 200 varchar
        /// </summary>
        public string fdScrollAdPic
        {
            get { return _fdScrollAdPic; }
            set { _fdScrollAdPic = value; }
        }
        private string _fdScrollAdLink = "";
        /// <summary>
        /// 广告链接 200 varchar
        /// </summary>
        public string fdScrollAdLink
        {
            get { return _fdScrollAdLink; }
            set { _fdScrollAdLink = value; }
        }
        private int _fdScrollAdType = 0;
        /// <summary>
        /// 广告类型(4合作院校5专题图片)
        /// </summary>
        public int fdScrollAdType
        {
            get { return _fdScrollAdType; }
            set { _fdScrollAdType = value; }
        }
        private int _fdScrollAdSort = 0;
        /// <summary>
        /// 排序
        /// </summary>
        public int fdScrollAdSort
        {
            get { return _fdScrollAdSort; }
            set { _fdScrollAdSort = value; }
        }


        /////////////////////////////////////////

        Dao_Base _dao = null;
        protected override Dao_Base dao
        {
            get
            {
                if (_dao == null)
                {
                    _dao = new AW_ScrollAD_dao();
                }
                return _dao;
            }
        }

        public static AW_ScrollAD_bean funcGetByID(string id)
        {
            AW_ScrollAD_bean bean = new AW_ScrollAD_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_ScrollAD_bean funcGetByID(int id)
        {
            AW_ScrollAD_bean bean = new AW_ScrollAD_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_ScrollAD_bean funcGetByID(string id, string columns)
        {
            AW_ScrollAD_bean bean = new AW_ScrollAD_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_ScrollAD_bean funcGetByID(int id, string columns)
        {
            AW_ScrollAD_bean bean = new AW_ScrollAD_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
        /////////////////////////////////////////

    }//
}//
