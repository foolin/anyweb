using System;

namespace AnyWell.Configs
{
    /// <summary>
    /// 基本设置描述类, 加[Serializable]标记为可序列化
    /// </summary>
    [Serializable]
    public class PaymentConfigInfo : IConfigInfo
    {
        #region 商城基本信息


        private string _shopName = "商城名称";
        /// <summary>
        /// 商城名称
        /// </summary>
        public string ShopName
        {
            get { return _shopName; }
            set { _shopName = value; }
        }

        private string _companyName = "广州市时代财富科技有限公司";
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        private string _address = "广州市科韵路18号6楼";
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _postcode = "510660";
        /// <summary>
        /// 邮编
        /// </summary>
        public string Postcode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }

        private string _tel = "020-85537383";
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        private string _fax = "020-85528003";
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        private string _mobile = "";
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        private string _qq = "99879123";
        /// <summary>
        /// 客服QQ
        /// </summary>
        public string QQ
        {
            get { return _qq; }
            set { _qq = value; }
        }

        private string _msn = "test@fortuneage.com";
        /// <summary>
        /// 客服MSN
        /// </summary>
        public string MSN
        {
            get { return _msn; }
            set { _msn = value; }
        }

        private string _email = "test@fortuneage.com";
        /// <summary>
        /// 客服邮件
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _icp = "";
        /// <summary>
        /// 网站备案信息
        /// </summary>
        public string Icp
        {
            get { return _icp; }
            set { _icp = value; }
        }

        #endregion

        #region 搜索引擎优化

        private string _titleExtension = "";
        /// <summary>
        /// 标题后缀
        /// </summary>
        public string TitleExtension
        {
            get { return _titleExtension; }
            set { _titleExtension = value; }
        }

        private string _metaKeywords;
        /// <summary>
        /// Meta Keywords
        /// </summary>
        public string MetaKeywords
        {
            get { return _metaKeywords; }
            set { _metaKeywords = value; }
        }

        private string _metaDescription;
        /// <summary>
        /// Meta Description
        /// </summary>
        public string MetaDescription
        {
            get { return _metaDescription; }
            set { _metaDescription = value; }
        }

        #endregion

        #region 图片大小水印


        private int _flashWidth = 470;
        /// <summary>
        /// 幻灯宽度
        /// </summary>
        public int FlashWidth
        {
            get { return _flashWidth; }
            set { _flashWidth = value; }
        }

        private int _falshHeight = 410;
        /// <summary>
        /// 高度
        /// </summary>
        public int FalshHeight
        {
            get { return _falshHeight; }
            set { _falshHeight = value; }
        }
	

        private int _memberAvatorWidth = 100;
        /// <summary>
        /// 会员头像宽度
        /// </summary>
        public int MemberAvatorWidth
        {
            get { return _memberAvatorWidth; }
            set { _memberAvatorWidth = value; }
        }

        private int _memberAvatorHeight = 100;
        /// <summary>
        /// 会员头像高度
        /// </summary>
        public int MemberAvatorHeight
        {
            get { return _memberAvatorHeight; }
            set { _memberAvatorHeight = value; }
        }
	

        private int _brandImageWidth = 150;
        /// <summary>
        /// 品牌图片宽度
        /// </summary>
        public int BrandImageWidth
        {
            get { return _brandImageWidth; }
            set { _brandImageWidth = value; }
        }
	

        private int _brandImageHeight = 80;
        /// <summary>
        /// 品牌图片高度
        /// </summary>
        public int BrandImageHeight
        {
            get { return _brandImageHeight; }
            set { _brandImageHeight = value; }
        }

        private int _goodsListImageWidth = 120;
        /// <summary>
        /// 商品列表图片宽度
        /// </summary>
        public int GoodsListImageWidth
        {
            get { return _goodsListImageWidth; }
            set { _goodsListImageWidth = value; }
        }

