
function StudyDetailsID() {
    return {
        studyId: $('#StudyId').val(),
        PIuserName: $('#txtUserName').val()
    };
}
function onCancel() {
    window.close();
}
function Show(e) {
    var gridRowData = $("#ui_dtg_documentList").data("kendoGrid");
    if (gridRowData) {
        var data = gridRowData.dataItem($(e).closest("tr"));
        var subModuleFolderName = data.SubModuleName;
        var fileName = data.DocumentNameWithOutExtension + data.DocumentExtension;
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + $('#StudyId').val();
    }
}
$(document).ready(function () {

    var retVal = true;
    var TitleOfTrial = "";
    var plUserName = "";
    var validator = $("#ui_frmAssignMSLLOIReview").kendoValidator().data("kendoValidator");
    $.ajax({
        async: false,
        type: "POST",
        url: '/NewStudy/GetInstituteBystudyId',
        data: { "studyId": $('#StudyId').val() },
        success: function (result) {
            if (result !== "") {
                $("#ui_lblInstitutionName").append(result);
                $("#instituteSubmitted").append(", " + result);
            }
        }
    });
    $.ajax({
        async: false,
        type: "POST",
        url: '/NewStudy/GetIndicationByStudyID',
        data: { "studyId": $('#StudyId').val() },
        success: function (result) {
            if (result !== "") {
                $("#ui_lbl_indication").append(result);
            }
        }
    });
    $.ajax({
        async: false,
        type: "POST",
        url: '/NewStudy/GetTitleOfTrialByStudyID',
        data: { "studyId": $('#StudyId').val() },
        success: function (result) {
            if (result !== "") {
                $("#studyIdAndTitleOfTrial").append(': ' + result);
                TitleOfTrial = result;
            }
        }
    });

    $.ajax({
        async: false,
        type: "POST",
        url: '/NewStudy/GetUserNameByUserTypeAndStudyId',
        data: { "studyId": $('#StudyId').val(), "userType": "ProgramLeader" },
        success: function (result) {
            if (result !== "") {
                plUserName = result;
            }
        }
    });
    $.ajax({
        async: true,
        type: "POST",
        url: "/TaskWorkFlow/GetMSLReviewDetailsByStudyId/",
        cache: false,
        dataType: "json",
        data: { "StudyId": $('#StudyId').val() },
        success: function (result) {
            if (result.length > 0) {
                $("#ui_ddl_Franchise").data('kendoDropDownList').value(result[0].Franchise);
                $("#ui_ddl_PrimaryIndication").data('kendoDropDownList').value(result[0].PrimaryIndication);
                if (result[0].SecondaryIndication !== null) {
                    var SecondaryIndicationArray = result[0].SecondaryIndication.split(',');
                    $("#ui_multiselect_SecondaryIndication").getKendoMultiSelect().value(SecondaryIndicationArray);
                }
                //  $("#ui_ddl_PIInstitution").data('kendoDropDownList').value(result[0].Institution);
                //  $("#ui_ddl_Decision").data('kendoDropDownList').value(result[0].Decision);
            }
        },
        failure: function (response) {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });

    $("#btn-Submit").click(function () {
        ValidateMandatoryFields();
        SaveStudyReviewDetails();
    });

    function ValidateMandatoryFields() {
        $('.error').remove();
        retVal = true;

        if (($('#ui_ddl_Franchise').val() === "Select") || ($('#ui_ddl_Franchise').val() === "")) {
            $('#franchise').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Franchise is required</div>');
            retVal = false;
        }
        if (($('#ui_ddl_PrimaryIndication').val() === "Select") || ($('#ui_ddl_PrimaryIndication').val() === "")) {
            $('#primaryIndication').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Primary Indication is required</div>');
            retVal = false;
        }
        if (($('#ui_ddl_PIInstitution').val() === "Select") || ($('#ui_ddl_PIInstitution').val() === "")) {
            $('#piInstitution').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>PI Institution is required</div>');
            retVal = false;
        }
        if (($('#ui_ddl_Decision').val() === "Select") || ($('#ui_ddl_Decision').val() === "")) {
            $('#decision').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Decision is required</div>');
            retVal = false;
        }
    }

    $('#ui_ddl_Franchise').on("change", function () {
        $('#franchise').next("div.error").remove();
    });
    $('#ui_ddl_PrimaryIndication').on("change", function () {
        $('#primaryIndication').next("div.error").remove();
    });
    $('#ui_ddl_PIInstitution').on("change", function () {
        $('#piInstitution').next("div.error").remove();
    });
    $('#ui_ddl_Decision').on("change", function () {
        $('#decision').next("div.error").remove();
    });

    function SaveStudyReviewDetails() {
        if (validator.validate() && retVal === true) {
            objStudyReviewDetails = new Object();
            objStudyReviewDetails.StudyId = $('#StudyId').val();
            objStudyReviewDetails.MsluserName = $('#LogedinUserName').val();
            objStudyReviewDetails.Franchise = $('#ui_ddl_Franchise').val();
            objStudyReviewDetails.PrimaryIndication = $('#ui_ddl_PrimaryIndication').val();
            if ($('#ui_multiselect_SecondaryIndication').val() !== null)
                objStudyReviewDetails.SecondaryIndication = $('#ui_multiselect_SecondaryIndication').val().toString();//tostring will give result with comma separate
            objStudyReviewDetails.Institution = $('#ui_ddl_PIInstitution').val();
            objStudyReviewDetails.Decision = $('#ui_ddl_Decision').val();
            objStudyReviewDetails.ANJU_AddedBy = $('#LogedinUserName').val();
            objStudyReviewDetails.ANJU_ChangedBy = $('#LogedinUserName').val();

            $.ajax({
                async: false,
                type: "POST",
                url: "/TaskWorkFlow/SaveMSLReviewDetails",
                data: { "studyReview": objStudyReviewDetails },
                success: function (results) {
                    var lsmailParameter = new Array();
                    var appUrl = $(location)[0].origin;

                    if (results.msgType === "Success") {
                        var StudyURL = "<a href='" + appUrl + "'> Navigate</a>";
                        opener.location.reload();
                        if ($('#ui_ddl_Decision').val() === "Resubmit") {
                            lsmailParameter.push($('#txtUserName').val());
                            lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + TitleOfTrial + "</a>");
                            lsmailParameter.push($('#LogedinUserName').val());
                            lsmailParameter.push(StudyURL);
                            $.ajax({
                                type: "POST",
                                url: "/Common/SendEmail/",
                                cache: false,
                                data: { "mailMessage": "Resubmit LOI Notification", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $('#txtUserName').val(), "ccMail": " " },
                                dataType: "json",
                                success: function (results) {
                                    popupNotification.show('Email Sent Successfully', "success");
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    popupNotification.show('Sending Email Failed', "error");
                                }
                            });

                        }
                        else {
                            lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + TitleOfTrial + "</a>");
                            lsmailParameter.push($('#txtUserName').val());
                            lsmailParameter.push(StudyURL);
                            $.ajax({
                                type: "POST",
                                url: "/Common/SendEmail/",
                                cache: false,
                                data: { "mailMessage": "PL review", "lsparameter": lsmailParameter, "subParam": " ", "toMail": plUserName, "ccMail": " " },
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
        else {

            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    }
});
