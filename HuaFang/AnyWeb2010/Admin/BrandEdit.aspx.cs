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
using AnyWell.AW_DL;
using AnyWell.AW_DL;
using AnyWell.Configs;


public partial class Admin_BrandEdit : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        AW_Brand_bean brand = (new AW_Brand_dao()).funcGetBrandInfo(int.Parse(QS("id")));
        txtName.Text = brand.fdBranName;
        if (!string.IsNullOrEmpty(brand.fdBranPicture))
        {
            imgPicture.ImageUrl = brand.fdBranPicture;
        }
        else
        {
            imgPicture.Visible = false;
        }
        txtIntro.Text = brand.fdBranIntro;

        if (brand.Children != null && brand.Children.Count > 0)
        {
            if (brand.Parent == null)
                drpParent.Items.Add(new ListItem("没有上级品牌", "0"));
            else
                drpParent.Items.Add(new ListItem(brand.Parent.fdBranName, brand.Parent.fdBranID.ToString()));
        }
        else
        {
            drpParent.Items.Add(new ListItem("没有上级品牌", "0"));
            foreach (AW_Brand_bean bean in (new AW_Brand_dao()).funcGetBrands())
            {
                if (bean != brand)
                    drpParent.Items.Add(new ListItem(bean.fdBranName, bean.fdBranID.ToString()));
            }
        }

        ListItem li = drpParent.Items.FindByValue(brand.fdBranParentID.ToString());
        if (li != null) li.Selected = true;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Trim() == "")
            WebAgent.AlertAndBack("请输入名称");

        if (filePicture.PostedFile.ContentLength > 0 && !filePicture.PostedFile.ContentType.ToLower().Contains("image"))
            WebAgent.AlertAndBack("您上传的文件不是图片格式");


        using (AW_Brand_dao dao = new AW_Brand_dao())
        {
            AW_Brand_bean bean = dao.funcGetBrandInfo(int.Parse(QS("id")));
            if (filePicture.PostedFile.ContentLength > 0)
            {
                bean.fdBranPicture = "/Files/Brand/" + "S_" + DL_helper.funcGetTicks().ToString() + Path.GetExtension(filePicture.PostedFile.FileName);
                WebAgent.SaveFile(filePicture.PostedFile, Server.MapPath(bean.fdBranPicture), GeneralConfigs.GetConfig().BrandImageWidth, GeneralConfigs.GetConfig().BrandImageWidth);
            }
            bean.fdBranName = txtName.Text;
            bean.fdBranParentID = int.Parse(drpParent.SelectedValue);
            if (bean.fdBranPath == "")
                bean.fdBranPath = bean.fdBranID.ToString();

            dao.funcUpdate(bean);
            this.AddLog(EventType.Update, "修改品牌", "修改品牌[" + bean.fdBranName + "]");
            WebAgent.SuccAndGo("修改品牌成功", this.RefUrl == null ? "brandlist.aspx" : this.RefUrl);
        }
    }
}
