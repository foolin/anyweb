using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using AnyP.BizPortal.Framework;
using AnyP.BizPortal.Common;

using Studio.Data;
using System.Collections;
using System.Collections.Generic;

namespace AnyP.BizPortal.Agent
{
	/// <summary>
	/// 留言代理
	/// </summary>
	public class LeaveAgent : DbAgent
	{
		public LeaveAgent():base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }
	}
}