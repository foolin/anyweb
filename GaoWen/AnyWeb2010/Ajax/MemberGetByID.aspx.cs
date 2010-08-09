using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWeb.AW_DL;

public partial class Ajax_MemberGetByID : ShopAjaxBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = int.Parse(this.QS("id"));
        AW_Member_bean member = AW_Member_bean.funcGetByID(id);
        if (member != null)
        {
            this.ExecuteSucc(this.FormatData(member));
        }
        else
        {
            this.ExecuteFalse(1, "不存在该会员");
        }
    }

    /// <summary>
    /// 格式化数据
    /// </summary>
    /// <param name="member"></param>
    /// <returns></returns>
    private string FormatData(AW_Member_bean member)
    {
        string data = "";
        data += "{";
        data += "provID:" + member.fdMembProvinceID.ToString() + ",";
        data += "cityID:" + member.fdMembCityID.ToString() + ",";
        data += "areaID:" + member.fdMembAreaID.ToString() + ",";
        data += "address:'" + member.fdMembAddress.Replace("'", "’") + "',";
        data += "name:'" + member.fdMembName + "',";
        data += "postcode:'" + member.fdMembPostcode.Replace("'", "’") + "',";
        data += "phone:'" + member.fdMembPhone + "'";
        data += "}";

        return data;
    }
}
