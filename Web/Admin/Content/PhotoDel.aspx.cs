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
using System.IO;

public partial class Admin_Content_PhotoDel : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
            WebAgent.AlertAndBack("参数错误");
        Photo phot = new PhotoAgent().GetPhotoInfo(int.Parse(QS("id")));
        if (phot == null)
            WebAgent.AlertAndBack("图片不存在");
        if (File.Exists(Server.MapPath(phot.PhotPath)))
            File.Delete(Server.MapPath(phot.PhotPath));
        if (new PhotoAgent().DeletePhoto(int.Parse(QS("id"))) > 0)
        {
            EventLog log = new EventLog();
            log.EvenDesc = "删除图片" + phot.PhotName + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            if (ViewState["BACK"].ToString() == "/Admin/Default.aspx")
                WebAgent.SuccAndGo("删除图片成功", "PhotoList.aspx");
            else
                WebAgent.SuccAndGo("删除图片成功", ViewState["BACK"].ToString());
        }
        else
            WebAgent.AlertAndBack("删除图片失败");
    }
}
