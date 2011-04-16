using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Site_bean
	{
        private List<AW_Column_bean> _Columns;
        /// <summary>
        /// 子栏目
        /// </summary>
        public List<AW_Column_bean> Columns
        {
            get
            {
                return _Columns;
            }
            set
            {
                _Columns = value;
            }
        }

        private List<AW_Template_bean> _TemplateList;
        /// <summary>
        /// 模板列表
        /// </summary>
        public List<AW_Template_bean> TemplateList
        {
            get
            {
                return _TemplateList;
            }
            set
            {
                _TemplateList = value;
            }
        }

        private AW_Template_bean _IndexTemplate;
        /// <summary>
        /// 首页模板
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

        private AW_Template_bean _ColumnTemplate;
        /// <summary>
        /// 栏目模板
        /// </summary>
        public AW_Template_bean ColumnTemplate
        {
            get
            {
                return _ColumnTemplate;
            }
            set
            {
                _ColumnTemplate = value;
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
        /// 获取模板
        /// </summary>
        /// <param name="tid">模板编号</param>
        /// <returns></returns>
        public AW_Template_bean GetTemplate( int tid )
        {
            foreach( AW_Template_bean bean in TemplateList )
            {
                if( bean.fdTempID == tid )
                {
                    return bean;
                }
            }
            return null;
        }

        /// <summary>
        /// 从站点缓存里面获取栏目对象
        /// </summary>
        /// <param name="list"></param>
        /// <param name="columnID"></param>
        /// <returns></returns>
        public AW_Column_bean funcGetColumnByID( List<AW_Column_bean> list, int columnID )
        {
            foreach( AW_Column_bean column in list )
            {
                if( column.fdColuID == columnID )
                    return column;
                else
                {
                    if( column.Children != null && column.Children.Count > 0 )
                    {
                        AW_Column_bean child = funcGetColumnByID( column.Children, columnID );
                        if( child != null )
                            return child;
                    }
                }
            }
            return null;
        }
	}
}
