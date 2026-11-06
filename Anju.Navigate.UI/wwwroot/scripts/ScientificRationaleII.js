$(document).ready(function () {
    wnd = $("#modalWindow").kendoWindow({
        title: DELETEMESSAGETITLEBOX,
        modal: true,
        visible: false,
        resizable: false,
        width: 400
    }).data("kendoWindow");
});

function deleteCenter(e) {
    e.preventDefault ? e.preventDefault() : e.returnValue = false;
    $(document).ready(function () {
        wnd = $("#modalWindow").kendoWindow({
            title: DELETEMESSAGETITLEBOX,
            modal: true,
            visible: false,
            resizable: false,
            width: 400
        }).data("kendoWindow");
    });

    var grid = $("#ui_dtg_Center").data("kendoGrid"); //Get the grid from which the pop-up is coming
    var tr = $(e.target).closest("tr"); //get the row for deletion
    var data = this.dataItem(tr);
    wnd.center().open();

    $("#ui_btn_yes").click(function () {
        grid.dataSource.remove(data);
        grid.dataSource.sync();
        wnd.close();
    });
    $("#ui_btn_no").click(function () {
        wnd.close();
    });
}

$(document).ready(function () {
    $("#fdaGuidanceLink").click(function (e) {
        $.ajax({
            async: false,
            type: "GET",
            url: "/Administration/GetGlobalSettingByKey",
            data: { "globalKey": fdaLink },
            success: function (results) {
                if (results.length > 0) {
                    var fdaGuidance = results[0].GlobalValue;
                    if (!fdaGuidance.match(/^[a-zA-Z]+:\/\//)) {
                        fdaGuidance = 'http://' + fdaGuidance;
                    }
                    $('#fdaGuidanceLink').attr("href", fdaGuidance);
                }
            }
        });
    });

    $("#ui_btndeleteNewStudy").click(function () {
        $.ajax({
            async: true,
            type: "POST",
            url: "/NewStudy/DeleteStudy/",
            data: { "studyId": $('#StudyId').val() },
            cache: false,
            dataType: "json",
            failure: function (response) {
                popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
            }
        });
    });

    if ($("#ui_num_plannedNoOfCenters").val() > 0)
        $("#ui_dtg_Center").removeClass("k-state-disabled").addClass("k-grid-add");
    else
        $("#ui_dtg_Center").addClass("k-state-disabled").removeClass("k-grid-add");

    $("#ui_btnPreviousSection, #ui_btnPreviousSectionEnd").click(function () {
        //window.history.pushState({ prevUrl: window.location.href }, null, "/NewStudy/ScientificRationaleI?StudyId=" + $('#StudyId').val() + '&&mode=Update' + '&&StudyType=' + $('#StudyType').val() + '&&piTaskStatus=' + $('#pITaskStatus').val());
        obj = new Object();
        obj.StudyId = $('#StudyId').val();
        obj.mode = "Update";
        obj.StudyType = $('#StudyType').val();
        obj.PITaskStatus = $('#pITaskStatus').val();
        obj.TaskName = $('#TaskName').val();

        $.ajax({
            async: true,
            type: "POST",
            url: "/Login/OpenNewWindow",
            data: { "obj": obj },
            success: function (results) {
                if (results.data === "Success") {
                    window.location.href = "../NewStudy/ScientificRationaleI";
                }
                else {
                    popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
                }
            }
        });
    });

    $('#step-2').removeClass('d-none').addClass('d-block');
    //page 2
    $('#ifCorrelativeScienceYes').hide();
    $('#impactPatientAcrual').hide();
    $('#rationaleINDExemption').hide();
    $('#withACompanyDrug').hide();
    $('#withNOCompanyDrug').hide();
    $('#InvolvingPRIMARYDATACOLLECTIONWITHOUT').hide();

    mode = $("#mode").val();
    // Display entered data if in Edit/read mode
    if (mode == "Update") {
        $.ajax({
            async: true,
            type: "POST",
            url: "/NewStudy/GetScientificRationaleIIDetails/",
            cache: false,
            dataType: "json",
            data: { "StudyId": $('#StudyId').val() },
            success: function (response) {
                if (response.Data == '') {
                    popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
                }
                else {
                    $("#ui_txt_sampleSizeJustification").val(response.Data[0].SampleSizeJustificationandStatisticalAnalysis);
                    noOfCharactersLeft(response.Data[0].SampleSizeJustificationandStatisticalAnalysis, 'ui_txt_sampleSizeJustification');
                    $("#ui_txt_clinicalPharmacology").val(response.Data[0].ClinicalPharmacology);
                    noOfCharactersLeft(response.Data[0].ClinicalPharmacology, 'ui_txt_clinicalPharmacology');
                    var IsincludeCorrelativeScience = response.Data[0].IsincludeCorrelativeScience;
                    IsincludeCorrelativeScience === true ? $("#ui_ddl_correlativeScience").data('kendoDropDownList').value("Yes") : $("#ui_ddl_correlativeScience").data('kendoDropDownList').value("No");
                    if (IsincludeCorrelativeScience === true) {
                        $('#ifCorrelativeScienceYes').show();
                        $("#ui_txt_correlativescienceAtStudySite").val(response.Data[0].BiomarkerStudiesperformedatStudySite);
                        noOfCharactersLeft(response.Data[0].BiomarkerStudiesperformedatStudySite, 'ui_txt_correlativescienceAtStudySite');
                        $("#ui_txt_correlativescienceAtCompanySite").val(response.Data[0].BiomarkerStudiesperformedatCompanySite);
                        noOfCharactersLeft(response.Data[0].BiomarkerStudiesperformedatCompanySite, 'ui_txt_correlativescienceAtCompanySite');
                        $("#ui_txt_correlativeScienceSamplingDet").val(response.Data[0].BiomarkerSamplingDetails);
                        noOfCharactersLeft(response.Data[0].BiomarkerSamplingDetails, 'ui_txt_correlativeScienceSamplingDet');
                    }
                    if (IsincludeCorrelativeScience === null)
                        $("#ui_ddl_correlativeScience").data('kendoDropDownList').value("Select")
                    $("#ui_dt_trialStart").data("kendoDatePicker").value(response.Data[0].TrialStart);
                    $("#ui_dt_recruitmentEnd").data("kendoDatePicker").value(response.Data[0].RecruitmentEnd);
                    $("#ui_dt_trialEnd").data("kendoDatePicker").value(response.Data[0].TrialEnd);
                    $("#ui_dt_completionOfTrialReport").data("kendoDatePicker").value(response.Data[0].CompletionofTrialReport);
                    $("#ui_dt_primaryPublication").data("kendoDatePicker").value(response.Data[0].PrimaryPublicationDate);
                    $("#ui_num_noOfPatients").val(response.Data[0].TotalPlannedNumberofPatients);
                    $("#ui_num_plannedNoOfCenters").val(response.Data[0].PlannedNumberofCenters);
                    $("#ui_txt_enrollmentHistory").val(response.Data[0].EnrollmentHistoryforOtherRelatedStudies);
                    noOfCharactersLeft(response.Data[0].EnrollmentHistoryforOtherRelatedStudies, 'ui_txt_enrollmentHistory');
                    $("#ui_txt_submitprotocol").val(response.Data[0].InvestigationalSiteProtocolNumber);
                    noOfCharactersLeft(response.Data[0].InvestigationalSiteProtocolNumber, 'ui_txt_submitprotocol');
                    var IsCompetingStudies = response.Data[0].IsCompetingStudies;
                    IsCompetingStudies === true ? $("#ui_ddl_competingStudies").data('kendoDropDownList').value("Yes") : $("#ui_ddl_competingStudies").data('kendoDropDownList').value("No");
                    if (IsCompetingStudies === true) {
                        $('#impactPatientAcrual').show();
                        $("#ui_txt_impactPatientAccrual").val(response.Data[0].CompetingStudies);
                        noOfCharactersLeft(response.Data[0].CompetingStudies, 'ui_txt_impactPatientAccrual');
                    }
                    if (IsCompetingStudies === null)
                        $("#ui_ddl_competingStudies").data('kendoDropDownList').value("Select");
                    var IsIndsubmission = response.Data[0].IsIndsubmission;
                    IsIndsubmission === false ? $("#ui_ddl_proposedStudyIND").data('kendoDropDownList').value("No") : $("#ui_ddl_proposedStudyIND").data('kendoDropDownList').value("Yes");
                    if (IsIndsubmission === false) {
                        $('#rationaleINDExemption').show();
                        $("#ui_txt_rationaleForINDExemption").val(response.Data[0].RationaleforINDExemption);
                        noOfCharactersLeft(response.Data[0].RationaleforINDExemption, 'ui_txt_rationaleForINDExemption');
                    }
                    if (IsIndsubmission === null)
                        $("#ui_ddl_proposedStudyIND").data('kendoDropDownList').value("Select");
                    if (response.Data[0].StudyType == "Interventional") {
                        var IsIrbregistrationRequirement = response.Data[0].IsIrbregistrationRequirement;
                        IsIrbregistrationRequirement === true ? $("#ui_ddl_registrationIRB").data('kendoDropDownList').value("Yes") : $("#ui_ddl_registrationIRB").data('kendoDropDownList').value("No");
                        if (IsIrbregistrationRequirement == null)
                            $("#ui_ddl_registrationIRB").data('kendoDropDownList').value("Select");
                    }
                    var TrialType = response.Data[0].TrialType;
                    $("#ui_ddl_interventionalTrial").data('kendoDropDownList').value(TrialType);
                    switch (TrialType) {
                        case 'WITH a ' + appName + ' Drug':
                            $('#withACompanyDrug').show();
                            $('#withNOCompanyDrug').hide();
                            $('#withACompanyDrugItems').show();
                            $('#withNOCompanyDrugItems').hide();
                            break;
                        case 'WITH NO ' + appName + ' Drug':
                            $('#withACompanyDrug').hide();
                            $('#withNOCompanyDrug').show();
                            $('#withACompanyDrugItems').hide();
                            $('#withNOCompanyDrugItems').show();
                            break;
                        case 'Involving PRIMARY DATA COLLECTION WITH a ' + appName + ' Product of Focus':
                            $('#withACompanyDrug').show();
                            if (response.Data[0].IsAllnonseriousAes == true)
                                $("#ui_chkbox_allnonseriousAEs").prop('checked', true);
                            if (response.Data[0].IsAllreportsdescribingtheoccurrenceofotherspecialscenarios == true)
                                $("#ui_chkbox_allreportsdescribingtheoccurrenceofotherspecialscenarios").prop('checked', true);
                            break;
                        case 'Involving PRIMARY DATA COLLECTION WITHOUT a ' + appName + ' Product of Focus':
                            $('#InvolvingPRIMARYDATACOLLECTIONWITHOUT').show();
                            $('#ForPRIMARYDATACOLLECTIONWITH').show();
                            $('#basedOnSecondaryUseofdata').hide();
                            $('#withACompanyDrug').hide();
                            $("#ui_txt_Specifywhatsafetydata").val(response.Data[0].Safetydata);
                            noOfCharactersLeft(response.Data[0].Safetydata, 'ui_txt_Specifywhatsafetydata');
                            break;
                        case 'Based on SECONDARY USE OF DATA':
                            $('#InvolvingPRIMARYDATACOLLECTIONWITHOUT').show();
                            $('#ForPRIMARYDATACOLLECTIONWITH').hide();
                            $('#basedOnSecondaryUseofdata').show();
                            $('#withACompanyDrug').hide();
                            $("#ui_txt_Specifywhatsafetydata").val(response.Data[0].Safetydata);
                            break;
                        default: break;
                    }
                    $("#ui_txt_adverseEvents").val(response.Data[0].AdverseEventsExemptfromCollection);
                    noOfCharactersLeft(response.Data[0].AdverseEventsExemptfromCollection, 'ui_txt_adverseEvents');
                    $("#ui_txt_keyReferences").val(response.Data[0].KeyReferences);
                    noOfCharactersLeft(response.Data[0].KeyReferences, 'ui_txt_keyReferences');
                }
            },
            failure: function (response) {
                popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
            }
        });
    }

    var navListItems = $('div.setup-panel div a'),
        allWells = $('.setup-content'),
        allNextBtn = $('.nextBtn'),
        allPrevBtn = $('.prevBtn');

    allWells.hide();

    navListItems.click(function (e) {
        e.preventDefault();
        var $target = $($(this).attr('href')),
            $item = $(this);

        if (!$item.hasClass('disabled')) {
            navListItems.removeClass('btn-primary').addClass('btn-default');
            $item.addClass('btn-primary');
            allWells.hide();
            $target.show();
            $target.find('input:eq(0)').focus();
        }
    });

    allPrevBtn.click(function () {
        var curStep = $(this).closest(".setup-content"),
            curStepBtn = curStep.attr("id"),
            prevStepWizard = $('div.setup-panel div a[href="#' + curStepBtn + '"]').parent().prev().children("a");

        prevStepWizard.removeAttr('disabled').trigger('click');
    });

    allNextBtn.click(function () {
        var curStep = $(this).closest(".setup-content"),
            curStepBtn = curStep.attr("id"),
            nextStepWizard = $('div.setup-panel div a[href="#' + curStepBtn + '"]').parent().next().children("a"),
            curInputs = curStep.find("input[type='text'],input[type='url']"),
            isValid = true;

        $(".form-group").removeClass("has-error");
        for (var i = 0; i < curInputs.length; i++) {
            if (!curInputs[i].validity.valid) {
                isValid = false;
                $(curInputs[i]).closest(".form-group").addClass("has-error");
            }
        }

        if (isValid)
            nextStepWizard.removeAttr('disabled').trigger('click');
    });

    $('div.setup-panel div a.btn-primary').trigger('click');
});

var wnd;

function onCancel() {
    opener.location.reload();
    window.close();
}

//Delete Current Submission
function onCancelDelete() {
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/DeleteStudy/",
        data: {
            "studyId": $('#StudyId').val()
        },
        cache: false,
        dataType: "json",
        failure: function (response) {
            popupNotification.show(errorsinthepage, "error");
        }
    });
    opener.location.reload();
    window.close();
}

