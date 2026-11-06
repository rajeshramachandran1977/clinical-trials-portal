function onChangeOfContractStatus(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Code === "CIF") {
        $('#ifCIF').show();
        $('#ifFullyExecutedContract').hide();
    }
    else if (dataItem.Code === "Fully-Executed Contract") {
        $('#ifFullyExecutedContract').show();
        $('#ifCIF').hide();
    }
    else {
        $('#ifCIF').hide();
        $('#ifFullyExecutedContract').hide();
    }
}
function onCancel() {
    window.close();
}

var ContactDocumnetName = "";
function onSelectContractUpload(e) {
    var src = $("#contractUploadfile").val();
    $(this).next("div.error").remove();
    $.each(e.files, function (index, value) {
        ContactDocumnetName = value.name;
        $("#ui_txt_contractDocumentName").val(value.name);
    });
}
function onremoveContractUpload(e) {
    if (ContactDocumnetName !== e.files[0].name)
        $("#ui_txt_contractDocumentName").val(ContactDocumnetName);
    else
        $("#ui_txt_contractDocumentName").val("");   
}
function onsuccessContractUpload(e) {

    $(".k-upload-files.k-reset").find("li").remove();
    $.each(e.files, function (index, value) {
        ContactDocumnetName = value.name;
    });
}
function onUploadContractUpload(e) {
    e.data = {};
    e.data["additional[0]"] = $("#ui_txt_contractDocumentName").val();
    e.data["additional[1]"] = $('#ui_ddl_contractDocumentStatus').val();
    e.data["additional[2]"] = $("#ui_lbl_documentType").text();
    e.data["additional[3]"] = "";
    e.data["additional[4]"] = $('#ui_ddl_contractVersion').val();
    e.data["additional[5]"] = $('#ui_dt_contractOriginalDate').val() !== '' ? $('#ui_dt_contractOriginalDate').val() : ' ';
    e.data["additional[6]"] = $('#ui_dt_contractExpiryDate').val() !== '' ? $('#ui_dt_contractExpiryDate').val() : ' ';
}

$("#ui_ddl_contractDocumentStatus").change(function () {
    $(this).next("div.error").remove();
});

