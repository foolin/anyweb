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
	public partial class AW_Goods_bean : Bean_Base
	{
		private int _fdGoodID = 0;
		/// <summary>
		/// 产品编号
		/// </summary>
		public int fdGoodID
		{
			get{return _fdGoodID;}
			set{_fdGoodID = value;}
		}

		private string _fdGoodName = "";
		/// <summary>
		/// 产品名称 100 nvarchar
		/// </summary>
		public string fdGoodName
		{
			get{return _fdGoodName;}
			set{_fdGoodName = value;}
		}

		private int _fdGoodSort = 0;
		/// <summary>
		/// 排序
		/// </summary>
		public int fdGoodSort
		{
			get{return _fdGoodSort;}
			set{_fdGoodSort = value;}
		}

		private float _fdGoodStockPrice = 0;
		/// <summary>
		/// 进货价
		/// </summary>
		public float fdGoodStockPrice
		{
			get{return _fdGoodStockPrice;}
			set{_fdGoodStockPrice = value;}
		}

		private float _fdGoodSalePrice = 0;
		/// <summary>
		/// 销售价格
		/// </summary>
		public float fdGoodSalePrice
		{
			get{return _fdGoodSalePrice;}
			set{_fdGoodSalePrice = value;}
		}

		private float _fdGoodMarketPrice = 0;
		/// <summary>
		/// 市场价格
		/// </summary>
		public float fdGoodMarketPrice
		{
			get{return _fdGoodMarketPrice;}
			set{_fdGoodMarketPrice = value;}
		}

		private int _fdGoodCategoryID = 0;
		/// <summary>
		/// 所属分类
		/// </summary>
		public int fdGoodCategoryID
		{
			get{return _fdGoodCategoryID;}
			set{_fdGoodCategoryID = value;}
		}

		private int _fdGoodCommentCount = 0;
		/// <summary>
		/// 评论数
		/// </summary>
		public int fdGoodCommentCount
		{
			get{return _fdGoodCommentCount;}
			set{_fdGoodCommentCount = value;}
		}

		private int _fdGoodFavCount = 0;
		/// <summary>
		/// 收藏数量
		/// </summary>
		public int fdGoodFavCount
		{
			get{return _fdGoodFavCount;}
			set{_fdGoodFavCount = value;}
		}

		private float _fdGoodScoreAverage = 0;
		/// <summary>
		/// 平均得分
		/// </summary>
		public float fdGoodScoreAverage
		{
			get{return _fdGoodScoreAverage;}
			set{_fdGoodScoreAverage = value;}
		}

		private int _fdGoodScoreCount = 0;
		/// <summary>
		/// 用户评分数量
		/// </summary>
		public int fdGoodScoreCount
		{
			get{return _fdGoodScoreCount;}
			set{_fdGoodScoreCount = value;}
		}

		private int _fdGoodClickCount = 189;
		/// <summary>
		/// 点击数
		/// </summary>
		public int fdGoodClickCount
		{
			get{return _fdGoodClickCount;}
			set{_fdGoodClickCount = value;}
		}

		private DateTime _fdGoodCreateAt = DateTime.Now;
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime fdGoodCreateAt
		{
			get{return _fdGoodCreateAt;}
			set{_fdGoodCreateAt = value;}
		}

		private DateTime _fdGoodUpdateAt = DateTime.Now;
		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime fdGoodUpdateAt
		{
			get{return _fdGoodUpdateAt;}
			set{_fdGoodUpdateAt = value;}
		}

		private int _fdGoodIsRecommend = 0;
		/// <summary>
		/// 是否推荐
		/// </summary>
		public int fdGoodIsRecommend
		{
			get{return _fdGoodIsRecommend;}
			set{_fdGoodIsRecommend = value;}
		}

		private int _fdGoodIsPromotion = 0;
		/// <summary>
		/// 是否促销
		/// </summary>
		public int fdGoodIsPromotion
		{
			get{return _fdGoodIsPromotion;}
			set{_fdGoodIsPromotion = value;}
		}

		private float _fdGoodPromPrice = 0;
		/// <summary>
		/// 促销价格
		/// </summary>
		public float fdGoodPromPrice
		{
			get{return _fdGoodPromPrice;}
			set{_fdGoodPromPrice = value;}
		}

		private DateTime _fdGoodPromStartAt = DateTime.Parse("1900-1-1");
		/// <summary>
		/// 促销开始时间
		/// </summary>
		public DateTime fdGoodPromStartAt
		{
			get{return _fdGoodPromStartAt;}
			set{_fdGoodPromStartAt = value;}
		}

		private DateTime _fdGoodPromEndAt = DateTime.Parse("1900-1-1");
		/// <summary>
		/// 促销结束时间
		/// </summary>
		public DateTime fdGoodPromEndAt
		{
			get{return _fdGoodPromEndAt;}
			set{_fdGoodPromEndAt = value;}
		}

		private int _fdGoodStockNum = 0;
		/// <summary>
		/// 库存数量
		/// </summary>
		public int fdGoodStockNum
		{
			get{return _fdGoodStockNum;}
			set{_fdGoodStockNum = value;}
		}

		private int _fdGoodSaleNum = 0;
		/// <summary>
		/// 销售数量
		/// </summary>
		public int fdGoodSaleNum
		{
			get{return _fdGoodSaleNum;}
			set{_fdGoodSaleNum = value;}
		}

		private string _fdGoodListImage = "";
		/// <summary>
		/// 列表图片 200 varchar
		/// </summary>
		public string fdGoodListImage
		{
			get{return _fdGoodListImage;}
			set{_fdGoodListImage = value;}
		}

		private int _fdGoodStatus = 1;
		/// <summary>
		/// 状态 1正常 2下架
		/// </summary>
		public int fdGoodStatus
		{
			get{return _fdGoodStatus;}
			set{_fdGoodStatus = value;}
		}

		private string _fdGoodDescription = "";
		/// <summary>
		/// 描述 16 ntext
		/// </summary>
		public string fdGoodDescription
		{
			get{return _fdGoodDescription;}
			set{_fdGoodDescription = value;}
		}

		private float _fdGoodWeight = 0;
		/// <summary>
		/// 重量
		/// </summary>
		public float fdGoodWeight
		{
			get{return _fdGoodWeight;}
			set{_fdGoodWeight = value;}
		}

		private string _fdGoodUnit = "";
		/// <summary>
		/// 单位 100 nvarchar
		/// </summary>
		public string fdGoodUnit
		{
			get{return _fdGoodUnit;}
			set{_fdGoodUnit = value;}
		}

		private string _fdGoodService = "";
		/// <summary>
		/// 服务 4000 nvarchar
		/// </summary>
		public string fdGoodService
		{
			get{return _fdGoodService;}
			set{_fdGoodService = value;}
		}

		private string _fdGoodSize = "";
		/// <summary>
		/// 大小 40 nvarchar
		/// </summary>
		public string fdGoodSize
		{
			get{return _fdGoodSize;}
			set{_fdGoodSize = value;}
		}

		private string _fdGoodArea = "";
		/// <summary>
		/// 商品生产地区 100 nvarchar
		/// </summary>
		public string fdGoodArea
		{
			get{return _fdGoodArea;}
			set{_fdGoodArea = value;}
		}

        private int _fdGoodHomeJinbao = 0;
        /// <summary>
        /// 劲爆推荐
        /// </summary>
        public int fdGoodHomeJinbao
        {
            get { return _fdGoodHomeJinbao; }
            set { _fdGoodHomeJinbao = value; }
        }

        private int _fdGoodHomeMeijiu = 0;
        /// <summary>
        /// 美酒推荐
        /// </summary>
        public int fdGoodHomeMeijiu
        {
            get { return _fdGoodHomeMeijiu; }
            set { _fdGoodHomeMeijiu = value; }
        }

        private int _fdGoodHomeMingpai = 0;
        /// <summary>
        /// 名牌推荐
        /// </summary>
        public int fdGoodHomeMingpai
        {
            get { return _fdGoodHomeMingpai; }
            set { _fdGoodHomeMingpai = value; }
        }

        private int _fdGoodHomeCheap = 0;
        /// <summary>
        /// 超值商品
        /// </summary>
        public int fdGoodHomeCheap
        {
            get { return _fdGoodHomeCheap; }
            set { _fdGoodHomeCheap = value; }
        }

        private int _fdGoodPoint = 0;
        /// <summary>
        /// 积分
        /// </summary>
        public int fdGoodPoint
        {
            get { return _fdGoodPoint; }
            set { _fdGoodPoint = value; }
        }



		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Goods_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Goods_bean funcGetByID(string id)
        {
            AW_Goods_bean bean = new AW_Goods_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Goods_bean funcGetByID(int id)
        {
            AW_Goods_bean bean = new AW_Goods_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Goods_bean funcGetByID(string id, string columns)
        {
            AW_Goods_bean bean = new AW_Goods_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Goods_bean funcGetByID(int id, string columns)
        {
            AW_Goods_bean bean = new AW_Goods_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
