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
	public partial class AW_Goods_Picture_dao
	{
        /// <summary>
        /// 获取商品的图片
        /// </summary>
        /// <param name="goodID"></param>
        /// <returns></returns>
        public List<AW_Goods_Picture_bean> funcGetGoodsPictures(int goodID)
        {
            this.propWhere = "fdPictGoodID=" + goodID.ToString();
            return this.funcGetList();
        }


        public void funcDeletePictureNoExists(int goodsID,string pictureIDs)
        {
            this.funcExecute(String.Format("DELETE AW_Goods_Picture WHERE fdPictGoodID={0} AND fdPictID NOT IN ({1})", goodsID, pictureIDs));
        }

        public void funcClearGoodsPictures(int goodsID)
        {
            this.funcExecute(String.Format("DELETE AW_Goods_Picture WHERE fdPictGoodID={0}", goodsID));
        }
	}
}
