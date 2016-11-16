$(document)
	.ready(function () {
        $("#rateYo").rateYo({
            rating: 0,
            halfStar: true
        }).on("rateyo.set", function(e, data) {
            $("#userRating")[0].value = data.rating;
        });
    });