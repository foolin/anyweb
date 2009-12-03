using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    public  class User:IdObject
    {
        public User() { }

        public User(DataRow dr)
        {
            this.ID = (int)dr["MemberID"];
            this._memberAcc = (string)dr["MemberAcc"];
            this._address = (string)dr["Address"];
            this._advance = (decimal)dr["Advance"];
            this._createat = (DateTime)dr["CreateAt"];
            this._email = (string)dr["Email"];
            this._memberName = (string)dr["MemberName"];
            this._memberPass = (string)dr["MemberPass"];
            this._mobile = (string)dr["Mobile"];
            this._msn = (string)dr["MSN"];
            this._ofShop = new Shop();
            this._otherContact = (string)dr["OtherContact"];
            this._phone = (string)dr["Phone"];
            this._photo = (string)dr["Photo"];
            this._point = (int)dr["Point"];
            this._sparePoint = (int)dr["SparePoint"];
            this._qq = (string)dr["QQ"];
            this._sex = (int)dr["Sex"];
            this._status = (short)dr["Status"];
            this._postalcode = (string)dr["Postalcode"];
            this._freezeReson = dr["FreezeReson"] == System.DBNull.Value ? "" : (string)dr["FreezeReson"];

        }

        /// <summary>
        /// 登陆帐号
        /// </summary>
        private string _memberAcc;

        public string MemberAcc
        {
            get { return _memberAcc; }
            set { _memberAcc = value; }
        }

        /// <summary>
        /// 密码
        /// </summary>
        private string  _memberPass;

        public string  MemberPass
        {
            get { return _memberPass; }
            set { _memberPass = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        private string _memberName;

        public string MemberName
        {
            get { return _memberName; }
            set { _memberName = value; }
        }

        /// <summary>
        /// 注册时间
        /// </summary>
        private DateTime _createat;

        public DateTime CreateAt
        {
            get { return _createat; }
            set { _createat = value; }
        }

        /// <summary>
        /// 所属商店
        /// </summary>
        private Shop _ofShop;

        public Shop OfShop
        {
            get { return _ofShop; }
            set { _ofShop = value; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        private short _status;

        public short Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// 性别
        /// </summary>
        private int _sex;

        public int Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        /// <summary>
        /// 头像
        /// </summary>
        private string _photo;

        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        /// <summary>
        /// 地址
        /// </summary>
        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        /// <summary>
        /// 移动电话
        /// </summary>
        private string _mobile;

        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        /// <summary>
        /// 电话
        /// </summary>
        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _registeremail;
        /// <summary>
        /// 注册邮箱
        /// </summary>
        public string RegisterEmail
        {
            get { return _registeremail; }
            set { _registeremail = value; }
        }


        /// <summary>
        /// QQ号码
        /// </summary>
        private string _qq;

        public string QQ
        {
            get { return _qq; }
            set { _qq = value; }
        }

        /// <summary>
        /// MSN
        /// </summary>
        private string _msn;

        public string MSN
        {
            get { return _msn; }
            set { _msn = value; }
        }

        /// <summary>
        /// 其它联系方式
        /// </summary>
        private string _otherContact;

        public string OtherContact
        {
            get { return _otherContact; }
            set { _otherContact = value; }
        }

        /// <summary>
        /// 总积分
        /// </summary>
        private int _point;

        public int Point
        {
            get { return _point; }
            set { _point = value; }
        }
        
        private int _sparePoint;
        /// <summary>
        /// 现有积分
        /// </summary>
        public int SparePoint
        {
            get { return _sparePoint; }
            set { _sparePoint = value; }
        }


        /// <summary>
        /// 预付款
        /// </summary>
        private decimal _advance;

        public decimal Advance
        {
            get { return _advance; }
            set { _advance = value; }
        }

        /// <summary>
        /// 邮政编码
        /// </summary>
        private string _postalcode;

        public string Postalcode
        {
            get { return _postalcode; }
            set { _postalcode = value; }
        }


        private string _gradeName;
        /// <summary>
        /// 等级名称
        /// </summary>
        public string GradeName
        {
            get { return _gradeName; }
            set { _gradeName = value; }
        }

        private int _gradeid;
        /// <summary>
        /// 会员等级
        /// </summary>
        public int GradeID
        {
            get { return _gradeid; }
            set { _gradeid = value; }
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
