var retVal = true;

$(document).ready(function () {
    $(document).on('click', '.toggle-password', function () {
        $(this).toggleClass("fa-eye fa-eye-slash");
        var input = $('#password');
        input.attr('type') === 'password' ? input.attr('type', 'text') : input.attr('type', 'password');
    });

    $.ajax({
        type: "GET",
        url: "/Administration/GetGlobalSettingByKey",
        data: { "globalKey": LOGIN_PAGE_CONTENT },
        success: function (results) {
            if (results.Data.length > 0) {
                $("#ui_txt_bannerText").empty();
                var str = results.Data[0].GlobalValue;
                if (str !== "" && str !== null) {
                    var array = str.split("$$")
                    $.each(array, function (i, item) {
                        $("#ui_txt_bannerText").append("<div class='login_page_content text-white pb-md-1'>" + item + "</div>");
                        return i < 7;
                    });
                }
            }
        }
    });

    $.ajax({
        type: "GET",
        url: "/Administration/GetGlobalSettingByKey",
        data: { "globalKey": VerbiageForNewUser },
        success: function (results) {
            if (results.Data.length > 0) {
                $("#newUserButtonText").empty();
                var str = results.Data[0].GlobalValue;
                $("#newUserButtonText").append("<div class='login_page_content text-white pb-md-1'>" + str + "</div>");
            }
        }
    });

    $("#btnRegister").click(function () {
        window.location.href = 'Register/Register';
    });

    $.ajax({
        type: "GET",
        url: "/Dashboard/GetLoginBackground",
        data: {},
        success: function (results) {
            if (results.Status !== "Failed") {
                if (results.Data.length > 0) {
                    var imageUrl = "BannerUpload/BackgroundUpload/" + results.Data[0].DocumentName;
                    $('#LoginBackground').css("background-image", "url(" + imageUrl + ")");
                }
                else $('#LoginBackground').css("background-image", "url('/Images/LoginBackground.jpg')");
            }
            else $('#LoginBackground').css("background-image", "url('/Images/LoginBackground.jpg')");
        }
    });
});

$(function () {
    var validator = $("#frmLogin").kendoValidator().data("kendoValidator");
    $("form").submit(function (event) {
        $("#errorMsg").empty();
        event.preventDefault();
        ValidateMandatoryFields();
        if (validator.validate()) {
            var logincredentials = {
                Username: $('#userName').val(),
                Password: $('#password').val()
            }
            $.ajax({
                async: true,
                type: "POST",
                url: "../Login/CheckifCredentialsExists/",
                cache: false,
                dataType: "json",
                data: logincredentials,
                success: function (response) {
                    if (response.message == EXTERNALUSER || response.message == PI) {
                        window.location.href = "/Dashboard/PIDashboard";
                    }
                    else if (response.message == RESETPASSWORD) {
                        popupNotification.show(PASSWORDEXPIRED, "info");
                        setTimeout(redirectToChangePassword, 6000);
                    }
                    else if (response.message == IISADMIN || response.message == MSL || response.message == PROGRAMLEADER || response.message == TRIALLEADER) {
                        window.location.href = "/Dashboard/IISAdminDashboard";
                    }
                    else if (response.message == ADMIN) {
                        window.location.href = "/Dashboard/Dashboard";
                    }
                    else {
                        popupNotification.show(response.message, "error");
                    }
                },
                failure: function (response) {
                    popupNotification.show(response.message, "error");
                    popupNotification.show(SOMETHNGWENTWRONG, "error");
                }
            });
        }
        else {
        }
    });
    function redirectToChangePassword() {
        window.location.href = "/Login/ResetPassword";
    }
});


function ValidateMandatoryFields() {
    $('.error').remove();
    retVal = true;
    if ($('#userName').val() === "") {
        $('#loginUserName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + USERNAMEREQUIRED + '</div>');
        retVal = false;
    }
    if ($('#password').val() === "") {
        $('#loginPassword').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + PASSWORDEREQUIRED + '</div>');
        retVal = false;
    }
}

$('#userName').on('keyup', function () {
    $('#loginUserName').next('div.error').remove();
});
$('#password').on('keyup', function () {
    $('#loginPassword').next('div.error').remove();
});

function GetAdminEmail() {
    $.ajax({
        async: true,
        type: "GET",
        url: "/Login/GetAdminEmail/",
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response != null) {

                window.location.href = "mailto:" + response.data + "?Subject=" + FORGOTTENUSERNAMESUBJECT;
            }
            else {
                var popupNotification = $("#popupNotification").kendoNotification().data("kendoNotification");
                popupNotification.show(INVALIDUSERNAMEPASSWORD);
            }
        },
        failure: function (response) {
            popupNotification.show(response.message, "error");
            popupNotification.show(SOMETHNGWENTWRONG, "error");
        }
    });
}