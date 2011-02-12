using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Goods_bean
	{
        private AW_Category_bean _category;
        /// <summary>
        /// 所属分类
        /// </summary>
        public AW_Category_bean Category
        {
            get { return _category; }
            set { _category = value; }
        }

        private List<AW_Goods_Picture_bean> _pictures;
        /// <summary>
        /// 图片
        /// </summary>
        public List<AW_Goods_Picture_bean> Pictures
        {
            get { return _pictures; }
            set { _pictures = value; }
        }

        private AW_Brand_bean _brand;
        /// <summary>
        /// 所属品牌
        /// </summary>
        public AW_Brand_bean Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        private string _pathStr;
        /// <summary>
        /// 访问路径
        /// </summary>
        public string PathStr
        {
            get
            {
                if (HttpContext.Current.Request.ApplicationPath == "/")
                {
                    return string.Format("/p/{0}/{1}.aspx", fdGoodCategoryID, fdGoodID);
                }
                else
                {
                    return string.Format("/{0}/p/{1}/{2}.aspx", HttpContext.Current.Request.ApplicationPath, fdGoodCategoryID, fdGoodID);
                }
            }
            set { _pathStr = value; }
        }
	}
}
