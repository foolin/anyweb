using System;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Studio.Web;
using AnyWeb.AW_DL;
using AnyWeb.AW_DL;
using AnyWeb.AW.Configs;

public partial class Admin_BrandAdd : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        foreach (AW_Brand_bean bean in (new AW_Brand_dao()).funcGetBrands())
        {
            drpParent.Items.Add(new ListItem(bean.fdBranName, bean.fdBranID.ToString()));
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Trim() == "")
            WebAgent.AlertAndBack("请输入名称");

        //if (filePicture.PostedFile.ContentLength == 0)
        //    WebAgent.AlertAndBack("请上传品牌图片");
        string picture = "";
        if (filePicture.PostedFile.ContentLength != 0)
        {
            if (!filePicture.PostedFile.ContentType.ToLower().Contains("image"))
                WebAgent.AlertAndBack("您上传的文件不是图片格式");

            picture = "/Files/Brand/" + "S_" + DL_helper.funcGetTicks().ToString() + Path.GetExtension(filePicture.PostedFile.FileName);
            WebAgent.SaveFile(filePicture.PostedFile, Server.MapPath(picture), GeneralConfigs.GetConfig().BrandImageWidth, GeneralConfigs.GetConfig().BrandImageHeight);
        }


        using (AW_Brand_dao dao = new AW_Brand_dao())
        {
            if (dao.funcGetBrandInfo(txtPath.Text) != null)
                WebAgent.AlertAndBack("访问路径已经被其他分类占用");

            AW_Brand_bean bean = new AW_Brand_bean();
            bean.fdBranID = dao.funcNewID();
            bean.fdBranSort = bean.fdBranID;
            bean.fdBranPicture = picture;
            bean.fdBranName = txtName.Text;
            bean.fdBranParentID = int.Parse(drpParent.SelectedValue);
            bean.fdBranPath = txtPath.Text.ToLower();
            if (bean.fdBranPath == "")
                bean.fdBranPath = bean.fdBranID.ToString();

            dao.funcInsert(bean);

            if (GeneralConfigs.GetConfig().SetupBrand == false)
            {
                GeneralConfigs.GetConfig().SetupBrand = true;
                GeneralConfigs.Serialiaze(GeneralConfigs.GetConfig(), DefaultConfigFileManager.ConfigFilePath);
            }

            WebAgent.SuccAndGo("添加品牌成功", this.RefUrl == null ? "brandlist.aspx" : this.RefUrl);
        }
    }
}
