function onCancel() {
    window.close();
}

$(document).ready(function () {
    $('.studyProfileUpdates').hide();

    var retVal = true;
    var TaskName = $('#TaskName').val();

    //Task “SAE Final Reconciliation Report Confirmation”
    if (TaskName === "SAE Final Reconciliation Report Confirmation") {
        $('#submissionSummary').hide();
        $('#studyProfile').hide();
    }

    //Task “Review Rejection for Amendment” (conditional)
    if (TaskName === "Review Rejection for Amendment") {
        $('#taskHeading').text("Review Rejection for Amendment");
        $('#piPanel').text("Please indicate if all reasons for rejection have been discussed with the Investigator.");
        $('#checkboxLabel').text("Reasons for rejection have been addressed");
    }

    //Task “Study Profile Updates for Amendment” (optional)  *** 
    if (TaskName === "Study Profile Updates for Amendment") {
        $('#taskHeading').text("Study Profile Updates for Amendment");
        $('#piPanel').text("By submitting this form, you are confirming that all required updates related to the amendment have been completed in the study profile.");
        $('#checkboxLabel').text("I confirm that all updates to the Study Profile have been completed as requested");
        $('.studyProfileUpdates').show();
    }

    $('#ui_btn_submit').click(function () {
        ValidateMandatoryFileds();
        SaveDetails();
    });
    function ValidateMandatoryFileds() {
        retVal = true;
        $(".error").remove();
        var isNotChecked;
        if (TaskName === "SAE Final Reconciliation Report Confirmation") {
             isNotChecked = $('#resubmissionReason').prop("checked");
            if (isNotChecked === false) {
                $('#chkbox').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>please check the reason for resubmission</div>');
                retVal = false;
            }
        }
        else if (TaskName === "Study Profile Updates for Amendment") {
              isNotChecked = $('#resubmissionReason').prop("checked");
            if (isNotChecked === false) {
                $('#chkbox').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>please check the reason for resubmission</div>');
                retVal = false;
            }
            if ($("#ui_txt_comments").val() === "") {
                $('#ui_txt_comments').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>please check the reason for resubmission</div>');
                retVal = false;
            }

        }
        else if (TaskName === "Review Rejection for Amendment") {
             isNotChecked = $('#resubmissionReason').prop("checked");
            if (isNotChecked === false) {
                $('#chkbox').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>please check the reason for resubmission</div>');
                retVal = false;
            }            

        }
    }
    $('#resubmissionReason').change(function () {
        $('#chkbox').next("div.error").remove();
    });

    function SaveDetails() {
        if (retVal === true) {
            objGMRCApprovalTask = new Object();
            objGMRCApprovalTask.ANJU_ChangedBy = $('#LogedinUserName').val();
            objGMRCApprovalTask.StudyId = $('#StudyId').val();
            objGMRCApprovalTask.TaskName = TaskName;
            $.ajax({
                async: false,
                type: "POST",
                url: "/MaintainanceAndMonitoring/UpdateFinalReconciliation",
                data: { "objGMRCApprovalTask": objGMRCApprovalTask },
                success: function (results) {
                    if (results.msgType === "Success") {
                        opener.location.reload();
                        if (TaskName === "SAE Final Reconciliation Report Confirmation") {
                            //ajax here                           
                        }
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
        }
        else {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    }
});