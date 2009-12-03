using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Common
{  /// <summary>
    /// 可添加到页面的插件

    /// </summary>
    public  class validWidget
    {
        private int _dataID;

        public int DataID
        {
            get { return _dataID; }
            set { _dataID = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private Widget _ofwidget;

        public Widget OfWidget
        {
            get { return _ofwidget; }
            set { _ofwidget = value; }
        }
    }

}
