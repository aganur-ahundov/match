$(document).ready(function () {

    $("tr.mainBets").click(function () {
        var adds = $(this).next("tr.addBetsHead");
        var addsValues = adds.next("tr.addBetsValues");

        $(this).hasClass("selected") ? $(this).removeClass("selected") : $(this).addClass("selected");
        adds.hasClass("hidden") ? adds.removeClass("hidden") : adds.addClass("hidden");
        addsValues.hasClass("hidden") ? addsValues.removeClass("hidden") : addsValues.addClass("hidden");
    });
});