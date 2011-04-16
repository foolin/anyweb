using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Site_dao : Dao_Base
	{
		public AW_Site_dao()
        {
            this._propTable = "AW_Site";
            this._propPK = "fdSiteID";
            this._propFields = "fdSiteID,fdSiteName,fdSiteDesc,fdSiteSort,fdSiteCreateAt,fdSiteIsDel,fdSiteUrl,fdSitePath,fdSiteIndexTemplateID,fdSiteContentTemplateID,fdSiteColumnTemplateID";
        }

        public List<AW_Site_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Site_bean> list = new List<AW_Site_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Site_bean bean = new AW_Site_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
