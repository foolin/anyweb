using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWeb.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_Member_Contact_bean
	{

        public string Province
        {
            get 
            {
                AnyWeb.Configs.Province province = AnyWeb.Configs.AreaConfigs.GetConfigs().funcGetProvinceById(fdContProvinceID);
                return province == null ? null : province.Name;
            }
        }

        public string City
        {
            get 
            {
                if (Province == null) return null;
                AnyWeb.Configs.City city = AnyWeb.Configs.AreaConfigs.GetConfigs().funcGetProvinceById(fdContProvinceID).funcGetCityById(fdContCityID);
                return city == null ? null : city.Name;
            }
        }

        public string Area
        {
            get
            {
                if (City == null) return null;
                AnyWeb.Configs.Area area = AnyWeb.Configs.AreaConfigs.GetConfigs().funcGetProvinceById(fdContProvinceID).funcGetCityById(fdContCityID).funcGetAreaById(fdContAreaID);
                return area == null ? null : area.Name;
            }
        }

	}
}
