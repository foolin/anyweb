using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Publish_bean
    {
        private AW_Admin_bean _Creater;
        /// <summary>
        /// 发布者
        /// </summary>
        public AW_Admin_bean Creater
        {
            get
            {
                return _Creater;
            }
            set
            {
                _Creater = value;
            }
        }

        public PublishObjectType ObjectType
        {
            get
            {
                return ( PublishObjectType ) this.fdPublObjType;
            }
        }

        public PublishType PublishType
        {
            get
            {
                return ( PublishType ) this.fdPublType;
            }
        }

        public string PublishTypeName
        {
            get
            {
                switch( ( PublishType ) this.fdPublType )
                {
                    case PublishType.HomeOnly:
                        return "仅发布首页";
                    case PublishType.Additional:
                        return "增量发布";
                    case PublishType.Complete:
                        return "完全发布";
                    case PublishType.Cancel:
                        return "撤销发布";
                    default:
                        return "";
                }
            }
        }

        public string PublishTime
        {
            get
            {
                if( this.fdPublStatus == 0 )
                {
                    return "未运行";
                }
                TimeSpan ts = DateTime.Now - this.fdPublStartAt;
                if( this.fdPublStatus == 2||this.fdPublStatus==3 )
                {
                    ts = this.fdPublFinishAt - this.fdPublStartAt;
                }
                if( ts.Hours > 0 )
                {
                    return string.Format( "{0}小时{1}分{2}.{3}秒", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds );
                }
                if( ts.Minutes > 0 )
                {
                    return string.Format( "{0}分{1}.{2}秒", ts.Minutes, ts.Seconds, ts.Milliseconds );
                }
                if( ts.Seconds > 0 )
                {
                    return string.Format( "{0}.{1}秒", ts.Seconds, ts.Milliseconds );
                }
                else
                {
                    return string.Format( "0.{0}秒", ts.Milliseconds );
                }
            }
        }
	}

    public enum PublishObjectType : int
    {
        Site = 1,
        Column = 2,
        Document = 3,
        Single = 4,
        Product = 5
    }

    public enum PublishType : int
    {
        HomeOnly = 1,
        Additional = 2,
        Complete = 3,
        Cancel = 4
    }
}
