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

public partial class Layout_LinkAdd : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAddLink_Click(object sender, EventArgs e)
    {
        LinkAgent agent = new LinkAgent();
        Link lnk = new Link();
        lnk.LinkName = this.txtLinkName.Text;
        lnk.LinkUrl = this.txtLinkUrl.Text;
        if (!lnk.LinkUrl.ToLower().StartsWith("http://"))
            lnk.LinkUrl = "http://" + lnk.LinkUrl;
        lnk.LinkSort = int.Parse(this.txtLinkSort.Text);
        if (this.imgupload.PostedFile.ContentLength > 0)
        {
            lnk.LinkImage = UploadImage();
        }
        else
            WebAgent.AlertAndBack("请上传图片！");
        if (agent.AddLink(lnk))
        {
            EventLog log = new EventLog();
            log.EvenDesc = "添加友情链接" + lnk.LinkName + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            WebAgent.SuccAndGo("添加友情链接成功", "LinkList.aspx");
        }
        else
            WebAgent.AlertAndBack("添加友情链接失败");
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
