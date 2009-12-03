using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel;

namespace Studio.Web
{
	/// <summary>
	/// Name:�ؼ�����
	/// Description:�Զ���ؼ�����
	/// Author:л��
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
		//�Ƿ�����༭
		public bool AllowEdit
		{
			get{return _allowEdit;}
			set{_allowEdit = value;}
		}

		string _skinPath;
		//Ƥ��·��
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

		//���ؿؼ�����
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
			//TODO:���ؿؼ�ǰ�Ĳ���
		}

		protected virtual void AfterLoadSkin()
		{
			WebAgent.CreateViewScript( Page, this.AllowEdit); //ע��ű�
		}

		/// <summary>
		/// ��ʼ���ؼ�
		/// </summary>
		/// <param name="skin">�ؼ�Ƥ��,ͨ����һ��ascx</param>
		protected abstract void InitializeSkin(Control skin);
	}

	public delegate void SkinEventHandler(object sender, Control skin);
}