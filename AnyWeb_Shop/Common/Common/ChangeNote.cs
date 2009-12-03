using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    public class ChangeNote:  IdObject
    {
        public ChangeNote() { }

        public ChangeNote(DataRow dr)
        {
            this.ID = (int)dr["ChangeNoteID"];
            this._orderID = (int)dr["OrderID"];
            this._changeID = (int)dr["ChangeID"];
            this._userID = (int)dr["UserID"];
            this._noteTime = (DateTime)dr["NoteTime"];
            this._sendStatus = (int)dr["SendStatus"];
            this._scroe = (int)dr["Score"];
            this._ofchangeGoods = new ChangeGoods();
        }

        private int _orderID;

        public int OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }

        private int _userID;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private int _changeID;

        public int ChangeID
        {
            get { return _changeID; }
            set { _changeID = value; }
        }

        private DateTime _noteTime;

        public DateTime NoteTime
        {
            get { return _noteTime; }
            set { _noteTime = value; }
        }

        private int _sendStatus;
        /// <summary>
        /// 发货状态 1－未发货 2－已发货
        /// </summary>
        public int SendStatus
        {
            get { return _sendStatus; }
            set { _sendStatus = value; }
        }

        private int _scroe;
        /// <summary>
        /// 积分
        /// </summary>
        public int Score
        {
            get { return _scroe; }
            set { _scroe = value; }
        }


        private ChangeGoods _ofchangeGoods;
        /// <summary>
        /// 
        /// </summary>
        public ChangeGoods OfChangeGoods
        {
            get { return _ofchangeGoods; }
            set { _ofchangeGoods = value; }
        }



    }
}
