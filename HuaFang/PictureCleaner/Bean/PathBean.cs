using System;
using System.Collections.Generic;
using System.Text;

namespace PictureCleaner
{
    public class PathBean
    {
        private string _RootPath;
        public string RootPath
        {
            get
            {
                return _RootPath;
            }
            set
            {
                _RootPath = value;
            }
        }

        private string _Prefix;
        public string Prefix
        {
            get
            {
                return _Prefix;
            }
            set
            {
                _Prefix = value;
            }
        }
    }
}
