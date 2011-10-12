﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;
using System.Web.UI.HtmlControls;

public partial class Admin_LibraryAdd : PageAdmin
{
    protected override void OnLoad( EventArgs e )
    {
        base.OnLoad( e );
        HtmlForm form = ( HtmlForm ) this.Master.FindControl( "form1" );
        if( form != null )
        {
            form.Target = "ifrSelf";
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtLibrName.Text))
            Fail("名称不能为空");
        if (string.IsNullOrEmpty(txtLibrEnName.Text))
            Fail( "英文名称不能为空" );
        if (string.IsNullOrEmpty(txtLibrOrder.Text))
            Fail( "排序不能为空" );
        if (!WebAgent.IsInt32(txtLibrOrder.Text.Trim()))
            Fail( "排序格式不正确" );
        if( drpLibrary.SelectedValue == "1" && string.IsNullOrEmpty( QF( "celebrityType" ) ) )
        {
            Fail( "请选择名人库类型" );
        }

        using (AW_Library_dao dao = new AW_Library_dao())
        {
            AW_Library_bean bean = new AW_Library_bean();
            bean.fdLibrID = dao.funcNewID();
            bean.fdLibrType = int.Parse(drpLibrary.SelectedValue);
            bean.fdLibrName = txtLibrName.Text.Trim();
            bean.fdLibrEnName = txtLibrEnName.Text.Trim();
            bean.fdLibrFirLetter = int.Parse( drpFirstLetter.SelectedValue );
            bean.fdLibrDesc = txtLibrDesc.Text;
            bean.fdLibrPic = QF( "imgPath" ).Trim();
            if (int.Parse(txtLibrOrder.Text) == 0)
            {
                bean.fdLibrSort = bean.fdLibrID * 100;
            }
            else
            {
                bean.fdLibrSort = int.Parse( txtLibrOrder.Text );
            }

            if( bean.fdLibrType == 1 )
            {
                string celebrityType = QF( "celebrityType" );
                if( celebrityType.IndexOf( "1" ) > -1 )
                {
                    bean.fdLibrCelebrityType1 = 1;
                }
                if( celebrityType.IndexOf( "2" ) > -1 )
                {
                    bean.fdLibrCelebrityType2 = 1;
                }
                if( celebrityType.IndexOf( "3" ) > -1 )
                {
                    bean.fdLibrCelebrityType3 = 1;
                }
                if( celebrityType.IndexOf( "4" ) > -1 )
                {
                    bean.fdLibrCelebrityType4 = 1;
                }
                if( celebrityType.IndexOf( "5" ) > -1 )
                {
                    bean.fdLibrCelebrityType5 = 1;
                }
            }

            dao.funcInsert(bean);

            if (int.Parse(drpLibrary.SelectedValue) == 1)
            {
                this.AddLog(EventType.Insert, "添加名人", "添加名人[" + bean.fdLibrName + "]");
            }
            else
            {
                this.AddLog(EventType.Insert, "添加品牌", "添加品牌[" + bean.fdLibrName + "]");
            }
            Success("添加成功", "LibraryList.aspx");
        }
    }
}
