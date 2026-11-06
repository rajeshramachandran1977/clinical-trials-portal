var rowNumber = 0;

function resetRowNumber(e) {
    e.preventDefault();
    rowNumber = 0;
}

function renderNumber(data) { 
    if (data.DefaultMilestoneId !== 0)
        return ++rowNumber;  
}
function renderRecordNumber(data) {
    if (data.DefaultMilestoneId !== 0) {
        var page = parseInt($("#gridDefaultMilestones").data("kendoGrid").dataSource.page()) - 1;
        var pagesize = $("#gridDefaultMilestones").data("kendoGrid").dataSource.pageSize();
        return parseInt(rowNumber + (parseInt(page) * parseInt(pagesize)));
    }
    else
        return "";
}

$('#hideStudies').click(function () {
    var grid = $("#gridMyStudyList").data("kendoGrid");
    var isChecked = $("#hideStudies").prop('checked');
    if (isChecked === true) {
        grid.dataSource.filter({
            logic: "and",
            filters: [
                { field: "Stage", operator: "neq", value: "Closed" },
                { field: "Stage", operator: "neq", value: "Withdrawn" },
                { field: "Stage", operator: "neq", value: "Rejected" },
            ]
        });
        grid.refresh();
    } else {
        grid.dataSource.filter({});
    }
});

function additionalInfo() {
    return {
        userName: $("#LoginUsername").val(),
        userType: $("#userType").val()
    }
}

function OnCreateUpdateModal(e) {
    $('#gridDefaultMilestones').data('kendoGrid').refresh();
  
}
function OnDefaultSettingsaveChanges(e) {
    var grid = null;
    switch (e.type) {
        case "create":
            grid = $("#gridDefaultMilestones").data("kendoGrid");
            grid.dataSource.read();
            break;
        case "update":
            grid = $("#gridDefaultMilestones").data("kendoGrid");
            grid.dataSource.read();
            break;
        case "destroy":
            grid = $("#gridDefaultMilestones").data("kendoGrid");
            grid.dataSource.read();
            break;
    }
}

var myContextMenuIIS = $("#contextMenuIIS").kendoContextMenu({
    target: "#gridMyStudyListDiv"
}).data("kendoContextMenu");

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
        data: { "studyId": 0, "subModuleName": "internalDocuments" },
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
                $(html).appendTo($("#reviewInternalDocuments"));
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

    $('#contextMenuIISDiv').hide();
    $('#tempdata').val(stringTempValue);
    $('#search').load('/Search/SearchResult');

    //help tab view
    $('#helpView').hide();
    $('.help').append($('#helpView').html());

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

    var userType = $("#userType").val();
    if (userType === MSL || userType === ProgramLeader || userType === TrialLeader)
        $("#listudyList").show();
    else
        $("#listudyList").hide();

    if (userType !== IISADMIN) {
        $('#dashboardItems li').removeClass('iis_dashboard_li');
        $('#dashboardItems li').addClass('iis_dashboard_iisAdmin');
    }
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
                    window.location = "/NewStudy/DownloadFiles?fileName=" + results.Data[index].DocumentName + '&&subModuleFolderName=' + "internal" + '&&studyId=' + 0 + '&&path=' + results.Data[index].Path;
                });
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            popupNotification.show('Error', "error");
        }
    });

}

function ShowIcon(dataItem) {   
        
        if (LocalMRCDecision === "Tabled" || GlobalMRCDecision === "Tabled") {
            return true;
        }
        else if ((GMRCTaskName === saeFinalReconciliationReportConfirmation && GMRCTaskCompleted === true)) { 
            if (NoOfGearTask === 4  && IsIconVisible === 0 ) {
                return false;
            }
            else if (IsallTaskCompleted === 0) {
                return false;
            }
            else if (TaskStatus === resubmitFianlStudyReportStatus && IsIconVisible === 0 ) {
                return false;
            }  
            else if (IsIconVisible === 0)
                return false;
            else
                return true;
        }
        else
            return false; 
}

//logout
$('.logout').click(function () {
    document.location.href = "/Login/Logout";
});

var StudyId;
var Anju_Added;
var TaskName;
var LocalMRCTaskName;
var GlobalMRCTaskName;
var Stage;
var State;
var myGearContextMenu;
var LoginUsername = $("#LoginUsername").val();
var ProxyUserName = $("#Proxyuser").val();

