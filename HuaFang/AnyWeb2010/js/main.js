//Unfold！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！Unfold//
$(document).ready(function(){
	$(".Unfold").click(function(){
		$(this).hide();
		$(".Packup").show();
		$(this).parent().next().addClass("PhoGal_unfold");
	});
	$(".Packup").click(function(){
		$(this).hide();
		$(".Unfold").show();
		$(this).parent().next().toggleClass("PhoGal_unfold");
	});
});

//OtherHot_list！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！OtherHot_list//
$(document).ready(function(){
	$(".OtherHot div").each(function(){
		$(this).mousemove(function(){
			$(this).siblings("div").removeClass("OtherHot-yes");
			$(this).addClass("OtherHot-yes");
		});
	});
});



//Pho_Gallery_tab！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！Pho_Gallery_tab//
//$(function(){
//	var tabTitle = ".Pho_Gallery_tab .PhoG_Tabtit p";
//	var tabContent = ".Pho_Gallery_tab .PhoGal_mod .PhoGal_list";
//	$(tabTitle + ":first").addClass("on");
//	$(tabContent).not(":first").hide();
//	$(tabTitle).unbind("click").bind("click", function(){
//		$(this).siblings("p").removeClass("on").end().addClass("on");
//		var index = $(tabTitle).index( $(this) );
//		$(tabContent).eq(index).siblings(tabContent).hide().end().fadeIn(0);
//   });
//});

//蛍�輅娉�
function addFavorites() { 
    if (document.all) {
        window.external.addFavorite(window.location, document.title);
    } else if (window.sidebar) {
        window.sidebar.addPanel(document.title, window.location, "");
    }
} 


