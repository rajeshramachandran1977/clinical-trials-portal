function onCancel() {
    //No need to delete the records if user click cancel button so commented below code
    //$.ajax({
    //    async: false,
    //    type: "GET",
    //    url: "/TaskWorkFlow/GetMRCDetails",
    //    data: { "studyId": $('#StudyId').val(), "loginUserName": $('#LogedinUserName').val(), "taskName": $("#TaskName").val() },
    //    success: function (results) {
    //        if (results.length !== 0 && results[0].MRCDecisionRejectedBy === "" && results[0].MRCRejectedDeliveryMethod === "" && $("#TaskName").val() === "Create/Deliver Rejection Letter") {
    //            window.close();
    //        }
    //        else {
    //            window.close();
    //        }
    //    },
    //    error: function (XMLHttpRequest, textStatus, errorThrown) {
    //        popupNotification.show('Error', "error");
    //    }
    //});
    window.close();
}
function filterDocumentSubType() {
    return {
        documentTypeId: $("#ui_ddl_documentType").val()
    };
}
var documentName = "";
function onSelect(e) {
    var src = $("#uploadfiles").val();
    $(this).next("div.error").remove();
    $.each(e.files, function (index, value) {
        $("#ui_txt_documentName").val(value.name);
        documentName = value.name;
    });
}
function onremove(e) {

    if (documentName !== e.files[0].name)
        $("#ui_txt_documentName").val(documentName);
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
    documentName = $("#ui_txt_documentName").val();
    e.data["additional[1]"] = $('#ui_ddl_documentStatus').val();
    e.data["additional[2]"] = $('#ui_ddl_documentType').data("kendoDropDownList").text();
    e.data["additional[3]"] = $('#ui_ddl_documentSubType').val();
    e.data["additional[4]"] = $('#ui_ddl_version').val();
    e.data["additional[5]"] = $('#ui_dt_originalDate').val() !== '' ? $('#ui_dt_originalDate').val() : ' ';
    e.data["additional[6]"] = $('#ui_dt_expiryDate').val() !== '' ? $('#ui_dt_expiryDate').val() : ' ';
    e.data["additional[7]"] = $('#LogedinUserName').val();
    e.data["additional[8]"] = $("#TaskName").val();
    e.data["additional[9]"] = $('#recordType').val();

}

var finaluploadName = "";
function onSelectfinalupload(e) {
    var src = $("#finaluploadfile").val();
    $(this).next("div.error").remove();
    $.each(e.files, function (index, value) {
        $("#ui_txt_documentNameFinal").val(value.name);
        finaluploadName = value.name;
    });
}

function onremovefinalupload(e) {
    if (finaluploadName !== e.files[0].name)
        $("#ui_txt_documentNameFinal").val(finaluploadName);
    else
        $("#ui_txt_documentNameFinal").val("");
}

function onsuccessfinalupload(e) {
    $(".k-upload-files.k-reset").find("li").remove();
}

function onUploadfinalupload(e) {
    $.each(e.files, function (index, value) {
        if ($("#ui_txt_documentNameFinal").val() === "")
            finaluploadName = value.name;
    });

    e.data = {};
    e.data["additional[0]"] = $("#ui_txt_documentNameFinal").val();
    e.data["additional[1]"] = $('#ui_ddl_documentStatusFinal').val();
    e.data["additional[2]"] = "Notification Letter";
    e.data["additional[3]"] = "";
    e.data["additional[4]"] = $('#ui_ddl_versionFinal').val();
    e.data["additional[5]"] = $('#ui_dt_originalDateFinal').val() !== '' ? $('#ui_dt_originalDate').val() : ' ';
    e.data["additional[6]"] = $('#ui_dt_expiryDateFinal').val() !== '' ? $('#ui_dt_expiryDate').val() : ' ';
    e.data["additional[7]"] = $('#LogedinUserName').val();

    if ($("#TaskName").val() === "Create/Deliver Rejection Letter" && $('#recordType').val() === "LocalMRC") {
        e.data["additional[8]"] = "LMRCFinalRejectedDocument";
    }
    else if ($("#TaskName").val() === "Create/Deliver Withdrawal Letter" && $('#recordType').val() === "LocalMRC") {
        e.data["additional[8]"] = "LMRCFinalWithdrawalDocument";
    }
    else if ($("#TaskName").val() === "Create/Deliver Rejection Letter" && $('#recordType').val() === "GlobalMRC") {
        e.data["additional[8]"] = "GMRCFinalRejectedDocument";
    }
    else if ($("#TaskName").val() === "Create/Deliver Withdrawal Letter" && $('#recordType').val() === "GlobalMRC") {
        e.data["additional[8]"] = "GMRCFinalWithdrawalDocument";
    }
    else if ($("#TaskName").val() === "Create/Deliver Approval Letter") {
        e.data["additional[8]"] = "GMRCApprovalFinalDocument";
    }

}

