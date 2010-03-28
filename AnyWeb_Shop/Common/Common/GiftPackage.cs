using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    public class GiftPackage : IdObject
    {
        public GiftPackage() { }
        public GiftPackage(DataRow dr)
        {
            this._packID = (int)dr["PackID"];
            this._packNo = (string)dr["PackNo"];
            this._packName = (string)dr["PackName"];
            this._goodsIds = (string)dr["GoodsIds"];
            this._image = (string)dr["Image"];
            this._price = (double)dr["Price"];
            this._intro = (string)dr["Intro"];
            this._description = (string)dr["Description"];
            this._isShow = (bool)dr["IsShow"];
            this._sort = (int)dr["Sort"];
        }

        private int _packID;
        /// <summary>
        /// 畅销大礼包ID
        /// </summary>
        public int PackID
        {
            get { return _packID; }
            set { _packID = value; }
        }

        private string _packNo;
        /// <summary>
        /// 大礼包编号，如: AF0101-0108
        /// </summary>
        public string PackNo
        {
            get { return _packNo; }
            set { _packNo = value; }
        }

        private string _packName;
        /// <summary>
        /// 大礼包名称
        /// </summary>
        public string PackName
        {
            get { return _packName; }
            set { _packName = value; }
        }

        private string _goodsIds;
        /// <summary>
        /// 大礼包商品Ids
        /// </summary>
        public string GoodsIds
        {
            get { return _goodsIds; }
            set { _goodsIds = value; }
        }

        private double _price;
        /// <summary>
        /// 大礼包价格
        /// </summary>
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private string _image;
        /// <summary>
        /// 图片
        /// </summary>
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        private string _intro;
        /// <summary>
        /// 大礼包简介
        /// </summary>
        public string Intro
        {
            get { return _intro; }
            set { _intro = value; }
        }

        private string _description;
        /// <summary>
        /// 大礼包描述（详细信息）
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private bool _isShow;
        /// <summary>
        /// 是否前台显示
        /// </summary>
        public bool IsShow
        {
            get { return _isShow; }
            set { _isShow = value; }
        }

        private int _sort;
        /// <summary>
        /// 大礼包排序
        /// </summary>
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }


        /*
        private List<Goods> _goodsList;
        /// <summary>
        /// 商品列表
        /// </summary>
        public List<Goods> GoodsList
        {
            get { return _goodsList; }
            set { _goodsList = value; }
        }
         */

    }
}
