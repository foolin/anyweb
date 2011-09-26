using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace PictureCleaner
{
    public class PathAgent
    {
        public PathAgent()
        {
            Init();
        }

        public void Init()
        {
            _pathes = new List<PathBean>();

            XmlDocument xml = new XmlDocument();
            if( !File.Exists( _pathFile ) )
            {
                return;
            }
            xml.Load( _pathFile );
            XmlNode root = xml.SelectSingleNode( "Pathes" );

            foreach( XmlNode node in root.ChildNodes )
            {
                PathBean bean = new PathBean();
                bean.RootPath = node.SelectSingleNode( "RootPath" ).InnerText;
                bean.Prefix = node.SelectSingleNode( "Prefix" ).InnerText;
                _pathes.Add( bean );
            }
        }

        private static object lockHelper = new object();
        private static volatile PathAgent instance = null;
        string _pathFile = System.Environment.CurrentDirectory + "\\Path.xml";

        public static PathAgent GetAgent()
        {
            if( instance == null )
            {
                lock( lockHelper )
                {
                    if( instance == null )
                    {
                        instance = new PathAgent();
                    }
                }
            }
            return instance;

        }

        public static void SetInstance( PathAgent anInstance )
        {
            if( anInstance != null )
                instance = anInstance;
        }

        public static void SetInstance()
        {
            SetInstance( new PathAgent() );
        }

        private List<PathBean> _pathes;
        public List<PathBean> Pathes
        {
            get
            {
                return _pathes;
            }
            set
            {
                _pathes = value;
            }
        }
    }
}
