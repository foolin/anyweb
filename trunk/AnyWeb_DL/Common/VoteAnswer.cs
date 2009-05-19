using System;
using System.Collections.Generic;
using System.Text;

namespace AnyWeb.AnyWeb_DL
{
    public class VoteAnswer
    {
        public VoteAnswer()
        { }

        private int _VoteID;
        /// <summary>
        /// 答案ID
        /// </summary>
        public int VoteID
        {
            get { return _VoteID; }
            set { _VoteID = value; }
        }

        private string _VoteResult;
        /// <summary>
        /// 投票答案
        /// </summary>
        public string VoteResult
        {
            get { return _VoteResult; }
            set { _VoteResult = value; }
        }

        private int _VoteQuestionID;
        /// <summary>
        /// 投票ID
        /// </summary>
        public int VoteQuestionID
        {
            get { return _VoteQuestionID; }
            set { _VoteQuestionID = value; }
        }

        private int _VoteCount;
        /// <summary>
        /// 投票数
        /// </summary>
        public int VoteCount
        {
            get { return _VoteCount; }
            set { _VoteCount = value; }
        }
	
    }
}
