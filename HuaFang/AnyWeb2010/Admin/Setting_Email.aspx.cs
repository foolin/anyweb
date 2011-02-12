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
using Studio.Web;
using AnyWell.AW_DL;
using AnyWell.Configs;

public partial class Admin_Setting_Email : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        repSmtp.DataSource = SmtpAgent.GetAgent().Smtps;
        repSmtp.DataBind();
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        if (txtPassword.Text == "" || txtPort.Text == "" || txtSender.Text == "" || txtServerAddress.Text == "" || txtUserName.Text == "")
            WebAgent.AlertAndBack("请输入数据");
        else if (!WebAgent.IsInt32(txtPort.Text))
            WebAgent.AlertAndBack("端口必须是数字");

        Smtp smtp = new Smtp();
        smtp.ID = SmtpAgent.GetAgent().Smtps.Count == 0 ? 1 : (SmtpAgent.GetAgent().Smtps[SmtpAgent.GetAgent().Smtps.Count - 1].ID + 1);
        smtp.Password = txtPassword.Text;
        smtp.Port = int.Parse(txtPort.Text);
        smtp.Sender = txtSender.Text;
        smtp.ServerAddress = txtServerAddress.Text;
        smtp.UserName = txtUserName.Text;
        smtp.EnableSsl = boxEnableSsl.Checked;
        SmtpAgent.GetAgent().Smtps.Add(smtp);

        SmtpAgent.GetAgent().Save();
        this.AddLog(EventType.Insert, "添加邮件设置", "添加邮件设置[" + smtp.Sender + "]");
        WebAgent.SuccAndGo("添加成功","?rd=" + (new Random()).Next(1000,9999).ToString());
    }

    protected void repSmtp_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label lbl = (Label)e.Item.FindControl("lblID");
        string addr = "";
        if (e.CommandName == "Delete")
        {
            for (int i = 0; i < SmtpAgent.GetAgent().Smtps.Count; i++)
            {
                if (SmtpAgent.GetAgent().Smtps[i].ID == int.Parse(lbl.Text))
                {
                    addr = SmtpAgent.GetAgent().Smtps[i].Sender;
                    SmtpAgent.GetAgent().Smtps.RemoveAt(i);
                    this.AddLog(EventType.Delete, "删除邮件设置", "批量删除关键词编号[" + addr + "]");
                    break;
                }
            }
        }
        else
        {
            CheckBox box = (CheckBox)e.Item.FindControl("boxEnableSsl");
            TextBox txtSender1 = (TextBox)e.Item.FindControl("txtSender");
            TextBox txtPort1 = (TextBox)e.Item.FindControl("txtPort");
            TextBox txtPassword1 = (TextBox)e.Item.FindControl("txtPassword");
            TextBox txtServerAddress1 = (TextBox)e.Item.FindControl("txtServerAddress");
            TextBox txtUserName1 = (TextBox)e.Item.FindControl("txtUserName");
            if (txtPassword1.Text == "" || txtPort1.Text == "" || txtSender1.Text == "" || txtServerAddress1.Text == "" || txtUserName1.Text == "")
                WebAgent.AlertAndBack("请输入数据");
            else if (!WebAgent.IsInt32(txtPort1.Text))
                WebAgent.AlertAndBack("端口必须是数字");

            foreach (Smtp smtp in SmtpAgent.GetAgent().Smtps)
            {
                if (smtp.ID == int.Parse(lbl.Text))
                {
                    smtp.Password = txtPassword1.Text;
                    smtp.Port = int.Parse(txtPort1.Text);
                    smtp.Sender = txtSender1.Text;
                    smtp.ServerAddress = txtServerAddress1.Text;
                    smtp.UserName = txtUserName1.Text;
                    smtp.EnableSsl = box.Checked;
                    this.AddLog(EventType.Update, "修改邮件设置", "修改邮件设置[" + smtp.Sender + "]");
                }
            }
        }

        SmtpAgent.GetAgent().Save();
        WebAgent.SuccAndGo("操作成功", "?rd=" + (new Random()).Next(1000, 9999).ToString());
    }
}
