using System;
using System.Data;
using System.Web;
using System.Collections;
using System.IO;
using System.Text;

namespace Studio.Web
{
	/// <summary>
	/// 表情集合
	/// </summary>
	public class Faces
	{
		Hashtable _groups = null;
	
		public Faces()
		{
			//Refresh();
		}

		public Hashtable Groups
		{
			get
			{
				if( _groups == null)
					this.Refresh();

				return _groups;
			}
		}

		public void Refresh()
		{
			_groups = new Hashtable();
			string file = HttpContext.Current.Server.MapPath(this.Config);
			DataSet dsFace = new DataSet();
			dsFace.ReadXml(file);
			foreach( DataRow gRow in dsFace.Tables["group"].Rows)
			{
				DataRow[] items = gRow.GetChildRows(dsFace.Relations[0]);
				FaceGroup group = new FaceGroup( gRow["id"].ToString(), gRow["name"].ToString());
				foreach( DataRow iRow in items)
				{
					group.Add( iRow["word"].ToString(), iRow["pic"].ToString());
				}
				_groups.Add(group.ID, group);
			}
		}

		string _config = "";
		public string Config
		{
			get{return _config;}
			set{_config = value;}
		}

		public static FaceGroup GetGroup( string id)
		{
			return (FaceGroup)Nested.instance.Groups[id];
		}

		public static FaceGroup GetGroup( string id, string config)
		{
			if( Nested.instance.Config == "")
				Nested.instance.Config = config;

			return (FaceGroup)Nested.instance.Groups[id];
		}

		public static Faces GetInstance()
		{
			return Nested.instance;
		}

		public class FaceGroup
		{
			ArrayList _faces = new ArrayList();

			public FaceGroup( string id, string name)
			{
				_id = id;
				_name = name;
			}
			
			public void Add( string word, string pic)
			{
				_faces.Add( new Face( word, pic));
			}

			string _id;
			public string ID
			{
				get{return _id;}
				set{_id = value;}
			}

			string _name;
			public string Name
			{
				get{return _name;}
				set{_name = value;}
			}

			public ArrayList Items
			{
				get{return _faces;}
			}
		}

		public class Face
		{
			public Face( string word, string pic)
			{
				_word = word;
				_pic = pic;
			}
			
			string _word;
			public string Word
			{
				get{return _word;}
				set{_word = value;}
			}

			string _pic;
			public string Picture
			{
				get{return _pic;}
				set{_pic = value;}
			}
		}

		class Nested
			{
				static Nested(){}
				internal static readonly Faces instance = new Faces();
			}
		}
}
