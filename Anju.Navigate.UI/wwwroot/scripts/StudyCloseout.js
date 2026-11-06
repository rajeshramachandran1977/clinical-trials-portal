function onCancel() {
    window.close();
}


function additionalInfo() {

    return {
        studyId: $('#StudyId').val(),
        subModuleName: "FinalStudyReport"
    };

}

var documentName = "";
function onSelect(e) {
    var src = $("#uploadCloseStudyFiles").val();
    $(this).next("div.error").remove();
    $.each(e.files, function (index, value) {
        $("#ui_txt_documentNameCloseStudy").val(value.name);
        documentName = value.name;
    });
}
function onremove(e) {

    if (documentName !== e.files[0].name)
        $("#ui_txt_documentNameCloseStudy").val(documentName);
    else
        $("#ui_txt_documentNameCloseStudy").val("");

}

function onUpload(e) {
    $.each(e.files, function (index, value) {
        documentName = value.name;
    });
    e.data = {};
    e.data["additional[0]"] = $("#ui_txt_documentNameCloseStudy").val();
    e.data["additional[1]"] = $('#ui_ddl_documentStatusCloseStudy').val();
    e.data["additional[2]"] = $('#ui_ddl_documentTypeCloseStudy').data("kendoDropDownList").text();
    e.data["additional[3]"] = $('#ui_ddl_documentSubTypeCloseStudy').val();
    e.data["additional[4]"] = $('#ui_ddl_versionCloseStudy').val();
    e.data["additional[5]"] = $('#ui_dt_originalDateCloseStudy').val() !== '' ? $('#ui_dt_originalDateCloseStudy').val() : ' ';
    e.data["additional[6]"] = $('#ui_dt_expiryDateCloseStudy').val() !== '' ? $('#ui_dt_expiryDateCloseStudy').val() : ' ';
    e.data["additional[7]"] = $('#LogedinUserName').val();
    e.data["additional[8]"] = $("#TaskName").val();

}


function filterEditDocumentSubType() {
    return {
        documentTypeId: $("#ui_ddl_editDocumentType").val()
    };
}

