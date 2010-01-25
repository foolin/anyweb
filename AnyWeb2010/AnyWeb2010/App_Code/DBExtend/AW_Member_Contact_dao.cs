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
	public partial class AW_Member_Contact_dao
	{

        public List<AW_Member_Contact_bean> funcGetList(int memberId)
        {
            this.propWhere = "fdContMemberID = " + memberId.ToString();
            return this.funcGetList();
        }

        public AW_Member_Contact_bean funcGetContact(int contactId, int memberId)
        {
            this.propWhere = string.Format("fdContID = {0} AND fdContMemberID = {1}", contactId, memberId);
            List<AW_Member_Contact_bean> list = this.funcGetList();
            return list.Count > 0 ? list[0] : null;
        }

        /// <summary>
        /// 删除会员商品收货地址
        /// </summary>
        /// <returns></returns>
        public int funcDelete(int contactId, int memberId)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                string sql = String.Format("DELETE FROM AW_Member_Contact WHERE fdContID = {0} AND fdContMemberID = {1}", contactId, memberId);
                return db.ExecuteNonQuery(sql);
            }
        }

	}
}
