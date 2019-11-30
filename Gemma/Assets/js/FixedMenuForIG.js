$('.instagram-list img').hover(

    function () //over
    {
        //opacity 為透明度
        $('.instagram-list img').css("opacity", "0.3");//Other Img
        
        $(this).css("opacity", "1");//Pointing Img
    },
    function () //out
    {

        $('.instagram-list img').css("opacity", "1");
    }
);