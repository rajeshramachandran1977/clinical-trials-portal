$(document).ready(function () {
    $('#globalSettingsDiv').show();
    $('#globalSettingsHelpDocDiv').hide();

    var html = '';
    var count = 0;
    var path = '';
    var firstreplace = '';

    //help tab view
    $('#helpView').hide();
    $('#help').append($('#helpView').html());

    $.ajax({
        type: "GET",
        url: "/Administration/GetGlobalSettingByKey",
        data: { "globalKey": LOGIN_PAGE_CONTENT },
        success: function (results) {
            if (results.length > 0) {
                $("#ui_txt_loginText").append(results[0].GlobalValue);
            }
        }
    });

    $('#listOfValues').load('/Administration/Administration');
    $('#metaData').load('/MetaData/MetaData');

    $(".logout").click(function () {
        window.location.href = "/Login/Logout";
    });

    $("#tabstrip").kendoTabStrip({
        animation: {
            open: {
                effects: "fadeIn"
            }
        }
    });

    $("#users").kendoTabStrip({
        dataTextField: "Name",
        tabPosition: "left",
        dataContentUrlField: "ContentUrl",
        causesvalidation: false,
        dataSource: [
            { Name: "Create New User", ContentUrl: "/Register/InternalNewUser" },
            { Name: "View/Edit User Profiles", ContentUrl: "/Register/EditInternalNewUser" }
        ],
    }).data("kendoTabStrip").select(0);

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

    $('#ui_btn_loginContentSave').on('click', function () {
        if ($('#ui_txt_loginText').val() !== "") {
            objGlobalSettings = new Object();
            objGlobalSettings.GlobalKey = LOGIN_PAGE_CONTENT;
            objGlobalSettings.GlobalValue = $("#ui_txt_loginText").val();
            objGlobalSettings.IsActive = true;
            objGlobalSettings.Anju_AddedBy = $('#LoginUsername').val();
            $.ajax({
                async: false,
                type: "POST",
                url: "/Administration/UpdateGlobalSetting",
                data: { "globalSettings": objGlobalSettings },
                success: function (results) {
                    $('#loginPageContentModal').modal('hide');
                    var grid = $("#GlobalSettinggrid").data("kendoGrid");
                    grid.dataSource.read();
                }
            });
        }
    });
});

function filterStates() {
    return {
        countryId: $("#ui_ddl_country").val()
    };
}
function filterCities() {
    return {
        stateId: $("#ui_ddl_state").val()
    };
}
function EditfilterStates() {
    return {
        countryId: $("#ui_ddl_countryEdit").val()
    };
}
function EditfilterCities() {
    return {
        stateId: $("#ui_ddl_stateEdit").val()
    };
}

var finalDocumentCheck = true;
$('#ui_btn_bannerUploadSave').click(function () {
    ValidateBannerUpload();
    if (finalDocumentCheck === true) {
        $(".k-upload-selected").click();
        $('#bannerUploadModal').modal('hide');
    }
});
function ValidateBannerUpload() {
    $(".error").remove();
    finalDocumentCheck = true;
    if ($("#files").closest(".k-upload").find(".k-file").length <= 0) {
        $('#bannerFileUpload').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
        finalDocumentCheck = false;
    }
}

$("#files").change(function () {
    $('#bannerFileUpload').next("div.error").remove();
});

$('#ui_btn_backgroundUploadSave').click(function () {
    ValidateBackgroundUpload();
    if (finalDocumentCheck === true) {
        $(".k-upload-selected").click();
        $('#backgroundUploadModal').modal('hide');
    }
});
function ValidateBackgroundUpload() {
    $(".error").remove();
    finalDocumentCheck = true;
    if ($("#loginBackgroundUpload").closest(".k-upload").find(".k-file").length <= 0) {
        $('#backgroundFileUpload').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
        finalDocumentCheck = false;
    }
}

$("#loginBackgroundUpload").change(function () {
    $('#backgroundFileUpload').next("div.error").remove();
});

var identifyUser = null;

function onDataBound(e) {
    $("#GlobalSettinggrid tbody tr .k-grid-edit").each(function () {
        var currentDataItem = $("#GlobalSettinggrid").data("kendoGrid").dataItem($(this).closest("tr"));
        if (currentDataItem.GlobalKey === EXTERNALUSERSHELPPAGE || currentDataItem.GlobalKey === INTERNALUSERSHELPPAGE || currentDataItem.GlobalKey === BANNERUPLOAD || currentDataItem.GlobalKey === BACKGROUNDUPLOAD || currentDataItem.GlobalKey === LOGIN_PAGE_CONTENT) {
            $(this).remove();
        }
    });
}

$("#ui_btn_loginContentCancel").click(function () {
    $('#loginPageContentModal').modal('hide');
})

$("#ui_btn_bannerUploadCancel").click(function () {
    $('#bannerUploadModal').modal('hide');
})

$("#ui_btn_backgroundUploadCancel").click(function () {
    $('#backgroundUploadModal').modal('hide');
})

