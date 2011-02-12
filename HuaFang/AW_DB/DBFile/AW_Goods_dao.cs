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
	public partial class AW_Goods_dao : Dao_Base
	{
		public AW_Goods_dao()
        {
            this._propTable = "AW_Goods";
            this._propPK = "fdGoodID";
            this._propFields = "fdGoodID,fdGoodName,fdGoodSort,fdGoodStockPrice,fdGoodSalePrice,fdGoodMarketPrice,fdGoodCategoryID,fdGoodCommentCount,fdGoodFavCount,fdGoodScoreAverage,fdGoodScoreCount,fdGoodClickCount,fdGoodCreateAt,fdGoodUpdateAt,fdGoodIsRecommend,fdGoodIsPromotion,fdGoodPromPrice,fdGoodPromStartAt,fdGoodPromEndAt,fdGoodStockNum,fdGoodSaleNum,fdGoodListImage,fdGoodStatus,fdGoodDescription,fdGoodWeight,fdGoodUnit,fdGoodService,fdGoodSize,fdGoodArea,fdGoodHomeJinbao,fdGoodHomeMeijiu,fdGoodHomeMingpai,fdGoodHomeCheap,fdGoodPoint";
        }

        public List<AW_Goods_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Goods_bean> list = new List<AW_Goods_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Goods_bean bean = new AW_Goods_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
