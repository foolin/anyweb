using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using AnyWell.AW_DL;

namespace AnyWell.AW_UC
{
    /// <summary>
    /// 广告列表标签
    /// </summary>
    public class ADList : ListControlBase
    {
        private int _typeId = 0;
        /// <summary>
        /// 设置广告类型
        /// </summary>
        [Description( "设置广告类型" ), DefaultValue( 0 )]
        public int TypeID
        {
            get
            {
                return _typeId;
            }
            set
            {
                _typeId = value;
            }
        }

        protected override object GetDataObject()
        {
            List<AW_AD_bean> ads;
            ads = new AW_AD_dao().funcGetADListByUC( this.TypeID, this.TopCount, this.Where, this.Order, this.CacheName );
            return ads;
        }
    }
}
