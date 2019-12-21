
//function sticky() {
//    if (window.pageYOffset > 100) {
//        document.querySelector(".header").classList.remove("fixed-2");
//        document.querySelector(".logo").classList.remove("photoanimation-2");

//        document.querySelector(".header").classList.add("fixed");
//        document.querySelector(".logo").classList.add("photoanimation");
//    }
//    if (window.pageYOffset < 100) {
//        document.querySelector(".header").classList.remove("fixed");
//        document.querySelector(".logo").classList.remove("photoanimation");

//        document.querySelector(".header").classList.add("fixed-2");
//        document.querySelector(".logo").classList.add("photoanimation-2");
//    }


//}


var lastScrollY = 0;
function sticky() {

    var nowscroll = this.scrollY;

    if (nowscroll > lastScrollY) {
        document.querySelector(".header").classList.remove("fixed-2");
        document.querySelector(".logo img").classList.remove("photoanimation-2");

        document.querySelector(".header").classList.add("fixed");
        document.querySelector(".logo img").classList.add("photoanimation");
    } else {
        document.querySelector(".header").classList.remove("fixed");
        document.querySelector(".logo img").classList.remove("photoanimation");

        document.querySelector(".header").classList.add("fixed-2");
        document.querySelector(".logo img").classList.add("photoanimation-2");
    }

    lastScrollY = nowscroll;

};