function showDetails(e) {
    var x = e.pageX;
    var y = e.pageY;
    var gridRowData = $("#gridMyStudyList").data("kendoGrid");
    if (gridRowData) {
        var data = this.dataItem($(e.currentTarget).closest("tr"));
        StudyId = data.StudyId;
        Anju_Added = data.ANJU_AddedBy;
        LocalMRCTaskName = data.LocalMRCDecision;
        GlobalMRCTaskName = data.GlobalMRCDecision;
        LocalMRCRecordType = data.LocalMRCRecordType;
        GlobalMRCRecordType = data.GlobalMRCRecordType;
        Stage = data.Stage;
        State = data.State;
        TaskName = data.TaskName;
        GMRCTaskName = data.GMRCTaskName;
        StudyNumber = data.StudyNumber;
        TitleofTrial = data.TitleofTrial;
        Institution = data.Institution;

        if ((LocalMRCTaskName === decisiontabled || GlobalMRCTaskName === decisiontabled) || (LocalMRCTaskName === "Tabled" || GlobalMRCTaskName === "Tabled")) {
            $("#contextMenuIIS").addClass(".k-context-menu");
            myContextMenuIIS.open(x, y);
            //$('#modifyStatusMenu').hide();
            $('#initiateCloseoutMenu').hide();
            $('#tabledMenu').show();
            //$('.closeStudy').hide();
        }
        if ((Stage === active && State === enrollmentClosed) || (Stage === "Active" && State === "Enrollment Closed")) {
            $("#contextMenuIIS").addClass(".k-context-menu");
            myContextMenuIIS.open(x,y);
            $('#initiateCloseoutMenu').show();
            $('#tabledMenu').hide();
        }
        if ((Stage === studyCloseoutInitiated && State === closeoutActivitiesInProgress) || (Stage === "Study Closeout Initiated" && State === "Closeout activities in Progress")) {
            $('#initiateCloseoutMenu').hide();
            $('#tabledMenu').hide();
            addContextMenuForGearTask();
            myGearContextMenu.open(x,y);
        }

        //if (Stage == "@Messages.DECISIONAPPROVED") {
        //      $('#modifyStatusMenu').show();
        //      $('#tabledMenu').hide();
        //  }
        //  else if (Stage = "@Messages.MODIFYSTATUSCANCELLEDSTAGE") {
        //      $('#modifyStatusMenu').hide();
        //  }
    }
}


function addContextMenuForGearTask(e) {
    $('#gearcontext-menu li').remove();
    $.ajax({
        async: false,
        type: "POST",
        url: '/StudyCloseout/GetGearTasks',
        data: { "studyId": StudyId },
        success: function (result) {
            for (var i = 0; i < result.length; i++) {
                var idValue = result[i].TaskName;
                if (result[i].AssignedTo === LoginUsername) {
                    $("#gearcontext-menu").append("<li class='ui_label' id=" + idValue + ">" + result[i].TaskName + "</li>");
                }
            }
            myGearContextMenu = $("#gearcontext-menu").kendoContextMenu({
                target: "#gridMyStudyListDiv",
                select: function (e) {
                    obj = new Object();
                    obj.GMRCTaskName = $(e.item).text();
                    CloseoutTasks(obj.GMRCTaskName);
                    $('#gearcontext-menu').hide();
                }
            }).data("kendoContextMenu");
        }
    });
}

