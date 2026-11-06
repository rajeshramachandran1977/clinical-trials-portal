function onCancel() {
    window.close();
}

function onSelectfinalupload(e) {
    var src = $("#uploadFilesFinal").val();
    $(this).next("div.error").remove();
    $.each(e.files, function (index, value) {
        documentName = $("#ui_txt_documentNameFinal").val(value.name);
    });
}

function onremovefinalupload(e) {
    $("#ui_txt_documentNameFinal").val("");
}

function onsuccessfinalupload(e) {
    $(".k-upload-files.k-reset").find("li").remove();
}

var finaluploadName = "";

function onUploadfinalupload(e) {

    $.each(e.files, function (index, value) {
        finaluploadName = value.name;
        if ($("#ui_txt_documentNameFinal").val() === "")
            $("#ui_txt_documentNameFinal").val(value.name);
    });

    e.data = {};
    e.data["additional[0]"] = $("#ui_txt_documentNameFinal").val();
    e.data["additional[1]"] = $('#ui_ddl_documentStatusFinal').val();
    e.data["additional[2]"] = $('#ui_lbl_documentSubTypeFinal').text();
    e.data["additional[3]"] = "";
    e.data["additional[4]"] = $('#ui_ddl_versionFinal').val();
    e.data["additional[5]"] = $('#ui_dt_originalDateFinal').val() !== '' ? $('#ui_dt_originalDateFinal').val() : ' ';
    e.data["additional[6]"] = $('#ui_dt_expiryDateFinal').val() !== '' ? $('#ui_dt_expiryDateFinal').val() : ' ';
    e.data["additional[7]"] = $('#LogedinUserName').val();

    if ($("#TaskName").val() === "Create/Deliver Activation Letter") {
        e.data["additional[8]"] = "StudyActivationDocument";
    }
}

function filterDocumentSubType() {
    return {
        documentTypeId: $("#ui_ddl_documentType").val()
    };
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
    e.data["additional[7]"] = $('#LogedinUserName').val();
    e.data["additional[8]"] = $("#TaskName").val();

}

function onSelect(e) {
    var src = $("#uploadFiles").val();
    $(this).next("div.error").remove();
    $.each(e.files, function (index, value) {
        $("#ui_txt_documentName").val(value.name);
    });
}

function onremove(e) {
    $("#ui_txt_documentName").val("");
}

function additionalInfo() {
    if ($("#TaskName").val() === "Create/Deliver Activation Letter") {
        return {
            studyId: $('#StudyId').val(),
            subModuleName: "StudyActivationAdditionalDocuments"
        };
    }

}

function filterEditDocumentSubType() {
    return {
        documentTypeId: $("#ui_ddl_editdocumentType").val()
    };
}

