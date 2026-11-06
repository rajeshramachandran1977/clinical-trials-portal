
function onCancel() {    
    
}
$(document).ready(function () {
    $('#submitActivationDocs').hide();    
});

$("#btn-Submit").click(function (e) {
    $(".k-upload-selected").click();
    setTimeout(function () {
        $.ajax({
            async: false,
            type: "POST",
            url: "/MaintainanceAndMonitoring/SaveActivatedUpdateDocuments",
            data: { "studyOwner": $("#LogedinUserName").val() },
            success: function (results) {
                if (results.msgType === "Success") {
                    var lsmailParameter = new Array();
                    var appUrl = $(location)[0].origin;
                    var StudyURL = "<a href='" + appUrl + "'> Navigate</a>";
                    lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                    lsmailParameter.push(StudyURL);
                    $.ajax({
                        async: false,
                        type: "POST",
                        url: "/Common/SendEmail/",
                        cache: false,
                        data: { "mailMessage": "Review Additional doucment", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $("#LogedinUserName").val(), "ccMail": " " },
                        dataType: "json",
                        success: function (results) {
                            popupNotification.show('Email Sent Successfully', "success");
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            popupNotification.show('Sending Email Failed', "error");
                        }
                    });
                    window.close();
                }
                else {
                    popupNotification.show(results.msgType, "error");
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                popupNotification.show('Error', "error");
            }
        });     
    }, 1000);
    
    
});
