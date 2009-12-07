using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Studio.Array;

namespace Common.Common
{
    /// <summary>
    /// �̵�ʵ��
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
        /// ҳ��
        /// </summary>
        private string _footer;

        public string Footer
        {
            get { return _footer; }
            set { _footer = value; }
        }

        private string _header;
        /// <summary>
        /// ҳͷ
        /// </summary>
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }


        /// <summary>
        /// �̵�����
        /// </summary>
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// ����ͨ���
        /// </summary>
        private int _comID;

        public int ComID
        {
            get { return _comID; }
            set { _comID = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        private DateTime _createAt;

        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        private string _shopMaster;

        public string ShopMaster
        {
            get { return _shopMaster; }
            set { _shopMaster = value; }
        }

        /// <summary>
        /// ״̬
        /// </summary>
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private int _version;
        /// <summary>
        /// ��Ӧ������ͨ�汾
        /// </summary>
        public int Version
        {
            get { return _version; }
            set { _version = value; }
        }
	

        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        private string _telePhone;

        public string TelePhone
        {
            get { return _telePhone; }
            set { _telePhone = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// �ƶ��绰
        /// </summary>
        private string _mobile;

        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        private string _postCode;

        public string PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }
        }

        /// <summary>
        /// ��ַ
        /// </summary>
        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        private string _fax;

        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        /// <summary>
        /// �û���
        /// </summary>
        private int _usercount;

        public int UserCount
        {
            get { return _usercount; }
            set { _usercount = value; }
        }

        /// <summary>
        /// �����
        /// </summary>
        private int _clickCount;

        public int ClickCount
        {
            get { return _clickCount; }
            set { _clickCount = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        private int _commentCount;

        public int CommentCount
        {
            get { return _commentCount; }
            set { _commentCount = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        private int _messageCount;

        public int MessageCount
        {
            get { return _messageCount; }
            set { _messageCount = value; }
        }

        private int _orderCount;
        /// <summary>
        /// ������
        /// </summary>
        public int OrderCount
        {
            get { return _orderCount; }
            set { _orderCount = value; }
        }


        /// <summary>
        /// �̵�����
        /// </summary>
        private string _shopAcc;

        public string ShopAcc
        {
            get { return _shopAcc; }
            set { _shopAcc = value; }
        }

        /// <summary>
        /// ����Ա�ʺ�
        /// </summary>
        private string _adminAcc;

        public string AdminAcc
        {
            get { return _adminAcc; }
            set { _adminAcc = value; }
        }

        /// <summary>
        /// ����
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
        /// �Զ�������
        /// </summary>
        private string _domainName;

        public string DomainName
        {
            get { return _domainName; }
            set { _domainName = value; }
        }

        /// <summary>
        /// �̵�����
        /// </summary>
        private int _typeID;

        public int TypeID
        {
            get { return _typeID; }
            set { _typeID = value; }
        }

        private string _emailSend;
        /// <summary>
        /// �ʼ����Ͷ˿�
        /// </summary>
        public string EmailSend
        {
            get { return _emailSend; }
            set { _emailSend = value; }
        }

        private string _emailPass;
        /// <summary>
        /// ��������
        /// </summary>
        public string EmailPass
        {
            get { return _emailPass; }
            set { _emailPass = value; }
        }


        private string _emailContent;
        /// <summary>
        /// ��������
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
        /// ģ����
        /// </summary>
        private int _skinID;

        public int SkinID
        {
            get { return _skinID; }
            set { _skinID = value; }
        }

        /// <summary>
        /// ��Ŀ��Ϣ
        /// </summary>
        private ObjectList _categorys;

        public ObjectList Categorys
        {
            get { return _categorys; }
            set { _categorys = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        private ObjectList _leftWidgets;

        public ObjectList LeftWidgets
        {
            get { return _leftWidgets; }
            set { _leftWidgets = value; }
        }

        /// <summary>
        /// ���������
        /// </summary>
        private ObjectList _contentWidgets;

        public ObjectList ContentWidgets
        {
            get { return _contentWidgets; }
            set { _contentWidgets = value; }
        }

        /// <summary>
        /// �б������
        /// </summary>
        private ObjectList _listLefTWidgets;

        public ObjectList ListLeftWidgets
        {
            get { return _listLefTWidgets; }
            set { _listLefTWidgets = value; }
        }

        /// <summary>
        /// ���²�����
        /// </summary>
        private ObjectList _articleLeftWidgets;

        public ObjectList ArticleLeftWidgets
        {
            get { return _articleLeftWidgets; }
            set { _articleLeftWidgets = value; }
        }

        private ObjectList _userLeftWidgets;
        /// <summary>
        /// ��Ա���Ĳ��
        /// </summary>
        public ObjectList UserLeftWidgets
        {
            get { return _userLeftWidgets; }
            set { _userLeftWidgets = value; }
        }

        /// <summary>
        /// ��Ʒ������
        /// </summary>
        private ObjectList __goodsLeftWidgets;

        public ObjectList GoodsLeftWidgets
        {
            get { return __goodsLeftWidgets; }
            set { __goodsLeftWidgets = value; }
        }

        /// <summary>
        /// �������
        /// </summary>
        private ObjectList _orderLeftWidgets;

        public ObjectList OrderLeftWidgets
        {
            get { return _orderLeftWidgets; }
            set { _orderLeftWidgets = value; }
        }
	
        /// <summary>
        /// ��������
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
        /// ��ӭ������
        /// </summary>
        private string _welcome;

        public string Welcome
        {
            get { return _welcome; }
            set { _welcome = value; }
        }

        private string _rootPath;
        /// <summary>
        /// ��·�� /test1/abc
        /// </summary>
        public string RootPath
        {
            get { return _rootPath; }
            set { _rootPath = value; }
        }

        private string _homeCss;
        /// <summary>
        /// �Զ�����ҳcss
        /// </summary>
        public string HomeCss
        {
            get { return _homeCss; }
            set { _homeCss = value; }
        }

        private string _pageCss;
        /// <summary>
        /// �Զ�����ҳcss
        /// </summary>
        public string PageCss
        {
            get { return _pageCss; }
            set { _pageCss = value; }
        }

        private string _listCss;
        /// <summary>
        /// �Զ����б�ҳcss
        /// </summary>
        public string ListCss
        {
            get { return _listCss; }
            set { _listCss = value; }
        }

        private string _goodsCss;
        /// <summary>
        /// �Զ�����Ʒҳcss
        /// </summary>
        public string GoodsCss
        {
            get { return _goodsCss; }
            set { _goodsCss = value; }
        }

        private string _articleCss;
        /// <summary>
        /// �Զ�������ҳcss
        /// </summary>
        public string ArticleCss
        {
            get { return _articleCss; }
            set { _articleCss = value; }
        }

        private string _carCss;
        /// <summary>
        /// �Զ��幺�ﳵcss
        /// </summary>
        public string CarCss
        {
            get { return _carCss; }
            set { _carCss = value; }
        }



        /// <summary>
        /// ������Ŀ·����ȡ��Ŀ
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
        /// ·��
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
        /// �������� 
        /// </summary>
        private string _aboutUs;

        public string AboutUs
        {
            get { return _aboutUs; }
            set { _aboutUs = value; }
        }

        /// <summary>
        /// ��ϵ���� 
        /// </summary>
        private string _interosculateUs;

        public string InterosculateUs
        {
            get { return _interosculateUs; }
            set { _interosculateUs = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        private ObjectList _afficheList;

        public ObjectList AfficheList
        {
            get { return _afficheList; }
            set { _afficheList = value; }
        }

        /// <summary>
        /// ���
        /// </summary>
        private ObjectList _advertisement;

        public ObjectList Advertisement
        {
            get { return _advertisement; }
            set { _advertisement = value; }
        }	

        private bool _showhelp;
        /// <summary>
        /// �Ƿ���ʾ�̳�ָ��
        /// </summary>
        public bool ShowHelp
        {
            get { return _showhelp; }
            set { _showhelp = value; }
        }


    }
}
