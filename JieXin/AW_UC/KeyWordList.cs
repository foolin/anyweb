using System;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;

namespace AnyWell.AW_UC
{
    public class KeyWordList : ListControlBase
    {
        protected override object GetDataObject()
        {
            List<AW_KeyWord_bean> keywords;
            keywords = new AW_KeyWord_dao().funcGetKeyWordListByUC( this.TopCount, this.Where, this.Order, this.CacheName );
            return keywords;
        }
    }
}
