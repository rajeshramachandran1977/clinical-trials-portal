$("#ui_ddl_compoundTypeForCompoundCategory2").change(function () {
    $(this).next("div.error").remove();
});
$("#ui_ddl_compoundTypeForCompoundCategory3").change(function () {
    $(this).next("div.error").remove();
});

function onChangeofCompoundCategory1(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Code === "Secondary" || dataItem.Code === "Tertiary") {
        $('#compoundType1').show();
    }
    else {
        $('#compoundType1').hide();
    }
    $('#ui_tbl_CompoundDetails').next("div.error").remove();
}
function onChangeofCompoundCategory2(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Code === "Secondary" || dataItem.Code === "Tertiary") {
        $('#compoundType2').show();
    }
    else {
        $('#compoundType2').hide();
    }
    $('#ui_tbl_CompoundDetails').next("div.error").remove();
}
function onChangeofCompoundCategory3(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Code === "Secondary" || dataItem.Code === "Tertiary") {
        $('#compoundType3').show();
    }
    else {
        $('#compoundType3').hide();
    }
    $('#ui_tbl_CompoundDetails').next("div.error").remove();
}

var conditionalMandatory = false;
function onChangeofCategorization(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Code === "A" || dataItem.Code === "B") {
        $("#monitoring").show();
        $("#ui_lbl_safetyMonitoringInterval, #ui_lbl_maxTimeAllowed").addClass("mandatory");
        conditionalMandatory = true;
    }
    else if (dataItem.Code === "C") {
        $("#monitoring").hide();
        $("#ui_lbl_safetyMonitoringInterval,#ui_lbl_maxTimeAllowed").removeClass("mandatory");
        conditionalMandatory = false;
    }
}

