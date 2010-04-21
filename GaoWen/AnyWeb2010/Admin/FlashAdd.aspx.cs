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
using AnyWeb.AW_DL;
using System.IO;
using Studio.Web;

public partial class Admin_FlashAdd : PageAdmin
{
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (fileUpload.PostedFile.ContentLength == 0)
            WebAgent.AlertAndBack("请上传图片文件");

        if (!fileUpload.PostedFile.ContentType.ToLower().Contains("image"))
            WebAgent.AlertAndBack("您上次的文件不是图片格式");

        using (AW_FlaAW_dao dao = new AW_FlaAW_dao())
        {
            AW_FlaAW_bean bean = new AW_FlaAW_bean();
            bean.fdFlasName = txtName.Text;
            bean.fdFlasUrl = txtUrl.Text;
            bean.fdFlasPicture = "/Files/Flash/" + DL_helper.funcGetTicks().ToString() + Path.GetExtension(fileUpload.PostedFile.FileName);
            fileUpload.PostedFile.SaveAs(Server.MapPath(bean.fdFlasPicture));
            bean.fdFlasID = dao.funcNewID();
            bean.fdFlasSort = bean.fdFlasID;
            int record = dao.funcInsert(bean);
            if (record > 0)
            {
                Studio.Web.WebAgent.SuccAndGo("添加成功", "FlashList.aspx");
            }
        }
    }
}
