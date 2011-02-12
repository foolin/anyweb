using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Order_bean
	{
        private List<AW_Order_Item_bean> _items;
        /// <summary>
        /// 订单明细
        /// </summary>
        public List<AW_Order_Item_bean> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        private AW_Member_bean _member;
        /// <summary>
        /// 会员信息
        /// </summary>
        public AW_Member_bean Member
        {
            get { return _member; }
            set { _member = value; }
        }

        private string _payMode;
        /// <summary>
        /// 支付方式
        /// </summary>
        public string PayMode
        {
            get
            {
                switch (this.fdOrdePayModeID)
                {
                    case 1:
                        _payMode = "支付宝";
                        break;
                    case 2:
                        _payMode = "网银在线支付";
                        break;
                    case 3:
                        _payMode = "银行转帐/电汇";
                        break;
                    case 4:
                        _payMode = "货到付款";
                        break;
                    case 5:
                        _payMode = "自提";
                        break;
                }
                return _payMode;
            }
        }

        private string _status;
        /// <summary>
        /// 订单状态
        /// </summary>
        public string Status
        {
            get
            {
                switch (this.fdOrdeStatus)
                {
                    case 1:
                        _status = "新增待支付";
                        break;
                    case 2:
                        _status = "已支付待发货";
                        break;
                    case 3:
                        _status = "已发货待确认";
                        break;
                    case 4:
                        _status = "已确认完成";
                        break;
                    case 5:
                        _status = "缺货登记";
                        break;
                    case 6:
                        _status = "用户取消";
                        break;
                    case 7:
                        _status = "测试无效";
                        break;
                }
                return _status;
            }
        }

        private string _deliverMode;
        /// <summary>
        /// 配送方式
        /// </summary>
        public string DeliverMode
        {
            get
            {
                switch (this.fdOrdeDeliverModeID)
                {
                    case 1:
                        _deliverMode = "平邮";
                        break;
                    case 2:
                        _deliverMode = "快递";
                        break;
                    case 3:
                        _deliverMode = "EMS";
                        break;
                    case 4:
                        _deliverMode = "自提";
                        break;
                    case 5:
                        _deliverMode = "配送";
                        break;
                }
                return _deliverMode;
            }
        }

        /// <summary>
        /// 支付日期
        /// </summary>
        public string PayAtDate
        {
            get { return this.fdOrdePayAt.Date.ToShortDateString(); }
        }

        public string DeliverDate
        {
            get { return this.fdOrdeDeliverTime.ToShortDateString(); }
        }
	}
}
