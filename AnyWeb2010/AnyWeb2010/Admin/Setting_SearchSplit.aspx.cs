using System;
using System.IO;
using System.Text;
using System.Xml;
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
using AnyWeb.AW_DL;
using Studio.IO;

public partial class Admin_Setting_SearchSplit : ShopAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        txtWord.Text = "";
        string path = Server.MapPath("~/App_Data/SearchSplit.xml");
        if(File.Exists(path))
        {
            XmlDocument xml;
            try
            {
                xml = new XmlDocument();
                xml.Load(path);
                XmlNode root = xml.SelectSingleNode("words");
                foreach (XmlNode node in root.SelectNodes("word"))
                {
                    txtWord.Text += node.InnerText + "\r\n";
                }
            }
            catch
            {
                txtWord.Text = "";
            }
        }

        if (txtWord.Text == "")
        {
            foreach (AW_Category_bean category1 in (new AW_Category_dao()).funcGetCategories())
            {
                txtWord.Text += category1.fdCateName + "\r\n";
                foreach (AW_Category_bean category2 in category1.Children)
                {
                    txtWord.Text += category2.fdCateName + "\r\n";
                    foreach (AW_Category_bean category3 in category2.Children)
                    {
                        txtWord.Text += category3.fdCateName + "\r\n";
                    }
                }
            }
            foreach (AW_Brand_bean brand1 in (new AW_Brand_dao()).funcGetBrands())
            {
                txtWord.Text += brand1.fdBranName + "\r\n";
                foreach (AW_Brand_bean brand2 in brand1.Children)
                {
                    txtWord.Text += brand2.fdBranName + "\r\n";
                }
            }
        }

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<?xml version=\"1.0\" encoding=\"gb2312\" ?>");
        sb.AppendLine("<words>");
        foreach (string word in txtWord.Text.Replace(" ", "").Split(new string[1]{"\r\n"}, StringSplitOptions.RemoveEmptyEntries))
        {
            sb.AppendLine("<word>" + word + "</word>");
        }
        sb.AppendLine("</words>");
        FileAgent.WriteText(Server.MapPath("~/App_Data/SearchSplit.xml"), sb.ToString(), false);
        WebAgent.SuccAndGo("保存成功", "Setting_SearchSplit.aspx");
    }
}
