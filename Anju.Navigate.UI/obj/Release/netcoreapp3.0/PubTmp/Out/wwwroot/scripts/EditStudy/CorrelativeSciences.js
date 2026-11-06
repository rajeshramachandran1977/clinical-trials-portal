$(function () {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");

    //#region Correlative Science
    $("#ui_txtarea_correlativescienceatcompanysite").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_correlativescienceatcompanysite").val().trim();
        if (str != "")
            if ($("#regexforcorrelativescienceatcompanysite").val() != "") {
                var expr = new RegExp($("#regexforcorrelativescienceatcompanysite").val());
                var str = $("#ui_txtarea_correlativescienceatcompanysite").val();
                if (str != "" && !expr.test(str)) {
                    $('#correlativescienceatcompanysite').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcorrelativescienceatcompanysite").val() + '</div>');
                    isvalidRegexforcorrelativescienceatcompanysite = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcorrelativescienceatcompanysite = true;
                    return true;
                }
            }
    });
    $("#ui_txt_correlativescienceatcompanysite").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_correlativescienceatcompanysite").val().trim();
        if (str != "")
            if ($("#regexforcorrelativescienceatcompanysite").val() != "") {
                var expr = new RegExp($("#regexforcorrelativescienceatcompanysite").val());
                var str = $("#ui_txt_correlativescienceatcompanysite").val();
                if (str != "" && !expr.test(str)) {
                    $('#correlativescienceatcompanysite').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcorrelativescienceatcompanysite").val() + '</div>');
                    isvalidRegexforcorrelativescienceatcompanysite = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcorrelativescienceatcompanysite = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_correlativescienceatstudysite").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_correlativescienceatstudysite").val().trim();
        if (str != "")
            if ($("#regexforcorrelativescienceatstudysite").val() != "") {
                var expr = new RegExp($("#regexforcorrelativescienceatstudysite").val());
                var str = $("#ui_txtarea_correlativescienceatstudysite").val();
                if (str != "" && !expr.test(str)) {
                    $('#correlativescienceatstudysite').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcorrelativescienceatstudysite").val() + '</div>');
                    isvalidRegexforcorrelativescienceatstudysite = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcorrelativescienceatstudysite = true;
                    return true;
                }
            }
    });
    $("#ui_txt_correlativescienceatstudysite").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_correlativescienceatstudysite").val().trim();
        if (str != "")
            if ($("#regexforcorrelativescienceatstudysite").val() != "") {
                var expr = new RegExp($("#regexforcorrelativescienceatstudysite").val());
                var str = $("#ui_txt_correlativescienceatstudysite").val();
                if (str != "" && !expr.test(str)) {
                    $('#correlativescienceatstudysite').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcorrelativescienceatstudysite").val() + '</div>');
                    isvalidRegexforcorrelativescienceatstudysite = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcorrelativescienceatstudysite = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_correlativesciencesamplingdet").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_correlativesciencesamplingdet").val().trim();
        if (str != "")
            if ($("#regexforcorrelativesciencesamplingdet").val() != "") {
                var expr = new RegExp($("#regexforcorrelativesciencesamplingdet").val());
                var str = $("#ui_txtarea_correlativesciencesamplingdet").val();
                if (str != "" && !expr.test(str)) {
                    $('#correlativesciencesamplingdetails').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcorrelativesciencesamplingdet").val() + '</div>');
                    isvalidRegexforcorrelativesciencesamplingdet = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcorrelativesciencesamplingdet = true;
                    return true;
                }
            }
    });
    $("#ui_txt_correlativesciencesamplingdet").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_correlativesciencesamplingdet").val().trim();
        if (str != "")
            if ($("#regexforcorrelativesciencesamplingdet").val() != "") {
                var expr = new RegExp($("#regexforcorrelativesciencesamplingdet").val());
                var str = $("#ui_txt_correlativesciencesamplingdet").val();
                if (str != "" && !expr.test(str)) {
                    $('#correlativesciencesamplingdetails').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcorrelativesciencesamplingdet").val() + '</div>');
                    isvalidRegexforcorrelativesciencesamplingdet = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcorrelativesciencesamplingdet = true;
                    return true;
                }
            }
    });
    //#endregion Correlative Science

    function ValidateCorrelativeScienceFields() {
        $(".error").remove();
        retval = true;
        objCorrelativeScience = new Object();
        objCorrelativeScience.StudyId = $('#StudyId').val();

        if ($('#displayStudyincludecorrelativescience').is(':visible'))
            if (sessionStorage.getItem("isincludecorrelativesciences") == "true") {
                if ($('#ui_ddl_correlativeScience').val() == "") {
                    $('#studyincludecorrelativescience').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_studyincludecorrelativescience').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_correlativeScience').val() == yes)
                        objCorrelativeScience.IsincludeCorrelativeScience = true;
                    if ($('#ui_ddl_correlativeScience').val() == no) {
                        objCorrelativeScience.IsincludeCorrelativeScience = false;
                        objCorrelativeScience.BiomarkerStudiesperformedatStudySite = null;
                        objCorrelativeScience.BiomarkerSamplingDetails = null;
                        objCorrelativeScience.BiomarkerStudiesperformedatCompanySite = null;
                    }
                    if ($('#ui_ddl_correlativeScience').val() == "")
                        objCorrelativeScience.IsincludeCorrelativeScience = null;
                }
            }
            else
                if ($('#ui_ddl_correlativeScience').val() == yes)
                    objCorrelativeScience.IsincludeCorrelativeScience = true;
        if ($('#ui_ddl_correlativeScience').val() == no) {
            objCorrelativeScience.IsincludeCorrelativeScience = false;
            objCorrelativeScience.BiomarkerStudiesperformedatStudySite = null;
            objCorrelativeScience.BiomarkerSamplingDetails = null;
            objCorrelativeScience.BiomarkerStudiesperformedatCompanySite = null;
        }
        if ($('#ui_ddl_correlativeScience').val() == "")
            objCorrelativeScience.IsincludeCorrelativeScience = null;


        if ($('#displayCorrelativescienceatstudysite').is(':visible'))
            if (sessionStorage.getItem("iscorrelativescienceatstudysite") == "true") {
                if ($('#ui_txt_correlativescienceatstudysite').is(':visible')) {
                    if ($('#ui_txt_correlativescienceatstudysite').val() == "") {
                        $('#correlativescienceatstudysite').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_correlativescienceatstudysite').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_correlativescienceatstudysite').is(':visible')) {
                    if ($('#ui_txtarea_correlativescienceatstudysite').val() == "") {
                        $('#correlativescienceatstudysite').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_correlativescienceatstudysite').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_correlativescienceatstudysite').is(':visible'))
                    objCorrelativeScience.BiomarkerStudiesperformedatStudySite = $('#ui_txt_correlativescienceatstudysite').val().trim();
                if ($('#ui_txtarea_correlativescienceatstudysite').is(':visible'))
                    objCorrelativeScience.BiomarkerStudiesperformedatStudySite = $('#ui_txtarea_correlativescienceatstudysite').val().trim();
            }
            else {
                if ($('#ui_txt_correlativescienceatstudysite').is(':visible'))
                    objCorrelativeScience.BiomarkerStudiesperformedatStudySite = $('#ui_txt_correlativescienceatstudysite').val().trim();
                if ($('#ui_txtarea_correlativescienceatstudysite').is(':visible'))
                    objCorrelativeScience.BiomarkerStudiesperformedatStudySite = $('#ui_txtarea_correlativescienceatstudysite').val().trim();
            }

        if ($('#displayCorrelativesciencesamplingdetails').is(':visible'))
            if (sessionStorage.getItem("iscorrelativesciencesamplingdet") == "true") {
                if ($('#ui_txt_correlativesciencesamplingdet').is(':visible')) {
                    if ($('#ui_txt_correlativesciencesamplingdet').val() == "") {
                        $('#correlativesciencesamplingdetails').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_correlativesciencesamplingdet').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_correlativesciencesamplingdet').is(':visible')) {
                    if ($('#ui_txtarea_correlativesciencesamplingdet').val() == "") {
                        $('#correlativesciencesamplingdetails').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_correlativesciencesamplingdet').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_correlativesciencesamplingdet').is(':visible'))
                    objCorrelativeScience.BiomarkerSamplingDetails = $('#ui_txt_correlativesciencesamplingdet').val().trim();
                if ($('#ui_txtarea_correlativesciencesamplingdet').is(':visible'))
                    objCorrelativeScience.BiomarkerSamplingDetails = $('#ui_txtarea_correlativesciencesamplingdet').val().trim();
            }
            else {
                if ($('#ui_txt_correlativesciencesamplingdet').is(':visible'))
                    objCorrelativeScience.BiomarkerSamplingDetails = $('#ui_txt_correlativesciencesamplingdet').val().trim();
                if ($('#ui_txtarea_correlativesciencesamplingdet').is(':visible'))
                    objCorrelativeScience.BiomarkerSamplingDetails = $('#ui_txtarea_correlativesciencesamplingdet').val().trim();
            }

        if ($('#displayCorrelativescienceatcompanysite').is(':visible'))
            if (sessionStorage.getItem("iscorrelativescienceatcompanysite") == "true") {
                if ($('#ui_txt_correlativescienceatcompanysite').is(':visible')) {
                    if ($('#ui_txt_correlativescienceatcompanysite').val() == "") {
                        $('#correlativescienceatcompanysite').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_correlativescienceatcompanysite').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_correlativescienceatcompanysite').is(':visible')) {
                    if ($('#ui_txtarea_correlativescienceatcompanysite').val() == "") {
                        $('#correlativescienceatcompanysite').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_correlativescienceatcompanysite').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_correlativescienceatcompanysite').is(':visible'))
                    objCorrelativeScience.BiomarkerStudiesperformedatCompanySite = $('#ui_txt_correlativescienceatcompanysite').val().trim();
                if ($('#ui_txtarea_correlativescienceatcompanysite').is(':visible'))
                    objCorrelativeScience.BiomarkerStudiesperformedatCompanySite = $('#ui_txtarea_correlativescienceatcompanysite').val().trim();
            }
            else {
                if ($('#ui_txt_correlativescienceatcompanysite').is(':visible'))
                    objCorrelativeScience.BiomarkerStudiesperformedatCompanySite = $('#ui_txt_correlativescienceatcompanysite').val().trim();
                if ($('#ui_txtarea_correlativescienceatcompanysite').is(':visible'))
                    objCorrelativeScience.BiomarkerStudiesperformedatCompanySite = $('#ui_txtarea_correlativescienceatcompanysite').val().trim();
            }

    }

    //#region Remove err msg on key up for non grid text fields
    $("#correlativescienceatcompanysite,#correlativescienceatstudysite,#correlativesciencesamplingdetails").on("keyup", function (e) {
        $(this).next("div.error").remove();
    })

    $('#studyincludecorrelativescience').change(function () {
        $(this).next("div.error").remove();
    }).change();
    //#endregion

    $("#ui_btnSaveCorrelativeScience").click(function (e) {
        ValidateCorrelativeScienceFields();
        if (validator.validate() && retval === true &&
            isvalidRegexforcorrelativescienceatcompanysite === true &&
            isvalidRegexforcorrelativescienceatstudysite === true &&
            isvalidRegexforcorrelativesciencesamplingdet === true)
            Savedetails(type = 3, objEditstudy = objCorrelativeScience);
        else
            popupNotification.show("There are errors on the page.Please correct them to continue.", "error");
        return false;
    });
});