var detailsTemplate = kendo.template($("#template").html());
function showDetails(e) {
    e.preventDefault();
    var grid = $("#ui_dtg_PLDocuments").getKendoGrid();

    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    var wnd = $("#Details").data("kendoWindow");
    wnd.content(detailsTemplate(dataItem));
    wnd.center().open();

    //Fill document window   
    var retVal = true;
    var LogedinUserName = $('#txtUserName').val();

    $("#ui_txt_uploadedBy").val(LogedinUserName);
    $("#ui_txt_documentName").val(dataItem.DocumentNameWithOutExtension);
    $("#ui_ddl_documentStatus").data('kendoDropDownList').value(dataItem.DocumentStatus);
    $("#ui_ddl_documentType").data('kendoDropDownList').value(dataItem.DocumentTypeId);
    $("#ui_ddl_documentSubType").data('kendoDropDownList').value(dataItem.DocumentSubType);
    $("#ui_ddl_amendmentVersion").data('kendoDropDownList').value(dataItem.DocumentVersion);
    $("#ui_dt_originalDate").data("kendoDatePicker").value(dataItem.OriginalDate);
    $("#ui_dt_expirationDate").data("kendoDatePicker").value(dataItem.ExpirationDate);

    var fileName = dataItem.DocumentName;
    var subModuleFolderName = dataItem.SubModuleName;
    var studyId = dataItem.StudyId;
    var documentId = dataItem.DocumentId;

    $('.fileDownload').click(function () {
        fileName = $(this).attr('filename');
        subModuleFolderName = $(this).attr('subModuleFolderName');
        studyId = $(this).attr('studyId');
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + studyId;

    });

    $("#btn-DocumentSubmit").click(function () {
        ValidateModalMandatoryFields();
        SaveDcouemntDetails();
    });

    $("#btn-DocumentCancel").click(function () {
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
        if ($('#ui_ddl_documentStatus').val() === 'Pending Review') {
            $('#documentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document should be reviewed, Please change the Document Status from Pending Review</div>');
            retVal = false;
        }

        var grid = $("#ui_dtg_PLDocuments").getKendoGrid();
        var datas = grid.dataSource.data();
        for (var i = 0; i < datas.length; i++) {
            if (documentId !== datas[i].DocumentId && datas[i].DocumentNameWithOutExtension === $("#ui_txt_documentName").val()) {
                $('#documentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name should be Unique</div>');
                retVal = false;
                break;
            }
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
            objDocumentDetails.DocumentName = fileName;
            objDocumentDetails.DocumentNameWithOutExtension = $("#ui_txt_documentName").val();
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
                        $("#ui_dtg_PLDocuments").data("kendoGrid").dataSource.read();
                        $("#ui_dtg_PLDocuments").data("kendoGrid").refresh();
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

function filterDocumentSubType() {
    return {
        documentTypeId: $("#ui_ddl_documentType").val()
    };
}

function onCancel() {
    window.close();
}

function StudyDetailsID() {
    return {
        studyId: $('#StudyId').val(),
        PIuserName: $('#txtUserName').val()
    };
}

function Show(e) {
    var gridRowData = $("#ui_dtg_PLDocuments").data("kendoGrid");
    if (gridRowData) {
        var data = gridRowData.dataItem($(e).closest("tr"));
        var subModuleFolderName = data.SubModuleName;
        var fileName = data.DocumentName;
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

function onDocumentTypeChange() {
    if ($("#ui_ddl_documentType").data("kendoDropDownList").value() === "") {
        $('#documentSubTypeLabel').removeClass("mandatory");
        $('#documentSubType').next("div.error").remove();
    }
}

$(document).ready(function () {

    var validator = $("#ui_frmProgramLeadreview").kendoValidator().data("kendoValidator");
    var retVal = true;
    var mSLUserame = "";
    $('#compoundType1').hide();
    $('#compoundType2').hide();
    $('#compoundType3').hide();
    $('#compoundOne').hide();
    $('#compoundTwo').hide();
    $('#compoundThree').hide();
    $("#monitoring").hide();

    $.ajax({
        async: false,
        type: "POST",
        url: '/NewStudy/GetUserNameByUserTypeAndStudyId',
        data: { "studyId": $('#StudyId').val(), "userType": "MSL" },
        success: function (result) {
            if (result !== "") {
                mSLUserame = result;
            }
        }
    });

    $.ajax({
        async: true,
        type: "POST",
        url: "/TaskWorkFlow/GetDrugorCompounddetailsDetailsByStudyId",
        cache: false,
        dataType: "json",
        data: { "StudyId": $('#StudyId').val() },
        success: function (result) {
            if (result.length >= 0) {
                if (result[0].Primarydrug !== null && result[0].Primarydrug.length > 0) {
                    $('#compoundOne').show();
                    $("#ui_lbl_CompoundCategory1").text(result[0].Primarydrug);
                    $("#ui_ddl_CompoundCategory1").data('kendoDropDownList').value("Primary");
                }

                if (result[0].Secondarydrug !== null && result[0].Secondarydrug.length > 0) {
                    $('#compoundTwo').show();
                    $("#ui_lbl_CompoundCategory2").text(result[0].Secondarydrug);
                    $("#ui_ddl_CompoundCategory2").data('kendoDropDownList').value("Secondary");
                    if (result[0].Secondarydrug !== null && result[0].Secondarydrug.length > 0) {
                        $('#compoundType2').show();
                        $("#ui_ddl_compoundTypeForCompoundCategory2").data('kendoDropDownList').value(result[0].SecondaryType);
                    }
                }
                if (result[0].Tertiarydrug !== null && result[0].Tertiarydrug.length > 0) {
                    $('#compoundThree').show();
                    $("#ui_lbl_CompoundCategory3").text(result[0].Tertiarydrug);
                    $("#ui_ddl_CompoundCategory3").data('kendoDropDownList').value("Tertiary");
                    if (result[0].Tertiarydrug !== null && result[0].Tertiarydrug.length > 0) {
                        $('#compoundType3').show();
                        $("#ui_ddl_compoundTypeForCompoundCategory3").data('kendoDropDownList').value(result[0].TertiaryaryType);
                    }
                }
            }
        },
        failure: function (response) {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });

    $.ajax({
        async: true,
        type: "POST",
        url: "/TaskWorkFlow/GetPLReviewDetailsByStudyId/",
        cache: false,
        dataType: "json",
        data: { "StudyId": $('#StudyId').val() },
        success: function (result) {
            if (result.length > 0) {
                $("#ui_ddl_CompoundCategory1").data('kendoDropDownList').value(result[0].CompoundCategory1);
                $("#ui_ddl_CompoundCategory2").data('kendoDropDownList').value(result[0].CompoundCategory2);
                $("#ui_ddl_CompoundCategory3").data('kendoDropDownList').value(result[0].CompoundCategory3);
                if (result[0].CompoundType1 !== null)
                    $("#ui_ddl_compoundTypeForCompoundCategory1").data('kendoDropDownList').value(result[0].CompoundType1);
                if (result[0].CompoundType2 !== null)
                    $("#ui_ddl_compoundTypeForCompoundCategory2").data('kendoDropDownList').value(result[0].CompoundType2);
                if (result[0].CompoundType3 !== null)
                    $("#ui_ddl_compoundTypeForCompoundCategory3").data('kendoDropDownList').value(result[0].CompoundType3);

                if (result[0].StudyDescriptors !== null) {
                    var StudyDescriptors = result[0].StudyDescriptors.split(',');
                    $("#ui_multiselect_studyDescriptors").getKendoMultiSelect().value(StudyDescriptors);
                }
                $("#ui_ddl_trialCategorization").data('kendoDropDownList').value(result[0].TrialCategorization);

                if (result[0].TrialCategorization === "A" || result[0].TrialCategorization === "B") {
                    $("#monitoring").show();
                    $("#ui_lbl_safetyMonitoringInterval, #ui_lbl_maxTimeAllowed").addClass("mandatory");
                }
                else {
                    $("#monitoring").hide();
                    $("#ui_lbl_safetyMonitoringInterval,#ui_lbl_maxTimeAllowed").removeClass("mandatory");

                }
                if (result[0].MonitoringInterval === true)
                    $("#visitDesign").prop('checked', true);
                $('#ui_txt_maxTimeAllowed').val(result[0].MaximumAllowableVists);
                $('#ui_ddl_trialLeader').data('kendoDropDownList').value(result[0].TluserId);
            }
        },
        failure: function (response) {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });

    $("#btn-Submit").click(function () {
        ValidateMandatoryFields();
        SaveProgramLeadReviewDetails();
    });

    function ValidateMandatoryFields() {
        retVal = true;
        $(".error").remove();
        var grid = $("#ui_dtg_PLDocuments").getKendoGrid();
        var datas = grid.dataSource.data();
        for (var item in datas) {
            if (datas[item].DocumentStatus === null || datas[item].DocumentName === null || datas[item].DocumentType === null || datas[item].DocumentSubType === null || datas[item].DocumentVersion === null) {
                $('#ui_dtg_PLDocuments').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please review and classify all documents</div>');
                retVal = false;
                break;
            }
        }

        if ($('#ui_ddl_CompoundCategory1').val() !== "Primary" && $('#ui_ddl_CompoundCategory2').val() !== "Primary" && $('#ui_ddl_CompoundCategory3').val() !== "Primary") {
            $('#ui_tbl_CompoundDetails').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please specify one Primary ' + appName + ' Compound</div>');
            retVal = false;
        }
        if (
            ($('#ui_ddl_CompoundCategory1').val() === "Primary" && $('#ui_ddl_CompoundCategory2').val() === "Primary" && $('#ui_ddl_CompoundCategory3').val() === "Primary") ||
            ($('#ui_ddl_CompoundCategory1').val() === "Primary" && $('#ui_ddl_CompoundCategory2').val() === "Primary") ||
            ($('#ui_ddl_CompoundCategory2').val() === "Primary" && $('#ui_ddl_CompoundCategory3').val() === "Primary") ||
            ($('#ui_ddl_CompoundCategory3').val() === "Primary" && $('#ui_ddl_CompoundCategory1').val() === "Primary")
        ) {
            $('#ui_tbl_CompoundDetails').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Study Should have only One Primary Compound</div>');
            retVal = false;
        }
        //if ($('#ui_ddl_CompoundCategory1').val() === "Secondary" || ($('#ui_ddl_CompoundCategory2').val() === "Secondary" || $('#ui_ddl_CompoundCategory3').val() === "Secondary")) {
        //    if ($('#ui_ddl_CompoundCategory1').val().length > 0 && $("#ui_ddl_compoundTypeForCompoundCategory1").val() === "Select" || $("#ui_ddl_compoundTypeForCompoundCategory1").val() === "") {
        //        $('#ui_ddl_compoundTypeForCompoundCategory1').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Compound Type</div>');
        //        retVal = false;
        //    }
        //    if ($('#ui_ddl_CompoundCategory2').val().length > 0 && ($("#ui_ddl_compoundTypeForCompoundCategory2").val() === "Select" || $("#ui_ddl_compoundTypeForCompoundCategory2").val() === "")) {
        //        $('#ui_ddl_compoundTypeForCompoundCategory2').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Compound Type</div>');
        //        retVal = false;
        //    }
        //    if ($('#ui_ddl_CompoundCategory3').val().length > 0 && ($("#ui_ddl_compoundTypeForCompoundCategory3").val() === "Select" || $("#ui_ddl_compoundTypeForCompoundCategory3").val() === "")) {
        //        $('#ui_ddl_compoundTypeForCompoundCategory3').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Compound Type</div>');
        //        retVal = false;
        //    }
        //}
        if ($('#ui_ddl_CompoundCategory1').val() === "Secondary" || ($('#ui_ddl_CompoundCategory2').val() === "Secondary" || $('#ui_ddl_CompoundCategory3').val() === "Secondary"))
            if (($('#ui_ddl_CompoundCategory1').val().length > 0 && $("#ui_ddl_compoundTypeForCompoundCategory1").val() === "Select" || $("#ui_ddl_compoundTypeForCompoundCategory1").val() === "")
                || ($('#ui_ddl_CompoundCategory2').val().length > 0 && ($("#ui_ddl_compoundTypeForCompoundCategory2").val() === "Select" || $("#ui_ddl_compoundTypeForCompoundCategory2").val() === ""))
                || ($('#ui_ddl_CompoundCategory3').val().length > 0 && ($("#ui_ddl_compoundTypeForCompoundCategory3").val() === "Select" || $("#ui_ddl_compoundTypeForCompoundCategory3").val() === ""))) {
                $('#ui_tbl_CompoundDetails').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Compound Type</div>');
                retVal = false;
            }
        if (conditionalMandatory === true) {
            if (!$("#visitDesign").is(':checked')) {
                $('#visitDesignError').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>please check Safety Monitoring Interval.</div>');
                retVal = false;
            }
            if ($('#ui_txt_maxTimeAllowed').val() === "") {
                $('#monitoring').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>please fill Maximum allowable time between visits (in weeks).</div>');
                retVal = false;
            }
        }
        if ($("#ui_multiselect_studyDescriptors").data("kendoMultiSelect").value().length <= 0) {
            $('#multiselectStudyDescriptors').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Study Descriptors</div>');
            retVal = false;
        }
        if (($('#ui_ddl_trialCategorization').val() === "Select") || ($('#ui_ddl_trialCategorization').val() === "")) {
            $('#trialCategorization').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Pandemic Preparedness Trial Categorization</div>');
            retVal = false;
        }
        if (($('#ui_ddl_trialLeader').val() === "Select") || ($('#ui_ddl_trialLeader').val() === "")) {
            $('#trialLeader').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Trial Leader</div>');
            retVal = false;
        }
        if (($('#ui_ddl_Decision').val() === "Select") || ($('#ui_ddl_Decision').val() === "")) {
            $('#decision').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please select Decision</div>');
            retVal = false;
        }
    }

    $('#ui_ddl_CompoundCategory1,#ui_ddl_CompoundCategory2,#ui_ddl_CompoundCategory3').on("change", function () {
        $('#ui_tbl_CompoundDetails').next("div.error").remove();
    });
    $('#ui_ddl_compoundTypeForCompoundCategory1,#ui_ddl_compoundTypeForCompoundCategory2,#ui_ddl_compoundTypeForCompoundCategory3').on("change", function () {
        $('#ui_tbl_CompoundDetails').next("div.error").remove();
    });
    $('#visitDesign').on("change", function () {
        $('#visitDesignError').next("div.error").remove();
    });
    $('#ui_txt_maxTimeAllowed').on("keyup", function () {
        $('#monitoring').next("div.error").remove();
    });
    $('#ui_multiselect_studyDescriptors').on("change", function () {
        $('#multiselectStudyDescriptors').next("div.error").remove();
    });
    $('#ui_ddl_trialCategorization').on("change", function () {
        $('#trialCategorization').next("div.error").remove();
    });
    $('#ui_ddl_trialLeader').on("change", function () {
        $('#trialLeader').next("div.error").remove();
    });
    $('#ui_ddl_Decision').on("change", function () {
        $('#decision').next("div.error").remove();
    });

    function SaveProgramLeadReviewDetails() {
        if (validator.validate() && retVal === true) {
            objPLStudyReview = new Object();
            objPLStudyReview.StudyId = $('#StudyId').val();
            objPLStudyReview.PLuserName = $('#LogedinUserName').val();
            objPLStudyReview.CompoundCategory1 = $('#ui_ddl_CompoundCategory1').val();
            objPLStudyReview.CompoundType1 = $('#ui_ddl_compoundTypeForCategory1').val();
            objPLStudyReview.CompoundCategory2 = $('#ui_ddl_CompoundCategory2').val();
            objPLStudyReview.CompoundType2 = $('#ui_ddl_compoundTypeForCompoundCategory2').val();
            objPLStudyReview.CompoundCategory3 = $('#ui_ddl_CompoundCategory3').val();
            objPLStudyReview.CompoundType3 = $('#ui_ddl_compoundTypeForCompoundCategory3').val();
            if ($('#ui_multiselect_studyDescriptors').val() !== null)
                objPLStudyReview.StudyDescriptors = $('#ui_multiselect_studyDescriptors').val().toString();//tostring will give result with comma separate
            objPLStudyReview.TrialCategorization = $('#ui_ddl_trialCategorization').val();
            objPLStudyReview.MonitoringInterval = $('#visitDesign').prop("checked");
            objPLStudyReview.MaximumAllowableVists = $('#ui_txt_maxTimeAllowed').val();
            objPLStudyReview.TluserId = $('#ui_ddl_trialLeader').val();
            objPLStudyReview.Decision = $('#ui_ddl_Decision').val();
            objPLStudyReview.Comments = $('#ui_txt_comments').val();
            objPLStudyReview.ANJU_AddedBy = $('#LogedinUserName').val();
            objPLStudyReview.ANJU_ChangedBy = $('#LogedinUserName').val();

            $.ajax({
                async: false,
                type: "POST",
                url: "/TaskWorkFlow/SavePLReviewDetails",
                data: { "pLStudyReview": objPLStudyReview },
                success: function (results) {
                    if (results.msgType === "Success") {
                        opener.location.reload();
                        var lsmailParameter = new Array();
                        var appUrl = $(location)[0].origin;
                        var StudyURL = "<a href='" + appUrl + "'> Navigate</a>";

                        if ($('#ui_ddl_Decision').val() === "Resubmit") {
                            lsmailParameter.push($('#LogedinUserName').val());
                            lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                            lsmailParameter.push($('#txtUserName').val());
                            lsmailParameter.push(StudyURL);
                            $.ajax({
                                type: "POST",
                                url: "/Common/SendEmail/",
                                cache: false,
                                data: { "mailMessage": "Resubmission_after_review", "lsparameter": lsmailParameter, "subParam": $('#LogedinUserName').val(), "toMail": mSLUserame, "ccMail": " " },
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

            popupNotification.show("There are errors on the page.Please correct them to continue.", "error");
        }
    }
});
