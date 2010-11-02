using System;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;

namespace AnyWell.AW_UC
{
    public class SiteInfoList : ListControlBase
    {
        protected override object GetDataObject()
        {
            return new AW_SiteInfo_dao().funcGetSiteInfoListByUC();
        }
    }
}
