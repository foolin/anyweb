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
	public partial class AW_Goods_Comment_bean
	{
        private AW_Goods_bean _goods;
        /// <summary>
        /// 评论的商品
        /// </summary>
        public AW_Goods_bean Goods
        {
            get { return _goods; }
            set { _goods = value; }
        }

        private AW_Member_bean _member;
        /// <summary>
        /// 会员
        /// </summary>
        public AW_Member_bean Member
        {
            get { return _member; }
            set { _member = value; }
        }

        public string funcToJosn()
        {
            return String.Format("[{0},{1},{2},\"{3}\",{4},\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\"]", 
                this.fdCommID, //0
                this.fdCommGoodsID,//1 
                this.fdCommMemberID, //2
                this.fdCommUserName.Replace("\"", "\\\"").Replace("\n", "<br/>"),//3
                this.fdCommScore, //4
                this.fdCommIP.Replace("\"", "\\\"").Replace("\n","<br/>"), //5
                this.fdCommCreateAt.ToString("yyyy-MM-dd HH:mm"),//6
                this.fdCommContent.Replace("\"", "\\\"").Replace("\n", "<br/>"),//7
                this.fdCommArea.Replace("\"", "\\\"").Replace("\n", "<br/>"),//8
                this.fdCommReply.Replace("\"", "\\\"").Replace("\n", "<br/>"),//9
                this.fdCommReplyAt.ToString("yyyy-MM-dd HH:mm")//10
                );
        }
	

	}
}
