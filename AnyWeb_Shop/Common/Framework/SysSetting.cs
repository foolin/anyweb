using System;
using System.Collections.Generic;
using System.Text;

using Studio.Data;
using Studio.Security;
using Studio.Array;

namespace Common.Framework
{
    /// <summary>
    /// ����,������ȡ�����ַ���
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
        /// ��������б�
        /// </summary>
        public ObjectList Typies
        {
            get { return _typies; }
            set { _typies = value; }
        }

        private ObjectList _skins;
        /// <summary>
        /// �̵�ģ���б�
        /// </summary>
        public ObjectList Skins
        {
            get { return _skins; }
            set { _skins = value; }
        }

        private ObjectList _sysWidgets;
        /// <summary>
        /// ϵͳ���������������ӣ�
        /// </summary>
        public ObjectList SysWidgets
        {
            get { return _sysWidgets; }
            set { _sysWidgets = value; }
        }

        private ObjectList _leftWidgets;
        /// <summary>
        /// ��ҳ������������ڲ����������
        /// </summary>
        public ObjectList LeftWidgets
        {
            get { return _leftWidgets; }
            set { _leftWidgets = value; }
        }

        private ObjectList _listLeftWidgets;
        /// <summary>
        /// �б�ҳ������������ڲ����������
        /// </summary>
        public ObjectList ListLeftWidgets
        {
            get { return _listLeftWidgets; }
            set { _listLeftWidgets = value; }
        }

        private ObjectList _articleLeftWidgets;
        /// <summary>
        /// ����ҳ������������ڲ����������
        /// </summary>
        public ObjectList ArticleLeftWidgets
        {
            get { return _articleLeftWidgets; }
            set { _articleLeftWidgets = value; }
        }


        private ObjectList _goodsLeftWidgets;
        /// <summary>
        /// ��Ʒҳ������������ڲ����������
        /// </summary>
        public ObjectList GoodsLeftWidgets
        {
            get { return _goodsLeftWidgets; }
            set { _goodsLeftWidgets = value; }
        }

        private ObjectList _carLeftWidgets;
        /// <summary>
        /// ���ﳵҳ������������ڲ����������
        /// </summary>
        public ObjectList CarLeftWidgets
        {
            get { return _carLeftWidgets; }
            set { _carLeftWidgets = value; }
        }

        private ObjectList  _userLeftWidgets;
        /// <summary>
        /// ��Ա���Ĳ��
        /// </summary>
        public ObjectList  UserLeftWidgets
        {
            get { return _userLeftWidgets; }
            set { _userLeftWidgets = value; }
        }
	

        private ObjectList _contentWidgets;
        /// <summary>
        /// ��ҳ���ݲ���������������������
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