function Show(e) {
    var gridRowData = $("#ui_dtg_activationLetterDocuments").data("kendoGrid");
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
    var grid = $("#ui_dtg_activationLetterDocuments").getKendoGrid();

    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    var wnd = $("#Details").data("kendoWindow");
    wnd.content(detailsTemplate(dataItem));
    wnd.center().open();

    //Fill document window   
    var retval = true;

    $("#ui_txt_editdocumentName").val(dataItem.DocumentName);
    $("#ui_ddl_editdocumentStatus").data('kendoDropDownList').value(dataItem.DocumentStatus);
    $("#ui_ddl_editdocumentType").data('kendoDropDownList').value(dataItem.DocumentTypeId);
    $("#ui_ddl_editdocumentSubType").data('kendoDropDownList').value(dataItem.DocumentSubType);
    $("#ui_ddl_amendmentVersion").data('kendoDropDownList').value(dataItem.DocumentVersion);
    $("#ui_dt_editoriginalDate").data("kendoDatePicker").value(dataItem.OriginalDate);
    $("#ui_dt_editExpirationDate").data("kendoDatePicker").value(dataItem.ExpirationDate);

    var fileName = dataItem.DocumentNameWithOutExtension + dataItem.DocumentExtension;
    var DocumentNameWithOutExtension = dataItem.DocumentNameWithOutExtension;
    var DocumentExtension = dataItem.DocumentExtension;
    var subModuleFolderName = dataItem.SubModuleName;
    var studyId = dataItem.StudyId;
    var documentId = dataItem.DocumentId;

    $('.fileDownload').click(function () {
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + studyId;
    });

    $("#ui_btn_editDocumentSubmit").click(function () {
        ValidateEditMandetoryFields();
        if (retval === true) {
            UpdateDocumentDetails();
        }
        else {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });

    $("#ui_btn_editDocumentCancel").click(function () {
        $("#Details").data("kendoWindow").close();
    });

    function ValidateEditMandetoryFields() {
        retval = true;
        $(".error").remove();

        if ($('#ui_txt_editdocumentName').val() === "") {
            $('#editDocumentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name is required</div>');
            retval = false;
        }
        if ($('#ui_ddl_editdocumentStatus').val() === 'Select' || $('#ui_ddl_editdocumentStatus').val() === "") {
            $('#editDocumentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Status is required</div>');
            retval = false;
        }
        if ($('#ui_ddl_editdocumentStatus').val() === 'Pending Review') {
            $('#editDocumentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document should be reviewed, Please change the Document Status from Pending Review</div>');
            retval = false;
        }
        if ($('#ui_ddl_editdocumentType').val() === 'Select' || $('#ui_ddl_editdocumentType').val() === "") {
            $('#editDocumentType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Type is required</div>');
            retval = false;
        }
        if ($('#ui_ddl_editdocumentType').val() !== 'Select' || $('#ui_ddl_editdocumentType').val() !== "") {
            if (($('#ui_ddl_editdocumentSubType').val() === 'Select' || $('#ui_ddl_editdocumentSubType').val() === "") && $('#editDocumentSubTypeLabel').hasClass("mandatory")) {
                $('#editDocumentSubType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document SubType is required</div>');
                retval = false;
            }
        }
        if ($('#ui_ddl_amendmentVersion').val() === 'Select' || $('#ui_ddl_amendmentVersion').val() === "") {
            $('#amendmentVersion').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Version is required</div>');
            retval = false;
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
    function UpdateDocumentDetails() {
        if (retval === true) {
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
            objDocumentDetails.ExpirationDate = $("#ui_dt_editExpirationDate").val();
            objDocumentDetails.ANJU_ChangedBy = $('#LogedinUserName').val();
            $.ajax({
                async: false,
                type: "POST",
                url: "/TaskWorkFlow/UpdateDocumentDetails",
                data: { "documents": objDocumentDetails },
                success: function (results) {
                    if (results.msgType === "Success") {
                        $("#ui_dtg_activationLetterDocuments").data("kendoGrid").dataSource.read();
                        $("#ui_dtg_activationLetterDocuments").data("kendoGrid").refresh();
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

function onSubTypeDataBound(e) {
    if ($("#ui_ddl_documentSubType").data("kendoDropDownList").dataSource._data.length > 0) {
        $("#ui_ddl_documentSubType").data("kendoDropDownList").enable(true);
        $('#documentSubTypeLabel').addClass("mandatory");
    }
    else {
        $("#ui_ddl_documentSubType").data("kendoDropDownList").enable(false);
        $('#documentSubTypeLabel').removeClass("mandatory");
        $('#documentSubType').next("div.error").remove();
    }
}

function onDocumentTypeChange() {
    if ($("#ui_ddl_documentType").data("kendoDropDownList").value() === "") {
        $('#documentSubTypeLabel').removeClass("mandatory");
        $('#documentSubType').next("div.error").remove();
    }
}

function onEditSubTypeDataBound(e) {
    if ($("#ui_ddl_editdocumentSubType").data("kendoDropDownList").dataSource._data.length > 0) {
        $("#ui_ddl_editdocumentSubType").data("kendoDropDownList").enable(true);
        $('#editDocumentSubTypeLabel').addClass("mandatory");
    }
    else {
        $("#ui_ddl_editdocumentSubType").data("kendoDropDownList").enable(false);
        $('#editDocumentSubTypeLabel').removeClass("mandatory");
        $('#editDocumentSubType').next("div.error").remove();
    }
}

function onEditDocumentTypeChange() {
    if ($("#ui_ddl_editdocumentType").data("kendoDropDownList").value() === "") {
        $('#editDocumentSubTypeLabel').removeClass("mandatory");
        $('#editDocumentSubType').next("div.error").remove();
    }
}

$(document).ready(function () {
    $("#btn_RemoveDocument").hide();
    $("#finalNotificationDownload").hide();

    $("#ui_dtg_activationLetterDocuments").data("kendoGrid").dataSource.read();
    var retval = true;
    var finalDocumentCheck = true;
    var activationDate;
    $.ajax({
        async: false,
        type: "POST",
        url: '/MaintainanceAndMonitoring/GetActivationDate',
        data: { "studyId": $("#StudyId").val() },
        success: function (result) {
            activationDate = result.Data[0].StudyActivationDate;
        }
    });

    $("#ui_ddl_deliveryMethod").change(function () {
        $("#deliveryMethod").next("div.error").remove();
    });

    $("#ui_btn_documentSubmitFinal").click(function () {
        ValidateFinalDocumentMandetoryFields();
        if (finalDocumentCheck === true) {
            $(".k-upload-selected").click();
            $("#finalActivationDocModal").modal("hide");
            $("#btn_RemoveDocument").show();
            $("#finalNotificationDownload").show();
            $("#finalNotificationDownload").text(finaluploadName);

        }
        else {
            $("#finalActivationDocModal").modal("show");
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });

    $("#ui_btn_documentCancelFinal").click(function () {
        $("#finalActivationDocModal").modal("hide");

    });

    function ValidateFinalDocumentMandetoryFields() {
        $(".error").remove();
        finalDocumentCheck = true;

        if ($("#uploadFilesFinal").closest(".k-upload").find(".k-file").length <= 0) {
            $('#fileUploadFinal').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
            finalDocumentCheck = false;
        }
        if ($("#ui_txt_documentNameFinal").val() === "") {
            $('#documentNameFinal').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name is required</div>');
            finalDocumentCheck = false;
        }
        if ($('#ui_ddl_documentStatusFinal').val() === 'Select' || $('#ui_ddl_documentStatusFinal').val() === "") {
            $('#documentStatusFinal').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Status is required</div>');
            finalDocumentCheck = false;
        }
        if ($('#ui_ddl_documentStatusFinal').val() === 'Pending Review') {
            $('#documentStatusFinal').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document should be reviewed, Please change the Document Status from Pending Review</div>');
            finalDocumentCheck = false;
        }

        if ($('#ui_ddl_versionFinal').val() === 'Select' || $('#ui_ddl_versionFinal').val() === "") {
            $('#versionFinal').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document version is required</div>');
            finalDocumentCheck = false;
        }
        if ($("#ui_txt_documentNameFinal").val() !== "" && $('#StudyId').val() > 0 && finalDocumentCheck === true) {
            $.ajax({
                async: false,
                type: "GET",
                url: "/TaskWorkFlow/IsDocumentNameIsUnique",
                data: { "documentsName": $("#ui_txt_documentNameFinal").val(), "studyId": $('#StudyId').val() },
                success: function (result) {
                    if (result) {
                        finalDocumentCheck = result;
                    }
                    else {
                        finalDocumentCheck = result;
                        $('#documentNameFinal').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name must be unique. Addition of a Date or Version Number is suggested.</div>');
                    }

                }
            });
        }
    }

    $("#uploadFilesFinal").change(function () {
        $('#fileUploadFinal').next("div.error").remove();
        $('#documentNameFinal').next("div.error").remove();
    });

    $("#ui_txt_documentNameFinal").on("keyup", function (e) {
        $('#documentNameFinal').next("div.error").remove();
    });

    $("#ui_ddl_documentStatusFinal").change(function () {
        $('#documentStatusFinal').next("div.error").remove();
    });

    $("#ui_ddl_versionFinal").change(function () {
        $('#versionFinal').next("div.error").remove();
    });

    $('#finalNotificationDownload').click(function () {
        fileName = finaluploadName;
        if ($("#TaskName").val() === "Create/Deliver Activation Letter") {
            subModuleFolderName = "StudyActivationDocument";
        }
        studyId = $('#StudyId').val();
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + studyId;
    });

    $('#btn_RemoveDocument').click(function () {
        objDocuments = new Object();
        objDocuments.StudyId = $('#StudyId').val();

        if ($("#TaskName").val() === "Create/Deliver Activation Letter") {
            objDocuments.SubModuleName = "StudyActivationDocument";
        }
        objDocuments.ANJU_ChangedBy = $('#LogedinUserName').val();

        $.ajax({
            async: false,
            type: "POST",
            url: "/TaskWorkFlow/DeleteDocuments",
            data: { "documents": objDocuments },
            success: function (results) {
                if (results.length !== 0) {
                    $("#finalNotificationDownload").hide();
                    $("#frm_finalDocumentDetails")[0].reset();
                    $(".k-upload-files").remove();
                    $(".k-upload-status").remove();
                    $(".k-upload.k-header").addClass("k-upload-empty");
                    $(".k-upload-button").removeClass("k-state-focused");
                }
                else {
                    popupNotification.show(results.msgType, "error");
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                popupNotification.show('Error', "error");
            }
        });
        $('#btn_RemoveDocument').hide();
        $("#finalNotificationDownload").text("DOWNLOAD");
    });

    var DocumentCheck = true;
    $("#ui_btn_documentSubmit").click(function () {
        ValidateDocumentmandetoryFields();
        if (DocumentCheck === true) {
            $(".k-upload-selected").click();
            $(".k-upload-files").remove();
            $(".k-upload-status").remove();
            $(".k-upload.k-header").addClass("k-upload-empty");
            $(".k-upload-button").removeClass("k-state-focused");
            $("#activationDocModal").modal("hide");
            $("#frm_documentDetails")[0].reset();
            setTimeout(function () {
                $("#ui_dtg_activationLetterDocuments").data("kendoGrid").dataSource.read();
                $("#ui_dtg_activationLetterDocuments").data("kendoGrid").refresh();
            }, 500);
        }
        else {
            $("#activationDocModal").modal("show");
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    }).on('mouseup', function () {
        $("#ui_dtg_activationLetterDocuments").data("kendoGrid").dataSource.read();
        $("#ui_dtg_activationLetterDocuments").data("kendoGrid").refresh();
    });

    function ValidateDocumentmandetoryFields() {

        $(".error").remove();
        DocumentCheck = true;

        if ($("#uploadFiles").closest(".k-upload").find(".k-file").length <= 0) {
            $('#fileUpload').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
            DocumentCheck = false;
        }
        if ($("#ui_txt_documentName").val() === "") {
            $('#documentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name is required</div>');
            DocumentCheck = false;
        }
        if ($('#ui_ddl_documentStatus').val() === 'Pending Review') {
            $('#documentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document should be reviewed, Please change the Document Status from Pending Review</div>');
            DocumentCheck = false;
        }

        if ($('#ui_ddl_documentStatus').val() === 'Select' || $('#ui_ddl_documentStatus').val() === "") {
            $('#documentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Status is required</div>');
            DocumentCheck = false;
        }
        if ($('#ui_ddl_documentType').val() === 'Select' || $('#ui_ddl_documentType').val() === "") {
            $('#documentType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Type is required</div>');
            DocumentCheck = false;
        }
        if ($('#ui_ddl_documentType').val() !== 'Select' || $('#ui_ddl_documentType').val() !== "") {
            if (($('#ui_ddl_documentSubType').val() === 'Select' || $('#ui_ddl_documentSubType').val() === "") && $('#documentSubTypeLabel').hasClass("mandatory")) {
                $('#documentSubType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document SubType is required</div>');
                DocumentCheck = false;
            }
        }
        if ($('#ui_ddl_version').val() === 'Select' || $('#ui_ddl_version').val() === "") {
            $('#version').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document version is required</div>');
            DocumentCheck = false;
        }
        if ($("#ui_txt_documentName").val() !== "" && $('#StudyId').val() > 0 && DocumentCheck) {
            $.ajax({
                async: false,
                type: "GET",
                url: "/TaskWorkFlow/IsDocumentNameIsUnique",
                data: { "documentsName": $("#ui_txt_documentName").val(), "studyId": $('#StudyId').val() },
                success: function (result) {
                    if (result) {
                        DocumentCheck = result;
                    }
                    else {
                        DocumentCheck = result;
                        $('#documentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name must be unique. Addition of a Date or Version Number is suggested.</div>');
                    }

                }
            });
        }
    }

    $("#uploadFiles").change(function () {
        $('#fileUpload').next("div.error").remove();
        $('#documentName').next("div.error").remove();
    });

    $("#ui_txt_documentName").on("keyup", function (e) {
        $('#documentName').next("div.error").remove();
    });

    $("#ui_ddl_documentStatus").change(function () {
        $('#documentStatus').next("div.error").remove();
    });

    $("#ui_ddl_documentType").change(function () {
        $('#documentType').next("div.error").remove();
    });

    $("#ui_ddl_documentSubType").change(function () {
        $('#documentSubType').next("div.error").remove();
    });

    $("#ui_ddl_version").change(function () {
        $('#version').next("div.error").remove();
    });

    $("#ui_btn_documentCancel").click(function () {
        $("#activationDocModal").modal("hide");
        $("#frm_documentDetails")[0].reset();

    });

    $("#ui_btn_submit").click(function () {
        ValidateMandatoryFields();
        SaveActivationDetails();

    });
    function ValidateMandatoryFields() {
        $(".error").remove();
        retval = true;

        if ($('#ui_ddl_deliveryMethod').val() === 'Select' || $('#ui_ddl_deliveryMethod').val() === "") {
            $('#deliveryMethod').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Delivery Method</div>');
            retval = false;
        }
        if ($("#finalNotificationDownload").text() === "DOWNLOAD") {
            $('#finalDocumentdownload').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload the final notification letter</div>');
            retval = false;
        }
    }
    function SaveActivationDetails() {
        if (retval) {
            objGMRCApprovalTask = new Object();
            objGMRCApprovalTask.StudyId = $('#StudyId').val();
            objGMRCApprovalTask.IsTaskCompleted = true;
            objGMRCApprovalTask.ANJU_ChangedBy = $('#LogedinUserName').val();
            objGMRCApprovalTask.TaskName = $("#TaskName").val();

            $.ajax({
                async: false,
                type: "POST",
                url: "/ProtocolPhase/UpdateGMRCApprovalTaskDetails",
                data: { "objGMRCApprovalTask": objGMRCApprovalTask },
                success: function (results) {
                    if (results.msgType === "Success") {
                        opener.location.reload();
                        var lsmailParameter = new Array();
                        var appUrl = $(location)[0].origin;
                        var StudyURL = "<a href='" + appUrl + "'> Navigate</a>";

                        lsmailParameter.push($("#txtUserName").val());
                        lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                        lsmailParameter.push($("#LogedinUserName").val());
                        lsmailParameter.push(activationDate);
                        $.ajax({

                            type: "POST",
                            url: "/Common/SendEmail/",
                            cache: false,
                            data: { "mailMessage": "Communicate Activation Letter (Study Activation)", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $('#LogedinUserName').val(), "ccMail": " " },
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
        else {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    }
});



