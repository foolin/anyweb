using System;
using System.Collections.Generic;
using System.Text;

using Common.Framework;

using Studio.Data;
using System.Web;
using Common.Common;
namespace Common.Agent
{
    public class AgentBase:DbAgent
    {
        public AgentBase() : base(DatabaseType.SqlServer, SysSetting.GetSetting().ConnectionString) { }

        protected Common.Shop ShopInfo
        {
            get
            {
                
                Shop s = (Common.Shop)HttpContext.Current.Items["SHOP_INFO"];

                if ( s != null )
                {
                    return s;
                }
                else
                {
                    HttpCookie c = new HttpCookie( "SHOP_ID" );

                    if ( HttpContext.Current.Request.Cookies["SHOP_ID"] != null )
                    {
                        return  ( new ShopAgent() ).GetShopInfo( int.Parse( HttpContext.Current.Request.Cookies["SHOP_ID"].Value ) );
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        private void Shop(Shop shop)
        {
            throw new Exception( "The method or operation is not implemented." );
        }

        protected User UserInfo
        {
            get
            {
                if ( HttpContext.Current.Request.Cookies["USER_ID"] == null )
                {
                    return null;
                }
                else
                {
                    if ( HttpRuntime.Cache[ShopInfo.ID.ToString() + "USER_INFO_" + HttpContext.Current.Request.Cookies["USER_ID"].Value] != null )
                    {

                        return (User)HttpRuntime.Cache[ShopInfo.ID.ToString() + "USER_INFO_" + HttpContext.Current.Request.Cookies["USER_ID"].Value];
                    }
                    else
                    {
                        return ( new UserAgent() ).GetUserInfoWeb(int.Parse(HttpContext.Current.Request.Cookies["USER_ID"].Value) );
                    }
                }
            }
        }
    }
}
