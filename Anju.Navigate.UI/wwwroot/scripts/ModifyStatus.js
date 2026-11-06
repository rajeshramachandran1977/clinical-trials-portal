function onCancel() {
    window.close();
}

function filterDocumentSubType() {
    return {
        documentTypeId: $("#ui_ddl_documentType").val()
    };
}

function additionalInfo() {
    return {
        studyId: $('#StudyId').val(),
        subModuleName: "ModifyStatusSupportDocuments"
    };
}

function onSelect(e) {
    var src = $("#uploadfiles").val();
    $(this).next("div.error").remove();

    $.each(e.files, function (index, value) {
        $("#ui_txt_documentName").val(value.name);
    });
}

function onUpload(e) {
    e.data = {};
    e.data["additional[0]"] = $("#ui_txt_documentName").val();
    e.data["additional[1]"] = $('#ui_ddl_documentStatus').val();
    e.data["additional[2]"] = $('#ui_ddl_documentType').data("kendoDropDownList").text();
    e.data["additional[3]"] = $('#ui_ddl_documentSubType').val();
    e.data["additional[4]"] = $('#ui_ddl_version').val();
    e.data["additional[5]"] = $('#ui_dt_originalDate').val() !== '' ? $('#ui_dt_originalDate').val() : ' ';
    e.data["additional[6]"] = $('#ui_dt_expiryDate').val() !== '' ? $('#ui_dt_expiryDate').val() : ' ';
}

function onremove(e) {
    $("#ui_txt_documentName").val("");
}

function onsuccess(e) {
    $.each(e.files, function (index, value) {
        $("#ui_txt_documentName").val(value.name);
    });
}

$('#ui_btn_submit').click(function () {
    ValidateMandatoryFields();
    SaveModifyStatus();
});

var retVal = true;
function ValidateMandatoryFields() {
    $('.error').remove();
    retVal = true;
    if ($('#ui_ddl_studyStatus').val() === "Select" || $('#ui_ddl_studyStatus').val() === "") {
        $('#studyStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Study Status</div>');
        retVal = false;
    }
    if ($('#ui_ddl_reasonForStatusChange').val() === "Select" || $('#ui_ddl_reasonForStatusChange').val() === "") {
        $('#reasonForStatusChange').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Reason for Status Change</div>');
        retVal = false;
    }
}

$('#ui_ddl_studyStatus').change(function () {
    $('#studyStatus').next("div.error").remove();
});
$('#ui_ddl_reasonForStatusChange').change(function () {
    $('#reasonForStatusChange').next("div.error").remove();
});

function SaveModifyStatus() {
    if ($('#ui_ddl_studyStatus').val() === "Cancelled") {
        $('#myModal').modal('show');
    } else {
        SaveValuesToModifyStatus();
    }  
}

