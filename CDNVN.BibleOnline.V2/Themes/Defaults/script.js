
$('.home-control-menu a:not(.main)').hide();

$('.home-control-menu a:not(.main)').on("click", function(){
	$('.home-control-menu a:not(.main)').slideUp();
	$('.home-control-menu a.main').transition({ rotate: '0deg', background: "#096DC9", opacity:0.5 });
});

$('.home-control-menu a.main').on("click", function(){

	if($('.home-control-menu a:not(.main)').is(":hidden"))
	{
		$('.home-control-menu a:not(.main)').slideDown();
		$(this).transition({ rotate: '225deg', background: "red",opacity:1 });
	} else
	{
		$('.home-control-menu a:not(.main)').slideUp();
		$(this).transition({ rotate: '0deg', background: "#096DC9", opacity:0.5 });
	}
	
	return false;
});

$(document).ready(function(){
	//gọi popover Đọc Kinh Thánh khi focus textbox tìm kiếm
    $("[data-toggle=popover]").popover({html:true })
    function autoPlacement(){
    	var w = $(document).width()+2;
    	if(w < 768)
    		return "top";
    	return "bottom";
    }
    $("[data-toggle=tooltip]").tooltip();

    

    //event chọn tab books khi click vào popover Kinh Thánh
    $('#bible-choose-modal').on('shown.bs.modal', function () {
	  $("#bible-choose-tab a:first").tab('show');
	})

	$('.nav-bar-modal').on('click', function(){
		
	});


    $('.book-list a').on("click",function(){
    	var chapters = $(this).parent().data("chapters");
    	var name = $(this).text();

    	//html chapters tab
    	var html = '<div class="chapter-list row">';
    	for (var i = 1; i <= chapters; i++) {
    		html += '<a href="http://kinhthanh.cdnvn.com/doc-kinh-thanh/btt?q='+name+" "+i+'" >'+i+'</a>';
    	};
    	html += '</div>';

    	$("#chapters").html(html);

    	//show chapters tab
    	$("#bible-choose-tab a:last").tab('show');
    	return false;
    });
});


//tab
$(".nav-tabs").on("click", "a", function (e) {
        e.preventDefault();
        if (!$(this).hasClass('add-contact')) {
            $(this).tab('show');
        }
    })
    .on("click", "span.glyphicon-remove", function () {
        var anchor = $(this).siblings('a');
        $(anchor.attr('href')).remove();
        $(this).parent().remove();
        $(".nav-tabs li").children('a').first().click();
    });

var a = "Lorem ipsum dolor sit amet, ex malis concludaturque vix, cu usu solet gloriatur definitiones, in blandit vituperata delicatissimi est. In iusto phaedrum mei. Id tamquam accusata neglegentur pri. Impedit constituam te vim, velit meliore consulatu in est, sonet atomorum at mea. Ludus utinam nam ne, ad est cotidieque theophrastus. Euismod adolescens conclusionemque pro ne, ad eos nibh volutpat, accumsan ocurreret ut eum. Has et reque intellegebat, oratio possit lucilius est ea.";

$('.add-contact').click(function (e) {
    e.preventDefault();
    var id = $(".nav-tabs").children().length; //think about it ;)
    var tabId = 'contact_' + id;
    $(this).closest('li').before('<li><a href="#contact_' + id + '">New Tab<span class="remove glyphicon glyphicon-remove"></span></a></li>');
    $('.tab-content').append('<div class="tab-pane" id="' + tabId + '">Contact Form: New Contact ' + id + a + '</div>');
   $('.nav-tabs li:nth-child(' + id + ') a').click();
});
//http://www.desktopwallpaperhd.net/wallpapers/19/a/nature-wallpaper-background-green-bender-190218.jpg