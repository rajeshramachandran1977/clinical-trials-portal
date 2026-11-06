//function OnDataBoundforDocuments() {
//    $.ajax({
//        async: true,
//        type: "GET",
//        url: "/NewStudy/GetAttributeValues/",
//        data: { attributeid: parseInt(documentsattributeid) },
//        cache: false,
//        dataType: "json",
//        success: function (response) {
//            if (response.Data == '') {
//                popupNotification.show(errorsinthepage, "error");
//            } else {
//                var grid = $("#ui_dtg_Documents").data("kendoGrid");
//                var isdeleterestricted = false;
//                for (i = 0; i < response.length; i++) {
//                    if (response[i].RestrictDeleteUser != null) {
//                        var restrictdeleteArray = response[i].RestrictDeleteUser.split(',');
//                        for (var j = 0; j < restrictdeleteArray.length; j++) {
//                            if (restrictdeleteArray[j] == $('#UserType').val()) {
//                                isdeleterestricted = true;
//                                break;
//                            }
//                            else
//                                isdeleterestricted = false;
//                            if (isdeleterestricted == true)
//                                break;
//                        }
//                        if (isdeleterestricted == true)
//                            break;
//                    }
//                }
//                if (isdeleterestricted == true)
//                    grid.hideColumn(13);
//                else
//                    grid.showColumn(13);

//                var iseditrestricted = false;
//                var iseditredtrictedattablevel = false;
//                for (i = 0; i < response.length; i++) {
//                    if (response[i].RestrictEditUser != null) {
//                        var restricteditArray = response[i].RestrictEditUser.split(',');
//                        for (var j = 0; j < restricteditArray.length; j++) {
//                            if (restricteditArray[j] == $('#UserType').val()) {
//                                iseditrestricted = true;
//                                if (response[i].Type == "Tab")
//                                    iseditredtrictedattablevel = true;
//                                break;
//                            }
//                            else
//                                iseditrestricted = false;
//                            if (iseditrestricted == true)
//                                break;
//                        }
//                        if (iseditrestricted == true)
//                            break;
//                    }
//                }
//                if (iseditrestricted == true) {
//                    if (iseditredtrictedattablevel == true)
//                        grid.hideColumn(12);
//                    return false;
//                }
//                else {
//                    grid.showColumn(12);
//                    return false;
//                }
//            }
//        },
//        failure: function (response) {
//            popupNotification.show(errorsinthepage, "error");
//        }
//    });
    
//    var grid = $("#ui_dtg_Documents").data("kendoGrid");
//    var trs = this.tbody.find('tr').each(function () {
//        var item = grid.dataItem($(this));
//        if (item.DocumentStatus == "Pending Review") {
//            $(this).find('.ui_delete').attr("disabled", true);
//            $(this).find('.ui_undelete').attr("disabled", true);
//            return;
//        }
//        if (item.IsActive == true && item.IsDeleted == false) {
//            $(this).find('.ui_delete').removeAttr("disabled");
//            $(this).find('.ui_undelete').attr("disabled", true);
//            return;
//        }
//        if (item.IsActive == false && item.IsDeleted == true) {
//            $(this).find('.ui_delete').attr("disabled", true);
//            $(this).find('.ui_undelete').removeAttr("disabled");
//            return;
//        }
//    });     
//}

//#region delete row functions in grids
function deleteDocuments(e) {
    e.preventDefault ? e.preventDefault() : e.returnValue = false;
    $(document).ready(function () {
        wnd = $("#modalWindow").kendoWindow({
            title: deleteMsg,
            modal: true,
            visible: false,
            resizable: false,
            width: 400
        }).data("kendoWindow");
    });
    var grid = $("#ui_dtg_Documents").data("kendoGrid"); //Get the grid from which the pop-up is coming
    var tr = $(e.target).closest("tr"); //get the row for deletion
    var data = this.dataItem(tr);
    wnd.center().open();

    $("#ui_btn_yes").click(function () {
        grid.dataSource.remove(data);
        grid.dataSource.sync();
        wnd.close();
    });
    $("#ui_btn_no").click(function () {
        wnd.close();
    });
}
//#endregion

