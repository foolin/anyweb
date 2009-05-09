using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Studio.Data;
using Studio.Security;

/// <summary>
/// ϵͳ����
/// </summary>
public class Setting
{
	public Setting()
	{
        this.DBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        this.DBType = (DatabaseType)int.Parse(System.Configuration.ConfigurationManager.AppSettings["DbType"]);
        this.Jobs = (new JobAgent(this.DBConnectionString)).GetJobList();
    }

    private List<Job> _jobs;
    /// <summary>
    /// ְλ�б�
    /// </summary>
    public List<Job> Jobs
    {
        get { return _jobs; }
        set { _jobs = value; }
    }

    /// <summary>
    /// ����Ż�ȡְλ
    /// </summary>
    /// <param name="jobID"></param>
    /// <returns></returns>
    public Job GetJobById(int jobID)
    {
        foreach (Job job in _jobs)
        {
            if (job.ID == jobID) return job;
        }
        return null;
    }

    private string _dbConnectionString;
    /// <summary>
    /// ���ݿ������ַ���
    /// </summary>
    public string DBConnectionString
    {
        get { return _dbConnectionString; }
        set { _dbConnectionString = value; }
    }

    private DatabaseType _dbType;
    /// <summary>
    /// ���ݿ�����
    /// </summary>
    public DatabaseType DBType
    {
        get { return _dbType; }
        set { _dbType = value; }
    }

    public static Setting GetSetting()
    {
        return Nested.instance;
    }
    class Nested
    {
        static Nested() { }
        internal static readonly Setting instance = new Setting();
    }
}
