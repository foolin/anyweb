using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using Common.Agent;
using Common.Common;

public partial class Web_Category : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected override void OnPreRender(EventArgs e)
    {
        if (!string.IsNullOrEmpty(QS("cid")))
        {
            if (WebAgent.IsInt32(QS("cid")))
            {
                Category c = new CategoryAgent().GetCategoryByid(int.Parse(QS("cid")));
                if (c == null)
                    WebAgent.FailAndGo("类别不存在！", "index.aspx");
                else
                    Context.Items.Add("CATEGORY", c);
                this.Title = c.Name;
            }
            else
                WebAgent.FailAndGo("参数错误！", "index.aspx");
        }
    }
}