//function UndeleteDocuments() {
//    e.preventDefault();
//    var currentDataItem = $("#ui_dtg_Documents").data("kendoGrid").dataItem($(e.currentTarget).closest("tr"));
//    var docid = currentDataItem.DocumentId;
//    var studyid = currentDataItem.StudyId;
//    $.ajax({
//        async: true,
//        type: "GET",
//        url: "/NewStudy/UndeleteDocuments/",
//        data: { docid: parseInt(docid), studyid: parseInt(studyid) },
//        cache: false,
//        dataType: "json",        
//        success: function (response) {
//            if (response.Data == '') {
//                popupNotification.show(errorsinthepage, "error");
//            } else {
//                $("#ui_dtg_Documents").data("kendoGrid").dataSource.read();
//                $("#ui_dtg_Documents").data("kendoGrid").refresh();
//            }
//        },
//        failure: function (response) {
//            popupNotification.show(errorsinthepage, "error");
//        }
//    });
//}

$("#ui_btnSaveDocumentsaddmode").click(function () {
    ValidateDocumentsFields();
    if (retval === true) {
        $(".k-upload-selected").click();
        $("#addNotificationDocModal").modal("hide");
        $("#ui_dtg_Documents").data("kendoGrid").dataSource.read();
        $("#ui_dtg_Documents").data("kendoGrid").refresh();
    }
});

$("#ui_btnSaveDocumentseditmode").click(function () {
    ValidateDocumentsFieldsEditMode();
    if (retval === true) {
        $(".k-upload-selected").click();
        $("#Documents").data("kendoWindow").close();
        $("#ui_dtg_Documents").data("kendoGrid").dataSource.read();
        $("#ui_dtg_Documents").data("kendoGrid").refresh();
    }
});

function addDocuments() {
    var username = $('#Username').val();
    $("#ui_lbl_uploadedperson").html(username);
    $("#ui_lbl_uploadeddate").html(kendo.toString(kendo.parseDate(new Date()), 'MMM dd, yyyy'));

    $("#uploadfiles").change(function () {
        $('#documentname').next("div.error").remove();
    });
    $("#ui_ddl_documentStatus").change(function () {
        $('#documentstatus').next("div.error").remove();
    });
    $("#ui_ddl_amendmentVersion").change(function () {
        $('#amendmentversion').next("div.error").remove();
    });
    $("#ui_ddl_documentType").change(function () {
        $('#documenttype').next("div.error").remove();
    });
    
    LoadDocumentsAttributes("Create");
}

//function ShowDocuments(e) {
//    var gridRowData = $("#ui_dtg_Documents").data("kendoGrid");
//    if (gridRowData) {
//        var data = gridRowData.dataItem($(e).closest("tr"));
//        var subModuleFolderName = data.SubModuleName;
//        var fileName = data.DocumentNameWithOutExtension + data.DocumentExtension;
//        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + $('#StudyId').val();
//    }
//}

function LoadDocumentsAttributes(mode) {
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(documentsattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case generaldetailsdocument:
                            Label(response, "displayDocumentname", "ui_lbl_documentname", "", "isdocumentname", mode);
                            break;
                        case documentsdocstatus:
                            DropDowndetails(response, "displaydocumentStatus", "ui_lbl_documentstatus", "", "isdocumentstatus", mode);
                            break;
                        case documentamendmentversion:
                            DropDowndetails(response, "displayAmendmentversion", "ui_lbl_amendmentversion", "", "isamendmentversion", mode);
                            break;
                        case documentdoctype:
                            DropDowndetails(response, "displayDocumenttype", "ui_lbl_documenttype", "", "isdocumenttype", mode);
                            break;
                        case documentdocsubtype:
                            DropDowndetails(response, "displayDocumentsubtype", "ui_lbl_documentsubtype", "", "isdocumentsubtype", mode);
                            break;
                        case documentsource:
                            Label(response, "displayDocumentsource", "ui_lbl_documentsource", "", "isdocumentsource", mode);
                            break;
                        case uploadedby:
                            Label(response, "displayUploadedby", "ui_lbl_uploadedby", "", "isuploadedby", mode);
                            break;
                        case documentdate:
                            DropDowndetails(response, "displayDateofupload", "ui_lbl_dateofupload", "", "isdateofupload", mode);
                            break;
                        case originaldate:
                            DropDowndetails(response, "displayOriginaldate", "ui_lbl_originaldate", "", "isoriginaldate", mode);
                            break;
                        case expirationdate:
                            DropDowndetails(response, "displayExpirationdate", "ui_lbl_expirationdate", "", "isexpirationdate", mode);
                            break;
                        default:
                            break;
                    }
                }
            }
        },
        failure: function (response) {
            popupNotification.show(errorsinthepage, "error");
        }
    });
}

