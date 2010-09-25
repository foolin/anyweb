using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
    public partial class AW_ADManage_bean : Bean_Base
    {
        private int _fdAdManageID = 0;
        /// <summary>
        /// 广告编号
        /// </summary>
        public int fdAdManageID
        {
            get { return _fdAdManageID; }
            set { _fdAdManageID = value; }
        }
        private string _fdAdManageName = "";
        /// <summary>
        /// 广告名称 100 nvarchar
        /// </summary>
        public string fdAdManageName
        {
            get { return _fdAdManageName; }
            set { _fdAdManageName = value; }
        }
        private string _fdAdManagePic = "";
        /// <summary>
        /// 广告图片 200 varchar
        /// </summary>
        public string fdAdManagePic
        {
            get { return _fdAdManagePic; }
            set { _fdAdManagePic = value; }
        }
        private string _fdAdManageLink = "";
        /// <summary>
        /// 广告链接 200 varchar
        /// </summary>
        public string fdAdManageLink
        {
            get { return _fdAdManageLink; }
            set { _fdAdManageLink = value; }
        }
        private int _fdAdManageType = 0;
        /// <summary>
        /// 广告类型(6企业介绍7动态标语8移动广告)
        /// </summary>
        public int fdAdManageType
        {
            get { return _fdAdManageType; }
            set { _fdAdManageType = value; }
        }
        private int _fdAdManageSort = 0;
        /// <summary>
        /// 排序
        /// </summary>
        public int fdAdManageSort
        {
            get { return _fdAdManageSort; }
            set { _fdAdManageSort = value; }
        }


        /////////////////////////////////////////

        Dao_Base _dao = null;
        protected override Dao_Base dao
        {
            get
            {
                if (_dao == null)
                {
                    _dao = new AW_ADManage_dao();
                }
                return _dao;
            }
        }

        public static AW_ADManage_bean funcGetByID(string id)
        {
            AW_ADManage_bean bean = new AW_ADManage_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_ADManage_bean funcGetByID(int id)
        {
            AW_ADManage_bean bean = new AW_ADManage_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_ADManage_bean funcGetByID(string id, string columns)
        {
            AW_ADManage_bean bean = new AW_ADManage_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_ADManage_bean funcGetByID(int id, string columns)
        {
            AW_ADManage_bean bean = new AW_ADManage_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
        /////////////////////////////////////////

    }//
}//
