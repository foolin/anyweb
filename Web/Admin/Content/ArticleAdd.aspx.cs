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

public partial class Content_ArticleAdd : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        drpColumn.DataSource = new ColumnAgent().GetColumnListByArticle();
        drpColumn.DataBind();
    }

    protected void btnAddArticle_Click(object sender, EventArgs e)
    {
        Article ar = new Article();
        ar.ArtiTitle = txtTitle.Text;
        ar.ArtiContent = edtContent.Text;
        ar.ArtiOrder = int.Parse(txtOrder.Text);
        ar.ArtiIsTop = false;
        ar.ArtiCreateAt = DateTime.Now;
        ar.ArtiStatus = 0;
        ar.ArtiColumnID = int.Parse(drpColumn.SelectedValue);
        ar.ArtiClicks = 0;
        ar.ArtiUserID = this.LoginUser.UserID;
        ar.ArtiUserName = this.LoginUser.UserName;
        if (this.uploadPic.PostedFile.ContentLength > 0)
        {
            ar.ArtiPic = UploadImage();
        }
        else
            ar.ArtiPic = "";

        if (new ArticleAgent().AddArticle(ar) > 0)
        {
            EventLog log = new EventLog();
            log.EvenDesc = "添加文章" + ar.ArtiTitle + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            WebAgent.SuccAndGo("添加文章成功", "ArticleList.aspx");
        }
        else
            WebAgent.AlertAndBack("添加文章失败");
    }

    protected string UploadImage()
    {
        if (this.uploadPic.PostedFile.ContentType.IndexOf("image") == -1)
        {
            WebAgent.AlertAndBack("请选择一个文件");
            return "";
        }

        string photo = "/SiteData/article/";
        if (!Directory.Exists(Server.MapPath(photo)))
            Directory.CreateDirectory(Server.MapPath(photo));
        photo += DateTime.Now.ToString("yyMMddHHmmssfff") + Path.GetExtension(this.uploadPic.PostedFile.FileName);
        WebAgent.SaveFile(this.uploadPic.PostedFile, Server.MapPath(photo), 160, 50, true);
        return photo;
    }
}
