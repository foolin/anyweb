using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using AnyWeb.AW_DL;
using Studio.Web;

/// <summary>
/// 一个会员对一个商品只能收藏一次，收藏成功收藏更新商品收藏数，并提示收藏人数
/// </summary>
public partial class Ajax_GoodsFavorite : ShopAjaxBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AW_Member_bean member = (new AW_Member_dao()).funcGetMemberFromCookie();
        if(member == null)  ExecuteFalse(2,"请先登录");

        AW_Goods_bean goods = null;
        if( QS("id") != "" && WebAgent.IsInt32(QS("id")))
            goods = (new AW_Goods_dao()).funcGetGoodsAjaxInfo(int.Parse(QS("id")));

        if (goods == null)
        {
            ExecuteFalse(2,"商品不存在");
        }
        else if((new AW_Favorite_dao()).funcCheckMemberHasFavGoods(goods.fdGoodID, member.fdMembID))
        {
            ExecuteFalse(3,"您已经收藏过该商品");
        }
        else
        {
            using(AW_Favorite_dao dao = new AW_Favorite_dao())
            {
                AW_Favorite_bean fav = new AW_Favorite_bean();
                fav.fdFavoCreateAt = DateTime.Now;
                fav.fdFavoID = dao.funcNewID();
                fav.fdFavoMemberID = member.fdMembID;
                fav.fdFavoGoodsID = goods.fdGoodID;
                dao.funcInsert(fav);
            }
            using(AW_Goods_dao dao = new AW_Goods_dao())
            {
                dao.funcAddGoodsFavCount(goods.fdGoodID);
            }
            ExecuteSucc("收藏成功");
        }

    }
}
