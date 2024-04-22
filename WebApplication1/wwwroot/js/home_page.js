



$(document).ready(() => {

    $.post("/HomePageAnimeSeasonBanner/", function (data) {
        $("#home_page_carousel").append(data);
    });

    $.post("/HomePageCarouselPartial/", function (data) {
        $("#home_page_carousel").append(data);
    });




});
