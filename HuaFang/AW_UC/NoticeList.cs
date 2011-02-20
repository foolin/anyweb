using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using AnyWell.AW_DL;

namespace AnyWell.AW_UC
{
    public class NoticeList : ListControlBase
    {
        private bool _getContent = false;
        /// <summary>
        /// 获取公告内容
        /// </summary>
        [Description("是否获取公告内容"), DefaultValue(false)]
        public bool GetContent
        {
            get { return _getContent; }
            set { _getContent = value; }
        }

        private string _pagerID;
        /// <summary>
        /// 获取或设置分页控件的ID
        /// </summary>
        [Description("设置关联的分页控件ID")]
        public string PagerID
        {
            get { return _pagerID; }
            set { _pagerID = value; }
        }

        protected virtual Pager Pager
        {
            get
            {
                if (string.IsNullOrEmpty(this.PagerID) == false)
                {
                    return (Pager)this.Parent.FindControl(this.PagerID);
                }
                else
                {
                    return null;
                }
            }
        }

        protected override object GetDataObject()
        {
            List<AW_Notice_bean> notices;
            if (this.Pager == null)
            {
                notices = new AW_Notice_dao().funcGetNoticeListByUC(this.TopCount, this.Where, this.Order, this.CacheName, this.GetContent);
            }
            else
            {
                int recordCount = 0;
                notices = new AW_Notice_dao().funcGetNoticeListByUC(this.Where, this.Order, this.Pager.PageID, this.Pager.PageSize, out recordCount, this.GetContent);
                this.Pager.RecordCount = recordCount;
            }
            return notices;
        }
    }
}