function Show(e) {
    var gridRowData = $("#gridMyStudyList").data("kendoGrid");
    if (gridRowData) {
        var w = 1020;
        var h = 600;
        var left = Number((screen.width / 2) - (w / 2));
        var top = Number((screen.height / 2) - (h / 2));

        var data = gridRowData.dataItem($(e).closest("tr"));
        obj = new Object();
        obj.StudyId = parseInt(data.StudyId);
        obj.StudyType = data.StudyType;
        obj.StudyNumber = data.StudyNumber;

        obj.mode = "Update";
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

function ShowIISAdmin(e) {
    var gridRowData = $("#gridIISAdminMyTaskList").data("kendoGrid");
    if (gridRowData) {
        var w = 1020;
        var h = 600;
        var left = Number((screen.width / 2) - (w / 2));
        var top = Number((screen.height / 2) - (h / 2));

        var data = gridRowData.dataItem($(e).closest("tr"));
        obj = new Object();
        obj.StudyId = data.StudyId;
        obj.StudyType = data.StudyType;
        obj.StudyNumber = data.StudyNumber;

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

function ShowMSL(e) {
    var gridRowData = $("#gridMSLMyTaskList").data("kendoGrid");
    if (gridRowData) {
        var w = 1020;
        var h = 600;
        var left = Number((screen.width / 2) - (w / 2));
        var top = Number((screen.height / 2) - (h / 2));

        var data = gridRowData.dataItem($(e).closest("tr"));
        obj = new Object();
        obj.StudyId = parseInt(data.StudyId);
        obj.StudyType = data.StudyType;
        obj.StudyNumber = data.StudyNumber;

        obj.mode = "Update";
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

function ShowPL(e) {
    var gridRowData = $("#gridPLMyTaskList").data("kendoGrid");
    if (gridRowData) {
        var w = 1020;
        var h = 600;
        var left = Number((screen.width / 2) - (w / 2));
        var top = Number((screen.height / 2) - (h / 2));

        var data = gridRowData.dataItem($(e).closest("tr"));
        obj = new Object();
        obj.StudyId = parseInt(data.StudyId);
        obj.StudyType = data.StudyType;
        obj.StudyNumber = data.StudyNumber;

        obj.mode = "Update";
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

function ShowTL(e) {
    var gridRowData = $("#gridTLMyTaskList").data("kendoGrid");
    if (gridRowData) {
        var w = 1020;
        var h = 600;
        var left = Number((screen.width / 2) - (w / 2));
        var top = Number((screen.height / 2) - (h / 2));

        var data = gridRowData.dataItem($(e).closest("tr"));
        obj = new Object();
        obj.StudyId = parseInt(data.StudyId);
        obj.StudyType = data.StudyType;
        obj.StudyNumber = data.StudyNumber;

        obj.mode = "Update";
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

function AssignMSLAndTL(e) {
    var w = 1020;
    var h = 600;
    var left = Number((screen.width / 2) - (w / 2));
    var top = Number((screen.height / 2) - (h / 2));

    var gridRowData = $("#gridIISAdminMyTaskList").data("kendoGrid");
    if (gridRowData) {
        var data = gridRowData.dataItem($(e).closest("tr"));
        obj = new Object();
        obj.StudyId = data.StudyId;
        obj.ANJU_AddedBy = data.ANJU_AddedBy;

        $.ajax({
            async: true,
            type: "POST",
            url: "/Login/OpenNewWindow",
            data: { "obj": obj },
            success: function (results) {
                if (results.data === "Success") {
                    window.open("../TaskWorkFlow/AssignMSLAndTL", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                }
                else {
                    alert("Error");
                }
            }
        });
    }
}

function MSLReview(e) {
    var gridRowData = $("#gridMSLMyTaskList").data("kendoGrid");
    if (gridRowData) {
        var w = 1020;
        var h = 600;
        var left = Number((screen.width / 2) - (w / 2));
        var top = Number((screen.height / 2) - (h / 2));

        var data = gridRowData.dataItem($(e).closest("tr"));
        obj = new Object();
        obj.StudyId = data.StudyId;
        obj.ANJU_AddedBy = data.ANJU_AddedBy;
        obj.TaskName = data.TaskName;
        obj.State = data.State;
        var TaskName = data.TaskName;
        var TitleofTrial = data.TitleofTrial;
        var Institution = data.Institution;

        if (TaskName === mslloireview) {
            $.ajax({
                async: true,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        var w = window.open("../TaskWorkFlow/AssignMSLLOIReview", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                        w.addEventListener('load', w.doSomething, true);

                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else {
            obj.TaskName = TaskName;
            obj.StudyNumber = data.StudyNumber;
            obj.TitleofTrial = TitleofTrial;
            obj.Institution = Institution;

            $.ajax({
                async: true,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        var w = window.open("../TaskWorkFlow/ProposalAndReview", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
    }
}

function PLReview(e) {
    var w = 1020;
    var h = 600;
    var left = Number((screen.width / 2) - (w / 2));
    var top = Number((screen.height / 2) - (h / 2));

    var gridRowData = $("#gridPLMyTaskList").data("kendoGrid");
    if (gridRowData) {
        var data = gridRowData.dataItem($(e).closest("tr"));

        obj = new Object();
        obj.StudyId = data.StudyId;
        obj.ANJU_AddedBy = data.ANJU_AddedBy;
        obj.Institution = data.Institution;
        obj.TitleofTrial = data.TitleofTrial;

        $.ajax({
            async: true,
            type: "POST",
            url: "/Login/OpenNewWindow",
            data: { "obj": obj },
            success: function (results) {
                if (results.data === "Success") {
                    window.open("../TaskWorkFlow/ProgramLeaderReview", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                }
                else {
                    alert("Error");
                }
            }
        });
    }
}

function TLReview(e) {   
    var w = 1020;
    var h = 600;
    var left = Number((screen.width / 2) - (w / 2));
    var top = Number((screen.height / 2) - (h / 2));

    var gridRowData = $("#gridTLMyTaskList").data("kendoGrid");
    if (gridRowData) {
        var data = gridRowData.dataItem($(e).closest("tr"));
        var StudyId = data.StudyId;
        var Anju_Added = data.ANJU_AddedBy;
        var TaskName = data.TaskName;
        var LocalMRCDecision = data.LocalMRCDecision;
        var GlobalMRCDecision = data.GlobalMRCDecision;
        var State = data.State;
        var StudyNumber = data.StudyNumber;
        var TitleofTrial = data.TitleofTrial;
        var Institution = data.Institution;

        if (TaskName === pltaskname) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = Anju_Added;
            obj.RecordType = "LocalMRC";
            obj.Institution = Institution;
            obj.TitleofTrial = TitleofTrial;

            $.ajax({
                async: true,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        window.open("../TaskWorkFlow/RecordMRCResults", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else if (TaskName === lmrcdecisionrejectedconfirmedtaskname) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = Anju_Added;
            obj.TaskName = lmrcdecisionrejectedconfirmedtaskname;
            obj.TitleofTrial = TitleofTrial;
            obj.Institution = Institution;
            obj.StudyNumber = StudyNumber;

            if ((LocalMRCDecision === "Rejected" || LocalMRCDecision === "Conditionally Approved - Resubmission required") && State === "Review Rejection Confirmed")
                obj.RecordType = "LocalMRC";
            else
                obj.RecordType = "GlobalMRC";

            $.ajax({
                async: true,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        window.open("../TaskWorkFlow/CreateDeliverLetter", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else if (TaskName === lmrcdecisionapprovedtaskname) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = Anju_Added;
            obj.RecordType = "GlobalMRC";
            obj.TitleofTrial = TitleofTrial;
            obj.Institution = Institution;

            $.ajax({
                async: true,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        window.open("../TaskWorkFlow/RecordMRCResults", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else if (TaskName === lmrcdecisionwithdrawntaskname) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = Anju_Added;
            obj.TaskName = TaskName;
            obj.TitleofTrial = TitleofTrial;
            obj.Institution = Institution;
            obj.StudyNumber = StudyNumber;

            if (LocalMRCDecision === "Withdrawn")
                obj.RecordType = "LocalMRC";
            else
                obj.RecordType = "GlobalMRC";
            $.ajax({
                async: true,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        window.open("../TaskWorkFlow/CreateDeliverLetter", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else if (TaskName === gmrcapprovedtaskname) {

            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = Anju_Added;
            obj.TaskName = TaskName;
            obj.RecordType = "GlobalMRC";
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
                        window.open("../TaskWorkFlow/CreateDeliverLetter", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else if (TaskName === fairmarketdocument || TaskName === drugactivities || TaskName === finalActivationreview) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = Anju_Added;
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
        else if (TaskName === managecontractstatus) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = Anju_Added;
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
                        window.open("../ProtocolPhase/ManageContractStatus", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else if (TaskName === identifyactivationdocuments) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = Anju_Added;
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
                        window.open("../ProtocolPhase/IdentifyActivationDocuments", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else if (TaskName === reviewicf) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = Anju_Added;
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
                        window.open("../ProtocolPhase/ReviewICF", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else if (TaskName === reviewactivationdocuments) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = Anju_Added;
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
                        window.open("../ProtocolPhase/ReviewActivationDocument", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else if (TaskName === reviewprotocol) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = Anju_Added;
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
                        window.open("../ProtocolPhase/ReviewProtocol", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else if (TaskName === saeFinalReconciliationReportConfirmation) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = Anju_Added;
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
                        window.open("../MaintainanceAndMonitoring/MaintainanceAndMonitoring", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else if (TaskName === reviewupdateddocuments) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.StudyNumber = StudyNumber;
            obj.TitleofTrial = TitleofTrial;
            obj.ANJU_AddedBy = Anju_Added;
            obj.TaskName = TaskName;
            $.ajax({
                async: true,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        window.open("../MaintainanceAndMonitoring/ReviewAUpdatedDocument", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else if (TaskName === reviewforamendment) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = Anju_Added;
            obj.TaskName = TaskName;
            $.ajax({
                async: true,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        window.open("../MaintainanceAndMonitoring/ReviewForAmendment", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else if (TaskName === activationletter) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = Anju_Added;
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
                        window.open("../ProtocolPhase/CreateDeliverActivationLetter", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else if (TaskName === studyProfileUpdatesForAmendment) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = Anju_Added;
            obj.TaskName = TaskName;
            obj.StudyNumber = StudyNumber;
            obj.TitleofTrial = TitleofTrial;
            $.ajax({
                async: true,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        window.open("../MaintainanceAndMonitoring/MaintainanceAndMonitoring", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else if (TaskName === reviewRejectionForAmendment) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = Anju_Added;
            obj.TaskName = TaskName;
            obj.StudyNumber = StudyNumber;
            obj.TitleofTrial = TitleofTrial;
            $.ajax({
                async: true,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        window.open("../MaintainanceAndMonitoring/MaintainanceAndMonitoring", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
        else if (TaskName === documentsubmissionreview) {
            obj = new Object();
            obj.StudyId = parseInt(StudyId);
            obj.ANJU_AddedBy = Anju_Added;
            obj.TaskName = TaskName;
            obj.GMRCTaskName = TaskName;
            obj.StudyNumber = StudyNumber;
            obj.TitleofTrial = TitleofTrial;

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
            obj.TaskName = data.TaskName;
            obj.StudyNumber = StudyNumber;
            $.ajax({
                async: true,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        var w = window.open("../TaskWorkFlow/ProposalAndReview", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
    }
}

$("#tabstrip").kendoTabStrip({
    animation: {
        open: {
            effects: "fadeIn"
        }
    }
});

$("#homeTabstrip").kendoTabStrip({
    animation: {
        open: {
            effects: "fadeIn"
        }
    }
});
//Targetting for the second phase

//$("#modifyStatusMenu").click(function (e) {
//    var w = 1020;
//    var h = 600;
//    var left = Number((screen.width / 2) - (w / 2));
//    var top = Number((screen.height / 2) - (h / 2));
//      obj = new Object();
//      obj.StudyId = parseInt(StudyId);
//      obj.ANJU_AddedBy = Anju_Added;
//      obj.TaskName = TaskName;

//        $.ajax({
//            async: false,
//            type: "POST",
//            url: "/Login/OpenNewWindow",
//            data: { "obj": obj },
//            success: function (results) {
//                if (results.data === "Success") {
//                    $("#gearcontext-menu").hide();
//                    window.open("../MaintainanceAndMonitoring/ModifyStatus", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
//                }
//                else {
//                    alert("Error");
//                }
//            }
//        });
//});

$("#tabledMenu").click(function () {
    var w = 1020;
    var h = 600;
    var left = Number((screen.width / 2) - (w / 2));
    var top = Number((screen.height / 2) - (h / 2));

    obj = new Object();
    obj.StudyId = StudyId;
    obj.ANJU_AddedBy = Anju_Added;
    obj.TaskName = lmrcresumemetting;
    obj.LocalMRCRecordType = LocalMRCRecordType;
    obj.GlobalMRCRecordType = GlobalMRCRecordType;
    obj.TitleofTrial = TitleofTrial;
    obj.Institution = Institution;
    obj.StudyNumber = StudyNumber;

    $.ajax({
        async: true,
        type: "POST",
        url: "/Login/OpenNewWindow",
        data: { "obj": obj },
        success: function (results) {
            if (results.data === "Success") {
                window.open("../TaskWorkFlow/ProposalAndReview", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
            }
            else {
                alert("Error");
            }
        }
    });
});

function CloseoutTasks(taskName) {
    var w = 1020;
    var h = 600;
    var left = Number((screen.width / 2) - (w / 2));
    var top = Number((screen.height / 2) - (h / 2));

    obj = new Object();
    obj.StudyId = StudyId;
    obj.ANJU_AddedBy = Anju_Added;
    obj.TaskName = taskName;
    obj.GMRCTaskName = taskName;
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
                window.open("../StudyCloseout/StudyCloseout", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
            }
            else {
                alert("Error");
            }
        }
    });
}

$("#initiateCloseoutMenu").click(function () {
    var w = 1020;
    var h = 600;
    var left = Number((screen.width / 2) - (w / 2));
    var top = Number((screen.height / 2) - (h / 2));

    obj = new Object();
    obj.StudyId = StudyId;
    obj.ANJU_AddedBy = Anju_Added;
    obj.GMRCTaskName = initiateStudyCloseout;
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
                window.open("../StudyCloseout/StudyCloseout", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
            }
            else {
                alert("Error");
            }
        }
    });
});
//$("#initiateCloseoutMenu").click(function () {
//    obj = new Object();
//    obj.GMRCTaskName = initiateStudyCloseout;
//    CloseoutTasks(obj.GMRCTaskName);
//});