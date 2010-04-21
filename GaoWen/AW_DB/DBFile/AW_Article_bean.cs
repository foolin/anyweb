using System;
using System.Collections.Generic;
using System.Web;

namespace AnyWeb.AW_DL
{
    public partial class AW_Article_bean : Bean_Base
    {
        private int _fdArtiID = 0;
        /// <summary>
        /// 文章编号
        /// </summary>
        public int fdArtiID
        {
            get { return _fdArtiID; }
            set { _fdArtiID = value; }
        }

        private int _fdArtiColumnID = 0;
        /// <summary>
        /// 所属栏目编号
        /// </summary>
        public int fdArtiColumnID
        {
            get { return _fdArtiColumnID; }
            set { _fdArtiColumnID = value; }
        }

        private string _fdArtiTitle = "";
        /// <summary>
        /// 文章标题 200 nvarchar
        /// </summary>
        public string fdArtiTitle
        {
            get { return _fdArtiTitle; }
            set { _fdArtiTitle = value; }
        }

        private string _fdArtiContent = "";
        /// <summary>
        /// 文章内容 16 ntext
        /// </summary>
        public string fdArtiContent
        {
            get { return _fdArtiContent; }
            set { _fdArtiContent = value; }
        }

        private DateTime _fdArtiCreateAt = DateTime.Now;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime fdArtiCreateAt
        {
            get { return _fdArtiCreateAt; }
            set { _fdArtiCreateAt = value; }
        }

        private int _fdArtiSort = 0;
        /// <summary>
        /// 文章排序
        /// </summary>
        public int fdArtiSort
        {
            get { return _fdArtiSort; }
            set { _fdArtiSort = value; }
        }


        /////////////////////////////////////////

        Dao_Base _dao = null;
        protected override Dao_Base dao
        {
            get
            {
                if (_dao == null)
                {
                    _dao = new AW_Article_dao();
                }
                return _dao;
            }
        }

        public static AW_Article_bean funcGetByID(string id)
        {
            AW_Article_bean bean = new AW_Article_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Article_bean funcGetByID(int id)
        {
            AW_Article_bean bean = new AW_Article_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Article_bean funcGetByID(string id, string columns)
        {
            AW_Article_bean bean = new AW_Article_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Article_bean funcGetByID(int id, string columns)
        {
            AW_Article_bean bean = new AW_Article_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
    }
}