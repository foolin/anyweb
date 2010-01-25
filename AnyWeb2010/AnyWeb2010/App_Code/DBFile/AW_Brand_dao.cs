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
	public partial class AW_Brand_dao : SHOP_daoBase
	{
		public AW_Brand_dao()
        {
            this._propTable = "AW_Brand";
            this._propPK = "fdBranID";
            this._propFields = "fdBranID,fdBranName,fdBranPath,fdBranIntro,fdBranPicture,fdBranParentID,fdBranSort";
        }

        public List<AW_Brand_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Brand_bean> list = new List<AW_Brand_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Brand_bean bean = new AW_Brand_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
