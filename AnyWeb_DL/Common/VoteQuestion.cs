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
        /// ͶƱID
        /// </summary>
        public int VoteID
        {
            get { return _VoteID; }
            set { _VoteID = value; }
        }

        private string _VoteName;
        /// <summary>
        /// ͶƱ����
        /// </summary>
        public string VoteName
        {
            get { return _VoteName; }
            set { _VoteName = value; }
        }

        private DateTime _VoteCreateAt;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime VoteCreateAt
        {
            get { return _VoteCreateAt; }
            set { _VoteCreateAt = value; }
        }

        private DateTime _VoteEndAt;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime VoteEndAt
        {
            get { return _VoteEndAt; }
            set { _VoteEndAt = value; }
        }

        private bool _VoteIsShow;
        /// <summary>
        /// ��ʾ��ҳ(0����ʾ1��ʾ)
        /// </summary>
        public bool VoteIsShow
        {
            get { return _VoteIsShow; }
            set { _VoteIsShow = value; }
        }
	
    }
}
