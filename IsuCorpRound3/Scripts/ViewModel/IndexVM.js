
$(function() {
    ko.applyBindings(indexVM);
    indexVM.loadReservations();

});

var indexVM = {
    Reservations: ko.observableArray([]),
    loadReservations: function() {
        var self = this;
        //Ajax Call Get All Articles
        $.ajax({
            type: "GET",
            url: "/api/reservations",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(data) {
                Refresh(data);
            },
            error: function(err) {
                alert(err.status + " : " + err.statusText);
            }
        });

    }
};

function Reservations(reservations) {
    this.Id = ko.observable(reservations.Id);
    this.FullName = ko.observable(reservations.FullName);
    this.Birthdate = ko.observable(reservations.Birthdate);
    this.Rating = ko.observable(reservations.Rating);
    this.IsFavorite = ko.observable(reservations.IsFavorite);


}

function Refresh(data) {

    indexVM.Reservations(data); //Put the response in ObservableArray
    $(".stars-default").rating("create", {
        coloron: "gold",
        onClick: function() {
            $.ajax({
                type: "PUT",
                url: "/api/reservations",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({ id: this.parents(".reservation-item").attr("id"), rating: this.attr("data-rating") }),
                success: function(data) {},
                error: function(err) {
                    alert(err.status + " : " + err.statusText);
                }
            });
        }
    });

    $(".stars-default").each(function(i, e) {
        $(this).rating("set", $(this).val());
    });
    $(".favorite").each(function(i, e) {
        setIsFavorite(e);
        $(e).click(function() {
            $(this).val(!$(this).val());
            var self = this;
            $.ajax({
                type: "PUT",
                url: "/api/reservations",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({ id: $(self).parents(".reservation-item").attr("id"), isfavorite: $(self).val() }),
                success: function() {
                    setIsFavorite(self);
                },
                error: function(err) {
                    alert(err.status + " : " + err.statusText);
                }
            });


        });

        function setIsFavorite(e) {
            heartClassName = "pull-right heart heart-gray";
            var textClassName = "text-favorite hidden-sm hidden-xs";
            if ($(e).val()) {
                heartClassName = "pull-right heart heart-red";
                textClassName = "text-muted hidden-sm hidden-xs";
            }
            $(e).children(".heart").attr("class", heartClassName);
            $(e).children("div").children("span").attr("class", textClassName);
        }
    });
    $("a.edit").each(function(i, e) {
        $(e).attr("href", "/Page/Edit/" + $(e).parents(".reservation-item").attr("id"));
    });


}