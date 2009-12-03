using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Studio.Array;

namespace Common.Common
{
    /// <summary>
    /// 各商城的注册协议
    /// </summary>
   public class Agreement:IdObject 
    {
       public  Agreement() { }
       public  Agreement(DataRow dr)
       {
           _id = (int)dr["AgreementID"];
           _content = (string)dr["Content"];
           _shopID = (int)dr["ShopID"];
       }

       private int _id;

       public int ID
       {
           get { return _id; }
           set { _id = value; }
       }

       private int _shopID;

       public int ShopID
       {
           get { return _shopID; }
           set { _shopID = value; }
       }

       private string _content;

       public string Content
       {
           get { return _content; }
           set { _content = value; }
       }

       private Shop _ofShop;

       public Shop OfShop
       {
           get { return _ofShop; }
           set { _ofShop = value; }
       }
	

    }
}