$('#scientificRationale').removeClass('btn-submission').addClass('activePage');
$('#2').removeClass('btn-submission').addClass('activePage');

//refresh the grid once data get bound.
//Start
function OnsaveChanges(e) {
    var grid = null;
    switch (e.type) {
        case "create":
            grid = $('#ui_dtg_Center').data("kendoGrid");
            grid.dataSource.read();
            break;
        case "update":
            grid = $('#ui_dtg_Center').data("kendoGrid");
            grid.dataSource.read();
            break;
        case "destroy":
            grid = $('#ui_dtg_Center').data("kendoGrid");
            grid.dataSource.read();
            break;
    }
}

//page2
function onChangeOfCorrelativeScience(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Value == "Yes") {
        $('#ifCorrelativeScienceYes').show();
    }
    else if (dataItem.Value == "" || dataItem.Value == "No") {
        $('#ifCorrelativeScienceYes').hide();
    }
}
function onChangeOfCompetingStudies(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Value == "Yes") {
        $('#impactPatientAcrual').show();
    }
    else if (dataItem.Value == "" || dataItem.Value == "No") {
        $('#impactPatientAcrual').hide();
    }
}

function onChangeOfINDProposedStudy(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Value == "No") {
        $('#rationaleINDExemption').show();
    }
    else if (dataItem.Value == "" || dataItem.Value == "Yes") {
        $('#rationaleINDExemption').hide();
    }
}

