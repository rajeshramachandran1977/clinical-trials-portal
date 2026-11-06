function onCancel() {
    window.close();
}

$(document).ready(function () {
    var retVal = true;
    var TitleofTrial = "";
    $.ajax({
        async: false,
        type: "POST",
        url: '/NewStudy/GetTitleOfTrialByStudyID',
        data: { "studyId": $('#StudyId').val() },
        success: function (result) {
            if (result !== "") {
                $("#studyIdAndTitleOfTrial").append(': ' + result);
                TitleofTrial = result;
            }
        }
    });
    $.ajax({
        async: false,
        type: "POST",
        url: '/NewStudy/GetInstituteBystudyId',
        data: { "studyId": $('#StudyId').val() },
        success: function (result) {
            if (result !== "") {
                $("#instituteSubmitted").append(", " + result);
            }
        }
    }); 

    $("#btn-Submit").click(function () {
        ValidateMandatoryFields();
        SaveTaskDetails();
    });
    function ValidateMandatoryFields() {
        $('.error').remove();
        retVal = true;
        if ($('#ui_ddl_msl').val() === 'Select' || $('#ui_ddl_msl').val() === "") {
            $('#msl').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>MSL is required</div>');
            retVal = false;
        }
        if ($('#ui_ddl_programLeader').val() === 'Select' || $('#ui_ddl_programLeader').val() === "") {
            $('#programLeader').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Program Leader is required</div>');
            retVal = false;
        }
    }
    $("#ui_ddl_msl").change(function () {
        $('#msl').next("div.error").remove();
    });
    $("#ui_ddl_programLeader").change(function () {
        $('#programLeader').next("div.error").remove();
    });

    var AssignedUser = $("#txtUserName").val();
    var LogedinUserName = $("#LogedinUserName").val();
    var validator = $("#ui_frmAssignMSLAndTL").kendoValidator().data("kendoValidator");

    function SaveTaskDetails() {
        if (validator.validate() && retVal === true) {
            objStudyTask = new Object();
            objStudyTask.StudyId = $('#StudyId').val();
            objStudyTask.MsluserId = $('#ui_ddl_msl').val();
            objStudyTask.PluserId = $('#ui_ddl_programLeader').val();
            objStudyTask.UpcomingTask = "MSL LOI Review";
            objStudyTask.ANJU_AddedBy = LogedinUserName;

            $.ajax({
                async: false,
                type: "POST",
                url: "/TaskWorkFlow/SaveMSLAndPLTaskDetails",
                data: { "studyTask": objStudyTask },
                success: function (results) {
                    if (results.msgType === "Success") {
                        opener.location.reload();
                        var lsmailParameter = new Array();
                        var appUrl = $(location)[0].origin;
                        var StudyURL = "<a href='" + appUrl + "'> Navigate</a>";                       
                        lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + TitleofTrial + "</a>");
                        lsmailParameter.push(AssignedUser);
                        lsmailParameter.push(StudyURL);
                        $.ajax({
                            type: "POST",
                            url: "/Common/SendEmail/",
                            cache: false,
                            data: { "mailMessage": "LOI review", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $('#ui_ddl_msl').data("kendoDropDownList").text(), "ccMail": " " },
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


        }
    }
});