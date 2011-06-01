using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace AnyWell.AW_DL
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public class AnyWellSetting
    {
        public AnyWellSetting()
        {
            this.Initialize();
        }

        public void Initialize()
        {
            if( !string.IsNullOrEmpty( ConfigurationManager.AppSettings[ "DataPath" ] ) )
            {
                this.DataRootPath = ConfigurationManager.AppSettings[ "DataPath" ];
            }
        }

        private string _DataRootPath = "/Files";
        /// <summary>
        /// 附件存放路径
        /// </summary>
        public string DataRootPath
        {
            get
            {
                return _DataRootPath;
            }
            set
            {
                _DataRootPath = value;
            }
        }

        private string[] _ColumnType;
        /// <summary>
        /// 栏目类型
        /// </summary>
        public string[] ColumnType
        {
            get
            {
                if( _ColumnType == null )
                {
                    _ColumnType = new string[] { "0:文档栏目", /*"1:产品栏目", "2:图片栏目",*/ "3:单篇文档栏目", "10:参展商栏目" };
                }
                return _ColumnType;
            }
        }

        public static AnyWellSetting GetSetting()
        {
            return Nested.instance;
        }
        class Nested
        {
            static Nested()
            {
            }
            internal static readonly AnyWellSetting instance = new AnyWellSetting();
        }
    }
}
