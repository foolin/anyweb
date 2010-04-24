﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;

public partial class Admin_RelationList : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        foreach (AW_Column_bean bean1 in (new AW_Column_dao()).funcGetColumns())
        {
            drpColumn.Items.Add(new ListItem(bean1.fdColuName, bean1.fdColuID.ToString()));
            if (!string.IsNullOrEmpty(QS("id")) && bean1.fdColuID == int.Parse(QS("id")))
            {
                foreach (AW_Column_bean bean2 in bean1.Children)
                {
                    drpChildColumn.Items.Add(new ListItem(bean2.fdColuName, bean2.fdColuID.ToString()));
                }
            }
        }

        ListItem li = drpColumn.Items.FindByValue(QS("id"));
        if (li != null) li.Selected = true;

        li = drpChildColumn.Items.FindByValue(QS("cid"));
        if (li != null) li.Selected = true;

        int columnID = 0;
        if (drpChildColumn.SelectedValue != "0")
        {
            columnID = int.Parse(drpChildColumn.SelectedValue);
        }
        else
        {
            columnID = int.Parse(drpColumn.SelectedValue);
        }

        AW_Column_bean column = (new AW_Column_dao()).funcGetColumnInfo(columnID);


        using (AW_Relation_dao dao = new AW_Relation_dao())
        {
            compRep.DataSource = dao.funcGetRelation(column, PN1.PageSize, PN1.PageIndex);
            compRep.DataBind();
            PN1.SetPage(dao.propCount);
        }
    }
}
