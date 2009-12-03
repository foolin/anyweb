using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Studio.Array;
namespace Common.Common
{
    /// <summary>
    /// 会员
    /// </summary>
   public class Member : IdObject 
    {
       public  Member(){}

       public  Member(DataRow dr)
       {
           _id = (int)dr["MemberID"];
           _memberAcc = (string)dr["MemberAcc"];
           _memberName = (string)dr["MemberName"];
           _memberPass = (string)dr["MemberPass"];
           _createAt = (DateTime)dr["CreateAt"];
           _shopID = (int)dr["ShopID"];
           _status = (bool)dr["Status"];
           _sex = (string)dr["Sex"];
           _photo = (string)dr["Photo"];
           _phone = (string)dr["Phone"];
           _qq = (string)dr["QQ"];
           _msn = (string)dr["MSN"];
           _otherContact = (string)dr["OtherContace"];
           _address = (string)dr["Address"];
           _advance = (decimal)dr["Advance"];
           _mobile = (string)dr["Mobile"];
           _email = (string)dr["Email"];
           _point = (int)dr["Point"];
           this._freezeReson = dr["FreezeReson"] == System.DBNull.Value ? "" : (string)dr["FreezeReson"];


       }

       private int _id;

       public int Id
       {
           get { return _id; }
           set { _id = value; }
       }

       private string _memberAcc;

       public string MemberAcc
       {
           get { return _memberAcc; }
           set { _memberAcc = value; }
       }

       private string _memberPass;

       public string MemberPass
       {
           get { return _memberPass; }
           set { _memberPass = value; }
       }

       private string _memberName;

       public string MemberName
       {
           get { return _memberName; }
           set { _memberName = value; }
       }

       private DateTime _createAt;

       public DateTime CreateAt
       {
           get { return _createAt; }
           set { _createAt = value; }
       }

       private int _shopID;

       public int ShopID
       {
           get { return _shopID; }
           set { _shopID = value; }
       }

       private bool _status;

       public bool Status
       {
           get { return _status; }
           set { _status = value; }
       }

       private string _sex;

       public string Sex
       {
           get { return _sex; }
           set { _sex = value; }
       }


       private string _photo;

       public string Photo
       {
           get { return _photo; }
           set { _photo = value; }
       }

       private string _address;

       public string Address
       {
           get { return _address; }
           set { _address = value; }
       }

       private string _mobile;

       public string Mobile
       {
           get { return _mobile; }
           set { _mobile = value; }
       }

       private string _phone;

       public string Phone
       {
           get { return _phone; }
           set { _phone = value; }
       }

       private string _email;

       public string Email
       {
           get { return _email; }
           set { _email = value; }
       }

       private string _qq;

       public string QQ
       {
           get { return _qq; }
           set { _qq = value; }
       }


       private string _msn;

       public string Msn
       {
           get { return _msn; }
           set { _msn = value; }
       }

       private string _otherContact;

       public string OtherContact
       {
           get { return _otherContact; }
           set { _otherContact = value; }
       }

       private int _point;

       public int Point
       {
           get { return _point; }
           set { _point = value; }
       }

       private decimal _advance;

       public decimal Advance
       {
           get { return _advance; }
           set { _advance = value; }
       }

       private string _freezeReson;
        /// <summary>
        /// 冻结原因
        /// </summary>
       public string FreezeReson
       {
           get { return _freezeReson; }
           set { _freezeReson = value; }
       }

	
    }

}
