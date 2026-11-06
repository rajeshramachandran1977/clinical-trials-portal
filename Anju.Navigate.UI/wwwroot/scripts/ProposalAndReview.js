function onCancel() {
    window.close();
}
var trialLeader='';
$(document).ready(function () {
     $.ajax({
        async: false,
        type: "POST",
        url: '/NewStudy/GetUserNameByUserTypeAndStudyId',
        data: { "studyId": $('#StudyId').val(), "userType": TRIALLEADER },
        success: function (result) {
            if (result !== "") {
                trialLeader = result;
            }
        }
    });

    //Fetching title of trial with Study Id or Study Number
    var titleOfTrialWithStudyId = $('#StudyId').val() + ": " + $('#TitleofTrial').val();
    var titleOfTrialWithStudyNumber = $('#StudyNumber').val() + ": " + $('#TitleofTrial').val();
    ($('#StudyNumber').val() === null || $('#StudyNumber').val() === "") ? $('#titleOfTrialWithStudy').text(titleOfTrialWithStudyId) : $('#titleOfTrialWithStudy').text(titleOfTrialWithStudyNumber)

    $('#globalMRCContingency').hide();
    $('#resubmissionDis').hide();
    $('#resubGlobalMRC').hide();
    $('#approvalComments').hide();

    var TaskName = $("#TaskName").val();
    var State = $("#State").val();

    //MSL Task “Review Rejection”
    if (TaskName === "Review Rejection") {
        $('#taskHeading').text("Review Rejection");
        $('#piPanel').text("Please indicate if all reasons for rejection have been discussed with the Investigator.");
        $('#checkboxLabel').text("Reasons for rejection have been addressed");
    }

    //Tabled
    //TL Action “Resume Meeting”
    if (TaskName === "Resume Meeting") {
        $('#taskHeading').text("Resume Meeting");
        $('#panelForPI').hide();
        $('#checkboxLabel').text("Committee is now ready to record a decision for the tabled study");
    }

    //MSL Task “MSL Clear Global MRC Contingency”
    if (TaskName === "MSL Clear Global MRC Contingency") {
        $('#taskHeading').text("MSL Clear Global MRC Contingency");
        $('#piPanel').text("Please record the outcome of discussion with the Investigator in the comments box. Also indicate if all contingencies have been cleared.");
        $('#chkbox').hide();
        $('#globalMRCContingency').show();
    }

    //MSL Task “Return to PI for Resubmission”
    if (TaskName === "Return to PI for Resubmission" && State !== "Program Leader Review Requested Resubmission") {
        $('#taskHeading').text("Return to PI for Resubmission");
        $('#piPanel').text("Please indicate if all comments have been discussed with the Investigator for resubmission.");
        $('#chkbox').hide();
        $('#resubmissionDis').show();
    }

    //MSL Task “Return to PI for Resubmission to Global MRC”
    if (TaskName === "Return to PI for Resubmission to Global MRC") {
        //$('#resubGlobalMRC').show();
        $('#taskHeading').text("Return to PI for Resubmission to Global MRC");
        $('#piPanel').text("Please indicate if all comments have been discussed with the Investigator for resubmission.");
        $('#chkbox').hide();
        $('#resubmissionDis').show();
    }

    //Task “Resubmitted LOI for Review”
    if (TaskName === "Resubmitted LOI for Review") {
        $('#taskHeading').text("Resubmitted LOI for Review");
        $('#piPanel').hide();
        $('#chkbox').hide();
        $('#approvalComments').show();
    }
    var retval = true;

    $("#btn-Submit").click(function () {
        ValidateMandatoryFields();
        SaveDetails();
    });
    $("#ui_txt_approvalComments").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });

    function ValidateMandatoryFields() {
        retval = true;
        $(".error").remove();
        if ((TaskName === "Return to PI for Resubmission" || TaskName === "Return to PI for Resubmission to Global MRC") && State !== "Program Leader Review Requested Resubmission") {
            if ($('#ui_ddl_reSubmissionCmts').val() === 'Select' || $('#ui_ddl_reSubmissionCmts').val() === "") {
                $('#reSubmissionCmts').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Decision</div>');
                retval = false;
            }
        }
        else if (TaskName === "Resubmitted LOI for Review") {
            if ($('#ui_ddl_approvalCommentsDecision').val() === 'Select' || $('#ui_ddl_approvalCommentsDecision').val() === "") {
                $('#approvalCommentsDecision').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Decision</div>');
                retval = false;
            }
            if ($('#ui_txt_approvalComments').val() === "") {
                $('#approvalTextComments').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Comments</div>');
                retval = false;
            }
        }
        else if (TaskName === "MSL Clear Global MRC Contingency") {
            if ($('#ui_ddl_contingencies').val() === 'Select' || $('#ui_ddl_contingencies').val() === "") {
                $('#contingencies').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Decision</div>');
                retval = false;
            }
        }
        else {
            var isNotChecked = $('#resubmissionReason').prop("checked");
            if (isNotChecked === false) {
                $('#chkbox').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>please check the reason for resubmission</div>');
                retval = false;
            }
        }
    }
    $("#ui_ddl_reSubmissionCmts").on("change", function () {
        $('#reSubmissionCmts').next("div.error").remove();
    });
    $("#resubmissionReason").change(function () {
        $('#chkbox').next("div.error").remove();
    });
    $("#ui_ddl_approvalCommentsDecision").change(function () {
        $('#approvalCommentsDecision').next("div.error").remove();
    });
    $("#ui_txt_approvalComments").on("keyup", function () {
        $('#approvalTextComments').next("div.error").remove();
    });
    $("#ui_ddl_contingencies").on("change", function () {
        $("#contingencies").next("div.error").remove();
    });
    function SaveDetails() {
        if (retval === true) {
            if (TaskName === "Resubmitted LOI for Review") {
                objMRCStudyReview = new Object();
                objMRCStudyReview.CAResubmissionDecision = $('#ui_ddl_approvalCommentsDecision').val();
                objMRCStudyReview.CAResubmissionComments = $('#ui_txt_approvalComments').val();
                objMRCStudyReview.ANJU_ChangedBy = $('#LogedinUserName').val();
                objMRCStudyReview.RecordType = "GlobalMRC";
                objMRCStudyReview.StudyId = $('#StudyId').val();

                $.ajax({
                    async: true,
                    type: "POST",
                    url: "/TaskWorkFlow/UpdateGMRCConditionalApprovalDetails",
                    data: { "mrcStudyReview": objMRCStudyReview },
                    success: function (results) {
                        if (results.msgType === "Success") {
                            opener.location.reload();
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
                objNewStudy = new Object();
                objNewStudy.StudyId = $('#StudyId').val();
                objNewStudy.TaskName = TaskName;
                objNewStudy.RecordType = $('#RecordType').val();
                objNewStudy.ANJU_ChangedBy = $('#LogedinUserName').val();
                if (TaskName === "Return to PI for Resubmission" && State === "Program Leader Review Requested Resubmission") {
                    objNewStudy.State = "Program Leader Review Requested Resubmission";
                }
                else if (TaskName === "Return to PI for Resubmission" && State === "LMRC Resubmission Required") {
                    if ($('#ui_ddl_reSubmissionCmts').val() === "PI consents to resubmit")
                        objNewStudy.State = "LMRC Requested Resubmission";
                    if ($('#ui_ddl_reSubmissionCmts').val() === "PI declines to resubmit")
                        objNewStudy.State = "LMRC Rejected";
                }
                else if (TaskName === "Return to PI for Resubmission to Global MRC" && State === "GMRC Resubmission Required") {
                    if ($('#ui_ddl_reSubmissionCmts').val() === "PI consents to resubmit")
                        objNewStudy.State = "GMRC Requested Resubmission";
                    if ($('#ui_ddl_reSubmissionCmts').val() === "PI declines to resubmit")
                        objNewStudy.State = "GMRC Rejected";
                }
                else if (TaskName === "MSL Clear Global MRC Contingency") {
                    if ($('#ui_ddl_contingencies').val() === "Yes")
                        objNewStudy.State = "GMRC Approved";
                    if ($('#ui_ddl_contingencies').val() === "No")
                        objNewStudy.State = "Resume Meeting";
                }
            
                $.ajax({                  
                    async: false,
                    type: "POST",
                    url: "/TaskWorkFlow/UpdatePIResubmission",
                    data: { "newStudy": objNewStudy },
                    success: function (results) {
                        if (results.msgType === "Success") {
                            opener.location.reload();
                            var lsmailParameter = new Array();
                            var appUrl = $(location)[0].origin;
                            var StudyURL = "<a href='" + appUrl + "'> Navigate</a>";
                            if (TaskName === "MSL Clear Global MRC Contingency") {
                                lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                                lsmailParameter.push(StudyURL);
                                $.ajax({
                                    type: "POST",
                                    url: "/Common/SendEmail/",
                                    cache: false,
                                    data: { "mailMessage": "Global Clear Approve", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $('#LogedinUserName').val(), "ccMail": " " },
                                    dataType: "json",
                                    success: function (results) {
                                        popupNotification.show('Email Sent Successfully', "success");
                                    },
                                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                                        popupNotification.show('Sending Email Failed', "error");
                                    }
                                });
                            }
                            else if (TaskName === "Review Rejection") {
                                lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                                lsmailParameter.push(StudyURL);
                                $.ajax({
                                    type: "POST",
                                    url: "/Common/SendEmail/",
                                    cache: false,
                                    data: { "mailMessage": "Study Rejection", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $('#LogedinUserName').val(), "ccMail": " " },
                                    dataType: "json",
                                    success: function (results) {
                                        popupNotification.show('Email Sent Successfully', "success");
                                    },
                                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                                        popupNotification.show('Sending Email Failed', "error");
                                    }
                                });
                            }
                            else if (TaskName === "Return to PI for Resubmission" &&  trialLeader!=="" ) {
                                //#parse("reviewtype.vm") 
                                lsmailParameter.push($('#LogedinUserName').val())
                                lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                                lsmailParameter.push($("#txtUserName").val())
                                lsmailParameter.push(StudyURL);
                                $.ajax({
                                    type: "POST",
                                    url: "/Common/SendEmail/",
                                    cache: false,
                                    data: { "mailMessage": "Start Meeting Resubmit (conditionally approved )", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $('#LogedinUserName').val(), "ccMail": " " },
                                    dataType: "json",
                                    success: function (results) {
                                        popupNotification.show('Email Sent Successfully', "success");
                                    },
                                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                                        popupNotification.show('Sending Email Failed', "error");
                                    }
                                });
                            }
                            else if (TaskName === "Return to PI for Resubmission") {
                                lsmailParameter.push($('#LogedinUserName').val())
                                lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                                lsmailParameter.push($("#txtUserName").val())
                                lsmailParameter.push(StudyURL);

                                $.ajax({
                                    type: "POST",
                                    url: "/Common/SendEmail/",
                                    cache: false,
                                    data: { "mailMessage": "Return to Resubmit", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $('#LogedinUserName').val(), "ccMail": " " },
                                    dataType: "json",
                                    success: function (results) {
                                        popupNotification.show('Email Sent Successfully', "success");
                                    },
                                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                                        popupNotification.show('Sending Email Failed', "error");
                                    }
                                });
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
        }
        else {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    }

});