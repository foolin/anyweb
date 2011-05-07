using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;

/// <summary>
/// 菜单项
/// </summary>
public class DropMenuItem
{
    private int _ID;
    public int ID
    {
        get
        {
            return _ID;
        }
        set
        {
            _ID = value;
        }
    }

    private string _Url;
    /// <summary>
    /// 链接地址
    /// </summary>
    public string Url
    {
        get
        {
            return _Url;
        }
        set
        {
            _Url = value;
        }
    }

    private string _Target = "";
    /// <summary>
    /// 链接目标
    /// </summary>
    public string Target
    {
        get
        {
            return _Target;
        }
        set
        {
            _Target = value;
        }
    }

    private string _Name;
    /// <summary>
    /// 名称
    /// </summary>
    public string Name
    {
        get
        {
            return _Name;
        }
        set
        {
            _Name = value;
        }
    }

    private ArrayList _Children;
    /// <summary>
    /// 下级列表
    /// </summary>
    public ArrayList Children
    {
        get
        {
            return _Children;
        }
        set
        {
            _Children = value;
        }
    }

    private DropMenuItem _Parent;
    /// <summary>
    /// 上级
    /// </summary>
    public DropMenuItem Parent
    {
        get
        {
            return _Parent;
        }
        set
        {
            _Parent = value;
        }
    }
}
