using System;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;

namespace AnyWell.AW_UC
{
    public class AD : ItemControlBase
    {
        private int _adID;
        /// <summary>
        /// 广告编号
        /// </summary>
        public int ADID
        {
            get
            {
                return _adID;
            }
            set
            {
                _adID = value;
            }
        }

        protected override object GetItemObject()
        {
            AW_AD_bean ad;
            ad = AW_AD_bean.funcGetByID( this.ADID );
            return ad;
        }
    }
}
