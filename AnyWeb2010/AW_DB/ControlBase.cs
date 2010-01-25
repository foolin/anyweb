using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace FortuneAge.IBOX_UC
{
    /// <summary>
    /// 用户控件基类，ItemTemplate模板用于定制输出布局和样式，类似Repeater
    /// </summary>
    public abstract class ControlBase : CompositeDataBoundControl
    {
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

        protected override void OnPreRender(EventArgs e)
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
            base.OnPreRender(e);
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            if (string.IsNullOrEmpty(this.Remark) == false) //显示描述
            {
                writer.Write(string.Format("<!--{0} Begin-->", this.Remark));
            }
            //显示自定义的开始标记
            writer.Write(this.BeginTag);
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
            //显示自定义的结束标记
            writer.Write(this.EndTag);
            if (string.IsNullOrEmpty(this.Remark) == false) //显示描述
            {
                writer.Write(string.Format("<!--{0} End-->", this.Remark));
            }
        }

        /// <summary>
        /// 获取要显示的数据对象
        /// </summary>
        /// <returns></returns>
        protected abstract object GetDataObject();

        
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

        private string _beginTag;
        /// <summary>
        /// 自定义开始标记
        /// </summary>
        public virtual string BeginTag
        {
            get { return _beginTag; }
            set { _beginTag = value; }
        }

        private string _endTag;
        /// <summary>
        /// 自定义结束标记
        /// </summary>
        public virtual string EndTag
        {
            get { return _endTag; }
            set { _endTag = value; }
        }

        private string _remark;
        /// <summary>
        /// 描述信息
        /// </summary>
        public virtual string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
    }
}
