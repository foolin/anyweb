using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace AnyWell.AW_UC
{
    public class TemplateItem : Control, IDataItemContainer
    {
        public TemplateItem()
        {
        }

        public TemplateItem( object dataItem, int index )
        {
            _dataItem = dataItem;
            _index = index;
        }

        #region IDataItemContainer 成员

        object _dataItem;
        public object DataItem
        {
            get
            {
                return _dataItem;
            }
        }

        int _index;
        public int DataItemIndex
        {
            get
            {
                return _index;
            }
        }

        public int DisplayIndex
        {
            get
            {
                return _index;
            }
        }

        #endregion

        public int ItemIndex
        {
            get
            {
                return _index;
            }
        }
    }
}
