$(document).ready(function() {
   
    var urlPath = window.location.pathname;
    var editVm = {
        Id: ko.observable($("#Id").val()),
        Fullname: ko.observable($("#Fullname").val()),
        PhoneNumber: ko.observable($("#PhoneNumber").val()),
        Description: ko.observable($("#Description").val()),
        Birthdate: ko.observable($("#Birthdate").val()),
        ContactTypeId: ko.observable($("#ContactTypeId").val()),
       
        btnCreateArticle: function () {
            var data = ko.toJSON(this);
            $.ajax({
                url: "/api/reservations",
                type: "PUT",
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
    ko.applyBindings(editVm);
  
});


/**/