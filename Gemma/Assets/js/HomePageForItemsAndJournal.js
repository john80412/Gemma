$(function () {
    $('.imageRow img').hover(function () {
        // over
        $(this).css("cursor", "pointer");
        $(this).css("transform", "scale(0.8)").css("transition-duration", "0.5s");

    }, function () {
        // out
        $(this).css("transform", "scale(1)").css("transition-duration", "0.5s");

    });


    $('.Journal-Picture img').hover(

        function () //over
        {
            //opacity 為透明度
            $('.Journal-Picture img').css("opacity", "0.3");//Other Img

            $(this).css("opacity", "1");//Pointing Img
        },
        function () //out
        {

            $('.Journal-Picture img').css("opacity", "1");
        }
    );
});