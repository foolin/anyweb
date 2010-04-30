using System;

namespace AnyWeb.AW.Configs
{
    /// <summary>
    /// 基本设置描述类, 加[Serializable]标记为可序列化
    /// </summary>
    [Serializable]
    public class GeneralConfigInfo : IConfigInfo
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

        private string _companyName = "AnyWeb";
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        private string _address = "广州市";
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _postcode = "";
        /// <summary>
        /// 邮编
        /// </summary>
        public string Postcode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }

        private string _tel = "";
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        private string _fax = "";
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

        private string _qq = "";
        /// <summary>
        /// 客服QQ
        /// </summary>
        public string QQ
        {
            get { return _qq; }
            set { _qq = value; }
        }

        private string _msn = "";
        /// <summary>
        /// 客服MSN
        /// </summary>
        public string MSN
        {
            get { return _msn; }
            set { _msn = value; }
        }

        private string _email = "";
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
        public int FlashHeight
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

        private int _columnImageWidth = 120;
        /// <summary>
        /// 栏目图片宽度
        /// </summary>
        public int ColumnImageWidth
        {
            get { return _columnImageWidth; }
            set { _columnImageWidth = value; }
        }

        private int _columnImageHeight = 120;
        /// <summary>
        /// 栏目图片高度
        /// </summary>
        public int ColumnImageHeight
        {
            get { return _columnImageHeight; }
            set { _columnImageHeight = value; }
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

        private int _imageWaterType;
        /// <summary>
        /// 水印类型 0未启用 1文字 2图片
        /// </summary>
        public int ImageWatermarkType
        {
            get { return _imageWaterType; }
            set { _imageWaterType = value; }
        }
	

        private string _imageWatermarkUrl = "";
        /// <summary>
        /// 水印图片路径
        /// </summary>
        public string ImageWatermarkUrl
        {
            get { return _imageWatermarkUrl; }
            set { _imageWatermarkUrl = value; }
        }

        private string _imageWatermarkText = "";
        /// <summary>
        /// 水印文字
        /// </summary>
        public string ImageWatermarkText
        {
            get { return _imageWatermarkText; }
            set { _imageWatermarkText = value; }
        }

        private int _imageWatermarkFontsize = 3;
        /// <summary>
        /// 图片水印文字大小
        /// </summary>
        public int ImageWatermarkFontsize
        {
            get { return _imageWatermarkFontsize; }
            set { _imageWatermarkFontsize = value; }
        }

        private string _imageWatermarkFontFamily = "宋体";
        /// <summary>
        /// 图片水印文字字体
        /// </summary>
        public string ImageWatermarkFontFamily
        {
            get { return _imageWatermarkFontFamily; }
            set { _imageWatermarkFontFamily = value; }
        }

        private int _imageWatermarkTransparency = 80;
        /// <summary>
        /// 图片水印透明度
        /// </summary>
        public int ImageWatermarkTransparency
        {
            get { return _imageWatermarkTransparency; }
            set { _imageWatermarkTransparency = value; }
        }

        private int _imageWatermarkPosition = 9;
        /// <summary>
        /// 商品图片水印图位置  1左上 2上 3右上 4左 5中 6右 7左下 8下 9右下
        /// </summary>
        public int ImageWatermarkPosition
        {
            get { return _imageWatermarkPosition; }
            set { _imageWatermarkPosition = value; }
        }

        private string _imageWatermarkFontColor = "#000000";
        /// <summary>
        /// 文字颜色
        /// </summary>
        public string ImageWatermarkFontColor
        {
            get { return _imageWatermarkFontColor; }
            set { _imageWatermarkFontColor = value; }
        }

        private string _imageWatermarkShadowColor = "#000000";
        /// <summary>
        /// 阴影颜色
        /// </summary>
        public string ImageWatermarkShadowColor
        {
            get { return _imageWatermarkShadowColor; }
            set { _imageWatermarkShadowColor = value; }
        }

        private int _imageWatermarkAngle;
        /// <summary>
        /// 旋转角度
        /// </summary>
        public int ImageWatermarkAngle
        {
            get { return _imageWatermarkAngle; }
            set { _imageWatermarkAngle = value; }
        }

        private string _imageWatermarkFontCss;
        /// <summary>
        /// 文字形状
        /// </summary>
        public string ImageWatermarkFontCss
        {
            get { return _imageWatermarkFontCss; }
            set { _imageWatermarkFontCss = value; }
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

        private bool _regMobile = false;
        /// <summary>
        /// 允许手机作为登录帐号注册
        /// </summary>
        public bool RegMobile
        {
            get { return _regMobile; }
            set { _regMobile = value; }
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

        #region 支付方式

        #region 支付宝设置

        private bool _isAliPay = false;
        /// <summary>
        /// 是否用支付宝
        /// </summary>
        public bool IsAliPay
        {
            get { return _isAliPay; }
            set { _isAliPay = value; }
        }

        private string _aliPay_Acc = "";
        /// <summary>
        /// 支付宝帐号
        /// </summary>
        public string AliPay_Acc
        {
            get { return _aliPay_Acc; }
            set { _aliPay_Acc = value; }
        }

        private string _aliPay_PartnerID = "";
        /// <summary>
        /// 支付宝，合作者身份(partnerID)
        /// </summary>
        public string AliPay_PartnerID
        {
            get { return _aliPay_PartnerID; }
            set { _aliPay_PartnerID = value; }
        }

        private string _aliPay_Key = "";
        /// <summary>
        /// 支付宝，安全校验码(key)
        /// </summary>
        public string AliPay_Key
        {
            get { return _aliPay_Key; }
            set { _aliPay_Key = value; }
        }

        private string _aliPay_Service = "trade_create_by_buyer";
        /// <summary>
        /// 支付宝，接口类型
        /// </summary>
        public string AliPay_Service
        {
            get { return _aliPay_Service; }
            set { _aliPay_Service = value; }
        }

        #endregion

        #region 网银在线设置

        private bool _isNetBank = false;
        /// <summary>
        /// 是否用网银在线
        /// </summary>
        public bool IsNetBank
        {
            get { return _isNetBank; }
            set { _isNetBank = value; }
        }

        private string _netBank_ID = "";
        /// <summary>
        /// 商户编号
        /// </summary>
        public string NetBank_ID
        {
            get { return _netBank_ID; }
            set { _netBank_ID = value; }
        }

        private string _netBank_Key = "";
        /// <summary>
        /// MD5密钥
        /// </summary>
        public string NetBank_Key
        {
            get { return _netBank_Key; }
            set { _netBank_Key = value; }
        }

        #endregion

        #region 其它付款方式设置

        private bool _isBank = false;
        /// <summary>
        /// 是否用银行转帐
        /// </summary>
        public bool IsBank
        {
            get { return _isBank; }
            set { _isBank = value; }
        }

        private string _bank_Des = "";
        /// <summary>
        /// 银行转帐描述
        /// </summary>
        public string Bank_Des
        {
            get { return _bank_Des; }
            set { _bank_Des = value; }
        }

        private bool _isFacePay = false;
        /// <summary>
        /// 是否用货到付款
        /// </summary>
        public bool IsFacePay
        {
            get { return _isFacePay; }
            set { _isFacePay = value; }
        }

        private string _facePay_Des = "";
        /// <summary>
        /// 货到付款描述
        /// </summary>
        public string FacePay_Des
        {
            get { return _facePay_Des; }
            set { _facePay_Des = value; }
        }

        #endregion 

        #endregion

        #region 商城建立指引(新用户)

        private bool _setupConfigGeneral = false;
        /// <summary>
        /// 商城建立指引-设置基本信息
        /// </summary>
        public bool SetupConfigGeneral
        {
            get { return _setupConfigGeneral; }
            set { _setupConfigGeneral = value; }
        }

        private bool _setupConfigMember = false;
        /// <summary>
        /// 商城建立指引-设置会员
        /// </summary>
        public bool SetupConfigMember
        {
            get { return _setupConfigMember; }
            set { _setupConfigMember = value; }
        }

        private bool _setupConfigHelp;
        /// <summary>
        /// 商城建立指引-设置商城客户常见问题答案
        /// </summary>
        public bool SetupConfigHelp
        {
            get { return _setupConfigHelp; }
            set { _setupConfigHelp = value; }
        }
	

        private bool _setupConfigPayment = false;
        /// <summary>
        /// 商城建立指引-设置支付方式
        /// </summary>
        public bool SetupConfigPayment
        {
            get { return _setupConfigPayment; }
            set { _setupConfigPayment = value; }
        }

        private bool _setupConfigImage = false;
        /// <summary>
        /// 商城建立指引-设置图片规格
        /// </summary>
        public bool SetupConfigImage
        {
            get { return _setupConfigImage; }
            set { _setupConfigImage = value; }
        }

        private bool _setupConfigSeo = false;
        /// <summary>
        /// 商城建立指引-设置搜索引擎优化
        /// </summary>
        public bool SetupConfigSeo
        {
            get { return _setupConfigSeo; }
            set { _setupConfigSeo = value; }
        }

        private bool _setupConfigSmtps = false;
        /// <summary>
        /// 商城建立指引-设置邮件服务器
        /// </summary>
        public bool SetupConfigSmtps
        {
            get { return _setupConfigSmtps; }
            set { _setupConfigSmtps = value; }
        }

        private bool _setupCategory = false;
        /// <summary>
        /// 商城建立指引-设置分类
        /// </summary>
        public bool SetupCategory
        {
            get { return _setupCategory; }
            set { _setupCategory = value; }
        }

        private bool _setupBrand = false;
        /// <summary>
        /// 商城建立指引-设置品牌
        /// </summary>
        public bool SetupBrand
        {
            get { return _setupBrand; }
            set { _setupBrand = value; }
        }

        #endregion
    }
}