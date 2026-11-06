function onCancel() {
    window.close();
}

function onChangeOfDecision(e) {
    var dataItem = this.dataItem(e.item);
    var recordType = $("#recordType").val();

    if (dataItem.Code === "Rejected" && recordType === "LocalMRC") {
        $('#decisionComments').show();
    }
    else if ((dataItem.Code === "Rejected" || dataItem.Code === "Conditionally Approved - Resubmission required") && recordType === "GlobalMRC") {
        $("#ui_lbl_macsNumber").addClass("mandatory");
    }
    else if ((dataItem.Code !== "Rejected" || dataItem.Code !== "Conditionally Approved - Resubmission required") && recordType === "GlobalMRC") {
        $("#ui_lbl_macsNumber").removeClass("mandatory");
    }
    else {
        $('#decisionComments').hide();
    }
    if ((dataItem.Code === "Approved" || dataItem.Code === "Conditionally Approved") && recordType === "GlobalMRC") {
        $("#ui_lbl_studyNumber").addClass("mandatory");
    }
    else if ((dataItem.Code !== "Approved" || dataItem.Code !== "Conditionally Approved") && recordType === "GlobalMRC") {
        $("#ui_lbl_studyNumber").removeClass("mandatory");
    }

    //GMRC Decision Date = mandatory depends on Decision
    if (recordType === "GlobalMRC") {
        if (dataItem.Code === "Approved" || dataItem.Code === "Conditionally Approved" || dataItem.Code === "Rejected") {
            $("#decisionDate").addClass("mandatory");
        }
        else {
            $("#decisionDate").removeClass("mandatory");
        }
    }
}

function filterDocumentSubType() {
    return {
        documentTypeId: $("#ui_ddl_documentType").val()
    };
}

function filterDocumentMACSSubType() {
    return {
        documentTypeId: $("#ui_ddl_MACSDocumentType").val()
    };
}

function filterEditDocumentSubType() {
    return {
        documentTypeId: $("#ui_ddl_editdocumentType").val()
    };
}

function additionalInfo() {
    var recordType = $("#recordType").val();
    if (recordType === "LocalMRC") {
        return {
            studyId: $('#StudyId').val(),
            subModuleName: "LocalMRCSupportDocuments"
        };
    }
    else {
        return {
            studyId: $('#StudyId').val(),
            subModuleName: "GlobalMRCSupportDocuments"
        };
    }
}

var Meetingdoc = "";
function onSelect(e) {

    var src = $("#uploadfiles").val();
    $(this).next("div.error").remove();
    $('#documentName').next("div.error").remove();

    $.each(e.files, function (index, value) {
        $("#ui_txt_documentName").val(value.name);
        Meetingdoc = value.name;
    });
}

function onremove(e) {
    if (Meetingdoc !== e.files[0].name)
        $("#ui_txt_documentName").val(Meetingdoc);
    else
        $("#ui_txt_documentName").val("");
}

function onUpload(e) {
    $.each(e.files, function (index, value) {
        if ($("#ui_txt_documentName").val() === "")
            $("#ui_txt_documentName").val(value.name);
    });
    e.data = {};
    e.data["additional[0]"] = $("#ui_txt_documentName").val();
    e.data["additional[1]"] = $('#ui_ddl_documentStatus').val();
    e.data["additional[2]"] = $('#ui_ddl_documentType').data("kendoDropDownList").text();
    e.data["additional[3]"] = $('#ui_ddl_documentSubType').val();
    e.data["additional[4]"] = $('#ui_ddl_version').val();
    e.data["additional[5]"] = $('#ui_dt_originalDate').val() !== '' ? $('#ui_dt_originalDate').val() : ' ';
    e.data["additional[6]"] = $('#ui_dt_expiryDate').val() !== '' ? $('#ui_dt_expiryDate').val() : ' ';
    e.data["additional[7]"] = $("#recordType").val();
}

var MACDocumnetName = "";
function onSelectMACDocuments(e) {
    var src = $("#MACSUploadfiles").val();
    $(this).next("div.error").remove();
    $.each(e.files, function (index, value) {
        MACDocumnetName = value.name;
    });

}