function onChangeOfInterventionalTrial(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Code == "") {
        $('#withACompanyDrug').hide();
        $('#withNOCompanyDrug').hide();
        $('#withACompanyDrugItems').hide();
        $('#withNOCompanyDrugItems').hide();
        $('#InvolvingPRIMARYDATACOLLECTIONWITHOUT').hide();
        $('#ForPRIMARYDATACOLLECTIONWITH').hide();
        $('#basedOnSecondaryUseofdata').hide();
    }
    else if (dataItem.Code == "WITH a " + appName + " Drug") {
        $('#withACompanyDrug').show();
        $('#withNOCompanyDrug').hide();
        $('#withACompanyDrugItems').show();
        $('#withNOCompanyDrugItems').hide();
    }
    else if (dataItem.Code == "WITH No " + appName + " Drug") {
        $('#withACompanyDrug').hide();
        $('#withNOCompanyDrug').show();
        $('#withACompanyDrugItems').hide();
        $('#withNOCompanyDrugItems').show();
    }
    else if (dataItem.Code == "Involving PRIMARY DATA COLLECTION WITH a " + appName + " Product of Focus") {
        $('#withACompanyDrug').show();
    }
    else if (dataItem.Code == "Involving PRIMARY DATA COLLECTION WITHOUT a " + appName + " Product of Focus") {
        $('#InvolvingPRIMARYDATACOLLECTIONWITHOUT').show();
        $('#ForPRIMARYDATACOLLECTIONWITH').show();
        $('#basedOnSecondaryUseofdata').hide();
        $('#withACompanyDrug').hide();
    }
    else if (dataItem.Code == "Based on SECONDARY USE OF DATA") {
        $('#InvolvingPRIMARYDATACOLLECTIONWITHOUT').show();
        $('#ForPRIMARYDATACOLLECTIONWITH').hide();
        $('#basedOnSecondaryUseofdata').show();
        $('#withACompanyDrug').hide();
    }
}

