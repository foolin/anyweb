using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Studio.Web
{
	/// <summary>
	/// Name:评论组件
	/// Description:实现一个简单的评论功能,可以自定义皮肤/导航设置等
	/// Author:谢康
	/// CreateDate:2005-07-11
	/// </summary>	
	public class CommentList : SkinedControl
	{
		protected TextBox txtName;
		protected TextBox txtComment;
		protected LinkButton lnkCommit;
		protected Label lblMsg;
		protected Repeater rep1;
		protected Repeater repFace;
		protected PageNaver PN1;
		public event CommentEventHandler Submit;
		public event CommentDeleteEventHandler Delete;

		public CommentList()
		{
		}

		string _commentID;
		//评论编号
		public string CommentID
		{
			get{return _commentID;}
			set{_commentID = value;}
		}

		string _dataPath = "comments";
		//评论数据路径
		public string DataPath
		{
			get{return _dataPath;}
			set{_dataPath = value;}
		}

		string _faceConfig = "/config/face.config";
		//表情配置文件
		public string FaceConfig
		{
			get{return _faceConfig;}
			set{_faceConfig = value;}
		}

		string _facePicPath = "/images/faces";
		//表情图片路径
		public string FacePicPath
		{
			get{return _facePicPath;}
			set{_facePicPath = value;}
		}

		//表情组编号
		string _faceGroupID = "1";
		public string FaceGroupID
		{
			get{return _faceGroupID;}
			set{_faceGroupID = value;}
		}

		int _listCount = 20;
		//显示条数
		public int ListCount
		{
			get{return _listCount;}
			set{_listCount = value;}
		}

		int _maxLength = 1000;
		//显示条数
		public int MaxLength
		{
			get{return _maxLength;}
			set{_maxLength = value;}
		}

		bool _navigate = true;
		//是否显示导航
		public bool Navigator
		{
			get{return _navigate;}
			set{_navigate = value;}
		}

		bool _readOnly = false;
		//是否只读评论
		public bool ReadOnly
		{
			get{return _readOnly;}
			set{_readOnly = value;}
		}

		//初始化
		protected override void InitializeSkin(Control skin)
		{
			txtName = (TextBox)skin.FindControl("txtName");
			txtComment = (TextBox)skin.FindControl("txtComment");
			lnkCommit = (LinkButton)skin.FindControl("lnkCommit");
			lblMsg = (Label)skin.FindControl("lblMsg");
			rep1 = (Repeater)skin.FindControl("rep1");
			repFace = (Repeater)skin.FindControl("repFace");

			PlaceHolder ph = (PlaceHolder)skin.FindControl("phPageNaver");
			if( ph != null)
			{
				PN1 = new PageNaver();
				PN1.PageSize = this.ListCount;
			
				ph.Controls.Add(PN1);
			}

			if( lnkCommit != null)
			{
				if( this.ReadOnly)
					lnkCommit.Visible = txtName.Visible = txtComment.Visible = repFace.Visible = false;
				else
					lnkCommit.Click += new EventHandler(lnkCommit_Click);
			}
		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if( rep1 != null)
			{
				//检查删除评论
				this.CheckDelete();

				using( CommentAgent agent = new CommentAgent(this.DataPath))
				{
					rep1.DataSource = PN1.GetCurrentPage(agent.GetComments( this.CommentID));
				}
				rep1.DataBind();

				lblMsg.Visible = rep1.DataSource == null;
			
				Literal litID = new Literal();
				litID.Text = "<input type='hidden' name='CommentID' value='" + this.CommentID + "'>";
				Controls.Add( litID );

				if( repFace != null)
				{
					repFace.DataSource = Faces.GetGroup( this.FaceGroupID, this.FaceConfig).Items;
					repFace.DataBind();
				}

				if(PN1.Visible == true)
					PN1.Visible = this.Navigator;

			}
		}

		void CheckDelete()
		{
			string cmd = Page.Request.Form["EventName"];		//事件名称
			string args = Page.Request.Form["EventArgs"];			//事件参数

			if( args != "")
			{					
				switch (cmd)
				{
					case "delete":
					{
						string[] ss = args.Split('|');
						if( ss.Length == 2)
						{
							using( CommentAgent agent = new CommentAgent(this.DataPath))
							{
								agent.DeleteComment( this.CommentID, DateTime.Parse(ss[0]), ss[1]);
							}
							//触发删除评论事件
							if( this.Delete != null)this.Delete(this, new CommentDeleteEventArgs(DateTime.Parse(ss[0]), ss[1]));
						}
						break;
					}
				}
			}
		}

		private void lnkCommit_Click(object sender, EventArgs e)
		{
			if( CheckInput( txtName, txtComment))
			{
				UComment newComment = new UComment();
				newComment.CreateTime = DateTime.Now;
				newComment.IP = Context.Request.UserHostAddress;
				newComment.Author = txtName.Text;
				string content = Context.Server.HtmlEncode(txtComment.Text);				
				if( content.Length > _maxLength)
				{
					content = content.Substring( 0 ,_maxLength);
				}

				newComment.Content = content;
				//替换表情符号
				if( repFace != null)
				{
					newComment.SetContent(ReplaceFace( newComment.Content));
				}

				using( CommentAgent agent = new CommentAgent(this.DataPath))
				{
					agent.AddComment( newComment, Context.Request.Form["CommentID"]);
				}

				//触发评论事件
				if( this.Submit != null)this.Submit(this, new CommentEventArgs(newComment));

				txtName.Text = txtComment.Text = String.Empty;

				WebAgent.SuccAndGo("评论成功!", Request.RawUrl);
			}
		}

		bool CheckInput(params TextBox[] ctls)
		{
			return true;
		}

		string ReplaceFace(string content)
		{
			string facePicPath = this.FacePicPath;
			IEnumerator dic = Faces.GetGroup(this.FaceGroupID, this.FaceConfig).Items.GetEnumerator();
			while( dic.MoveNext())
			{
				content = content.Replace( ((Faces.Face)dic.Current).Word, "<img border=0 src='" + facePicPath + ((Faces.Face)dic.Current).Picture + "'>");
			}
			return content;
		}
	}

	/// <summary>
	/// 评论对象
	/// </summary>
	public class UComment
	{
		public UComment()
		{

		}

		public UComment(string text) //2005-02-02 19:03:32|64.145.125.558|xiekang|hello!
		{
			string[] ss = text.Split('|');
			_createTime = DateTime.Parse(ss[0]);
			_ip = ss[1];//.Substring(0, ss[1].LastIndexOf('.') + 1) + "*";
			_author = ss[2].Replace('`', '|');
			_text = ss[3].Replace('`', '|');
		}

		string Encode( string text)
		{
			return text.Replace("\r\n", "<br>").Replace(" ", "&nbsp;");
		}

		string _text;
		/// <summary>
		/// 内容
		/// </summary>
		public string Content
		{
			get{return _text;}
			set{_text = Encode(value);}
		}

		public void SetContent( string content)
		{
			_text = content;
		}

		string _author;
		/// <summary>
		/// 作者
		/// </summary>
		public string Author
		{
			get{return _author;}
			set{_author = value;}
		}

		DateTime _createTime;
		public DateTime CreateTime
		{
			get{return _createTime;}
			set{_createTime = value;}
		}

		string _ip;
		public string IP
		{
			get{return _ip;}
			set{_ip = value;}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append( _createTime.ToString("yyyy-MM-dd HH:mm:ss"))
				.Append('|')
				.Append(_ip)
				.Append('|')
				.Append(_author.Replace('|','`'))
				.Append('|')
				.Append(_text.Replace('|','`'));

			return sb.ToString();
		}

	}

	public delegate void CommentEventHandler(object sender, CommentEventArgs e);

	public class CommentEventArgs: EventArgs
	{
		public CommentEventArgs(){}

		public CommentEventArgs(UComment comment)
		{
			_comment = comment;
		}

		UComment _comment;
		public UComment Comment
		{
			get{return _comment;}
			set{_comment = value;}
		}
	}

	public delegate void CommentDeleteEventHandler(object sender, CommentDeleteEventArgs e);

	public class CommentDeleteEventArgs: EventArgs
	{
		public CommentDeleteEventArgs(){}

		public CommentDeleteEventArgs(DateTime createAt, string ip)
		{
			_createAt = createAt;
			_ip = ip;
		}

		DateTime _createAt;
		public DateTime CreateAt
		{
			get{return _createAt;}
			set{_createAt = value;}
		}

		string _ip;
		public string IP
		{
			get
			{
				return _ip;
			}
			set{_ip = value;}
		}
	}
	/// <summary>
	/// 数据代理
	/// </summary>
	public class CommentAgent : IDisposable
	{
		string _path = "comments";
		public CommentAgent(string path)
		{
			_path = path;
		}
		//***************************************
		// 获取评论信息
		//***************************************
		public ArrayList GetComments( string commentID)
		{
			string commentPath = HttpContext.Current.Server.MapPath( _path + "/" + commentID + ".txt");
			ArrayList deletedList = GetDeletedList( commentID, commentPath.Replace("\\" + commentID, "\\Deleted"));

			if( !File.Exists(commentPath))
			{
				return null;
			}
			else
			{
				ArrayList list = new ArrayList();
				string data = "";
				UComment comment = null;

				using( StreamReader sr = new StreamReader(commentPath, System.Text.Encoding.Default))
				{
					data = sr.ReadLine();
					while( data != null && data.Equals(String.Empty) == false)
					{
						comment = new UComment(data);
						if( !deletedList.Contains(comment.CreateTime.ToString("yyyy-MM-dd HH:mm:ss") + comment.IP))
						{
							list.Add( comment );
						}
						data = sr.ReadLine();
					}
				}
				list.Reverse();
				return list;
			}
		}

		ArrayList GetDeletedList( string commentID, string filePath)
		{
			if( !File.Exists(filePath))
			{
				return new ArrayList();
			}
			else
			{
				ArrayList deletedList = new ArrayList();
				string data; int splitAt;

				using(StreamReader sr = new StreamReader(filePath, System.Text.Encoding.ASCII))
				{
					data = sr.ReadLine();
					while( data != null && data.Equals(String.Empty) == false)	//
					{
						splitAt = data.IndexOf('|');
						if( splitAt > 0)
						{
							if( data.Substring(0, splitAt) == commentID)
							{
								deletedList.Add( data.Substring( splitAt+1));
							}
						}
						data = sr.ReadLine();
					}
				}
				return deletedList;
			}
		}

		public void DeleteComment( string commentID, DateTime createTime, string ip)
		{
			string deletedPath = HttpContext.Current.Server.MapPath( _path + "/Deleted.txt");

			using(StreamWriter sw = new StreamWriter(deletedPath, true, System.Text.Encoding.Default))
			{
				sw.WriteLine( commentID + '|' + createTime.ToString("yyyy-MM-dd HH:mm:ss") + ip);
			}
		}

		public void AddComment( UComment comment, string commentID)
		{
			string commentFolder = HttpContext.Current.Server.MapPath( _path);
			string commentPath = commentFolder + "\\" + commentID + ".txt";
			if( !Directory.Exists( commentFolder ))
			{
				Directory.CreateDirectory( commentFolder);
			}

			using(StreamWriter sw = new StreamWriter(commentPath, true, System.Text.Encoding.Default))
			{
				sw.WriteLine( comment.ToString());
			}
		}

		public void DeleteComment( string commentID)
		{
			string commentPath = HttpContext.Current.Server.MapPath( _path + "/" + commentID + ".txt");
			if( File.Exists( commentPath))
				File.Delete(commentPath);	
		}
		#region IDisposable 成员

		public void Dispose()
		{
			// TODO:  添加 Agent.Dispose 实现
		}

		#endregion
	}
}
