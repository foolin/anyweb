using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    public class MemberGrade:IdObject
    {
        public MemberGrade(){  }

        public MemberGrade(DataRow dr)
        {
            this.ID = (int)dr["GradeID"];
            this._name = (string)dr["GradeName"];
            this._maxPoint = (int)dr["MaxPoint"];
            this._shopid = (int)dr["ShopID"];
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _maxPoint;

        public int MaxPoint
        {
            get { return _maxPoint; }
            set { _maxPoint = value; }
        }

        private int _shopid;

        public int ShopID
        {
            get { return _shopid; }
            set { _shopid = value; }
        }

    }
}
