//SeasonList————————————————————————————————————————————————————————————SeasonList//

$(function() {
    var page = 1;
    var height = $('.SeasonList-con').height();
    var conheight = $('.SeasonList-div').height();
    var len = Math.ceil(height / conheight);
    $('.SeaList-Down').click(function() {
        if (page == len) {
            $('.SeasonList-con').animate({ top: 0 }, 300);
            page = 1;
        } else {
            $('.SeasonList-con').animate({ top: '-=' + conheight }, 300);
            page++;
        }
    });
    $('.SeaList-Up').click(function() {
        if (page == 1) {
            $('.SeasonList-con').animate({ top: '-=' + conheight * (len - 1) }, 300);
            page = len;
        } else {
            $('.SeasonList-con').animate({ top: '+=' + conheight }, 300);
            page--;
        }
    });
})


//ShowNav-search————————————————————————————————————————————————————————————ShowNav-search//
/*
$(function(){
	$(".ShowNav-search input").click(function(){
			$(this).next().show();
	}).parent().hover(function(){},function(){
		$(this).find(".ShowNav-list").fadeOut();
	})
})
*/

//Hot_Show————————————————————————————————————————————————————————————Hot_Show//
$(document).ready(function(){
	$(".Hot_Show div").each(function(){
		$(this).mousemove(function(){
			$(this).siblings("div").removeClass("HotShow-item");
			$(this).addClass("HotShow-item");
		});
	});
	$(".Hot_Show div:odd").addClass("HotShow-odd")
});

