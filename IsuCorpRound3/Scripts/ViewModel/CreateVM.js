$(document).ready(function() {
    var validForm = false;
    var urlPath = window.location.pathname;
    var createVm = {
        Fullname: ko.observable(),
        PhoneNumber: ko.observable(),
        Description: ko.observable($("#Description")[0].value),
        Birthdate: ko.observable(),
        ContactTypeId: ko.observable(),
        ValidForm: ko.computed(function () {
            return $("#Fullname").val() === "";
        }, this),
        btnCreateArticle: function (event) {
            var data = ko.toJSON(this);
            validateForm(event);
            $.ajax({
                url: "/api/reservations",
                type: "POST",
                dataType: "json",
                data: data,
                contentType: "application/json",
                success: function(result) {
                    successMessage();
                },
                error: function(err) {
                    if (err.responseText == "success") {
                        window.location.href = urlPath + "/";
                    } else {
                        alert(err.responseText);
                    }
                },
                complete: function() {
                }
            });

        }
    };
    ko.applyBindings(createVm);
  
});


/**/