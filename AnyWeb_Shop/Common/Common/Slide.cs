using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    public class Slide : IdObject
    {
        public Slide() { }

        public Slide(DataRow dr)
        {
            this.ID = (int)dr["SlideID"];
            _slideFile = (string)dr["SlideFile"];
            _slideLink = dr["SlideLink"]==System.DBNull.Value  ? "" :(string)dr["SlideLink"];
            _shopID = (int)dr["ShopID"];
            _sort = (int)dr["Sort"];
        }

        private string _slideFile;
        /// <summary>
        /// 幻灯片路径
        /// </summary>
        public string SlideFile
        {
            get { return _slideFile; }
            set { _slideFile = value; }
        }

        private int _shopID;
        /// <summary>
        /// 商城编号
        /// </summary>
        public int ShopID
        {
            get { return _shopID; }
            set { _shopID = value; }
        }

        private string _slideLink;
        /// <summary>
        /// 幻灯片链接
        /// </summary>
        public string SlideLink
        {
            get { return _slideLink; }
            set { _slideLink = value; }
        }

        private int _sort;
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }

        private string _slideUrl;
        public string SlideUrl
        {
            get 
            {
                if ( SlideFile != null && ShopID > 0 )
                {
                    return "/Shopdata/" + this.ShopID + "/Slide" + this.SlideFile;
                }
                else
                {
                    return null;
                }
            }
        
        }

    }

	
}
