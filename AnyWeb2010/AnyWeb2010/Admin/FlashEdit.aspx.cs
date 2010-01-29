using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using AnyWeb.AW_DL;
using Studio.Web;
using System.IO;
using AnyWeb.AW_DL;

public partial class Admin_FlashEdit : PageAdmin
{

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        AW_FlaAW_bean flash = AW_FlaAW_bean.funcGetByID(int.Parse(QS("id")));
        txtName.Text = flash.fdFlasName;
        txtUrl.Text = flash.fdFlasUrl;
        imgPicture.ImageUrl = flash.fdFlasPicture;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (fileUpload.PostedFile.ContentLength > 0 && !fileUpload.PostedFile.ContentType.ToLower().Contains("image"))
            WebAgent.AlertAndBack("您上次的文件不是图片格式");


        using (AW_FlaAW_dao dao = new AW_FlaAW_dao())
        {
            AW_FlaAW_bean bean = AW_FlaAW_bean.funcGetByID(int.Parse(QS("id")));
            bean.fdFlasName = txtName.Text;
            bean.fdFlasUrl = txtUrl.Text;
            if (fileUpload.PostedFile.ContentLength > 0)
            {
                bean.fdFlasPicture = "/Files/Flash/" + DL_helper.funcGetTicks().ToString() + Path.GetExtension(fileUpload.PostedFile.FileName);
                fileUpload.PostedFile.SaveAs(Server.MapPath(bean.fdFlasPicture));
            }
            dao.funcUpdate(bean);
            WebAgent.SuccAndGo("修改成功", "FlashList.aspx");
        }
    }

}
