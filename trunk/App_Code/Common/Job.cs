using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// 工作对象
/// </summary>
public class Job
{
    public Job(){}

    public Job(DataRow r)
    {
        ID = (short)r["job_id"];
        Name = (string)r["job_desc"];
    }

    private short _id;
    /// <summary>
    /// 编号
    /// </summary>
    public short ID
    {
        get { return _id; }
        set { _id = value; }
    }

    private string _name;
    /// <summary>
    /// 名称
    /// </summary>
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
}