function onremoveMACDocuments(e) {
    //if (MACDocumnetName !== e.files[0].name)
    //    $("#ui_txt_MACSDocumentName").val(MACDocumnetName);
    //else
    $("#ui_txt_MACSDocumentName").val("MACS Part II");

}

function onsuccessMACDocuments(e) {

    $(".k-upload-files.k-reset").find("li").remove();
    $.each(e.files, function (index, value) {
        MACDocumnetName = value.name;
    });
}

function onUploadMACDocuments(e) {
    e.data = {};
    e.data["additional[0]"] = $("#ui_txt_MACSDocumentName").val();
    e.data["additional[1]"] = $('#ui_ddl_MACSDocumentStatus').val();
    e.data["additional[2]"] = $('#ui_ddl_MACSDocumentType').data("kendoDropDownList").text();
    e.data["additional[3]"] = $('#ui_ddl_MACSDocumentSubType').val();
    e.data["additional[4]"] = $('#ui_ddl_MACSVersion').val();
    e.data["additional[5]"] = $('#ui_dt_MACSOriginalDate').val() !== '' ? $('#ui_dt_MACSOriginalDate').val() : ' ';
    e.data["additional[6]"] = $('#ui_dt_MACSExpiryDate').val() !== '' ? $('#ui_dt_MACSExpiryDate').val() : ' ';
}

