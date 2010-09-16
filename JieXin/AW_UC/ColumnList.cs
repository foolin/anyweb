using System;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.ComponentModel;
using Studio.Web;

namespace AnyWell.AW_UC
{
    public class ColumnList : ListControlBase
    {
        public int _columnID;
        /// <summary>
        /// 栏目编号
        /// </summary>
        public int ColumnID
        {
            get
            {
                if (this.IsContext)
                {
                    int.TryParse(this.ContextItem(this.IDName), out this._columnID);
                }
                else
                {
                    int.TryParse(this.QS(this.IDName), out this._columnID);
                }
                return this._columnID;
            }
            set { _columnID = value; }
        }

        private bool _getParent = false;
        /// <summary>
        /// 获取或设置是否返回同级栏目
        /// </summary>
        [Description("设置是否返回同级栏目")]
        public bool GetParent
        {
            get { return _getParent; }
            set { _getParent = value; }
        }

        protected override object GetDataObject()
        {
            if (this.ColumnID == 0)
            {
                if (string.IsNullOrEmpty(this.ErrorMsg))
                {
                    this.ErrorMsg = "栏目不存在！";
                }
                WebAgent.FailAndGo(this.ErrorMsg, this.ErrorPage);
                return null;
            }
            else
            {
                AW_Column_bean bean = AW_Column_bean.funcGetByID(this.ColumnID);
                if (bean == null)
                {
                    if (string.IsNullOrEmpty(this.ErrorMsg))
                    {
                        this.ErrorMsg = "栏目不存在！";
                    }
                    WebAgent.FailAndGo(this.ErrorMsg, this.ErrorPage);
                }
                return new AW_Column_dao().funcGetColumnListByUC(this.ColumnID, this.GetParent, this.TopCount, this.Where, this.Order, this.CacheName);
            }
        }
    }
}
