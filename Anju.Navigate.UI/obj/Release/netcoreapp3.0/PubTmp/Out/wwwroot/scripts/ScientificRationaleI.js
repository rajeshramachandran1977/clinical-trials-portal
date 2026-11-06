function onCancel() {
    window.close();
    opener.location.reload();
}

var wnd;
var minAge;
var maxAge;
maxnumber = 100;

$(document).ready(function () {
    wnd = $("#modalWindow").kendoWindow({
        title: deletemessagetitlebox,
        modal: true,
        visible: false,
        resizable: false,
        width: 400
    }).data("kendoWindow");
});

function deleteCohortRow(e) {
    e.preventDefault ? e.preventDefault() : e.returnValue = false;
    $(document).ready(function () {
        wnd = $("#modalWindow").kendoWindow({
            title: deletemessagetitlebox,
            modal: true,
            visible: false,
            resizable: false,
            width: 400
        }).data("kendoWindow");
    });

    var grid = $("#ui_dtg_gridCohortLevels").data("kendoGrid"); //Get the grid from which the pop-up is coming
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

function deleteObjectivesandEndpoints(e) {
    e.preventDefault ? e.preventDefault() : e.returnValue = false;
    $(document).ready(function () {
        wnd = $("#modalWindow").kendoWindow({
            title: deletemessagetitlebox,
            modal: true,
            visible: false,
            resizable: false,
            width: 400
        }).data("kendoWindow");
    });

    var grid = $("#ui_dtg_gridObjectivesandEndpoints").data("kendoGrid"); //Get the grid from which the pop-up is coming
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

function deleteTreatmentInformation(e) {
    e.preventDefault ? e.preventDefault() : e.returnValue = false;
    $(document).ready(function () {
        wnd = $("#modalWindow").kendoWindow({
            title: deletemessagetitlebox,
            modal: true,
            visible: false,
            resizable: false,
            width: 400
        }).data("kendoWindow");
    });

    var grid = $("#ui_dtg_gridTreatmentInformation").data("kendoGrid"); //Get the grid from which the pop-up is coming
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

function OnsaveCohortLevelChanges(e) {
    var grid = null;
    if ($('#StudyType').val() === studytypeinterventional) {
        switch (e.type) {
            case "create":
                grid = $("#ui_dtg_gridCohortLevels").data("kendoGrid");
                grid.dataSource.read();
                break;
            case "update":
                grid = $("#ui_dtg_gridCohortLevels").data("kendoGrid");
                grid.dataSource.read();
                break;
            case "destroy":
                grid = $("#ui_dtg_gridCohortLevels").data("kendoGrid");
                grid.dataSource.read();
                break;
        }
    }
}

function OnsaveObjectiveEndpointChanges(e) {
    var grid = null;
    switch (e.type) {
        case "create":
            grid = $("#ui_dtg_gridObjectivesandEndpoints").data("kendoGrid");
            grid.dataSource.read();
            break;
        case "update":
            grid = $("#ui_dtg_gridObjectivesandEndpoints").data("kendoGrid");
            grid.dataSource.read();
            break;
        case "destroy":
            grid = $("#ui_dtg_gridObjectivesandEndpoints").data("kendoGrid");
            grid.dataSource.read();
            break;
    }
}

function OnsaveTreatementInfoChanges(e) {
    var grid = null;
    if ($('#StudyType').val() === studytypeinterventional) {
        switch (e.type) {
            case "create":
                grid = $("#ui_dtg_gridTreatmentInformation").data("kendoGrid");
                grid.dataSource.read();
                break;
            case "update":
                grid = $("#ui_dtg_gridTreatmentInformation").data("kendoGrid");
                grid.dataSource.read();
                break;
            case "destroy":
                grid = $("#ui_dtg_gridTreatmentInformation").data("kendoGrid");
                grid.dataSource.read();
                break;
        }
    }
}

//End
$(function () {

    var validator = $("#ui_frmNewStudy").kendoValidator().data("kendoValidator");

    $("#ui_txt_titleOfTrial").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $('#ui_ddl_primaryDrug').change(function () {
        $('#primaryDrug').next("div.error").remove();
    }).change();
    $("#ui_txt_indication").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_txt_rationaleForTrial").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_txt_trialDesign").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_txt_patientPopulation").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_txt_keyInclusionCriteria").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_txt_exclusionCriteria").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $('#ui_ddl_maxAge').change(function () {
        if (parseInt($('#ui_ddl_maxAge').val()) === 'NaN') {
            maxAge = maxnumber;
        } else {
            maxAge = parseInt($('#ui_ddl_maxAge').val());
        }
        if (parseInt($('#ui_ddl_maxAge').val()) > parseInt($('#ui_ddl_minAge').val()))
            $(this).next("div.error").remove();
    }).change();
    $('#ui_ddl_blinding').change(function () {
        $('#blinding').next("div.error").remove();
    }).change();
    $('#ui_ddl_structure').change(function () {
        $('#structure').next("div.error").remove();
    }).change();
    $('#ui_ddl_randomized').change(function () {
        $('#randomized').next("div.error").remove();
    }).change();
    $('#ui_multiselectGender').change(function () {
        $('#multiselectGender').next("div.error").remove();
    }).change();
    $('#ui_ddl_minAge').change(function () {
        var minAgeArray = $('#ui_ddl_minAge').val().split(" ");
        if (minAgeArray[1] === null) {
            minAge = minAgeArray[0];
        } else {
            minAge = parseInt(minAgeArray[0]) / 10;
        }
        $('#minAge').next("div.error").remove();
    }).change();
    $('#ui_ddl_maxAge').change(function () {
        $('#maxAge').next("div.error").remove();
    }).change();
    $("#ui_txt_treatmentArms").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });

    //Validate mandatory non-kendo fields
    function Validatemandatoryfields() {

        $(".error").remove();
        retval = true;
        if ($('#ui_txt_titleOfTrial').val().trim() === "") {
            $('#ui_txt_titleOfTrial').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + titleoftrialrequired + '</div>');
            retval = false;
        }
        if ($('#ui_ddl_primaryDrug').val().trim() === "") {
            $('#primaryDrug').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + primarycompound + '</div>');
            retval = false;
        }
        if ($('#ui_txt_indication').val().trim() === "") {
            $('#ui_txt_indication').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + indicationrequired + '</div>');
            retval = false;
        }
        if ($('#ui_txt_rationaleForTrial').val().trim() === "") {
            $('#ui_txt_rationaleForTrial').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + rationalefortrialrequired + '</div>');
            retval = false;
        }
        if ($('#ui_txt_trialDesign').val().trim() === "") {
            $('#ui_txt_trialDesign').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + trialdesignrequired + '</div>');
            retval = false;
        }
        if ($('#ui_ddl_blinding').val() === "") {
            $('#blinding').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + blindingrequired + '</div>');
            retval = false;
        }
        if ($('#ui_ddl_structure').val() === "") {
            $('#structure').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + structurerequired + '</div>');
            retval = false;
        }
        if ($('#ui_ddl_randomized').val() === "") {
            $('#randomized').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + randomizedrequired + '</div>');
            retval = false;
        }
        if ($('#ui_multiselectGender').data("kendoMultiSelect").value().length <= 0) {
            $('#multiselectGender').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span >' + genderrequired + '</div>');
            retval = false;
        }
        if ($('#ui_ddl_minAge').val() === "") {
            $('#minAge').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + minimumagerequired + '</div>');
            retval = false;
        }
        if ($('#ui_ddl_maxAge').val() === "") {
            $('#maxAge').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + maximumagerequired + '</div>');
            retval = false;
        }
        if ($('#ui_txt_patientPopulation').val().trim() === "") {
            $('#ui_txt_patientPopulation').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + patientpopulationrequired + '</div>');
            retval = false;
        }
        if ($('#ui_txt_keyInclusionCriteria').val().trim() === "") {
            $('#ui_txt_keyInclusionCriteria').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + keyinclusioncriteriarequired + '</div>');
            retval = false;
        }
        if ($('#ui_txt_exclusionCriteria').val().trim() === "") {
            $('#ui_txt_exclusionCriteria').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + keyexclusioncriteriarequired + '</div>');
            retval = false;
        }
        if ($('#StudyType').val() === studytypeinterventional) {
            if ($('#ui_txt_treatmentArms').val().trim() === "") {
                $('#ui_txt_treatmentArms').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + howmanytreatmentarmsapplytothistrialrequired + '</div>');
                retval = false;
            }
        }
        if (minAge > maxAge) {
            $('#maxAge').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + maximumagecannotbelessthanminimumage + '</div>');
            retval = false;
        }
    }
    var isPrimarrecordpresent = true;
    function ValidateGrids() {     
        //Cohort levels for dose escalation trials only' is required
        //Start
        retvalforgrids = true;
        if ($('#StudyType').val() === studytypeinterventional) {
            var noofGriditems = $("#ui_dtg_gridCohortLevels").data("kendoGrid").dataSource.data().length;
            if (noofGriditems === 0) {
                $('#ui_dtg_gridCohortLevels').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + cohortlevelsrequired + '</div>');
                retvalforgrids = false;
                //return false;
            }
        }
        //end

        var grid = $("#ui_dtg_gridObjectivesandEndpoints").data("kendoGrid");       
        datas = grid.dataSource.data();
        if (datas.length === 0) {
            $('#ui_dtg_gridObjectivesandEndpoints').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + objectivetypeandobjectivenameisrequired + '</div>');
            retvalforgrids = false;
        } else {
            for (var i = 0; i < datas.length; i++) {
                if (datas[i].ObjectiveType !== "Primary") {
                    isPrimarrecordpresent = false;
                   // break;
                } else {
                    isPrimarrecordpresent = true;
                   // break;
                }
            }
            if (isPrimarrecordpresent === false) {
                $('#ui_dtg_gridObjectivesandEndpoints').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + objectivetypeandobjectivenameisrequired + '</div>');
                retvalforgrids = false;
            } else
                retvalforgrids = true;
        }
        var isObjectivetypepresent = true;
        if (datas.length > 0 && isPrimarrecordpresent === true) {
            for (var y = 0; y < datas.length; y++) {
                if (datas[y].ObjectiveType === null) {
                    isObjectivetypepresent = false;
                    break;
                } else
                    isObjectivetypepresent = true;
            }
            if (isObjectivetypepresent === false) {
                $('#ui_dtg_gridObjectivesandEndpoints').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + objectivetypeisrequired + '</div>');
                retvalforgrids = false;
            } else
                retvalforgrids = true;
        }
        var isObjectiveNamepresent = true;
        if (datas.length > 0 && isPrimarrecordpresent === true && isObjectivetypepresent === true) {
            for (var x = 0; x < datas.length; x++) {
                if (datas[x].ObjectiveName === null || datas[x].ObjectiveName === "" ) {
                    isObjectiveNamepresent = false;
                    break;
                } else
                    isObjectiveNamepresent = true;
            }
            if (isObjectiveNamepresent === false) {
                $('#ui_dtg_gridObjectivesandEndpoints').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + objectivenameisrequired + '</div>');
                retvalforgrids = false;
            } else
                retvalforgrids = true;
        }
        if ($('#StudyType').val() === studytypeinterventional) {
            GriddatanotSaved('ui_dtg_gridCohortLevels');
            GriddatanotSaved('ui_dtg_gridTreatmentInformation');
        }
        // GriddatanotSaved('ui_dtg_gridObjectivesandEndpoints');       
    }

    var EventName = '';
    $("#ui_btnSaveandExit, #ui_btnSaveandExitEnd").click(function (e) {
        EventName = saveandexit;
        SaveScientificRationaleI(EventName);
    });

    $("#ui_btnSaveandContinue, #ui_btnSaveandContinueEnd").click(function (e) {
        EventName = saveandcontinue;
        Validatemandatoryfields();
        ValidateGrids();
        SaveScientificRationaleI(EventName);
    });

    function SaveScientificRationaleI(EventName) {
        if (EventName === saveandcontinue) {
            event.preventDefault();
            if (validator.validate() && retval === true && retvalforgrids === true && isPrimarrecordpresent === true)
                SaveandContinue();
            else
                popupNotification.show(errorsinthepage, "error");
        } else
            SaveandContinue();
    }

    function SaveandContinue() {
        var NewStudy = {
            StudyId: $('#StudyId').val(),
            StudyType: $('#StudyType').val(),
            TitleofTrial: $('#ui_txt_titleOfTrial').val(),
            Treatmentarms: $('#ui_txt_treatmentArms').val()
        }
        var trialPhase = {
            TrialPhaseId: $("#TrialPhaseId").val(),
            PhaseI: $('#PhaseI').prop("checked"),
            PhaseII: $('#PhaseII').prop("checked"),
            PhaseIII: $('#PhaseIII').prop("checked"),
            PhaseIV: $('#PhaseIV').prop("checked")
        }
        var drugorCompounddetails = {
            DrugorCompounddetailsId: $("#DrugorCompounddetailsId").val(),
            Primarydrug: $('#ui_ddl_primaryDrug').val(),
            Secondarydrug: $('#ui_ddl_secondaryDrug').val(),
            Tertiarydrug: $('#ui_ddl_tertiaryDrug').val(),
            SecondaryType: $('#ui_ddl_drugOrCompoundTypeForSecondary').val(),
            TertiaryaryType: $('#ui_ddl_drugOrCompoundTypeForTertiary').val()
        }

        var Gender = $('#ui_multiselectGender').val();
        var conceptDesignandRationale = {
            ConceptDesignandRationaleId: $('#ConceptDesignandRationaleId').val(),
            Indication: $('#ui_txt_indication').val(),
            RationaleforTrial: $('#ui_txt_rationaleForTrial').val(),
            TrialDesign: $('#ui_txt_trialDesign').val(),
            Binding: $('#ui_ddl_blinding').val(),
            Structure: $('#ui_ddl_structure').val(),
            Randomized: $('#ui_ddl_randomized').val(),
            MinimumAge: $('#ui_ddl_minAge').val(),
            MaximumAge: $('#ui_ddl_maxAge').val(),
            PatientPopulation: $('#ui_txt_patientPopulation').val(),
            KeyInclusionCriteria: $('#ui_txt_keyInclusionCriteria').val(),
            KeyExclusionCriteria: $('#ui_txt_exclusionCriteria').val()
        }
        $.ajax({
            async: true,
            type: "POST",
            url: "/NewStudy/CreateUpdateScientificRationaleI/",
            cache: false,
            dataType: "json",
            data: {
                "NewStudy": NewStudy,
                "trialPhase": trialPhase,
                "drugorCompounddetails": drugorCompounddetails,
                "conceptDesignandRationale": conceptDesignandRationale,
                "Gender": Gender
            },
            success: function (response) {
                if (response.Data === 'Success') {
                    if (EventName === saveandexit) {
                        DestroySession();
                        opener.location.reload();
                        window.close();
                    }

                    obj = new Object();
                    obj.StudyId = $('#StudyId').val();
                    obj.StudyType = $('#StudyType').val();
                    obj.mode = $('#mode').val();
                    obj.PITaskStatus = $('#pITaskStatus').val();
                    obj.TaskName = $('#TaskName').val();

                    $.ajax({
                        async: true,
                        type: "POST",
                        url: "/Login/OpenNewWindow",
                        data: {
                            "obj": obj
                        },
                        success: function (results) {
                            if (results.data === "Success") {
                                window.location.href = "../NewStudy/ScientificRationaleII";
                            } else {
                                popupNotification.show(errorsinthepage, "error");
                            }
                        }
                    });

                } else {
                    if (EventName === saveandexit) {
                        DestroySession();
                        opener.location.reload();
                        window.close();
                    }
                    else
                        popupNotification.show(errorsinthepage, "error");
                }
            },
            failure: function (response) {
                popupNotification.show(errorsinthepage, "error");

            }
        });

        function DestroySession() {
            $.ajax({
                async: true,
                type: "POST",
                url: "/NewStudy/DestroyStudySession/",
                cache: false,
                dataType: "json",
                failure: function (response) {
                    popupNotification.show(errorsinthepage, "error");
                }
            });
        }

    }
});

