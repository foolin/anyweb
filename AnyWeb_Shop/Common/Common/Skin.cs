using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    /// <summary>
    /// 单个模版实体
    /// </summary>
    public class Skin:IdObject
    {

        public  Skin() { }

        public  Skin(DataRow dr)
        {
            this.ID = (int)dr["SkinID"];
            this._skinName = (string)dr["SkinName"];
            this._path = (string)dr["Path"];
            this._typeId = (int)dr["TypeID"];
            this._createAt = (DateTime)dr["CreateAt"];
            this._breviaryPhoto = (string)dr["BreviaryPhoto"];
            this._isValid = (bool)dr["IsValid"];
            this._framWork = (FrameWork)(int)dr["FrameWork"];
            this._skinShopID = (int)dr["Skin_ShopID"];
        }

        private string _skinName;
        /// <summary>
        /// 模版名称
        /// </summary>
        public string SkinName
        {
            get { return _skinName; }
            set { _skinName = value; }
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

        private bool _isValid;
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; }
        }

        private string _path;
        /// <summary>
        /// 模版路径
        /// </summary>
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        private int _typeId;
        /// <summary>
        /// 所属类别
        /// </summary>
        public int TypeID
        {
            get { return _typeId; }
            set { _typeId = value; }
        }

        private string _breviaryPhoto;
        /// <summary>
        /// 模版缩略图
        /// </summary>
        public string BreviaryPhoto
        {
            get { return _breviaryPhoto; }
            set { _breviaryPhoto = value; }
        }

        private FrameWork _framWork;

        public FrameWork FramWork
        {
            get { return _framWork; }
            set { _framWork = value; }
        }

        private int _skinShopID;
        /// <summary>
        /// 对应此模版的商城示例
        /// </summary>
        public int SkinShopID
        {
            get { return _skinShopID; }
            set { _skinShopID = value; }
        }
    }
    /// <summary>
    ///布局  0,左侧边,1右侧边
    /// </summary>
    public enum FrameWork : int
    {
        rg2ptpt1 = 0,
        rg2ptpt2 = 1

    }
}
