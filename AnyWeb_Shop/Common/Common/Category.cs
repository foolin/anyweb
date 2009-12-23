using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    /// <summary>
    /// 类别实体
    /// </summary>
    public class Category:IdObject
    {
        public  Category() { }

        public Category(DataRow dr)
        {
            this.ID = (int)dr["CategoryID"];
            this._name = (string)dr["CategoryName"];
            this._createAt = (DateTime)dr["CreateAt"];
            this._shopID = (int)dr["ShopID"];
            this._type = (int)dr["Type"];
            this._path = (string)dr["path"];
            this._pater = (int)dr["Pater"];
            this._isShow = (bool)dr["IsShow"];
            this._ofshop = new Shop();
            this._articles = new ObjectList();

            this._goodslist = new ObjectList();
        }

        private string _name;
        /// <summary>
        /// 类别名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 是否前台显示
        /// </summary>
        private bool _isShow;

        public bool IsShow
        {
            get { return _isShow; }
            set { _isShow = value; }
        }
	

      

        private string _paterName;
        /// <summary>
        /// 所属类别名称

        /// </summary>
        public string PaterName
        {
            get { return _paterName; }
            set { _paterName = value; }
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

        private int _shopID;
        /// <summary>
        /// 商店编号
        /// </summary>
        public int ShopID
        {
            get { return _shopID; }
            set { _shopID = value; }
        }

        /// <summary>
        /// 所属商店

        /// </summary>
        private Shop _ofshop;

        public Shop OfShop
        {
            get { return _ofshop; }
            set { _ofshop = value; }
        }

        private string _path = "";
        /// <summary>
        /// 文件名称
        /// </summary>
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        private int _type;
        /// <summary>
        /// 类别 1-文章类别 2-商品类别
        /// </summary>
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private int _pater ;
        /// <summary>
        ///所属父级

        /// </summary>
        public int Pater 
        {
            get { return _pater ; }
            set { _pater  = value; }
        }

        private ObjectList _articles;
        /// <summary>
        /// 文章
        /// </summary>
        public ObjectList Articles
        {
            get { return _articles; }
            set { _articles = value; }
        }

        private ObjectList _goodslist;
        /// <summary>
        /// 商品
        /// </summary>
        public ObjectList GoodsList
        {
            get { return _goodslist; }
            set { _goodslist = value; }
        }


        public string Url
        {
            get
            {
                return string.Format("/c/{0}.aspx",this.ID);
            }
        }

        private string _backUrl;
        /// <summary>
        /// 后台使用
        /// </summary>
        public string BackUrl
        {
            get { return _backUrl; }
            set { _backUrl = value; }
        }

        private List<Category> _Children;
        /// <summary>
        /// 子类别
        /// </summary>
        public List<Category> Children
        {
            get { return _Children; }
            set { _Children = value; }
        }
    }
}
