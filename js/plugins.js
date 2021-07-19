$(document).ready(function () {
	//nice scroll
	$("html").niceScroll();

	//caching scroll top
	var scrollButton = $("#scroll-top");
	$(window).scroll(function () {
		if ($(this).scrollTop() >= 1000)
			scrollButton.show();
		else
			scrollButton.hide();
	});

	//click on button to scroll top
	scrollButton.click(function () {
		$("html,body").animate({ scrollTop: 0 }, 600);
	});

	//if add to cart true
	$('.hasAdded').click(function () {
		alert("you Added It before");
	});

	//click
	$('.addCart').click(function() {
		var add = document.querySelector('.num').value;
		return add;
	});
});


//loading screen
$(window).load(function () {
	$(".loading .spinner").fadeOut(1000,
		function () {
			//show scroll
			$("body").css("overflow", "auto");
			$(this).parent().fadeOut(1000,
				function () {
					$(this).remove();
				});
		});
});
