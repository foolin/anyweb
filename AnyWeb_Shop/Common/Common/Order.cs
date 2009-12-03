using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;
using System.Web;

namespace Common.Common
{
    public  class Order:IdObject
    {

        public Order() { }

        public Order(DataRow dr)
        {
            this.ID = (int)dr["OrderID"];
            this._shopID = (int)dr["ShopID"];
            this._userID = (int)dr["UserID"];
            this._userName = (string)dr["UserName"];
            this._userPhone = (string)dr["UserPhone"];
            this._userEmail = (string)dr["UserEmail"];
            this._status = (int)dr["Status"];
            this._remark = dr["Remark"] == System.DBNull.Value ? "" : (string)dr["Remark"];
            this._price = (double)dr["Price"];
            this._postalcode = (string)dr["Postalcode"];
            this._paymentPrice = (double)dr["PaymentPrice"];
            this._deliverPrice = (double)dr["DeliverPrice"];
            this._paymentModeID = (int)dr["PaymentModeID"];
            this._deliverModeID = (int)dr["DeliverModeID"];
            this._createAt = (DateTime)dr["CreateAt"];
            this._address = (string)dr["Address"];
            this._deliverTime = (DateTime)dr["DeliverTime"];
            this._mobile = (string)dr["Mobile"];
            this._cancleReson = dr["CancleReson"] == System.DBNull.Value ? "" : (string)dr["CancleReson"];
        }

        private int _shopID;
        /// <summary>
        /// 商店编号
        /// </summary>
        public int ShopID
        {
            get { return _shopID; }
            set { _shopID = value; }
        }

      

        private int _userID;
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private DateTime _createAt;
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }

        private double _price;
        /// <summary>
        /// 交易总额
        /// </summary>
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private int _status;
        /// <summary>
        /// 订单状态 1-未处理 2－已发货 3－取消发货 9－删除
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _userName;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _userEmail;
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string UserEmail
        {
            get { return _userEmail; }
            set { _userEmail = value; }
        }

        private string _userPhone;
        /// <summary>
        /// 用户固定电话
        /// </summary>
        public string UserPhone
        {
            get { return _userPhone; }
            set { _userPhone = value; }
        }

        private string _mobile;
        /// <summary>
        /// 移动电话
        /// </summary>
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        private string _address;
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _postalcode;
        /// <summary>
        /// 邮编
        /// </summary>
        public string Postalcode
        {
            get { return _postalcode; }
            set { _postalcode = value; }
        }

        private DateTime _deliverTime;
        /// <summary>
        /// 送货时间
        /// </summary>
        public DateTime DeliverTime
        {
            get { return _deliverTime; }
            set { _deliverTime = value; }
        }

        private string _remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private int _deliverModeID;
        /// <summary>
        /// 送货方式
        /// </summary>
        public int DeliverModeID
        {
            get { return _deliverModeID; }
            set { _deliverModeID = value; }
        }

        private int _paymentModeID;
        /// <summary>
        /// 支付方式
        /// </summary>
        public int PaymentModeID
        {
            get { return _paymentModeID; }
            set { _paymentModeID = value; }
        }

        private double _paymentPrice;
        /// <summary>
        /// 支付金额
        /// </summary>
        public double PaymentPrice
        {
            get { return _paymentPrice; }
            set { _paymentPrice = value; }
        }

        /// <summary>
        /// 支付总金额
        /// </summary>
        public double MathPaymentPrice
        {
            get 
            {
                double _mathPaymentPrice=0.0;
                if ( OfSendMode != null && OfPayMode != null )
                {

                    _mathPaymentPrice = this.OfPayMode.MathPayMent + this.OfSendMode.MathDeliver + this.MathPrice;

                }
                return _mathPaymentPrice;
            }
          
        }
	

        private ObjectList _orderItems;
        /// <summary>
        /// 订单项
        /// </summary>
        public ObjectList OrderItems
        {
            get { return _orderItems; }
            set { _orderItems = value; }
        }

