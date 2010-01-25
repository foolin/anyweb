using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.ComponentModel;

namespace Studio.Web
{
    /// <summary>
	/// Name:验证控件
	/// Description:实现客户端验证功能，暂不支持服务器端验证
	/// Author:谢康
	/// CreateDate:2009-02-24
	/// </summary>	
    public class Validator : Control, INamingContainer 
	{
        public static string ScriptSrc = "/Public/js/validator1.2.js";
        int _index = 0;
        string _ciKey = "FA_VALIDATORS";
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            
            lock (Context)
            {
                ArrayList validators = (ArrayList)Context.Items[_ciKey];
                if (validators == null)
                {
                    validators = new ArrayList();
                    Context.Items.Add(_ciKey, validators);
                }
                validators.Add(this);
                _index = validators.Count;                
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (Context == null)
            {
                writer.Write("<font color=\"red\">Validator(" + this.Name + ")</font>");
            }
            else
            {
                writer.Write(string.Format("<span id=\"{0}\"></span>", this.ClientID));
                ArrayList validators = (ArrayList)Context.Items[_ciKey];
                if (_index == validators.Count)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("<script type=\"text/javascript\" id=\"script_v1\" src=\"{0}\"></script>", ScriptSrc);
                    sb.Append("<script type=\"text/javascript\">");
                    sb.Append("var v1 = new Validator();");
                    foreach (Validator v in validators)
                    {
                        Control target = Page.FindControl(v.ControlID);
                        if (target == null && Page.Master.FindControl("cph1") != null)
                        {
                            target = Page.Master.FindControl("cph1").FindControl(v.ControlID);
                        }
                        if (target == null && Page.Master.FindControl("cphContent") != null)
                        {
                            target = Page.Master.FindControl("cphContent").FindControl(v.ControlID);
                        }
                        sb.AppendFormat("c1 = new v1.Control(\"{0}\", \"{1}\", \"{2}\");", v.ClientID, v.Name, target != null ? target.ClientID : v.ControlID);
                        if (v.ErrorMessage != "格式错误")
                            sb.AppendFormat("c1.errmsg = \"{0}\";", v.ErrorMessage);
                        if (v.ErrorText != "*")
                            sb.AppendFormat("c1.errtext = \"{0}\";", v.ErrorText);
                        if (v.ErrorCss != "invalid")
                            sb.AppendFormat("c1.errcss = \"{0}\";", v.ErrorCss);
                        if (v.OkText != "")
                            sb.AppendFormat("c1.oktext = \"{0}\";", v.OkText);
                        if (v.OkCss != "valid")
                            sb.AppendFormat("c1.okcss = \"{0}\";", v.OkCss);
                        if (v.MinValue != 0)
                            sb.AppendFormat("c1.min = {0};", v.MinValue);
                        if (v.MaxValue != 99999999)
                            sb.AppendFormat("c1.max = {0};", v.MaxValue);
                        if (v.MaxLength != 99999999)
                            sb.AppendFormat("c1.maxlen = {0};", v.MaxLength);
                        if (v.MinLength > 0)
                            sb.AppendFormat("c1.minlen = {0};", v.MinLength);
                        if (v.DataType != ValidateDataType.None)
                            sb.AppendFormat("c1.datatype = \"{0}\";", v.DataType.ToString().ToLower());
                        if (v.DateFormat != "ymd")
                            sb.AppendFormat("c1.format = \"{0}\";", v.DateFormat);
                        if (v.Expression != "")
                            sb.AppendFormat("c1.expression = \"{0}\";", v.Expression);

                        sb.AppendFormat("c1.checktype = {0};", (int)v.ValidateType);
                        if (v.CheckBlur != true)
                            sb.AppendFormat("c1.checkblur = {0};", v.CheckBlur ? "true" : "false");

                        sb.Append("v1.Add(c1);");
                    }
                    sb.Append("v1.Init();");
                    sb.Append("</script>");
                    Page.ClientScript.RegisterStartupScript(typeof(string), "ValidatorScript", sb.ToString());
                }
            }
        }

        string _name;
        [Description("验证控件名称")]
        public string Name
        {
            get {
                if (_name == null)
                    _name = this.ClientID;
                return _name; 
            }
            set { _name = value; }
        }

        string _controlID;
        [Description("被验证控件的编号")]
        public string ControlID
        {
            get { return _controlID; }
            set { _controlID = value; }
        }

        string _errMsg = "格式错误";
        [Description("错误提示(汇总提示)"), DefaultValue("格式错误")]
        public string ErrorMessage
        {
            get { return _errMsg; }
            set { _errMsg = value; }
        }

        string _errText = "*";
        [Description("错误提示(即时提示)"), DefaultValue("*")]
        public string ErrorText
        {
            get { return _errText; }
            set { _errText = value; }
        }

        string _errCss = "invalid";
        [Description("错误提示显示样式"), DefaultValue("invalid")]
        public string ErrorCss
        {
            get { return _errCss; }
            set { _errCss = value; }
        }

        string _okText = "";
        [Description("正确提示(即时提示)")]
        public string OkText
        {
            get { return _okText; }
            set { _okText = value; }
        }

        string _okCss = "valid";
        [Description("正确提示显示样式"), DefaultValue("valid")]
        public string OkCss
        {
            get { return _okCss; }
            set { _okCss = value; }
        }

        int _min = 0;
        [Description("最小值"), DefaultValue("0")]
        public int MinValue
        {
            get { return _min; }
            set { _min = value; }
        }

        int _max = 99999999;
        [Description("最大值"), DefaultValue("99999999")]
        public int MaxValue
        {
            get { return _max; }
            set { _max = value; }
        }

        int _maxLen = 99999999;
        [Description("最大长度"), DefaultValue("99999999")]
        public int MaxLength
        {
            get { return _maxLen; }
            set { _maxLen = value; }
        }

        int _minLen = 0;
        [Description("最小长度"), DefaultValue("0")]
        public int MinLength
        {
            get { return _minLen; }
            set { _minLen = value; }
        }

        string _dateFormat = "ymd";
        [Description("日期格式"), DefaultValue("ymd")]
        public string DateFormat
        {
            get { return _dateFormat; }
            set { _dateFormat = value; }
        }

        string _expression = "";
        [Description("表达式(正则表达式或自定义函数)")]
        public string Expression
        {
            get { return _expression; }
            set { _expression = value; }
        }

        ValidateDataType _datatype = ValidateDataType.None;
        [Description("验证数据类型")]
        public ValidateDataType DataType
        {
            get { return _datatype; }
            set { _datatype = value; }
        }

        ValidateType _validateType = ValidateType.Required;
        [Description("验证方法类型"), DefaultValue(ValidateType.Required)]
        public ValidateType ValidateType
        {
            get { return _validateType; }
            set { _validateType = value; }
        }

        bool _checkBlur = true;
        [Description("是否在控件失去焦点时验证"), DefaultValue(true)]
        public bool CheckBlur
        {
            get { return _checkBlur; }
            set { _checkBlur = value; }
        }
    }

    public enum ValidateDataType
    {
        None, Account, Email, Phone, Mobile, Url, IDCard, Currency, Number, Date, Zip, QQ, Integer, Double, English, Chinese
    }

    public enum ValidateType : int
    {
        Required = 1, 
        MaxLength = 2,
        DataType = 3,
        Range = 4,
        Regular = 5,
        Custom = 6,
        MinLength = 7
    }
}
