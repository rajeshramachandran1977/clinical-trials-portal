var gridRowData = $("#gridMyTaskList").data("kendoGrid");
$('#ui_btnStartaNewSubmission').click(function () {
    $('#myModal').modal('show');
});

var infoFlag = true;
$('#helpText').click(function () {
    $('#infoModal').toggle();
    if (infoFlag) {
        $('#onInterventional').hide();
        $('#onNonInterventional').hide();
        infoFlag = false;
    }
    else if (!infoFlag) {
        $("input[type = radio]").prop('checked', false);
        infoFlag = true;
    }
});

$('#myModal').on('hidden.bs.modal', function (e) {
    $(this).find("input[type=checkbox], input[type=radio]").prop("checked", "").end();
    $('#onInterventional').hide();
    $('#onNonInterventional').hide();
    $('#ui_btn_newStudy').attr("disabled", true);
    $('#modalCheckBox').attr("disabled", true);
});

$('.changePasswordModal').on('hidden.bs.modal', function () {
    $('#ui_txt_currentPassword,#ui_txt_enterNewPassword,#ui_txt_confirmNewPassword').val('');
    $('.greenColor,.redColor').remove();
})

$('#ui_btn_save').click(function () {

    ValidatePasswordFields();
    SavePasswordDetails();
});

var retVal = true;
var PasswordvalidationCheck = true;
$('.greenColor,.redColor').remove();


