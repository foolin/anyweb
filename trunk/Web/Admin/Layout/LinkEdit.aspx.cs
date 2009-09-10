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
using Studio.Security;
using System.IO;

public partial class Layout_LinkEdit : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
            WebAgent.AlertAndBack("参数错误");
        Link lnk = new LinkAgent().GetLinkInfo(int.Parse(QS("id")));
        if (lnk == null)
            WebAgent.AlertAndBack("友情链接不存在");
        txtLinkName.Text = lnk.LinkName;
        txtLinkUrl.Text = lnk.LinkUrl;
        if (string.IsNullOrEmpty(lnk.LinkImage))
            imgPhoto.Visible = false;
        else
            imgPhoto.ImageUrl = lnk.LinkImage;
        txtLinkSort.Text = lnk.LinkSort.ToString();
    }

    protected void btnEditLink_Click(object sender, EventArgs e)
    {
        LinkAgent agent = new LinkAgent();
        Link lnk = new LinkAgent().GetLinkInfo(int.Parse(QS("id")));
        lnk.LinkName = this.txtLinkName.Text;
        lnk.LinkUrl = this.txtLinkUrl.Text;
        lnk.LinkSort = int.Parse(txtLinkSort.Text);
        if (this.imgupload.PostedFile.ContentLength > 0)
            lnk.LinkImage = UploadImage();
        if (new LinkAgent().UpdateLinkInfo(lnk) > 0)
        {
            EventLog log = new EventLog();
            log.EvenDesc = "修改友情链接" + lnk.LinkName + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            WebAgent.SuccAndGo("修改友情成功", "LinkList.aspx");
        }
        else
            WebAgent.AlertAndBack("修改友情失败");
    }

    protected string UploadImage()
    {
        if (this.imgupload.PostedFile.ContentType.IndexOf("image") == -1)
        {
            WebAgent.AlertAndBack("请选择一个文件");
            return "";
        }

        string photo = "/SiteData/Link/";
        if (!Directory.Exists(Server.MapPath(photo)))
            Directory.CreateDirectory(Server.MapPath(photo));
        photo += DateTime.Now.ToString("yyMMddHHmmssfff") + Path.GetExtension(this.imgupload.PostedFile.FileName);
        WebAgent.SaveFile(this.imgupload.PostedFile, Server.MapPath(photo), 160, 50, true);
        return photo;
    }
}
