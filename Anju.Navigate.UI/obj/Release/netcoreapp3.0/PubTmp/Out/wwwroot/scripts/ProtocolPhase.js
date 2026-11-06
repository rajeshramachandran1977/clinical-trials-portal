function onCancel() {
    window.close();
}
$('#AddChecklistDocument').click(function () {
    $(".addFMVDocModal").modal("show");
});

var FMVDocumnetName = "";
var ICFReUploadDocumentName = "";

function onSelectReUploadDocuments(e) {
    var src = $("#fileReUploadICFDoc").val();
    $('#fileReUploadICFDoc').next("div.error").remove();
    $.each(e.files, function (index, value) {
        ICFReUploadDocumentName = value.name;
    });
}
function onsuccessReUploadDocuments(e) {
    $.each(e.files, function (index, value) {
        ICFReUploadDocumentName = value.name;
    });
}

function onSelectFMVDocuments(e) {
    var src = $("#FMVUploadFile").val();
    $('#FMVUpload').next("div.error").remove();
    $.each(e.files, function (index, value) {
        FMVDocumnetName = value.name;
        $("#ui_txt_FMVdocumentName").val(value.name);
    });
}
function onremoveFMVDocuments(e) {
    if (FMVDocumnetName !== e.files[0].name)
        $("#ui_txt_FMVdocumentName").val(FMVDocumnetName);
    else
        $("#ui_txt_FMVdocumentName").val("");
}
function onsuccessFMVDocuments(e) {
    $(".k-upload-files.k-reset").find("li").remove();
    $.each(e.files, function (index, value) {
        FMVDocumnetName = value.name;
        $("#ui_txt_FMVdocumentName").val(FMVDocumnetName);
    });

}
function onUploadFMVDocuments(e) {
    $('#FMVdocumentName').next("div.error").remove();
    e.data = {};
    e.data["additional[0]"] = $("#ui_txt_FMVdocumentName").val();
    e.data["additional[1]"] = $('#ui_ddl_FMVdocumentStatus').val();
    e.data["additional[2]"] = $("#ui_lbl_documentType").text();
    e.data["additional[3]"] = $('#ui_lbl_documentSubType').text();
    e.data["additional[4]"] = $('#ui_ddl_FMVVersion').val();

    e.data["additional[5]"] = $('#ui_dt_FMVOriginalDate').val() !== '' ? $('#ui_dt_FMVOriginalDate').val() : ' ';
    e.data["additional[6]"] = $('#ui_dt_FMVExpiryDate').val() !== '' ? $('#ui_dt_FMVExpiryDate').val() : ' ';
    e.data["additional[7]"] = $("#TaskName").val();
}

