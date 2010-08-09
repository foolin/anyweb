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
	public partial class AW_Category_dao : Dao_Base
	{
		public AW_Category_dao()
        {
            this._propTable = "AW_Category";
            this._propPK = "fdCateID";
            this._propFields = "fdCateID,fdCateName,fdCateCreateAt,fdCatePath,fdCateParent,fdCateIsShow,fdCateSort,fdCateIDPath,fdCateGoods,fdCateTempIndex,fdCateTempContent";
        }

        public List<AW_Category_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Category_bean> list = new List<AW_Category_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Category_bean bean = new AW_Category_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
