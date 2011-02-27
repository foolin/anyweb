using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Control_Uploader : System.Web.UI.UserControl
{
    protected void Page_Load( object sender, EventArgs e )
    {

    }

    private string _FilePath = "/Upload/";
    public string FilePath
    {
        get
        {
            return _FilePath;
        }
        set
        {
            _FilePath = value;
        }
    }

    private string _JavascriptReturnFunction = "";
    public string JavascriptReturnFunction
    {
        get
        {
            return _JavascriptReturnFunction;
        }
        set
        {
            _JavascriptReturnFunction = value;
        }
    }

    private bool _Multiselect = true;
    public bool Multiselect
    {
        get
        {
            return _Multiselect;
        }
        set
        {
            _Multiselect = value;
        }
    }

    private int _MaxNumberToUpload = -1;
    public int MaxNumberToUpload
    {
        get
        {
            return _MaxNumberToUpload;
        }
        set
        {
            _MaxNumberToUpload = value;
        }
    }
}
