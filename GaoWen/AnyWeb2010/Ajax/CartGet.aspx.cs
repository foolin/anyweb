using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWeb.AW_DL;

/// <summary>
/// 获取购物车信息
/// </summary>
public partial class Ajax_CartGet : ShopAjaxBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.Cookies["CART_ITEM"] != null) && (Request.Cookies["CART_ITEM"].Value != ""))
        {
            string str = Uri.UnescapeDataString(Request.Cookies["CART_ITEM"].Value);
            string[] arr = str.Split('|');
            string ids = "";
            for (int i = 0; i < arr.Length; i++)
            {
                string[] member = arr[i].Split(','); //得到成员
                string[] hash = member[0].Split(':');//分解id的key/value
                ids += hash[1] + ",";
            }
            ids = ids.Substring(0, ids.LastIndexOf(','));

            string data = "";
            using (AW_Goods_dao dao = new AW_Goods_dao())
            {
                List<AW_Goods_bean> list = dao.funcGetGoodsByIDs(ids);
                data = this.FormatData(list);//格式化数据
                Response.Write(data);
            }
        }
        else
        {
            Response.Write("");
        }
    }

    /// <summary>
    /// 格式化数据
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    private string FormatData(List<AW_Goods_bean> list)
    {
        string data = "";
        foreach (AW_Goods_bean g in list)
        {
            data += "{";
            data += "id:" + g.fdGoodID.ToString() + ",";
            data += "quantity:" + this.GetQuantity(g.fdGoodID.ToString()) + ",";
            data += "name:'" + g.fdGoodName + "',";
            
            string salePrice = "";
            if (g.fdGoodIsPromotion == 1)
            {
                salePrice = g.fdGoodPromPrice.ToString("F2");
            }
            else
            {
                salePrice = g.fdGoodSalePrice.ToString("F2");
            }
            data += "salePrice:" + salePrice + ",";
          //data += "salePrice:" + g.fdGoodSalePrice.ToString("F2") + ",";

            data += "listimage:'" + g.fdGoodListImage + "'"; 
            data += "}|";
        }
        data = data.Substring(0, data.LastIndexOf('|'));
        return data;
    }

    /// <summary>
    /// 根据id从cookie获取quantity信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private string GetQuantity(string id)
    {
        string quantity = "0";

        string str = Uri.UnescapeDataString(Request.Cookies["CART_ITEM"].Value);
        string[] arr = str.Split('|');
        for (int i = 0; i < arr.Length; i++)
        {
            //过滤"{}"
            arr[i] = arr[i].Replace("{", "");
            arr[i] = arr[i].Replace("}", "");

            string[] member = arr[i].Split(','); //得到成员
            string[] hash = member[0].Split(':');//分解id的key/value

            //找出符合id的quantity信息
            if (id == hash[1].Trim())
            {
                quantity = (member[1].Split(':'))[1];
                break;
            }
        }

        return quantity;
    }
}