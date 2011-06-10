using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using Studio.Web;
using Studio.Security;

namespace AnyWell.AW_DL
{
    public class LicenseConfig
    {
        public LicenseConfig()
        {
            if (!File.Exists(_licenseFile)) 
            {
                WebAgent.AlertAndBack("该域名没有访问权限，请联系开发商！");
            }
            string key = "";
            try
            {
                key = Secure.Decrypt(File.ReadAllText(_licenseFile));
            }
            catch (Exception)
            {
                WebAgent.AlertAndBack("许可证不合法，请联系开发商！");
            }
            if (key.Trim().Length == 0) 
            {
                WebAgent.AlertAndBack("许可证不合法，请联系开发商！");
            }
            DomailList = new List<string>();
            foreach (string str in key.Split(',')) 
            {
                DomailList.Add(str);
            }
            if (DomailList.Count == 0)
            {
                WebAgent.AlertAndBack("该域名没有访问权限，请联系开发商！");
            }
        }

        public void CheckDomain(string domain)
        {
            if (!DomailList.Contains(domain.ToLower()))
            {
                WebAgent.AlertAndBack("该域名没有访问权限，请联系开发商！");
            }
        }

        private static object lockHelper = new object();
        private static volatile LicenseConfig instance = null;
        string _licenseFile = HttpContext.Current.Server.MapPath("~/App_Data/License.key");

        public static LicenseConfig GetAgent()
        {
            if (instance == null)
            {
                lock (lockHelper)
                {
                    if (instance == null)
                    {
                        instance = new LicenseConfig();
                    }
                }
            }
            return instance;

        }

        public static void SetInstance(LicenseConfig anInstance)
        {
            if (anInstance != null)
                instance = anInstance;
        }

        public static void SetInstance()
        {
            SetInstance(new LicenseConfig());
        }

        public List<string> DomailList { get; set; }
    }
}
