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
	public partial class AW_News_Column_dao : SHOP_daoBase
	{
		public AW_News_Column_dao()
        {
            this._propTable = "AW_News_Column";
            this._propPK = "fdColuID";
            this._propFields = "fdColuID,fdColuName,fdColuPath,fdColuSort,fdColuDescription,fdColuPicture,fdColuShowIndex,fdColuParentID";
        }

        public List<AW_News_Column_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_News_Column_bean> list = new List<AW_News_Column_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_News_Column_bean bean = new AW_News_Column_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
