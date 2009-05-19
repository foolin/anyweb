using System;
using System.Collections.Generic;
using System.Text;

namespace AnyWeb_DL
{
    public class Leave
    {
        public Leave()
        { }

        private int _LeavID;
        /// <summary>
        /// 留言ID
        /// </summary>
        public int LeavID
        {
            get { return _LeavID; }
            set { _LeavID = value; }
        }

        private int _LeavDepartment;
        /// <summary>
        /// 反馈部门(1:办公室2:综合处3:财务处4:劳动工资处5:审计处6:保卫处)
        /// </summary>
        public int LeavDepartment
        {
            get { return _LeavDepartment; }
            set { _LeavDepartment = value; }
        }

        private bool _LeavType;
        /// <summary>
        /// 留言类型(0:公众留言1:办事咨询)
        /// </summary>
        public bool LeavType
        {
            get { return _LeavType; }
            set { _LeavType = value; }
        }

        private string _LeavUserName;
        /// <summary>
        /// 姓名
        /// </summary>
        public string LeavUserName
        {
            get { return _LeavUserName; }
            set { _LeavUserName = value; }
        }

        private string _LeavPhone;
        /// <summary>
        /// 留言电话
        /// </summary>
        public string LeavPhone
        {
            get { return _LeavPhone; }
            set { _LeavPhone = value; }
        }

        private string _LeavEmail;
        /// <summary>
        /// 留言信箱
        /// </summary>
        public string LeavEmail
        {
            get { return _LeavEmail; }
            set { _LeavEmail = value; }
        }

        private string _LeavTitle;
        /// <summary>
        /// 意见标题
        /// </summary>
        public string LeavTitle
        {
            get { return _LeavTitle; }
            set { _LeavTitle = value; }
        }

        private string _LeavContent;
        /// <summary>
        /// 意见描述
        /// </summary>
        public string LeavContent
        {
            get { return _LeavContent; }
            set { _LeavContent = value; }
        }

        private string _LeavIP;
        /// <summary>
        /// 留言IP
        /// </summary>
        public string LeavIP
        {
            get { return _LeavIP; }
            set { _LeavIP = value; }
        }

        private DateTime _LeavCreateAt;
        /// <summary>
        /// 留言时间
        /// </summary>
        public DateTime LeavCreateAt
        {
            get { return _LeavCreateAt; }
            set { _LeavCreateAt = value; }
        }

        private bool _LeavDeleted;
        /// <summary>
        /// 0:正常1:已删除
        /// </summary>
        public bool LeavDeleted
        {
            get { return _LeavDeleted; }
            set { _LeavDeleted = value; }
        }

        private string _LeavRevert;
        /// <summary>
        /// 回复内容
        /// </summary>
        public string LeavRevert
        {
            get { return _LeavRevert; }
            set { _LeavRevert = value; }
        }

        private DateTime _LeavRevertat;
        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime LeavRevertat
        {
            get { return _LeavRevertat; }
            set { _LeavRevertat = value; }
        }
    }
}