        private ObjectList _changeList;
        /// <summary>
        /// 积分兑换项
        /// </summary>
        public ObjectList ChangeList
        {
            get { return _changeList; }
            set { _changeList = value; }
        }

        /// <summary>
        /// 商品总价格
        /// </summary>
        public double MathPrice
        {
            get 
            {
                double _mathprice=0;
                double _commentMath = 0;
                double _sMath = 0;


                Shop s = (Common.Shop)HttpContext.Current.Items["SHOP_INFO"];
                Agio a = s.OfAgio;

                if (a != null)
                {
                    foreach (Order_Item oi in OrderItems)
                    {

                        if (oi.OfGoods.IsRecommend == true)
                        {
                            _commentMath += oi.Price;
                        }
                        else
                        {
                            _mathprice += oi.Price;
                        }
                    }

                    if (a.Type == 1)
                    {
                        _sMath = _commentMath * a.Agiomoney / 10 + _mathprice;
                    }
                    else if (a.Type == 2 && _commentMath > a.Money)
                    {

                        _sMath = _commentMath * a.Agiomoney / 10 + _mathprice;
                    }
                    else
                    {
                        _sMath = _commentMath + _mathprice;
                    }

                }
                else
                {
                    foreach (Order_Item oi in OrderItems)
                    {
                        _sMath += oi.Price;
                        
                    }
                }

                return _sMath;
            }
        }

        /// <summary>
        /// 推荐商品的价格
        /// </summary>
        public double CommPrice
        {
            get 
            {
                double _commentMath = 0;
                foreach (Order_Item oi in OrderItems)
                {

                    if (oi.OfGoods.IsRecommend == true)
                    {
                        _commentMath += oi.Price;
                    }
                }

                return _commentMath;
            }
            
        }
	

        /// <summary>
        /// 优惠金额
        /// </summary>
        public double MathMarket
        {
            get
            {
                double _marketMath = 0;
               
                foreach (Order_Item oi in OrderItems)
                {
                   
                    
                    _marketMath += oi.MarketPrice;
                }

                return _marketMath - MathPrice;
            }
        }
        /// <summary>
        /// 用户信息
        /// </summary>
        private User _ofUser;

        public User OfUser
        {
            get { return _ofUser; }
            set { _ofUser = value; }
        }

        private Mode _ofPayMode;
        /// <summary>
        /// 支付方式
        /// </summary>
        public Mode OfPayMode
        {
            get { return _ofPayMode; }
            set { _ofPayMode = value; }
        }

        private Mode _ofSendMode;
        /// <summary>
        /// 送货方式
        /// </summary>
        public Mode OfSendMode
        {
            get { return _ofSendMode; }
            set { _ofSendMode = value; }
        }

        private double _deliverPrice;
        /// <summary>
        /// 支付金额
        /// </summary>
        public double DeliverPrice
        {
            get { return _deliverPrice; }
            set { _deliverPrice = value; }
        }

        private double  _totalPrice;
        /// <summary>
        /// 应付金额
        /// </summary>
        public double  TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        private string _cancleReson;
        /// <summary>
        /// 取消发货的原因
        /// </summary>
        public string CancleReson
        {
            get { return _cancleReson; }
            set { _cancleReson = value; }
        }

        /// <summary>
        /// 积分
        /// </summary>
        private int _score;

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        /// <summary>
        /// 总积分
        /// </summary>
        public int MathScore
        {
            get 
            {
                int _matgScore=0;
                foreach (Order_Item oi in this.OrderItems)
                {
                    _matgScore += oi.OfGoods.Score * oi.Quantity;
                }
                return _matgScore;
            }
        }

        /// <summary>
        /// 商品总重量
        /// </summary>
        public double MathWeight
        {
            get 
            {
                double _weight = 0;
                foreach (Order_Item oi in this.OrderItems)
                {
                    _weight += oi.OfGoods.Weight;
                }

                return _weight;
            }
        }
    }
}
