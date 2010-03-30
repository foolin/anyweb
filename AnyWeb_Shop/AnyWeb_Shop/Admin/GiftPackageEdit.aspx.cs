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

using Admin.Framework;
using Studio.Web;
using Common.Agent;
using Common.Common;
using System.IO;

public partial class Admin_GiftPackageEdit : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            switch (QS("mode"))
            {
                case "update":
                    this.fv1.ChangeMode(FormViewMode.Edit);
                    litTitle.Text = "修改大礼包";
                    break;
                case "select":
                    this.fv1.ChangeMode(FormViewMode.ReadOnly);
                    litTitle.Text = "查看大礼包";
                    break;
                default:
                    this.fv1.ChangeMode(FormViewMode.Insert);
                    litTitle.Text = "添加大礼包";
                    break;

            }
        }
    }


    protected void fv1_DataBound(object sender, EventArgs e)
    {
        if (QS("mode") != "select")
        {
            GiftPackage gp = (GiftPackage)fv1.DataItem;
            TextBox txtPackName = (TextBox)fv1.FindControl("txtPackName");
            TextBox txtPackNo = (TextBox)fv1.FindControl("txtPackNo");
            TextBox txtPrice = (TextBox)fv1.FindControl("txtPrice");
            TextBox txtIntro = (TextBox)fv1.FindControl("txtIntro");
            //HiddenField hdfGoodsIds = (HiddenField)fv1.FindControl("hdfGoodsIds");
        }

    }

    protected void ods3_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (WebAgent.IsInt32(QS("packID")))
        {
            e.InputParameters["packID"] = int.Parse(QS("packID"));
        }

    }

    protected void ods3_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        FileUpload img = (FileUpload)fv1.FindControl("txtImage");
        TextBox txtSort = (TextBox)fv1.FindControl("txtSort");
        TextBox txtIntro = (TextBox)fv1.FindControl("txtIntro");
        TextBox txtPrice = (TextBox)fv1.FindControl("txtPrice");
        //TextBox txtDescription = (TextBox)fv1.FindControl("txtDescription");

        GiftPackage gp = (GiftPackage)e.InputParameters[0];

        gp.GoodsIds = "";
        if (img != null)
        {
            gp.Image = this.GetProductImg(img);
        }
        else
        {
            gp.Image = "";
        }

        if (txtSort == null || string.IsNullOrEmpty(txtSort.Text))
        {
            gp.Sort = 0;
        }
        else if (WebAgent.IsInt32(txtSort.Text))
        {
            gp.Sort = int.Parse(txtSort.Text);
        }
        else
        {
            gp.Sort = 0;
        }
        if (txtIntro == null || string.IsNullOrEmpty(txtIntro.Text))
        {
            gp.Intro = "暂无";
        }
        if (txtPrice == null || string.IsNullOrEmpty(txtPrice.Text))
        {
            WebAgent.AlertAndBack("价格输入不能为空，请输入！");
        }
        else
        {
            try
            {
                gp.Price = Convert.ToDouble(txtPrice.Text);
            }
            catch
            {
                WebAgent.AlertAndBack("价格输入必须为数字，请输入！");
            }
        }
    }

    protected void ods3_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if ((int)e.ReturnValue > 0)
        {

            this.AddLog(EventID.Insert, "添加大礼包", "添加大礼包");

            WebAgent.SuccAndGo("添加成功!", "GiftPackageList.aspx");
        }
        else
        {
            WebAgent.FailAndGo("添加失败,请重试!", "GiftPackageList.aspx");
        }
    }

    protected void ods3_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        if (!WebAgent.IsInt32(QS("packID")))
        {
            WebAgent.AlertAndBack("ID参数错误");
        }
        FileUpload img = (FileUpload)fv1.FindControl("txtImage");
        TextBox txtSort = (TextBox)fv1.FindControl("txtSort");
        TextBox txtIntro = (TextBox)fv1.FindControl("txtIntro");
        HiddenField hdfGoodsIds = (HiddenField)fv1.FindControl("hdfGoodsIds");

        GiftPackage gp = (GiftPackage)e.InputParameters[0];

        gp.GoodsIds = "";
        gp.PackID = int.Parse(QS("packID"));
        if (img != null)
        {
            gp.Image = this.GetProductImg(img);
        }
        if (hdfGoodsIds != null && !string.IsNullOrEmpty(hdfGoodsIds.Value))
        {
            gp.GoodsIds = hdfGoodsIds.Value;
            
        }
        WebAgent.Alert(hdfGoodsIds.Value);
        if (txtSort == null || string.IsNullOrEmpty(txtSort.Text))
        {
            gp.Sort = 0;
        }
        else if (WebAgent.IsInt32(txtSort.Text))
        {
            gp.Sort = int.Parse(txtSort.Text);
        }
        else
        {
            gp.Sort = 0;
        }
        if (txtIntro == null || string.IsNullOrEmpty(txtIntro.Text))
        {
            gp.Intro = "暂无";
        }
    }

    protected void ods3_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if ((int)e.ReturnValue > 0)
        {

            this.AddLog(EventID.Insert, "修改大礼包信息", "修改大礼包信息,大礼包编号：" + QS("packID"));

            WebAgent.SuccAndGo("修改成功。", "GiftPackageList.aspx");
        }
        else
        {
            WebAgent.FailAndGo("修改失败。", "GiftPackageList.aspx");
        }
    }

    protected void ods3_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        if (!WebAgent.IsInt32(QS("packID")))
        {
            WebAgent.AlertAndBack("ID参数错误");
        }
        GiftPackage gp = (GiftPackage)e.InputParameters[0];
        gp.PackID = int.Parse(QS("packID"));

    }

    protected void ods3_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if ((int)e.ReturnValue > 0)
        {
            this.AddLog(EventID.Delete, "删除大礼包信息", "删除大礼包信息,大礼包编号：" + QS("packID"));

            WebAgent.SuccAndGo("删除成功.", "GiftPackageList.aspx");
        }
        else
        {
            WebAgent.FailAndGo("删除失败.", "GiftPackageList.aspx");
        }
    }




}
