using System;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Web;

namespace AnyWell.AW_UC
{
    public class Column : ItemControlBase
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
                switch (this.ItemType)
                {
                    case ItemObjectType.Next:
                        {
                            this._columnID = new AW_Column_dao().funcGetNextColumnIDByUC(this._columnID);
                            break;
                        }
                    case ItemObjectType.Previous:
                        {
                            this._columnID = new AW_Column_dao().funcGetPreviousColumnIDByUC(this._columnID);
                            break;
                        }
                    case ItemObjectType.Parent:
                        {
                            AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo(this._columnID);
                            if (column != null)
                            {
                                this._columnID = column.fdColuParentID;
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                return this._columnID;
            }
            set { _columnID = value; }
        }

        protected override object GetItemObject()
        {
            AW_Column_bean column;

            if (this.ColumnID == 0)
            {
                if (this.ItemType == ItemObjectType.Current)
                {
                    if (string.IsNullOrEmpty(this.ErrorMsg))
                    {
                        this.ErrorMsg = "栏目不存在！";
                    }
                    WebAgent.FailAndGo(this.ErrorMsg, this.ErrorPage);
                }
                else
                {
                    return null;
                }

            }
            if (this.ItemType == ItemObjectType.Parent && this.ColumnID == 0)
            {
                return null;
            }

            //从上下文中读取该栏目，如果该栏目存在的话
            if (HttpContext.Current.Items["COLUMN_" + this.ColumnID] != null)
            {
                column = (AW_Column_bean)HttpContext.Current.Items["COLUMN_" + this.ColumnID];
            }
            else
            {
                column = AW_Column_bean.funcGetByID(this.ColumnID);
                HttpContext.Current.Items.Add("COLUMN_" + this.ColumnID, column);
            }
            if (column == null)
            {
                if (string.IsNullOrEmpty(this.ErrorMsg))
                {
                    this.ErrorMsg = "栏目不存在！";
                }
                WebAgent.FailAndGo(this.ErrorMsg, this.ErrorPage);
            }

            return column;
        }
    }
}
