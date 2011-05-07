using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_SingleArticle_dao : Dao_Base
	{
		public AW_SingleArticle_dao()
        {
            this._propTable = "AW_SingleArticle";
            this._propPK = "fdSingID";
            this._propFields = "fdSingID,fdSingColuID,fdSingTitle,fdSingContent,fdSingClickCount,fdSingCommentCount,fdSingCanComment";
        }

        public List<AW_SingleArticle_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_SingleArticle_bean> list = new List<AW_SingleArticle_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_SingleArticle_bean bean = new AW_SingleArticle_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
