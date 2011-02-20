using System;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI;
using System.Collections;

namespace AnyWell.AW_UC
{
    public class Navigation : ListControlBase
    {
        protected override object GetDataObject()
        {
            return new AW_Navigation_dao().funcGetNavigations();
        }
    }
}
