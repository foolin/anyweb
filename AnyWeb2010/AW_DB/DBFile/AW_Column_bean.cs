using System;
using System.Collections.Generic;
using System.Web;

namespace AnyWeb.AW_DL
{
    public partial class AW_Column_bean : Bean_Base
    {
        private int _fdColuID = 0;
        /// <summary>
        /// 栏目编号
        /// </summary>
        public int fdColuID
        {
            get { return _fdColuID; }
            set { _fdColuID = value; }
        }

        private string _fdColuName = "";
        /// <summary>
        /// 栏目名称 200 nvarchar
        /// </summary>
        public string fdColuName
        {
            get { return _fdColuName; }
            set { _fdColuName = value; }
        }

        private int _fdColuSort = 0;
        /// <summary>
        /// 栏目排序
        /// </summary>
        public int fdColuSort
        {
            get { return _fdColuSort; }
            set { _fdColuSort = value; }
        }

        private string _fdColuDescription = "";
        /// <summary>
        /// 栏目描述 400 nvarchar
        /// </summary>
        public string fdColuDescription
        {
            get { return _fdColuDescription; }
            set { _fdColuDescription = value; }
        }

        private string _fdColuPicture = "";
        /// <summary>
        /// 栏目图片 100 varchar
        /// </summary>
        public string fdColuPicture
        {
            get { return _fdColuPicture; }
            set { _fdColuPicture = value; }
        }

        private int _fdColuParentID;
        /// <summary>
        /// 父级栏目编号
        /// </summary>
        public int fdColuParentID
        {
            get { return _fdColuParentID; }
            set { _fdColuParentID = value; }
        }

        private int _fdColuShowIndex = 1;
        /// <summary>
        /// 是否在首页显示
        /// </summary>
        public int fdColuShowIndex
        {
            get { return _fdColuShowIndex; }
            set { _fdColuShowIndex = value; }
        }

        private int _fdColuTempIndex = 0;
        /// <summary>
        /// 首页模版
        /// </summary>
        public int fdColuTempIndex
        {
            get { return _fdColuTempIndex; }
            set { _fdColuTempIndex = value; }
        }

        private int _fdColuTempContent;
        /// <summary>
        /// 内容模版
        /// </summary>
        public int fdColuTempContent
        {
            get { return _fdColuTempContent; }
            set { _fdColuTempContent = value; }
        }



        /////////////////////////////////////////

        Dao_Base _dao = null;
        protected override Dao_Base dao
        {
            get
            {
                if (_dao == null)
                {
                    _dao = new AW_Column_dao();
                }
                return _dao;
            }
        }

        public static AW_Column_bean funcGetByID(string id)
        {
            AW_Column_bean bean = new AW_Column_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Column_bean funcGetByID(int id)
        {
            AW_Column_bean bean = new AW_Column_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Column_bean funcGetByID(string id, string columns)
        {
            AW_Column_bean bean = new AW_Column_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Column_bean funcGetByID(int id, string columns)
        {
            AW_Column_bean bean = new AW_Column_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
    }
}
