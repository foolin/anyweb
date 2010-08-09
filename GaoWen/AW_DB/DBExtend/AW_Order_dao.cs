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
	public partial class AW_Order_dao
	{
        ///// <summary>
        ///// 获取订单列表（分页）
        ///// </summary>
        ///// <returns></returns>
        //public List<AW_Order_bean> funcGetList(int pageSize, int pageID)
        //{
        //    //this.propGetCount = true;
        //    //this.propPage = pageID;
        //    //this.propPageSize = pageSize;

        //    DataSet ds = base.funcCommon();
        //    List<AW_Order_bean> list = new List<AW_Order_bean>();
        //    foreach (DataRow r in ds.Tables[0].Rows)
        //    {
        //        AW_Order_bean bean = new AW_Order_bean();
        //        bean.funcFromDataRow(r);
        //        bean.
        //        list.Add(bean);
        //    }
        //    return list;
        //}

        //public DataSet funcGetCount()
        //{

        //}


        /// <summary>
        /// 获取会员订单数
        /// Author:Jonllen
        /// </summary>
        /// <param name="memberId">会员编号</param>
        /// <returns>订单数</returns>
        public int funcGetOrderCount(int memberId)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                object rev = db.ExecuteScalar("SELECT COUNT(*) FROM AW_Order WHERE fdOrdeMemberID = " + memberId);
                return Convert.IsDBNull(rev) ? 0 : (int)rev;
            }
        }

        /// <summary>
        /// 获取最新订单数量
        /// </summary>
        /// <returns></returns>
        public int funcGetNewOrderCount()
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                object rev = db.ExecuteScalar("SELECT COUNT(*) FROM AW_Order WHERE fdOrdeStatus = 1");
                return Convert.IsDBNull(rev) ? 0 : (int)rev;
            }
            
        }

        /// <summary>
        /// 获取最近3个月订单数量
        /// </summary>
        /// <returns></returns>
        public int funcGetTop3MonthOrderCount()
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                object rev = db.ExecuteScalar("SELECT COUNT(*) FROM AW_Order WHERE fdOrdeCreateAt > Dateadd(month,-3,Getdate())");
                return Convert.IsDBNull(rev) ? 0 : (int)rev;
            }
            
        }

	}
}
