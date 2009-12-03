using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    /// <summary>
    /// 用户组件实体
    /// </summary>
    public class UserWidget:IdObject
    {
        public UserWidget() { }

        public UserWidget(DataRow dr)
        {
            this.ID = (int)dr["UserWidgetID"];
            this._widgetID = (int)dr["WidgetID"];
            this._sort = (int)dr["Sort"];
            this._name = (string)dr["Name"];
            this._dataID = (int)dr["DataID"];
            this._createAt = (DateTime)dr["CreateAt"];
            this._shopID = (int)dr["ShopID"];
        }

        private int _widgetID;
        /// <summary>
        /// 所属组件
        /// </summary>
        public int WidgetID
        {
            get { return _widgetID; }
            set { _widgetID = value; }
        }

        private string _name;
        /// <summary>
        /// 组件名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private DateTime _createAt;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }

        private int _sort;
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }

        private int _dataID;
        /// <summary>
        /// 数据源编号(文章栏目组件则保存文章栏目编号)
        /// </summary>
        public int DataID
        {
            get { return _dataID; }
            set { _dataID = value; }
        }

        private int _shopID;
        /// <summary>
        /// 商店编号
        /// </summary>
        public int ShopID
        {
            get { return _shopID; }
            set { _shopID = value; }
        }

        private Widget _ofWidget;

        public Widget OfWidget
        {
            get { return _ofWidget; }
            set { _ofWidget = value; }
        }


        public string Value
        {
            get
            {
                return string.Format( "{0}|{1}|{2}" , this.WidgetID , this.Name , this.DataID );
            }
        }
    }
}
