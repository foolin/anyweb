using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI;
using System.Collections;

namespace AnyWell.AW_UC
{
    public abstract class ControlBase : CompositeDataBoundControl
    {
        private ITemplate _itemTemplate;
        /// <summary>
        /// 内容模板，可包含任意html内容和嵌套对象
        /// </summary>
        [Browsable(false)]
        [TemplateContainer(typeof(TemplateItem))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate ItemTemplate
        {
            get { return _itemTemplate; }
            set { _itemTemplate = value; }
        }

        /// <summary>
        /// 获取要显示的数据对象
        /// </summary>
        /// <returns></returns>
        protected abstract object GetDataObject();

        /// <summary>
        /// 绑定模版项
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="dataBinding"></param>
        /// <returns></returns>
        protected override int CreateChildControls(IEnumerable dataSource, bool dataBinding)
        {
            int index = 0;
            if (dataBinding && dataSource != null && _itemTemplate != null)
            {
                foreach (object dataItem in dataSource)
                {
                    TemplateItem ti = new TemplateItem(dataItem, index);
                    _itemTemplate.InstantiateIn(ti);
                    Controls.Add(ti);
                    index++;
                    ti.DataBind();
                }
            }
            return index;
        }

        /// <summary>
        /// 呈现内容
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            if (this.DataSource == null)
            {
                object data = this.GetDataObject();
                if (data != null)
                {
                    if (data is string || this.ItemTemplate == null)
                    {
                        Controls.Add(new LiteralControl(data.ToString()));//当数据不是一个集合类型时直接返回字符串结果
                    }
                    else
                    {
                        if (data is IEnumerable == false)
                        {
                            this.DataSource = new object[] { data };
                        }
                        else
                        {
                            this.DataSource = data;
                        }
                        this.DataBind();
                    }
                }
            }
            base.OnPreRender(e);
        }

        /// <summary>
        /// 从URL读取参数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected string QS(string name)
        {
            return HttpContext.Current.Request.QueryString[name] + "";
        }

        /// <summary>
        /// 从上下文中读取参数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected string ContextItem(string name)
        {
            return HttpContext.Current.Items[name] + "";
        }

        /// <summary>
        /// 跳转到错误页面
        /// </summary>
        protected void goErrorPage()
        {
            HttpContext.Current.Response.Redirect("/Error.aspx");
        }
    }
}
