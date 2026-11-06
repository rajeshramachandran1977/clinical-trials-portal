$(document).ready(function () {
    
});


$("#btn-Submit").click(function (e) {
    var mandatoryUpload = $("#addMandatoryFile").data("kendoUpload");
    var additionalUpload = $("#uploadAdditionalfiles").data("kendoUpload");
    mandatoryUpload.upload();  
    setTimeout(function () {
        additionalUpload.upload(); 
        setTimeout(function () {
            $.ajax({
                async: false,
                type: "POST",
                url: "/MaintainanceAndMonitoring/CreateAmendmentTask",
                data: { "studyOwner": $("#LogedinUserName").val() },
                success: function (results) {
                    if (results.msgType === "Success") {

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
    }, 1000);
   
});