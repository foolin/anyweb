using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace AnyWell.AW_DL
{
    /// <summary>
    /// 用户登陆会话信息,从主系统的Cookie中检索
    /// </summary>
    public class UserCookie
    {
        private int _userID;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private string _userName;
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private List<Site> _managedSites;

        public List<Site> ManagedSites
        {
            get { return _managedSites; }
            set { _managedSites = value; }
        }

        private string _managedSiteIDs;

        public string ManagedSiteIDs
        {
            get { return _managedSiteIDs; }
            set { _managedSiteIDs = value; }
        }


        /// <summary>
        /// 获取当前登陆的用户信息
        /// </summary>
        public static UserCookie Current
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    HttpCookie co = HttpContext.Current.Request.Cookies["USER"];
                    if (co != null)
                    {
                        UserCookie uc = new UserCookie();
                        uc.UserID = int.Parse(co.Values["propUserID"]);
                        uc.UserName = HttpUtility.UrlDecode(co.Values["propUserName"]);
                        uc.ManagedSites = new List<Site>();
                        if (co.Values["propSiteIDs"] != null)
                        {
                            uc.ManagedSiteIDs = HttpUtility.UrlDecode(co.Values["propSiteIDs"]);
                            string[] siteIDs = HttpUtility.UrlDecode(co.Values["propSiteIDs"]).Split(',');
                            string[] siteNames = HttpUtility.UrlDecode(co.Values["propSiteNames"]).Split(',');
                            for (int i = 0; i < siteIDs.Length; i++)
                            {
                                uc.ManagedSites.Add(new Site(int.Parse(siteIDs[i]), siteNames[i]));
                            }
                        }
                        return uc;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 站点基本信息
        /// </summary>
        public class Site
        {
            public Site(int id, string name)
            {
                _id = id;
                _name = name;
            }

            private int _id;

            public int ID
            {
                get { return _id; }
                set { _id = value; }
            }

            private string _name;

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

        }
    }
}
