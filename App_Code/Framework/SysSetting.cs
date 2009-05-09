using System;
using System.IO;
using System.Data;
using System.Xml;
using System.Web;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Collections;

using System.Resources;
using System.Globalization;

using Studio.Data;
using Studio.Array;
using Studio.Security;
using Studio.Xml;
using AnyP.BizPortal.Common;

namespace AnyP.BizPortal.Framework
{
	/// <summary>
	/// Biz Blog系统设置
	/// </summary>
	public class SysSetting
	{ 
		Hashtable _configData;

		public SysSetting()
		{
            this.DbConnectionString = Secure.GetAppSetting("DbConnectionString");
            this.DbType = DatabaseType.SqlServer;
            this.MailServer = System.Configuration.ConfigurationSettings.AppSettings["MailServer"];
            this.MailPassword = System.Configuration.ConfigurationSettings.AppSettings["MailPassword"];
            this.MailAccount = System.Configuration.ConfigurationSettings.AppSettings["MailAccount"];


		}

		public bool Initialize()
		{
			( new Agent.SystemAgent()).GetSystemConfiguration( 
				out _educationList,
				out _salaryList,
				out _workExprienceList,
				out _workTypeList,
                out _companySizeList,
                out _countryList,
				out _provinceList,
                out _cityList,
                out _productTypes,
                out _companyTypes,
                out _industries
                );
            ReadSettings();
            return true;
		}

