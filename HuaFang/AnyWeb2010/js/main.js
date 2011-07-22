//PicBlack_tab！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！PicBlack_tab//
$(document).ready(function() {
	$(".PicBlack_tab").show();
	$(".PicBlack_tab li:first").addClass("active");
		
	var imageWidth = $(".PicB_win").width();
	var imageSum = $(".PicBReel img").size();
	var imageReelWidth = imageWidth * imageSum;
	
	$(".PicBReel").css({'width' : imageReelWidth});
	
	rotate = function(){	
		var triggerID = $active.attr("rel") - 1; 
		var PicBReelPosition = triggerID * imageWidth; 

		$(".PicBlack_tab li").removeClass('active'); 
		$active.addClass('active'); 
		
		$(".PicBReel").animate({ 
			left: -PicBReelPosition
		}, 300 );
	}; 
	
	rotateSwitch = function(){		
		play = setInterval(function(){ 
			$active = $('.PicBlack_tab li.active').next();
			if ( $active.length === 0) { 
				$active = $('.PicBlack_tab li:first');
			}
			rotate();
		}, 2200); 
	};
	
	rotateSwitch();
	
	$(".PicBReel a").hover(function() {
		clearInterval(play);
	}, function() {
		rotateSwitch();
	});	
	
	$(".PicBlack_tab li").click(function() {	
		$active = $(this);
		clearInterval(play);
		rotate();
		rotateSwitch();
		return false;
	});	
});


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

function navTab(id){
    $("#subNav").find("div[id^='navC_navT_']").hide();
    $("#subNav").find("#navC_navT_"+id).show();
}

//蛍�輅娉�
function addFavorites() { 
    if (document.all) {
        window.external.addFavorite(window.location, document.title);
    } else if (window.sidebar) {
        window.sidebar.addPanel(document.title, window.location, "");
    }
} 


