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
using System.Collections.Generic;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected override void OnPreRender(EventArgs e)
    {
        List<Photo> list = new PhotoAgent().getPhotoListByCateID(1);
        //幻灯片图片
        repFlash1.DataSource = list;
        repFlash1.DataBind();
        //幻灯片按钮
        repFlash2.DataSource = list;
        repFlash2.DataBind();
        //幻灯片标题
        repFlash3.DataSource = list;
        repFlash3.DataBind();

        //菜篮子
        repCLZ.DataSource = new PhotoAgent().getPhotoListByCateID(2);
        repCLZ.DataBind();

        //知名企业
        repZMQY.DataSource = new PhotoAgent().getPhotoListByCateID(3);
        repZMQY.DataBind();

        //荣誉奖状
        repRYJZ.DataSource = new PhotoAgent().getPhotoListByCateID(4);
        repRYJZ.DataBind();
    }
}