$(document).ready(function () {
    var retval = true;
    var DocumentCheck = true;

    $('#drugActivitiesCmt').hide();
    $('#FMVDocument').hide();
    $('#FMVDocumentDownload').hide();
    $('#ui_btn_RemoveFMVDocument').hide();
    $('#checklistDownload').hide();
    $('#ui_btn_removeChecklistDocument').hide();
    $('#submitActivationDocs').hide();
    $('#requiredICFDocs').hide();
    $('#finalActivationReview').hide();
    $('#icfResubmissionRequired').hide();

    var TaskName = $("#TaskName").val();

    //Drug Activities
    if (TaskName === "Drug Activities") {
        $('#drugActivitiesCmt').show();
    }
    //Task “Upload Fair Market Value Analysis Document”
    if (TaskName === "Upload Fair Market Value Analysis Document") {
        $('#taskHeading').text("Upload Fair Market Value Analysis Document");
        $('#piPanel').text("Please upload the final FMV approval of budget and confirmation.");
        $('#chkbox').hide();
        $('#FMVDocument').show();
    }
    // Task “Submit Required ICF Document”
    if (TaskName === "Submit Required ICF Document") {
        $('#taskHeading').text("Submit Required ICF Document");
        $('#piPanel').text("Please upload your informed Consent Form(ICF). Remember to select submit for the files to properly upload.");
        $('#chkbox').hide();
        $('#requiredICFDocs').show();
    }
    // Task “Final Activation Review” 
    if (TaskName === "Final Activation Review") {
        $('#taskHeading').text("Final Activation Review");
        $('#piPanel').text("Please download the VDR Checklist and complete as appropriate. Upload the final document document and submit.");
        $('#chkbox').hide();
        $('#finalActivationReview').show();
        var todayDate = kendo.toString(kendo.parseDate(new Date()), 'MMM dd, yyyy');
        $("#ui_dt_studyActivation").data("kendoDatePicker").value(todayDate);
        $('#ui_lbl_documentType').text("Regulatory");
        $('#ui_lbl_documentSubType').text("VDR");
        $('#modalHeading').text("Upload Completed checklist");
    }
    if (TaskName === "ICF Resubmission Required") {
        $('#taskHeading').text("ICF Resubmission Required");
        $('#piPanel').text("Your Informed Consent Form(ICF) is redlined. Please download the redlined copy from the download option below and address the comments as specified. You will be required to upload the updated document to complete the submission. Remember to select submit for the files to properly upload.");
        $('#chkbox').hide();
        $('#icfResubmissionRequired').show();
    }
    //Task “Submit Activation Documents”
    if (TaskName === "Submit Activation Documents" || TaskName === "Resubmit Activation Documents") {
        $('#taskHeading').text(TaskName);
        $('#piPanel').text("Please upload the required activation documents and submit");
        $('#chkbox').hide();
        $('#submitActivationDocs').show();
        studyid = $('#StudyId').val();
        var count = 0;
        var document = "doc";
        var kendoid = "upload";
        var html = '';
        $.ajax({
            async: false,
            type: "POST",
            url: "/TaskWorkFlow/GetActivationDocuments",
            data: { "studyId": studyid },
            success: function (results) {
                if (results !== null) {
                    $.each(results.Data, function (index, item) {
                        count = count + 1;
                        html += '<tr><td class="ui_label" id=' + document + count + '>' + results.Data[index].DocumentName + '</td>';
                        html += '<td >' + '<input  name="files" id=' + kendoid + count + '  type="file" aria-label="files" />' + ' </td>';
                        html += '</tr>';
                    });
                    $(html).appendTo($("#activationdocumentlist"));
                }
                else {
                    popupNotification.show(results.msgType, "error");
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                popupNotification.show('Error', "error");
            }
        });
        for (i = 1; i <= count; i++) {
            $("#upload" + i).kendoUpload({ multiple: false });
        }
    }

    $("#btn_FMVDocumentCancel").click(function () {
        $(".addFMVDocModal").modal("hide");
        $("#frm_FMVDocumentDetails")[0].reset();
    });

    $('#FMVDocumentDownload').click(function () {
        subModuleFolderName = "FMVDocument";
        studyId = $('#StudyId').val();
        window.location = "/NewStudy/DownloadFiles?fileName=" + FMVDocumnetName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + studyId;
    });

    $('#checklistDownload').click(function () {
        subModuleFolderName = "StudyCheckListDocument";
        studyId = $('#StudyId').val();
        window.location = "/NewStudy/DownloadFiles?fileName=" + FMVDocumnetName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + studyId;
    });

    $("#btn_FMVDocumentSubmit").click(function () {
        ValidateFMVDocumentMandetoryFields();
        if (DocumentCheck === true) {
            $(".k-upload-selected").click();
            $(".k-upload-files").remove();
            $(".k-upload-status").remove();
            $(".k-upload.k-header").addClass("k-upload-empty");
            $(".k-upload-button").removeClass("k-state-focused");
            $(".addFMVDocModal").modal("hide");

            if (TaskName === "Upload Fair Market Value Analysis Document") {
                $("#ui_btn_RemoveFMVDocument").show();
                $("#FMVDocumentDownload").show();
                $("#FMVDocumentDownload").text(FMVDocumnetName);
            }
            else {
                $("#ui_btn_removeChecklistDocument").show();
                $("#checklistDownload").show();
                $("#checklistDownload").text(FMVDocumnetName);
            }
        }
        else {
            $(".addFMVDocModal").modal("show");
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });

    function ValidateFMVDocumentMandetoryFields() {
        $(".error").remove();
        DocumentCheck = true;

        if ($("#ui_txt_FMVdocumentName").val() === "" || $("#ui_txt_FMVdocumentName").val() === null) {
            $('#FMVdocumentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name is required</div>');
            DocumentCheck = false;
        }
        if ($('#ui_ddl_FMVdocumentStatus').val() === 'Select' || $('#ui_ddl_FMVdocumentStatus').val() === "") {
            $('#FMVdocumentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Status is required</div>');
            DocumentCheck = false;
        }

        if ($('#ui_ddl_FMVdocumentStatus').val() === 'Pending Review') {
            $('#FMVdocumentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document should be reviewed, Please change the Document Status from Pending Review</div>');
            retVal = false;
        }

        if ($('#ui_ddl_FMVVersion').val() === 'Select' || $('#ui_ddl_FMVVersion').val() === "") {
            $('#FMVVersion').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document version is required</div>');
            DocumentCheck = false;
        }
        if ($("#FMVUploadFile").closest(".k-upload").find(".k-file").length <= 0) {
            $('#FMVUpload').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
            DocumentCheck = false;
        }
        if ($("#ui_txt_FMVdocumentName").val() !== "" && $('#StudyId').val() > 0 && DocumentCheck) {
            $.ajax({
                async: false,
                type: "GET",
                url: "/TaskWorkFlow/IsDocumentNameIsUnique",
                data: { "documentsName": $("#ui_txt_FMVdocumentName").val(), "studyId": $('#StudyId').val() },
                success: function (result) {
                    if (result) {
                        DocumentCheck = result;
                    }
                    else {
                        DocumentCheck = result;
                        $('#FMVdocumentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name must be unique. Addition of a Date or Version Number is suggested.</div>');
                    }

                }
            });
        }
    }
    $("#FMVUploadFile").change(function () {
        $("#FMVUpload").next("div.error").remove();
        $("#FMVdocumentName").next("div.error").remove();
    });
    $("#ui_ddl_FMVdocumentStatus").change(function () {
        $('#FMVdocumentStatus').next("div.error").remove();
    });
    $("#ui_ddl_FMVVersion").change(function () {
        $('#FMVVersion').next("div.error").remove();
    });
    $("#ui_txt_FMVdocumentName").on("keyup", function () {
        $('#FMVdocumentName').next('div.error').remove();
    });

    $('#ui_btn_RemoveFMVDocument').click(function () {
        objDocuments = new Object();
        objDocuments.StudyId = $('#StudyId').val();
        objDocuments.SubModuleName = "FMVDocument";
        objDocuments.ANJU_ChangedBy = $('#LogedinUserName').val();

        $.ajax({
            async: false,
            type: "POST",
            url: "/TaskWorkFlow/DeleteDocuments",
            data: { "documents": objDocuments },
            success: function (results) {
                if (results.length !== 0) {
                    $("#FMVDocumentDownload").hide();
                    $("#frm_FMVDocumentDetails")[0].reset();
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

        $('#FMVDocumentDownload').text('DOWNLOAD');
        $('#ui_btn_RemoveFMVDocument').hide();

    });

    $('#ui_btn_removeChecklistDocument').click(function () {
        objDocuments = new Object();
        objDocuments.StudyId = $('#StudyId').val();
        objDocuments.SubModuleName = "StudyCheckListDocument";
        objDocuments.ANJU_ChangedBy = $('#LogedinUserName').val();

        $.ajax({
            async: false,
            type: "POST",
            url: "/TaskWorkFlow/DeleteDocuments",
            data: { "documents": objDocuments },
            success: function (results) {
                if (results.length !== 0) {
                    $('#checklistDownload').hide();
                    $("#frm_FMVDocumentDetails")[0].reset();
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

        $('#checklistDownload').text('DOWNLOAD');
        $('#ui_btn_removeChecklistDocument').hide();

    });

    //download files
    $(".k-file-name").css("cursor", "pointer");
    $(".k-file-name").click(function () {
        var fileName = this.innerText;
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=ICFDocument';
    });

    $("#btn-Submit").click(function (e) {
        if (TaskName === "Submit Activation Documents" || TaskName === "Resubmit Activation Documents") {
            e.preventDefault();
            var document = "doc";
            var count = $('#activationdocumentlist').children('tr').length;
            //var value = $(this).closest('tr').children('td:first').text();
            for (i = 1; i <= count; i++) {
                var formData = new FormData();
                var upload = $("#upload" + i).getKendoUpload();
                var files = upload.getFiles();
                if (files.length > 0) {
                    var documentname = $("#" + document + i).text();
                    formData.append('files', files[0].rawFile);
                    formData.append('files', files[0].rawFile, documentname);
                    $.ajax({
                        async: false,
                        type: "POST",
                        url: "/TaskWorkFlow/SaveSubmitActivationDocuments/",
                        data: formData,
                        cache: false,
                        contentType: false,
                        processData: false,
                        success: function (results) {
                            if (results === "Success") {
                                opener.location.reload();
                                window.close();
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            popupNotification.show('Error', "error");
                        }
                    });
                }
            }

        }
        else if (TaskName === "ICF Resubmission Required") {
            ValidateMandatoryFields();
            SaveICFUpload();
        } 
        else {
            ValidateMandatoryFields();
            SaveFMVUpload();
        }
    });

    function ValidateMandatoryFields() {
        retval = true;
        $(".error").remove();

        if (TaskName === "Upload Fair Market Value Analysis Document") {
            var hyperLinkText = $('#FMVDocumentDownload').text(); // get the name          

            if (hyperLinkText === "DOWNLOAD") {
                $('#FMVDocumentError').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload FMV approval of budget </div>');
                retval = false;
            }
        }
        else if (TaskName === "Drug Activities") {
            if (!$("#requestAccepted").is(':checked')) {
                $('#chkbox').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>The required field I have adequately forecasted and completed all drug related activities required for this study has not been filled in.</div>');
                retval = false;
            }
        }
        else if (TaskName === "Submit Required ICF Document") {
            if ($("#fileICFDoc").closest(".k-upload").find(".k-file").length === 0) {
                $('#requiredICFDocs').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please Upload ICF Document</div>');
                retval = false;
            }
        }
        else if (TaskName === "ICF Resubmission Required") {
            if ($("#fileReUploadICFDoc").closest(".k-upload").find(".k-file").length === 0) {
                $('#Reupload').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please Upload ICF Document</div>');
                retval = false;
            }
        }
        else if (TaskName === "Final Activation Review") {
            if ($('#checklistDownload').text() === "DOWNLOAD") {
                $('#checklistUpload').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload Completed checklist </div>');
                retval = false;
            }
            var date = $("#ui_dt_studyActivation").val();
            var varDate = new Date(date); //dd-mm-YYYY
            var today = new Date();
            today.setHours(0, 0, 0, 0);

            if (varDate <= today) {
                $('#activationDate').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Study Activation Date should be greater than ' + todayDate + '</div>');
                retval = false;
            }
        }
    }

    $('#requestAccepted').change(function () {
        $('#chkbox').next("div.error").remove();
    });
    $("#fileICFDoc").change(function () {
        $('#requiredICFDocs').next("div.error").remove();
    });

    $("#fileReUploadICFDoc").change(function () {
        $('#Reupload').next("div.error").remove();
    });

    var lsmailParameter = new Array();
    var appUrl = $(location)[0].origin;
    function SaveFMVUpload() {
        if (retval) {
            objGMRCApprovalTask = new Object();
            objGMRCApprovalTask.StudyId = $('#StudyId').val();
            if (TaskName === "Upload Fair Market Value Analysis Document") {
                objGMRCApprovalTask.TaskName = "Upload Fair Market Value Analysis Document";
            }
            else if (TaskName === "Drug Activities") {
                objGMRCApprovalTask.TaskName = "Drug Activities";
                objGMRCApprovalTask.Comments = $("#ui_txt_comments").val();
            }
            else if (TaskName === "Submit Required ICF Document") {
                objGMRCApprovalTask.TaskName = "Submit Required ICF Document";

            }
            else if (TaskName === "Final Activation Review") {
                objGMRCApprovalTask.TaskName = "Final Activation Review";
                objGMRCApprovalTask.SubmissionDate = $("#ui_dt_studyActivation").val(); 
            }
            objGMRCApprovalTask.IsTaskCompleted = true;
            objGMRCApprovalTask.ANJU_ChangedBy = $('#LogedinUserName').val();
            objGMRCApprovalTask.TaskName = TaskName;

            $.ajax({
                async: false,
                type: "POST",
                url: "/ProtocolPhase/UpdateGMRCApprovalTaskDetails",
                data: { "objGMRCApprovalTask": objGMRCApprovalTask },
                success: function (results) {
                    if (results.msgType === "Success") {
                        opener.location.reload();
                        var StudyURL = "<a href='" + appUrl + "'> Navigate</a>";

                        if (TaskName === "Drug Activities") {                           
                            lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                            lsmailParameter.push(StudyURL);
                             $.ajax({
                                type: "POST",
                                url: "/Common/SendEmail/",
                                cache: false,
                                data: { "mailMessage": "Drug Supply", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $('#LogedinUserName').val(), "ccMail": " " },
                                dataType: "json",
                                 success: function (results) {
                                     popupNotification.show('Email Sent Successfully', "success");
                                 },
                                 error: function (XMLHttpRequest, textStatus, errorThrown) {
                                     popupNotification.show('Sending Email Failed', "error");
                                 }
                            });
                        }
                        else if (TaskName === "Upload Fair Market Value Analysis Document") {
                            lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                            lsmailParameter.push(StudyURL);
                            $.ajax({
                                type: "POST",
                                url: "/Common/SendEmail/",
                                cache: false,
                                data: { "mailMessage": "FMV Submit", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $('#LogedinUserName').val(), "ccMail": " " },
                                dataType: "json",
                                success: function (results) {
                                    popupNotification.show('Email Sent Successfully', "success");
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    popupNotification.show('Sending Email Failed', "error");
                                }
                            });
                        }
                        else if (TaskName === "Final Activation Review") {
                            lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                            lsmailParameter.push(StudyURL);                           
                            $.ajax({
                                async:false,
                                type: "POST",
                                url: "/Common/SendEmail/",
                                cache: false,
                                data: { "mailMessage": "Final Activation Review", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $("#LogedinUserName").val(), "ccMail": " " },
                                dataType: "json",
                                success: function (results) {
                                    popupNotification.show('Email Sent Successfully', "success");
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    popupNotification.show('Sending Email Failed', "error");
                                }
                            });
                          
                        }
                        else if (TaskName === "Submit Required ICF Document") {
                            lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                            lsmailParameter.push(StudyURL);
                            $.ajax({
                                type: "POST",
                                url: "/Common/SendEmail/",
                                cache: false,
                                data: { "mailMessage": "Submit ICF", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $("#txtUserName").val(), "ccMail": " " },
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
        else {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    }
    function SaveICFUpload() {
        if (retval) {
            objGMRCApprovalTask = new Object();
            objGMRCApprovalTask.StudyId = $('#StudyId').val();
            objGMRCApprovalTask.TaskName = TaskName;
            objGMRCApprovalTask.IsTaskCompleted = true;
            objGMRCApprovalTask.ANJU_ChangedBy = $('#LogedinUserName').val();

            objDocument = new Object();
            objDocument.StudyId = $('#StudyId').val();
            objDocument.DocumentName = ICFReUploadDocumentName;
            objDocument.IsActive = true;
            objDocument.IsDeleted = false;
            objGMRCApprovalTask.ANJU_ChangedBy = $('#LogedinUserName').val();

            $.ajax({
                async: false,
                type: "POST",
                url: "/ProtocolPhase/UpdateGMRCApprovalTaskAndDocumentDetails",
                data: { "objGMRCApprovalTask": objGMRCApprovalTask, "objDocument": objDocument },
                success: function (results) {
                    if (results.msgType === "Success") {
                        opener.location.reload();
                        var StudyURL = "<a href='" + appUrl + "'> Navigate</a>";
                        lsmailParameter.push($("#txtUserName").val());
                        lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                        lsmailParameter.push(StudyURL);
                        $.ajax({
                            type: "POST",
                            url: "/Common/SendEmail/",
                            cache: false,
                            data: { "mailMessage": "Resubmit ICF", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $("#txtUserName").val(), "ccMail": " " },
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
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }


    }


    $('#downloadICF').click(function () {
        subModuleFolderName = "ICFDocument";
        studyId = $('#StudyId').val();
        var ICFdocumentName = "";
        var path = "";
        $.ajax({
            async: false,
            type: "POST",
            url: '/NewStudy/GetDocumentsByStudyID/',
            data: { "studyId": $('#StudyId').val(), "subModuleName": subModuleFolderName },
            success: function (result) {
                if (result !== "") {
                    ICFdocumentName = result.Data[0].DocumentNameWithOutExtension + result.Data[0].DocumentExtension;
                    path = result.Data[0].Path;
                    window.location = "/NewStudy/DownloadFiles?fileName=" + ICFdocumentName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + studyId + '&&path=' + path;
                }
            }
        });


    });
});