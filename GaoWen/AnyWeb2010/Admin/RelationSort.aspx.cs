using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWeb.AW_DL;

public partial class Admin_RelationSort : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        int relationId = 0;
        int previewId = 0;
        int nextId = 0;

        if (QS("id") != "" && WebAgent.IsInt32(QS("id")))
            relationId = int.Parse(QS("id"));

        if (QS("previewid") != "" && WebAgent.IsInt32(QS("previewid")))
            previewId = int.Parse(QS("previewid"));

        if (QS("nextid") != "" && WebAgent.IsInt32(QS("nextid")))
            nextId = int.Parse(QS("nextid"));

        if (relationId > 0 && (previewId > 0 || nextId > 0))
        {
            using (AW_Relation_dao dao = new AW_Relation_dao())
            {
                dao.funcSortRelation(relationId, nextId, previewId);
                Response.Write("ok");
            }
        }
        else
        {
            Response.Write("parmaters null");
        }
    }
}
