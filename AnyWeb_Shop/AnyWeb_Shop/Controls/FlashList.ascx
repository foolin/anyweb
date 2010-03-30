<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FlashList.ascx.cs" Inherits="Controls_FlashList" %>
<div class="container-images">
    <div class="slide-container" id="slide-container">
        <table id="slide-images" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <asp:Repeater ID="repFlash" runat="server">
                    <ItemTemplate>
                        <td>
                            <a href="<%#Eval("SlideLink") %>">
                                <img src="<%=ShopInfo.DataPath%>/Slide<%#Eval("SlideFile") %>" width="461" height="241" /></a>
                        </td>
                    </ItemTemplate>
                </asp:Repeater>
            </tr>
        </table>
        <ul class="num" id="idNum">
        </ul>
    </div>
</div>

<script type="text/javascript">
    
    var forEach = function(array, callback, thisObject) {
        if (array.forEach) {
            array.forEach(callback, thisObject);
        } else {
            for (var i = 0, len = array.length; i < len; i++) { callback.call(thisObject, array[i], i, array); }
        }
    }

    var st = new SlideTrans("slide-container", "slide-images", 5, { Vertical: false });


    var nums = [];
    //插入数字
    for (var i = 0, n = st._count - 1; i <= n; ) {
        (nums[i] = document.getElementById("idNum").appendChild(document.createElement("li"))).innerHTML = ++i;
    }

    forEach(nums, function(o, i) {
        o.onmouseover = function() { o.className = "on"; st.Auto = false; st.Run(i); }
        o.onmouseout = function() { o.className = ""; st.Auto = true; st.Run();}
    })

    //设置按钮样式
    st.onStart = function() {
        forEach(nums, function(o, i) { o.className = st.Index == i ? "on" : ""; })
    }

    st.Run();
</script>

