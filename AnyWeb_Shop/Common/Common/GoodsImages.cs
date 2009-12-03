using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    public class GoodsImages : IdObject
    {
        public GoodsImages() { }

        public GoodsImages(DataRow dr)
        {
            this.ID = (int)dr["ImageID"];
            this._goodsId = (int)dr["GoodsID"];
            this._imageName = (string)dr["ImageName"];
            this._imageUrl = (string)dr["ImageUrl"];
            this._createat = (DateTime)dr["CreateAt"];
            this._type = (int)dr["Type"];
        }

        private int _goodsId;
        /// <summary>
        /// 商品编号
        /// </summary>
        public int GoodsID
        {
            get { return _goodsId; }
            set { _goodsId = value; }
        }

        private string _imageName;

        public string ImageName
        {
            get { return _imageName; }
            set { _imageName = value; }
        }

        private DateTime _createat;

        public DateTime CreateAt
        {
            get { return _createat; }
            set { _createat = value; }
        }

        private string _imageUrl;

        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        private int _type;

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

    }
}
