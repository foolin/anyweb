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
	public partial class AW_Flash_dao : Dao_Base
	{
        public AW_Flash_dao()
        {
            this._propTable = "AW_Flash";
            this._propPK = "fdFlasID";
            this._propFields = "fdFlasID,fdFlasName,fdFlasUrl,fdFlasPicture,fdFlashDesc,fdFlasSort";
        }

        public List<AW_Flash_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Flash_bean> list = new List<AW_Flash_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Flash_bean bean = new AW_Flash_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