var detailsTemplate = kendo.template($("#template").html());
function showDetails(e) {
    e.preventDefault();
    var grid = $("#ui_dtg_localMRCDocuments").getKendoGrid();

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
        //fileName = $(this).attr('filename');
        //subModuleFolderName = $(this).attr('subModuleFolderName');
        //studyId = $(this).attr('studyId');
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
        if ($('#ui_ddl_editdocumentStatus').val() === 'Pending Review') {
            $('#editDocumentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document should be reviewed, Please change the Document Status from Pending Review</div>');
            retVal = false;
        }
        if ($('#ui_ddl_editdocumentType').val() === 'Select' || $('#ui_ddl_editdocumentType').val() === "") {
            $('#editDocumentType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Type is required</div>');
            retVal = false;
        }
        if ($('#ui_ddl_editdocumentType').val() !== 'Select' || $('#ui_ddl_editdocumentType').val() !== "") {
            if (($('#ui_ddl_editdocumentSubType').val() === 'Select' || $('#ui_ddl_editdocumentSubType').val() === "") && $('#editDocumentSubTypeLabel').hasClass("mandatory")) {
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
                        $("#ui_dtg_localMRCDocuments").data("kendoGrid").dataSource.read();
                        $("#ui_dtg_localMRCDocuments").data("kendoGrid").refresh();
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

function Show(e) {
    var gridRowData = $("#ui_dtg_localMRCDocuments").data("kendoGrid");
    if (gridRowData) {
        var data = gridRowData.dataItem($(e).closest("tr"));
        var subModuleFolderName = data.SubModuleName;
        var fileName = data.DocumentNameWithOutExtension + data.DocumentExtension;
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + $('#StudyId').val();
    }
}

function onDataBound(e) {
    var dropdownlist = $("#ui_ddl_documentType").data("kendoDropDownList");
    dropdownlist.select(function (dataItem) {
        return dataItem.Code === "Meeting Support";
    });
}

function onMACSDataBound(e) {
    var dropdownlist = $("#ui_ddl_MACSDocumentType").data("kendoDropDownList");
    dropdownlist.select(function (dataItem) {
        return dataItem.Code === "Submission Support";
    });
}

function onMACSSubTypeBound(e) {
    var dropdownlist = $("#ui_ddl_MACSDocumentSubType").data("kendoDropDownList");
    dropdownlist.select(function (dataItem) {
        return dataItem.Code === "MACS";
    });
    if ($("#ui_ddl_MACSDocumentSubType").data("kendoDropDownList").dataSource._data.length > 0) {
        $("#ui_ddl_MACSDocumentSubType").data("kendoDropDownList").enable(true);
        $('#macsDocumentSubTypeLabel').addClass("mandatory");
    }
    else {
        $("#ui_ddl_MACSDocumentSubType").data("kendoDropDownList").enable(false);
        $('#macsDocumentSubTypeLabel').removeClass("mandatory");
        $('#macsDocumentSubType').next("div.error").remove();
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

var mslUserName = "";
$(document).ready(function () {
    $('#finalNotificationDownload').hide();
    $('#btn_RemoveDocument').hide();
    $("#ui_dtg_localMRCDocuments").data("kendoGrid").dataSource.read();
    $("#ui_dtg_localMRCDocuments").data("kendoGrid").dataSource.fetch();
    $("#ui_dtg_localMRCDocuments").data("kendoGrid").refresh();

    var retVal = true;
    var recordType = $("#recordType").val();

    $('.GMRC').hide();
    $('#decisionComments').hide();
    $('#GMRCDecision').hide();

    //Record Global MRC Results
    if ($("#recordType").val() === "GlobalMRC") {
        $('#taskHeading').text("Record Global MRC Results");
        $('.GMRC').show();
        $('#decisionDate').text('GMRC Decision Date');
        $('#decisionMadeBy').hide();
        $('#LMRCDecision').hide();
        $('#GMRCDecision').show();
        $("#finalNotificationDownload").hide();
        $("#btn_RemoveDocument").hide();
    }

    $("#AmountRequested").hide();
    $.ajax({
        async: false,
        type: "GET",
        url: '/TaskWorkFlow/GetMRCBudgetDetails',
        data: { "studyId": $('#StudyId').val() },
        success: function (result) {
            if (result.length > 0) {
                $("#ui_lbl_plannedNopatients").text(result[0].TotalPlannedNumberofPatients);
                $("#ui_lbl_mslUserName").text(result[0].MslUserName);
                mslUserName = result[0].MslUserName;
                var Amount = result[0].AmountRequested;
                if (Amount > 0) {
                    $("#AmountRequested").show();
                    $("#ui_lbl_drugName").text("Drug and Funding");
                    $("#ui_txt_amountReq").val(result[0].AmountRequested);
                }
                else {
                    $("#ui_lbl_drugName").text("N/A");
                    $("#AmountRequested").hide();
                }
            }
        }
    });

    if ($("#recordType").val() === "GlobalMRC") {
        $.ajax({
            async: true,
            type: "GET",
            url: '/TaskWorkFlow/GetMACDocuments',
            data: { "studyId": $('#StudyId').val() },
            success: function (result) {
                if (result.Data.length > 0) {
                    $("#finalNotificationDownload").text(result.Data[0].DocumentNameWithOutExtension + result.Data[0].DocumentExtension);
                    MACDocumnetName = result.Data[0].DocumentNameWithOutExtension + result.Data[0].DocumentExtension;
                }
            }
        });
    }
    var DocumentCheck = true;

    $("#btn-DocumentSubmit").click(function () {
        ValidateDocumentmandetoryFields();
        if (DocumentCheck === true) {
            $(".k-upload-selected").click();
            $(".k-upload-files").remove();
            $(".k-upload-status").remove();
            $(".k-upload.k-header").addClass("k-upload-empty");
            $(".k-upload-button").removeClass("k-state-focused");
            $("#docModal").modal("hide");
            $("#frm_documentDetails")[0].reset();
            $("#ui_frm_documentForm")[0].reset();

            setWidgetValue($("#ui_ddl_documentType"), 'Meeting Support');

            setTimeout(function () {
                $("#ui_dtg_localMRCDocuments").data("kendoGrid").dataSource.read();
                $("#ui_dtg_localMRCDocuments").data("kendoGrid").refresh();
            }, 1000);

            //$("#ui_ddl_documentType").data('kendoDropDownList').value("Meeting Support");
        }
        else {
            $("#docModal").modal("show");
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    }).on('mouseup', function () {
        $("#ui_dtg_localMRCDocuments").data("kendoGrid").dataSource.read();
        $("#ui_dtg_localMRCDocuments").data("kendoGrid").refresh();
    });

    function ValidateDocumentmandetoryFields() {
        $(".error").remove();
        DocumentCheck = true;

        if ($("#ui_txt_documentName").val() === "" || $("#ui_txt_documentName").val() === null) {
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
        if ($('#ui_ddl_documentType').val() === 'Select' || $('#ui_ddl_documentType').val() === "") {
            $('#documentType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Type is required</div>');
            DocumentCheck = false;
        }
        if ($('#ui_ddl_documentType').val() !== 'Select' || $('#ui_ddl_documentType').val() !== "") {
            if (($('#ui_ddl_documentSubType').val() === 'Select' || $('#ui_ddl_documentSubType').val() === "") && $('#documentSubTypeLabel').hasClass("mandatory")) {
                $('#documentSubType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Sub-Type is required</div>');
                DocumentCheck = false;
            }
        }
        if ($('#ui_ddl_version').val() === 'Select' || $('#ui_ddl_version').val() === "") {
            $('#version').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document version is required</div>');
            DocumentCheck = false;
        }
        if ($("#uploadfiles").closest(".k-upload").find(".k-file").length <= 0) {
            $('#fileUpload').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
            DocumentCheck = false;
        }
        if ($("#ui_txt_documentName").val() !== "" && $('#StudyId').val() > 0 && DocumentCheck == true) {
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


    $("#btn-DocumentCancel").click(function () {
        $("#frm_documentDetails")[0].reset();
        setWidgetValue($("#ui_ddl_documentType"), 'Meeting Support');
        $("#docModal").modal("hide");
    });

    setWidgetValue = function (widget, val) {
        if (null === widget || undefined === widget) {
            return;
        }
        setTimeout(setWidgetValueDelayed, 50, val);
    };

    setWidgetValueDelayed = function (val) {
        if (val === "Meeting Support") {
            var dropdownlist = $("#ui_ddl_documentType").data("kendoDropDownList");
            dropdownlist.select(function (dataItem) {
                return dataItem.Code === val;
            });
        }
        if (val === "Submission Support") {
            var MACSDocumentType = $("#ui_ddl_MACSDocumentType").data("kendoDropDownList");
            MACSDocumentType.select(function (dataItem) {
                return dataItem.Code === val;
            });
            var MACSDocumentSubType = $("#ui_ddl_MACSDocumentSubType").data("kendoDropDownList");
            MACSDocumentSubType.select(function (dataItem) {
                return dataItem.Code === "MACS";
            });
        }
    };

    $("#btn_MACSDocumentCancel").click(function () {
        $("#MACSdocModal").modal("hide");
        $("#frm_MACSDocumentDetails")[0].reset();
        setWidgetValue($("#ui_ddl_MACSDocumentType"), 'Submission Support');

    });
    $("#btn_MACSDocumentSubmit").click(function () {
        ValidateMACDocumentMandetoryFields();
        if (DocumentCheck === true) {
            $(".k-upload-selected").click();
            $("#MACSdocModal").modal("hide");
            $("#btn_RemoveDocument").show();
            $("#finalNotificationDownload").show();

            $("#finalNotificationDownload").text(MACDocumnetName);

        }
        else {
            $("#MACSdocModal").modal("show");
            $("#finalNotificationDownload").hide();
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });

    $('#btn_RemoveDocument').click(function () {
        objDocuments = new Object();
        objDocuments.StudyId = $('#StudyId').val();
        objDocuments.SubModuleName = "GMRCMACDDocument";
        objDocuments.ANJU_ChangedBy = $('#LogedinUserName').val();

        $.ajax({
            async: false,
            type: "POST",
            url: "/TaskWorkFlow/DeleteDocuments",
            data: { "documents": objDocuments },
            success: function (results) {
                if (results.length !== 0) {
                    $("#finalNotificationDownload").hide();
                    $("#frm_MACSDocumentDetails")[0].reset();
                    setWidgetValue($("#ui_ddl_MACSDocumentType"), 'Submission Support');
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

        $('#finalNotificationDownload').text('DOWNLOAD');
        $('#btn_RemoveDocument').hide();
    });

    $('#finalNotificationDownload').click(function () {

        //fileName = $("#ui_txt_MACSDocumentName").val();
        subModuleFolderName = "GMRCMACDDocument";
        studyId = $('#StudyId').val();
        window.location = "/NewStudy/DownloadFiles?fileName=" + MACDocumnetName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + studyId;
    });

    function ValidateMACDocumentMandetoryFields() {
        $(".error").remove();
        DocumentCheck = true;
        if ($('#ui_txt_MACSDocumentName').val() === "" || $('#ui_txt_MACSDocumentName').val() === null) {
            $('#macsDocumentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name is required</div>');
            DocumentCheck = false;
        }
        if ($('#ui_ddl_MACSDocumentStatus').val() === 'Select' || $('#ui_ddl_MACSDocumentStatus').val() === "") {
            $('#macsDocumentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Status is required</div>');
            DocumentCheck = false;
        }
        if ($('#ui_ddl_MACSDocumentStatus').val() === 'Pending Review') {
            $('#macsDocumentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document should be reviewed, Please change the Document Status from Pending Review</div>');
            DocumentCheck = false;
        }
        if ($('#ui_ddl_MACSDocumentType').val() === 'Select' || $('#ui_ddl_MACSDocumentType').val() === "") {
            $('#macsDocumentType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Type is required</div>');
            DocumentCheck = false;
        }
        if ($('#ui_ddl_MACSDocumentType').val() !== 'Select' || $('#ui_ddl_MACSDocumentType').val() !== "") {
            if (($('#ui_ddl_MACSDocumentSubType').val() === 'Select' || $('#ui_ddl_MACSDocumentSubType').val() === "") && $('#macsDocumentSubTypeLabel').hasClass("mandatory")) {
                $('#macsDocumentSubType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Sub-Type is required</div>');
                DocumentCheck = false;
            }
        }
        if ($('#ui_ddl_MACSVersion').val() === 'Select' || $('#ui_ddl_MACSVersion').val() === "") {
            $('#macsVersion').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document version is required</div>');
            DocumentCheck = false;
        }
        if ($("#MACSUploadfiles").closest(".k-upload").find(".k-file").length <= 0) {
            $('#macsFileUpload').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
            DocumentCheck = false;
        }
        if ($("#ui_txt_MACSDocumentName").val() !== "" && $('#StudyId').val() > 0 && DocumentCheck === true) {
            $.ajax({
                async: false,
                type: "GET",
                url: "/TaskWorkFlow/IsDocumentNameIsUnique",
                data: { "documentsName": $("#ui_txt_MACSDocumentName").val(), "studyId": $('#StudyId').val() },
                success: function (result) {
                    if (result) {
                        DocumentCheck = result;
                    }
                    else {
                        DocumentCheck = result;
                        $('#macsDocumentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name must be unique. Addition of a Date or Version Number is suggested.</div>');
                    }

                }
            });
        }

    }

    $("#MACSUploadfiles").change(function () {
        $('#macsFileUpload').next("div.error").remove();
        $('#macsDocumentName').next("div.error").remove();
    });
    $("#ui_txt_MACSDocumentName").on("keyup", function (e) {
        $('#macsDocumentName').next("div.error").remove();
    });
    $("#ui_ddl_MACSDocumentStatus").change(function () {
        $('#macsDocumentStatus').next("div.error").remove();
    });
    $("#ui_ddl_MACSDocumentType").change(function () {
        $('#macsDocumentType').next("div.error").remove();
    });
    $("#ui_ddl_MACSDocumentSubType").change(function () {
        $('#macsDocumentSubType').next("div.error").remove();
    });
    $("#ui_ddl_MACSVersion").change(function () {
        $('#macsVersion').next("div.error").remove();
    });

    $("#btn-Submit").click(function () {
        ValidateMandatoryFields();
        SaveMRCDetails();
    });


    function ValidateMandatoryFields() {
        $(".error").remove();
        retVal = true;
        if (recordType === "LocalMRC") {

            if ($('#ui_ddl_decision').val() === 'Select' || $('#ui_ddl_decision').val() === "") {
                $('#decision').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Decision</div>');
                retVal = false;
            }
            var DecsionType = $('#ui_ddl_decision').val();
            if (DecsionType === "Rejected") {
                if ($('#ui_ddl_rejectedDecisionCmts').val() === 'Select' || $('#ui_ddl_rejectedDecisionCmts').val() === "") {
                    $('#decisionComments').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Decision Comments is required</div>');
                    retVal = false;
                }
            }
            if ($("#ui_dt_dateOfDecision").val() === "") {
                $('#dateOfDecision').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Date of Decision has not been filled in</div>');
                retVal = false;

            }
            if ($('#ui_ddl_decisionMadeBy').val() === 'Select' || $('#ui_ddl_decisionMadeBy').val() === "") {
                $('#decisionMadeBy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select the person who made the decision</div>');
                retVal = false;
            }
        }
        else if (recordType === "GlobalMRC") {
            if ($('#ui_ddl_GMRCdecision').val() === 'Select' || $('#ui_ddl_GMRCdecision').val() === "") {
                $('#GMRCDecision').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Decision</div>');
                retVal = false;
            }
            if ($('#ui_ddl_saeFrequency').val() === 'Select' || $('#ui_ddl_saeFrequency').val() === "") {
                $('#saeFrequency').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>SAE Reconciliation frequency is required</div>');
                retVal = false;
            }

            var DecisionType = $('#ui_ddl_GMRCdecision').val();
            if (DecisionType === "Rejected" || DecisionType === "Conditionally Approved - Resubmission required") {
                if ($('#ui_txt_macsNumber').val() === "") {
                    $('#macsNumber').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please Specify MACS Number</div>');
                    retVal = false;
                }
            }
            if (DecisionType === "Approved") {
                if ($('#ui_txt_studyNumber').val() === "") {
                    $('#studyNumber').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please Specify Study Number</div>');
                    retVal = false;
                }
            }
            if (DecisionType === "Approved" || DecisionType === "Conditionally Approved" || DecisionType === "Rejected") {
                if ($("#ui_dt_dateOfDecision").val() === "") {
                    $('#dateOfDecision').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Date of Decision has not been filled in</div>');
                    retVal = false;
                }
            }

            var hyperLinkText = $('#finalNotificationDownload').text(); // get the name          

            if (hyperLinkText === "DOWNLOAD") {
                $('#macsFormDownload').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload MACS Form Part 2 </div>');
                retVal = false;
            }
        }

        var grid = $("#ui_dtg_localMRCDocuments").getKendoGrid();
        var datas = grid.dataSource.data();
        if (datas.length === 0) {
            $('#ui_dtg_localMRCDocuments').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please Upload the documents</div>');
            retVal = false;
        }
    }

    $("#ui_ddl_rejectedDecisionCmts").change(function () {
        $("#decisionComments").next("div.error").remove();
    });
    $("#ui_ddl_decision").change(function () {
        $('#decision').next("div.error").remove();
    });
    $("#ui_dt_dateOfDecision").on("focus", function (e) {
        $("#dateOfDecision").next("div.error").remove();
    });
    $("#ui_ddl_decisionMadeBy").change(function () {
        $("#decisionMadeBy").next("div.error").remove();
    });
    $("#ui_ddl_saeFrequency").change(function () {
        $("#saeFrequency").next("div.error").remove();
    });
    $("#ui_ddl_GMRCdecision").change(function () {
        $("#GMRCDecision").next("div.error").remove();
    });
    $("#ui_txt_macsNumber").on("keyup", function (e) {
        $('#macsNumber').next("div.error").remove();
    });
    $("#ui_txt_studyNumber").on("keyup", function (e) {
        $('#studyNumber').next("div.error").remove();
    });

    function SaveMRCDetails() {
        if (retVal) {
            if (recordType === "LocalMRC") {
                objMRCStudyReviewDetails = new Object();
                objMRCStudyReviewDetails.StudyId = $('#StudyId').val();
                objMRCStudyReviewDetails.RecordType = recordType;
                objMRCStudyReviewDetails.LocalMrcdecision = $('#ui_ddl_decision').val();
                objMRCStudyReviewDetails.LocalMrcdecisionComments = $('#ui_ddl_rejectedDecisionCmts').val();
                objMRCStudyReviewDetails.LocalMrcdateOfDecision = $("#ui_dt_dateOfDecision").val();
                objMRCStudyReviewDetails.LocalMrcdecisionMadeBy = $('#ui_ddl_decisionMadeBy').val();
                objMRCStudyReviewDetails.ANJU_ChangedBy = $('#LogedinUserName').val();
                objMRCStudyReviewDetails.ANJU_AddedBy = $('#LogedinUserName').val();
                $.ajax({
                    async: false,
                    type: "POST",
                    url: "/TaskWorkFlow/SaveMRCReviewDetails",
                    data: { "mrcStudyReview": objMRCStudyReviewDetails },
                    success: function (results) {
                        if (results.msgType === "Success") {
                            opener.location.reload();
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
            else if (recordType === "GlobalMRC") {
                objMRCStudyReviewDetails = new Object();
                objMRCStudyReviewDetails.StudyId = $('#StudyId').val();
                objMRCStudyReviewDetails.RecordType = recordType;
                objMRCStudyReviewDetails.SaereconciliationFrequency = $('#ui_ddl_saeFrequency').val();
                objMRCStudyReviewDetails.GlobalMrcdecision = $('#ui_ddl_GMRCdecision').val();
                objMRCStudyReviewDetails.GlobalMrcdecisionDate = $("#ui_dt_dateOfDecision").val();
                objMRCStudyReviewDetails.Macsnumber = $("#ui_txt_macsNumber").val();
                objMRCStudyReviewDetails.StudyNumber = $("#ui_txt_studyNumber").val();
                objMRCStudyReviewDetails.ANJU_ChangedBy = $('#LogedinUserName').val();
                objMRCStudyReviewDetails.ANJU_AddedBy = $('#LogedinUserName').val();
                $.ajax({
                    async: false,
                    type: "POST",
                    url: "/TaskWorkFlow/SaveMRCReviewDetails",
                    data: { "mrcStudyReview": objMRCStudyReviewDetails },
                    success: function (results) {
                        if (results.msgType === "Success") {
                            opener.location.reload();
                            var lsmailParameter = new Array();
                            var appUrl = $(location)[0].origin;
                            var decisionMadeby = "";
                            $.ajax({
                                async: false,
                                type: "GET",
                                url: "/TaskWorkFlow/GetMRCDetails",
                                data: { "studyId": $('#StudyId').val(), "loginUserName": $('#LogedinUserName').val() },
                                success: function (results) {
                                    if (results.length > 0) {
                                        decisionMadeby = results[0].LocalMrcdecisionMadeBy;
                                    }
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    popupNotification.show('Error', "error");
                                }
                            });
                            if ($('#ui_ddl_GMRCdecision').val() === "Approved") {
                                var StudyURL = "<a href='" + appUrl + "'> Navigate</a>";
                                lsmailParameter.push($("#ui_ddl_decisionMadeBy").val());
                                lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                                lsmailParameter.push($('#LogedinUserName').val());
                                lsmailParameter.push(StudyURL);
                                $.ajax({
                                    type: "POST",
                                    url: "/Common/SendEmail/",
                                    cache: false,
                                    data: { "mailMessage": "Approval letter (communication - Create/Deliver Approval Letter) MD", "lsparameter": lsmailParameter, "subParam": " ", "toMail": decisionMadeby, "ccMail": " " },
                                    dataType: "json",
                                    success: function (results) {
                                        popupNotification.show('Email Sent Successfully', "success");
                                    },
                                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                                        popupNotification.show('Sending Email Failed', "error");
                                    }
                                });
                            }
                            if ($('#ui_ddl_GMRCdecision').val() === "Conditionally Approved - Resubmission required") {
                                var StudyURL = "<a href='" + appUrl + "'> Navigate</a>";

                                lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                                lsmailParameter.push($('#LogedinUserName').val());
                                lsmailParameter.push(StudyURL);
                                $.ajax({
                                    type: "POST",
                                    url: "/Common/SendEmail/",
                                    cache: false,
                                    data: { "mailMessage": "IRC clear and resubmit", "lsparameter": lsmailParameter, "subParam": " ", "toMail": mslUserName, "ccMail": " " },
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
        }
        else {

            popupNotification.show("There are errors on the page.Please correct them to continue.", "error");
        }
    }
});