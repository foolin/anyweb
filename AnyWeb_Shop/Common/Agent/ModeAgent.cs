using System;
using System.Collections.Generic;
using System.Text;
using Common.Common;
using System.Data;
using Studio.Data;
using System.Collections;
namespace Common.Agent
{
    public class ModeAgent:AgentBase
    {

        /// <summary>
        /// 根据类别获取商店支付或配送方式
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ArrayList GetModeByType( int type)
        {
            return GetModeByType(type, ShopInfo.ID);
        }

        /// <summary>
        /// 根据类别获取系统支付方式或配送方式
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ArrayList GetModeByType(int type,int shopid)
        {
            DataSet ds = new DataSet();
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetModeByType",
                                    this.NewParam("@Type", type),
                                    this.NewParam("@ShopID", shopid));
            }

            ArrayList list = new ArrayList();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Mode m = new Mode();
                    m.ID = (int)dr["ModeID"];
                    m.ShopID = (int)dr["ShopID"];
                    m.Title = (string)dr["Title"];
                    m.CreateAt = (DateTime)dr["CreateAt"];
                    m.Type = Convert.ToInt32(dr["Type"]);
                    m.Poundage = Convert.ToDouble(dr["Poundage"]);
                    m.MostPoundage = Convert.ToDouble(dr["MostPoundage"]);
                    m.Content = (string)dr["Content"];

                    list.Add(m);
                }
            }
            return list;
        }


        /// <summary>
        /// 获得单个配送方式或支付方式
        /// </summary>
        /// <param name="modeid"></param>
        /// <returns></returns>
        public Mode GetModeInfo(int modeid)
        {
            DataSet ds = new DataSet();
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetModeInfo",
                                    this.NewParam("@ModeID", modeid));

            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            return (new Mode(ds.Tables[0].Rows[0]));

        }

        /// <summary>
        /// 添加配送方式或支付方式
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int InsertMode(Mode m)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_InsertMode",
                                            this.NewParam("@ShopID", ShopInfo.ID),
                                            this.NewParam("@Content", m.Content),
                                            this.NewParam("@Type", m.Type),
                                            this.NewParam("@Title", m.Title),
                                            this.NewParam("@Poundage", m.Poundage),
                                            this.NewParam("@MostPoundage",m.MostPoundage));
            }
        }

        /// <summary>
        /// 修改配送方式或支付方式
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int UpdateMode(Mode m)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_UpdateMode",
                                            this.NewParam("@ModeID", m.ID),
                                            this.NewParam("@Content", m.Content),
                                            this.NewParam("@Title", m.Title),
                                            this.NewParam("@Poundage",m.Poundage),
                                            this.NewParam("@MostPoundage",m.MostPoundage));
            }
        }

        /// <summary>
        /// 删除配送或支付方式
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int DeleteMode(Mode m)
        {
            using(IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_DeleteMode",
                                            this.NewParam("@ModeID", m.ID));
            }
            
        }

    }
}
