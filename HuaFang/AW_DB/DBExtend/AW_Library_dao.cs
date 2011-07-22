using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Data;
using Studio.Web;

namespace AnyWell.AW_DL
{
    public partial class AW_Library_dao
    {
        /// <summary>
        /// 根据库名和首字母获取库列表
        /// </summary>
        /// <param name="library"></param>
        /// <param name="firstLetter"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<AW_Library_bean> funcGetLibrary(int library, int firstLetter, int pageSize, int pageIndex)
        {
            this.propSelect = "fdLibrID,fdLibrType,fdLibrName,fdLibrEnName,fdLibrFirLetter,fdLibrDesc,fdLibrSort";
            this.propOrder = "ORDER BY fdLibrID DESC";
            this.propWhere = string.Format( " fdLibrType={0} AND fdLibrFirLetter={1}", library, firstLetter );

            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            this.propGetCount = true;

            List<AW_Library_bean> list = this.funcGetList();
            return list;
        }

        /// <summary>
        /// 根据ID获取库信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AW_Library_bean funcGetLibraryItemByID(int id)
        {
            this.propSelect = "fdLibrID,fdLibrType,fdLibrName,fdLibrEnName,fdLibrFirLetter,fdLibrDesc,fdLibrSort";
            this.propWhere = " fdLibrID = " + id.ToString();

            List<AW_Library_bean> list = this.funcGetList();
            return list[0];
        }
    }
}
