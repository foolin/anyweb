using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml;

namespace Studio.Web
{

	/// <summary>
	/// 文章中的图标
	/// </summary>
	[DefaultProperty("Text"),
	ToolboxData("<{0}:ArticleICON runat=server width=100px height=100px></{0}:ArticleICON>")]
	public class ArticleICON : System.Web.UI.WebControls.WebControl
	{
		public enum IconReturnType
		{
			ReturnTag = 0, ReturnIconName = 1, ReturnFileName = 2, ReturnFilePath = 3, ReImgHtml = 4
		}

		private IconReturnType _returntype;
		private string _configfile = "";
		private int _rowsize = 5;
		private int _cellspacing = 0;
		private int _cellpadding = 0;
		private string _iconpath = "";
		private string _receiver = "";
		private string _command = "";
		private string tempstring = "图标区域";
		private Table table1 = new Table();

		[Bindable(true),
		Category("Data"),
		Description("图标的配置xml文件"),
		DefaultValue("")]
		public string IconConfigFile
		{
			get
			{
				return _configfile;
			}

			set
			{
				if (value != null) _configfile = value;
			}
		}

		[Bindable(true),
		Description("图标的返回类型：ReturnTag(返回标记);ReturnIconName(返回说明);ReturnFileName(返回文件名);ReturnFilePath(返回文件路径)"),
		Category("Data"),]
		public IconReturnType ReturnType
		{
			get
			{
				return _returntype;
			}
			set
			{
				_returntype = value;
			}
		}

		[Bindable(true),
		Category("Data"),
		Description("图标的存放路径"),
		DefaultValue("")]
		public string IconPath
		{
			get { return _iconpath; }
			set { if (value != null)_iconpath = value; }
		}

		[Bindable(true),
		Category("Data"),
		Description("图标的接收对象"),
		DefaultValue("")]
		public string IconReceiver
		{
			get { return _receiver; }
			set { if (value != null)_receiver = value; }
		}

		[Bindable(true),
		Category("Data"),
		Description("选择图标时执行的函数"),
		DefaultValue("")]
		public string CommandName
		{
			get { return _command; }
			set { if (value != null)_command = value; }
		}

		[Bindable(true),
		Category("Appearance"),
		Description("每行显示图标个数"),
		DefaultValue("0")]
		public int RowSize
		{
			get { return _rowsize; }
			set { _rowsize = value; }
		}

		[Bindable(true),
		Category("Appearance"),
		Description("图标的间隙"),
		DefaultValue("0")]
		public int CellSpacing
		{
			get { return _cellspacing; }
			set { _cellspacing = value; }
		}

		[Bindable(true),
		Category("Appearance"),
		Description("填充间隔"),
		DefaultValue("0")]
		public int CellPadding
		{
			get { return _cellpadding; }
			set { _cellpadding = value; }
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			this.Load += new EventHandler(FAIcon_Load);
		}

		/// <summary>
		/// 将此控件呈现给指定的输出参数。
		/// </summary>
		/// <param name="output"> 要写出到的 HTML 编写器 </param>
		protected override void Render(HtmlTextWriter output)
		{
			InitControls();
			this.RenderChildren(output);
		}

		private void InitControls()
		{
			this.Controls.Clear();
			table1 = new Table();
			table1.BackColor = this.BackColor;
			table1.BorderStyle = this.BorderStyle;
			table1.BorderWidth = this.BorderWidth;
			table1.BorderColor = this.BorderColor;
			table1.CellPadding = table1.CellSpacing = 0;
			table1.Width = this.Width;
			table1.Height = this.Height;
			table1.Rows.Add(new TableRow());
			table1.Rows[0].Cells.Add(new TableCell());
			table1.Rows[0].Cells[0].Width = Unit.Parse("100%");
			table1.Rows[0].Cells[0].Height = Unit.Parse("100%");
			table1.Rows[0].Cells[0].Text = tempstring;
			this.Controls.Add(table1);
		}

