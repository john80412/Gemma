//window.onscroll = function () { Wave() };

//function Wave() {
//    if (document.body.scrollTop > 50 || document.documentElement.scrollTop > 50) {
//        document.getElementByClass("header-nav").className = "wave";
//    } else {
//        document.getElementByClass("header-nav").className = "";
//    }
//}

//$(function () {

//    $('#sticky').scroll(

//        function () //頁面往下滑的NAV變化
//        {
//            if (window.pageYOffset > 50) { 
//                $(this).css("height", "500px").css("background-color","black");
//            };
//        },
        
//    );

//});


//function {
//    if (window.pageYOffset > 50) {
//        document.querySelector(".header-nav").classList.add("sticky");
//    }

//    if (window.pageYOffset < 50) {
//        document.querySelector(".header-nav").classList.remove("sticky");
//    }
//}
//});



//$(function () { 

//    var nav = document.querySelector("div");
//    var navclass = document.getElementsByClassName("header-nav");
//    var topofnav = nav.offsetTop;

//        function()
//    {

//    {
//        $(this).css("", "");
//        $(this).css("", "");

//    if (window.scrollY >= topOfNav) {

//    }

//    else {

//    }

//    }
//});


window.onscroll = function () { myFunction() };

var navbar = document.getElementById("sticky");

var sticky = navbar.offsetTop;

function myFunction() {
    if (window.pageYOffset >= sticky) {
        navbar.classList.add("navsticky")
    } else {
        navbar.classList.remove("navsticky");
    }
}