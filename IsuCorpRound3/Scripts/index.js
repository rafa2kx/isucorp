var page = 1;
$(document).ready(function() {
    $("#orderType").change(function(e) {
        getReservations();
    });

    $(".pagination > .page").click(function() {
        $(".pagination > .page").attr("class", "page");
        $(this).attr("class", "active page");
        page = $(this).text();
        var t = $(".pagination > .first");
        if (page > 1)
            $(".pagination > .first").attr("class","first");
        else {
            $(".pagination > .first").attr("class", "first disabled");
        }

        if (page < $(".pagination > .page").length)
            $(".pagination > .last").attr("class","last");
        else {
            $(".pagination > .last").attr("class", "last disabled");
        }
        getReservations();
    });

    $(".pagination > .first").click(function () {
        $(".pagination > #page_1").click();
       
    });
    $(".pagination > .last").click(function () {
        var lastId = "page_" + $(".pagination > .page").length;
        $(".pagination > #" + lastId).click();
    });

});

function getReservations() {
    var sortBy = $("#orderType option:selected").val();
    $.ajax({
        type: "GET",
        url: "/api/reservations",
        contentType: "application/json; charset=utf-8",
        data: { sortBy: sortBy, page: page },
        success: function(data) {
            Refresh(data);
        },
        error: function(err) {
            alert(err.status + " : " + err.statusText);
        }
    });
}