        private int _goodsListImageHeight = 120;
        /// <summary>
        /// 商品列表图片高度
        /// </summary>
        public int GoodsListImageHeight
        {
            get { return _goodsListImageHeight; }
            set { _goodsListImageHeight = value; }
        }

        private int _goodsImageWidth = 300;
        /// <summary>
        /// 商品图片宽度    
        /// </summary>
        public int GoodsImageWidth
        {
            get { return _goodsImageWidth; }
            set { _goodsImageWidth = value; }
        }

        private int _goodsImageHeight = 300;
        /// <summary>
        /// 商品图片高度
        /// </summary>
        public int GoodsImageHeight
        {
            get { return _goodsImageHeight; }
            set { _goodsImageHeight = value; }
        }

        private int _goodsImageWaterType;
        /// <summary>
        /// 水印类型 0未启用 1文字 2图片
        /// </summary>
        public int GoodsImageWatermarkType
        {
            get { return _goodsImageWaterType; }
            set { _goodsImageWaterType = value; }
        }
	

        private string _goodsImageWatermarkUrl = "";
        /// <summary>
        /// 商品图片水印图路径
        /// </summary>
        public string GoodsImageWatermarkUrl
        {
            get { return _goodsImageWatermarkUrl; }
            set { _goodsImageWatermarkUrl = value; }
        }

        private string _goodsImageWatermarkText = "";
        /// <summary>
        /// 商品图片水印文字路径
        /// </summary>
        public string GoodsImageWatermarkText
        {
            get { return _goodsImageWatermarkText; }
            set { _goodsImageWatermarkText = value; }
        }

        private int _goodsImageWatermarkFontsize = 12;
        /// <summary>
        /// 商品图片水印文字大小
        /// </summary>
        public int GoodsImageWatermarkFontsize
        {
            get { return _goodsImageWatermarkFontsize; }
            set { _goodsImageWatermarkFontsize = value; }
        }

        private string _goodsImageWatermarkFontFamily = "宋体";
        /// <summary>
        /// 商品图片水印文字字体
        /// </summary>
        public string GoodsImageWatermarkFontFamily
        {
            get { return _goodsImageWatermarkFontFamily; }
            set { _goodsImageWatermarkFontFamily = value; }
        }

        private int _goodsImageWatermarkTransparency = 6;
        /// <summary>
        /// 商品图片水印透明度
        /// </summary>
        public int GoodsImageWatermarkTransparency
        {
            get { return _goodsImageWatermarkTransparency; }
            set { _goodsImageWatermarkTransparency = value; }
        }

        private int _goodsImageWatermarkPosition = 9;
        /// <summary>
        /// 商品图片水印图位置  1左上 2上 3右上 4左 5中 6右 7左下 8下 9右下
        /// </summary>
        public int GoodsImageWatermarkPosition
        {
            get { return _goodsImageWatermarkPosition; }
            set { _goodsImageWatermarkPosition = value; }
        }

        #endregion

        #region 用户注册与访问

        private bool _regEnable = true;
        /// <summary>
        /// 允许注册
        /// </summary>
        public bool RegEnable
        {
            get { return _regEnable; }
            set { _regEnable = value; }
        }

        private string _regAgreement = @"1 遵守国家法律法规
2 遵守所有与网络服务有关的网络协议、规定和程序
3 不得为任何非法目的而使用网络服务系统";
        /// <summary>
        /// 注册协议
        /// </summary>
        public string RegAgreement
        {
            get { return _regAgreement; }
            set { _regAgreement = value; }
        }

        private string _regEmailBlocked = "";
        /// <summary>
        /// 拒绝注册的邮件地址后缀
        /// </summary>
        public string RegEmailBlocked
        {
            get { return _regEmailBlocked; }
            set { _regEmailBlocked = value; }
        }

        private string _regEmailEnabled = "";
        /// <summary>
        /// 允许注册的邮件地址后缀
        /// </summary>
        public string RegEmailEnabled
        {
            get { return _regEmailEnabled; }
            set { _regEmailEnabled = value; }
        }

        #endregion
    }
}