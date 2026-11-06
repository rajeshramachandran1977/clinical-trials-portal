var retVal = true;

$(function () {
    var validator = $("#ui_frmForgotPassword").kendoValidator().data("kendoValidator");   
    $("form").submit(function (event) {       
        document.body.style.cursor = 'wait';
        event.preventDefault();
        ValidateMandatoryFields(); 
        if (validator.validate() && retVal == true) {
            var forgotCredentials = {
                Username: $('#userName').val(),
                PrimaryEmailId: $('#email').val()
            }
            $.ajax({
                async: true,
                type: "POST",
                url: "/Login/CheckifUserNameExists/",
                cache: false,
                dataType: "json",
                data: forgotCredentials,
                success: function (results) {                    
                    if (results.msgType == "Success") {
                        popupNotification.show(results.data, "success");
                        document.body.style.cursor = 'default';
                    }
                    else                       
                        popupNotification.show(results.data, "error");
                },
                failure: function (response) {
                    popupNotification.show(systemerror, "error");
                }
            });
        }
        else {
            popupNotification.show(errorsinthepage, "error");
        }
    });
});

$("#email").blur(function () {
    email = $("#email").val().trim();
    $('#fieldemailaddr').nextAll("div.error").remove();
    if (IsEmail(email) == false) {
        $('#fieldemailaddr').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + invalidemail + '</div>');
        retVal = false;
        return false;
    }
    else {
        $('#fieldemailaddr').nextAll("div.error").remove();
        retVal = true;
        return true;
    }
});

$("#userName").blur(function () {
    userName = $("#userName").val().trim();
    if ($('#userName').val() != "") {
        $('#fieldusername').nextAll("div.error").remove();
        retVal = true;
    }
});

function ValidateMandatoryFields() {
    $('.error').remove();   
    if ($('#userName').val() === "") {
        $('#fieldusername').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + usernamerequired + '</div>');
        retVal = false;
    }
    if ($('#email').val() === "") {
        $('#fieldemailaddr').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + emailaddressrequired + '</div>');
        retVal = false;
    }
    email = $("#email").val().trim();
    if (email != "") {
        $('#fieldemailaddr').nextAll("div.error").remove();
        if (IsEmail(email) == false) {
            $('#fieldemailaddr').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + invalidemail + '</div>');
            retVal = false;
            return false;
        }
    }
}

function onCancel() {
    window.location.href = "/";
}