function filterCloseStudyDocumentSubType() {
    return {
        documentTypeId: $("#ui_ddl_documentTypeCloseStudy").val()
    };
}
function showDetails(e) {
    e.preventDefault();
    var detailsTemplate = kendo.template($("#finalStudyTemplate").html());
    var grid = $("#ui_dtg_FinalStudyDocuments").getKendoGrid();
    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    var wnd = $("#FinalStudyDetails").data("kendoWindow");
    wnd.content(detailsTemplate(dataItem));
    wnd.center().open();

    //Fill document window   
    var retVal = true;

    $("#ui_txt_editdocumentName").val(dataItem.DocumentName);
    $("#ui_ddl_editDocumentStatus").data('kendoDropDownList').value(dataItem.DocumentStatus);
    $("#ui_ddl_editDocumentType").data('kendoDropDownList').value(dataItem.DocumentTypeId);
    $("#ui_ddl_editDocumentSubType").data('kendoDropDownList').value(dataItem.DocumentSubType);
    $("#ui_ddl_amendmentVersion").data('kendoDropDownList').value(dataItem.DocumentVersion);
    $("#ui_dt_editOriginalDate").data("kendoDatePicker").value(dataItem.OriginalDate);
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

    $("#ui_btn_editFinalStudyDocumentSubmit").click(function () {
        ValidateEditMandetoryFields();
        if (retVal === true) {
            UpdateDcouemntDetails();
        }
        else {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });

    $("#ui_btn_editFinalStudyDocumentCancel").click(function () {
        $("#FinalStudyDetails").data("kendoWindow").close();
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
        if ($('#ui_ddl_amendmentVersion').val() === 'Select' || $('#ui_ddl_amendmentVersion').val() === "") {
            $('#amendmentVersion').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Version is required</div>');
            retVal = false;
        }
        if ($("#ui_txt_editDocumentName").val() !== "" && $('#StudyId').val() > 0 && retVal) {
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
    $("#ui_ddl_amendmentVersion").change(function () {
        $('#amendmentVersion').next("div.error").remove();
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
            objDocumentDetails.DocumentSubType = ($('#ui_ddl_editDocumentSubType').data("kendoDropDownList").text() === "Select") ? "" : $('#ui_ddl_editDocumentSubType').data("kendoDropDownList").text();
            objDocumentDetails.DocumentVersion = $('#ui_ddl_amendmentVersion').data("kendoDropDownList").text();
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
                        $("#ui_dtg_FinalStudyDocuments").data("kendoGrid").dataSource.read();
                        $("#ui_dtg_FinalStudyDocuments").data("kendoGrid").refresh();
                        $("#FinalStudyDetails").data("kendoWindow").close();

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
    var gridRowData = $("#ui_dtg_FinalStudyDocuments").data("kendoGrid");
    if (gridRowData) {
        var data = gridRowData.dataItem($(e).closest("tr"));
        var subModuleFolderName = data.SubModuleName;
        var fileName = data.DocumentNameWithOutExtension + data.DocumentExtension;
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + $('#StudyId').val();
    }
}

var TaskName = $('#taskName').val();

$('#IRBClosure').hide();
$('#submitIRBClosure').hide();
$('#submitFinalStudyData').hide();
$('#closeStudy').hide();
$('#finalStudyData').hide();
$('.uploadDocuments').hide();

// Task “Initiate Study Closeout”
if (TaskName === "Initiate Study Closeout") {
    $('#panelForPI').hide();
}

// Action "TPSR is in CREDI"
if (TaskName === "TPSR Reconciliation") {
    $('#taskHeading').text("Confirm Milestone Achieved");
    $('#panelForPI').hide();
    $('#checkboxLabel').text('I hereby deem "TPSR" milestone as complete');
}

// Action "Drug Reconciliation "
if (TaskName === "Drug Reconciliation") {
    $('#taskHeading').text("Confirm Milestone Achieved");
    $('#panelForPI').hide();
    $('#checkboxLabel').text('I hereby deem "Drug Reconciliation" milestone as complete');
}
// Action"Budget Reconciliation "
if (TaskName === "Budget Reconciliation") {
    $('#taskHeading').text("Confirm Milestone Achieved");
    $('#panelForPI').hide();
    $('#checkboxLabel').text('I hereby deem "Budget Reconciliation" milestone as complete');
}
// Action "PO Closeout Requested "
if (TaskName === "PO Closeout Requested") {
    $('#taskHeading').text("Confirm Milestone Achieved");
    $('#panelForPI').hide();
    $('#checkboxLabel').text('I hereby deem "PO Closeout Requested" milestone as complete');
}

// Action "Final Study Data / Report"
if (TaskName === "Final Study Data/Report") {
    $('#taskHeading').text("Submit Final Study Data / Report");
    $('#piPanel').text("Please upload the requested document in the field provided below");
    $('#chkbox').hide();
    $('#finalStudyData').show();
}
if (TaskName === "Resubmit Final Study Data / Report") {

    $('#taskHeading').text("Resubmit Final Study Data / Report");
    $('#piPanel').text("Please upload the requested document in the field provided below");
    $('#chkbox').hide();
    $('#finalStudyData').show();
}
//Task “Document Submission Review ”[IRB Closure Notification Document] 
//same for : 3.1.9.1.7 Task “Document Submission Review ”[for Final Study Data / Report] 
//same for : 3.1.9.1.13 Action “Document Submission Review] 
if (TaskName === "Document Submission Review") {
    $('#taskHeading').text("Document Submission Review");
    $('#panelForPI').hide();
    $('#chkbox').hide();
    $('#IRBClosure').show();
}

// Action “IRB Study Closure Notification” 
if (TaskName === "Submit IRB Study Closure Notification") {
    $('#taskHeading').text("Submit IRB Study Closure Notification");
    $('#piPanel').text("Please upload the requested document in the field provided below.");
    $('#chkbox').hide();
    $('#submitIRBClosure').show();
}

// Action “Submit Final Study / Report”
// 3.1.9.1.10 Action “Resubmit Final Study / Report”[Resubmit Final Study Data / Report] 
if (TaskName === "Submit Final Study Data / Report") {
    $('#taskHeading').text("Submit Final Study Data / Report");
    $('#piPanel').text("Please upload the requested document in the field provided below.");
    $('#chkbox').hide();
    $('#submitFinalStudyData').show();
}
// Action “Close Study (Trial Leader)” 
if (TaskName === "Close Study") {
    $('#taskHeading').text("Close Study");
    $('#piPanel').text("Please select the appropriate Reason for Closure from the dropdown list. Checking the box is acknowledgement that all study closure related activities have been completed.");
    $('#chkbox').hide();
    $('#closeStudy').show();
}
// Action “Upload Documents [Submit Updated Document(s)] 
if (TaskName === "Submit Updated Document(s)") {
    $('#taskHeading').text("Submit Updated Document(s)");
    $('#piPanel').text("Please upload document(s) pertaining to the study by clicking on the + Add Document button below");
    $('#chkbox').hide();
    $('.uploadDocuments').show();
}
function onSubTypeDataBound(e) {
    if ($("#ui_ddl_documentSubTypeCloseStudy").data("kendoDropDownList").dataSource._data.length > 0) {
        $("#ui_ddl_documentSubTypeCloseStudy").data("kendoDropDownList").enable(true);
        $('#documentSubTypeCloseStudyLabel').addClass("mandatory");
    }
    else {
        $("#ui_ddl_documentSubTypeCloseStudy").data("kendoDropDownList").enable(false);
        $('#documentSubTypeCloseStudyLabel').removeClass("mandatory");
    }
}

function onDocumentTypeCloseStudyChange() {
    if ($("#ui_ddl_documentTypeCloseStudy").data("kendoDropDownList").value() === "") {
        $('#documentSubTypeCloseStudyLabel').removeClass("mandatory");
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

function onEditDocumentTypeChange() {
    if ($("#ui_ddl_editDocumentType").data("kendoDropDownList").value() === "") {
        $('#editDocumentSubTypeLabel').removeClass("mandatory");
        $('#editDocumentSubType').next("div.error").remove();
    }
}

$(document).ready(function () {
    $("#closeStudyDownload").hide();
    $('#btn_RemoveCloseStudyDocument').hide();
    var retVal = true;
    $('#ui_btn_submit').click(function () {
        ValidateMandatoryFields();

        if (TaskName === "Final Study Data/Report" || TaskName === "Resubmit Final Study Data / Report") {
            if (retVal === true)
                $(".k-upload-selected").click();
            UpdateTaskDetails(TaskName);
            
           
        }
        if (TaskName === "TPSR Reconciliation" || TaskName === "Drug Reconciliation" || TaskName === "Budget Reconciliation" || TaskName === "PO Closeout Requested" || TaskName === "Document Submission Review" || TaskName === "Close Study") {
            UpdateTaskDetails(TaskName);
        }
    });


    $(".k-file-name").css("cursor", "pointer");
    $(".k-file-name").click(function () {
        var fileName = this.innerText;
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=FinalStudyReport';
    });


    function ValidateMandatoryFields() {
        retVal = true;
        $('.error').remove();
        var isNotChecked = false;

        if (TaskName === "Initiate Study Closeout") {
            isNotChecked = $('#resubmissionReason').prop("checked");
            if (isNotChecked === false) {
                $('#chkbox').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>please check the reason for resubmission</div>');
                retVal = false;
            }
            else if (isNotChecked === true) {
                $("#submitModal").modal('show');
            }
        }
        if (TaskName === "TPSR Reconciliation" || TaskName === "Drug Reconciliation" || TaskName === "Budget Reconciliation" || TaskName === "PO Closeout Requested") {
            isNotChecked = $('#resubmissionReason').prop("checked");
            if (isNotChecked === false) {
                $('#chkbox').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>please check the Checkbox to processed. </div>');
                retVal = false;
            }
        }
        if (TaskName === "Final Study Data/Report" || TaskName === "Resubmit Final Study Data / Report") {
            if ($("#fileFinalStudyData").closest(".k-upload").find(".k-file").length <= 0) {
                $('#finalStudyData').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
                retVal = false;
            }
        }
        if (TaskName === "Document Submission Review") {
            var grid = $("#ui_dtg_FinalStudyDocuments").getKendoGrid();
            var datas = grid.dataSource.data();
            for (var item in datas) {
                if (datas[item].DocumentStatus === null || datas[item].DocumentName === null || datas[item].DocumentType === null || datas[item].DocumentVersion === null) {
                    $('#ui_dtg_FinalStudyDocuments').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please review and classify all documents</div>');
                    retVal = false;
                    break;
                }
            }
            if ($('#ui_ddl_reviewStatus').val() === 'Select' || $('#ui_ddl_reviewStatus').val() === "") {
                $('#ReviewStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Review Status</div>');
                retVal = false;
            }
            if ($('#ui_txt_reviewComments').val() === "") {
                $('#ReviewComments').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>The required field Review Comments has not been filled in.</div>');
                retVal = false;
            }
        }
        if (TaskName === "Close Study") {

            if ($('#ui_ddl_reasonForClosure').val() === 'Select' || $('#ui_ddl_reasonForClosure').val() === "") {
                $('#reasonForClosure').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Reason for Closure</div>');
                retVal = false;
            }
            var IsClosureTaskCompleted = $('#studyClosureCheckbox').prop("checked");
            if (IsClosureTaskCompleted === false) {
                $('#ClosureCheckbox').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>The required field All required study-closure related activities have been completed. has not been filled in.</div>');
                retVal = false;
            }
            if ($("#closeStudyDownload").text() === "DOWNLOAD") {
                $('#closeStudyLetter').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload the study closure document</div>');
                retval = false;
            }
        }


    }
    $("#ui_ddl_reasonForClosure").change(function () {
        $('#reasonForClosure').next("div.error").remove();
    });
    $('#ClosureCheckbox').change(function () {
        $('#ClosureCheckbox').next("div.error").remove();
    });


    $("#ui_ddl_reviewStatus").change(function () {
        $('#ReviewStatus').next("div.error").remove();
    });

    $('#ui_txt_reviewComments').on("keyup", function () {
        $('#ReviewComments').next("div.error").remove();
    });

    function UpdateTaskDetails(TaskName) {
        if (retVal) {
            objGMRCApprovalTask = new Object();
            objGMRCApprovalTask.StudyId = $('#StudyId').val();
            objGMRCApprovalTask.TaskName = TaskName;
            objGMRCApprovalTask.IsTaskCompleted = true;
            objGMRCApprovalTask.IsGearTaskCompleted = false;
            objGMRCApprovalTask.ANJU_ChangedBy = $('#LogedinUserName').val();
            if (TaskName === "Document Submission Review") {
                objGMRCApprovalTask.Decision = $('#ui_ddl_reviewStatus').val();
                objGMRCApprovalTask.Comments = $('#ui_txt_reviewComments').val();
                objGMRCApprovalTask.AssignedTo = $('#txtUserName').val();
            }
            if (TaskName === "Close Study") {
                objGMRCApprovalTask.Decision = $('#ui_ddl_reasonForClosure').val();
                objGMRCApprovalTask.IsClosureActivitiesCompleted = $('#studyClosureCheckbox').prop("checked");
            }

            $.ajax({
                async: false,
                type: "POST",
                url: "/ProtocolPhase/UpdateGMRCApprovalGearTaskDetails",
                data: { "objGMRCApprovalTask": objGMRCApprovalTask },
                success: function (results) {
                    if (results.msgType === "Success") {
                        //if (TaskName === "Document Submission Review" || (TaskName === "Close Study")) {
                        //    opener.location.reload();
                        //}
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
        else {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    }

    $('#resubmissionReason').change(function () {
        $('#chkbox').next("div.error").remove();
    });

    $('#ui_btn_yes').click(function () {
        if (retVal === true) {
            objGMRCApprovalTask = new Object();
            objGMRCApprovalTask.ANJU_ChangedBy = $('#LogedinUserName').val();
            objGMRCApprovalTask.AssignedTo = $('#LogedinUserName').val();
            objGMRCApprovalTask.ANJU_AddedBy = $('#txtUserName').val();
            objGMRCApprovalTask.StudyId = $('#StudyId').val();
            objGMRCApprovalTask.TaskName = "Initiate Study Closeout";
            objGMRCApprovalTask.IsGearTaskCompleted = null;


            $.ajax({
                async: false,
                type: "POST",
                url: "/StudyCloseout/UpdateInitiateCloseout",
                data: { "objGMRCApprovalTask": objGMRCApprovalTask },
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
                    popupNotification.show("Error", "error");
                }
            });
        }
    });

    var finalDocumentCheck = true;
    $("#ui_btn_documentCloseStudySubmit").click(function () {
        ValidateFinalDocumentMandetoryFields();
        if (finalDocumentCheck === true) {
            $(".k-upload-selected").click();
            $("#addCloseStudyModal").modal("hide");
            $("#btn_RemoveCloseStudyDocument").show();
            $("#closeStudyDownload").show();
            $("#closeStudyDownload").text(documentName);
            $('#closeStudyLetter').next("div.error").remove();

        }
        else {
            $("#addCloseStudyModal").modal("show");
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });

    $("#ui_btn_documentCloseStudyCancel").click(function () {
        $("#addCloseStudyModal").modal("hide");

    });

    function ValidateFinalDocumentMandetoryFields() {
        $(".error").remove();
        finalDocumentCheck = true;

        if ($("#uploadCloseStudyFiles").closest(".k-upload").find(".k-file").length <= 0) {
            $('#closeStudyFiles').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
            finalDocumentCheck = false;
        }
        if ($("#ui_txt_documentNameCloseStudy").val() === "") {
            $('#documentNameCloseStudy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name is required</div>');
            finalDocumentCheck = false;
        }
        if ($('#ui_ddl_documentStatusCloseStudy').val() === 'Select' || $('#ui_ddl_documentStatusCloseStudy').val() === "") {
            $('#documentStatusCloseStudy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Status is required</div>');
            finalDocumentCheck = false;
        }
        if ($('#ui_ddl_documentStatusCloseStudy').val() === 'Pending Review') {
            $('#documentStatusCloseStudy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document should be reviewed, Please change the Document Status from Pending Review</div>');
            finalDocumentCheck = false;
        }
        if ($('#ui_ddl_versionCloseStudy').val() === 'Select' || $('#ui_ddl_versionCloseStudy').val() === "") {
            $('#versionCloseStudy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document version is required</div>');
            finalDocumentCheck = false;
        }
        if ($('#ui_ddl_documentTypeCloseStudy').val() === 'Select' || $('#ui_ddl_documentTypeCloseStudy').val() === "") {
            $('#documentTypeCloseStudy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Type is required</div>');
            finalDocumentCheck = false;
        }

        if ($("#ui_txt_documentNameCloseStudy").val() !== "" && $('#StudyId').val() > 0 && finalDocumentCheck) {
            $.ajax({
                async: false,
                type: "GET",
                url: "/TaskWorkFlow/IsDocumentNameIsUnique",
                data: { "documentsName": $("#ui_txt_documentNameCloseStudy").val(), "studyId": $('#StudyId').val() },
                success: function (result) {
                    if (result) {
                        finalDocumentCheck = result;
                    }
                    else {
                        finalDocumentCheck = result;
                        $('#documentNameCloseStudy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name must be unique. Addition of a Date or Version Number is suggested.</div>');
                    }

                }
            });
        }
    }
    $("#uploadCloseStudyFiles").change(function () {
        $('#closeStudyFiles').next("div.error").remove();
        $('#documentNameCloseStudy').next("div.error").remove();
    });
    $("#ui_txt_documentNameCloseStudy").on("keyup", function (e) {
        $('#documentNameCloseStudy').next("div.error").remove();
    });
    $("#ui_ddl_documentStatusCloseStudy").change(function () {
        $('#documentStatusCloseStudy').next("div.error").remove();
    });
    $("#ui_ddl_versionCloseStudy").change(function () {
        $('#versionCloseStudy').next("div.error").remove();
    });
    $("#ui_ddl_documentTypeCloseStudy").change(function () {
        $('#documentTypeCloseStudy').next("div.error").remove();
    });


    $('#closeStudyDownload').click(function () {

        fileName = documentName;
        subModuleFolderName = "CloseStudyDocument";
        studyId = $('#StudyId').val();
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + studyId;
    });

    $('#btn_RemoveCloseStudyDocument').click(function () {
        objDocuments = new Object();
        objDocuments.StudyId = $('#StudyId').val();
        objDocuments.SubModuleName = "CloseStudyDocument";
        objDocuments.ANJU_ChangedBy = $('#LogedinUserName').val();

        $.ajax({
            async: false,
            type: "POST",
            url: "/TaskWorkFlow/DeleteDocuments",
            data: { "documents": objDocuments },
            success: function (results) {
                if (results.length !== 0) {
                    $("#closeStudyDownload").hide();
                    $("#frm_closeStudy")[0].reset();
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
        $('#btn_RemoveCloseStudyDocument').hide();
    });
});