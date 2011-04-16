using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Column_bean
	{
        private AW_Site_bean _Site;
        /// <summary>
        /// 所属站点
        /// </summary>
        public AW_Site_bean Site
        {
            get
            {
                return _Site;
            }
            set
            {
                _Site = value;
            }
        }

        private List<AW_Column_bean> _Children;
        /// <summary>
        /// 子栏目
        /// </summary>
        public List<AW_Column_bean> Children
        {
            get
            {
                return _Children;
            }
            set
            {
                _Children = value;
            }
        }

        private AW_Column_bean _Parent;
        /// <summary>
        /// 父栏目
        /// </summary>
        public AW_Column_bean Parent
        {
            get
            {
                return _Parent;
            }
            set
            {
                _Parent = value;
            }
        }

        private AW_Template_bean _IndexTemplate;
        /// <summary>
        /// 栏目模板
        /// </summary>
        public AW_Template_bean IndexTemplate
        {
            get
            {
                return _IndexTemplate;
            }
            set
            {
                _IndexTemplate = value;
            }
        }

        private AW_Template_bean _ContentTemplate;
        /// <summary>
        /// 内容模板
        /// </summary>
        public AW_Template_bean ContentTemplate
        {
            get
            {
                return _ContentTemplate;
            }
            set
            {
                _ContentTemplate = value;
            }
        }

        /// <summary>
        /// 栏目层级路径
        /// </summary>
        public string ColumnIDPath
        {
            get
            {
                string path = getColumnPath( this, "" );
                return path.Substring( 0, path.Length - 1 );
            }
        }

        private string getColumnPath(AW_Column_bean bean,string path)
        {
            path = string.Format( "{0}.{1}", bean.fdColuID, path );
            if( bean.Parent != null )
            {
                path = getColumnPath( bean.Parent, path );
            }
            return path;
        }

        /// <summary>
        /// 栏目类型
        /// </summary>
        public string ColumnTypeText
        {
            get
            {
                switch( this.fdColuType )
                {
                    case (int)ColumnType.Article:
                        return "文章栏目";
                    case (int)ColumnType.Album:
                        return "图片栏目";
                    case (int)ColumnType.Product:
                        return "产品栏目";
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// 获取某个栏目下所有栏目编号
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public string ColumnAndChildrenString()
        {
            string str = "";
            foreach( AW_Column_bean column in this.Children )
            {
                str += "," + column.ColumnAndChildrenString();
            }
            return ( str + "," + this.fdColuID ).Substring( 1 );
        }
	}

    /// <summary>
    /// 1-文章，2-图库，3-产品
    /// </summary>
    public enum ColumnType
    {
        Article = 0,
        Product = 1,
        Album = 2
    }
}