$("#correlativescience").on("click", function () {
    $('#correlativesciencescontents').show();
    LoadCorrelativeSciencesAttributeValues();
    LoadCorrelativeSciencesData();
});

function LoadCorrelativeSciencesAttributeValues() {
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/GetAttributeValues/",
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case isstudyincludecorrelativescience:
                            DropDowndetails(response, "displayStudyincludecorrelativescience", "ui_lbl_studyincludecorrelativescience", "ui_img_studyincludecorrelativescience", "isincludecorrelativesciences");
                            break;
                        case correlativesciencestudiesperformedatcompanysite:
                            Textdetails(response, "displayCorrelativescienceatcompanysite", "ui_lbl_correlativescienceatcompanysite", "ui_img_correlativescienceatcompanysite", "iscorrelativescienceatcompanysite", "ui_txt_correlativescienceatcompanysite", "ui_txtarea_correlativescienceatcompanysite", "ui_lbl_charsleftforcorrelativescienceatcompanysite", "regexforcorrelativescienceatcompanysite", "validationmsgforcorrelativescienceatcompanysite");
                            break;
                        case correlativesciencestudiesperformedatstudysite:
                            Textdetails(response, "displayCorrelativescienceatstudysite", "ui_lbl_correlativescienceatstudysite", "ui_img_correlativescienceatstudysite", "iscorrelativescienceatstudysite", "ui_txt_correlativescienceatstudysite", "ui_txtarea_correlativescienceatstudysite", "ui_lbl_charsleftforcorrelativescienceatstudysite", "regexforcorrelativescienceatstudysite", "validationmsgforcorrelativescienceatstudysite");
                            break;
                        case correlativesciencesamplingdetails:
                            Textdetails(response, "displayCorrelativesciencesamplingdetails", "ui_lbl_correlativesciencesamplingdet", "ui_img_correlativesciencesamplingdet", "iscorrelativesciencesamplingdet", "ui_txt_correlativesciencesamplingdet", "ui_txtarea_correlativesciencesamplingdet", "ui_lbl_charsleftforcorrelativesciencesamplingdet", "regexforcorrelativesciencesamplingdet", "validationmsgforcorrelativesciencesamplingdet");
                            break;
                        default:
                            break;
                    }
                }
            }
        },
        failure: function (response) {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });
}

