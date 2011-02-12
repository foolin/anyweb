using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Order_bean : Bean_Base
	{
		private int _fdOrdeID = 0;
		/// <summary>
		/// 订单编号
		/// </summary>
		public int fdOrdeID
		{
			get{return _fdOrdeID;}
			set{_fdOrdeID = value;}
		}

		private string _fdOrdeNO = "";
		/// <summary>
		/// 订单编号（保证唯一，用当前时间ToString("yyyyMMddHHmmss")加上4位随机数） 50 varchar
		/// </summary>
		public string fdOrdeNO
		{
			get{return _fdOrdeNO;}
			set{_fdOrdeNO = value;}
		}

		private int _fdOrdeMemberID = 0;
		/// <summary>
		/// 会员编号
		/// </summary>
		public int fdOrdeMemberID
		{
			get{return _fdOrdeMemberID;}
			set{_fdOrdeMemberID = value;}
		}

		private DateTime _fdOrdeCreateAt = DateTime.Now;
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime fdOrdeCreateAt
		{
			get{return _fdOrdeCreateAt;}
			set{_fdOrdeCreateAt = value;}
		}

		private string _fdOrderNote = "";
		/// <summary>
		/// 用户备注信息 400 nvarchar
		/// </summary>
		public string fdOrderNote
		{
			get{return _fdOrderNote;}
			set{_fdOrderNote = value;}
		}

		private float _fdOrdeGoodsPrice = 0;
		/// <summary>
		/// 各货品实际价格
		/// </summary>
		public float fdOrdeGoodsPrice
		{
			get{return _fdOrdeGoodsPrice;}
			set{_fdOrdeGoodsPrice = value;}
		}

		private float _fdOrdePayPrice = 0;
		/// <summary>
		/// 实际付款金额,默认等于总价加上邮费
		/// </summary>
		public float fdOrdePayPrice
		{
			get{return _fdOrdePayPrice;}
			set{_fdOrdePayPrice = value;}
		}

		private string _fdOrdeRemark = "";
		/// <summary>
		/// 备注，如果货品总价加上邮费和付款价格不相同必填 200 varchar
		/// </summary>
		public string fdOrdeRemark
		{
			get{return _fdOrdeRemark;}
			set{_fdOrdeRemark = value;}
		}

		private int _fdOrdeStatus = 1;
		/// <summary>
		/// 状态：新增待支付、已支付待发货、已发货待确认、已确认完成、缺货登记、用户取消、测试无效
		/// </summary>
		public int fdOrdeStatus
		{
			get{return _fdOrdeStatus;}
			set{_fdOrdeStatus = value;}
		}

		private string _fdOrdeUserName = "";
		/// <summary>
		/// 用户名称 50 varchar
		/// </summary>
		public string fdOrdeUserName
		{
			get{return _fdOrdeUserName;}
			set{_fdOrdeUserName = value;}
		}

		private string _fdOrdeUserEmail = "";
		/// <summary>
		/// 联系邮件 50 varchar
		/// </summary>
		public string fdOrdeUserEmail
		{
			get{return _fdOrdeUserEmail;}
			set{_fdOrdeUserEmail = value;}
		}

		private string _fdOrdeUserPhone = "";
		/// <summary>
		/// 联系电话 50 varchar
		/// </summary>
		public string fdOrdeUserPhone
		{
			get{return _fdOrdeUserPhone;}
			set{_fdOrdeUserPhone = value;}
		}

		private string _fdOrdeUserMobile = "";
		/// <summary>
		/// 联系手机 50 varchar
		/// </summary>
		public string fdOrdeUserMobile
		{
			get{return _fdOrdeUserMobile;}
			set{_fdOrdeUserMobile = value;}
		}

		private int _fdOrdeUserProvinceID = 0;
		/// <summary>
		/// 省份
		/// </summary>
		public int fdOrdeUserProvinceID
		{
			get{return _fdOrdeUserProvinceID;}
			set{_fdOrdeUserProvinceID = value;}
		}

		private int _fdOrdeUserCityID = 0;
		/// <summary>
		/// 城市
		/// </summary>
		public int fdOrdeUserCityID
		{
			get{return _fdOrdeUserCityID;}
			set{_fdOrdeUserCityID = value;}
		}

        private int _fdOrdeUserAreaID = 0;
        /// <summary>
        /// 地区
        /// </summary>
        public int fdOrdeUserAreaID
        {
            get { return _fdOrdeUserAreaID; }
            set { _fdOrdeUserAreaID = value; }
        }

		private string _fdOrdeUserAddress = "";
		/// <summary>
		/// 地址 50 varchar
		/// </summary>
		public string fdOrdeUserAddress
		{
			get{return _fdOrdeUserAddress;}
			set{_fdOrdeUserAddress = value;}
		}

		private string _fdOrdeUserPostcode = "";
		/// <summary>
		/// 邮编 10 varchar
		/// </summary>
		public string fdOrdeUserPostcode
		{
			get{return _fdOrdeUserPostcode;}
			set{_fdOrdeUserPostcode = value;}
		}

		private int _fdOrdePayModeID = 0;
		/// <summary>
		/// 付款方式
		/// </summary>
		public int fdOrdePayModeID
		{
			get{return _fdOrdePayModeID;}
			set{_fdOrdePayModeID = value;}
		}

		private DateTime _fdOrdePayAt = DateTime.Parse("1900-1-1");
		/// <summary>
		/// 支付时间
		/// </summary>
		public DateTime fdOrdePayAt
		{
            get { return _fdOrdePayAt; }
			set{_fdOrdePayAt = value;}
		}

        private DateTime _fdOrdeDeliverTime = DateTime.Parse("1900-1-1");
		/// <summary>
		/// 发货时间
		/// </summary>
		public DateTime fdOrdeDeliverTime
		{
			get{return _fdOrdeDeliverTime;}
			set{_fdOrdeDeliverTime = value;}
		}

		private int _fdOrdeDeliverModeID = 0;
		/// <summary>
		/// 物流配送模式
		/// </summary>
		public int fdOrdeDeliverModeID
		{
			get{return _fdOrdeDeliverModeID;}
			set{_fdOrdeDeliverModeID = value;}
		}

		private float _fdOrdeDeliverPrice = 0;
		/// <summary>
		/// 邮费
		/// </summary>
		public float fdOrdeDeliverPrice
		{
			get{return _fdOrdeDeliverPrice;}
			set{_fdOrdeDeliverPrice = value;}
		}

		private string _fdOrdeDeliverCompany = "";
		/// <summary>
		/// 投递公司 100 nvarchar
		/// </summary>
		public string fdOrdeDeliverCompany
		{
			get{return _fdOrdeDeliverCompany;}
			set{_fdOrdeDeliverCompany = value;}
		}

		private string _fdOrdeDeliverFormNo = "";
		/// <summary>
		/// 快递单号 100 nvarchar
		/// </summary>
		public string fdOrdeDeliverFormNo
		{
			get{return _fdOrdeDeliverFormNo;}
			set{_fdOrdeDeliverFormNo = value;}
		}

		private string _fdOrdeSenderPhone = "";
		/// <summary>
		/// 投递电话 100 nvarchar
		/// </summary>
		public string fdOrdeSenderPhone
		{
			get{return _fdOrdeSenderPhone;}
			set{_fdOrdeSenderPhone = value;}
		}

		private string _fdOrdeCancelReson = "";
		/// <summary>
		/// 取消原因 600 nvarchar
		/// </summary>
		public string fdOrdeCancelReson
		{
			get{return _fdOrdeCancelReson;}
			set{_fdOrdeCancelReson = value;}
		}

		private int _fdOrdeIsChangeGood = 0;
		/// <summary>
		/// 是否更换货品
		/// </summary>
		public int fdOrdeIsChangeGood
		{
			get{return _fdOrdeIsChangeGood;}
			set{_fdOrdeIsChangeGood = value;}
		}

		private int _fdOrdeConfirmWay = 0;
		/// <summary>
		/// 确定方式
		/// </summary>
		public int fdOrdeConfirmWay
		{
			get{return _fdOrdeConfirmWay;}
			set{_fdOrdeConfirmWay = value;}
		}

		private string _fdOrdePayConfirmcode = "";
		/// <summary>
		/// 发给支付网关时要求传回的安全验证码 50 varchar
		/// </summary>
		public string fdOrdePayConfirmcode
		{
			get{return _fdOrdePayConfirmcode;}
			set{_fdOrdePayConfirmcode = value;}
		}

		private string _fdOrdeInvoiceTitle = "";
		/// <summary>
		/// 发票抬头 200 nvarchar
		/// </summary>
		public string fdOrdeInvoiceTitle
		{
			get{return _fdOrdeInvoiceTitle;}
			set{_fdOrdeInvoiceTitle = value;}
		}



		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Order_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Order_bean funcGetByID(string id)
        {
            AW_Order_bean bean = new AW_Order_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Order_bean funcGetByID(int id)
        {
            AW_Order_bean bean = new AW_Order_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Order_bean funcGetByID(string id, string columns)
        {
            AW_Order_bean bean = new AW_Order_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Order_bean funcGetByID(int id, string columns)
        {
            AW_Order_bean bean = new AW_Order_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