function additionalInfo() {
    if ($("#TaskName").val() === "Create/Deliver Rejection Letter" && $('#recordType').val() === "LocalMRC") {
        return {
            studyId: $('#StudyId').val(),
            subModuleName: "LMRCRejectedSupportDocuments"
        };
    }
    else if ($("#TaskName").val() === "Create/Deliver Withdrawal Letter" && $('#recordType').val() === "LocalMRC") {
        return {
            studyId: $('#StudyId').val(),
            subModuleName: "LMRCWithdrawalSupportDocuments"
        };
    }
    else if ($("#TaskName").val() === "Create/Deliver Rejection Letter" && $('#recordType').val() === "GlobalMRC") {
        return {
            studyId: $('#StudyId').val(),
            subModuleName: "GMRCRejectedSupportDocuments"
        };
    }
    else if ($("#TaskName").val() === "Create/Deliver Withdrawal Letter" && $('#recordType').val() === "GlobalMRC") {
        return {
            studyId: $('#StudyId').val(),
            subModuleName: "GMRCWithdrawalSupportDocuments"
        };
    }
    else if ($("#TaskName").val() === "Create/Deliver Approval Letter") {

        return {
            studyId: $('#StudyId').val(),
            subModuleName: "GMRCAdditionalApprovalDocuments"
        };
    }
}

function filterEditDocumentSubType() {
    return {
        documentTypeId: $("#ui_ddl_editdocumentType").val()
    };
}

