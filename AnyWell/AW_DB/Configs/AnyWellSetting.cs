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
