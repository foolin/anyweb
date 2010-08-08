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

public partial class Admin_Content_PhotoAdd : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        txtPhotOrder.Text = (this.SiteInfo.SitePicCount + 1).ToString();    
    }

    protected void btnAddPhoto_Click(object sender, EventArgs e)
    {
        PhotoAgent agent = new PhotoAgent();
        Photo phot = new Photo();
        phot.PhotName = this.txtPhotName.Text;
        phot.PhotUrl = this.txtPhotUrl.Text;
        phot.PhotOrder = int.Parse(this.txtPhotOrder.Text);
        phot.PhotCateID = int.Parse(type.SelectedValue);
        phot.PhotUploadAt = DateTime.Now;
        if (phot.PhotName == "")
        {
            WebAgent.AlertAndBack("请填写名字");
        }
        if (phot.PhotUrl == "")
        {
            WebAgent.AlertAndBack("请填写连接地址");
        }
        if (this.imgupload.PostedFile.ContentLength > 0)
        {
            phot.PhotPath = UploadImage();
        }
        else
            WebAgent.AlertAndBack("请上传图片！");
        if (agent.AddPhoto(phot))
        {
            EventLog log = new EventLog();
            log.EvenDesc = "添加图片" + phot.PhotName + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            WebAgent.SuccAndGo("添加图片成功", "PhotoList.aspx");
        }
        else
            WebAgent.AlertAndBack("添加图片失败");

    }

    protected string UploadImage()
    {
        if (this.imgupload.PostedFile.ContentType.IndexOf("image") == -1)
        {
            WebAgent.AlertAndBack("请选择一个文件");
            return "";
        }

        string photo = "/SiteData/Picture/";
        if (!Directory.Exists(Server.MapPath(photo)))
            Directory.CreateDirectory(Server.MapPath(photo));
        photo += DateTime.Now.ToString("yyMMddHHmmssfff") + Path.GetExtension(this.imgupload.PostedFile.FileName);
        WebAgent.SaveFile(this.imgupload.PostedFile, Server.MapPath(photo), 800, 600, true);
        return photo;
    }
}