var detailsTemplate = kendo.template($("#template").html());
function showDetails(e) {
    e.preventDefault();
    var grid = $("#ui_dtg_withdrawalLetter").getKendoGrid();

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
        if (retval === true) {
            UpdateDocumentDetails();
        }
        else {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });

    $("#btn-editDocumentCancel").click(function () {
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
        if ($("#ui_txt_editdocumentName").val() !== "" && $('#StudyId').val() > 0 && retval) {
            $.ajax({
                async: false,
                type: "GET",
                url: "/TaskWorkFlow/IsDocumentNameIsUnique",
                data: { "documentsName": $("#ui_txt_editdocumentName").val(), "studyId": $('#StudyId').val() },
                success: function (result) {
                    if (result) {
                        retval = result;
                    }
                    else {
                        retval = result;
                        $('#editDocumentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name must be unique. Addition of a Date or Version Number is suggested.</div>');
                    }

                }
            });
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
            objDocumentDetails.ExpirationDate = $("#ui_dt_editexpirationDate").val();
            objDocumentDetails.ANJU_ChangedBy = $('#LogedinUserName').val();
            $.ajax({
                async: false,
                type: "POST",
                url: "/TaskWorkFlow/UpdateDocumentDetails",
                data: { "documents": objDocumentDetails },
                success: function (results) {
                    if (results.msgType === "Success") {
                        $("#ui_dtg_withdrawalLetter").data("kendoGrid").dataSource.read();
                        $("#ui_dtg_withdrawalLetter").data("kendoGrid").refresh();
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
    var gridRowData = $("#ui_dtg_withdrawalLetter").data("kendoGrid");
    if (gridRowData) {
        var data = gridRowData.dataItem($(e).closest("tr"));
        var subModuleFolderName = data.SubModuleName;
        var fileName = data.DocumentNameWithOutExtension + data.DocumentExtension;
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + $('#StudyId').val();
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
        $('#documentSubType').next("div.error").remove();
        $('#editDocumentSubType').next("div.error").remove();
    }
}

$(document).ready(function () {
    $("#btn_RemoveDocument").hide();
    $("#finalNotificationDownload").hide();
    $('#notificationLetter').hide();
    var submodule = "";

    if ($("#TaskName").val() === "Create/Deliver Rejection Letter" && $('#recordType').val() === "LocalMRC") {
        submodule = "LMRCFinalRejectedDocument";
    }
    else if ($("#TaskName").val() === "Create/Deliver Withdrawal Letter" && $('#recordType').val() === "LocalMRC") {
        submodule = "LMRCFinalWithdrawalDocument";
    }
    else if ($("#TaskName").val() === "Create/Deliver Rejection Letter" && $('#recordType').val() === "GlobalMRC") {
        submodule = "GMRCFinalRejectedDocument";
    }
    else if ($("#TaskName").val() === "Create/Deliver Withdrawal Letter" && $('#recordType').val() === "GlobalMRC") {
        submodule = "GMRCFinalWithdrawalDocument";
    }
    else if ($("#TaskName").val() === "Create/Deliver Approval Letter") {
        submodule = "GMRCApprovalFinalDocument";
    }

    $.ajax({
        async: false,
        type: "GET",
        url: '/TaskWorkFlow/GetDocumentsBysubModule',
        data: { "studyId": $('#StudyId').val(), "submodule": submodule },
        success: function (result) {
            if (result.Data.length > 0) {
                $("#finalNotificationDownload").text(result.Data[0].DocumentNameWithOutExtension + result.Data[0].DocumentExtension);
                documentName = result.Data[0].DocumentNameWithOutExtension + result.Data[0].DocumentExtension;
            }
            else {
                $("#btn_RemoveDocument").hide();
                $("#finalNotificationDownload").hide();
            }
        }
    });   

    $("#ui_dtg_withdrawalLetter").data("kendoGrid").dataSource.read();
    var retval = true;
    
    if ($('#StudyNumber').val() === '') {
        $('#studyIdOrStudyNumber').append($('#StudyId').val() + ': ' + $('#TitleofTrial').val());
    }
    else {
        $('#studyIdOrStudyNumber').append($('#StudyNumber').val() + ': ' + $('#TitleofTrial').val());
    }

    //Enable Drug/Compound Type fields only on selection of Drug types
    $('#ui_ddl_signatory').change(function () {
        if ($('#ui_ddl_signatory').val() === "")
            $('#notificationLetter').hide();
        else
            $('#notificationLetter').show();
    });

    //Task “Create/Deliver Approval Letter”
    if ($("#TaskName").val() === "Create/Deliver Approval Letter") {
        $('#taskHeading').text("Create/Deliver Approval Letter");
        $('.withdrawalLetter').hide();
    }

    //Task “Create/Deliver Rejection Letter”
    if ($("#TaskName").val() === "Create/Deliver Rejection Letter") {
        $('#taskHeading').text("Create/Deliver Rejection Letter");
    }

    $("#btn-Submit").click(function () {
        ValidateMandatoryFields();
        SaveMRCDetails();
    });
    function ValidateMandatoryFields() {
        $(".error").remove();
        retval = true;

        if ($('#ui_ddl_deliveryMethod').val() === 'Select' || $('#ui_ddl_deliveryMethod').val() === "") {
            $('#deliveryMethod').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Delivery Method</div>');
            retval = false;
        }
        if ($("#finalNotificationDownload").text() === "DOWNLOAD") {
            $('#finalNotificationLetter').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload the final document</div>');
            retval = false;
        }
    }
    $("#ui_ddl_deliveryMethod").change(function () {
        $("#deliveryMethod").next("div.error").remove();
    });


    var lsmailParameter = new Array();
    var appUrl = $(location)[0].origin;
    function SaveMRCDetails() {     
        if (retval === true) {
            if ($('#TaskName').val() === "Create/Deliver Rejection Letter") {
                objMRCStudyReview = new Object();
                objMRCStudyReview.StudyId = $('#StudyId').val();
                objMRCStudyReview.RecordType = $('#recordType').val();
                objMRCStudyReview.MRCDecisionRejectedBy = $('#ui_ddl_signatory').val();
                objMRCStudyReview.MRCRejectedDeliveryMethod = $('#ui_ddl_deliveryMethod').val();
                objMRCStudyReview.ANJU_ChangedBy = $('#LogedinUserName').val();
                objMRCStudyReview.ANJU_AddedBy = $('#LogedinUserName').val();
                $.ajax({
                    async: false,
                    type: "POST",
                    url: "/TaskWorkFlow/SaveRejectedMRCReviewDetails",
                    data: { "mrcStudyReview": objMRCStudyReview },
                    success: function (results) {                      
                        if (results.msgType === "Success") {
                            opener.location.reload();
                            var StudyURL = "<a href='" + appUrl + "'> Navigate</a>";
                            lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                            lsmailParameter.push(StudyURL);
                            $.ajax({
                                type: "POST",
                                url: "/Common/SendEmail/",
                                cache: false,
                                data: { "mailMessage": "LOI rejection Letter", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $('#LogedinUserName').val(), "ccMail": " " },
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
            else if ($('#TaskName').val() === "Create/Deliver Withdrawal Letter") {
                objMRCStudyReview = new Object();
                objMRCStudyReview.StudyId = $('#StudyId').val();
                objMRCStudyReview.RecordType = $('#recordType').val();
                objMRCStudyReview.MRCDecisionWithdrawalBy = $('#ui_ddl_signatory').val();
                objMRCStudyReview.MRCWithdrawalDeliveryMethod = $('#ui_ddl_deliveryMethod').val();
                objMRCStudyReview.ANJU_ChangedBy = $('#LogedinUserName').val();
                objMRCStudyReview.ANJU_AddedBy = $('#LogedinUserName').val();
                $.ajax({
                    async: false,
                    type: "POST",
                    url: "/TaskWorkFlow/SaveWithdrawalMRCReviewDetails",
                    data: { "mrcStudyReview": objMRCStudyReview },
                    success: function (results) {
                        if (results.msgType === "Success") {
                            opener.location.reload();
                            lsmailParameter.push($('#txtUserName').val());
                            var StudyURL = "<a href='" + appUrl + "'> Navigate</a>";
                            lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                            lsmailParameter.push(StudyURL);
                            $.ajax({
                                type: "POST",
                                url: "/Common/SendEmail/",
                                cache: false,
                                data: { "mailMessage": "Study Withdrawal letter", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $('#LogedinUserName').val(), "ccMail": " " },
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
            if ($('#TaskName').val() === "Create/Deliver Approval Letter") {
                objMRCStudyReview = new Object();
                objMRCStudyReview.StudyId = $('#StudyId').val();
                objMRCStudyReview.GlobalMrcdecision = "Approved";
                objMRCStudyReview.RecordType = $('#recordType').val();
                objMRCStudyReview.MRCWithdrawalDeliveryMethod = $('#ui_ddl_deliveryMethod').val();
                objMRCStudyReview.ANJU_ChangedBy = $('#LogedinUserName').val();
                objMRCStudyReview.ANJU_AddedBy = $('#LogedinUserName').val();
                $.ajax({
                    async: false,
                    type: "POST",
                    url: "/TaskWorkFlow/UpdateMRCReviewDetails",
                    data: { "mrcStudyReview": objMRCStudyReview, "piUserName": $('#txtUserName').val() },
                    success: function (results) {
                        if (results.msgType === "Success") {
                            opener.location.reload();
                            var StudyURL = "<a href='" + appUrl + "'> Navigate</a>";
                            lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                            lsmailParameter.push(StudyURL);
                            $.ajax({
                                type: "POST",
                                url: "/Common/SendEmail/",
                                cache: false,
                                data: { "mailMessage": "Approval letter (communication - Create/Deliver Approval Letter)", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $('#LogedinUserName').val(), "ccMail": " " },
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
        else {

            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
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

            $("#addDocModal").modal("hide");
            $("#frm_documentDetails")[0].reset();
            setTimeout(function () {
                $("#ui_dtg_withdrawalLetter").data("kendoGrid").dataSource.read();
                $("#ui_dtg_withdrawalLetter").data("kendoGrid").refresh();
            }, 1000);
        }
        else {

            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    }).on('mouseup', function () {
        $("#ui_dtg_withdrawalLetter").data("kendoGrid").dataSource.read();
        $("#ui_dtg_withdrawalLetter").data("kendoGrid").refresh();
    });

    function ValidateDocumentmandetoryFields() {
        $(".error").remove();
        DocumentCheck = true;

        if ($("#uploadfiles").closest(".k-upload").find(".k-file").length <= 0) {
            $('#uploadAdditionalFiles').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
            DocumentCheck = false;
        }
        if ($("#ui_txt_documentName").val() === "") {
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
                $('#documentSubType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document SubType is required</div>');
                DocumentCheck = false;
            }
        }
        if ($('#ui_ddl_version').val() === 'Select' || $('#ui_ddl_version').val() === "") {
            $('#version').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document version is required</div>');
            DocumentCheck = false;
        }
        if ($("#ui_txt_documentName").val() !== "" && $('#StudyId').val() > 0 && DocumentCheck ) {
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
        $('#uploadAdditionalFiles').next("div.error").remove();
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
        $("#addDocModal").modal("hide");
        $("#frm_documentDetails")[0].reset();
    });
    var finalDocumentCheck = true;
    $("#btn-FinalDocumentSubmit").click(function () {
        ValidateFinalDocumentMandetoryFields();
        if (finalDocumentCheck === true) {
            $(".k-upload-selected").click();
            $("#addNotificationDocModal").modal("hide");
            $("#btn_RemoveDocument").show();
            $("#finalNotificationDownload").show();
            $("#finalNotificationDownload").text(finaluploadName);

        }
        else {

            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });

    $("#btn-FinalDocumentCancel").click(function () {
        $("#addNotificationDocModal").modal("hide");

    });

    function ValidateFinalDocumentMandetoryFields() {
        $(".error").remove();
        finalDocumentCheck = true;

        if ($("#finaluploadfile").closest(".k-upload").find(".k-file").length <= 0) {
            $('#finalFileUpload').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
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
        if ($("#ui_txt_documentNameFinal").val() !== "" && $('#StudyId').val() > 0 && finalDocumentCheck ) {
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
    $("#finaluploadfile").change(function () {
        $('#finalFileUpload').next("div.error").remove();
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

        //fileName = $("#ui_txt_documentNameFinal").val();'
        if (finaluploadName !== "")
            fileName = finaluploadName;
        else
            fileName = $("#finalNotificationDownload").text();

        if ($("#TaskName").val() === "Create/Deliver Rejection Letter" && $('#recordType').val() === "LocalMRC") {
            subModuleFolderName = "LMRCFinalRejectedDocument";
        }
        else if ($("#TaskName").val() === "Create/Deliver Withdrawal Letter" && $('#recordType').val() === "LocalMRC") {
            subModuleFolderName = "LMRCFinalWithdrawalDocument";
        }
        else if ($("#TaskName").val() === "Create/Deliver Rejection Letter" && $('#recordType').val() === "GlobalMRC") {
            subModuleFolderName = "GMRCFinalRejectedDocument";
        }
        else if ($("#TaskName").val() === "Create/Deliver Withdrawal Letter" && $('#recordType').val() === "GlobalMRC") {
            subModuleFolderName = "GMRCFinalWithdrawalDocument";
        }
        else if ($("#TaskName").val() === "Create/Deliver Approval Letter") {
            subModuleFolderName = "GMRCApprovalFinalDocument";
        }
        studyId = $('#StudyId').val();
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + studyId;
    });

    $('#btn_RemoveDocument').click(function () {
        objDocuments = new Object();
        objDocuments.StudyId = $('#StudyId').val();
        if ($("#TaskName").val() === "Create/Deliver Rejection Letter" && $('#recordType').val() === "LocalMRC") {
            objDocuments.SubModuleName = "LMRCFinalRejectedDocument";
        }
        else if ($("#TaskName").val() === "Create/Deliver Withdrawal Letter" && $('#recordType').val() === "LocalMRC") {
            objDocuments.SubModuleName = "LMRCFinalWithdrawalDocument";
        }
        else if ($("#TaskName").val() === "Create/Deliver Rejection Letter" && $('#recordType').val() === "GlobalMRC") {
            objDocuments.SubModuleName = "GMRCFinalRejectedDocument";
        }
        else if ($("#TaskName").val() === "Create/Deliver Withdrawal Letter" && $('#recordType').val() === "GlobalMRC") {
            objDocuments.SubModuleName = "GMRCFinalWithdrawalDocument";
        }
        else if ($("#TaskName").val() === "Create/Deliver Approval Letter") {
            objDocuments.SubModuleName = "GMRCApprovalFinalDocument";
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
    });
});