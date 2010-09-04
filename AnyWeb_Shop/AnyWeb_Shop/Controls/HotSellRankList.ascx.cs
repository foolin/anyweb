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
using Common.Agent;
using Common.Common;
using Studio.Web;

public partial class Controls_HotSellRankList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        ArrayList listStor = new ArrayList();
        ArrayList listShow = new ArrayList();

        if (Cache["HotSellRankListShow"] != null)
        {
            listShow = (ArrayList)Cache["HotSellRankListShow"];
        }
        else
        {
            listStor = new HotSellRankAgent().GetHotSellRankList();
            for (int i = 0; i < 5 && listStor.Count > 0; i++)
            {
                Random ra = new Random();
                int index = ra.Next(listStor.Count);
                listShow.Add(listStor[index]);
                listStor.Remove(listStor[index]);
            }
            HttpRuntime.Cache.Insert("HotSellRankListShow", listShow, null, DateTime.Now.AddHours(2), TimeSpan.Zero);
        }

        repList.DataSource = listShow;
        repList.DataBind();
    }


    private bool IsIn2Hours(DateTime dateTime)
    {
        DateTime today = DateTime.Now;
        TimeSpan ts = today - dateTime;
        if (ts.Hours >= 2)
            return false;
        return true;
    }
}
