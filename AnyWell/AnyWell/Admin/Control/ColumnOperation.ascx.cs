using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Control_ColumnOperation : UserControlBase
{
    protected AW_Column_bean CurrentColumn
    {
        get
        {
            return ( ( PageAdmin ) Page ).CurrentColumn;
        }
    }
}