		bool ReadSettings()
		{
			_configData = XmlAgent.GetKeyValueConfig("BlogConfig", this.GetSettingPath());
			if(_configData.Count > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Refresh()
		{
			this.Initialize();
		}

		string _connectString;
		public string DbConnectionString
		{
			get
			{
				return _connectString;
			}
			set{_connectString = value;}
		}

		string _bbsConnectString;
		public string BbsConnectionString
		{
			get
			{
				return _bbsConnectString;
			}
			set{_bbsConnectString = value;}
		}

		string _oracleConnectString;
		public string OracleConnectionString
		{
			get
			{
				return _oracleConnectString;
			}
			set{_oracleConnectString = value;}
		}

        string _bizConnectionString = Secure.GetAppSetting("BizConnectionString");
        public string BizConnectionString
        {
            get
            {
                return _bizConnectionString;
            }
            set { _bizConnectionString = value; }
        }

		DatabaseType _dbtype;
		public DatabaseType DbType
		{
			get
			{
				return _dbtype;
			}
			set{_dbtype = value;}
		}

		#region 公共属性
		string _settingPath;
		string GetSettingPath()
		{
			if(null == _settingPath)
			{
				_settingPath = HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings["ConfigFile"]);
			}
			return _settingPath;
		}

		/// <summary>
		/// 应用程序公共配置
		/// </summary>
		public Hashtable Configs
		{
			get
			{
				return _configData;
			}
		}
		
		ArrayList _fileTypes;
		public ArrayList AllowFileTypes
		{
			get
			{
				if( _fileTypes == null)
				{
					_fileTypes = new ArrayList();
					string[] types = ((string)Configs["AllowFileTypes"]).Split(',');
					foreach( string type in types)
					{
						_fileTypes.Add( type);
					}
				}

				return _fileTypes;
			}
		}



		/// <summary>
		/// 样式根目录路径
		/// </summary>
		public string StylePath
		{
			get{return (string)this._configData["StylePath"];}
		}

		/// <summary>
		/// 样式模板文件名
		/// </summary>
		public string TemplateCss
		{
			get{return (string)this._configData["TemplateCss"];}
		}
		/// <summary>
		/// 用户文件存放路径
		/// </summary>
		public string UserDataPath
		{
			get{return (string)this._configData["UserDataPath"];}
		}

		/// <summary>
		/// 用户文件存放路径
		/// </summary>
		public bool RssIntelligence
		{
			get{return (string)this._configData["RssIntelligence"] != "0";}
		}
		string _titleExt;
		public string TitleExtention
		{
			get
			{
				if(null == _titleExt)
				{
					_titleExt = (string)Configs["TitleExtension"];
				}
				return _titleExt;
			}
		}

		string _keyword;
		public string KeywordExtension
		{
			get
			{
				if(null == _keyword)
				{
					_keyword = (string)Configs["KeywordExtension"];
				}
				return _keyword;
			}
		}

		string _description;
		public string DescriptionExtension
		{
			get
			{
				if(null == _description)
				{
					_description = (string)Configs["DescriptionExtension"];
				}
				return _description;
			}
		}

		public int DescriptionLength
		{
			get{return 100;}
		}

		DicObjectCollection _educationList;
		public DicObjectCollection EducationList
		{
			get{return _educationList;}
			set{_educationList = value;}
		}

		DicObjectCollection _salaryList;
		public DicObjectCollection SalaryList
		{
			get{return _salaryList;}
			set{_salaryList = value;}
		}

		DicObjectCollection _workExprienceList;
		public DicObjectCollection WorkExprienceList
		{
			get{return _workExprienceList;}
			set{_workExprienceList = value;}
		}

		DicObjectCollection _workTypeList;
		public DicObjectCollection WorkTypeList
		{
			get{return _workTypeList;}
			set{_workTypeList = value;}
		}

		DicObjectCollection _companySizeList;
		public DicObjectCollection CompanySize
		{
			get{return _companySizeList;}
			set{_companySizeList = value;}
		}

		DicObjectCollection _countryList;
		public DicObjectCollection CountryList
		{
			get{	return _countryList;	}
			set{	_countryList = value;	}
		}

		DicObjectCollection _provinceList;
		public DicObjectCollection ProvinceList
		{
			get{	return _provinceList;	}
			set{	_provinceList = value;	}
		}

		DicObjectCollection _cityList;
		public DicObjectCollection CityList
		{
			get{	return _cityList;	}
			set{	_cityList = value;	}
		}




		#endregion

		#region  默认值设置

		/// <summary>
		/// 默认个人模板样式
		/// </summary>
		public string DefaultPersonalComponentsString
		{
			get
			{
				return (string)this._configData["DefaultPersonalComponent"];
			}
		}

		/// <summary>
		/// 默认企业模板样式
		/// </summary>
		public string DefaultEntComponentsString
		{
			get
			{
				return (string)this._configData["DefaultCompanyComponent"];
			}
		}

		/// <summary>
		/// 默认群模板样式
		/// </summary>
		public string DefaultGroupComponentsString
		{
			get
			{
				return (string)this._configData["DefaultGroupComponent"];
			}
		}
		
		/// <summary>
		/// 默认个人博客设置
		/// </summary>
		public string DefaultPersonalSettingString
		{
			get{return "";}
		}

		/// <summary>
		/// 默认企业博客设置
		/// </summary>
		public string DefaultEntSettingString
		{
			get{return "";}
		}

        #endregion

        ProductTypeCollection _productTypes;
        /// <summary>
        /// 产品类别
        /// </summary>
        public ProductTypeCollection ProductTypes
        {
            get { return _productTypes; }
            set { _productTypes = value; }
        }

        CompanyTypeCollection _companyTypes;
        /// <summary>
        /// 公司类别
        /// </summary>
        public CompanyTypeCollection CompanyTypes
        {
            get { return _companyTypes; }
            set { _companyTypes = value; }
        }

        IndustryCollection _industries;
        /// <summary>
        /// 行业类别
        /// </summary>
        public IndustryCollection Industries
        {
            get { return _industries; }
            set { _industries = value; }
        }

        public ArrayList GetProtuctTypeByParentID(int parentID)
        {
            ArrayList arr = new ArrayList();
            foreach (ProductType pt in this._productTypes)
            {
                if (pt.Parent == parentID) arr.Add(pt);
            }
            return arr;
        }

        public ProductType GetProTypeByID(int typeID)
        {
            foreach (ProductType pt in this._productTypes)
            {
                if (pt.ID == typeID)
                    return pt;
            }
            return null;
        }

		public string MapPath(string relativePath)
		{
			return HttpContext.Current.Server.MapPath(relativePath);
		}

		public static SysSetting GetSettings()
		{
			return Nested.instance;
		}
		class Nested
		{
			static Nested(){}
			internal static readonly SysSetting instance = new SysSetting();
		}

        private string _mailServer;
        /// <summary>
        /// 邮件服务器地址
        /// </summary>
        public string MailServer
        {
            get { return _mailServer; }
            set { _mailServer = value; }
        }

        private string _mailAccount;
        /// <summary>
        /// 邮件服务器帐号
        /// </summary>
        public string MailAccount
        {
            get { return _mailAccount; }
            set { _mailAccount = value; }
        }

        private string _mailPassword;
        /// <summary>
        /// 邮件服务器密码
        /// </summary>
        public string MailPassword
        {
            get { return _mailPassword; }
            set { _mailPassword = value; }
        }
	
	


	

		
	}
}
