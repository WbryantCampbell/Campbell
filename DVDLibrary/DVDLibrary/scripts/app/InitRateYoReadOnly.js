$(document)
	.ready(function () {

		//var rating = 0;

		$("#rateYo").rateYo({

			rating: $("#userRating").val(),
			readOnly: true
			//onInit: function () {
			//    rating = $("#userRating").value;
			//}

		});
		
	});
//$(document)
//	.ready(function () {
//	    $("#rateYo").rateYo("option", "rating", "userRating".val);

//	});


//		var rating = 5.0;

//		$(".counter").text(rating);

//		$("#rateYo").on("rateyo.init", function () { console.log("rateyo.init"); });

//		$("#rateYo").rateYo({
//			rating: rating,
//			readOnly: true,
//			numStars: 5,
//			precision: 2,
//			starWidth: "32px",
//			spacing: "5px",
//			fullStar: true,
//			//multiColor: {

//			//  startColor: "#000000",
//			//  endColor:   "#ffd700"
//			//},
//			onInit: function () {

//				console.log("On Init");
//			},
//			onSet: function () {

//				console.log("On Set");
//			}
//		}).on("rateyo.set", function () { console.log("rateyo.set"); })
//		  .on("rateyo.change", function () { console.log("rateyo.change"); });

//		$(".rateyo").rateYo();

//		$("#rateYo").click(function () {


//			$(".rateyo-readonly-widg").rateYo({

//				rating: rating,
//				numStars: 5,
//				precision: 2,
//				minValue: 1,
//				maxValue: 5
//			}).on("rateyo.change", function (e, data) {

//				console.log(data.rating);


//			});

//		});
//	});

//$("#rateYo").rateYo({ rating: 0,fullStar: true, readOnly: true, onInit: function (rating, data) {
 
//    $("#userRating").val(data.rating);}
	
//("rateyo", function (e, data) {
//	$("#userRating").val(data.rating);
	 //document.getElementById("userRating").value = data.rating
//});
