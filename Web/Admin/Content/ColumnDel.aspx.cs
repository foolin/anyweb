using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AnyWeb.AnyWeb_DL;
using Studio.Web;

public partial class Content_ColumnDel : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        ColumnAgent Agent=new ColumnAgent();
        if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
            WebAgent.AlertAndBack("参数错误");
        Column col = Agent.GetColumnInfo(int.Parse(QS("id")));
        if (col == null)
            WebAgent.AlertAndBack("栏目不存在");
        if(Agent.CheckArticleInColumn(int.Parse(QS("id"))))
            WebAgent.AlertAndBack("该栏目下存在文章，请先将文章删除或移动到其它栏目");
        if (Agent.DeleteColumn(int.Parse(QS("id"))) > 0)
        {
            EventLog log = new EventLog();
            log.EvenDesc = "删除栏目" + col.ColuName + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            WebAgent.SuccAndGo("删除栏目成功", "ColumnList.aspx");
        }
        else
            WebAgent.AlertAndBack("删除栏目失败");
    }
}