function DestroySession() {
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/DestroyStudySession/",
        cache: false,
        dataType: "json",
        failure: function (response) {
            popupNotification.show("There appears to be an error,please retry or contact Administrator if issue persists.", "error");
        }
    });
}

$(function () {
    var validator = $("#ui_frmNewStudyII").kendoValidator().data("kendoValidator");
    $("#ui_txt_sampleSizeJustification").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_txt_clinicalPharmacology").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_txt_clinicalPharmacology").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_txt_correlativescienceAtStudySite").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_ddl_correlativeScience").change(function (e) {
        $('#correlativeScience').next("div.error").remove();
    });
    $("#ui_dt_trialStart").on("focus", function (e) {
        $('#trialStart').next("div.error").remove();
    });
    $("#ui_dt_recruitmentEnd").on("focus", function (e) {
        $('#recruitmentEnd').next("div.error").remove();
    });
    $("#ui_dt_trialEnd").on("focus", function (e) {
        $('#trialEnd').next("div.error").remove();
    });
    $("#ui_dt_completionOfTrialReport").on("focus", function (e) {
        $('#completionOfTrialReport').next("div.error").remove();
    });
    $("#ui_dt_primaryPublication").on("focus", function (e) {
        $('#primaryPublication').next("div.error").remove();
    });
    $("#ui_num_noOfPatients").on("keyup", function (e) {
        $('#noOfPatients').next("div.error").remove();
    });
    $("#ui_num_plannedNoOfCenters").on("keyup", function (e) {
        $('#plannedNoOfCenters').next("div.error").remove();
    });
    $("#ui_num_plannedNoOfCenters").on("change keyup", function (e) {
        if ($("#ui_num_plannedNoOfCenters").val() >= 2)
            $("#ui_dtg_Center").removeClass("k-state-disabled").addClass("k-grid-add");
        else
            $("#ui_dtg_Center").addClass("k-state-disabled").removeClass("k-grid-add");
    });
    $("#ui_ddl_competingStudies").change(function (e) {
        $('#competingStudies').next("div.error").remove();
    });
    $("#ui_ddl_proposedStudyIND").change(function (e) {
        $('#proposedStudyIND').next("div.error").remove();
    });
    $("#ui_ddl_registrationIRB").change(function (e) {
        $('#registrationIRB').next("div.error").remove();
    });
    $("#ui_txt_correlativescienceAtCompanySite").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_txt_correlativeScienceSamplingDet").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_txt_rationaleForINDExemption").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_txt_keyReferences").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_txt_impactPatientAccrual").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_txt_rationaleForINDExemption").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });

    function GetEndDateForMonth(dt) {
        var DateCreated = new Date(Date.parse("01 "+dt));
        var dateofinspectionyear = DateCreated.getFullYear();
        var dateofinspectionmonth = DateCreated.getMonth();
        var DateOfFda = new Date(dateofinspectionyear, dateofinspectionmonth + 1, 0);
        var k = getFormattedDate(DateOfFda);
        return k;
    }

    function getFormattedDate(date) {
        var year = date.getFullYear();
        var month = (1 + date.getMonth()).toString();
        month = month.length > 1 ? month : '0' + month;
        var day = date.getDate().toString();
        day = day.length > 1 ? day : '0' + day;
        return year + '-' + month + '-' + day;
    }

    var retval = true;
    function ValidateMandatoryControls() {
        $(".error").remove();
        if ($('#ui_txt_sampleSizeJustification').val().trim() == '') {
            $('#ui_txt_sampleSizeJustification').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Sample Size Justification and Statistical Analysis is required.</div>');
            retval = false;
        }
        if ($('#ui_txt_clinicalPharmacology').val().trim() == '') {
            $('#ui_txt_clinicalPharmacology').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Clinical Pharmacology is required.</div>');
            retval = false;
        }
        if ($('#ui_ddl_correlativeScience').val() == '') {
            $('#correlativeScience').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Correlative Science Studies is required.</div>');
            retval = false;
        }
        else if ($('#ui_ddl_correlativeScience').val() == 'Yes') {
            if ($('#ui_txt_correlativescienceAtStudySite').val().trim() == '') {
                $('#ui_txt_correlativescienceAtStudySite').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Biomarker / Correlative Science Studies performed at Study Site(s) is required.</div>');
                retval = false;
            }

            if ($('#ui_txt_correlativescienceAtCompanySite').val().trim() == '') {
                $('#ui_txt_correlativescienceAtCompanySite').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Biomarker / Correlative Science Studies performed at Company Site is required.</div>');
                retval = false;
            }
            if ($('#ui_txt_correlativeScienceSamplingDet').val().trim() == '') {
                $('#ui_txt_correlativeScienceSamplingDet').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Biomarker / Correlative Science Sampling Details is required.</div>');
                retval = false;
            }
        }
        if ($('#ui_dt_trialStart').val() == 'month year' || $('#ui_dt_trialStart').val() == '') {
            $('#trialStart').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Trial Start (First Patient First Visit) is required.</div>');
            retval = false;
        }
        if ($('#ui_dt_recruitmentEnd').val() == 'month year' || $('#ui_dt_recruitmentEnd').val() == '') {
            $('#recruitmentEnd').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Recruitment End (Last Patient First Visit) is required.</div>');
            retval = false;
        }
        if ($('#ui_dt_trialEnd').val() == 'month year' || $('#ui_dt_trialEnd').val() == '') {
            $('#trialEnd').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Trial End (Last Patient Last Visit) is required.</div>');
            retval = false;
        }
        if ($('#ui_dt_completionOfTrialReport').val() == 'month year' || $('#ui_dt_completionOfTrialReport').val() == '') {
            $('#completionOfTrialReport').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Completion of Trial Report is required.</div>');
            retval = false;
        }
        if ($('#ui_dt_primaryPublication').val() == 'month year' || $('#ui_dt_primaryPublication').val() == '') {
            $('#primaryPublication').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Primary Publication Date is required.</div>');
            retval = false;
        }
        if ($("#ui_dt_trialStart").val() != "month year" && ($("#ui_dt_recruitmentEnd").val()) != "month year") {
            if (GetEndDateForMonth($("#ui_dt_trialStart").val()) >= GetEndDateForMonth($("#ui_dt_recruitmentEnd").val())) {
                $('#recruitmentEnd').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span> Recruitment End (Last Patient First Visit) should be greater than Trial Start (First Patient First Visit).</div>');
                retval = false;
            }
        }
        else
            $(this).next("div.error").remove();
        if ($("#ui_dt_recruitmentEnd").val() != "month year" && $("#ui_dt_trialEnd").val() != "month year") {
            if (GetEndDateForMonth($("#ui_dt_recruitmentEnd").val()) >= GetEndDateForMonth($("#ui_dt_trialEnd").val())) {
                $('#trialEnd').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Trial End (Last Patient Last Visit should be greater than Recruitment End (Last Patient First Visit)).</div>');
                retval = false;
            }
        }
        else
            $(this).next("div.error").remove();
        if ($('#ui_num_noOfPatients').val() == 0 || $('#ui_num_noOfPatients').val().trim() == "") {
            $('#noOfPatients').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Total Planned Number of Patients is required and needs to be between the expected values of 1 and 9,999.</div>');
            retval = false;
        }
        if ($('#ui_num_plannedNoOfCenters').val() == 0 || $('#ui_num_plannedNoOfCenters').val().trim() == "") {
            $('#plannedNoOfCenters').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Planned Number of Centers is required and needs to be between the expected values of 1 and 1000.</div>');
            retval = false;
        }
        if ($('#ui_ddl_competingStudies').val() == '') {
            $('#competingStudies').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Competing Studies is required.</div>');
            retval = false;
        }
        else if ($('#ui_ddl_competingStudies').val() == 'Yes')
            if ($('#ui_txt_impactPatientAccrual').val().trim() == '') {
                $('#ui_txt_impactPatientAccrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>How will these studies impact patient accrual for the proposed study is required.</div>');
                retval = false;
            }

        if ($('#ui_ddl_proposedStudyIND').val() == '') {
            $('#proposedStudyIND').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>IND Submission is required.</div>');
            retval = false;
        }
        else if ($('#ui_ddl_proposedStudyIND').val() == 'No') {
            if ($('#ui_txt_rationaleForINDExemption').val().trim() == '') {
                $('#ui_txt_rationaleForINDExemption').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Rationale for IND Exemption is required.</div>');
                retval = false;
            }
        }
        if ($('#ui_ddl_registrationIRB').val() == '') {
            $('#registrationIRB').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>IRB Registration Requirement is required.</div>');
            retval = false;
        }
        if ($('#ui_txt_keyReferences').val() == '') {
            $('#ui_txt_keyReferences').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Key References is required.</div>');
            retval = false;
        }
    }

    var EventName = '';
    $("#ui_btnSaveandExit, #ui_btnSaveandExitEnd").click(function (e) {
        retval = true;
        EventName = "SaveandExit";
        SaveScientificRationaleII(EventName);
    });

    $("#ui_btnSaveandContinue, #ui_btnSaveandContinueEnd").click(function (e) {
        retval = true;
        EventName = "SaveandContinue";
        ValidateMandatoryControls()
        SaveScientificRationaleII(EventName);
    });

    function SaveandContinue() {
        objectNewStudy = new Object();
        objectNewStudy.SampleSizeJustificationandStatisticalAnalysis = $('#ui_txt_sampleSizeJustification').val();
        objectNewStudy.ClinicalPharmacology = $('#ui_txt_clinicalPharmacology').val();
        objectNewStudy.EnrollmentHistoryforOtherRelatedStudies = $('#ui_txt_enrollmentHistory').val();
        if ($('#ui_ddl_competingStudies').val() !== "")
            objectNewStudy.IsCompetingStudies = $('#ui_ddl_competingStudies').val() === 'Yes' ? true : false;
        objectNewStudy.CompetingStudies = $('#ui_txt_impactPatientAccrual').val();
        if ($('#ui_ddl_proposedStudyIND').val() !== "")
            objectNewStudy.IsINDSubmission = $('#ui_ddl_proposedStudyIND').val() === 'Yes' ? true : false;
        objectNewStudy.RationaleforINDExemption = $('#ui_txt_rationaleForINDExemption').val();
        if ($('#ui_ddl_registrationIRB').val() !== "")
        objectNewStudy.IsIrbregistrationRequirement = $('#ui_ddl_registrationIRB').val() === 'Yes' ? true : false;
        objectNewStudy.AdverseEventsExemptfromCollection = $('#ui_txt_adverseEvents').val();
        objectNewStudy.KeyReferences = $('#ui_txt_keyReferences').val();
        if ($('#pITaskStatus').val().toUpperCase() == $('#pIsubmitprotocol').val().toUpperCase() || $('#TaskName').val() === "Resubmit Protocol") {
            objectNewStudy.InvestigationalSiteProtocolNumber = $('#ui_txt_submitprotocol').val();
        }
        else
            objectNewStudy.InvestigationalSiteProtocolNumber = '';

        objCorrelativeScienceStudies = new Object();
        if ($('#ui_ddl_correlativeScience').val() !== "")
            objCorrelativeScienceStudies.IsincludeCorrelativeScience = $('#ui_ddl_correlativeScience').val() === 'Yes' ? true : false;
        objCorrelativeScienceStudies.BiomarkerStudiesperformedatStudySite = $('#ui_txt_correlativescienceAtStudySite').val();
        objCorrelativeScienceStudies.BiomarkerStudiesperformedatCompanySite = $('#ui_txt_correlativescienceAtCompanySite').val();
        objCorrelativeScienceStudies.BiomarkerSamplingDetails = $('#ui_txt_correlativeScienceSamplingDet').val();

        objPlannedTrialMilestoneDatesandEnrollment = new Object();
        objPlannedTrialMilestoneDatesandEnrollment.TrialStart = GetEndDateForMonth($("#ui_dt_trialStart").val());
        objPlannedTrialMilestoneDatesandEnrollment.RecruitmentEnd = GetEndDateForMonth($("#ui_dt_recruitmentEnd").val());
        objPlannedTrialMilestoneDatesandEnrollment.TrialEnd = GetEndDateForMonth($("#ui_dt_trialEnd").val());
        objPlannedTrialMilestoneDatesandEnrollment.CompletionofTrialReport = GetEndDateForMonth($("#ui_dt_completionOfTrialReport").val());
        objPlannedTrialMilestoneDatesandEnrollment.PrimaryPublicationDate = GetEndDateForMonth($("#ui_dt_primaryPublication").val());
        objPlannedTrialMilestoneDatesandEnrollment.TotalPlannedNumberofPatients = parseInt($('#ui_num_noOfPatients').val());
        objPlannedTrialMilestoneDatesandEnrollment.PlannedNumberofCenters = parseInt($('#ui_num_plannedNoOfCenters').val());

        objPharmacovigilanceRequirements = new Object();
        if ($('#ui_ddl_interventionalTrial').val() !== "")
        objPharmacovigilanceRequirements.TrialType = $('#ui_ddl_interventionalTrial').val();
        objPharmacovigilanceRequirements.IsAllnonseriousAes = $('#ui_chkbox_allnonseriousAEs').prop("checked");
        objPharmacovigilanceRequirements.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios = $('#ui_chkbox_allreportsdescribingtheoccurrenceofotherspecialscenarios').prop("checked");
        objPharmacovigilanceRequirements.Safetydata = $('#ui_txt_Specifywhatsafetydata').val();
        objPharmacovigilanceRequirements.AdverseEventsExemptfromCollection = $('#ui_txt_adverseEvents').val();

        $.ajax({
            async: true,
            type: "POST",
            url: "/NewStudy/CreateUpdateScientificRationaleII/",
            cache: false,
            dataType: "json",
            data: { "NewStudy": objectNewStudy, "CorrelativeScienceStudies": objCorrelativeScienceStudies, "PlannedTrialMilestoneDatesandEnrollment": objPlannedTrialMilestoneDatesandEnrollment, "PharmacovigilanceRequirements": objPharmacovigilanceRequirements },
            success: function (response) {
                if (response.Data == 'Success') {
                    if (EventName === "SaveandExit") {
                        DestroySession();
                        opener.location.reload();
                        window.close();
                    }
                    //window.location.href = "../NewStudy/PersonalandResearchSites?StudyId=" + $('#StudyId').val() + '&&mode=' + $('#mode').val() + '&&StudyType=' + $('#StudyType').val() + '&&piTaskStatus=' + $('#pITaskStatus').val();
                    else {
                        obj = new Object();
                        obj.StudyId = $('#StudyId').val();
                        obj.mode = $('#mode').val();
                        obj.StudyType = $('#StudyType').val();
                        obj.piTaskStatus = $('#pITaskStatus').val();
                        obj.TaskName = $('#TaskName').val();

                        $.ajax({
                            async: true,
                            type: "POST",
                            url: "/Login/OpenNewWindow",
                            data: { "obj": obj },
                            success: function (results) {
                                if (results.data === "Success") {
                                    window.location.href = "/NewStudy/PersonalandResearchSites";
                                }
                                else {
                                    popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
                                }
                            }
                        });
                    }
                }

                else {
                    popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
                }
            },
            failure: function (response) {
                popupNotification.show("There are errors on the page. Please correct them to continue.", "error");

            }
        });
    }

    function SaveScientificRationaleII(EventName) {
        if (EventName == "SaveandContinue") {
            event.preventDefault();
            if (validator.validate() && retval === true)
                SaveandContinue();
            else
                popupNotification.show("There are errors on the page.Please correct them to continue.", "error");
        }
        else
            SaveandContinue();
    };
});

if ($("#pITaskStatus").val() === RESUBMITPROPOSAL) {
    $('#taskHeading').text("Re-Submit Proposal");
    $('.border-right').removeClass('border-right');
    $('#deleteBtn,#deleteBtnEnd').hide();
}
else if ($('#TaskName').val() === RESUBMITPROTOCOL) {
    $('#taskHeading').text("Resubmit Protocol");
    $('.border-right').removeClass('border-right');
    $('#deleteBtn,#deleteBtnEnd').hide();

}
if ($('#TaskName').val() === SUBMITPROTOCOL) {
    $('#taskHeading').text("Submit Protocol");
    $('.border-right').removeClass('border-right');
    $('#deleteBtn,#deleteBtnEnd').hide();
}