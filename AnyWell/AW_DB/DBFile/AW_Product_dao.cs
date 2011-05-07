using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Product_dao : Dao_Base
	{
		public AW_Product_dao()
        {
            this._propTable = "AW_Product";
            this._propPK = "fdProdID";
            this._propFields = "fdProdID,fdProdColuID,fdProdType,fdProdName,fdProdCode,fdProdImage,fdProdDescription,fdProdContent,fdProdClickCount,fdProdCommentCount,fdProdIsDel,fdProdCreateAt,fdProdCanComment,fdProdSort,fdProdSourceID";
        }

        public List<AW_Product_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Product_bean> list = new List<AW_Product_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Product_bean bean = new AW_Product_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
