using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using System.Data;
using System.Collections;

namespace AnyWeb.AnyWeb_DL
{
    public class PhotoAgent : DbAgent
    {
        public PhotoAgent() : base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }

        /// <summary>
        /// 获取图片列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public ArrayList GetPhotoList(int PageSize, int PageIndex, out int RecordCount)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 4, true);
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetPhotoList",
                    this.NewParam("@PageSize", PageSize),
                    this.NewParam("@PageNo", PageIndex),
                    record);
                RecordCount = (int)record.Value;
            }
            ArrayList list = new ArrayList();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Photo phot = new Photo(row);
                list.Add(phot);
            }
            return list;
        }

        /// <summary>
        /// 获取图片信息
        /// </summary>
        /// <param name="PhotID"></param>
        /// <returns></returns>
        public Photo GetPhotoInfo(int PhotID)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetPhotoInfo",
                    this.NewParam("@PhotID", PhotID));
            }
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
            {
                Photo phot = new Photo(ds.Tables[0].Rows[0]);
                return phot;
            }
        }

        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="phot"></param>
        /// <returns></returns>
        public bool AddPhoto(Photo phot)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "AddPhoto",
                    this.NewParam("@PhotName", phot.PhotName),
                    this.NewParam("@PhotUrl", phot.PhotUrl),
                    this.NewParam("@PhotPath", phot.PhotPath),
                    this.NewParam("@PhotOrder", phot.PhotOrder),
                    this.NewParam("@PhotUploadAt", phot.PhotUploadAt)) > 0;
            }
        }

        /// <summary>
        /// 更新图片信息
        /// </summary>
        /// <param name="phot"></param>
        /// <returns></returns>
        public int UpdatePhotoInfo(Photo phot)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "UpdatePhotoInfo",
                    this.NewParam("@PhotID", phot.PhotID),
                    this.NewParam("@PhotName", phot.PhotName),
                    this.NewParam("@PhotUrl", phot.PhotUrl),
                    this.NewParam("@PhotPath", phot.PhotPath),
                    this.NewParam("@PhotOrder", phot.PhotOrder),
                    this.NewParam("@PhotUploadAt", phot.PhotUploadAt));
            }
        }

        /// <summary>
        /// 删除图片信息
        /// </summary>
        /// <param name="PhotID"></param>
        /// <returns></returns>
        public int DeletePhoto(int PhotID)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "DeletePhoto",
                    this.NewParam("@PhotID", PhotID));
            }
        }

        /// <summary>
        /// 前台获取图片
        /// </summary>
        /// <returns></returns>
        public List<Photo> GetPhotoListByWeb()
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetPhotoListByWeb");
            }
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
            {
                List<Photo> list = new List<Photo>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Photo pt = new Photo(row);
                    list.Add(pt);
                }
                return list;
            }
        }
    }
}
