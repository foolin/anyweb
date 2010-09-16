using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class User_EduSave : PageUser
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        string type = QS("type");
        if (string.IsNullOrEmpty(type))
        {
            Response.Clear();
            Response.Write("");
            Response.End();
        }
        if (type == "add")
        {
            if (string.IsNullOrEmpty(QS("id")) || !WebAgent.IsInt32(QS("id")) || string.IsNullOrEmpty(QS("eduid")) || !WebAgent.IsInt32(QS("eduid")))
            {
                Response.Clear();
                Response.Write("");
                Response.End();
            }
            AW_Resume_bean resume = AW_Resume_bean.funcGetByID(int.Parse(QS("id")));
            bean = new AW_Education_bean();
            bean.fdEducID = int.Parse(QS("eduid"));
            bean.fdEducResuID = int.Parse(QS("id"));
            bean.fdEducBegin = DateTime.Parse(string.Format("{0}-{1}-1", QF("FromYear"), QF("FromMonth")));
            if (QF("ToYear") != "0" && QF("ToMonth") != "0")
                bean.fdEducEnd = DateTime.Parse(string.Format("{0}-{1}-1", QF("ToYear"), QF("ToMonth")));
            else
                bean.fdEducEnd = DateTime.Parse("2099-1-1");
            bean.fdEducSchool = QF("SchoolName");
            if (string.IsNullOrEmpty(QF("SubMajor")) || QF("SubMajor") == "0")
            {
                bean.fdEducSpeciality = 0;
                bean.fdEducOtherSpecialty = QF("MoreMajor");
            }
            else
            {
                bean.fdEducSpeciality = int.Parse(QF("SubMajor"));
                bean.fdEducOtherSpecialty = "";
            }
            bean.fdEducDegree = int.Parse(QF("Degree"));
            if (!string.IsNullOrEmpty(QF("fdEducIntro")))
                bean.fdEducIntro = QF("fdEducIntro");
            new AW_Education_dao().funcInsert(bean);
            if (resume.fdResuStatus == 1)
            {
                resume.fdResuStatus = 0;
                new AW_Resume_dao().funcUpdate(resume);
            }
        }
        else if (type == "edit")
        {
            if (string.IsNullOrEmpty(QS("eduid")) || !WebAgent.IsInt32(QS("eduid")))
            {
                Response.Clear();
                Response.Write("");
                Response.End();
            }
            bean = AW_Education_bean.funcGetByID(int.Parse(QS("eduid")));
            if (bean == null)
            {
                Response.Clear();
                Response.Write("");
                Response.End();
            }
            AW_Resume_bean resume = AW_Resume_bean.funcGetByID(bean.fdEducResuID);
            if (resume == null)
            {
                Response.Clear();
                Response.Write("");
                Response.End();
            }
            if (resume.fdResuUserID != this.LoginUser.fdUserID)
            {
                Response.Clear();
                Response.Write("");
                Response.End();
            }
            bean.fdEducBegin = DateTime.Parse(string.Format("{0}-{1}-1", QF("FromYear"), QF("FromMonth")));
            if (QF("ToYear") != "0" && QF("ToMonth") != "0")
                bean.fdEducEnd = DateTime.Parse(string.Format("{0}-{1}-1", QF("ToYear"), QF("ToMonth")));
            else
                bean.fdEducEnd = DateTime.Parse("2099-1-1");
            bean.fdEducSchool = QF("SchoolName");
            if (string.IsNullOrEmpty(QF("SubMajor")) || QF("SubMajor") == "0")
            {
                bean.fdEducSpeciality = 0;
                bean.fdEducOtherSpecialty = QF("MoreMajor");
            }
            else
            {
                bean.fdEducSpeciality = int.Parse(QF("SubMajor"));
                bean.fdEducOtherSpecialty = "";
            }
            bean.fdEducDegree = int.Parse(QF("Degree"));
            if (!string.IsNullOrEmpty(QF("fdEducIntro")))
                bean.fdEducIntro = QF("fdEducIntro");
            new AW_Education_dao().funcUpdate(bean);
        }
        else
        {
            Response.Clear();
            Response.Write("");
            Response.End();
        }
    }

    private AW_Education_bean _bean;
    public AW_Education_bean bean
    {
        get { return _bean; }
        set { _bean = value; }
    }
}
