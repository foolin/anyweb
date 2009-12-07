using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Studio.Array;

namespace Common.Common
{
    /// <summary>
    /// 商店实体
    /// </summary>
    public class Shop:IdObject
    {
        public Shop()
        { }
        public Shop(DataRow dr)
        {
            this.ID = (int)dr["ShopID"];
            this._name = (string)dr["ShopName"];
            this._comID = (int)dr["ComID"];
            this._createAt = (DateTime)dr["CreateAt"];
            this._shopMaster = (string)dr["ShopMaster"];
            this._status = (int)dr["Status"];
            this._telePhone = (string)dr["TelePhone"];
            this._email = (string)dr["Email"];
            this._mobile = (string)dr["Mobile"];
            this._postCode = (string)dr["PostCode"];
            this._address = (string)dr["Address"];
            this._fax = (string)dr["Fax"];
            this._usercount = (int)dr["UserCount"];
            this._clickCount = (int)dr["ClickCount"];
            this._commentCount = (int)dr["CommentCount"];
            this._orderCount = (int)dr["OrderCount"];
            this.MessageCount = (int)dr["MessageCount"];
            this._shopAcc = (string)dr["ShopAcc"];
            this._adminAcc = (string)dr["AdminAcc"];
            this._adminPass = (string)dr["AdminPass"];
            this._domainName = dr["DomainName"] == System.DBNull.Value ? "" : (string)dr["DomainName"]; ;
            this._typeID = (int)dr["TypeID"];
            this._skinID = (int)dr["SkinID"];
            this._titleExt = dr["TitleExt"]==System.DBNull.Value ? "" :(string)dr["TitleExt"];
            this._titleExt2 = dr["TitleExt"] == System.DBNull.Value ? (string)dr["ShopName"] : (string)dr["TitleExt"];
            this._keywordExt = dr["KeywordExt"] == System.DBNull.Value ? "" : (string)dr["KeywordExt"];
            this._descriptionExt = dr["DescriptionExt"] == System.DBNull.Value ? "" : (string)dr["DescriptionExt"];
            this._logo = (string)dr["Logo"];

            this._emailSend = (string)dr["EmailSend"];
            this._emailPass = (string)dr["EmailPass"];
            this._emailContent = dr["EmailContent"] == System.DBNull.Value ? "" : (string)dr["EmailContent"];

            this._header = dr["Header"] == System.DBNull.Value ? "" : (string)dr["Header"];
            this._footer = dr["Footer"] == System.DBNull.Value ? "" : (string)dr["Footer"];
            this._welcome = dr["Welcome"] == System.DBNull.Value ? "" : (string)dr["Welcome"];
            this._aboutUs = dr["AboutUs"] == System.DBNull.Value ? "" : (string)dr["AboutUs"];
            this.InterosculateUs = dr["InterosculateUs"] == System.DBNull.Value ? "" : (string)dr["InterosculateUs"];
            this._homeCss = dr["HomeCss"]==System.DBNull.Value ? "" :(string)dr["HomeCss"];
            this._pageCss = dr["PageCss"] == System.DBNull.Value ? "" : (string)dr["PageCss"];
            this._carCss = dr["CarCss"] == System.DBNull.Value ? "" : (string)dr["CarCss"];
            this._articleCss = dr["ArticleCss"] == System.DBNull.Value ? "" : (string)dr["ArticleCss"];
            this._listCss = dr["ListCss"] == System.DBNull.Value ? "" : (string)dr["ListCss"];
            this._goodsCss = dr["GoodsCss"] == System.DBNull.Value ? "" : (string)dr["GoodsCss"];
            this._recordsInfo = dr["RecordsInfo"] == System.DBNull.Value ? "" : (string)dr["RecordsInfo"];
            this._showhelp = (bool)dr["ShowHelp"];

            this._categorys = new ObjectList();
            this._leftWidgets = new ObjectList();
            this._contentWidgets = new ObjectList();
        }

        /// <summary>
        /// 页脚
        /// </summary>
        private string _footer;

        public string Footer
        {
            get { return _footer; }
            set { _footer = value; }
        }

        private string _header;
        /// <summary>
        /// 页头
        /// </summary>
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }


        /// <summary>
        /// 商店名称
        /// </summary>
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 商脉通编号
        /// </summary>
        private int _comID;

