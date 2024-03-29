using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace AnyWeb.AnyWeb_DL
{
    public class Column
    {
        public Column()
        { }

        public Column(DataRow row)
        {
            ColuID = (int)row["ColuID"];
            ColuName = (string)row["ColuName"];
            ColuCreateAt = (DateTime)row["ColuCreateAt"];
            ColuDesc = (string)row["ColuDesc"];
        }

        private int _ColuID;
        /// <summary>
        /// 栏目ID
        /// </summary>
        public int ColuID
        {
            get { return _ColuID; }
            set { _ColuID = value; }
        }

        private string _ColuName;
        /// <summary>
        /// 栏目名称
        /// </summary>
        public string ColuName
        {
            get { return _ColuName; }
            set { _ColuName = value; }
        }

        private DateTime _ColuCreateAt;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime ColuCreateAt
        {
            get { return _ColuCreateAt; }
            set { _ColuCreateAt = value; }
        }

        private string _ColuDesc;
        /// <summary>
        /// 栏目描述
        /// </summary>
        public string ColuDesc
        {
            get { return _ColuDesc; }
            set { _ColuDesc = value; }
        }
    }
}
