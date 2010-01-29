using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWeb.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_Goods_Comment_bean : Bean_Base
	{
		private int _fdCommID = 0;
		/// <summary>
		/// fdCommID
		/// </summary>
		public int fdCommID
		{
			get{return _fdCommID;}
			set{_fdCommID = value;}
		}

		private int _fdCommGoodsID = 0;
		/// <summary>
		/// fdCommGoodsID
		/// </summary>
		public int fdCommGoodsID
		{
			get{return _fdCommGoodsID;}
			set{_fdCommGoodsID = value;}
		}

		private int _fdCommMemberID = 0;
		/// <summary>
		/// fdCommMemberID
		/// </summary>
		public int fdCommMemberID
		{
			get{return _fdCommMemberID;}
			set{_fdCommMemberID = value;}
		}

		private string _fdCommUserName = "";
		/// <summary>
		/// fdCommUserName 40 nvarchar
		/// </summary>
		public string fdCommUserName
		{
			get{return _fdCommUserName;}
			set{_fdCommUserName = value;}
		}

		private int _fdCommScore = 0;
		/// <summary>
		/// 商品评分
		/// </summary>
		public int fdCommScore
		{
			get{return _fdCommScore;}
			set{_fdCommScore = value;}
		}

		private string _fdCommIP = "";
		/// <summary>
		/// fdCommIP 20 varchar
		/// </summary>
		public string fdCommIP
		{
			get{return _fdCommIP;}
			set{_fdCommIP = value;}
		}

		private DateTime _fdCommCreateAt = DateTime.Now;
		/// <summary>
		/// fdCommCreateAt
		/// </summary>
		public DateTime fdCommCreateAt
		{
			get{return _fdCommCreateAt;}
			set{_fdCommCreateAt = value;}
		}

		private string _fdCommContent = "";
		/// <summary>
		/// fdCommContent 6000 nvarchar
		/// </summary>
		public string fdCommContent
		{
			get{return _fdCommContent;}
			set{_fdCommContent = value;}
		}

		private int _fdCommIsDeleted = 0;
		/// <summary>
		/// fdCommIsDeleted
		/// </summary>
		public int fdCommIsDeleted
		{
			get{return _fdCommIsDeleted;}
			set{_fdCommIsDeleted = value;}
		}

		private string _fdCommUrlRef = "";
		/// <summary>
		/// fdCommUrlRef 200 varchar
		/// </summary>
		public string fdCommUrlRef
		{
			get{return _fdCommUrlRef;}
			set{_fdCommUrlRef = value;}
		}

		private string _fdCommArea = "";
		/// <summary>
		/// fdCommArea 40 nvarchar
		/// </summary>
		public string fdCommArea
		{
			get{return _fdCommArea;}
			set{_fdCommArea = value;}
		}

		private string _fdCommReply = "";
		/// <summary>
		/// fdCommReply 6000 nvarchar
		/// </summary>
		public string fdCommReply
		{
			get{return _fdCommReply;}
			set{_fdCommReply = value;}
		}

		private DateTime _fdCommReplyAt = DateTime.Now;
		/// <summary>
		/// fdCommReplyAt
		/// </summary>
		public DateTime fdCommReplyAt
		{
			get{return _fdCommReplyAt;}
			set{_fdCommReplyAt = value;}
		}



		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Goods_Comment_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Goods_Comment_bean funcGetByID(string id)
        {
            AW_Goods_Comment_bean bean = new AW_Goods_Comment_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Goods_Comment_bean funcGetByID(int id)
        {
            AW_Goods_Comment_bean bean = new AW_Goods_Comment_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Goods_Comment_bean funcGetByID(string id, string columns)
        {
            AW_Goods_Comment_bean bean = new AW_Goods_Comment_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Goods_Comment_bean funcGetByID(int id, string columns)
        {
            AW_Goods_Comment_bean bean = new AW_Goods_Comment_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
