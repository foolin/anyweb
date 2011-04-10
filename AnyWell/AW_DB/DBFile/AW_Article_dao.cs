using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Article_dao : Dao_Base
	{
		public AW_Article_dao()
        {
            this._propTable = "AW_Article";
            this._propPK = "fdArtiID";
            this._propFields = "fdArtiID,fdArtiColuID,fdArtiCreateAt,fdArtiType,fdArtiLink,fdArtiTitle,fdArtiSubTitle,fdArtiContent,fdArtiDescription,fdArtiClickCount,fdArtiCommentCount,fdArtiIsAuthorship,fdArtiFrom,fdArtiFromLink,fdArtiFromAuthor,fdArtiCanComment,fdArtiIsDel,fdArtiSort,fdArtiImage";
        }

        public List<AW_Article_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Article_bean> list = new List<AW_Article_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
