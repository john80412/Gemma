$(function () {

    //img.hover
    $('.collection-item').hover(

        function () //滑鼠移過去做的事
        {
            $(this).css("cursor", "pointer");
            $(this).css("transform", "scale(0.8)").css("transition-duration", "0.5s"); //放大與變形時間

        },
        function () //滑鼠移出做的事
        {
            $(this).css("transform", "scale(1)").css("transition-duration", "0.5s");
        }
    );

    $('.collection-item img').hover(

        function () //滑鼠移過去做的事
        {

            $('.collection-item img').css("opacity", "0.3");
            $(this).css("opacity", "1");
        },
        function () //滑鼠移出做的事
        {

            $('.collection-item img').css("opacity", "1");
        }
    );

    $('a').click(
        function ()
        {
            $('img').css("opacity", "1");
        },
    );  

});