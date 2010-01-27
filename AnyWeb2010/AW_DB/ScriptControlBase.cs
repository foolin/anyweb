using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Reflection;

namespace FortuneAge.AW_UC
{
    public abstract class ScriptControlBase : Control, INamingContainer
    {
        /// <summary>
        /// 当前控件在页面中出现的顺序
        /// </summary>
        protected int Index = 0;

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            int count = 0;
            string key = this.GetType().Name + "_COUNT";

            if (Context.Items.Contains(key))
            {
                count = (int)Context.Items[key];
            }
            Index = count;
            Context.Items[key] = ++count; //记录当前页面请求中创建的检索控件个数
        }

        public abstract string GetScript();

        protected override void Render(HtmlTextWriter writer)
        {
            if (Context != null)
            {
                writer.Write(this.GetScript());
            }
            else
            {
                writer.Write("IBOX:" + this.GetType().Name);
            }
        }

        private string _encoding = "utf-8";
        /// <summary>
        /// 获取或设置脚本输出编码
        /// </summary>
        [Description("设置脚本输出编码")]
        public virtual string Encoding
        {
            get { return _encoding; }
            set { _encoding = value; }
        }

    }
}