		private void FAIcon_Load(object sender, EventArgs e)
		{
			this.GetData();
			StringBuilder sb = new StringBuilder("<script language=javascript>var over='blue',out='#d6d3ce',icon=0;\n");
			sb.Append("function ChooseIcon(type){\n");
			sb.Append("var img1=event.srcElement;\n");
			sb.Append("var data;\n");
			sb.Append("	switch(type)\n");
			sb.Append("	{" + "\n");
			sb.Append("		case 0:{data=img1.ICONTAG;break;}\n");
			sb.Append("		case 1:{data=img1.art;break;}\n");
			sb.Append("		case 2:{data=img1.ICONFILE;break;}\n");
			sb.Append("		case 3:{data=img1.src;break;}\n");
			sb.Append("		case 4:{data='<img border=0 align=absmiddle src='+img1.src+'>';break;}\n");
			sb.Append("	}" + "\n");
			if (this.IconReceiver != "")
			{
				sb.Append("try{" + this.IconReceiver + "=data;}catch(e){}\n");
			}
			if (this.CommandName != "")
			{
				sb.Append("try{" + this.CommandName + "(data);}catch(e){}\n");
			}
			sb.Append("}" + "\n");
			sb.Append("function SwitchIcon(type){\n");
			sb.Append("icon=icon==1?2:1;\n");
			sb.Append("var tbl;if(icon==1){tbl=tblICON;tbl.style.display='block';tblICONS.style.display='none';}\n");
			sb.Append("else{tbl=tblICONS;tbl.style.display='block';tblICON.style.display='none';}\n");
			sb.Append("for(i=0;i<tbl.rows.length;i++){\n");
			sb.Append("   for(j=0;j<tbl.rows[i].cells.length;j++){\n");
			sb.Append("		var td=tbl.rows[i].cells[j];\n");
			sb.AppendFormat("		 if(td.ICONNAME!=null)td.innerHTML='<img border=1 style=\"cursor:hand;border-color:#d6d3ce\" onmouseover=\"this.style.borderColor=over\" onmouseout=\"this.style.borderColor=out\" ICONTAG=\"\\a\" alt=\"' + td.ICONNAME + '\" src=\"/images/icons/' + td.ICONFILE + '\" ICONFILE=\"' + td.ICONFILE + '\" onclick=\"ChooseIcon({0})\">';\n", ((int)ReturnType).ToString());
			sb.Append("		}\n");
			sb.Append("	}\n");
			sb.Append("}\n");

			sb.Append("SwitchIcon(1);</script>" + "\n");

			tempstring += sb.ToString();
		}

		void GetData()
		{
			if (this.IconConfigFile.IndexOf(":") < 0) this.IconConfigFile = System.Web.HttpContext.Current.Server.MapPath(this.IconConfigFile);
			if (!File.Exists(this.IconConfigFile)) return;
			StringBuilder sb = new StringBuilder();
			tempstring = "";
			try
			{
				IconConfig icons = (IconConfig)Context.Cache["ANYPICONCONFIG"];
				if (icons == null)
				{
					icons = new IconConfig();
					icons.ReadXml(this.IconConfigFile);
					Context.Cache.Insert("ANYPICONCONFIG", icons, null, DateTime.Now.AddHours(2), TimeSpan.Zero);
				}

				if (icons.Icon.Count == 0)
				{
					icons.Dispose(); return;
				}

				//最先显示的图标
				sb.Append("<table id='tblICON' style='display:none' align=left>\n");
				sb.Append( "	<tr>" + "\n");
				for (int i = 0; i < 10 && i < icons.Icon.Count; i++)
				{
					sb.AppendFormat( "<td class='icon' ICONFILE='{0}' ICONNAME='{1}'></td>", icons.Icon[i].File, icons.Icon[i].Name);
				}
				sb.Append( "<td>&nbsp;&nbsp;<a href=\"javascript:SwitchIcon(2);\" style='color:blue;'>更多图标</a></td></tr></table>		\n");

				//更多图标
				sb.AppendFormat( "<table id='tblICONS' style='display:none' width=100% cellspacing='{0}' cellpadding='{1}'>\n", this.CellSpacing.ToString(), this.CellPadding.ToString());
				sb.Append( "	<tr>\n");
				for (int i = 0; i < icons.Icon.Count; i++)
				{
					if (i > 0 && i % this.RowSize == 0)
					{
						sb.Append( "	</tr><tr>\n");
					}
					sb.AppendFormat( "<td class='icon' ICONFILE='{0}' ICONNAME='{1}'></td>", icons.Icon[i].File, icons.Icon[i].Name);
				}
				sb.Append( "	</tr>\n");
				sb.Append( "</table>\n");

				tempstring = sb.ToString();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
