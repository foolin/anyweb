using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Resume_dao
	{
        /// <summary>
        /// 获取简历列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<AW_Resume_bean> funcGetResumeList(int userId)
        {
            this.propWhere = string.Format("fdResuUserID={0} AND fdResuStatus=0", userId);
            this.propOrder = "ORDER BY fdResuID ASC";
            return this.funcGetList();
        }
	}
}
