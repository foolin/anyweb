using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Column_bean : Bean_Base
	{
		private int _fdColuID = 0;
		 /// <summary>
		 /// 栏目编号
		 /// </summary>
		public int fdColuID
		{
			get{return _fdColuID;}
			set{_fdColuID = value;}
		}
		private string _fdColuName = "";
		 /// <summary>
		 /// 栏目名称 200 nvarchar
		 /// </summary>
		public string fdColuName
		{
			get{return _fdColuName;}
			set{_fdColuName = value;}
		}
		private string _fdColuPicture = "";
		 /// <summary>
		 /// 栏目图片 200 varchar
		 /// </summary>
		public string fdColuPicture
		{
			get{return _fdColuPicture;}
			set{_fdColuPicture = value;}
		}
		private int _fdColuSort = 0;
		 /// <summary>
		 /// 排序
		 /// </summary>
		public int fdColuSort
		{
			get{return _fdColuSort;}
			set{_fdColuSort = value;}
		}
		private string _fdColuDescription = "";
		 /// <summary>
		 /// 栏目描述 400 nvarchar
		 /// </summary>
		public string fdColuDescription
		{
			get{return _fdColuDescription;}
			set{_fdColuDescription = value;}
		}
		private int _fdColuParentID = 0;
		 /// <summary>
		 /// 父级编号
		 /// </summary>
		public int fdColuParentID
		{
			get{return _fdColuParentID;}
			set{_fdColuParentID = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Column_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Column_bean funcGetByID(string id)
        {
            AW_Column_bean bean = new AW_Column_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Column_bean funcGetByID(int id)
        {
            AW_Column_bean bean = new AW_Column_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Column_bean funcGetByID(string id, string columns)
        {
            AW_Column_bean bean = new AW_Column_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Column_bean funcGetByID(int id, string columns)
        {
            AW_Column_bean bean = new AW_Column_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