        public int ComID
        {
            get { return _comID; }
            set { _comID = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime _createAt;

        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }

        /// <summary>
        /// 店主姓名
        /// </summary>
        private string _shopMaster;

        public string ShopMaster
        {
            get { return _shopMaster; }
            set { _shopMaster = value; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private int _version;
        /// <summary>
        /// 对应的商脉通版本
        /// </summary>
        public int Version
        {
            get { return _version; }
            set { _version = value; }
        }
	

        /// <summary>
        /// 联系电话
        /// </summary>
        private string _telePhone;

        public string TelePhone
        {
            get { return _telePhone; }
            set { _telePhone = value; }
        }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// 移动电话
        /// </summary>
        private string _mobile;

        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        /// <summary>
        /// 邮政编码
        /// </summary>
        private string _postCode;

        public string PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }
        }

        /// <summary>
        /// 地址
        /// </summary>
        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        /// <summary>
        /// 传真
        /// </summary>
        private string _fax;

        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        /// <summary>
        /// 用户数
        /// </summary>
        private int _usercount;

        public int UserCount
        {
            get { return _usercount; }
            set { _usercount = value; }
        }

        /// <summary>
        /// 点击数
        /// </summary>
        private int _clickCount;

        public int ClickCount
        {
            get { return _clickCount; }
            set { _clickCount = value; }
        }

        /// <summary>
        /// 评论数
        /// </summary>
        private int _commentCount;

        public int CommentCount
        {
            get { return _commentCount; }
            set { _commentCount = value; }
        }

        /// <summary>
        /// 留言数
        /// </summary>
        private int _messageCount;

        public int MessageCount
        {
            get { return _messageCount; }
            set { _messageCount = value; }
        }

        private int _orderCount;
        /// <summary>
        /// 订单数
        /// </summary>
        public int OrderCount
        {
            get { return _orderCount; }
            set { _orderCount = value; }
        }


        /// <summary>
        /// 商店域名
        /// </summary>
        private string _shopAcc;

        public string ShopAcc
        {
            get { return _shopAcc; }
            set { _shopAcc = value; }
        }

        /// <summary>
        /// 管理员帐号
        /// </summary>
        private string _adminAcc;

        public string AdminAcc
        {
            get { return _adminAcc; }
            set { _adminAcc = value; }
        }

        /// <summary>
        /// 密码
        /// </summary>
        private string _adminPass;

        public string AdminPass
        {
            get { return _adminPass; }
            set { _adminPass = value; }
        }

        private string _recordsInfo;

        public string RecordsInfo
        {
            get { return _recordsInfo; }
            set { _recordsInfo = value; }
        }
	

        /// <summary>
        /// 自定义域名
        /// </summary>
        private string _domainName;

        public string DomainName
        {
            get { return _domainName; }
            set { _domainName = value; }
        }

        /// <summary>
        /// 商店类型
        /// </summary>
        private int _typeID;

        public int TypeID
        {
            get { return _typeID; }
            set { _typeID = value; }
        }

        private string _emailSend;
        /// <summary>
        /// 邮件发送端口
        /// </summary>
        public string EmailSend
        {
            get { return _emailSend; }
            set { _emailSend = value; }
        }

        private string _emailPass;
        /// <summary>
        /// 邮箱密码
        /// </summary>
        public string EmailPass
        {
            get { return _emailPass; }
            set { _emailPass = value; }
        }


        private string _emailContent;
        /// <summary>
        /// 邮箱内容
        /// </summary>
        public string EmailContent
        {
            get { return _emailContent; }
            set { _emailContent = value; }
        }

        /// <summary>
        /// SEO
        /// </summary>
        private string _titleExt;

        public string TitleExt
        {
            get { return _titleExt; }
            set { _titleExt = value; }
        }

        /// <summary>
        /// SEO
        /// </summary>
        private string _titleExt2;

        public string TitleExt2
        {
            get { return _titleExt2; }
            set { _titleExt2 = value; }
        }
	

        /// <summary>
        /// SEO
        /// </summary>
        private string _keywordExt;

        public string KeywordExt
        {
            get { return _keywordExt; }
            set { _keywordExt = value; }
        }

        /// <summary>
        /// SEO
        /// </summary>
        private string _descriptionExt;

        public string DescriptionExt
        {
            get { return _descriptionExt; }
            set { _descriptionExt = value; }
        }

        public string DataPath
        {
            get { return "/ShopData/" + this.ID.ToString(); }
        }
        /// <summary>
        /// 模版编号
        /// </summary>
        private int _skinID;

        public int SkinID
        {
            get { return _skinID; }
            set { _skinID = value; }
        }

        /// <summary>
        /// 栏目信息
        /// </summary>
        private ObjectList _categorys;

        public ObjectList Categorys
        {
            get { return _categorys; }
            set { _categorys = value; }
        }

        /// <summary>
        /// 侧边栏组件
        /// </summary>
        private ObjectList _leftWidgets;

        public ObjectList LeftWidgets
        {
            get { return _leftWidgets; }
            set { _leftWidgets = value; }
        }

        /// <summary>
        /// 内容区组件
        /// </summary>
        private ObjectList _contentWidgets;

        public ObjectList ContentWidgets
        {
            get { return _contentWidgets; }
            set { _contentWidgets = value; }
        }

        /// <summary>
        /// 列表侧边组件
        /// </summary>
        private ObjectList _listLefTWidgets;

        public ObjectList ListLeftWidgets
        {
            get { return _listLefTWidgets; }
            set { _listLefTWidgets = value; }
        }

        /// <summary>
        /// 文章侧边组件
        /// </summary>
        private ObjectList _articleLeftWidgets;

        public ObjectList ArticleLeftWidgets
        {
            get { return _articleLeftWidgets; }
            set { _articleLeftWidgets = value; }
        }

        private ObjectList _userLeftWidgets;
        /// <summary>
        /// 会员中心侧边
        /// </summary>
        public ObjectList UserLeftWidgets
        {
            get { return _userLeftWidgets; }
            set { _userLeftWidgets = value; }
        }

        /// <summary>
        /// 商品侧边组件
        /// </summary>
        private ObjectList __goodsLeftWidgets;

        public ObjectList GoodsLeftWidgets
        {
            get { return __goodsLeftWidgets; }
            set { __goodsLeftWidgets = value; }
        }

        /// <summary>
        /// 订单侧边
        /// </summary>
        private ObjectList _orderLeftWidgets;

        public ObjectList OrderLeftWidgets
        {
            get { return _orderLeftWidgets; }
            set { _orderLeftWidgets = value; }
        }
	
        /// <summary>
        /// 友情连接
        /// </summary>
        private ObjectList _links;

        public ObjectList Links
        {
            get { return _links; }
            set { _links = value; }
        }

        /// <summary>
        /// LOGO
        /// </summary>
        private string _logo;

        public string Logo
        {
            get { return _logo; }
            set { _logo = value; }
        }

        /// <summary>
        /// 欢迎区内容
        /// </summary>
        private string _welcome;

        public string Welcome
        {
            get { return _welcome; }
            set { _welcome = value; }
        }

        private string _rootPath;
        /// <summary>
        /// 根路径 /test1/abc
        /// </summary>
        public string RootPath
        {
            get { return _rootPath; }
            set { _rootPath = value; }
        }

        private string _homeCss;
        /// <summary>
        /// 自定义首页css
        /// </summary>
        public string HomeCss
        {
            get { return _homeCss; }
            set { _homeCss = value; }
        }

        private string _pageCss;
        /// <summary>
        /// 自定义内页css
        /// </summary>
        public string PageCss
        {
            get { return _pageCss; }
            set { _pageCss = value; }
        }

        private string _listCss;
        /// <summary>
        /// 自定义列表页css
        /// </summary>
        public string ListCss
        {
            get { return _listCss; }
            set { _listCss = value; }
        }

        private string _goodsCss;
        /// <summary>
        /// 自定义商品页css
        /// </summary>
        public string GoodsCss
        {
            get { return _goodsCss; }
            set { _goodsCss = value; }
        }

        private string _articleCss;
        /// <summary>
        /// 自定义文章页css
        /// </summary>
        public string ArticleCss
        {
            get { return _articleCss; }
            set { _articleCss = value; }
        }

        private string _carCss;
        /// <summary>
        /// 自定义购物车css
        /// </summary>
        public string CarCss
        {
            get { return _carCss; }
            set { _carCss = value; }
        }



        /// <summary>
        /// 根据栏目路径获取栏目
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Category GetCategoryByPath(string path)
        {
            foreach (Category c in this.Categorys)
            {
                if (c.Path.ToLower() == path)
                {
                    return c;
                }
            }

            return null;
        }

        /// <summary>
        /// 路径
        /// </summary>
        public string Url
        {
            get
            {
                return string.Format("http://{0}/{1}", this.ShopDomain, this.RootPath);
            }
        }

        public string ShopDomain
        {
            get
            {
                if (this.DomainName == null || this.DomainName == "")
                {
                    return this.ShopAcc + ".anyp.com";
                }
                else
                {
                    return this.DomainName;
                }
            }
        }

        /// <summary>
        /// 关于我们 
        /// </summary>
        private string _aboutUs;

        public string AboutUs
        {
            get { return _aboutUs; }
            set { _aboutUs = value; }
        }

        /// <summary>
        /// 联系我们 
        /// </summary>
        private string _interosculateUs;

        public string InterosculateUs
        {
            get { return _interosculateUs; }
            set { _interosculateUs = value; }
        }

        /// <summary>
        /// 公告
        /// </summary>
        private ObjectList _afficheList;

        public ObjectList AfficheList
        {
            get { return _afficheList; }
            set { _afficheList = value; }
        }

        /// <summary>
        /// 广告
        /// </summary>
        private ObjectList _advertisement;

        public ObjectList Advertisement
        {
            get { return _advertisement; }
            set { _advertisement = value; }
        }	

        private bool _showhelp;
        /// <summary>
        /// 是否显示商城指南
        /// </summary>
        public bool ShowHelp
        {
            get { return _showhelp; }
            set { _showhelp = value; }
        }


    }
}
