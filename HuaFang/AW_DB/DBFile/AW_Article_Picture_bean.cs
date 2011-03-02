using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Article_Picture_bean : Bean_Base
	{
		private int _fdArPiID = 0;
		 /// <summary>
		 /// 图片编号
		 /// </summary>
		public int fdArPiID
		{
			get{return _fdArPiID;}
			set{_fdArPiID = value;}
		}
		private string _fdArPiPath = "";
		 /// <summary>
		 /// 图片路径
		 /// </summary>
		public string fdArPiPath
		{
			get{return _fdArPiPath;}
			set{_fdArPiPath = value;}
		}
		private int _fdArPiArtiID = 0;
		 /// <summary>
		 /// 文章编号
		 /// </summary>
		public int fdArPiArtiID
		{
			get{return _fdArPiArtiID;}
			set{_fdArPiArtiID = value;}
		}
		private int _fdArPiType = 0;
		 /// <summary>
		 /// 类型(0:图片1CatWalk2BackStage3CloseUp)
		 /// </summary>
		public int fdArPiType
		{
			get{return _fdArPiType;}
			set{_fdArPiType = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Article_Picture_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Article_Picture_bean funcGetByID(string id)
        {
            AW_Article_Picture_bean bean = new AW_Article_Picture_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Article_Picture_bean funcGetByID(int id)
        {
            AW_Article_Picture_bean bean = new AW_Article_Picture_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Article_Picture_bean funcGetByID(string id, string columns)
        {
            AW_Article_Picture_bean bean = new AW_Article_Picture_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Article_Picture_bean funcGetByID(int id, string columns)
        {
            AW_Article_Picture_bean bean = new AW_Article_Picture_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
