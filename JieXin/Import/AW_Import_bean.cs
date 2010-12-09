using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnyWell.AW_DL;

namespace Import
{
    public partial class AW_Import_bean : Bean_Base
    {

        private int _no;
        /// <summary>
        /// no
        /// </summary>
        public int no
        {
            get
            {
                return _no;
            }
            set
            {
                _no = value;
            }
        }

        private string _name;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private string _sex;
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get
            {
                return _sex;
            }
            set
            {
                _sex = value;
            }
        }

        private string _birthday;
        /// <summary>
        /// 出生年月
        /// </summary>
        public string Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                _birthday = value;
            }
        }

        private string _address;
        /// <summary>
        /// 居住地
        /// </summary>
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        private string _experience;
        /// <summary>
        /// 工作年限
        /// </summary>
        public string Experience
        {
            get
            {
                return _experience;
            }
            set
            {
                _experience = value;
            }
        }

        private string _houseAddress;
        /// <summary>
        /// 户口
        /// </summary>
        public string HouseAddress
        {
            get
            {
                return _houseAddress;
            }
            set
            {
                _houseAddress = value;
            }
        }

        private string _salary;
        /// <summary>
        /// 目前年薪
        /// </summary>
        public string Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
            }
        }

        private string _contactAddress;
        /// <summary>
        /// 联系地址
        /// </summary>
        public string ContactAddress
        {
            get
            {
                return _contactAddress;
            }
            set
            {
                _contactAddress = value;
            }
        }

        private string _postCode;
        /// <summary>
        /// 邮编
        /// </summary>
        public string PostCode
        {
            get
            {
                return _postCode;
            }
            set
            {
                _postCode = value;
            }
        }

        private string _email;
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        private string _familyPhone;
        /// <summary>
        /// 家庭电话
        /// </summary>
        public string FamilyPhone
        {
            get
            {
                return _familyPhone;
            }
            set
            {
                _familyPhone = value;
            }
        }

        private string _mobilePhone;
        /// <summary>
        /// 移动电话
        /// </summary>
        public string MobilePhone
        {
            get
            {
                return _mobilePhone;
            }
            set
            {
                _mobilePhone = value;
            }
        }

        private string _companyPhone;
        /// <summary>
        /// 公司电话
        /// </summary>
        public string CompanyPhone
        {
            get
            {
                return _companyPhone;
            }
            set
            {
                _companyPhone = value;
            }
        }

        private string _objIntro;
        /// <summary>
        /// 自我评价
        /// </summary>
        public string ObjIntro
        {
            get
            {
                return _objIntro;
            }
            set
            {
                _objIntro = value;
            }
        }

        private string _objType;
        /// <summary>
        /// 工作性质
        /// </summary>
        public string ObjType
        {
            get
            {
                return _objType;
            }
            set
            {
                _objType = value;
            }
        }

        private string _objIndustry;
        /// <summary>
        /// 工作行业
        /// </summary>
        public string ObjIndustry
        {
            get
            {
                return _objIndustry;
            }
            set
            {
                _objIndustry = value;
            }
        }

        private string _objAddress;
        /// <summary>
        /// 工作地点
        /// </summary>
        public string ObjAddress
        {
            get
            {
                return _objAddress;
            }
            set
            {
                _objAddress = value;
            }
        }

        private string _objSalery;
        /// <summary>
        /// 期望工资
        /// </summary>
        public string ObjSalery
        {
            get
            {
                return _objSalery;
            }
            set
            {
                _objSalery = value;
            }
        }

        private string _objFuncType;
        /// <summary>
        /// 目标职能
        /// </summary>
        public string ObjFuncType
        {
            get
            {
                return _objFuncType;
            }
            set
            {
                _objFuncType = value;
            }
        }

        private string _objcompType;
        /// <summary>
        /// 公司性质
        /// </summary>
        public string ObjCompType
        {
            get
            {
                return _objcompType;
            }
            set
            {
                _objcompType = value;
            }
        }

        private string _work;
        /// <summary>
        /// 工作经验
        /// </summary>
        public string Work
        {
            get
            {
                return _work;
            }
            set
            {
                _work = value;
            }
        }

        private string _education;
        /// <summary>
        /// 教育经历
        /// </summary>
        public string Education
        {
            get
            {
                return _education;
            }
            set
            {
                _education = value;
            }
        }

        private string _rewards;
        /// <summary>
        /// 奖励
        /// </summary>
        public string Rewards
        {
            get
            {
                return _rewards;
            }
            set
            {
                _rewards = value;
            }
        }

        private string _language;
        /// <summary>
        /// 语言能力
        /// </summary>
        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
            }
        }

        private string _skill;
        /// <summary>
        /// 技能
        /// </summary>
        public string Skill
        {
            get
            {
                return _skill;
            }
            set
            {
                _skill = value;
            }
        }

        private string _cert;
        /// <summary>
        /// 证书
        /// </summary>
        public string Cert
        {
            get
            {
                return _cert;
            }
            set
            {
                _cert = value;
            }
        }

        /////////////////////////////////////////

        Dao_Base _dao = null;
        protected override Dao_Base dao
        {
            get
            {
                if( _dao == null )
                {
                    _dao = new AW_Import_dao();
                }
                return _dao;
            }
        }

        public static AW_Import_bean funcGetByID( string id )
        {
            AW_Import_bean bean = new AW_Import_bean();
            return bean.funcGetDataByID( id ) ? bean : null;
        }

        public static AW_Import_bean funcGetByID( int id )
        {
            AW_Import_bean bean = new AW_Import_bean();
            return bean.funcGetDataByID( id ) ? bean : null;
        }

        public static AW_Import_bean funcGetByID( string id, string columns )
        {
            AW_Import_bean bean = new AW_Import_bean();
            return bean.funcGetDataByID( id, columns ) ? bean : null;
        }

        public static AW_Import_bean funcGetByID( int id, string columns )
        {
            AW_Import_bean bean = new AW_Import_bean();
            return bean.funcGetDataByID( id, columns ) ? bean : null;
        }
        /////////////////////////////////////////
																							
    }
}
