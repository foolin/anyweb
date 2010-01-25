using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace FortuneAge.IBOX_UC
{
    public class TemplateItem : Control, IDataItemContainer
    {
        public TemplateItem()
        { }

        public TemplateItem(object dataItem, int index)
        {
            _dataItem = dataItem;
            _index = index;
        }

        #region IDataItemContainer 成员

        object _dataItem;
        public object DataItem
        {
            get { return _dataItem; }
        }

        int _index;
        public int DataItemIndex
        {
            get { return _index; }
        }

        public int DisplayIndex
        {
            get { return _index; }
        }

        #endregion

        public int ItemIndex
        {
            get { return _index; }
        }
    }
}
