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
            //this.propWhere = "[No] IN (702)";
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
        public AW_Import_bean funcFromDataRow( DataRow row )
        {
            AW_Import_bean bean = new AW_Import_bean();
            bean.no = ( int ) row[ "No" ];
            bean.Name = row[ "姓名" ] == DBNull.Value ? "" : ( string ) row[ "姓名" ];
            bean.Sex = row[ "性别" ] == DBNull.Value ? "" : ( string ) row[ "性别" ];
            bean.Birthday = row[ "出生年月" ] == DBNull.Value ? "" : ( string ) row[ "出生年月" ];
            bean.Address = row[ "目前居住地" ] == DBNull.Value ? "" : ( string ) row[ "目前居住地" ];
            bean.Experience = row[ "工作年限" ] == DBNull.Value ? "" : ( string ) row[ "工作年限" ];
            bean.HouseAddress = row[ "户口" ] == DBNull.Value ? "" : ( string ) row[ "户口" ];
            bean.Salary = row[ "目前年薪" ] == DBNull.Value ? "" : ( string ) row[ "目前年薪" ];
            bean.ContactAddress = row[ "地址" ] == DBNull.Value ? "" : ( string ) row[ "地址" ];
            bean.PostCode = row[ "邮编" ] == DBNull.Value ? "" : ( string ) row[ "邮编" ];
            bean.Email = row[ "电子邮件" ] == DBNull.Value ? "" : ( string ) row[ "电子邮件" ];
            bean.FamilyPhone = row[ "家庭电话" ] == DBNull.Value ? "" : ( string ) row[ "家庭电话" ];
            bean.MobilePhone = row[ "移动电话" ] == DBNull.Value ? "" : ( string ) row[ "移动电话" ];
            bean.CompanyPhone = row[ "公司电话" ] == DBNull.Value ? "" : ( string ) row[ "公司电话" ];
            bean.ObjIntro = row[ "自我评价" ] == DBNull.Value ? "" : ( string ) row[ "自我评价" ];
            bean.ObjType = row[ "希望工作性质" ] == DBNull.Value ? "" : ( string ) row[ "希望工作性质" ];
            bean.ObjIndustry = row[ "希望行业" ] == DBNull.Value ? "" : ( string ) row[ "希望行业" ];
            bean.ObjAddress = row[ "目标地点" ] == DBNull.Value ? "" : ( string ) row[ "目标地点" ];
            bean.ObjSalery = row[ "期望工资" ] == DBNull.Value ? "" : ( string ) row[ "期望工资" ];
            bean.ObjFuncType = row[ "目标职能" ] == DBNull.Value ? "" : ( string ) row[ "目标职能" ];
            bean.ObjCompType = row[ "期望公司性质" ] == DBNull.Value ? "" : ( string ) row[ "期望公司性质" ];
            bean.Work = row[ "工作经验" ] == DBNull.Value ? "" : ( string ) row[ "工作经验" ];
            bean.Education = row[ "教育经历" ] == DBNull.Value ? "" : ( string ) row[ "教育经历" ];
            bean.Rewards = row[ "所获奖励" ] == DBNull.Value ? "" : ( string ) row[ "所获奖励" ];
            bean.Language = row[ "语言能力" ] == DBNull.Value ? "" : ( string ) row[ "语言能力" ];
            bean.Skill = row[ "IT技能" ] == DBNull.Value ? "" : ( string ) row[ "IT技能" ];
            bean.Cert = row[ "证书" ] == DBNull.Value ? "" : ( string ) row[ "证书" ];
            return bean;
        }
    }
}