function LoadCorrelativeSciencesData() {
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/GetCorrelativeSciencesData/",
        cache: false,
        dataType: "json",
        data: { "StudyId": $('#StudyId').val() },
        success: function (response) {
            if (response.Data == '')
                popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
            else {
                var IsincludeCorrelativeScience = response.Data[0].IsincludeCorrelativeScience;
                if (IsincludeCorrelativeScience == null)
                    $("#ui_ddl_correlativeScience").data('kendoDropDownList').value("Select");
                else {
                    if (IsincludeCorrelativeScience == true)
                        $('#ui_ddl_correlativeScience').data('kendoDropDownList').value(yes);
                    else
                        $('#ui_ddl_correlativeScience').data('kendoDropDownList').value(no);
                }
                if (IsincludeCorrelativeScience === true) {
                    $('#ifCorrelativeScienceYes').show();
                    $('#ui_txt_correlativescienceatstudysite,#ui_txtarea_correlativescienceatstudysite').val(response.Data[0].BiomarkerStudiesperformedatStudySite);
                    $('#ui_txt_correlativescienceatcompanysite,#ui_txtarea_correlativescienceatcompanysite').val(response.Data[0].BiomarkerStudiesperformedatCompanySite);
                    $('#ui_txt_correlativesciencesamplingdet,#ui_txtarea_correlativesciencesamplingdet').val(response.Data[0].BiomarkerSamplingDetails);
                }
            }
        },
        failure: function (response) {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });
}

