using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using System.Data;
using System.Collections;
using System.Web;

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
        /// <param name="CateID"></param>
        /// <returns></returns>
        public ArrayList GetPhotoList(int CateID, int PageSize, int PageIndex, out int RecordCount)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 4, true);
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetPhotoList",
                    this.NewParam("@CateID", CateID),
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
                bool result = db.ExecuteNonQuery(CommandType.StoredProcedure, "AddPhoto",
                    this.NewParam("@PhotName", phot.PhotName),
                    this.NewParam("@CateID", phot.PhotCateID),
                    this.NewParam("@PhotUrl", phot.PhotUrl),
                    this.NewParam("@PhotPath", phot.PhotPath),
                    this.NewParam("@PhotOrder", phot.PhotOrder),
                    this.NewParam("@PhotUploadAt", phot.PhotUploadAt)) > 0;
                this.clearCache();
                return result;
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
                int result = db.ExecuteNonQuery(CommandType.StoredProcedure, "UpdatePhotoInfo",
                    this.NewParam("@PhotID", phot.PhotID),
                    this.NewParam("@PhotName", phot.PhotName),
                    this.NewParam("@CateID", phot.PhotCateID),
                    this.NewParam("@PhotUrl", phot.PhotUrl),
                    this.NewParam("@PhotPath", phot.PhotPath),
                    this.NewParam("@PhotOrder", phot.PhotOrder),
                    this.NewParam("@PhotUploadAt", phot.PhotUploadAt));
                this.clearCache();
                return result;
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
                int result = db.ExecuteNonQuery(CommandType.StoredProcedure, "DeletePhoto",
                    this.NewParam("@PhotID", PhotID));
                this.clearCache();
                return result;
            }
        }

        /// <summary>
        /// 前台获取图片
        /// </summary>
        /// <returns></returns>
        public List<Photo> GetPhotoListByWeb()
        {
            List<Photo> list = (List<Photo>)HttpRuntime.Cache["PHOTO"];
            if (list != null)
                return list;
            list = new List<Photo>();
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetPhotoListByWeb");
            }
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Photo pt = new Photo(row);
                list.Add(pt);
            }
            HttpRuntime.Cache.Insert("PHOTO", list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(5));
            return list;
        }

        /// <summary>
        /// 前台根据类别获取图片
        /// </summary>
        /// <param name="cateID"></param>
        /// <returns></returns>
        public List<Photo> getPhotoListByCateID(int cateID) 
        {
            List<Photo> list = this.GetPhotoListByWeb();
            List<Photo> photoList = new List<Photo>();
            foreach (Photo photo in list)
            {
                if (photo.PhotCateID == cateID)
                {
                    photoList.Add(photo);
                }
            }
            return photoList;
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        public void clearCache() 
        {
            if (HttpRuntime.Cache["PHOTO"] != null)
            {
                HttpRuntime.Cache.Remove("PHOTO");
            }
        }
    }
}
