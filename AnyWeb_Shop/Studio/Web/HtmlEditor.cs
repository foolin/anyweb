using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;



namespace Studio.Web
{
	/// <summary>
	/// ����һ��HTML�༭���Ĵ���(��ʾһ��iframe)
	/// </summary>
	[
	DefaultProperty("propControlID"),
	ToolboxData("<{0}:HtmlEditor runat=server></{0}:HtmlEditor>")
	]
	public class HtmlEditor : System.Web.UI.WebControls.WebControl
	{

		#region properties
		private string _propPath;

		[
		Bindable(true),
		Category("MyProperties"),
		DefaultValue("")
		]
		public string propPath
		{
			get
			{
				return this._propPath;
			}

			set
			{
				this._propPath = value;
			}
		}



		private string _propControlID;

		[
		Bindable(true),
		Category("MyProperties"),
		DefaultValue("")
		]
		public string propControlID
		{
			get
			{
				return this._propControlID;
			}

			set
			{
				this._propControlID = value;
			}
		}



		private string _propAutoSave = "autoSave=1&";

		[
		Bindable(true),
		Category("MyProperties"),
		DefaultValue("True")
		]
		public bool propAutoSave
		{
			get
			{
				return this._propAutoSave != "";
			}

			set
			{
				this._propAutoSave = value ? "autoSave=1&" : "";
			}
		}
		#endregion



		#region body
		/// <summary>
		/// ���˿ؼ����ָ�ָ�������������
		/// </summary>
		/// <param name="output"> Ҫд������ HTML ��д�� </param>
		protected override void Render(HtmlTextWriter output)
		{
			output.WriteLine("<!--HtmlEditor {-->");

			output.WriteLine(string.Format
				(
				"<iframe src='{0}innerEditor.htm?{4}width={2}&height={3}&id={1}' width='{2}' height='{3}' frameborder='0' id='frmEditor_{5}'></iframe>",
				this._propPath,
				this._propControlID,
				this.Width,
				this.Height,
				this._propAutoSave,
				this.ClientID
				));

			output.WriteLine("<!--HtmlEditor }-->");
		}
		#endregion



	}//
}//