function LoadDocumentsAttributesEditMode(mode) {
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(documentsattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case generaldetailsdocument:
                            Label(response, "displayDocumentnameeditmode", "ui_lbl_documentnameeditmode", "", "isdocumentname", mode);
                            break;
                        case documentsdocstatus:
                            DropDowndetails(response, "displaydocumentStatuseditmode", "ui_lbl_documentstatuseditmode", "", "isdocumentstatus", mode);
                            break;
                        case documentamendmentversion:
                            DropDowndetails(response, "displayAmendmentversioneditmode", "ui_lbl_amendmentversioneditmode", "", "isamendmentversion", mode);
                            break;
                        case documentdoctype:
                            DropDowndetails(response, "displayDocumenttypeeditmode", "ui_lbl_documenttypeeditmode", "", "isdocumenttype", mode);
                            break;
                        case documentdocsubtype:
                            DropDowndetails(response, "displayDocumentsubtypeeditmode", "ui_lbl_documentsubtypeeditmode", "", "isdocumentsubtype", mode);
                            break;
                        case documentsource:
                            Label(response, "displayDocumentsourceeditmode", "ui_lbl_documentsourceeditmode", "", "isdocumentsource", mode);
                            break;
                        case uploadedby:
                            Label(response, "displayUploadedbyeditmode", "ui_lbl_uploadedbyeditmode", "", "isuploadedby", mode);
                            break;
                        case documentdate:
                            DropDowndetails(response, "displayDateofuploadeditmode", "ui_lbl_dateofuploadeditmode", "", "isdateofupload", mode);
                            break;
                        case originaldate:
                            DropDowndetails(response, "displayOriginaldateeditmode", "ui_lbl_originaldateeditmode", "", "isoriginaldate", mode);
                            break;
                        case expirationdate:
                            DropDowndetails(response, "displayExpirationdateeditmode", "ui_lbl_expirationdateeditmode", "", "isexpirationdate", mode);
                            break;
                        default:
                            break;
                    }
                }
            }
        },
        failure: function (response) {
            popupNotification.show(errorsinthepage, "error");
        }
    });
}

$(document).ready(function () {
    
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(documentsattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case documentstab:
                            var iscreaterestricted = false;
                            if (response[i].RestrictCreateUser != null) {
                                var restrictcreateUserArray = response[i].RestrictCreateUser.split(',');
                                for (var j = 0; j < restrictcreateUserArray.length; j++) {
                                    if (restrictcreateUserArray[j] == $('#UserType').val()) {
                                        iscreaterestricted = true;
                                        break;
                                    }
                                    else
                                        iscreaterestricted = false;
                                    if (iscreaterestricted == true)
                                        $("#ui_btn_AddDocuments").attr("disabled", true);
                                }
                                if (iscreaterestricted == true)
                                    $("#ui_btn_AddDocuments").attr("disabled", true);
                            }
                            if (iscreaterestricted == true)
                                $("#ui_btn_AddDocuments").attr("disabled", true);
                            else
                                $("#ui_btn_AddDocuments").removeAttr("disabled");
                            break;                        
                        default:
                            break;
                    }
                }
            }
        },
        failure: function (response) {
            popupNotification.show(errorsinthepage, "error");
        }
    });
});
