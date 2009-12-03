using System;
using System.Text;
using Studio.Data;
using System.Data;

namespace Studio.Security
{
    public class KeywordFilterAgent : DbAgent
    {
        //public KeywordFilterAgent() : base((DatabaseType)int.Parse(System.Configuration.ConfigurationManager.AppSettings["DbType"]), System.Configuration.ConfigurationManager.ConnectionStrings["FilterConnectionString"].ConnectionString) {}

        public void SetConnection(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.DBType = DatabaseType.SqlServer;
        }

        public string GetConnection()
        {
            return this.ConnectionString;
        }

        public void AddFilter(KeywordFilter kf)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                db.ExecuteNonQuery(CommandType.StoredProcedure, "ft_FilterAdd",
                    this.NewParam("@ColumnID", kf.ColumnID),
                    this.NewParam("@ContentID", kf.ContentID),
                    this.NewParam("@StringID", kf.StringID),
                    this.NewParam("@SiteName", kf.SiteName),
                    this.NewParam("@Content", kf.Content),
                    this.NewParam("@Keyword", kf.Keyword == null ? "" : kf.Keyword),
                    this.NewParam("@UserCode", kf.UserCode),
                    this.NewParam("@UserName", kf.UserName),
                    this.NewParam("@Domain", kf.Domain),
                    this.NewParam("@IP", kf.IP),
                    this.NewParam("@Url", kf.Url));
            }
        }
    }

    public class KeywordFilter
    {
        public KeywordFilter()
        { }

        private int _ID;
        /// <summary>
        /// ��ʶID
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _ColumnID;
        /// <summary>
        /// ��ĿID
        /// </summary>
        public int ColumnID
        {
            get { return _ColumnID; }
            set { _ColumnID = value; }
        }

        private int _ContentID;
        /// <summary>
        /// ����ID
        /// </summary>
        public int ContentID
        {
            get { return _ContentID; }
            set { _ContentID = value; }
        }

        private string _StringID;
        /// <summary>
        /// �����ַ���ID
        /// </summary>
        public string StringID
        {
            get { return _StringID; }
            set { _StringID = value; }
        }

        private string _SiteName;
        /// <summary>
        /// վ������
        /// </summary>
        public string SiteName
        {
            get { return _SiteName; }
            set { _SiteName = value; }
        }

        private string _Content;
        /// <summary>
        /// ��������(ͼƬ���ӵ�ַ)
        /// </summary>
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        private int _UserCode;
        /// <summary>
        /// ͨ��֤
        /// </summary>
        public int UserCode
        {
            get { return _UserCode; }
            set { _UserCode = value; }
        }

        private string _UserName;
        /// <summary>
        /// �ʺ�
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _Domain;
        /// <summary>
        /// ����(ͼƬ�������¡���ᡢ���ӻ��Ʒ��ַ)
        /// </summary>
        public string Domain
        {
            get { return _Domain; }
            set { _Domain = value; }
        }

        private string _IP;
        /// <summary>
        /// �û�IP
        /// </summary>
        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }

        private DateTime _CreateAt;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CreateAt
        {
            get { return _CreateAt; }
            set { _CreateAt = value; }
        }

        private string _Url;
        /// <summary>
        /// URL��ַ(ͼƬURL��ַ)
        /// </summary>
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }

        private string _keyword;
        /// <summary>
        /// �Ƿ��ؼ���
        /// </summary>
        public string Keyword
        {
            get { return _keyword; }
            set { _keyword = value; }
        }

        private int _AdminID;
        /// <summary>
        /// ����ԱID
        /// </summary>
        public int AdminID
        {
            get { return _AdminID; }
            set { _AdminID = value; }
        }

        private DateTime _DeletedAt;
        /// <summary>
        /// ɾ��ʱ��
        /// </summary>
        public DateTime DeletedAt
        {
            get { return _DeletedAt; }
            set { _DeletedAt = value; }
        }

        private bool _Deleted;
        /// <summary>
        /// ��ɾ��
        /// </summary>
        public bool Deleted
        {
            get { return _Deleted; }
            set { _Deleted = value; }
        }

    }
}
