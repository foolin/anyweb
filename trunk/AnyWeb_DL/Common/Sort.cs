using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace AnyWeb.AnyWeb_DL
{
    public class Sort
    {
        public Sort()
        { }

        public Sort(DataRow row,string choice)
        {
            if (choice == "photo")
            {
                SortID = (int)row["SortID"];
                SortName = (string)row["SortName"];
                SortCreateAt = (DateTime)row["SortCreateAt"];
                SortDesc = (string)row["SortDesc"];
            }
            if (choice == "link")
            {
                SortID = (int)row["LinkSortID"];
                SortName = (string)row["LinkSortName"];
                SortCreateAt = (DateTime)row["LinkSortCreateAt"];
                SortDesc = (string)row["LinkSortDesc"];
            }
        }

        private int _SortID;
        /// <summary>
        /// 栏目ID
        /// </summary>
        public int SortID
        {
            get { return _SortID; }
            set { _SortID = value; }
        }

        private string _SortName;
        /// <summary>
        /// 栏目名称
        /// </summary>
        public string SortName
        {
            get { return _SortName; }
            set { _SortName = value; }
        }

        private DateTime _SortCreateAt;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime SortCreateAt
        {
            get { return _SortCreateAt; }
            set { _SortCreateAt = value; }
        }

        private string _SortDesc;
        /// <summary>
        /// 栏目描述
        /// </summary>
        public string SortDesc
        {
            get { return _SortDesc; }
            set { _SortDesc = value; }
        }
    }
}
