using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using Studio.Array;
using Studio.Data;

using Common.Framework;
using Common.Common;
using Studio.Web;
using Studio.Security;

namespace Common.Agent
{
    /// <summary>
    /// �̵����־ҵ�����ݲ���
    /// </summary>
    public class ShopAgent:AgentBase
    {
        /// <summary>
        /// ��ȡ�̵���ϸ��Ϣ(������ǰ̨��Ϣ)
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public Shop GetShopInfo(int shopid)
        {
           
           Shop s = (Shop)HttpRuntime.Cache["SHOP_" + shopid.ToString()];

           if (s != null)
           {
               return s;
           }
            
            DataSet ds = new DataSet();


            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure,"Shop_GetShopInfo",
                                        this.NewParam("@ShopID",shopid));
            }

            //����̵겻����
            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            //��ʼ��ShopInfo����
            s = new Shop(ds.Tables[0].Rows[0]);
            s.Categorys = new CategoryAgent().GetCategorys(shopid);

            HttpRuntime.Cache.Insert("SHOP_" + shopid.ToString(), s, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(5));

            return s;
        }

        /// <summary>
        /// ���seo��Ϣ
        /// </summary>
        /// <returns></returns>
        public Shop GetSeoInfo()
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetSeoInfo" ,
                                this.NewParam( "@ShopID" , ShopInfo.ID ) );
            }
            if ( ds.Tables[0].Rows.Count > 0 )
            {
                DataRow dr = ds.Tables[0].Rows[0];

                Shop s = new Shop();
                s.ID = (int)dr["ShopID"];
                s.DescriptionExt = (string)dr["DescriptionExt"];
                s.TitleExt = (string)dr["TitleExt"];
                s.KeywordExt = (string)dr["KeywordExt"];

                return s;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��ȡǰ̨��Ҫ���̵���Ϣ(ǰ̨��Ϣ)
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public Shop GetShopInfoWeb(int shopid)
        {
            //��ȡ����
            Shop s = (Shop)HttpRuntime.Cache["SHOP_" + shopid.ToString()];

            if (s != null)
            {
                return s;
            }

            
            DataSet ds = new DataSet();

            using (IDbExecutor db = this.NewExecutor())
            {
                ds =  db.GetDataSet(CommandType.StoredProcedure, "Shop_GetShopInfoWeb",
                                this.NewParam("@ShopID",shopid));
            }

            if (ds.Tables[0].Rows.Count != 1)
            {
                return null;
            }

            //��ȡ���
            s = new Shop(ds.Tables[0].Rows[0]);

            //��ȡ��Ŀ
            s.Categorys = new ObjectList();
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Category c = new Category(dr);
                c.OfShop = s;
                s.Categorys.Add(c);
            }

            //��ȡ���
            s.LeftWidgets = new ObjectList();
            s.ContentWidgets = new ObjectList();
            s.ListLeftWidgets = new ObjectList();
            s.GoodsLeftWidgets = new ObjectList();
            s.ArticleLeftWidgets = new ObjectList();
            s.OrderLeftWidgets = new ObjectList();
            s.UserLeftWidgets = new ObjectList();

            //��������
            s.Links = new ObjectList();

            foreach (DataRow dr in ds.Tables[3].Rows)
            {
                Link l = new Link(dr);
                l.OfShop = s;

                s.Links.Add(l);
            }

            //����
            s.AfficheList = new ObjectList();

            foreach (DataRow dr in ds.Tables[4].Rows)
            {

                Affiche a = new Affiche();

                a.ID = (int)dr["AfficheID"];
                a.Title = (string)dr["Title"];
                a.CreateAt = (DateTime)dr["CreateAt"];
                a.Type = (int)dr["Type"];
                a.MemberID = (int)dr["MemberID"];
                a.OfShop = s;
                s.AfficheList.Add(a);
            }

            //���
            s.Advertisement = new ObjectList();

            foreach (DataRow dr in ds.Tables[5].Rows)
            {
                Advertisement ad = new Advertisement(dr);
                ad.OfShop = s;

                s.Advertisement.Add(ad);
            }
           
            HttpRuntime.Cache.Insert("SHOP_" + shopid.ToString(), s, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(5));

            return s;

        }

        /// <summary>
        /// �����̵����� ��ȡ�̵���
        /// </summary>
        /// <param name="shopacc">�̵�����</param>
        /// <returns></returns>
        public int GetShopID(string shopacc)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteProcedure("Shop_GetIndieShopID",
                                    this.NewParam("@ShopAcc", shopacc));
            }
        }

        /// <summary>
        /// �������
        /// </summary>
        public void RefreshShop(int shopid)
        {
            string key = ShopInfo.ID.ToString();
            
            HttpRuntime.Cache.Remove( "NewGoods_" + key);
            HttpRuntime.Cache.Remove( "GetCommend_" + key);
            HttpRuntime.Cache.Remove( "GetTopGoods_" + key);
            HttpRuntime.Cache.Remove( "GetHotGoods_" + key);
            HttpRuntime.Cache.Remove("SHOP_" + key);
        }

        /// <summary>
        /// ��û�����Ϣ
        /// </summary>
        /// <returns></returns>
        public Shop GetShopBasicInfo()
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetShopBasicInfo" ,
                                this.NewParam( "@ShopID" , ShopInfo.ID ) );
            }
            if ( ds.Tables[0].Rows.Count > 0 )
            {
                DataRow dr = ds.Tables[0].Rows[0];

                Shop s = new Shop();
                s.ID = (int)dr["ShopID"];
                s.ShopAcc = (string)dr["ShopAcc"];
                s.ShopMaster = (string)dr["ShopMaster"];
                s.PostCode = (string)dr["PostCode"];
                s.TelePhone = (string)dr["TelePhone"];
                s.Mobile = (string)dr["Mobile"];
                s.Name = (string)dr["ShopName"];
                s.Logo = (string)dr["Logo"];
                s.Fax = (string)dr["Fax"];
                s.EmailSend = (string)dr["EmailSend"];
                s.EmailPass = (string)dr["EmailPass"];
                s.EmailContent = dr["EmailContent"] == System.DBNull.Value ? "" : (string)dr["EmailContent"];
                s.Email = (string)dr["Email"];
                s.Address = (string)dr["Address"];
                s.AdminAcc = (string)dr["AdminAcc"];
                s.AdminPass = (string)dr["AdminPass"];
                s.DomainName = dr["DomainName"] == System.DBNull.Value ? "" : (string)dr["DomainName"];

                return s;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// �޸Ļ�������
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int UpdateBasicInfo( Shop s)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
               return  db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_BasicInfoUpdate" ,
                                this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                this.NewParam("@ShopMaster",s.ShopMaster),
                                this.NewParam("@PostCode",s.PostCode),
                                this.NewParam("@TelePhone",s.TelePhone),
                                this.NewParam("@ShopName",s.Name),
                                this.NewParam("@Logo",s.Logo),
                                this.NewParam("@Fax",s.Fax),
                                this.NewParam("@Address",s.Address),
                                this.NewParam("@Mobile",s.Mobile ) );

               ShopInfo.ShopMaster = s.ShopMaster;
               ShopInfo.PostCode = s.PostCode;
               ShopInfo.Address = s.Address;
               ShopInfo.TelePhone = s.TelePhone;
               ShopInfo.Logo = s.Logo;
               ShopInfo.Fax = s.Fax;
               ShopInfo.Mobile = s.Mobile;
               ShopInfo.Name = s.Name;

            }
        }

        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int UpdateAdminPass(Shop s)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                int count= db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_UpdateAdminPass" ,
                                         this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                         this.NewParam( "@AdminPass" , s.AdminPass ),
                                         this.NewParam("@AdminAcc",s.AdminAcc));
                if ( count > 0 )
                {
                    ShopInfo.AdminAcc = s.AdminAcc;
                    ShopInfo.AdminPass = s.AdminPass;
                }
                return count;

            }
        }

        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int SetMail(Shop s)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                int count = db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_MailUpdate" ,
                                         this.NewParam( "@EmailSend" , s.EmailSend ) ,
                                         this.NewParam( "@EmailPass" , s.EmailPass ) ,
                                         this.NewParam( "@EmailContent" , s.EmailContent ),
                                         this.NewParam( "@Email",s.Email ),
                                         this.NewParam("@ShopID",ShopInfo.ID));
                if ( count > 0 )
                {
                    ShopInfo.Email = s.Email;
                    ShopInfo.EmailContent = s.EmailContent;
                    ShopInfo.EmailPass = s.EmailPass;
                    ShopInfo.EmailSend = s.EmailSend;
                }

                return count;
            }
        }

        /// <summary>
        /// �༭��������
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int UpdateAboutUs(Shop s)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                int count = db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_AboutUsUpdate" ,
                                        this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                        this.NewParam( "@AboutUs" , s.AboutUs ) );
                if ( count > 0 )
                {
                    ShopInfo.AboutUs = s.AboutUs;
                    HttpRuntime.Cache["SHOP_" + ShopInfo.ID] = ShopInfo;
                }
                return count;
            }
        }

        /// <summary>
        /// �༭�˻�������
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int UpdateService(Shop s)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                int count = db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_ShopServiceUpdate",
                                        this.NewParam("@ShopID", ShopInfo.ID),
                                        this.NewParam("@Service", s.AboutUs));
                if (count > 0)
                {
                    ShopInfo.AboutUs = s.AboutUs;
                    HttpRuntime.Cache["SHOP_" + ShopInfo.ID] = ShopInfo;
                }
                return count;
            }
        }
        
        
        /// <summary>
        /// �༭��ϵ����
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int UpdateContactUs(Shop s)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                int count = db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_ContactUsUpdate" ,
                                        this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                        this.NewParam( "@InterosculateUs" , s.InterosculateUs ) );
                if ( count > 0 )
                {
                    ShopInfo.InterosculateUs = s.InterosculateUs;
                    HttpRuntime.Cache["SHOP_" + ShopInfo.ID] = ShopInfo;
                }

                return count;
               
            }
        }

        /// <summary>
        /// �޸�ҳ��
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int UpdateFooter(Shop s)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                int count = db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_FooterUpdate" ,
                                        this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                        this.NewParam( "@Footer" , s.Footer ) );

                if ( count > 0 )
                {
                    ShopInfo.Footer = s.Footer;
                    HttpRuntime.Cache["SHOP_" + ShopInfo.ID] = ShopInfo;
                }

                return count;


            }
        }

        /// <summary>
        /// �޸�ҳͷ
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int UpdateHeader(Shop s)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                int count = db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_HeaderUpdate" ,
                                        this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                        this.NewParam( "@Header" , s.Header ) );

                if ( count > 0 )
                {
                    ShopInfo.Header = s.Header;
                    HttpRuntime.Cache["SHOP_" + ShopInfo.ID] = ShopInfo;
                }

                return count;


            }
        }

        /// <summary>
        /// ��½
        /// </summary>
        /// <param name="shopacc"></param>
        /// <param name="adminacc"></param>
        /// <param name="adminpass"></param>
        /// <returns></returns>
        public int AdminLogin(string adminacc,string adminpass)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteProcedure("Shop_AdminLogin",
                                    this.NewParam("@AdminAcc",adminacc),
                                    this.NewParam("@AdminPass",Studio.Security.Secure.Md5(adminpass)));
            }
 
        }

        /// <summary>
        /// �༭Seo
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int SeoEdit(Shop s)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                int value = db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_SeoEdit",
                                        this.NewParam("@TitleExt",s.TitleExt),
                                        this.NewParam("@DescriptionExt",s.DescriptionExt),
                                        this.NewParam("@KeywordExt",s.KeywordExt),
                                        this.NewParam("@ShopID",ShopInfo.ID));
                if ( value > 0 )
                {
                    ShopInfo.TitleExt = s.TitleExt;
                    ShopInfo.DescriptionExt = s.DescriptionExt;
                    ShopInfo.KeywordExt = s.KeywordExt;
                }
                return value;
            }
        }

        /// <summary>
        ///  ��������ͨ��Ż�ȡ�̳���Ϣ
        /// </summary>
        /// <param name="comid"></param>
        /// <returns></returns>
        public Shop GetShopInfoByComID(int comid,out int status)
        {
            Shop s = (Shop)HttpRuntime.Cache["ComID_" + comid.ToString()];

            if (s != null)
            {
                status = 0;
                return s;
            }

            DataSet ds = new DataSet();

            IDbDataParameter record = this.NewParam("@Status", 0, DbType.Int32, 8, true);
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetShopInfoByComID",
                                        this.NewParam("@ComID", comid),
                                        record);

                status = (int)record.Value;
            }

            //����̵겻����
            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            //��ʼ��ShopInfo����
            s = new Shop(ds.Tables[0].Rows[0]);

            HttpRuntime.Cache.Insert("ComID_" + comid.ToString(), s, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(5));

            return s;
        }

        /// <summary>
        /// ɾ����˾logo
        /// </summary>
        /// <returns></returns>
        public int DelShopLog()
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_ShopLogDelete" ,
                                    this.NewParam( "@ShopID" , ShopInfo.ID));
            }
        }


        /// <summary>
        /// �Ƿ���ʾ�̳�ָ��
        /// </summary>
        /// <returns></returns>
        public int updateShowHelp(bool ischeck)
        { 
            using ( IDbExecutor db = this.NewExecutor() )
            {
                int returnvalue= db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_UpdateShowHelp" ,
                                    this.NewParam( "@ShopID" , ShopInfo.ID),
                                    this.NewParam("@IsCheck",ischeck));

                if ( returnvalue > 0 )
                {
                    ShopInfo.ShowHelp = ischeck;
                }
                return returnvalue;
            }
        }

        /// <summary>
        /// ��ͨ�̳�
        /// </summary>
        /// <param name="shopname"></param>
        /// <param name="shopmaster"></param>
        /// <param name="typeid"></param>
        /// <param name="skinid"></param>
        /// <param name="comid"></param>
        /// <param name="skinshopid"></param>
        /// <returns></returns>
        public int ShopRegaist(int typeid,int skinid,int comid,int skinshopid)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {     
                return db.ExecuteProcedure( "Shop_Regist" ,
                    this.NewParam( "@TypeID" , typeid ) ,
                    this.NewParam( "@SkinID" , skinid ) ,
                    this.NewParam( "@ComID" , comid ) ,
                    this.NewParam( "@SkinShopID" , skinshopid ) );
            }
        }

        /// <summary>
        /// �������ͨ�汾
        /// </summary>
        /// <param name="comid"></param>
        /// <returns></returns>
        public int GetComVersion(int comid)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
               return db.ExecuteProcedure( "Shop_GetComVersion" ,
                                this.NewParam("@ComID" ,comid));
            }
        }

    }
}
