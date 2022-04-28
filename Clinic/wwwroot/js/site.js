$(document).ready(function () {
    $("body").niceScroll(
        {
            cursorcolor: "#40a9ff",
            cursorwidth: "8px",
            cursorborder:"1px solid transparent"
        }
    );
    var winheight = $(window).height();
    $('header').height(winheight);
    $('header .row').height(winheight);
});
