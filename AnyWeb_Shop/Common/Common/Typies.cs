using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    /// <summary>
    /// 模版类别实体
    /// </summary>
    public class Typies:IdObject
    {
        public  Typies() { }

        public  Typies(DataRow dr)
        {
            this.ID = (int)dr["TypeID"];
            this._typeName = (string)dr["TypeName"];
            this._description = (string)dr["Description"];
        }

        private string _typeName;
        /// <summary>
        /// 模版类别名称
        /// </summary>
        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }

        private string _description;
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

    }
}
