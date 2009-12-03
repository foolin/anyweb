using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel;

namespace Studio.Web
{
	/// <summary>
	/// Name:控件基类
	/// Description:自定义控件基类
	/// Author:谢康
	/// CreateDate:2005-07-23
	/// </summary>
	[ParseChildren(true),Designer(typeof(SkinedControlDesigner))]
	public abstract class SkinedControl : WebControl, INamingContainer
	{
		public event SkinEventHandler SkinLoad;

		public SkinedControl()
		{
		}

		protected HttpRequest Request
		{
			get{return Context.Request;}
		}

		protected HttpResponse Response
		{
			get{return Context.Response;}
		}

		bool _allowEdit;
		//是否允许编辑
		public bool AllowEdit
		{
			get{return _allowEdit;}
			set{_allowEdit = value;}
		}

		string _skinPath;
		//皮肤路径
		public string SkinPath
		{
			get{return _skinPath;}
			set{_skinPath = value;}
		}

		override public ControlCollection Controls 
		{
			get 
			{
				EnsureChildControls();
				return base.Controls;
			}
		}

		//加载控件内容
		protected override void CreateChildControls() 
		{
			Control skin;

			BeforeLoadSkin();//do something before load skin

			// Load the skin
			skin = LoadSkin();

			Controls.Add(skin);

			// Initialize the skin
			InitializeSkin(skin);

			if(SkinLoad != null)
			{
				SkinLoad(this, skin);
			}

			AfterLoadSkin();//do something after load skin
		}

		protected Control LoadSkin()
		{
			return Page.LoadControl(this.SkinPath);
		}


		protected virtual void BeforeLoadSkin()
		{
			//TODO:加载控件前的操作
		}

		protected virtual void AfterLoadSkin()
		{
			WebAgent.CreateViewScript( Page, this.AllowEdit); //注册脚本
		}

		/// <summary>
		/// 初始化控件
		/// </summary>
		/// <param name="skin">控件皮肤,通常是一个ascx</param>
		protected abstract void InitializeSkin(Control skin);
	}

	public delegate void SkinEventHandler(object sender, Control skin);
}