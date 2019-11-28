
$(function () {
    $('.Collection-Picture img').hover(function () {
        // over
        $(this).css("cursor", "pointer");
        $(this).css("transform", "scale(0.8)").css("transition-duration", "0.5s");

    }, function () {
        // out
        $(this).css("transform", "scale(1)").css("transition-duration", "0.5s");

    });
});