function SaveValuesToModifyStatus() {
    if (retVal) {
        objModifyStatus = new Object();
        objModifyStatus.StudyId = $('#StudyId').val();
        objModifyStatus.StudyStatus = $('#ui_ddl_studyStatus').val();
        objModifyStatus.StatusChangeReason = $('#ui_ddl_reasonForStatusChange').val();
        objModifyStatus.ANJU_ChangedBy = $('#LogedinUserName').val();
        $.ajax({
            async: false,
            type: "POST",
            url: "/MaintainanceAndMonitoring/UpdateModifyStatusDetails",
            data: { "maintainanceAndMonitoring": objModifyStatus },
            success: function (results) {
                if (results.msgType === "Success") {
                    opener.location.reload();
                    window.close();
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
function test() {
    if ($('#ui_ddl_studyStatus').val() === "Cancelled") {
        $('#myModal').modal('show');
    }

}
$('#ui_btn_documentSubmit').click(function () {
    ValidateDocumentMandatoryFields();
    if (retVal === true) {
        $(".k-upload-selected").click();
        $(".k-upload-files").remove();
        $(".k-upload-status").remove();
        $(".k-upload.k-header").addClass("k-upload-empty");
        $(".k-upload-button").removeClass("k-state-focused");
        $("#docModal").modal("hide");
        $("#frm_documentDetails")[0].reset();
        $("#ui_frm_documentForm")[0].reset();
        setTimeout(function () {
            $("#ui_dtg_modifyStatusDocuments").data("kendoGrid").dataSource.read();
            $("#ui_dtg_modifyStatusDocuments").data("kendoGrid").refresh();
        }, 1000);
    }
    else {
        popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
    }
}).on('mouseup', function () {
    $("#ui_dtg_modifyStatusDocuments").data("kendoGrid").dataSource.read();
    $("#ui_dtg_modifyStatusDocuments").data("kendoGrid").refresh();
});

function ValidateDocumentMandatoryFields() {
    $(".error").remove();
    retVal = true;
    if ($("#uploadfiles").closest(".k-upload").find(".k-file").length <= 0) {
        $('#fileUpload').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload a document</div>');
        retVal = false;
    }
    if ($("#ui_txt_documentName").val() === null || $("#ui_txt_documentName").val() === "") {
        $("#documentName").after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>The required field Document Name has not been filled in.</div>');
        retVal = false;
    }
    if ($("#ui_ddl_documentStatus").val() === "Select" || $("#ui_ddl_documentStatus").val() === "") {
        $("#documentStatus").after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Document Status</div>');
        retVal = false;
    }
    if ($("#ui_ddl_documentType").val() === "Select" || $("#ui_ddl_documentType").val() === "") {
        $("#documentType").after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Document Type</div>');
        retVal = false;
    }
    if ($("#ui_ddl_documentType").val() !== "Select" || $("#ui_ddl_documentType").val() !== "") {
        if ($("#ui_ddl_documentSubType").val() === "Select" || $("#ui_ddl_documentSubType").val() === "") {
            $("#documentSubType").after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Document Sub-Type</div>');
            retVal = false;
        }
    }
    if ($("#ui_ddl_version").val() === "Select" || $("#ui_ddl_version").val() === "") {
        $("#version").after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Original / Amendment Version</div>');
        retVal = false;
    }
}
$("#uploadfiles").change(function () {
    $("#fileUpload").next("div.error").remove();
    $("#documentName").next("div.error").remove();
});
$("#ui_txt_documentName").on("keyup", function () {
    $("#documentName").next("div.error").remove();
});
$("#ui_ddl_documentStatus").change(function () {
    $("#documentStatus").next("div.error").remove();
});
$("#ui_ddl_documentType").change(function () {
    $("#documentType").next("div.error").remove();
});
$("#ui_ddl_documentSubType").change(function () {
    $("#documentSubType").next("div.error").remove();
});
$("#ui_ddl_version").change(function () {
    $("#version").next("div.error").remove();
});
function filterEditDocumentSubType() {
    return {
        documentTypeId: $("#ui_ddl_editdocumentType").val()
    };
}
$("#ui_btn_documentCancel").click(function () {
    $("#docModal").modal("hide");
    $("#frm_documentDetails")[0].reset();
});
function Show(e) {
    var gridRowData = $("#ui_dtg_modifyStatusDocuments").data("kendoGrid");
    if (gridRowData) {
        var data = gridRowData.dataItem($(e).closest("tr"));
        var subModuleFolderName = data.SubModuleName;
        var fileName = data.DocumentNameWithOutExtension + data.DocumentExtension;
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + $('#StudyId').val();
    }
}
var detailsTemplate = kendo.template($("#template").html());
function showDetails(e) {
    e.preventDefault();
    var grid = $("#ui_dtg_modifyStatusDocuments").getKendoGrid();
    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    var wnd = $("#Details").data("kendoWindow");
    wnd.content(detailsTemplate(dataItem));
    wnd.center().open();

    //Fill document window
    var retVal = true;
    $("#ui_txt_editdocumentName").val(dataItem.DocumentName);
    $("#ui_ddl_editdocumentStatus").data('kendoDropDownList').value(dataItem.DocumentStatus);
    $("#ui_ddl_editdocumentType").data('kendoDropDownList').value(dataItem.DocumentTypeId);
    $("#ui_ddl_editdocumentSubType").data('kendoDropDownList').value(dataItem.DocumentSubType);
    $("#ui_ddl_amendmentVersion").data('kendoDropDownList').value(dataItem.DocumentVersion);
    $("#ui_dt_editoriginalDate").data("kendoDatePicker").value(dataItem.OriginalDate);
    $("#ui_dt_editexpirationDate").data("kendoDatePicker").value(dataItem.ExpirationDate);

    var fileName = dataItem.DocumentNameWithOutExtension + dataItem.DocumentExtension;
    var DocumentNameWithOutExtension = dataItem.DocumentNameWithOutExtension;
    var DocumentExtension = dataItem.DocumentExtension;
    var subModuleFolderName = dataItem.SubModuleName;
    var studyId = dataItem.StudyId;
    var documentId = dataItem.DocumentId;

    $('.fileDownload').click(function () {
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + studyId;
    });

    $("#btn-editDocumentSubmit").click(function () {
        ValidateEditMandetoryFields();
        if (retVal === true) {
            UpdateDcouemntDetails();
        }
        else {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });

    $("#btn-editDocumentCancel").click(function () {
        $("#Details").data("kendoWindow").close();
    });

    function ValidateEditMandetoryFields() {
        retVal = true;
        $(".error").remove();

        if ($("#ui_txt_editdocumentName").val() === "" || $("#ui_txt_editdocumentName").val() === null) {
            $('#editDocumentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name is required</div>');
            retVal = false;
        }

        if ($('#ui_ddl_editdocumentStatus').val() === 'Select' || $('#ui_ddl_editdocumentStatus').val() === "") {
            $('#editDocumentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Status is required</div>');
            retVal = false;
        }
        if ($('#ui_ddl_editdocumentType').val() === 'Select' || $('#ui_ddl_editdocumentType').val() === "") {
            $('#editDocumentType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Type is required</div>');
            retVal = false;
        }
        if ($('#ui_ddl_editdocumentType').val() !== 'Select' || $('#ui_ddl_editdocumentType').val() !== "") {
            if ($('#ui_ddl_editdocumentSubType').val() === 'Select' || $('#ui_ddl_editdocumentSubType').val() === "") {
                $('#editDocumentSubType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Sub-Type is required</div>');
                retVal = false;
            }
        }
        if ($('#ui_ddl_amendmentVersion').val() === 'Select' || $('#ui_ddl_amendmentVersion').val() === "") {
            $('#amendmentVersion').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Version is required</div>');
            retVal = false;
        }
    }

    $("#ui_txt_editdocumentName").on("keyup", function (e) {
        $('#editDocumentName').next("div.error").remove();
    });
    $("#ui_ddl_editdocumentStatus").change(function () {
        $('#editDocumentStatus').next("div.error").remove();
    });
    $("#ui_ddl_editdocumentType").change(function () {
        $('#editDocumentType').next("div.error").remove();
    });
    $("#ui_ddl_editdocumentSubType").change(function () {
        $('#editDocumentSubType').next("div.error").remove();
    });
    $("#ui_ddl_amendmentVersion").change(function () {
        $('#amendmentVersion').next("div.error").remove();
    });

    function UpdateDcouemntDetails() {
        if (retVal === true) {
            objDocumentDetails = new Object();
            objDocumentDetails.DocumentId = documentId;
            objDocumentDetails.StudyId = $('#StudyId').val();
            objDocumentDetails.SubModuleName = subModuleFolderName;
            objDocumentDetails.DocumentName = $("#ui_txt_editdocumentName").val();
            objDocumentDetails.DocumentNameWithOutExtension = DocumentNameWithOutExtension;
            objDocumentDetails.DocumentExtension = DocumentExtension;
            objDocumentDetails.DocumentStatus = $('#ui_ddl_editdocumentStatus').data("kendoDropDownList").text();
            objDocumentDetails.DocumentType = $('#ui_ddl_editdocumentType').data("kendoDropDownList").text();
            objDocumentDetails.DocumentSubType = $('#ui_ddl_editdocumentSubType').data("kendoDropDownList").text();
            objDocumentDetails.DocumentVersion = $('#ui_ddl_amendmentVersion').data("kendoDropDownList").text();
            objDocumentDetails.OriginalDate = $("#ui_dt_editoriginalDate").val();
            objDocumentDetails.ExpirationDate = $("#ui_dt_editexpirationDate").val();
            objDocumentDetails.ANJU_ChangedBy = $('#LogedinUserName').val();
            $.ajax({
                async: false,
                type: "POST",
                url: "/TaskWorkFlow/UpdateDocumentDetails",
                data: { "documents": objDocumentDetails },
                success: function (results) {
                    if (results.msgType === "Success") {
                        $("#ui_dtg_modifyStatusDocuments").data("kendoGrid").dataSource.read();
                        $("#ui_dtg_modifyStatusDocuments").data("kendoGrid").refresh();
                        $("#Details").data("kendoWindow").close();

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
}

$(document).ready(function () {
    $('#ui_btn_newStudy').attr("disabled", true);    
    $('#myModal').modal('hide');

    $.ajax({
        async: false,
        type: "POST",
        url: '/NewStudy/GetTitleOfTrialByStudyID',
        data: { "studyId": $('#StudyId').val() },
        success: function (result) {
            if (result !== "") {
                $("#studyIdAndTitleOfTrial").append(': ' + result);
            }
        }
    });
    $.ajax({
        async: false,
        type: "POST",
        url: '/NewStudy/GetChangedInstituteBystudyId',
        data: { "studyId": $('#StudyId').val() },
        success: function (result) {
            if (result !== "") {
                $("#instituteSubmitted").append(", " + result);
            }
        }
    });
    $("#ui_dtg_modifyStatusDocuments").data("kendoGrid").dataSource.read();
    $("#ui_dtg_modifyStatusDocuments").data("kendoGrid").dataSource.fetch();
    $("#ui_dtg_modifyStatusDocuments").data("kendoGrid").refresh();
});

$("#modalCheckBox").click(function () {
    $("#ui_btn_newStudy").attr("disabled", !this.checked);    
});

$("#ui_btn_newStudy").click(function () {
    SaveValuesToModifyStatus();
});