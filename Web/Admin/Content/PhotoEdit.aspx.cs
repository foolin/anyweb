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

public partial class Admin_Content_PhotoEdit : AdminBase
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
        txtPhotName.Text = phot.PhotName;
        txtPhotUrl.Text = phot.PhotUrl;
        imgPhoto.ImageUrl = phot.PhotPath;
        txtPhotSort.Text = phot.PhotOrder.ToString();
    }
    protected void btnEidtPhoto_Click(object sender, EventArgs e)
    {
        PhotoAgent agent = new PhotoAgent();
        Photo phot = new Photo();
        phot.PhotID = int.Parse(QS("id"));
        phot.PhotName = this.txtPhotName.Text;
        phot.PhotUrl = this.txtPhotUrl.Text;
        phot.PhotOrder = int.Parse(this.txtPhotSort.Text);
        phot.PhotPath = imgPhoto.ImageUrl;
        phot.PhotUploadAt = DateTime.Now;
        if (phot.PhotName == "")
        {
            WebAgent.AlertAndBack("请填写名字");
        }
        if (phot.PhotUrl == "")
        {
            WebAgent.AlertAndBack("图片地址不能为空");
        }
        if (imgupload.PostedFile.ContentLength > 0)
        {
            phot.PhotPath = UploadImage();
        }
        
        if (agent.UpdatePhotoInfo(phot) > 0)
        {
            EventLog log = new EventLog();
            log.EvenDesc = "修改图片信息" + phot.PhotName + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            WebAgent.SuccAndGo("修改图片信息成功", "PhotoList.aspx");
        }
        else
            WebAgent.AlertAndBack("修改图片信息失败");
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
