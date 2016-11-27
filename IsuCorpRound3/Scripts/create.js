$(document).ready(function() {

   $("#Birthdate").datepicker({ format: "dd/mm/yyyy" });
   var s = $("#Birthdate");
   $("#Birthdate").change(validateForm);
   $("#Fullname").keyup(validateForm);

    $("#Description").Editor();
    $('#Description').Editor('setText', $('#Description').val());
   $(".Editor-container").mouseleave(function () {
        var v = $(".Editor-editor").html();
        $("#Description").val(v);
        $("#Description").change();
    });

    $("#Birthdate").keypress(function(event) {
        event.preventDefault();

    });

    $("#PhoneNumber").keypress(function(event) {
        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 || // Allow: backspace, delete, tab, escape, and enter
        (event.keyCode == 65 && event.ctrlKey === true) || // Allow: Ctrl+A
        (event.keyCode == 67 && event.ctrlKey === true) || // Allow: Ctrl+C
        (event.keyCode == 86 && event.ctrlKey === true) || // Allow: Ctrl+C
        (event.keyCode >= 35 && event.keyCode < 39)) // Allow: home, end, left, right
        {
            return; // let it happen, don't do anything
        } else {
            if (event.shiftKey || (event.charCode < 48 || event.charCode > 57) && (event.charCode < 96 || event.charCode >= 97)) { // Ensure that it is a number and stop the keypress
                event.preventDefault();
            }
        }
    });

});

function successMessage() {
    $('<div class="alert alert-success alert-dismissable"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>Well done! Your reservation was submitted.</div>').insertAfter("#header");
}

function validateForm() {
    valid = true;
    if ($("#Birthdate").val() === "") {
        $("#Birthdate").parent().attr("class", "col-md-2 has-error");
        valid = false;
    } else {
        $("#Birthdate").parent().attr("class", "col-md-2 has-success");
    }
    if ($("#Fullname").val() === "") {
        $("#Fullname").parent().attr("class", "col-md-3 has-error");
        valid = false;
    } else
        $("#Fullname").parent().attr("class", "col-md-3 has-success");


    if (!valid)
        $("#Submit").attr("disabled", "disabled");
    else
        $("#Submit").attr("disabled", null);
}