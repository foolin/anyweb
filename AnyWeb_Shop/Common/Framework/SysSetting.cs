using System;
using System.Collections.Generic;
using System.Text;

using Studio.Data;
using Studio.Security;
using Studio.Array;

namespace Common.Framework
{
    /// <summary>
    /// 基类,单键获取连接字符串
    /// </summary>
    public class SysSetting
    {
        public SysSetting()
        {
            this.ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
        }

        private string _connectionstring;

        public string ConnectionString
        {
            get { return _connectionstring; }
            set { _connectionstring = value; }
        }

        private ObjectList _typies;
        /// <summary>
        /// 海报类别列表
        /// </summary>
        public ObjectList Typies
        {
            get { return _typies; }
            set { _typies = value; }
        }

        private ObjectList _skins;
        /// <summary>
        /// 商店模板列表
        /// </summary>
        public ObjectList Skins
        {
            get { return _skins; }
            set { _skins = value; }
        }

        private ObjectList _sysWidgets;
        /// <summary>
        /// 系统插件（不能自由添加）
        /// </summary>
        public ObjectList SysWidgets
        {
            get { return _sysWidgets; }
            set { _sysWidgets = value; }
        }

        private ObjectList _leftWidgets;
        /// <summary>
        /// 首页侧栏插件，可在侧栏自由添加
        /// </summary>
        public ObjectList LeftWidgets
        {
            get { return _leftWidgets; }
            set { _leftWidgets = value; }
        }

        private ObjectList _listLeftWidgets;
        /// <summary>
        /// 列表页侧栏插件，可在侧栏自由添加
        /// </summary>
        public ObjectList ListLeftWidgets
        {
            get { return _listLeftWidgets; }
            set { _listLeftWidgets = value; }
        }

        private ObjectList _articleLeftWidgets;
        /// <summary>
        /// 文章页侧栏插件，可在侧栏自由添加
        /// </summary>
        public ObjectList ArticleLeftWidgets
        {
            get { return _articleLeftWidgets; }
            set { _articleLeftWidgets = value; }
        }


        private ObjectList _goodsLeftWidgets;
        /// <summary>
        /// 商品页侧栏插件，可在侧栏自由添加
        /// </summary>
        public ObjectList GoodsLeftWidgets
        {
            get { return _goodsLeftWidgets; }
            set { _goodsLeftWidgets = value; }
        }

        private ObjectList _carLeftWidgets;
        /// <summary>
        /// 购物车页侧栏插件，可在侧栏自由添加
        /// </summary>
        public ObjectList CarLeftWidgets
        {
            get { return _carLeftWidgets; }
            set { _carLeftWidgets = value; }
        }

        private ObjectList  _userLeftWidgets;
        /// <summary>
        /// 会员中心侧边
        /// </summary>
        public ObjectList  UserLeftWidgets
        {
            get { return _userLeftWidgets; }
            set { _userLeftWidgets = value; }
        }
	

        private ObjectList _contentWidgets;
        /// <summary>
        /// 首页内容插件，可在内容区自由添加
        /// </summary>
        public ObjectList ContentWidgets
        {
            get { return _contentWidgets; }
            set { _contentWidgets = value; }
        }
        public string DefaultPageTitle
        {
            get { return System.Configuration.ConfigurationSettings.AppSettings["page_title"]; }
        }

        public string DefaultPageKeyword
        {
            get { return System.Configuration.ConfigurationSettings.AppSettings["page_keyword"]; }
        }

        public string DefaultPageDescription
        {
            get { return System.Configuration.ConfigurationSettings.AppSettings["page_description"]; }
        }

        public string LoginLink
        {
            get { return System.Configuration.ConfigurationSettings.AppSettings["loginlink"]; }
        }

        string _appRoot = "/";
        public string AppRoot
        {
            get
            {
                return _appRoot;
            }
        }

        public static SysSetting GetSetting()
        {

            return Nested.instance;
        }

        class Nested
        {
            static Nested() { }
            internal static readonly SysSetting instance = new SysSetting();
        }

    }



}