$(document).ready(function () {
    $('#contractDocDownload').hide();
    $('#btn_RemoveContractDoc').hide();
    $('#ifCIF').hide();
    $('#ifFullyExecutedContract').hide();
    var retval = true;
    var DocumentCheck = true;
    var todayDate = kendo.toString(kendo.parseDate(new Date()), 'MMM dd, yyyy');
    $("#ui_dt_CIFSubmission").data("kendoDatePicker").value(todayDate);
    $("#ui_dt_contractExecution").data("kendoDatePicker").value(todayDate);
    $("#ui_dt_contractEffective").data("kendoDatePicker").value(todayDate);
    $("#ui_dt_contractExpiration").data("kendoDatePicker").value(todayDate);

    $("#btn-Submit").click(function () {
        ValidateMandatoryFields();
        SaveManageContractStatus();
    });
    function ValidateMandatoryFields() {
        $(".error").remove();
        retval = true;
        if ($('#ui_ddl_contractType').val() === 'Select' || $('#ui_ddl_contractType').val() === "") {
            $('#contractType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please specify Contract Type</div>');
            retval = false;
        }
        if ($('#ui_ddl_contractStatus').val() === 'Select' || $('#ui_ddl_contractStatus').val() === "") {
            $('#contractStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please specify Contract Status</div>');
            retval = false;
        }
        if ($('#ui_ddl_currentLocation').val() === 'Select' || $('#ui_ddl_currentLocation').val() === "") {
            $('#currentLocation').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please specify Current Location</div>');
            retval = false;
        }
        if ($('#ui_ddl_contractStatus').val() === "CIF") {
            if ($('#ui_dt_CIFSubmission').val() === "month day, year") {
                $('#CIFSubmission').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>The required field CIF Submission Date has not been filled in.</div>');
                retval = false;
            }
        }
        if ($('#ui_ddl_contractStatus').val() === "Fully-Executed Contract") {

            if ($('#ui_dt_contractExecution').val() === "month day, year") {
                $('#contractExecution').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>The required field Contract Execution Date has not been filled in.</div>');
                retval = false;
            }
            if ($('#ui_dt_contractEffective').val() === "month day, year") {
                $('#contractEffective').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>The required field Contract Effective Date has not been filled in.</div>');
                retval = false;
            }
            if ($('#ui_dt_contractExpiration').val() === "month day, year") {
                $('#contractExpiration').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>The required field Contract Expiration Date has not been filled in.</div>');
                retval = false;
            }
            if ($('#contractDocDownload').text() === "DOWNLOAD") {
                $('#contractDoc').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
                retval = false;
            }
        }
    }

    $("#ui_ddl_contractType").change(function () {
        $('#contractType').next("div.error").remove();
    });
    $("#ui_ddl_contractStatus").change(function () {
        $('#contractStatus').next("div.error").remove();
    });
    $("#ui_ddl_currentLocation").change(function () {
        $('#currentLocation').next("div.error").remove();
    });
    $("#ui_dt_CIFSubmission").change(function () {
        $('#CIFSubmission').next("div.error").remove();
    });
    $("#ui_dt_contractExecution").change(function () {
        $('#contractExecution').next("div.error").remove();
    });
    $("#ui_dt_contractEffective").change(function () {
        $('#contractEffective').next("div.error").remove();
    });
    $("#ui_dt_contractExpiration").change(function () {
        $('#contractExpiration').next("div.error").remove();
    });
    $("#contractDocDownload").change(function () {
        $('#contractDoc').next("div.error").remove();
    });

    function SaveManageContractStatus() {
        if (retval) {
            objGMRCApprovalTask = new Object();
            objGMRCApprovalTask.StudyId = $('#StudyId').val();
            objGMRCApprovalTask.TaskName = "Manage Contract Status";
            objGMRCApprovalTask.IsTaskCompleted = true;
            objGMRCApprovalTask.ContractType = $('#ui_ddl_contractType').val();
            objGMRCApprovalTask.ContractStatus = $('#ui_ddl_contractStatus').val();
            objGMRCApprovalTask.CurrentLocation = $('#ui_ddl_currentLocation').val();
            objGMRCApprovalTask.ContactName = $('#ui_txt_contactName').val();
            if ($('#ui_ddl_contractStatus').val() === "Fully-Executed Contract") {
                objGMRCApprovalTask.ExecutionDate = $("#ui_dt_contractExecution").val();
                objGMRCApprovalTask.EffectiveDate = $("#ui_dt_contractEffective").val();
                objGMRCApprovalTask.ExpirationDate = $("#ui_dt_contractExpiration").val();
            }
            else {
                objGMRCApprovalTask.ExecutionDate = null;
                objGMRCApprovalTask.EffectiveDate = null;
                objGMRCApprovalTask.ExpirationDate = null;

            }
            if ($('#ui_ddl_contractStatus').val() === "CIF") {
                objGMRCApprovalTask.IsTaskCompleted = false;
                objGMRCApprovalTask.SubmissionDate = $("#ui_dt_CIFSubmission").val();
            }
            else {
                objGMRCApprovalTask.SubmissionDate = null;
            }

            objGMRCApprovalTask.ANJU_ChangedBy = $('#LogedinUserName').val();
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
                        lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                        lsmailParameter.push(StudyURL);
                        $.ajax({
                            type: "POST",
                            url: "/Common/SendEmail/",
                            cache: false,
                            data: { "mailMessage": "Contracting", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $('#LogedinUserName').val(), "ccMail": " " },
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
    $("#btn-ContractDocumentCancel").click(function () {
        $("#addContractDocModal").modal("hide");
        $("#frm_contractDocDetails")[0].reset();
    });

    $('#contractDocDownload').click(function () {
        subModuleFolderName = "ExecutedContractDocument";
        studyId = $('#StudyId').val();
        window.location = "/NewStudy/DownloadFiles?fileName=" + ContactDocumnetName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + studyId;
    });

    $("#btn-ContractDocumentSubmit").click(function () {
        ValidateContractDocumentMandetoryFields();
        if (DocumentCheck === true) {
            $(".k-upload-selected").click();
            $(".k-upload-files").remove();
            $(".k-upload-status").remove();
            $(".k-upload.k-header").addClass("k-upload-empty");
            $(".k-upload-button").removeClass("k-state-focused");
            $("#addContractDocModal").modal("hide");
            $("#btn_RemoveContractDoc").show();
            $("#contractDocDownload").show();
            $("#contractDocDownload").text(ContactDocumnetName);
        }
        else {
            $("#addContractDocModal").modal("show");
            $("#contractDocDownload").hide();
            $('#contractDocDownload').text('DOWNLOAD');
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });

    function ValidateContractDocumentMandetoryFields() {
        $(".error").remove();
        DocumentCheck = true;
        if ($('#contractUploadfile').closest(".k-upload").find(".k-file").length<=0) {
            $('#uploadFile').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please Upload</div>');
        }

        if ($("#ui_txt_contractDocumentName").val() === "" || $("#ui_txt_contractDocumentName").val() === null) {
            $('#contractDocumentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name is required</div>');
            DocumentCheck = false;
        }
        if ($('#ui_ddl_contractDocumentStatus').val() === 'Select' || $('#ui_ddl_contractDocumentStatus').val() === "") {
            $('#contractDocumentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Status is required</div>');
            DocumentCheck = false;
        }

        if ($('#ui_ddl_contractDocumentStatus').val() === 'Pending Review') {
            $('#contractDocumentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document should be reviewed, Please change the Document Status from Pending Review</div>');
            DocumentCheck = false;
        }

        if ($('#ui_ddl_contractVersion').val() === 'Select' || $('#ui_ddl_contractVersion').val() === "") {
            $('#contractVersion').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document version is required</div>');
            DocumentCheck = false;
        }

        if ($("#ui_txt_contractDocumentName").val() !== "" && $('#StudyId').val() > 0 && DocumentCheck) {
            $.ajax({
                async: false,
                type: "GET",
                url: "/TaskWorkFlow/IsDocumentNameIsUnique",
                data: { "documentsName": $("#ui_txt_contractDocumentName").val(), "studyId": $('#StudyId').val() },
                success: function (result) {
                    if (result) {
                        DocumentCheck = result;
                    }
                    else {
                        DocumentCheck = result;
                        $('#contractDocumentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name must be unique. Addition of a Date or Version Number is suggested.</div>');
                    }
                }
            });
        }
    }
    $('#contractUploadfile').change(function () {
        $('#uploadFile').next("div.error").remove();
        $('#contractDocumentName').next("div.error").remove();
    });
    $('#ui_txt_contractDocumentName').on("keyup",function () {
        $('#contractDocumentName').next("div.error").remove();
    });
    $('#ui_ddl_contractDocumentStatus').change(function () {
        $('#contractDocumentStatus').next("div.error").remove();
    });
    $('#ui_ddl_contractVersion').change(function () {
        $('#contractVersion').next("div.error").remove();
    });
   $('#contractUploadfile').change(function () {
        $('#uploadFile').next("div.error").remove();
    });

    $('#btn_RemoveContractDoc').click(function () {

        objDocuments = new Object();
        objDocuments.StudyId = $('#StudyId').val();
        objDocuments.SubModuleName = "ExecutedContractDocument";
        objDocuments.ANJU_ChangedBy = $('#LogedinUserName').val();

        $.ajax({
            async: false,
            type: "POST",
            url: "/TaskWorkFlow/DeleteDocuments",
            data: { "documents": objDocuments },
            success: function (results) {
                if (results.length !== 0) {
                    $("#contractDocDownload").hide();
                    $("#frm_contractDocDetails")[0].reset();
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

        $('#contractDocDownload').text('DOWNLOAD');
        $('#btn_RemoveContractDoc').hide();
    });
});