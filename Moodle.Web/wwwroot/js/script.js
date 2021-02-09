let dropdown = $("li.dropdown");
dropdown.click(function () {
    if ($(this).hasClass("open")) {
        $(this).find(".dropdown-menu").slideUp("fast");
        $(this).removeClass("open");
    } else
    {
        $(this).find(".dropdown-menu").slideDown("fast");
        $(this).toggleClass("open");
    }
});

dropdown.mouseleave(function () {
    $(this).find(".dropdown-menu").slideUp("fast");
    $(this).removeClass("open");
});

$(".navbar-toggle").click(function () {
    $(".navbar-collapse").toggleClass("collapse").slideToggle("fast");
});