function onChangeOfCorrelativeScience(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Value == "Yes") {
        $('#ifCorrelativeScienceYes').show();
    } else if (dataItem.Value == "" || dataItem.Value == "No") {
        $('#ifCorrelativeScienceYes').hide();
    }
}

function onChangeOfCompetingStudies(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Value == "Yes") {
        $('#impactPatientAcrual').show();
    } else if (dataItem.Value == "" || dataItem.Value == "No") {
        $('#impactPatientAcrual').hide();
    }
}

function onChangeOfINDProposedStudy(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Value == "No") {
        $('#rationaleINDExemption').show();
    } else if (dataItem.Value == "" || dataItem.Value == "Yes") {
        $('#rationaleINDExemption').hide();
    }
}

function onChangeOfInterventionalTrial(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Value == "") {
        $('#withACompanyDrug').hide();
        $('#withNOCompanyDrug').hide();
        $('#withACompanyDrugItems').hide();
        $('#withNOCompanyDrugItems').hide();
        //$('#InvolvingPRIMARYDATACOLLECTIONWITHOUT').hide();
        $('#ForPRIMARYDATACOLLECTIONWITH').hide();
        $('#basedOnSecondaryUseofdata').hide();
    } else if (dataItem.Value == "WITH a "+ appName +" Drug") {
        $('#withACompanyDrug').show();
        $('#withNOCompanyDrug').hide();
        $('#withACompanyDrugItems').show();
        $('#withNOCompanyDrugItems').hide();
    } else if (dataItem.Value == "WITH NO " + appName +" Drug") {
        $('#withACompanyDrug').hide();
        $('#withNOCompanyDrug').show();
        $('#withACompanyDrugItems').hide();
        $('#withNOCompanyDrugItems').show();
    } else if (dataItem.Value == "Involving PRIMARY DATA COLLECTION WITH a " + appName +" Product of Focus") {
        $('#withACompanyDrug').show();
    } else if (dataItem.Value == "Involving PRIMARY DATA COLLECTION WITHOUT a " + appName +" Product of Focus") {
        //$('#InvolvingPRIMARYDATACOLLECTIONWITHOUT').show();
        $('#ForPRIMARYDATACOLLECTIONWITH').show();
        $('#basedOnSecondaryUseofdata').hide();
        $('#withACompanyDrug').hide();
    } else if (dataItem.Value == "Based on SECONDARY USE OF DATA") {
        //$('#InvolvingPRIMARYDATACOLLECTIONWITHOUT').show();
        $('#ForPRIMARYDATACOLLECTIONWITH').hide();
        $('#basedOnSecondaryUseofdata').show();
        $('#withACompanyDrug').hide();
    }
}