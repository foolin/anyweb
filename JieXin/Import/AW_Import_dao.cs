using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnyWell.AW_DL;
using System.Data;

namespace Import
{
    public partial class AW_Import_dao : Dao_Base
    {
        public AW_Import_dao()
        {
            this._propTable = "Chinese";
            this._propPK = "No";
            this._propFields = "";
        }

        public int funcGetCount()
        {
            this.propSelect = "COUNT(No)";
            DataSet ds = this.funcCommon();
            return ( int ) ds.Tables[ 0 ].Rows[ 0 ][ 0 ];
        }

        public List<AW_Import_bean> funcGetImportList( int pageIndex,int PageSize )
        {
            this.propSelect = "*";
            this.propPageSize = PageSize;
            this.propPage = pageIndex;
            DataSet ds = this.funcCommon();
            if( ds.Tables[ 0 ].Rows.Count > 0 )
            {
                List<AW_Import_bean> list = new List<AW_Import_bean>();
                foreach( DataRow row in ds.Tables[ 0 ].Rows )
                {
                    AW_Import_bean bean = this.funcFromDataRow( row );
                    list.Add( bean );
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public AW_Import_bean funcFromDataRow(DataRow row)
        {
            AW_Import_bean bean = new AW_Import_bean();
            bean.no = ( int ) row[ "No" ];
            bean.Name = ( string ) row[ "姓名" ];
            bean.Sex = ( string ) row[ "性别" ];
            bean.Birthday = ( string ) row[ "出生年月" ];
            bean.Address = ( string ) row[ "目前居住地" ];
            bean.Experience = ( string ) row[ "工作年限" ];
            bean.HouseAddress = ( string ) row[ "户口" ];
            bean.Salary = ( string ) row[ "目前年薪" ];
            bean.ContactAddress = ( string ) row[ "地址" ];
            bean.PostCode = ( string ) row[ "邮编" ];
            bean.Email = ( string ) row[ "电子邮件" ];
            bean.FamilyPhone = ( string ) row[ "家庭电话" ];
            bean.MobilePhone = ( string ) row[ "移动电话" ];
            bean.CompanyPhone = ( string ) row[ "公司电话" ];
            bean.ObjIntro = ( string ) row[ "自我评价" ];
            bean.ObjType = ( string ) row[ "希望工作性质" ];
            bean.ObjIndustry = ( string ) row[ "希望行业" ];
            bean.ObjAddress = ( string ) row[ "目标地点" ];
            bean.ObjSalery = ( string ) row[ "期望工资" ];
            bean.ObjFuncType = ( string ) row[ "目标职能" ];
            bean.ObjCompType = ( string ) row[ "期望公司性质" ];
            bean.Work = ( string ) row[ "工作经验" ];
            bean.Education = ( string ) row[ "教育经历" ];
            bean.Rewards = ( string ) row[ "所获奖励" ];
            bean.Language = ( string ) row[ "语言能力" ];
            bean.Skill = ( string ) row[ "IT技能" ];
            bean.Cert = ( string ) row[ "证书" ];
            return bean;
        }
    }
}
