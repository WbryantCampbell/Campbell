$(document)
    .ready(function () {
        var $anchor = $('.rateYo')
        $anchor.each(function () {
            $(this).rateYo({
                rating: $(this).attr("data-rating"),
                readOnly: true
            });
        })    
});
