using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    public class SingleArticle : IdObject
    {
        public SingleArticle() { }

        public SingleArticle(DataRow dr)
        {
            this.ID = (int)dr["SingleArticleID"];
            this._categoryid = (int)dr["CategoryID"];
            this._content = (string)dr["Content"];

            this._ofCategory = new Category();
        }


        private string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private int _categoryid;

        public int CategoryID
        {
            get { return _categoryid; }
            set { _categoryid = value; }
        }

        private Category _ofCategory;

        public Category OfCategory
        {
            get { return _ofCategory; }
            set { _ofCategory = value; }
        }


    }
}
