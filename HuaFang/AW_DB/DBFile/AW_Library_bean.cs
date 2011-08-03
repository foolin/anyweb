using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
    public partial class AW_Library_bean : Bean_Base
    {
        private int _fdLibrID = 0;
        /// <summary>
        /// 编号
        /// </summary>
        public int fdLibrID
        {
            get { return _fdLibrID; }
            set { _fdLibrID = value; }
        }
        private int _fdLibrType = 0;
        /// <summary>
        /// 类别(1名人 2品牌)
        /// </summary>
        public int fdLibrType
        {
            get { return _fdLibrType; }
            set { _fdLibrType = value; }
        }
        private string _fdLibrName = "";
        /// <summary>
        /// 名称 nvarchar(100)
        /// </summary>
        public string fdLibrName
        {
            get { return _fdLibrName; }
            set { _fdLibrName = value; }
        }
        private string _fdLibrEnName = "";
        /// <summary>
        /// 英文名称 nvarchar(100)
        /// </summary>
        public string fdLibrEnName
        {
            get { return _fdLibrEnName; }
            set { _fdLibrEnName = value; }
        }
        private string _fdLibrPic = "";
        /// <summary>
        /// 图片 varchar(100)
        /// </summary>
        public string fdLibrPic
        {
            get{return _fdLibrPic;}
            set{_fdLibrPic = value;}
        }
        private int _fdLibrFirLetter = 0;
        /// <summary>
        /// 首字母
        /// </summary>
        public int fdLibrFirLetter
        {
            get { return _fdLibrFirLetter; }
            set { _fdLibrFirLetter = value; }
        }
        private string _fdLibrDesc = "";
        /// <summary>
        /// 介绍
        /// </summary>
        public string fdLibrDesc
        {
            get { return _fdLibrDesc; }
            set { _fdLibrDesc = value; }
        }
        private int _fdLibrSort = 0;
        /// <summary>
        /// 排序
        /// </summary>
        public int fdLibrSort
        {
            get { return _fdLibrSort; }
            set { _fdLibrSort = value; }
        }


        /////////////////////////////////////////

        Dao_Base _dao = null;
        protected override Dao_Base dao
        {
            get
            {
                if (_dao == null)
                {
                    _dao = new AW_Library_dao();
                }
                return _dao;
            }
        }

        public static AW_Library_bean funcGetByID(string id)
        {
            AW_Library_bean bean = new AW_Library_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Library_bean funcGetByID(int id)
        {
            AW_Library_bean bean = new AW_Library_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Library_bean funcGetByID(string id, string columns)
        {
            AW_Library_bean bean = new AW_Library_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Library_bean funcGetByID(int id, string columns)
        {
            AW_Library_bean bean = new AW_Library_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
        /////////////////////////////////////////
    }
}
