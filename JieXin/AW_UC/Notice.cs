using System;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;

namespace AnyWell.AW_UC
{
    public class Notice : ItemControlBase
    {
        private int _noticeID;
        /// <summary>
        /// 公告编号
        /// </summary>
        public int NoticeID
        {
            get
            {
                if (this._noticeID == 0)
                {
                    int.TryParse(this.ContextItem("NOTICEID"), out this._noticeID);
                }
                switch (this.ItemType)
                {
                    case ItemObjectType.Next:
                        {

                            this._noticeID = new AW_Notice_dao().funcGetNextNoticeIDByUC(this._noticeID);
                            break;
                        }
                    case ItemObjectType.Previous:
                        {
                            this._noticeID = new AW_Notice_dao().funcGetPreviousNoticeIDByUC(this._noticeID);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                return this._noticeID;
            }
            set { _noticeID = value; }
        }

        protected override object GetItemObject()
        {
            AW_Notice_bean notice;

            if (this.NoticeID == 0)
            {
                if (this.ItemType == ItemObjectType.Current)
                {
                    goErrorPage();
                    return null;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                //从上下文中读取该公告，如果该公告存在的话
                if (HttpContext.Current.Items["NOTICEID_" + this.NoticeID] != null)
                {
                    notice = (AW_Notice_bean)HttpContext.Current.Items["NOTICEID_" + this.NoticeID];
                }
                else
                {
                    notice = AW_Notice_bean.funcGetByID(this.NoticeID);
                    HttpContext.Current.Items.Add("NOTICEID_" + this.NoticeID, notice);
                }

                if (notice == null && this.ItemType == ItemObjectType.Current)
                {
                    HttpContext.Current.Response.Redirect("/Error.html");
                    return null;
                }
            }

            return notice;
        }
    }
}
