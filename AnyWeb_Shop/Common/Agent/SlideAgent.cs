using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

using Studio.Data;

using Common.Framework;
using Common.Common;
using System.Collections;
using Studio.Web;
using System.Web;
using System.IO;
using Studio.IO;

namespace Common.Agent
{
    public  class SlideAgent:AgentBase
    {
        /// <summary>
        /// 获得幻灯列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetSlideList()
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
               ds= db.GetDataSet( CommandType.StoredProcedure , "Shop_GetSlideList" ,
                                this.NewParam( "@ShopID" , ShopInfo.ID ) );
            }
            ArrayList list = new ArrayList();
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                list.Add( new Slide( dr ) );
            }
            return list;
        }

        /// <summary>
        /// 删除幻灯
        /// </summary>
        /// <param name="slideID"></param>
        /// <returns></returns>
        public int SlideDelete(int slideID)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
              return   db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_SlideDelete" ,
                                    this.NewParam( "@SlideID" , slideID ) );
            }
        }

        /// <summary>
        /// 删除所有幻灯
        /// </summary>
        public void SlideDeleteAll()
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                 db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_SlideDeleteAll" ,
                                      this.NewParam( "@ShopID" ,ShopInfo.ID ) );
            }
        }

        /// <summary>
        /// 编辑幻灯片
        /// </summary>
        /// <param name="slideList"></param>
        /// <returns></returns>
        public int SlideEdit(ObjectList slideList)
        {
            this.SlideDeleteAll();
            int value = 0;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                foreach ( Slide sd in slideList )
                {
                   value= db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_SlideAdd" ,
                                        this.NewParam( "@SlideFile" , sd.SlideFile ) ,
                                        this.NewParam( "@SlideLink" , sd.SlideLink ) ,
                                        this.NewParam( "@Sort" , sd.Sort ) ,
                                        this.NewParam( "@ShopID" , ShopInfo.ID ) );
                }
                return value;
            }

        }


    }
}
