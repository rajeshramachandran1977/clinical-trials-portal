//kendo pop up notification
var popupNotification = $("#popupNotification").kendoNotification({
    position: {
        pinned: true,
        top: 30,
        right: 30
    },
    autoHideAfter: 4000,
    stacking: "down",
}).data("kendoNotification");

//maxlength validation
$("textarea[maxlength]").keyup(function () {
    var charLength = $(this).val().length;
    var charLimit = $(this).attr("maxlength");
    $(this).nextAll("span.count").html(charLimit - charLength + " Characters left to enter");
});

//email validation
function IsEmail(email) {
    var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!regex.test(email)) {
        return false;
    } else {
        return true;
    }
}

function noOfCharactersLeft(data, id) {
    if (data !== null) {
        var charlimit = $("#" + id).attr('maxlength');
        var charlength = $('#' + id).val().length;
        $("#" + id + "_span").html(charlimit - charlength + " Characters left to enter");
    }
}

$(document).ready(function () {
    $(".floatNumberField").change(function () {
        $(this).val(parseFloat($(this).val()).toFixed(2));
    });
});