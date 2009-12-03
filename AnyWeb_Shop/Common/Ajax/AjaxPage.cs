using System;
using System.Web;
using System.Web.UI;


namespace Common.Ajax
{
    /// <summary>
    /// AjaxPage 页面基类，控制页面结果输出
    /// </summary>
    public class AjaxPage : Page
    {
        string _errorCode;
        string _message;

        protected virtual void ExecSucc(string message)
        {
            _errorCode = "0";
            _message = message;
        }

        protected virtual void ExecFail(string errCode, string errMessage)
        {
            _errorCode = errCode;
            _message = errMessage;
        }

        protected override void OnPreRender(EventArgs e)
        {
            Response.Clear();
            Response.Write("result:");
            Response.Write(_errorCode);
            Response.Write('|');
            Response.Write(_message);
            Response.End();
        }

        protected string QS(string key)
        {
            return Request.QueryString[key] + "";
        }
    }
}
