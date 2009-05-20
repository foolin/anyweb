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

public partial class MasterPage : System.Web.UI.MasterPage
{
    public string Path = "";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        DropMenuItem dmi;
        if (Path == "")
            dmi = (new DropMenu()).GetItemByPath(Request.FilePath, null);
        else
            dmi = (new DropMenu()).GetItemByPath(Request.FilePath.Replace(Path, ""), null);
        string pos;

        if (dmi != null)
        {
            if (dmi.Parent == null)
            {
                pos = dmi.Name;
            }
            else
            {
                if (dmi.Parent.Parent == null)
                {
                    pos = string.Format("{0}&gt; {1}", dmi.Parent.Name, dmi.Name);
                }
                else
                {
                    if (dmi.Parent.Parent.Parent == null)
                    {
                        pos = string.Format("{0} &gt; {1}", dmi.Parent.Name, dmi.Name);
                    }
                    else
                    {
                        pos = string.Format("{0} &gt; {1} &gt; {2}", dmi.Parent.Parent.Name, dmi.Parent.Name, dmi.Name);
                    }

                }
            }

            this.compPos.Text = pos;
        }
    }
}
