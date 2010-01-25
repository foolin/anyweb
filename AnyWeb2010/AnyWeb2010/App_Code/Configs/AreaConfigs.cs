using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Studio.Array;
using System.Xml;

namespace AnyWeb.AW.Configs
{
    /// <summary>
    /// 省份城市设置
    /// </summary>
    public class AreaConfigs
    {

        public AreaConfigs()
        {
            _provinces = new List<Province>();

            XmlDocument xml = new XmlDocument();
            xml.Load(_areaFile);
            XmlNode root = xml.SelectSingleNode("Provinces");

            foreach (XmlNode node in root.ChildNodes)
            {
                Province province = new Province();
                province.ID = int.Parse(node.Attributes["id"].Value);
                province.Name = node.Attributes["name"].Value;
                province.Cities = new List<City>();
                foreach (XmlNode n in node.ChildNodes)
                {
                    City city = new City();
                    city.ID = int.Parse(n.Attributes["id"].Value);
                    city.Name = n.Attributes["name"].Value;
                    city.Province = province;
                    city.Areas = new List<Area>();
                    foreach (XmlNode na in n.ChildNodes)
                    {
                        Area area = new Area();
                        area.ID = int.Parse(na.Attributes["id"].Value);
                        area.Name = na.Attributes["name"].Value;
                        area.City = city;
                        city.Areas.Add(area);
                    }
                    province.Cities.Add(city);
                }
                _provinces.Add(province);
            }
        }


        private static object lockHelper = new object();
        private static volatile AreaConfigs instance = null;
        string _areaFile = HttpContext.Current.Server.MapPath("~/App_Data/Areas.xml");


        public static AreaConfigs GetConfigs()
        {
            if (instance == null)
            {
                lock (lockHelper)
                {
                    if (instance == null)
                    {
                        instance = new AreaConfigs();
                    }
                }
            }
            return instance;

        }

        public static void SetInstance(AreaConfigs anInstance)
        {
            if (anInstance != null)
                instance = anInstance;
        }

        public static void SetInstance()
        {
            SetInstance(new AreaConfigs());
        }



        public Province funcGetProvinceById(int provinceID)
        {
            if (_provinces == null)
                return null;
            foreach (Province province in this._provinces)
                if (province.ID == provinceID)
                    return province;
            return null;
        }
	

        private List<Province> _provinces;
        /// <summary>
        /// 省份列表
        /// </summary>
        public List<Province> Provinces
        {
            get { return _provinces; }
            set { _provinces = value; }
        }
    }

    /// <summary>
    /// 省份对象
    /// </summary>
    public class Province : IdObject
    {
        private string _name;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private List<City> _cities;
        /// <summary>
        /// 省份下面的城市
        /// </summary>
        public List<City> Cities
        {
            get { return _cities; }
            set { _cities = value; }
        }

        public City funcGetCityById(int cityID)
        {
            if (_cities == null)
                return null;
            foreach (City ci in this._cities)
                if (ci.ID == cityID)
                    return ci;
            return null;
        }

    }

    /// <summary>
    /// 城市对象
    /// </summary>
    public class City : IdObject
    {
        private string _name;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private Province _province;
        /// <summary>
        /// 所属省份
        /// </summary>
        public Province Province
        {
            get { return _province; }
            set { _province = value; }
        }

        private List<Area> _areas;
        /// <summary>
        ///城市下面的区域
        /// </summary>
        public List<Area> Areas
        {
            get { return _areas; }
            set { _areas = value; }
        }

        public Area funcGetAreaById(int areaID)
        {
            if (_areas == null)
                return null;
            foreach (Area area in this._areas)
                if (area.ID == areaID)
                    return area;
            return null;
        }
    }

    public class Area : IdObject
    {
        private string _name;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private City _city;
        /// <summary>
        /// 所属城市
        /// </summary>
        public City City
        {
            get { return _city; }
            set { _city = value; }
        }
	
    }



}
