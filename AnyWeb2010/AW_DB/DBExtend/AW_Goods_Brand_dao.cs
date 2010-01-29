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
	public partial class AW_Goods_Brand_dao
	{
        /// <summary>
        /// 获取商品和品牌的关系
        /// </summary>
        /// <param name="goodsID"></param>
        /// <returns></returns>
        public AW_Goods_Brand_bean funcGetGoodsBrandRelation(int goodsID)
        { 
            this.propWhere = "fdGoBrGoodsID=" + goodsID.ToString();
            List<AW_Goods_Brand_bean> list = this.funcGetList();
            return list.Count > 0 ? list[0] : null;
        }

        public void funcDeleteGoodsBrandRelation(int goodsID)
        {
            this.funcExecute(String.Format("DELETE AW_Goods_Brand WHERE fdGoBrGoodsID={0}", goodsID));
        }

	}
}
