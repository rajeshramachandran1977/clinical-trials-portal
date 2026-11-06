function onChangeofICFReview(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Code === "Redlined") {
        $('#ICFUpload').show();
        $('#icfDownload').hide();
        $('#ui_btn_removeIcfDocument').hide();
    }
    else {
        $('#ICFUpload').hide();
    }
}
function onCancel() {
    window.close();
}

function additionalInfo() {
    return {
        studyId: $('#StudyId').val(),
        subModuleName: "ICFDocument"
    };
}

function Show(e) {
    var gridRowData = $("#ui_dtg_ICFDocuments").data("kendoGrid");
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
    var grid = $("#ui_dtg_ICFDocuments").getKendoGrid();

    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    var wnd = $("#Details").data("kendoWindow");
    wnd.content(detailsTemplate(dataItem));
    wnd.center().open();

    //Fill document window   
    var retVal = true;
    var LogedinUserName = $('#txtUserName').val();

    $("#ui_txt_uploadedBy").val(LogedinUserName);
    $("#ui_txt_documentName").val(dataItem.DocumentName);
    $("#ui_ddl_documentStatus").data('kendoDropDownList').value(dataItem.DocumentStatus);
    $("#ui_ddl_documentType").data('kendoDropDownList').value(dataItem.DocumentTypeId);
    $("#ui_ddl_documentSubType").data('kendoDropDownList').value(dataItem.DocumentSubType);
    $("#ui_ddl_amendmentVersion").data('kendoDropDownList').value(dataItem.DocumentVersion);
    $("#ui_dt_originalDate").data("kendoDatePicker").value(dataItem.OriginalDate);
    $("#ui_dt_expirationDate").data("kendoDatePicker").value(dataItem.ExpirationDate);

    var fileName = dataItem.DocumentNameWithOutExtension + dataItem.DocumentExtension;
    var DocumentNameWithOutExtension = dataItem.DocumentNameWithOutExtension;
    var DocumentExtension = dataItem.DocumentExtension;
    var subModuleFolderName = dataItem.SubModuleName;
    var studyId = dataItem.StudyId;
    var documentId = dataItem.DocumentId;

    $('.fileDownload').click(function () {
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + studyId;

    });

    $("#ui_btn_documentSubmit").click(function () {
        ValidateModalMandatoryFields();
        if (retVal === true)
            SaveDcouemntDetails();
        else
            popupNotification.show("There are errors on the page.Please correct them to continue.", "error");
    });

    $("#ui_btn_documentCancel").click(function () {
        $("#Details").data("kendoWindow").close();
    });

    function ValidateModalMandatoryFields() {
        retVal = true;
        $(".error").remove();

        if ($("#ui_txt_documentName").val() === "" || $("#ui_txt_documentName").val() === null) {
            $('#documentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name is required</div>');
            retVal = false;
        }
        if ($('#ui_ddl_documentStatus').val() === 'Select' || $('#ui_ddl_documentStatus').val() === "") {
            $('#documentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Status is required</div>');
            retVal = false;
        }
        if ($('#ui_ddl_documentStatus').val() === 'Pending Review') {
            $('#documentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document should be reviewed, Please change the Document Status from Pending Review</div>');
            retVal = false;
        }
        if ($('#ui_ddl_documentType').val() === 'Select' || $('#ui_ddl_documentType').val() === "") {
            $('#documentType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Type is required</div>');
            retVal = false;
        }
        if ($('#ui_ddl_documentType').val() !== 'Select' || $('#ui_ddl_documentType').val() !== "") {
            if (($('#ui_ddl_documentSubType').val() === 'Select' || $('#ui_ddl_documentSubType').val() === "") && $('#documentSubTypeLabel').hasClass("mandatory")) {
                $('#documentSubType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Sub-Type is required</div>');
                retVal = false;
            }
        }
        if ($('#ui_ddl_amendmentVersion').val() === 'Select' || $('#ui_ddl_amendmentVersion').val() === "") {
            $('#amendmentVersion').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Original / Amendment Version is required</div>');
            retVal = false;
        }
        var grid = $("#ui_dtg_ICFDocuments").getKendoGrid();
        var datas = grid.dataSource.data();
        for (var i = 0; i < datas.length; i++) {
            if (documentId !== datas[i].DocumentId && datas[i].DocumentNameWithOutExtension === $("#ui_txt_documentName").val()) {
                $('#documentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name should be Unique</div>');
                retVal = false;
                break;
            }
        }
        if ($("#ui_txt_documentName").val() !== "" && $('#StudyId').val() > 0 && retVal === true) {
            $.ajax({
                async: false,
                type: "GET",
                url: "/TaskWorkFlow/IsDocumentNameIsUnique",
                data: { "documentsName": $("#ui_txt_documentName").val(), "studyId": $('#StudyId').val() },
                success: function (result) {
                    if (result) {
                        retVal = result;
                    }
                    else {
                        retVal = result;
                        $('#documentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name must be unique. Addition of a Date or Version Number is suggested.</div>');
                    }

                }
            });
        }
    }

    $('#ui_txt_documentName').on("keyup", function () {
        $('#documentName').next("div.error").remove();
    });
    $('#ui_ddl_documentStatus').on("change", function () {
        $('#documentStatus').next("div.error").remove();
    });
    $('#ui_ddl_documentType').on("change", function () {
        $('#documentType').next("div.error").remove();
    });
    $('#ui_ddl_documentSubType').on("change", function () {
        $('#documentSubType').next("div.error").remove();
    });
    $('#ui_ddl_amendmentVersion').on("change", function () {
        $('#amendmentVersion').next("div.error").remove();
    });

    function SaveDcouemntDetails() {
        if (retVal === true) {
            objDocumentDetails = new Object();
            objDocumentDetails.DocumentId = documentId;
            objDocumentDetails.StudyId = $('#StudyId').val();
            objDocumentDetails.SubModuleName = subModuleFolderName;
            objDocumentDetails.DocumentName = $("#ui_txt_documentName").val();
            objDocumentDetails.DocumentNameWithOutExtension = DocumentNameWithOutExtension;
            objDocumentDetails.DocumentExtension = DocumentExtension;
            objDocumentDetails.DocumentStatus = $('#ui_ddl_documentStatus').data("kendoDropDownList").text();
            objDocumentDetails.DocumentType = $('#ui_ddl_documentType').data("kendoDropDownList").text();
            objDocumentDetails.DocumentSubType = $('#ui_ddl_documentSubType').data("kendoDropDownList").text();
            objDocumentDetails.DocumentVersion = $('#ui_ddl_amendmentVersion').data("kendoDropDownList").text();
            objDocumentDetails.OriginalDate = $("#ui_dt_originalDate").val();
            objDocumentDetails.ExpirationDate = $("#ui_dt_expirationDate").val();
            objDocumentDetails.ANJU_ChangedBy = $('#LogedinUserName').val();
            $.ajax({
                async: false,
                type: "POST",
                url: "/TaskWorkFlow/UpdateDocumentDetails",
                data: { "documents": objDocumentDetails },
                success: function (results) {
                    if (results.msgType === "Success") {
                        $("#ui_dtg_ICFDocuments").data("kendoGrid").dataSource.read();
                        $("#ui_dtg_ICFDocuments").data("kendoGrid").refresh();
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

            popupNotification.show("There are errors on the page.Please correct them to continue.", "error");
        }
    }
}

function filterDocumentSubType() {
    return {
        documentTypeId: $("#ui_ddl_documentType").val()
    };
}

var RedLinedDocumnetName = "";
function onSelectICFDocuments(e) {
    var src = $("#icfUploadFiles").val();
    $(this).next("div.error").remove();
    $.each(e.files, function (index, value) {
        RedLinedDocumnetName = value.name;
        $("#ui_txt_icfDocumentName").val(value.name);
    });

}
function onremoveICFDocuments(e) {
    $("#ui_txt_icfDocumentName").val("");

}
function onsuccessICFDocuments(e) {

    $(".k-upload-files.k-reset").find("li").remove();
    $.each(e.files, function (index, value) {
        RedLinedDocumnetName = value.name;
    });

}
function onUploadICFDocuments(e) {
    e.data = {};
    e.data["additional[0]"] = $("#ui_txt_icfDocumentName").val();
    e.data["additional[1]"] = $('#ui_ddl_icfDocumentStatus').val();
    e.data["additional[2]"] = $('#ui_lbl_documentType').text();
    e.data["additional[3]"] = $('#ui_lbl_documentSubType').text();
    e.data["additional[4]"] = $('#ui_ddl_icfVersion').val();
    e.data["additional[5]"] = $('#ui_dt_icfOriginalDate').val() !== '' ? $('#ui_dt_icfOriginalDate').val() : ' ';
    e.data["additional[6]"] = $('#ui_dt_icfExpiryDate').val() !== '' ? $('#ui_dt_icfExpiryDate').val() : ' ';
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

$(document).ready(function () {
    $('#ICFUpload').hide();
    var DocumentCheck = true;
    var retVal = true;
    var TaskName = $("#TaskName").val();

    $("#ui_btn_icfDocumentCancel").click(function () {
        $("#icfDocModal").modal("hide");
        $("#frm_icfDocumentDetails")[0].reset();
    });

    $("#ui_btn_icfDocumentSubmit").click(function () {
        ValidateRedlinedDocumentMandetoryFields();
        if (DocumentCheck === true) {
            $(".k-upload-selected").click();
            $("#icfDocModal").modal("hide");
            $("#ui_btn_removeIcfDocument").show();
            $("#icfDownload").show();

            $("#icfDownload").text(RedLinedDocumnetName);

        }
        else {

            popupNotification.show("There are errors on the page.Please correct them to continue.", "error");
        }

    });

    function ValidateRedlinedDocumentMandetoryFields() {
        $(".error").remove();
        DocumentCheck = true;

        if ($('#ui_txt_icfDocumentName').val() === "") {
            $('#icfDocumentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name is required</div>');
            DocumentCheck = false;

        } if ($('#ui_ddl_icfDocumentStatus').val() === 'Select' || $('#ui_ddl_icfDocumentStatus').val() === "") {
            $('#icfDocumentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Status is required</div>');
            DocumentCheck = false;
        }
        if ($('#ui_ddl_icfDocumentStatus').val() === 'Pending Review') {
            $('#icfDocumentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document should be reviewed, Please change the Document Status from Pending Review</div>');
            DocumentCheck = false;
        }
        if ($('#ui_ddl_icfVersion').val() === 'Select' || $('#ui_ddl_icfVersion').val() === "") {
            $('#icfVersion').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document version is required</div>');
            DocumentCheck = false;
        }
        if ($("#icfUploadFiles").closest(".k-upload").find(".k-file").length <= 0) {
            $('#icfFileUpload').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
            DocumentCheck = false;
        }
        if ($("#ui_txt_icfDocumentName").val() !== "" && $('#StudyId').val() > 0 && DocumentCheck) {
            $.ajax({
                async: false,
                type: "GET",
                url: "/TaskWorkFlow/IsDocumentNameIsUnique",
                data: { "documentsName": $("#ui_txt_icfDocumentName").val(), "studyId": $('#StudyId').val() },
                success: function (result) {
                    if (result) {
                        DocumentCheck = result;
                    }
                    else {
                        DocumentCheck = result;
                        $('#icfDocumentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name must be unique. Addition of a Date or Version Number is suggested.</div>');
                    }

                }
            });
        }
    }

    $("#icfUploadFiles").change(function () {
        $('#icfFileUpload').next("div.error").remove();
        $('#icfDocumentName').next("div.error").remove();
    });
    $('#ui_txt_icfDocumentName').on("keyup", function () {
        $('#icfDocumentName').next("div.error").remove();
    });
    $('#ui_ddl_icfDocumentStatus').on("change", function () {
        $('#icfDocumentStatus').next("div.error").remove();
    });
    $('#ui_ddl_icfVersion').on("change", function () {
        $('#icfVersion').next("div.error").remove();
    });

    $('#ui_btn_removeIcfDocument').click(function () {
        objDocuments = new Object();
        objDocuments.StudyId = $('#StudyId').val();
        objDocuments.SubModuleName = "RedlinedICFDocument";
        objDocuments.ANJU_ChangedBy = $('#LogedinUserName').val();

        $.ajax({
            async: false,
            type: "POST",
            url: "/TaskWorkFlow/DeleteDocuments",
            data: { "documents": objDocuments },
            success: function (results) {
                if (results.length !== 0) {
                    $("#icfDownload").hide();
                    $("#frm_icfDocumentDetails")[0].reset();
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

        $('#icfDownload').text('DOWNLOAD');
        $('#ui_btn_removeIcfDocument').hide();

    });

    $('#icfDownload').click(function () {
        subModuleFolderName = "RedlinedICFDocument";
        studyId = $('#StudyId').val();
        window.location = "/NewStudy/DownloadFiles?fileName=" + RedLinedDocumnetName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + studyId;
    });

    $("#ui_btn_submit").click(function () {
        ValidateMandatoryFields();
        SaveICFDetails();
    });

    function ValidateMandatoryFields() {
        $(".error").remove();
        retVal = true;

        var grid = $("#ui_dtg_ICFDocuments").getKendoGrid();
        var datas = grid.dataSource.data();
        for (var item in datas) {
            if (datas[item].DocumentStatus === null || datas[item].DocumentName === null || datas[item].DocumentType === null || datas[item].DocumentSubType === null || datas[item].DocumentVersion === null) {
                $('#ui_dtg_ICFDocuments').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please review and classify all documents</div>');
                retVal = false;
                break;
            }
        }

        if ($('#ui_ddl_icfReview').val() === 'Select' || $('#ui_ddl_icfReview').val() === "") {
            $('#icfReview').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please Specify ICF Review Decision</div>');
            retVal = false;
        }
        if ($('#ui_ddl_icfReview').val() === 'Redlined') {

            var hyperLinkText = $('#icfDownload').text(); // get the name          

            if (hyperLinkText === "DOWNLOAD") {
                $('#icfDownload').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload Redlined ICF </div>');
                retVal = false;
            }
        }
    }

    $("#ui_ddl_icfReview").change(function () {
        $('#icfReview').next("div.error").remove();
    });
    function SaveICFDetails() {
        if (retVal) {
            objGMRCApprovalTask = new Object();
            objGMRCApprovalTask.StudyId = $('#StudyId').val();
            objGMRCApprovalTask.TaskName = $("#TaskName").val();
            objGMRCApprovalTask.Decision = $('#ui_ddl_icfReview').val();
            objGMRCApprovalTask.Comments = $('#ui_txt_ICFReviewCmts').val();
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
                        lsmailParameter.push($('#txtUserName').val());
                        lsmailParameter.push(StudyURL);
                        $.ajax({

                            type: "POST",
                            url: "/Common/SendEmail/",
                            cache: false,
                            data: { "mailMessage": "Review ICF", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $('#LogedinUserName').val(), "ccMail": " " },
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

            popupNotification.show("There are errors on the page.Please correct them to continue.", "error");
        }

    }
});