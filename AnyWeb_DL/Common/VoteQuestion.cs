using System;
using System.Collections.Generic;
using System.Text;

namespace AnyWeb_DL
{
    public class VoteQuestion
    {
        public VoteQuestion()
        { }

        private int _VoteID;
        /// <summary>
        /// 投票ID
        /// </summary>
        public int VoteID
        {
            get { return _VoteID; }
            set { _VoteID = value; }
        }

        private string _VoteName;
        /// <summary>
        /// 投票问题
        /// </summary>
        public string VoteName
        {
            get { return _VoteName; }
            set { _VoteName = value; }
        }

        private DateTime _VoteCreateAt;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime VoteCreateAt
        {
            get { return _VoteCreateAt; }
            set { _VoteCreateAt = value; }
        }

        private DateTime _VoteEndAt;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime VoteEndAt
        {
            get { return _VoteEndAt; }
            set { _VoteEndAt = value; }
        }

        private bool _VoteIsShow;
        /// <summary>
        /// 显示首页(0不显示1显示)
        /// </summary>
        public bool VoteIsShow
        {
            get { return _VoteIsShow; }
            set { _VoteIsShow = value; }
        }
	
    }
}
