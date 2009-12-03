using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    /// <summary>
    /// 单个商品实体
    /// </summary>
    public class Goods : IdObject
    {
        public Goods() { }

        public Goods(DataRow dr)
        {
            this.ID = (int)dr["GoodsID"];
            this._goodsName = (string)dr["GoodsName"];
            this._price =(double)dr["Price"];
            this._marketPrice = dr["MarketPrice"] == System.DBNull.Value ? 0 : (double)dr["MarketPrice"];
            this._categoryID = (int)dr["CategoryID"];
            this._comments = (int)dr["Comments"];
            this._clicks = (int)dr["Clicks"];
            this._createAt = (DateTime)dr["CreateAt"];
            this._startTime = dr["StartTime"] == System.DBNull.Value ? DateTime.MinValue : (DateTime)dr["StartTime"];
            this._endTime = dr["EndTime"] == System.DBNull.Value ? DateTime.MaxValue : (DateTime)dr["EndTime"];
            this._order = (int)dr["Order"];
            this._recommend = (bool)dr["Recommend"];
            this._shopID = (int)dr["ShopID"];
            this._image = (string)dr["image"];
            this._status = (int)dr["Status"];
            this._description = (string)dr["Description"];
            this._score = (int)dr["Score"];
            this._weight = (double)dr["Weight"];
            this._factory = (string)dr["Factory"];
            this._service = (string)dr["Service"];
            this._unit = (string)dr["Unit"];
            this._model = (string)dr["Model"];
            this._isRecommend = (bool)dr["IsRecommend"];
        }

        private string _goodsName;
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        private double _price;
        /// <summary>
        /// 商品价格
        /// </summary>
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private double _marketPrice;
        /// <summary>
        /// 市场价格
        /// </summary>
        public double MarketPrice
        {
            get { return _marketPrice; }
            set { _marketPrice = value; }
        }

        private string _factory;
        /// <summary>
        /// 生产产家
        /// </summary>
        public string Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        private string _service;
        /// <summary>
        /// 售后服务
        /// </summary>
        public string Service
        {
            get { return _service; }
            set { _service = value; }
        }

        private int _categoryID;
        /// <summary>
        /// 类别编号
        /// </summary>
        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

        private int _comments;
        /// <summary>
        /// 评论数

        /// </summary>
        public int Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        private int _clicks;
        /// <summary>
        /// 点击数

        /// </summary>
        public int Clicks
        {
            get { return _clicks; }
            set { _clicks = value; }
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

        private int _order;
        /// <summary>
        /// 排序
        /// </summary>
        public int Order
        {
            get { return _order; }
            set { _order = value; }
        }


        private bool _recommend;
        /// <summary>
        /// 是否允许评论
        /// </summary>
        public bool Recommend
        {
            get { return _recommend; }
            set { _recommend = value; }
        }

        private DateTime _startTime=DateTime.MinValue;
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
       
        private DateTime _endTime=DateTime.MaxValue;
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        private string _image;
        /// <summary>
        /// 商品图片
        /// </summary>
        public string Image
        {
            get { return _image; }
            set { _image = value; }
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

        private int _status;
         /// <summary>
         /// 状态

         /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _description;
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private int _score;
        /// <summary>
        ///  积分
        /// </summary>
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        private double _weight;
        /// <summary>
        /// 重量
        /// </summary>
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        /// <summary>
        /// 所属栏目

        /// </summary>
        private Category _ofCategory;

        public Category OfCategory
        {
            get { return _ofCategory; }
            set { _ofCategory = value; }
        }

        /// <summary>
        /// 图片路径
        /// </summary>
        private string _fileUrl;

        public string FileUrl
        {
            get 
            {
                return this.Image;
            }
            set { _fileUrl = value; }
        }

        /// <summary>
        ///大图路径
        /// </summary>
        private string _bigfileurl;

        public string BigFileUrl
        {
            get 
            {
               
                return this.Image.Replace("S_","");
 
            }
            set { _bigfileurl = value; }
        }
	
	

        /// <summary>
        /// 路径
        /// </summary>
        private string _linkUrl;

        public string LinkUrl
        {
            get
            {
                if (_linkUrl == null)
                    _linkUrl = string.Format("/g/{0}.aspx", this.ID);
                return _linkUrl;
            }
            set { _linkUrl = value; }
        }

        /// <summary>
        /// 单位
        /// </summary>
        private string _unit;

        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        /// <summary>
        /// 型号
        /// </summary>
        private string _model;

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        private bool _isRecommend;
        /// <summary>
        ///  是否推荐
        /// </summary>
        public bool IsRecommend
        {
            get { return _isRecommend; }
            set { _isRecommend = value; }
        }

        /// <summary>
        /// 出售数量
        /// </summary>
        private int _payCount;

        public int PayCount
        {
            get { return _payCount; }
            set { _payCount = value; }
        }
    }
}