function onDataBound(e) {
    var dropdownlist = $("#ui_ddl_structure").data("kendoDropDownList");
    dropdownlist.select(function (dataItem) {
        return dataItem.Code === parallelgroup;
    });
}

if ($("#pITaskStatus").val() === resubmitproposal) {
    $('#taskHeading').text(resubmitproposal);
    $('.border-right').removeClass('border-right');
    $('#deleteBtn,#deleteBtnEnd').hide();
}
else if ($('#TaskName').val() === resubmitProtocol) {
    $('#taskHeading').text("Resubmit Protocol");
    $('.border-right').removeClass('border-right');
    $('#deleteBtn,#deleteBtnEnd').hide();
}

if ($('#TaskName').val() === submitProtocol) {
    $('#taskHeading').text("Submit Protocol");
    $('.border-right').removeClass('border-right');
    $('#deleteBtn,#deleteBtnEnd').hide();
}

$(document).ready(function () {
    var retval = true;

    //Enable Drug/Compound Type fields only on selection of Drug types
    $('#ui_ddl_secondaryDrug').change(function () {
        if ($('#ui_ddl_secondaryDrug').val() === "") {
            $('#ui_ddl_drugOrCompoundTypeForSecondary').data('kendoDropDownList').value("");
            $('#ui_ddl_drugOrCompoundTypeForSecondary').data("kendoDropDownList").enable(false);
        } else
            $('#ui_ddl_drugOrCompoundTypeForSecondary').data("kendoDropDownList").enable(true);
    }).change();

    $('#ui_ddl_tertiaryDrug').change(function () {
        if ($('#ui_ddl_tertiaryDrug').val() === "") {
            $('#ui_ddl_drugOrCompoundTypeForTertiary').data('kendoDropDownList').value("");
            $('#ui_ddl_drugOrCompoundTypeForTertiary').data("kendoDropDownList").enable(false);
        } else
            $('#ui_ddl_drugOrCompoundTypeForTertiary').data("kendoDropDownList").enable(true);
    }).change();

    var StudyType = $('#StudyType').val();

    //current page button active
    $('#scientificRationale').removeClass('btn-submission').addClass('activePage');
    $('#1').removeClass('btn-submission').addClass('activePage');

    var RegisterConstants = {
        elementIDConstant: {
            multiselect_gender: "#ui_multiselectGender"
        }
    };
    //Multi Select drop down
    $(RegisterConstants.elementIDConstant.multiselect_gender).kendoMultiSelect({
        dataTextField: "Code",
        dataValueField: "CodeId",
        optionLabel: 'Select',
        autoClose: false,
        dataSource: {
            transport: {
                read: {
                    dataType: "json",
                    url: "../Common/GetGender"
                }
            }
        }
    });

    var mode = $('#mode').val();
    if (mode === "Create") {
        // Get New Study ID
        $.ajax({
            async: true,
            type: "POST",
            url: "/NewStudy/GetNewStudyID/",
            data: {
                "mode": mode
            },
            cache: false,
            dataType: "json",
            failure: function (response) {
                popupNotification.show(contactadministratoronerror, "error");
            }
        });
    }

    // Display entered data if in Edit/read mode
    if (mode === "Update") {
        $.ajax({
            async: true,
            type: "POST",
            url: "/NewStudy/GetScientificRationaleIDetails/",
            cache: false,
            dataType: "json",
            data: {
                "StudyId": $('#StudyId').val()
            },
            success: function (response) {
                if (response.Data === '') {
                    popupNotification.show(errorsinthepage, "error");
                } else {

                    $("#ui_txt_titleOfTrial").val(response.Data[0].TitleofTrial);
                    noOfCharactersLeft(response.Data[0].TitleofTrial, 'ui_txt_titleOfTrial');
                    if (response.Data[0].StudyType === studytypeinterventional) {
                        $("#TrialPhaseId").val(response.Data[0].TrialPhaseId);
                        if (response.Data[0].PhaseI === true)
                            $("#PhaseI").prop('checked', true);
                        if (response.Data[0].PhaseII === true)
                            $("#PhaseII").prop('checked', true);
                        if (response.Data[0].PhaseIII === true)
                            $("#PhaseIII").prop('checked', true);
                        if (response.Data[0].PhaseIV === true)
                            $("#PhaseIV").prop('checked', true);
                    }
                    $("#DrugorCompounddetailsId").val(response.Data[0].DrugorCompounddetailsId);
                    $("#ui_ddl_primaryDrug").data('kendoDropDownList').value(response.Data[0].Primarydrug);
                    $("#ui_ddl_secondaryDrug").data('kendoDropDownList').value(response.Data[0].Secondarydrug);
                    $("#ui_ddl_tertiaryDrug").data('kendoDropDownList').value(response.Data[0].Tertiarydrug);
                    $("#ui_ddl_drugOrCompoundTypeForSecondary").data('kendoDropDownList').value(response.Data[0].SecondaryType);
                    $("#ui_ddl_drugOrCompoundTypeForTertiary").data('kendoDropDownList').value(response.Data[0].TertiaryaryType);
                    $("#ui_txt_indication").val(response.Data[0].Indication);
                    noOfCharactersLeft(response.Data[0].Indication, 'ui_txt_indication');
                    $("#ui_txt_rationaleForTrial").val(response.Data[0].RationaleforTrial);
                    noOfCharactersLeft(response.Data[0].TitleofTrial, 'ui_txt_rationaleForTrial');
                    $("#ui_txt_trialDesign").val(response.Data[0].TrialDesign);
                    noOfCharactersLeft(response.Data[0].TrialDesign, 'ui_txt_trialDesign');
                    $("#ConceptDesignandRationaleId").val(response.Data[0].ConceptDesignandRationaleId);
                    if (response.Data[0].StudyType === studytypeinterventional) {
                        $("#ui_ddl_blinding").data('kendoDropDownList').value(response.Data[0].Binding);
                        $("#ui_ddl_structure").data('kendoDropDownList').value(response.Data[0].Structure);
                        $("#ui_ddl_randomized").data('kendoDropDownList').value(response.Data[0].Randomized);
                        $("#ui_txt_treatmentArms").val(response.Data[0].Treatmentarms);
                        noOfCharactersLeft(response.Data[0].Treatmentarms, 'ui_txt_treatmentArms');
                    }
                    if (response.Data[0].Gender !== null) {
                        var gender = response.Data[0].Gender.split(',');
                        $(RegisterConstants.elementIDConstant.multiselect_gender).getKendoMultiSelect().value(gender);
                    }

                    $("#ui_ddl_minAge").data('kendoDropDownList').value(response.Data[0].MinimumAge);
                    $("#ui_ddl_maxAge").data('kendoDropDownList').value(response.Data[0].MaximumAge);
                    $("#ui_txt_patientPopulation").val(response.Data[0].PatientPopulation);
                    noOfCharactersLeft(response.Data[0].PatientPopulation, 'ui_txt_patientPopulation');
                    $("#ui_txt_keyInclusionCriteria").val(response.Data[0].KeyInclusionCriteria);
                    noOfCharactersLeft(response.Data[0].KeyInclusionCriteria, 'ui_txt_keyInclusionCriteria');
                    $("#ui_txt_exclusionCriteria").val(response.Data[0].KeyExclusionCriteria);
                    noOfCharactersLeft(response.Data[0].KeyExclusionCriteria, 'ui_txt_exclusionCriteria');
                }
            },
            failure: function (response) {
                popupNotification.show(errorsinthepage, "error");
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