function ValidatePasswordFields() {
    $('.error').remove();
    retVal = true;
    if ($('#ui_txt_currentPassword').val() === "" || $('#ui_txt_currentPassword').val() === null) {
        $('#currentPassword').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please enter Current Password.</div>');
        retVal = false;
    }
    if ($('#ui_txt_enterNewPassword').val() === "" || $('#ui_txt_enterNewPassword').val() === null) {
        $('#enterNewPassword').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please enter New Password.</div>');
        retVal = false;
    }
    if ($('#ui_txt_confirmNewPassword').val() === "" || $('#ui_txt_confirmNewPassword').val() === null) {
        $('#confirmNewPassword').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please enter Confirm New Password.</div>');
        retVal = false;
    }
    if ($('#ui_txt_confirmNewPassword').val() !== "" || $('#ui_txt_confirmNewPassword').val() !== null) {
        if ($('#ui_txt_enterNewPassword').val() !== $('#ui_txt_confirmNewPassword').val()) {
            $('#confirmNewPassword').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Passwords do not match.</div>');
            retVal = false;
        }
    }

    if ($('#ui_txt_currentPassword').val() === $('#ui_txt_enterNewPassword').val() && $('#ui_txt_currentPassword').val().length > 0 && $('#ui_txt_enterNewPassword').val().length > 0) {
        $('#confirmNewPassword').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Current Password and New Password cannot be same.</div>');
        retVal = false;
    }

}
var pwdLength;
var pwdIncUpperandLowerCase;
var pwdEnforceOneNumber;
var pwdSpecialChar;
$("#ui_txt_enterNewPassword").blur(function () {
    $('.greenColor,.redColor').remove();
    var password = $("#ui_txt_enterNewPassword").val();
    if (isCheckPasswordLength) {
        if (parseInt(password.length) >= pwdLength)
            PasswordvalidationCheck = true;
        else
            PasswordvalidationCheck = false;
    }
    if (PasswordvalidationCheck === true && pwdIncUpperandLowerCase === true) {
        if (password.match(/[A-Z]/) && password.match(/[a-z]/)) {
            PasswordvalidationCheck = true;
        }
        else
            PasswordvalidationCheck = false;
    }

    if (PasswordvalidationCheck === true && pwdEnforceOneNumber === true) {
        if (password.match(/\d/)) {
            PasswordvalidationCheck = true;
        } else {
            PasswordvalidationCheck = false;
        }
    }


    if (PasswordvalidationCheck === true && pwdSpecialChar === true) {
        if (password.match(/[!"#$%&'()*+,-./:;<=>?@@[\]^_`{|}~]/)) {
            PasswordvalidationCheck = true;
        } else {
            PasswordvalidationCheck = false;
        }
    }


    if (PasswordvalidationCheck === false && parseInt(password.length) > 0) {
        PasswordvalidationCheck = false;
        $('#confirmNewPassword').after('<div class="redColor font_12">The provided password does not meet system requirements.</div>');
    }

});
$("#ui_txt_confirmNewPassword").blur(function () {
    $('.greenColor,.redColor').remove();
    var password = $("#ui_txt_enterNewPassword").val();
    if (isCheckPasswordLength) {
        if (parseInt(password.length) >= pwdLength)
            PasswordvalidationCheck = true;
        else
            PasswordvalidationCheck = false;
    }
    if (PasswordvalidationCheck === true && pwdIncUpperandLowerCase === true) {
        if (password.match(/[A-Z]/) && password.match(/[a-z]/)) {
            PasswordvalidationCheck = true;
        }
        else
            PasswordvalidationCheck = false;
    }

    if (PasswordvalidationCheck === true && pwdEnforceOneNumber === true) {
        if (password.match(/\d/)) {
            PasswordvalidationCheck = true;
        } else {
            PasswordvalidationCheck = false;
        }
    }


    if (PasswordvalidationCheck === true && pwdSpecialChar === true) {
        if (password.match(/[!"#$%&'()*+,-./:;<=>?@@[\]^_`{|}~]/)) {
            PasswordvalidationCheck = true;
        } else {
            PasswordvalidationCheck = false;
        }
    }


    if (PasswordvalidationCheck === false && parseInt(password.length) > 0) {
        PasswordvalidationCheck = false;
        $('#confirmNewPassword').after('<div class="redColor font_12">The provided password does not meet system requirements.</div>');
    }

});

$('#ui_txt_currentPassword').on('keyup', function () {
    $('#currentPassword').next("div.error").remove();
});
$('#ui_txt_enterNewPassword').on('keyup', function () {
    $('#enterNewPassword').next("div.error").remove();
});
$('#ui_txt_confirmNewPassword').on('keyup', function () {
    $('#confirmNewPassword').next("div.error").remove();
});
$('#ui_txt_enterNewPassword').on('keyup', function () {
    $('#confirmNewPassword').next("div.error").remove();
});

$('#hideStudies').click(function () {
    var grid = $("#gridMyStudyList").data("kendoGrid");
    var isChecked = $("#hideStudies").prop('checked');
    if (isChecked == true) {
        grid.dataSource.filter({
            logic: "and",
            filters: [
                { field: "Stage", operator: "neq", value: "Closed" },
                { field: "Stage", operator: "neq", value: "Withdrawn" },
                { field: "Stage", operator: "neq", value: "Rejected" },
            ]
        });
        grid.refresh()
    } else {
        grid.dataSource.filter({});
    }
});
function SavePasswordDetails() {
    $('.greenColor,.redColor').remove();

    if (retVal && PasswordvalidationCheck) {
        $.ajax({
            async: true,
            type: "POST",
            url: "/Login/ChangePassword",
            data: { urlString: "", password: $('#ui_txt_confirmNewPassword').val(), oldPassword: $('#ui_txt_currentPassword').val() },
            success: function (results) {
                if (results.msgType === "Success") {
                    $('#ui_txt_currentPassword').val('');
                    $('#ui_txt_enterNewPassword').val('');
                    $('#ui_txt_confirmNewPassword').val('');
                    $('#confirmNewPassword').after('<div class="greenColor font_12">Password has changed successfully</div>');
                    setTimeout(function () {
                        $('.changePasswordModal').modal('hide');
                    }, 3000)
                }
                else
                    $('#confirmNewPassword').after('<div class="redColor font_12">' + results.data + '</div>');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
            }
        });
    }
    else {
        $('#confirmNewPassword').after('<div class="redColor font_12">The provided password does not meet system requirements.</div>');
    }
}

$(document).ready(function () {
    $('#piDashboardHelp').hide();
    $('#piDashboardMyProfile').hide();
    $('#piDashboardProfileSubmit').hide();

    var html = '';
    var count = 0;
    var i;
    var path = '';
    var firstreplace = '';
    var seconreplace = '';

    $.ajax({
        async: false,
        type: "POST",
        url: "/NewStudy/GetDocumentsByStudyID",
        data: { "studyId": 0, "subModuleName": "externalDocuments" },
        success: function (results) {
            if (results !== null) {
                $.each(results.Data, function (index, item) {
                    count++;
                    path = results.Data[index].Path;
                    firstreplace = path.replace('/', '%');
                    firstreplace = path.replace('\\', '%');
                    html += '<tr class="col-md-12 pl-md-2"><td class="ui_label" id=ui_text_review' + count + '>' + '<a href="#" onclick="Downloads(this)">' + results.Data[index].DocumentName + '</a>' + '</td>';
                    html += '</tr>';
                });
                $(html).appendTo($("#reviewExternalDocuments"));
            }
            else {
                popupNotification.show(results.msgType, "error");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            popupNotification.show('Error', "error");
        }
    });

    //disable right click for study list
    $("#gridMyStudyList").on("contextmenu", function (e) {
        return false;
    });

    $('#tempdata').val("@tempvalue");
    $('#piDashboardHelp').hide();
    $('#infoModal').hide();

    $('#onInterventional').hide();
    $('#onNonInterventional').hide();

    $(document).on('click', '#toggleCurrentPassword', function () {
        $(this).toggleClass("fa-eye fa-eye-slash");
        var input = $('#ui_txt_currentPassword');
        input.attr('type') === 'password' ? input.attr('type', 'text') : input.attr('type', 'password');
    });

    $(document).on('click', '#toggleNewPassword', function () {
        $(this).toggleClass("fa-eye fa-eye-slash");
        var input = $('#ui_txt_enterNewPassword');
        input.attr('type') === 'password' ? input.attr('type', 'text') : input.attr('type', 'password');
    });

    $(document).on('click', '#toggleConfirmPassword', function () {
        $(this).toggleClass("fa-eye fa-eye-slash");
        var input = $('#ui_txt_confirmNewPassword');
        input.attr('type') === 'password' ? input.attr('type', 'text') : input.attr('type', 'password');
    });

    //change password   
    $.ajax({
        async: true,
        type: "POST",
        url: "/Login/GetPwdPolicydetails",
        success: function (results) {
            $.each(results, function (index, item) {
                if (item.GlobalKey.toUpperCase() === "EnforcePasswordLength".toUpperCase() && parseInt(item.GlobalValue) > 0) {
                    isCheckPasswordLength = true;
                    pwdLength = item.GlobalValue;
                }
                if (item.GlobalKey.toUpperCase() === "EnforceOneUpperandOneLowerCaseCharacter".toUpperCase() && item.GlobalValue === "True") {
                    isIncUpperandLowerCase = true;
                    pwdIncUpperandLowerCase = true;
                }
                if (item.GlobalKey.toUpperCase() === "EnforceOneNumber".toUpperCase() && item.GlobalValue === "True") {
                    isEnforceOneNumber = true;
                    pwdEnforceOneNumber = true;
                }
                if (item.GlobalKey.toUpperCase() === "EnforceSpecialChar".toUpperCase() && item.GlobalValue === "True") {
                    isSpecialChar = true;
                    pwdSpecialChar = true;
                }
            });
            if (parseInt(pwdLength) > 0) {
                $("#passwordLength").append("At least " + pwdLength + " characters in length");
            }
            if (pwdIncUpperandLowerCase === true) {
                $("#passwordUpperLowerCase").append("At least one upper and lower case character");
            }
            if (pwdEnforceOneNumber === true) {
                $("#passwordNumberic").append("At least one numeric character");
            }
            if (pwdSpecialChar === true) {
                $("#passwordSpecial").append("At least one special character");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });


    $("#tabstrip").kendoTabStrip({
        animation: {
            open: {
                effects: "fadeIn"
            }
        }
    });

    //disable checkbox until radio button is selected
    $('input:radio').change(function () {
        if (($(this).val() === 'Interventional') || ($(this).val() === 'Non-Interventional')) {
            $('#modalCheckBox').removeAttr('disabled');
        }
    });

    $("input:radio").click(function () {
        if ($(this).val() === "Interventional") {
            $("#onInterventional").show();
            $("#onNonInterventional").hide();
        } else {
            $("#onInterventional").hide();
            $("#onNonInterventional").show();
        }
    });
    //disable submit until checkbox is checked
    $('#ui_btn_newStudy').attr("disabled", true);
    $('#modalCheckBox').click(function () {
        $('#ui_btn_newStudy').attr("disabled", !$(this).is(":checked"));
    });
});
function Downloads(e) {
    var documentname = e.innerHTML;
    $.ajax({
        async: false,
        type: "POST",
        url: "/TaskWorkFlow/GetDocumentByName",
        data: { "documentname": documentname, "studyid": 0 },
        success: function (results) {
            if (results !== null) {
                $.each(results.Data, function (index, item) {
                    //window.location = "/NewStudy/DownloadFiles?fileName=" + results.Data[index].DocumentName + '&&subModuleFolderName=' + "CommonDocuments" + '&&studyId=' + 0 + '&&path=' + results.Data[index].Path;
                    window.location = "/NewStudy/DownloadFiles?fileName=" + results.Data[index].DocumentName + '&&subModuleFolderName=' + "CommonDocuments" + '&&studyId=0';
                });
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            popupNotification.show('Error', "error");
        }
    });

}

//Start a New Study
$(document).on("click", "#ui_btn_newStudy", function () {
    var trialType = $('input[name=trialType]:checked', '#ui_frmPIDashboard').val();
    //window.open('../NewStudy/ScientificRationaleI?Username=' + $('#username').val() + '&&StudyId=' + 0 + '&&mode=Create' + '&&StudyType=' + trialType, 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=1400,height=668,top=100');
    var h = 600;
    var top = Number((screen.height / 2) - (h / 2));
    obj = new Object();
    obj.StudyId = 0;
    obj.mode = "Create";
    obj.StudyType = trialType;
    $.ajax({
        async: true,
        type: "POST",
        url: "/Login/OpenNewWindow",
        data: { "obj": obj },
        success: function (results) {
            if (results.data === "Success") {
                window.open('../NewStudy/ScientificRationaleI', 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=1400,height=' + h + ',top=' + top + '');
            }
            else {
                alert("Error");
            }
        }
    });
});

//logout
$('.logout').click(function () {
    document.location.href = "/Login/Logout";
});

$('.help').click(function () {
    $('#piDashboardHome').hide();
    $('#piDashboardMyProfile').hide();
    $('#piDashboardProfileSubmit').hide();
    $('#piDashboardHelp').show();
});

$(".myHome").click(function () {
    window.location.href = "/Dashboard/PIDashboard";
});

$(".myProfile").click(function () {
    $('#piDashboardHome').hide();
    $('#piDashboardHelp').hide();
    $('#piDashboardProfileSubmit').hide();
    $('#piDashboardMyProfile').show();
});

function ShowStudyName(e) {
    var gridRowData = $("#gridMyTaskList").data("kendoGrid");
    if (gridRowData) {
        var data = gridRowData.dataItem($(e).closest("tr"));

        var StudyId = data.StudyId;
        var StudyType = data.StudyType;
        obj = new Object();
        obj.StudyId = parseInt(StudyId);
        obj.mode = "Update";
        obj.StudyType = StudyType;
        obj.StudyNumber = data.StudyNumber;

        var w = 1020;
        var h = 600;
        var left = Number((screen.width / 2) - (w / 2));
        var top = Number((screen.height / 2) - (h / 2));
        $.ajax({
            async: true,
            type: "POST",
            url: "/Login/OpenNewWindow",
            data: { "obj": obj },
            success: function (results) {
                if (results.data === "Success") {
                    window.open('../NewStudy/EditStudy', 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                }
                else {
                    alert("Error");
                }
            }
        });
    }
}

function studyFilter(element) {
    element.kendoAutoComplete({
        dataSource: {
            transport: {
                //read: "@Url.Action("FilterMenuCustomization_Titles")"
            }
        }
    });
}

function Show(e) {
    var gridRowData = $("#gridMyStudyList").data("kendoGrid");
    if (gridRowData) {
        var data = gridRowData.dataItem($(e).closest("tr"));

        var StudyId = data.StudyId;
        var StudyType = data.StudyType;
        obj = new Object();
        obj.StudyId = parseInt(StudyId);
        obj.mode = "Update";
        obj.StudyType = StudyType;
        obj.StudyNumber = data.StudyNumber;

        var w = 1020;
        var h = 600;
        var left = Number((screen.width / 2) - (w / 2));
        var top = Number((screen.height / 2) - (h / 2));
        $.ajax({
            async: true,
            type: "POST",
            url: "/Login/OpenNewWindow",
            data: { "obj": obj },
            success: function (results) {
                if (results.data === "Success") {
                    window.open('../NewStudy/EditStudy', 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                }
                else {
                    alert("Error");
                }
            }
        });
    }
}

function ShowTask(e) {
    var gridRowData = $("#gridMyTaskList").data("kendoGrid");
    if (gridRowData) {
        var w = 1020;
        var h = 600;
        var left = Number((screen.width / 2) - (w / 2));
        var top = Number((screen.height / 2) - (h / 2));

        var data = gridRowData.dataItem($(e).closest("tr"));
        var StudyId = data.StudyId;
        var StudyType = data.StudyType;
        var piTaskStatus = data.PITaskStatus;
        var TaskName = data.TaskName;
        var StudyNumber = data.StudyNumber;
        var TitleofTrial = data.TitleofTrial;
        var Institution = data.Institution;

        if (TaskName === submitrequiredicfdocument || TaskName === submitactivationdocuments || TaskName === icfresubmissionrequired || TaskName === resubmitactivationdocuments) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = data.ANJU_AddedBy;
            obj.TaskName = TaskName;
            obj.StudyNumber = StudyNumber;
            obj.TitleofTrial = TitleofTrial;
            obj.Institution = Institution;

            $.ajax({
                async: true,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        window.open("../ProtocolPhase/ProtocolPhase", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else if (TaskName === resubmitamendmentrequest) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = data.Anju_Added;
            obj.TaskName = TaskName;
            $.ajax({
                async: true,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        window.open("../MaintainanceAndMonitoring/ResubmitAmendmentRequest", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else if (TaskName === resubmitfinalstudyreport) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = data.Anju_Added;
            obj.TaskName = TaskName;
            obj.GMRCTaskName = TaskName;
            obj.StudyNumber = data.StudyNumber;

            $.ajax({
                async: true,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        window.open("../StudyCloseout/StudyCloseout", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });

        }
        else {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.mode = "Update";
            obj.StudyType = StudyType;
            obj.PITaskStatus = piTaskStatus;
            obj.TaskName = TaskName;
            $.ajax({
                async: true,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        window.open('../NewStudy/ScientificRationaleI', 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=1400,height=' + h + ',top=' + top + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
    }
}

function ShowIcon(dataItem) {
    if (Stage === "Active") {
        return true;
    }
    if (PITaskStatus === "Study Closeout Initiated" && TaskStatus !== "Requested Document has been accepted") {
        if (IsallTaskCompleted === 0 || IsallTaskCompleted === null)
            return false;
        else
            return true;
    }
    if (IsallTaskCompleted === 0 || IsallTaskCompleted === null)
        return false;
    else
        return false;
} 