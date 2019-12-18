setTimeout(
    function () {
        window.addEventListener("load", function () {
            var load = document.querySelector(".loading");
            load.classList.add("hidden");
        });
    }
    , 2500
);