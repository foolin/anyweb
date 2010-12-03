using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_ResumeSearch : PageAdmin
{
    protected override void OnPreRender( EventArgs e )
    {
        if( !string.IsNullOrEmpty( QS( "no" ) ) )
        {
            this.no = int.Parse( QS( "no" ) );
        }
        if( !string.IsNullOrEmpty( QS( "type" ) ) )
        {
            this.type = int.Parse( QS( "type" ) );
        }
        this.key = QS( "key" );
        if( this.key == "多关键字用空格隔开" )
        {
            this.key = "";
        }
        if( !string.IsNullOrEmpty( QS( "workfrom" ) ) )
        {
            this.workfrom = int.Parse( QS( "workfrom" ) );
        }
        if( !string.IsNullOrEmpty( QS( "workto" ) ) )
        {
            this.workto = int.Parse( QS( "workto" ) );
        }
        if( !string.IsNullOrEmpty( QS( "edufrom" ) ) )
        {
            this.edufrom = int.Parse( QS( "edufrom" ) );
        }
        if( !string.IsNullOrEmpty( QS( "eduto" ) ) )
        {
            this.eduto = int.Parse( QS( "eduto" ) );
        }
        if( !string.IsNullOrEmpty( QS( "agefrom" ) ) )
        {
            this.agefrom = int.Parse( QS( "agefrom" ) );
        }
        if( !string.IsNullOrEmpty( QS( "ageto" ) ) )
        {
            this.ageto = int.Parse( QS( "ageto" ) );
        }
        if( !string.IsNullOrEmpty( QS( "sex" ) ) )
        {
            this.sex = int.Parse( QS( "sex" ) );
        }
        if( !string.IsNullOrEmpty( QS( "saleryfrom" ) ) )
        {
            this.saleryfrom = int.Parse( QS( "saleryfrom" ) );
        }
        if( !string.IsNullOrEmpty( QS( "saleryto" ) ) )
        {
            this.saleryto = int.Parse( QS( "saleryto" ) );
        }
        if( !string.IsNullOrEmpty( QS( "update" ) ) )
        {
            this.update = int.Parse( QS( "update" ) );
        }
        if( !string.IsNullOrEmpty( QS( "majorid" ) ) )
        {
            string[] majorids = QS( "majorid" ).Split( ';' );
            string[] majors = QS( "major" ).Split( ';' );
            for( int i = 0; i < majorids.Length; i++ )
            {
                if( !string.IsNullOrEmpty( majorids[ i ] ) )
                {
                    this.majorid[ i ] = int.Parse( majorids[ i ] );
                    this.major[ i ] = majors[ i ];
                }
            }
        }
        if( !string.IsNullOrEmpty( QS( "addressid" ) ) )
        {
            string[] addressids = QS( "addressid" ).Split( ';' );
            string[] addresses = QS( "address" ).Split( ';' );
            for( int i = 0; i < addressids.Length; i++ )
            {
                if( !string.IsNullOrEmpty( addressids[ i ] ) )
                {
                    this.addressid[ i ] = int.Parse( addressids[ i ] );
                    this.address[ i ] = addresses[ i ];
                }
            }
        }
        if( !string.IsNullOrEmpty( QS( "industryid" ) ) )
        {
            string[] industryids = QS( "industryid" ).Split( ';' );
            string[] industrys = QS( "industry" ).Split( ';' );
            for( int i = 0; i < industryids.Length; i++ )
            {
                if( !string.IsNullOrEmpty( industryids[ i ] ) )
                {
                    this.industryid[ i ] = int.Parse( industryids[ i ] );
                    this.industry[ i ] = industrys[ i ];
                }
            }
        }
        DateTime updatefrom, updateto;
        switch( this.update )
        {
            case 1:
                updatefrom = DateTime.Now.AddDays( -7 );
                updateto = DateTime.Now;
                break;
            case 2:
                updatefrom = DateTime.Now.AddDays( -14 );
                updateto = DateTime.Now;
                break;
            case 3:
                updatefrom = DateTime.Now.AddDays( -30 );
                updateto = DateTime.Now;
                break;
            case 4:
                updatefrom = DateTime.Now.AddDays( -60 );
                updateto = DateTime.Now;
                break;
            case 5:
                updatefrom = DateTime.Now.AddDays( -180 );
                updateto = DateTime.Now;
                break;
            case 6:
                updatefrom = DateTime.Parse( string.Format( "{0}-1-1", DateTime.Now.Year - 1 ) );
                updateto = DateTime.Parse( string.Format( "{0}-1-1", DateTime.Now.Year ) );
                break;
            case 7:
                updatefrom = DateTime.Parse( string.Format( "{0}-1-1", DateTime.Now.Year - 2 ) );
                updateto = DateTime.Parse( string.Format( "{0}-1-1", DateTime.Now.Year - 1 ) );
                break;
            case 8:
                updatefrom = DateTime.Parse( string.Format( "{0}-1-1", DateTime.Now.Year - 3 ) );
                updateto = DateTime.Parse( string.Format( "{0}-1-1", DateTime.Now.Year - 2 ) );
                break;
            default:
                updatefrom = DateTime.Now.AddDays( -7 );
                updateto = DateTime.Now;
                break;
        }

        int recordCount = 0;
        compRep.DataSource = new AW_Resume_dao().funcSearchResume( no, type, key, workfrom, workto, edufrom, eduto, agefrom, ageto, sex, saleryfrom, saleryto, majorid, addressid, industryid, updatefrom, updateto, PN1.PageIndex, PN1.PageSize, out recordCount );
        compRep.DataBind();
        PN1.SetPage( recordCount );
   }

    private int _no = 0;
    /// <summary>
    /// 简历编号
    /// </summary>
    public int no
    {
        get
        {
            return _no;
        }
        set
        {
            _no = value;
        }
    }

    private int _type = 1;
    /// <summary>
    /// 类别
    /// </summary>
    public int type
    {
        get
        {
            return _type;
        }
        set
        {
            _type = value;
        }
    }

    private string _key = "";
    /// <summary>
    /// 关键字
    /// </summary>
    public string key
    {
        get
        {
            return _key;
        }
        set
        {
            _key = value;
        }
    }

    private int _workfrom = 0;
    /// <summary>
    /// 工作年限 起始
    /// </summary>
    public int workfrom
    {
        get
        {
            return _workfrom;
        }
        set
        {
            _workfrom = value;
        }
    }

    private int _workto = 0;
    /// <summary>
    /// 工作年限 结束
    /// </summary>
    public int workto
    {
        get
        {
            return _workto;
        }
        set
        {
            _workto = value;
        }
    }

    private int _edufrom = 0;
    /// <summary>
    /// 学历 起始
    /// </summary>
    public int edufrom
    {
        get
        {
            return _edufrom;
        }
        set
        {
            _edufrom = value;
        }
    }

    private int _eduto = 0;
    /// <summary>
    /// 学历结束
    /// </summary>
    public int eduto
    {
        get
        {
            return _eduto;
        }
        set
        {
            _eduto = value;
        }
    }

    private int _agefrom = 0;
    /// <summary>
    /// 年龄 起始
    /// </summary>
    public int agefrom
    {
        get
        {
            return _agefrom;
        }
        set
        {
            _agefrom = value;
        }
    }

    private int _ageto = 0;
    /// <summary>
    /// 年龄 结束
    /// </summary>
    public int ageto
    {
        get
        {
            return _ageto;
        }
        set
        {
            _ageto = value;
        }
    }

    private int _sex = -1;
    /// <summary>
    /// 性别
    /// </summary>
    public int sex
    {
        get
        {
            return _sex;
        }
        set
        {
            _sex = value;
        }
    }

    private int _saleryfrom = 0;
    /// <summary>
    /// 目前年薪 起始
    /// </summary>
    public int saleryfrom
    {
        get
        {
            return _saleryfrom;
        }
        set
        {
            _saleryfrom = value;
        }
    }

    private int _saleryto = 0;
    /// <summary>
    /// 目前年薪 结束
    /// </summary>
    public int saleryto
    {
        get
        {
            return _saleryto;
        }
        set
        {
            _saleryto = value;
        }
    }

    private int _update = 4;
    /// <summary>
    /// 更新时间
    /// </summary>
    public int update
    {
        get
        {
            return _update;
        }
        set
        {
            _update = value;
        }
    }

    private int[] _majorid = { 0, 0, 0 };
    /// <summary>
    /// 专业编号
    /// </summary>
    public int[] majorid
    {
        get
        {
            return _majorid;
        }
        set
        {
            _majorid = value;
        }
    }

    private string[] _major = { "", "", "" };
    /// <summary>
    /// 专业
    /// </summary>
    public string[] major
    {
        get
        {
            return _major;
        }
        set
        {
            _major = value;
        }
    }

    //private int _majorid1 = 0;
    ///// <summary>
    ///// 专业编号1
    ///// </summary>
    //public int majorid1
    //{
    //    get
    //    {
    //        return _majorid1;
    //    }
    //    set
    //    {
    //        _majorid1 = value;
    //    }
    //}

    //private string _major1 = "";
    ///// <summary>
    ///// 专业1
    ///// </summary>
    //public string major1
    //{
    //    get
    //    {
    //        return _major1;
    //    }
    //    set
    //    {
    //        _major1 = value;
    //    }
    //}

    //private int _majorid2 = 0;
    ///// <summary>
    ///// 专业编号2
    ///// </summary>
    //public int majorid2
    //{
    //    get
    //    {
    //        return _majorid2;
    //    }
    //    set
    //    {
    //        _majorid2 = value;
    //    }
    //}

    //private string _major2 = "";
    ///// <summary>
    ///// 专业2
    ///// </summary>
    //public string major2
    //{
    //    get
    //    {
    //        return _major2;
    //    }
    //    set
    //    {
    //        _major2 = value;
    //    }
    //}

    //private int _majorid3 = 0;
    ///// <summary>
    ///// 专业编号3
    ///// </summary>
    //public int majorid3
    //{
    //    get
    //    {
    //        return _majorid3;
    //    }
    //    set
    //    {
    //        _majorid3 = value;
    //    }
    //}

    //private string _major3 = "";
    ///// <summary>
    ///// 专业3
    ///// </summary>
    //public string major3
    //{
    //    get
    //    {
    //        return _major3;
    //    }
    //    set
    //    {
    //        _major3 = value;
    //    }
    //}


    private int[] _addressid = { 0, 0, 0 };
    /// <summary>
    /// 居住地编号
    /// </summary>
    public int[] addressid
    {
        get
        {
            return _addressid;
        }
        set
        {
            _addressid = value;
        }
    }


    private string[] _address = { "", "", "" };
    /// <summary>
    /// 居住地
    /// </summary>
    public string[] address
    {
        get
        {
            return _address;
        }
        set
        {
            _address = value;
        }
    }
			


    //private int _addressid1 = 0;
    ///// <summary>
    ///// 居住地编号1
    ///// </summary>
    //public int addressid1
    //{
    //    get
    //    {
    //        return _addressid1;
    //    }
    //    set
    //    {
    //        _addressid1 = value;
    //    }
    //}


    //private string _address1 = "";
    ///// <summary>
    ///// 居住地1
    ///// </summary>
    //public string address1
    //{
    //    get
    //    {
    //        return _address1;
    //    }
    //    set
    //    {
    //        _address1 = value;
    //    }
    //}

    //private int _addressid2 = 0;
    ///// <summary>
    ///// 居住地编号2
    ///// </summary>
    //public int addressid2
    //{
    //    get
    //    {
    //        return _addressid2;
    //    }
    //    set
    //    {
    //        _addressid2 = value;
    //    }
    //}

    //private string _address2 = "";
    ///// <summary>
    ///// 居住地2
    ///// </summary>
    //public string address2
    //{
    //    get
    //    {
    //        return _address2;
    //    }
    //    set
    //    {
    //        _address2 = value;
    //    }
    //}

    //private int _addressid3 = 0;
    ///// <summary>
    ///// 居住地编号3
    ///// </summary>
    //public int addressid3
    //{
    //    get
    //    {
    //        return _addressid3;
    //    }
    //    set
    //    {
    //        _addressid3 = value;
    //    }
    //}

    //private string _address3 = "";
    ///// <summary>
    ///// 居住地3
    ///// </summary>
    //public string address3
    //{
    //    get
    //    {
    //        return _address3;
    //    }
    //    set
    //    {
    //        _address3 = value;
    //    }
    //}

    private int[] _industryid = { 0, 0, 0 };
    /// <summary>
    /// 行业编号
    /// </summary>
    public int[] industryid
    {
        get
        {
            return _industryid;
        }
        set
        {
            _industryid = value;
        }
    }


    private string[] _industry = { "", "", "" };
    /// <summary>
    /// 行业
    /// </summary>
    public string[] industry
    {
        get
        {
            return _industry;
        }
        set
        {
            _industry = value;
        }
    }
			
			
    //private int _industryid1 = 0;
    ///// <summary>
    ///// 行业编号1
    ///// </summary>
    //public int industryid1
    //{
    //    get
    //    {
    //        return _industryid1;
    //    }
    //    set
    //    {
    //        _industryid1 = value;
    //    }
    //}

    //private string _industry1 = "";
    ///// <summary>
    ///// 行业1
    ///// </summary>
    //public string industry1
    //{
    //    get
    //    {
    //        return _industry1;
    //    }
    //    set
    //    {
    //        _industry1 = value;
    //    }
    //}

    //private int _industryid2 = 0;
    ///// <summary>
    ///// 行业编号2
    ///// </summary>
    //public int industryid2
    //{
    //    get
    //    {
    //        return _industryid2;
    //    }
    //    set
    //    {
    //        _industryid2 = value;
    //    }
    //}

    //private string _industry2 = "";
    ///// <summary>
    ///// 行业2
    ///// </summary>
    //public string industry2
    //{
    //    get
    //    {
    //        return _industry2;
    //    }
    //    set
    //    {
    //        _industry2 = value;
    //    }
    //}

    //private int _industryid3 = 0;
    ///// <summary>
    ///// 行业编号3
    ///// </summary>
    //public int industryid3
    //{
    //    get
    //    {
    //        return _industryid3;
    //    }
    //    set
    //    {
    //        _industryid3 = value;
    //    }
    //}

    //private string _industry3 = "";
    ///// <summary>
    ///// 行业3
    ///// </summary>
    //public string industry3
    //{
    //    get
    //    {
    //        return _industry3;
    //    }
    //    set
    //    {
    //        _industry3 = value;
    //    }
    //}
	
    /// <summary>
    /// 获取专业
    /// </summary>
    /// <param name="split"></param>
    /// <returns></returns>
    protected string getMajorStr( string split, string result )
    {
        string str = "";
        for( int i = 0; i < majorid.Length; i++ )
        {
            if( majorid[ i ] != 0 )
            {
                str += split + major[ i ];
            }
        }
        if( str.Length > 0 )
        {
            str = str.Substring( split.Length );
        }
        else
        {
            str = result;
        }
        return str;
    }

    /// <summary>
    /// 获取专业编号
    /// </summary>
    /// <param name="split"></param>
    /// <returns></returns>
    protected string getMajoridStr( string split,string result )
    {
        string str = "";
        for( int i = 0; i < majorid.Length; i++ )
        {
            if( majorid[ i ] != 0 )
            {
                str += split + majorid[ i ];
            }
        }
        if( str.Length > 0 )
        {
            str = str.Substring( split.Length );
        }
        else
        {
            str = result;
        }
        return str;
    }

    /// <summary>
    /// 获取居住地
    /// </summary>
    /// <param name="split"></param>
    /// <returns></returns>
    protected string getAddressStr( string split, string result )
    {
        string str = "";
        for( int i = 0; i < addressid.Length; i++ )
        {
            if( addressid[ i ] != 0 )
            {
                str += split + address[ i ];
            }
        }
        if( str.Length > 0 )
        {
            str = str.Substring( split.Length );
        }
        else
        {
            str = result;
        }
        return str;
    }

    /// <summary>
    /// 获取居住地编号
    /// </summary>
    /// <param name="split"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    protected string getAddressidStr( string split, string result )
    {
        string str = "";
        for( int i = 0; i < addressid.Length; i++ )
        {
            if( addressid[ i ] != 0 )
            {
                str += split + addressid[ i ];
            }
        }
        if( str.Length > 0 )
        {
            str = str.Substring( split.Length );
        }
        else
        {
            str = result;
        }
        return str;
    }

    /// <summary>
    /// 获取行业
    /// </summary>
    /// <param name="split"></param>
    /// <returns></returns>
    protected string getIndustryStr( string split, string result )
    {
        string str = "";
        for( int i = 0; i < industryid.Length; i++ )
        {
            if( industryid[ i ] != 0 )
            {
                str += split + industry[ i ];
            }
        }
        if( str.Length > 0 )
        {
            str = str.Substring( split.Length );
        }
        else
        {
            str = result;
        }
        return str;
    }

    /// <summary>
    /// 获取行业编号
    /// </summary>
    /// <param name="split"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    protected string getIndustryidStr( string split, string result )
    {
        string str = "";
        for( int i = 0; i < industryid.Length; i++ )
        {
            if( industryid[ i ] != 0 )
            {
                str += split + industryid[ i ];
            }
        }
        if( str.Length > 0 )
        {
            str = str.Substring( split.Length );
        }
        else
        {
            str = result;
        }
        return str;
    }																												
}
