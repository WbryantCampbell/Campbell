$(document)
	.ready(function () {
		$(".hidediv1").hide();
		$(".hidediv2").hide();
		$("#addActor2").click(function () {
			$(".hidediv1").show();
		$("#addActor3").click(function () {
		    $(".hidediv2").show();
		    })
	});
		});