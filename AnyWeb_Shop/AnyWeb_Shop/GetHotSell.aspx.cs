using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Common.Agent;

public partial class GetHotSell : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        ArrayList listStor = new ArrayList();
        ArrayList listShow = new ArrayList();

        listStor = new HotSellRankAgent().GetHotSellRankList();
        for (int i = 0; i < 8 && listStor.Count > 0; i++)
        {
            Random ra = new Random();
            int index = ra.Next(listStor.Count);
            listShow.Add(listStor[index]);
            listStor.Remove(listStor[index]);
        }

        repHot.DataSource = listShow;
        repHot.DataBind();
    }
}
