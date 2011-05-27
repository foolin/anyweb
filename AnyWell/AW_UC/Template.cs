using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using AnyWell.AW_DL;

namespace AnyWell.AW_UC
{
    /// <summary>
    /// 嵌套模板组件,可嵌套其他模板
    /// </summary>
    public class Template : Control, INamingContainer
    {
        private string _name;
        /// <summary>
        /// 模板名称
        /// </summary>
        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        protected override void OnInit( EventArgs e )
        {
            string templateFolder = "/Files/Template/";
            int sid = 0;
            if( Context != null && Context.Request.QueryString[ "sid" ] != null )
            {
                int.TryParse( Context.Request.QueryString[ "sid" ], out sid );
            }
            if( sid == 0 && Context != null && Context.Request.QueryString[ "cid" ] != null )
            {
                int cid = int.Parse( Context.Request.QueryString[ "cid" ] );
                AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( cid );
                if( column != null )
                {
                    sid = column.Site.fdSiteID;
                }
            }
            if( sid > 0 )
            {
                AW_Site_bean site = new AW_Site_dao().funcGetSiteInfo( sid );
                templateFolder += site.fdSiteID.ToString() + "/";
            }
            string ctlPath = templateFolder + "/" + this.Name + ".ascx";
            //检查循环嵌套
            if( ctlPath.ToLower().Replace( "/", "_" ).Replace( ".ascx", "_ascx" ).EndsWith( Parent.GetType().Name.ToLower() ) )
            {
                this.Controls.Clear();
                this.Controls.Add( new LiteralControl( "<font color='red'>嵌套模板不能嵌套自己！[模板名：" + this.Name + "]</font>" ) );
            }
            else
            {
                Control template = Page.LoadControl( ctlPath );
                Controls.Add( template );
                base.OnInit( e );
            }
        }
    }
}
