function onCancel() {
    window.close();
}

function additionalInfo() {
    return {
        studyId: $('#StudyId').val(),
        subModuleName: "RequestedSupportProtocolDocuments"
    };
}
var RedLinedDocumnetName = "";
function onSelect(e) {
    var src = $("#uploadfiles").val();
    $(this).next("div.error").remove();
    $.each(e.files, function (index, value) {
        RedLinedDocumnetName = value.name;
        $("#ui_txt_documentName").val(RedLinedDocumnetName);
    });

}
function filterDocumentSubType() {
    return {
        documentTypeId: $("#ui_ddl_editDocumentType").val()
    };
}
function onremove(e) {
    $("#ui_txt_documentName").val("");

}
function onsuccess(e) {

    $(".k-upload-files.k-reset").find("li").remove();
    $.each(e.files, function (index, value) {
        RedLinedDocumnetName = value.name;
        $("#ui_txt_documentName").val(RedLinedDocumnetName);
    });
}

function onUpload(e) {
    e.data = {};
    e.data["additional[0]"] = $("#ui_txt_documentName").val();
    e.data["additional[1]"] = $('#ui_ddl_documentStatus').val();
    e.data["additional[2]"] = $('#ui_lbl_documentType').text();
    e.data["additional[3]"] = $('#ui_lbl_documentSubType').text();
    e.data["additional[4]"] = $('#ui_ddl_version').val();
    e.data["additional[5]"] = $('#ui_dt_originalDate').val() !== '' ? $('#ui_dt_originalDate').val() : ' ';
    e.data["additional[6]"] = $('#ui_dt_expiryDate').val() !== '' ? $('#ui_dt_expiryDate').val() : ' ';
}
function Show(e) {
    var gridRowData = $("#ui_dtg_reviewProtocolDocuments").data("kendoGrid");
    if (gridRowData) {
        var data = gridRowData.dataItem($(e).closest("tr"));
        var subModuleFolderName = data.SubModuleName;
        var fileName = data.DocumentNameWithOutExtension + data.DocumentExtension;
        var path = data.Path;
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + $('#StudyId').val() + '&&path=' + path;
    }
}
var detailsTemplate = kendo.template($("#template").html());
function showDetails(e) {
    e.preventDefault();
    var grid = $("#ui_dtg_reviewProtocolDocuments").getKendoGrid();

    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    var wnd = $("#Details").data("kendoWindow");
    wnd.content(detailsTemplate(dataItem));
    wnd.center().open();

    //Fill document window   
    var retVal = true;
    var LogedinUserName = $('#txtUserName').val();

    $("#ui_txt_uploadedBy").val(LogedinUserName);
    $("#ui_txt_editDocumentName").val(dataItem.DocumentName);
    $("#ui_ddl_editDocumentStatus").data('kendoDropDownList').value(dataItem.DocumentStatus);
    $("#ui_ddl_editDocumentType").data('kendoDropDownList').value(dataItem.DocumentTypeId);
    $("#ui_ddl_editDocumentSubType").data('kendoDropDownList').value(dataItem.DocumentSubType);
    $("#ui_ddl_editAmendmentVersion").data('kendoDropDownList').value(dataItem.DocumentVersion);
    $("#ui_dt_editOriginalDate").data("kendoDatePicker").value(dataItem.OriginalDate);
    $("#ui_dt_editExpirationDate").data("kendoDatePicker").value(dataItem.ExpirationDate);

    var fileName = dataItem.DocumentNameWithOutExtension + dataItem.DocumentExtension;
    var DocumentNameWithOutExtension = dataItem.DocumentNameWithOutExtension;
    var DocumentExtension = dataItem.DocumentExtension;
    var subModuleFolderName = dataItem.SubModuleName;
    var studyId = dataItem.StudyId;
    var documentId = dataItem.DocumentId;
    var path = dataItem.Path;

    $('.fileDownload').click(function () {
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + studyId + '&&path=' + path;
    });

    $("#btn-EditDocumentSubmit").click(function () {
        ValidateEditMandetoryFields();
        if (retVal === true) {
            UpdateDcouemntDetails();
        }
        else {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });

    $("#btn-EditDocumentCancel").click(function () {
        $("#Details").data("kendoWindow").close();
    });

    function ValidateEditMandetoryFields() {
        retVal = true;
        $(".error").remove();

        if ($("#ui_txt_editDocumentName").val() === "" || $("#ui_txt_editDocumentName").val() === null) {
            $('#editDocumentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name is required</div>');
            retVal = false;
        }

        if ($('#ui_ddl_editDocumentStatus').val() === 'Select' || $('#ui_ddl_editDocumentStatus').val() === "") {
            $('#editDocumentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Status is required</div>');
            retVal = false;
        }
        if ($('#ui_ddl_editDocumentStatus').val() === 'Pending Review') {
            $('#editDocumentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document should be reviewed, Please change the Document Status from Pending Review</div>');
            retVal = false;
        }
        if ($('#ui_ddl_editDocumentType').val() === 'Select' || $('#ui_ddl_editDocumentType').val() === "") {
            $('#editDocumentType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Type is required</div>');
            retVal = false;
        }
        if ($('#ui_ddl_editDocumentType').val() !== 'Select' || $('#ui_ddl_editDocumentType').val() !== "") {
            if (($('#ui_ddl_editDocumentSubType').val() === 'Select' || $('#ui_ddl_editDocumentSubType').val() === "") && $('#editDocumentSubTypeLabel').hasClass("mandatory")) {
                $('#editDocumentSubType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Sub-Type is required</div>');
                retVal = false;
            }
        }
        if ($('#ui_ddl_editAmendmentVersion').val() === 'Select' || $('#ui_ddl_editAmendmentVersion').val() === "") {
            $('#editAmendmentVersion').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Version is required</div>');
            retVal = false;
        }
        if ($("#ui_txt_editDocumentName").val() !== "" && $('#StudyId').val() > 0 && retVal === true) {
            $.ajax({
                async: false,
                type: "GET",
                url: "/TaskWorkFlow/IsDocumentNameIsUnique",
                data: { "documentsName": $("#ui_txt_editDocumentName").val(), "studyId": $('#StudyId').val() },
                success: function (result) {
                    if (result) {
                        retVal = result;
                    }
                    else {
                        retVal = result;
                        $('#editDocumentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name must be unique. Addition of a Date or Version Number is suggested.</div>');
                    }

                }
            });
        }
    }

    $("#ui_txt_editDocumentName").on("keyup", function (e) {
        $('#editDocumentName').next("div.error").remove();
    });
    $("#ui_ddl_editDocumentStatus").change(function () {
        $('#editDocumentStatus').next("div.error").remove();
    });
    $("#ui_ddl_editDocumentType").change(function () {
        $('#editDocumentType').next("div.error").remove();
    });
    $("#ui_ddl_editDocumentSubType").change(function () {
        $('#editDocumentSubType').next("div.error").remove();
    });
    $("#ui_ddl_editAmendmentVersion").change(function () {
        $('#editAmendmentVersion').next("div.error").remove();
    });

    function UpdateDcouemntDetails() {
        if (retVal === true) {
            objDocumentDetails = new Object();
            objDocumentDetails.DocumentId = documentId;
            objDocumentDetails.StudyId = $('#StudyId').val();
            objDocumentDetails.SubModuleName = subModuleFolderName;
            objDocumentDetails.DocumentName = $("#ui_txt_editDocumentName").val();
            objDocumentDetails.DocumentNameWithOutExtension = DocumentNameWithOutExtension;
            objDocumentDetails.DocumentExtension = DocumentExtension;
            objDocumentDetails.DocumentStatus = $('#ui_ddl_editDocumentStatus').data("kendoDropDownList").text();
            objDocumentDetails.DocumentType = $('#ui_ddl_editDocumentType').data("kendoDropDownList").text();
            objDocumentDetails.DocumentSubType = $('#ui_ddl_editDocumentSubType').data("kendoDropDownList").text();
            objDocumentDetails.DocumentVersion = $('#ui_ddl_editAmendmentVersion').data("kendoDropDownList").text();
            objDocumentDetails.OriginalDate = $("#ui_dt_editOriginalDate").val();
            objDocumentDetails.ExpirationDate = $("#ui_dt_editExpirationDate").val();
            objDocumentDetails.ANJU_ChangedBy = $('#LogedinUserName').val();
            $.ajax({
                async: false,
                type: "POST",
                url: "/TaskWorkFlow/UpdateDocumentDetails",
                data: { "documents": objDocumentDetails },
                success: function (results) {
                    if (results.msgType === "Success") {
                        $("#ui_dtg_reviewProtocolDocuments").data("kendoGrid").dataSource.read();
                        $("#ui_dtg_reviewProtocolDocuments").data("kendoGrid").refresh();
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

function onEditSubTypeDataBound(e) {
    if ($("#ui_ddl_editDocumentSubType").data("kendoDropDownList").dataSource._data.length > 0) {
        $("#ui_ddl_editDocumentSubType").data("kendoDropDownList").enable(true);
        $('#editDocumentSubTypeLabel').addClass("mandatory");
    }
    else {
        $("#ui_ddl_editDocumentSubType").data("kendoDropDownList").enable(false);
        $('#editDocumentSubTypeLabel').removeClass("mandatory");
        $('#editDocumentSubType').next("div.error").remove();
    }
}

$(document).ready(function () {
    var DocumentCheck = true;
    var retVal = true;
    var TaskName = $("#TaskName").val();
    $('#reviewProtocolDocumentDownload').hide();
    $('#ui_btn_removeProtocolDocument').hide();

    $.ajax({
        async: true,
        type: "GET",
        url: '/NewStudy/GetDocumentsByStudyID',
        data: { "studyId": $('#StudyId').val(), "subModuleName": "RedlinedReviewProtocolDocument" },
        success: function (result) {
            if (result.Data.length > 0) {
                $("#reviewProtocolDocumentDownload").text(result.Data[0].DocumentNameWithOutExtension + result.Data[0].DocumentExtension);

            }
        }
    });


    $("#btn-DocumentCancel").click(function () {
        $("#RedlinedProtocolModal").modal("hide");
        $("#frm_RedLinedDocumentDetails")[0].reset();
    });

    $("#btn-DocumentSubmit").click(function () {
        ValidatDocumentMandetoryFields();
        if (DocumentCheck === true) {
            $(".k-upload-selected").click();
            $("#RedlinedProtocolModal").modal("hide");
            $("#ui_btn_removeProtocolDocument").show();
            $("#reviewProtocolDocumentDownload").show();

            $("#reviewProtocolDocumentDownload").text(RedLinedDocumnetName);

        }
        else {

            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });

    $('#ui_btn_removeProtocolDocument').click(function () {
        objDocuments = new Object();
        objDocuments.StudyId = $('#StudyId').val();
        objDocuments.SubModuleName = "RedlinedReviewProtocolDocument";
        objDocuments.ANJU_ChangedBy = $('#LogedinUserName').val();

        $.ajax({
            async: false,
            type: "POST",
            url: "/TaskWorkFlow/DeleteDocuments",
            data: { "documents": objDocuments },
            success: function (results) {
                if (results.length !== 0) {
                    $("#reviewProtocolDocumentDownload").hide();
                    $("#frm_RedLinedDocumentDetails")[0].reset();
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

        $('#reviewProtocolDocumentDownload').text('DOWNLOAD');
        $('#ui_btn_removeProtocolDocument').hide();
    });
    $('#reviewProtocolDocumentDownload').click(function () {

        subModuleFolderName = "RedlinedReviewProtocolDocument";
        studyId = $('#StudyId').val();
        window.location = "/NewStudy/DownloadFiles?fileName=" + RedLinedDocumnetName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + studyId;
    });

    function ValidatDocumentMandetoryFields() {
        $(".error").remove();
        DocumentCheck = true;
        if ($('#ui_txt_documentName').val() === "" || $('#ui_txt_documentName').val() === null) {
            $('#documentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name is required</div>');
            DocumentCheck = false;
        }
        if ($('#ui_ddl_documentStatus').val() === 'Select' || $('#ui_ddl_documentStatus').val() === "") {
            $('#documentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Status is required</div>');
            DocumentCheck = false;
        }
        if ($('#ui_ddl_documentStatus').val() === 'Pending Review') {
            $('#documentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document should be reviewed, Please change the Document Status from Pending Review</div>');
            DocumentCheck = false;
        }
        if ($('#ui_ddl_version').val() === 'Select' || $('#ui_ddl_version').val() === "") {
            $('#version').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document version is required</div>');
            DocumentCheck = false;
        }
        if ($("#uploadfiles").closest(".k-upload").find(".k-file").length <= 0) {
            $('#fileUpload').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
            DocumentCheck = false;
        }
        if ($("#ui_txt_documentName").val() !== "" && $('#StudyId').val() > 0 && DocumentCheck === true) {
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

    $("#uploadfiles").change(function () {
        $('#fileUpload').next("div.error").remove();
    });
    $("#ui_txt_documentName").on("keyup", function (e) {
        $('#documentName').next("div.error").remove();
    });
    $("#ui_ddl_documentStatus").change(function () {
        $('#documentStatus').next("div.error").remove();
    });
    $("#ui_ddl_amendmentVersion").change(function () {
        $('#amendmentVersion').next("div.error").remove();
    });

    $("#ui_btn_submit").click(function () {
        ValidateMandatoryFields();
        SaveProtocolDetails();
    });

    function ValidateMandatoryFields() {
        $(".error").remove();
        retVal = true;

        var grid = $("#ui_dtg_reviewProtocolDocuments").getKendoGrid();
        var datas = grid.dataSource.data();
        for (var item in datas) {
            if (datas[item].DocumentStatus === null || datas[item].DocumentName === null || datas[item].DocumentType === null || datas[item].DocumentSubType === null || datas[item].DocumentVersion === null) {
                $('#ui_dtg_reviewProtocolDocuments').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please review and classify all documents</div>');
                retVal = false;
                break;
            }
        }
        if ($('#ui_ddl_trialLeadDecision').val() === 'Select' || $('#ui_ddl_trialLeadDecision').val() === "") {
            $('#trialLeadDecision').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Trial Lead Decision</div>');
            retVal = false;
        }
        var hyperLinkText = $('#reviewProtocolDocumentDownload').text(); // get the name          

        if (hyperLinkText === "DOWNLOAD") {
            $('#uploadReviewProtocol').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload redlined version of protocol </div>');
            retVal = false;
        }

    }
    $("#ui_ddl_trialLeadDecision").change(function () {
        $(this).next("div.error").remove();
    });


    function SaveProtocolDetails() {
        if (retVal) {
            objGMRCApprovalTask = new Object();
            objGMRCApprovalTask.StudyId = $('#StudyId').val();
            objGMRCApprovalTask.TaskName = $("#TaskName").val();
            objGMRCApprovalTask.Decision = $('#ui_ddl_trialLeadDecision').val();
            objGMRCApprovalTask.Comments = $('#ui_txt_comments').val();
            objGMRCApprovalTask.IsTaskCompleted = true;
            objGMRCApprovalTask.ANJU_AddedBy = $('#LogedinUserName').val();
            objGMRCApprovalTask.AssignedTo = $('#txtUserName').val();
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
                            data: { "mailMessage": "Review Submitted Protocol", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $("#txtUserName").val(), "ccMail": " " },
                            dataType: "json",
                            success: function (results) {

                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {

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

            popupNotification.show("There are errors on the page.Please correct them to continue.", "error");
        }

    }
});