$("#GlobalSettinggrid").on("click", "a.openModal", function () {
    $(".error").remove();
    identifyUser = $(this).data('id');
    if ($(this).data('id') === "internal") {
        $('.labeltest').text("Modify help page for internal users")
        $('#globalSettingsDiv').hide();
        $('#globalSettingsHelpDocDiv').show();
        identifyUser = "internalDocuments";
    }
    else if ($(this).data('id') === "external") {
        $('.labeltest').text("Modify help page for external users")
        $('#globalSettingsDiv').hide();
        $('#globalSettingsHelpDocDiv').show();
        identifyUser = "externalDocuments";
    }
    $("#ui_dtg_helpDocuments").data("kendoGrid").dataSource.read();
    $("#ui_dtg_helpDocuments").data("kendoGrid").refresh();
});


$('#ui_btn_helpDocumentSave').click(function () {
    ValidateMandetoryFields();
    if (finalDocumentCheck === true) {
        $(".k-upload-selected").click();
        setTimeout(function () {
            $("#ui_dtg_helpDocuments").data("kendoGrid").dataSource.read();
            $("#ui_dtg_helpDocuments").data("kendoGrid").refresh();
        }, 500);
        $(".k-upload-files").remove();
        $(".k-upload-status").remove();
        $(".k-upload.k-header").addClass("k-upload-empty");
        $(".k-upload-button").removeClass("k-state-focused");
    }
    else {
        popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
    }

}).on('mouseup', function () {
    $("#ui_dtg_helpDocuments").data("kendoGrid").dataSource.read();
    $("#ui_dtg_helpDocuments").data("kendoGrid").refresh();
});
function ValidateMandetoryFields() {
    $(".error").remove();
    finalDocumentCheck = true;
    if ($("#helpFiles").closest(".k-upload").find(".k-file").length <= 0) {
        $('#helpUpload').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
        finalDocumentCheck = false;
    }
}

$("#helpFiles").change(function () {
    $('#helpUpload').next("div.error").remove();
});

$('#ui_btn_back').on('click', function () {
    $('#globalSettingsDiv').show();
    $('#globalSettingsHelpDocDiv').hide();
    $(".k-upload-files").remove();
    $(".k-upload-status").remove();
    $(".k-upload.k-header").addClass("k-upload-empty");
    $(".k-upload-button").removeClass("k-state-focused");
})

function additionalDocumentInfo() {
    return {
        studyId: 0,
        subModuleName: identifyUser
    };
}

function ShowDocument(e) {
    var gridRowData = $("#ui_dtg_helpDocuments").data("kendoGrid");
    if (gridRowData) {
        var data = gridRowData.dataItem($(e).closest("tr"));
        var subModuleFolderName = "CommonDocuments";
        var fileName = data.DocumentNameWithOutExtension + data.DocumentExtension;
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=0';
    }
}

$("#GlobalSettinggrid").on("click", "a.openLoginPageModal", function () {
    $('#loginPageContentModal').modal('show');
})
$("#GlobalSettinggrid").on("click", "a.openBannerUploadModal", function () {
    $('#bannerUploadModal').modal('show');
})
$("#GlobalSettinggrid").on("click", "a.openBackgroundUploadModal", function () {
    $('#backgroundUploadModal').modal('show');
})

function onUpload(e) {
    e.data = {};
    e.data["additional[0]"] = identifyUser;
}

function OnCreateUpdateModal(e) {
    $('#GlobalSettinggrid').data('kendoGrid').refresh();
}

function OnGlobalSettingsaveChanges(e) {
    var grid = null;
    switch (e.type) {
        case "create":
            grid = $("#GlobalSettinggrid").data("kendoGrid");
            grid.dataSource.read();
            break;
        case "update":
            grid = $("#GlobalSettinggrid").data("kendoGrid");
            grid.dataSource.read();
            break;
        case "destroy":
            grid = $("#GlobalSettinggrid").data("kendoGrid");
            grid.dataSource.read();
            break;
    }
}

//function onEdit(e) {
//    if (e.model.GlobalKey == "EMAIL_DEFAULT_POSTBOX") {

//    }
//}

//(function ($, kendo) {
//    $.extend(true, kendo.ui.validator, {
//        rules: { // custom rules
//            emailvalidation: function (input) {
//                //check if it is the Email field
//                if (input.is("[name=GlobalValue]") && input.val()) {
//                    input.attr("data-emailvalidation-msg", "Invalid Email");
//                    var expr = (/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);
//                    return expr.test(input.val());
//                }
//                return true;
//            }
//        }
//    });
//})(jQuery, kendo);

////show server errors if any
//function error_handler(e) {
//    if (e.errors) {
//        var message = "Errors:\n";
//        $.each(e.errors, function (key, value) {
//            if ('errors' in value) {
//                $.each(value.errors, function () {
//                    message += this + "\n";
//                });
//            }
//        });
//    }
//}

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