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
	public partial class AW_Help_bean : Bean_Base
	{
		private int _fdHelpID = 0;
		/// <summary>
		/// fdHelpID
		/// </summary>
		public int fdHelpID
		{
			get{return _fdHelpID;}
			set{_fdHelpID = value;}
		}

		private int _fdHelpTypeID = 0;
		/// <summary>
		/// fdHelpTypeID
		/// </summary>
		public int fdHelpTypeID
		{
			get{return _fdHelpTypeID;}
			set{_fdHelpTypeID = value;}
		}

        private string _fdHelpQuestion = "";
		/// <summary>
		/// fdHelpName 200 nvarchar
		/// </summary>
        public string fdHelpQuestion
		{
            get { return _fdHelpQuestion; }
            set { _fdHelpQuestion = value; }
		}

		private string _fdHelpAnswer = "";
		/// <summary>
		/// fdHelpAnswer 20 nchar
		/// </summary>
		public string fdHelpAnswer
		{
			get{return _fdHelpAnswer;}
			set{_fdHelpAnswer = value;}
		}

		private int _fdHelpSort = 0;
		/// <summary>
		/// fdHelpSort
		/// </summary>
		public int fdHelpSort
		{
			get{return _fdHelpSort;}
			set{_fdHelpSort = value;}
		}

		private DateTime _fdHelpCreateAt = DateTime.Now;
		/// <summary>
		/// fdHelpCreateAt
		/// </summary>
		public DateTime fdHelpCreateAt
		{
			get{return _fdHelpCreateAt;}
			set{_fdHelpCreateAt = value;}
		}



		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Help_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Help_bean funcGetByID(string id)
        {
            AW_Help_bean bean = new AW_Help_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Help_bean funcGetByID(int id)
        {
            AW_Help_bean bean = new AW_Help_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Help_bean funcGetByID(string id, string columns)
        {
            AW_Help_bean bean = new AW_Help_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Help_bean funcGetByID(int id, string columns)
        {
            AW_Help_bean bean = new AW_Help_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
