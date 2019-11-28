
    var CarouselImg = new Array("Img01.jpg", "Img02.jpg", "Img03.jpg", "Img04.jpg");

    var i=1;

    setInterval(ImgCarouseling, 3500);
        function ImgCarouseling(){
            document.getElementById("Carouseldiv").innerHTML = "<img src='/Assets/images/HomePage/" + CarouselImg[i] + "'>";
    i++;
            if (i >= CarouselImg.length) {i = 0; };
}
