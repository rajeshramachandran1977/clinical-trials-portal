$(function () {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");

    //#region Science Main
    var retisvalidRegex = true;
    $("#ui_txt_titleOfTrial").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_titleOfTrial").val().trim();
        if (str != "")
            if ($("#regexexprfortitleOfTrial").val() != "") {
                var expr = new RegExp($("#regexexprfortitleOfTrial").val());
                var str = $("#ui_txt_titleOfTrial").val();
                if (str != "" && !expr.test(str)) {
                    $('#titleoftrial').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortitleOfTrial").val() + '</div>');
                    isvalidRegexfortitleOfTrial = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortitleOfTrial = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_titleOfTrial").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_titleOfTrial").val().trim();
        if (str != "")
            if ($("#regexexprfortitleOfTrial").val() != "") {
                var expr = new RegExp($("#regexexprfortitleOfTrial").val());
                var str = $("#ui_txtarea_titleOfTrial").val();
                if (str != "" && !expr.test(str)) {
                    $('#titleoftrial').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortitleOfTrial").val() + '</div>');
                    isvalidRegexfortitleOfTrial = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortitleOfTrial = true;
                    return true;
                }
            }
    });
    $("#ui_txt_InvestigationalDrugandReferenceTherapy").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_InvestigationalDrugandReferenceTherapy").val().trim();
        if (str != "")
            if ($("#regexexprforinvestigationalDrugandReferenceTherapy").val() != "") {
                var expr = new RegExp($("#regexexprforinvestigationalDrugandReferenceTherapy").val());
                var str = $("#ui_txt_InvestigationalDrugandReferenceTherapy").val();
                if (str != "" && !expr.test(str)) {
                    $('#investigationalDrugandReferenceTherapy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforinvestigationalDrugandReferenceTherapy").val() + '</div>');
                    isvalidRegexforinvestigationalDrugandReferenceTherapy = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforinvestigationalDrugandReferenceTherapy = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_InvestigationalDrugandReferenceTherapy").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_InvestigationalDrugandReferenceTherapy").val().trim();
        if (str != "")
            if ($("#regexexprforinvestigationalDrugandReferenceTherapy").val() != "") {
                var expr = new RegExp($("#regexexprforinvestigationalDrugandReferenceTherapy").val());
                var str = $("#ui_txtarea_InvestigationalDrugandReferenceTherapy").val();
                if (str != "" && !expr.test(str)) {
                    $('#investigationalDrugandReferenceTherapy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforinvestigationalDrugandReferenceTherapy").val() + '</div>');
                    isvalidRegexforinvestigationalDrugandReferenceTherapy = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforinvestigationalDrugandReferenceTherapy = true;
                    return true;
                }
            }
    });
    $("#ui_txt_exclusioncriteria").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_exclusioncriteria").val().trim();
        if (str != "")
            if ($("#regexforexclusionCriteria").val() != "") {
                var expr = new RegExp($("#regexforexclusionCriteria").val());
                var str = $("#ui_txt_exclusioncriteria").val();
                if (str != "" && !expr.test(str)) {
                    $('#exclusioncriteria').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforexclusionCriteria").val() + '</div>');
                    isvalidRegexforexclusioncriteria = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforexclusioncriteria = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_exclusioncriteria").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_exclusioncriteria").val().trim();
        if (str != "")
            if ($("#regexforexclusionCriteria").val() != "") {
                var expr = new RegExp($("#regexforexclusionCriteria").val());
                var str = $("#ui_txtarea_exclusioncriteria").val();
                if (str != "" && !expr.test(str)) {
                    $('#exclusioncriteria').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforexclusionCriteria").val() + '</div>');
                    isvalidRegexforexclusioncriteria = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforexclusioncriteria = true;
                    return true;
                }
            }
    });
    $("#ui_txt_clinicalPharmacology").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_clinicalPharmacology").val().trim();
        if (str != "")
            if ($("#regexforclinicalPharmacology").val() != "") {
                var expr = new RegExp($("#regexforclinicalPharmacology").val());
                var str = $("#ui_txt_clinicalPharmacology").val();
                if (str != "" && !expr.test(str)) {
                    $('#clinicalPharmacology').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforclinicalPharmacology").val() + '</div>');
                    isvalidRegexforclinicalPharmacology = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforclinicalPharmacology = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_clinicalPharmacology").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_clinicalPharmacology").val().trim();
        if (str != "")
            if ($("#regexforclinicalPharmacology").val() != "") {
                var expr = new RegExp($("#regexforclinicalPharmacology").val());
                var str = $("#ui_txtarea_clinicalPharmacology").val();
                if (str != "" && !expr.test(str)) {
                    $('#clinicalPharmacology').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforclinicalPharmacology").val() + '</div>');
                    isvalidRegexforclinicalPharmacology = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforclinicalPharmacology = true;
                    return true;
                }
            }
    });
    $("#ui_txt_indication").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_indication").val().trim();
        if (str != "")
            if ($("#regexforindication").val() != "") {
                var expr = new RegExp($("#regexforindication").val());
                var str = $("#ui_txt_indication").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_indication').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforindication").val() + '</span>');
                    isvalidRegexforindication = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforindication = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_indication").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_indication").val().trim();
        if (str != "")
            if ($("#regexforindication").val() != "") {
                var expr = new RegExp($("#regexforindication").val());
                var str = $("#ui_txtarea_indication").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_indication').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforindication").val() + '</span>');
                    isvalidRegexforindication = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforindication = true;
                    return true;
                }
            }
    });
    $("#ui_txt_safetycriteria").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_safetycriteria").val().trim();
        if (str != "")
            if ($("#regexforsafetycriteria").val() != "") {
                var expr = new RegExp($("#regexforsafetycriteria").val());
                var str = $("#ui_txt_safetycriteria").val();
                if (str != "" && !expr.test(str)) {
                    $('#safetycriteria').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforsafetycriteria").val() + '</div>');
                    isvalidRegexforsafetycriteria = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforsafetycriteria = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_safetycriteria").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_safetycriteria").val().trim();
        if (str != "")
            if ($("#regexforsafetycriteria").val() != "") {
                var expr = new RegExp($("#regexforsafetycriteria").val());
                var str = $("#ui_txtarea_safetycriteria").val();
                if (str != "" && !expr.test(str)) {
                    $('#safetycriteria').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforsafetycriteria").val() + '</div>');
                    isvalidRegexforsafetycriteria = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforsafetycriteria = true;
                    return true;
                }
            }
    });
    $("#ui_txt_othercompound").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_othercompound").val().trim();
        if (str != "")
            if ($("#regexforothercompound").val() != "") {
                var expr = new RegExp($("#regexforothercompound").val());
                var str = $("#ui_txt_othercompound").val();
                if (str != "" && !expr.test(str)) {
                    $('#othercompound').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforothercompound").val() + '</div>');
                    isvalidRegexforothercompound = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforothercompound = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_othercompound").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_othercompound").val().trim();
        if (str != "")
            if ($("#regexforothercompound").val() != "") {
                var expr = new RegExp($("#regexforothercompound").val());
                var str = $("#ui_txtarea_othercompound").val();
                if (str != "" && !expr.test(str)) {
                    $('#othercompound').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforothercompound").val() + '</div>');
                    isvalidRegexforothercompound = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforothercompound = true;
                    return true;
                }
            }
    });
    $("#ui_txt_rationaleforstudy").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_rationaleforstudy").val().trim();
        if (str != "")
            if ($("#regexforrationaleforstudy").val() != "") {
                var expr = new RegExp($("#regexforrationaleforstudy").val());
                var str = $("#ui_txt_rationaleforstudy").val();
                if (str != "" && !expr.test(str)) {
                    $('#rationaleforstudy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforrationaleforstudy").val() + '</div>');
                    isvalidRegexforrationaleforstudy = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforrationaleforstudy = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_rationaleforstudy").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_rationaleforstudy").val().trim();
        if (str != "")
            if ($("#regexforrationaleforstudy").val() != "") {
                var expr = new RegExp($("#regexforrationaleforstudy").val());
                var str = $("#ui_txtarea_rationaleforstudy").val();
                if (str != "" && !expr.test(str)) {
                    $('#rationaleforstudy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforrationaleforstudy").val() + '</div>');
                    isvalidRegexforrationaleforstudy = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforrationaleforstudy = true;
                    return true;
                }
            }
    });
    $("#ui_txt_studydesign").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_studydesign").val().trim();
        if (str != "")
            if ($("#regexforstudydesign").val() != "") {
                var expr = new RegExp($("#regexforstudydesign").val());
                var str = $("#ui_txt_studydesign").val();
                if (str != "" && !expr.test(str)) {
                    $('#studydesign').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstudydesign").val() + '</div>');
                    isvalidRegexforstudydesign = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstudydesign = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_studydesign").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_studydesign").val().trim();
        if (str != "")
            if ($("#regexforstudydesign").val() != "") {
                var expr = new RegExp($("#regexforstudydesign").val());
                var str = $("#ui_txtarea_studydesign").val();
                if (str != "" && !expr.test(str)) {
                    $('#studydesign').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstudydesign").val() + '</div>');
                    isvalidRegexforstudydesign = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstudydesign = true;
                    return true;
                }
            }
    });
    $("#ui_txt_keyinclusioncriteria").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_keyinclusioncriteria").val().trim();
        if (str != "")
            if ($("#regexforkeyinclusioncriteria").val() != "") {
                var expr = new RegExp($("#regexforkeyinclusioncriteria").val());
                var str = $("#ui_txt_keyinclusioncriteria").val();
                if (str != "" && !expr.test(str)) {
                    $('#keyinclusioncriteria').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforkeyinclusioncriteria").val() + '</div>');
                    isvalidRegexforkeyinclusioncriteria = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforkeyinclusioncriteria = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_keyinclusioncriteria").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_keyinclusioncriteria").val().trim();
        if (str != "")
            if ($("#regexforkeyinclusioncriteria").val() != "") {
                var expr = new RegExp($("#regexforkeyinclusioncriteria").val());
                var str = $("#ui_txtarea_keyinclusioncriteria").val();
                if (str != "" && !expr.test(str)) {
                    $('#keyinclusioncriteria').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforkeyinclusioncriteria").val() + '</div>');
                    isvalidRegexforkeyinclusioncriteria = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforkeyinclusioncriteria = true;
                    return true;
                }
            }
    });
    $("#ui_txt_basisfosamplesize").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_basisfosamplesize").val().trim();
        if (str != "")
            if ($("#regexforbasisfosamplesize").val() != "") {
                var expr = new RegExp($("#regexforbasisfosamplesize").val());
                var str = $("#ui_txt_basisfosamplesize").val();
                if (str != "" && !expr.test(str)) {
                    $('#basisfosamplesize').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforbasisfosamplesize").val() + '</div>');
                    isvalidRegexforbasisfosamplesize = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforbasisfosamplesize = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_basisfosamplesize").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_basisfosamplesize").val().trim();
        if (str != "")
            if ($("#regexforbasisfosamplesize").val() != "") {
                var expr = new RegExp($("#regexforbasisfosamplesize").val());
                var str = $("#ui_txtarea_basisfosamplesize").val();
                if (str != "" && !expr.test(str)) {
                    $('#basisfosamplesize').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforbasisfosamplesize").val() + '</div>');
                    isvalidRegexforbasisfosamplesize = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforbasisfosamplesize = true;
                    return true;
                }
            }
    });
    $("#ui_txt_treatmentarmsapplyforthistrial").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_treatmentarmsapplyforthistrial").val().trim();
        if (str != "")
            if ($("#regexfortreatmentarmsapplyforthistrial").val() != "") {
                var expr = new RegExp($("#regexfortreatmentarmsapplyforthistrial").val());
                var str = $("#ui_txt_treatmentarmsapplyforthistrial").val();
                if (str != "" && !expr.test(str)) {
                    $('#treatmentarmsapplyforthistrial').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortreatmentarmsapplyforthistrial").val() + '</div>');
                    isvalidRegexfortreatmentarmsapplyforthistrial = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortreatmentarmsapplyforthistrial = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_treatmentarmsapplyforthistrial").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_treatmentarmsapplyforthistrial").val().trim();
        if (str != "")
            if ($("#regexfortreatmentarmsapplyforthistrial").val() != "") {
                var expr = new RegExp($("#regexfortreatmentarmsapplyforthistrial").val());
                var str = $("#ui_txtarea_treatmentarmsapplyforthistrial").val();
                if (str != "" && !expr.test(str)) {
                    $('#treatmentarmsapplyforthistrial').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortreatmentarmsapplyforthistrial").val() + '</div>');
                    isvalidRegexfortreatmentarmsapplyforthistrial = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortreatmentarmsapplyforthistrial = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_patientpopulation").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_patientpopulation").val().trim();
        if (str != "")
            if ($("#regexforpatientpopulation").val() != "") {
                var expr = new RegExp($("#regexforpatientpopulation").val());
                var str = $("#ui_txtarea_patientpopulation").val();
                if (str != "" && !expr.test(str)) {
                    $('#patientpopulation').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforpatientpopulation").val() + '</div>');
                    isvalidRegexforpatientpopulation = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforpatientpopulation = true;
                    return true;
                }
            }
    });
    $("#ui_txt_patientpopulation").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_patientpopulation").val().trim();
        if (str != "")
            if ($("#regexforpatientpopulation").val() != "") {
                var expr = new RegExp($("#regexforpatientpopulation").val());
                var str = $("#ui_txt_patientpopulation").val();
                if (str != "" && !expr.test(str)) {
                    $('#patientpopulation').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforpatientpopulation").val() + '</div>');
                    isvalidRegexforpatientpopulation = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforpatientpopulation = true;
                    return true;
                }
            }
    });
    //#endregion Science Main

    //#region Validate ScienceMain Fields 
    function ValidateScienceMainFields() {
        $(".error").remove();
        retval = true;
        objectScienceMain = new Object();
        objectScienceMain.StudyId = $('#StudyId').val();
        if ($('#displaytitleoftrial').is(':visible'))
            if (sessionStorage.getItem("ismandatetitleoftrial") == "true") {
                if ($('#ui_txt_titleOfTrial').is(':visible')) {
                    if ($('#ui_txt_titleOfTrial').val() == "") {
                        $('#titleoftrial').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_titleOfTrial').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_titleOfTrial').is(':visible')) {
                    if ($('#ui_txtarea_titleOfTrial').val() == "") {
                        $('#titleoftrial').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_titleOfTrial').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_titleOfTrial').is(':visible'))
                    objectScienceMain.TitleofTrial = $('#ui_txt_titleOfTrial').val().trim();
                if ($('#ui_txtarea_titleOfTrial').is(':visible'))
                    objectScienceMain.TitleofTrial = $('#ui_txtarea_titleOfTrial').val().trim();
            }
            else {
                if ($('#ui_txt_titleOfTrial').is(':visible'))
                    objectScienceMain.TitleofTrial = $('#ui_txt_titleOfTrial').val().trim();
                if ($('#ui_txtarea_titleOfTrial').is(':visible'))
                    objectScienceMain.TitleofTrial = $('#ui_txtarea_titleOfTrial').val().trim();
            }

        if ($('#displaystudydescriptors').is(':visible'))
            if (sessionStorage.getItem("ismandatemultistudydescriptors") == "true") {
                if ($('#ui_multistudydescriptors').data("kendoMultiSelect").value().length <= 0) {
                    $('#studydescriptors').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_multistudydescriptors').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_multistudydescriptors').val() == "")
                        objectScienceMain.Studydescriptors = null;
                    else
                        objectScienceMain.Studydescriptors = $('#ui_multistudydescriptors').val().toString();
                }

            }
            else {
                if ($('#ui_multistudydescriptors').val() == "")
                    objectScienceMain.Studydescriptors = null;
                else
                    objectScienceMain.Studydescriptors = $('#ui_multistudydescriptors').val().toString();
            }

        if ($('#displayinvestigationalDrugandReferenceTherapy').is(':visible'))
            if (sessionStorage.getItem("isviewinvestigationalDrugandReferenceTherapy") == "true") {
                if ($('#ui_txt_InvestigationalDrugandReferenceTherapy').is(':visible')) {
                    if ($('#ui_txt_InvestigationalDrugandReferenceTherapy').val() == "") {
                        $('#investigationalDrugandReferenceTherapy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_investigationalDrugandReferenceTherapy').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_InvestigationalDrugandReferenceTherapy').is(':visible')) {
                    if ($('#ui_txtarea_InvestigationalDrugandReferenceTherapy').val() == "") {
                        $('#investigationalDrugandReferenceTherapy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_investigationalDrugandReferenceTherapy').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_InvestigationalDrugandReferenceTherapy').is(':visible'))
                    objectScienceMain.InvestigationalDrugandReferenceTherapy = $('#ui_txt_InvestigationalDrugandReferenceTherapy').val().trim();
                if ($('#ui_txtarea_InvestigationalDrugandReferenceTherapy').is(':visible'))
                    objectScienceMain.InvestigationalDrugandReferenceTherapy = $('#ui_txtarea_InvestigationalDrugandReferenceTherapy').val().trim();
            }
            else {
                if ($('#ui_txt_InvestigationalDrugandReferenceTherapy').is(':visible'))
                    objectScienceMain.InvestigationalDrugandReferenceTherapy = $('#ui_txt_InvestigationalDrugandReferenceTherapy').val().trim();
                if ($('#ui_txtarea_InvestigationalDrugandReferenceTherapy').is(':visible'))
                    objectScienceMain.InvestigationalDrugandReferenceTherapy = $('#ui_txtarea_InvestigationalDrugandReferenceTherapy').val().trim();
            }

        if ($('#displayGender').is(':visible'))
            if (sessionStorage.getItem("ismultiselectGender") == "true") {
                if ($('#ui_multiselectGender').data("kendoMultiSelect").value().length <= 0) {
                    $('#Gender').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_multiselectGender').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_multiselectGender').val() == "")
                        objectScienceMain.Gender = null;
                    else
                        objectScienceMain.Gender = $('#ui_multiselectGender').val().toString();
                }
            }
            else {
                if ($('#ui_multiselectGender').val() == "")
                    objectScienceMain.Gender = null;
                else
                    objectScienceMain.Gender = $('#ui_multiselectGender').val().toString();
            }

        if ($('#displaymaxAge').is(':visible'))
            if (sessionStorage.getItem("ismaxAge") == "true") {
                if ($('#ui_ddl_maxAge').val() == "") {
                    $('#maxAge').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_maxAge').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_maxAge').val() == "")
                        objectScienceMain.MaximumAge = null;
                    else
                        objectScienceMain.MaximumAge = $('#ui_ddl_maxAge').val();
                }
            }
            else {
                if ($('#ui_ddl_maxAge').val() == "")
                    objectScienceMain.MaximumAge = null;
                else
                    objectScienceMain.MaximumAge = $('#ui_ddl_maxAge').val();
            }

        if ($('#displayexclusionCriteria').is(':visible'))
            if (sessionStorage.getItem("isexclusionCriteria") == "true") {
                if ($('#ui_txt_exclusioncriteria').is(':visible')) {
                    if ($('#ui_txt_exclusioncriteria').val() == "") {
                        $('#exclusioncriteria').after('<span class="error errorBackground"><div class="k-icon k-i-warning"></span>' + $('#ui_lbl_exclusioncriteria').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_exclusioncriteria').is(':visible')) {
                    if ($('#ui_txtarea_exclusioncriteria').val() == "") {
                        $('#exclusioncriteria').after('<span class="error errorBackground"><div class="k-icon k-i-warning"></span>' + $('#ui_lbl_exclusioncriteria').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_exclusioncriteria').is(':visible'))
                    objectScienceMain.KeyExclusionCriteria = $('#ui_txt_exclusioncriteria').val().trim();
                if ($('#ui_txtarea_exclusioncriteria').is(':visible'))
                    objectScienceMain.KeyExclusionCriteria = $('#ui_txtarea_exclusioncriteria').val().trim();
            }
            else {
                if ($('#ui_txt_exclusioncriteria').is(':visible'))
                    objectScienceMain.KeyExclusionCriteria = $('#ui_txt_exclusioncriteria').val().trim();
                if ($('#ui_txtarea_exclusioncriteria').is(':visible'))
                    objectScienceMain.KeyExclusionCriteria = $('#ui_txtarea_exclusioncriteria').val().trim();
            }

        if ($('#displayclinicalPharmacology').is(':visible'))
            if (sessionStorage.getItem("isclinicalPharmacology") == "true") {
                if ($('#ui_txt_clinicalPharmacology').is(':visible')) {
                    if ($('#ui_txt_clinicalPharmacology').val() == "") {
                        $('#clinicalPharmacology').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_clinicalPharmacology').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_clinicalPharmacology').is(':visible')) {
                    if ($('#ui_txtarea_clinicalPharmacology').val() == "") {
                        $('#clinicalPharmacology').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_clinicalPharmacology').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_clinicalPharmacology').is(':visible'))
                    objectScienceMain.ClinicalPharmacology = $('#ui_txt_clinicalPharmacology').val().trim();
                if ($('#ui_txtarea_clinicalPharmacology').is(':visible'))
                    objectScienceMain.ClinicalPharmacology = $('#ui_txtarea_clinicalPharmacology').val().trim();
            }
            else {
                if ($('#ui_txt_clinicalPharmacology').is(':visible'))
                    objectScienceMain.ClinicalPharmacology = $('#ui_txt_clinicalPharmacology').val().trim();
                if ($('#ui_txtarea_clinicalPharmacology').is(':visible'))
                    objectScienceMain.ClinicalPharmacology = $('#ui_txtarea_clinicalPharmacology').val().trim();
            }

        if ($('#displayinterventionstatus').is(':visible'))
            if (sessionStorage.getItem("isinterventionstatus") == "true") {
                if ($('#ui_ddl_interventionstatus').val() == "") {
                    $('#interventionstatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_interventionstatus').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_interventionstatus').val() == "")
                        objectScienceMain.StudyType = null;
                    else
                        objectScienceMain.StudyType = $('#ui_ddl_interventionstatus').val();
                }
            }
            else {
                if ($('#ui_ddl_interventionstatus').val() == "")
                    objectScienceMain.StudyType = null;
                else
                    objectScienceMain.StudyType = $('#ui_ddl_interventionstatus').val();
            }

        if ($('#displayIndicationforsciencemain').is(':visible'))
            if (sessionStorage.getItem("isindicationforsciencemain") == "true") {
                if ($('#ui_txt_indicationforsciencemain').is(':visible')) {
                    if ($('#ui_txt_indicationforsciencemain').val() == "") {
                        $('#indicationforsciencemain').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_indicationforsciencemain').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_indicationforsciencemain').is(':visible')) {
                    if ($('#ui_txtarea_indicationforsciencemain').val() == "") {
                        $('#indicationforsciencemain').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_indicationforsciencemain').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_indicationforsciencemain').is(':visible'))
                    objectScienceMain.Indicationforsciencemain = $('#ui_txt_indicationforsciencemain').val().trim();
                if ($('#ui_txtarea_indicationforsciencemain').is(':visible'))
                    objectScienceMain.Indicationforsciencemain = $('#ui_txtarea_indicationforsciencemain').val().trim();
            }
            else {
                if ($('#ui_txt_indicationforsciencemain').is(':visible'))
                    objectScienceMain.Indicationforsciencemain = $('#ui_txt_indicationforsciencemain').val().trim();
                if ($('#ui_txtarea_indicationforsciencemain').is(':visible'))
                    objectScienceMain.Indicationforsciencemain = $('#ui_txtarea_indicationforsciencemain').val().trim();
            }

        if ($('#displayplacebocontrolled').is(':visible'))
            if (sessionStorage.getItem("isplacebocontrolled") == "true") {
                if ($('#ui_ddl_placebocontrolled').val() == "") {
                    $('#placebocontrolled').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_placebocontrolled').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_placebocontrolled').val() == "@ConstDefaultValue.YES")
                        objectScienceMain.IsPlacebocontrolled = true;
                    if ($('#ui_ddl_placebocontrolled').val() == "@ConstDefaultValue.NO")
                        objectScienceMain.IsPlacebocontrolled = false;
                    if ($('#ui_ddl_placebocontrolled').val() == "")
                        objectScienceMain.IsPlacebocontrolled = null;
                }
            }
            else {
                if ($('#ui_ddl_placebocontrolled').val() == "@ConstDefaultValue.YES")
                    objectScienceMain.IsPlacebocontrolled = true;
                if ($('#ui_ddl_placebocontrolled').val() == "@ConstDefaultValue.NO")
                    objectScienceMain.IsPlacebocontrolled = false;
                if ($('#ui_ddl_placebocontrolled').val() == "")
                    objectScienceMain.IsPlacebocontrolled = null;
            }


        if ($('#displaypatientype').is(':visible'))
            if (sessionStorage.getItem("ismultiselectpatientype") == "true") {
                if ($('#ui_multiselectpatientype').data("kendoMultiSelect").value().length <= 0) {
                    $('#patientype').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_multiselectpatientype').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_multiselectpatientype').val() == "")
                        objectScienceMain.PatientType = null;
                    else
                        objectScienceMain.PatientType = $('#ui_multiselectGender').val().toString();
                }
            }
            else {
                if ($('#ui_multiselectpatientype').val() == "")
                    objectScienceMain.PatientType = null;
                else
                    objectScienceMain.PatientType = $('#ui_multiselectGender').val().toString();
            }

        if ($('#displaypatientpopulation').is(':visible'))
            if (sessionStorage.getItem("ispatientpopulation") == "true") {
                if ($('#ui_txt_patientpopulation').is(':visible')) {
                    if ($('#ui_txt_patientpopulation').val() == "") {
                        $('#patientpopulation').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_patientpopulation').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_patientpopulation').is(':visible')) {
                    if ($('#ui_txtarea_patientpopulation').val() == "") {
                        $('#patientpopulation').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_patientpopulation').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_patientpopulation').is(':visible'))
                    objectScienceMain.PatientPopulation = $('#ui_txt_patientpopulation').val().trim();
                if ($('#ui_txtarea_patientpopulation').is(':visible'))
                    objectScienceMain.PatientPopulation = $('#ui_txtarea_patientpopulation').val().trim();
            }
            else {
                if ($('#ui_txt_patientpopulation').is(':visible'))
                    objectScienceMain.PatientPopulation = $('#ui_txt_patientpopulation').val().trim();
                if ($('#ui_txtarea_patientpopulation').is(':visible'))
                    objectScienceMain.PatientPopulation = $('#ui_txtarea_patientpopulation').val().trim();
            }

        if ($('#displaysafetycriteria').is(':visible'))
            if (sessionStorage.getItem("issafetycriteria") == "true") {
                if ($('#ui_txt_safetycriteria').is(':visible')) {
                    if ($('#ui_txt_safetycriteria').val() == "") {
                        $('#safetycriteria').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_safetycriteria').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_safetycriteria').is(':visible')) {
                    if ($('#ui_txtarea_safetycriteria').val() == "") {
                        $('#safetycriteria').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_safetycriteria').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_safetycriteria').is(':visible'))
                    objectScienceMain.Safetycriteria = $('#ui_txt_safetycriteria').val().trim();
                if ($('#ui_txtarea_safetycriteria').is(':visible'))
                    objectScienceMain.Safetycriteria = $('#ui_txtarea_safetycriteria').val().trim();
            }
            else {
                if ($('#ui_txt_safetycriteria').is(':visible'))
                    objectScienceMain.Safetycriteria = $('#ui_txt_safetycriteria').val().trim();
                if ($('#ui_txtarea_safetycriteria').is(':visible'))
                    objectScienceMain.Safetycriteria = $('#ui_txtarea_safetycriteria').val().trim();
            }

        if ($('#displayothercompound').is(':visible'))
            if (sessionStorage.getItem("isothercompound") == "true") {
                if ($('#ui_txt_othercompound').is(':visible')) {
                    if ($('#ui_txt_othercompound').val() == "") {
                        $('#othercompound').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_othercompound').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_othercompound').is(':visible')) {
                    if ($('#ui_txtarea_othercompound').val() == "") {
                        $('#othercompound').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_othercompound').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_othercompound').is(':visible'))
                    objectScienceMain.Othercompanycompound = $('#ui_txt_othercompound').val().trim();
                if ($('#ui_txtarea_othercompound').is(':visible'))
                    objectScienceMain.Othercompanycompound = $('#ui_txtarea_othercompound').val().trim();
            }
            else {
                if ($('#ui_txt_othercompound').is(':visible'))
                    objectScienceMain.Othercompanycompound = $('#ui_txt_othercompound').val().trim();
                if ($('#ui_txtarea_othercompound').is(':visible'))
                    objectScienceMain.Othercompanycompound = $('#ui_txtarea_othercompound').val().trim();
            }

        if ($('#displayphases').is(':visible'))
            if (sessionStorage.getItem("isphases") == "true") {
                if (($('#PhaseI').prop("checked") == false) && ($('#PhaseII').prop("checked")) == false &&
                    ($('#PhaseIII').prop("checked") == false) && ($('#PhaseIV').prop("checked")) == false) {
                    $('#phases').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_phases').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    objectScienceMain.PhaseI = $('#PhaseI').prop("checked");
                    objectScienceMain.PhaseII = $('#PhaseII').prop("checked");
                    objectScienceMain.PhaseIII = $('#PhaseIII').prop("checked");
                    objectScienceMain.PhaseIV = $('#PhaseIV').prop("checked");
                }
            }
            else {
                objectScienceMain.PhaseI = $('#PhaseI').prop("checked");
                objectScienceMain.PhaseII = $('#PhaseII').prop("checked");
                objectScienceMain.PhaseIII = $('#PhaseIII').prop("checked");
                objectScienceMain.PhaseIV = $('#PhaseIV').prop("checked");
            }

        if ($('#displayrationaleforstudy').is(':visible'))
            if (sessionStorage.getItem("isrationaleforstudy") == "true") {
                if ($('#ui_txt_rationaleforstudy').is(':visible')) {
                    if ($('#ui_txt_rationaleforstudy').val() == "") {
                        $('#rationaleforstudy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_rationaleforstudy').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_rationaleforstudy').is(':visible')) {
                    if ($('#ui_txtarea_rationaleforstudy').val() == "") {
                        $('#rationaleforstudy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_rationaleforstudy').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_rationaleforstudy').is(':visible'))
                    objectScienceMain.Rationaleforstudy = $('#ui_txt_rationaleforstudy').val().trim();
                if ($('#ui_txtarea_rationaleforstudy').is(':visible'))
                    objectScienceMain.Rationaleforstudy = $('#ui_txtarea_rationaleforstudy').val().trim();
            }
            else {
                if ($('#ui_txt_rationaleforstudy').is(':visible'))
                    objectScienceMain.Rationaleforstudy = $('#ui_txt_rationaleforstudy').val().trim();
                if ($('#ui_txtarea_rationaleforstudy').is(':visible'))
                    objectScienceMain.Rationaleforstudy = $('#ui_txtarea_rationaleforstudy').val().trim();
            }

        if ($('#displaystudydesign').is(':visible'))
            if (sessionStorage.getItem("isstudydesign") == "true") {
                if ($('#ui_txt_studydesign').is(':visible')) {
                    if ($('#ui_txt_studydesign').val() == "") {
                        $('#studydesign').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_studydesign').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_studydesign').is(':visible')) {
                    if ($('#ui_txtarea_studydesign').val() == "") {
                        $('#studydesign').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_studydesign').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_studydesign').is(':visible'))
                    objectScienceMain.Studydesign = $('#ui_txt_studydesign').val().trim();
                if ($('#ui_txtarea_studydesign').is(':visible'))
                    objectScienceMain.Studydesign = $('#ui_txtarea_studydesign').val().trim();
            }
            else {
                if ($('#ui_txt_studydesign').is(':visible'))
                    objectScienceMain.Studydesign = $('#ui_txt_studydesign').val().trim();
                if ($('#ui_txtarea_studydesign').is(':visible'))
                    objectScienceMain.Studydesign = $('#ui_txtarea_studydesign').val().trim();
            }

        if ($('#displayminAge').is(':visible'))
            if (sessionStorage.getItem("isminage") == "true") {
                if ($('#ui_ddl_minAge').val() == "") {
                    $('#minAge').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_minAge').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_minAge').val() == "")
                        objectScienceMain.MinimumAge = null;
                    else
                        objectScienceMain.MinimumAge = $('#ui_ddl_minAge').val();
                }
            }
            else {
                if ($('#ui_ddl_minAge').val() == "")
                    objectScienceMain.MinimumAge = null;
                else
                    objectScienceMain.MinimumAge = $('#ui_ddl_minAge').val();
            }

        if ($('#displaykeyinclusioncriteria').is(':visible'))
            if (sessionStorage.getItem("isinclusioncriteria") == "true") {
                if ($('#ui_txt_keyinclusioncriteria').is(':visible')) {
                    if ($('#ui_txt_keyinclusioncriteria').val() == "") {
                        $('#keyinclusioncriteria').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_keyinclusioncriteria').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_keyinclusioncriteria').is(':visible')) {
                    if ($('#ui_txtarea_keyinclusioncriteria').val() == "") {
                        $('#keyinclusioncriteria').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_keyinclusioncriteria').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_keyinclusioncriteria').is(':visible'))
                    objectScienceMain.KeyInclusionCriteria = $('#ui_txt_keyinclusioncriteria').val().trim();
                if ($('#ui_txtarea_keyinclusioncriteria').is(':visible'))
                    objectScienceMain.KeyInclusionCriteria = $('#ui_txtarea_keyinclusioncriteria').val().trim();
            }
            else {
                if ($('#ui_txt_keyinclusioncriteria').is(':visible'))
                    objectScienceMain.KeyInclusionCriteria = $('#ui_txt_keyinclusioncriteria').val().trim();
                if ($('#ui_txtarea_keyinclusioncriteria').is(':visible'))
                    objectScienceMain.KeyInclusionCriteria = $('#ui_txtarea_keyinclusioncriteria').val().trim();
            }

        if ($('#displaybasisfosamplesize').is(':visible'))
            if (sessionStorage.getItem("isbasisforsamplesize") == "true") {
                if ($('#ui_txt_basisfosamplesize').is(':visible')) {
                    if ($('#ui_txt_basisfosamplesize').val() == "") {
                        $('#basisfosamplesize').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_basisforsamplesize').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_basisfosamplesize').is(':visible')) {
                    if ($('#ui_txtarea_basisfosamplesize').val() == "") {
                        $('#basisfosamplesize').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_basisforsamplesize').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_basisfosamplesize').is(':visible'))
                    objectScienceMain.Basisforsamplesize = $('#ui_txt_basisfosamplesize').val().trim();
                if ($('#ui_txtarea_basisfosamplesize').is(':visible'))
                    objectScienceMain.Basisforsamplesize = $('#ui_txtarea_basisfosamplesize').val().trim();
            }
            else {
                if ($('#ui_txt_basisfosamplesize').is(':visible'))
                    objectScienceMain.Basisforsamplesize = $('#ui_txt_basisfosamplesize').val().trim();
                if ($('#ui_txtarea_basisfosamplesize').is(':visible'))
                    objectScienceMain.Basisforsamplesize = $('#ui_txtarea_basisfosamplesize').val().trim();
            }

        if ($('#displaytreatmentarmsapplyforthistrial').is(':visible'))
            if (sessionStorage.getItem("istreatmentarmsapplyforthistrial") == "true") {
                if ($('#ui_txt_treatmentarmsapplyforthistrial').is(':visible')) {
                    if ($('#ui_txt_treatmentarmsapplyforthistrial').val() == "") {
                        $('#treatmentarmsapplyforthistrial').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_treatmentarmsapplyforthistrial').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_treatmentarmsapplyforthistrial').is(':visible')) {
                    if ($('#ui_txtarea_treatmentarmsapplyforthistrial').val() == "") {
                        $('#treatmentarmsapplyforthistrial').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_treatmentarmsapplyforthistrial').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_treatmentarmsapplyforthistrial').is(':visible'))
                    objectScienceMain.Treatmentarms = $('#ui_txt_treatmentarmsapplyforthistrial').val().trim();
                if ($('#ui_txtarea_treatmentarmsapplyforthistrial').is(':visible'))
                    objectScienceMain.Treatmentarms = $('#ui_txtarea_treatmentarmsapplyforthistrial').val().trim();
            }
            else {
                if ($('#ui_txt_treatmentarmsapplyforthistrial').is(':visible'))
                    objectScienceMain.Treatmentarms = $('#ui_txt_treatmentarmsapplyforthistrial').val().trim();
                if ($('#ui_txtarea_treatmentarmsapplyforthistrial').is(':visible'))
                    objectScienceMain.Treatmentarms = $('#ui_txtarea_treatmentarmsapplyforthistrial').val().trim();
            }
    }

    //#endregion Validate

    //#region Remove err msg on key up for non grid text fields
    $("#titleoftrial,#investigationalDrugandReferenceTherapy,#exclusioncriteria,#clinicalPharmacology, \
          #indicationforsciencemain,#patientpopulation,#safetycriteria,#othercompound,#studydesign, \
          #basisfosamplesize,#treatmentarmsapplyforthistrial").on("keyup", function (e) {
        $(this).next("div.error").remove();
    })

    $('#studydescriptors,#Gender,#maxAge,#interventionstatus,#placebocontrolled,#patientype,#minAge, \
           #keyinclusioncriteria').change(function () {
        $(this).next("div.error").remove();
    }).change();
    //#endregion

    $("#ui_btnSaveScienceMain").click(function (e) {
        ValidateScienceMainFields();
        if (validator.validate() && retval === true && isvalidRegexfortitleOfTrial === true && isvalidRegexforinvestigationalDrugandReferenceTherapy === true
            && isvalidRegexforexclusioncriteria === true && isvalidRegexforclinicalPharmacology === true
            && isvalidRegexforindication === true && isvalidRegexforsafetycriteria === true
            && isvalidRegexforothercompound === true && isvalidRegexforrationaleforstudy === true
            && isvalidRegexforstudydesign === true && isvalidRegexforkeyinclusioncriteria === true
            && isvalidRegexforbasisfosamplesize === true && isvalidRegexfortreatmentarmsapplyforthistrial === true
            && isvalidRegexforpatientpopulation === true)
            Savedetails(type = 1, objEditstudy = objectScienceMain);
        else
            popupNotification.show("There are errors on the page.Please correct them to continue.", "error");
        return false;
    });

    $("#sciencemain").on("click", function () {
        $('#sciencemaincontents').show();
        LoadScienceMainAttributeValues();
        LoadScienceMainData();
    });
});

$(document).ready(function () {
    
    $('#ui_multistudydescriptors').kendoMultiSelect({
        dataTextField: "Code",
        dataValueField: "CodeId",
        optionLabel: 'Select',
        autoClose: false,
        dataSource: {
            transport: {
                read: {
                    dataType: "json",
                    url: urlstudydescriptors
                }
            }
        }
    });
    
    $('#ui_multiselectpatientype').kendoMultiSelect({
        dataTextField: "Code",
        dataValueField: "CodeId",
        optionLabel: 'Select',
        autoClose: false,
        dataSource: {
            transport: {
                read: {
                    dataType: "json",
                    url: urlmultiselectpatienttype
                }
            }
        }
    });

    $('#ui_multiselectGender').kendoMultiSelect({
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
    
   

});

function LoadScienceMainAttributeValues() {
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
                        case studytitle:
                            Textdetails(response, "displaytitleoftrial", "ui_lbl_titleOfTrial", "ui_img_helpTextfortitleOfTrial", "ismandatetitleoftrial", "ui_txt_titleOfTrial", "ui_txtarea_titleOfTrial", "ui_lbl_charsleftfortitleOfTrial", "regexexprfortitleOfTrial", "validationmsgfortitleOfTrial")
                            break;
                        case studydescriptors:
                            DropDowndetails(response, "displaystudydescriptors", "ui_lbl_multistudydescriptors", "ui_img_helpTextformultistudydescriptors", "ismandatemultistudydescriptors");
                            break;
                        case investigationaldrugandreferencetherapy:
                            Textdetails(response, "displayinvestigationalDrugandReferenceTherapy", "ui_lbl_investigationalDrugandReferenceTherapy", "ui_img_helpTextforinvestigationalDrugandReferenceTherapy", "isviewinvestigationalDrugandReferenceTherapy", "ui_txt_InvestigationalDrugandReferenceTherapy", "ui_txtarea_InvestigationalDrugandReferenceTherapy", "ui_lbl_charsleftforInvestigationalDrugandReferenceTherapy", "regexexprforinvestigationalDrugandReferenceTherapy", "validationmsgforinvestigationalDrugandReferenceTherapy")
                            break;
                        case gender:
                            DropDowndetails(response, "displayGender", "ui_lbl_multiselectGender", "ui_img_multiselectGender", "ismultiselectGender");
                            break;
                        case exclusioncriteria:
                            Textdetails(response, "displayexclusionCriteria", "ui_lbl_exclusionCriteria", "ui_img_exclusionCriteria", "isexclusionCriteria", "ui_txt_exclusioncriteria", "ui_txtarea_exclusioncriteria", "ui_lbl_charsleftforexclusioncriteria", "regexforexclusionCriteria", "validationmsgforexclusionCriteria")
                            break;
                        case maximumage:
                            DropDowndetails(response, "displaymaxAge", "ui_lbl_maxAge", "ui_img_maxAge", "ismaxAge");
                            break;
                        case clinicalpharmacology:
                            Textdetails(response, "displayclinicalPharmacology", "ui_lbl_clinicalPharmacology", "ui_img_clinicalPharmacology", "isclinicalPharmacology", "ui_txt_clinicalPharmacology", "ui_txtarea_clinicalPharmacology", "ui_lbl_charsleftforexclusioncriteria", "regexforclinicalPharmacology", "validationmsgforclinicalPharmacology");
                            break;
                        case interventionstatus:
                            DropDowndetails(response, "displayinterventionstatus", "ui_lbl_interventionstatus", "ui_img_interventionstatus", "isinterventionstatus");
                            break;
                        case indicationforsciencemain:
                            Textdetails(response, "displayIndicationforsciencemain", "ui_lbl_indicationforsciencemain", "ui_img_indicationforsciencemain", "isindicationforsciencemain", "ui_txt_indicationforsciencemain", "ui_txtarea_indicationforsciencemain", "ui_lbl_charsleftforindicationforsciencemain", "regexforindicationforsciencemain", "validationmsgforindicationforsciencemain");
                            break;
                        case patienttype:
                            DropDowndetails(response, "displaypatientype", "ui_lbl_multiselectpatientype", "ui_img_multiselectpatientype", "ismultiselectpatientype");
                            break;
                        case patientpopulation:
                            Textdetails(response, "displaypatientpopulation", "ui_lbl_patientpopulation", "ui_img_patientpopulation", "ispatientpopulation", "ui_txt_patientpopulation", "ui_txtarea_patientpopulation", "ui_lbl_charsleftforpatientpopulation", "regexforpatientpopulation", "validationmsgforpatientpopulation");
                            break;
                        case safetycriteria:
                            Textdetails(response, "displaysafetycriteria", "ui_lbl_safetycriteria", "ui_img_safetycriteria", "issafetycriteria", "ui_txt_safetycriteria", "ui_txtarea_safetycriteria", "ui_lbl_charsleftforsafetycriteria", "regexforsafetycriteria", "validationmsgforsafetycriteria");
                            break;
                        case othercompound:
                            Textdetails(response, "displayothercompound", "ui_lbl_othercompound", "ui_img_othercompound", "isothercompound", "ui_txt_othercompound", "ui_txtarea_othercompound", "ui_lbl_charsleftforothercompound", "regexforothercompound", "validationmsgforothercompound");
                            break;
                        case studyphase:
                            DropDowndetails(response, "displayphases", "ui_lbl_phases", "ui_img_phases", "isphases");
                            break;
                        case phasei:
                            $("#ui_lbl_phasei").html(response[i].Name);
                            break;
                        case phaseii:
                            $("#ui_lbl_phaseii").html(response[i].Name);
                            break;
                        case phaseiii:
                            $("#ui_lbl_phaseiii").html(response[i].Name);
                            break;
                        case phaseiv:
                            $("#ui_lbl_phaseiv").html(response[i].Name);
                            break;
                        case rationaleforstudy:
                            Textdetails(response, "displayrationaleforstudy", "ui_lbl_rationaleforstudy", "ui_img_rationaleforstudy", "isrationaleforstudy", "ui_txt_rationaleforstudy", "ui_txtarea_rationaleforstudy", "ui_lbl_charsleftforrationaleforstudy", "regexforrationaleforstudy", "validationmsgforrationaleforstudy");
                            break;
                        case studydesign:
                            Textdetails(response, "displaystudydesign", "ui_lbl_studydesign", "ui_img_studydesign", "isstudydesign", "ui_txt_studydesign", "ui_txtarea_studydesign", "ui_lbl_charsleftforstudydesign", "regexforstudydesign", "validationmsgforstudydesign");
                            break;
                        case minimumage:
                            DropDowndetails(response, "displayminAge", "ui_lbl_minAge", "ui_img_minAge", "isminage");
                            break;
                        case inclusioncriteria:
                            Textdetails(response, "displaykeyinclusioncriteria", "ui_lbl_keyinclusioncriteria", "ui_img_keyinclusioncriteria", "isinclusioncriteria", "ui_txt_keyinclusioncriteria", "ui_txtarea_keyinclusioncriteria", "ui_lbl_charsleftforkeyinclusioncriteria", "regexforkeyinclusioncriteria", "validationmsgforkeyinclusioncriteria");
                            break;
                        case basisforsamplesize:
                            Textdetails(response, "displaybasisfosamplesize", "ui_lbl_basisforsamplesize", "ui_img_basisforsamplesize", "isbasisforsamplesize", "ui_txt_basisfosamplesize", "ui_txtarea_basisfosamplesize", "ui_lbl_charsleftforbasisfosamplesize", "regexforbasisfosamplesize", "validationmsgforbasisfosamplesize");
                            break;
                        case treatmentarmsapplyforthistrial:
                            Textdetails(response, "displaytreatmentarmsapplyforthistrial", "ui_lbl_treatmentarmsapplyforthistrial", "ui_img_treatmentarmsapplyforthistrial", "istreatmentarmsapplyforthistrial", "ui_txt_treatmentarmsapplyforthistrial", "ui_txtarea_treatmentarmsapplyforthistrial", "ui_lbl_charsleftfortreatmentarmsapplyforthistrial", "regexfortreatmentarmsapplyforthistrial", "validationmsgfortreatmentarmsapplyforthistrial");
                            break;
                        case placebocontrolled:
                            DropDowndetails(response, "displayplacebocontrolled", "ui_lbl_placebocontrolled", "ui_img_placebocontrolled", "isplacebocontrolled");
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

function LoadScienceMainData() {
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/GetScienceMainData/",
        cache: false,
        dataType: "json",
        data: { "StudyId": $('#StudyId').val() },
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
            } else {
                $("#ui_txt_titleOfTrial,#ui_txtarea_titleOfTrial").val(response.Data[0].TitleofTrial);
                $("#ui_ddl_interventionstatus").data('kendoDropDownList').value(response.Data[0].StudyType);
                if (response.Data[0].StudyType == "Interventional") {
                    $("#TrialPhaseId").val(response.Data[0].TrialPhaseId);
                    if (response.Data[0].PhaseI == true)
                        $("#PhaseI").prop('checked', true);
                    if (response.Data[0].PhaseII == true)
                        $("#PhaseII").prop('checked', true);
                    if (response.Data[0].PhaseIII == true)
                        $("#PhaseIII").prop('checked', true);
                    if (response.Data[0].PhaseIV == true)
                        $("#PhaseIV").prop('checked', true);
                }
                if (response.Data[0].Studydescriptors !== null) {
                    var studydescriptors = response.Data[0].Studydescriptors.split(',');
                    $('#ui_multistudydescriptors').getKendoMultiSelect().value(studydescriptors);
                }
                $("#ui_txt_InvestigationalDrugandReferenceTherapy,#ui_txtarea_InvestigationalDrugandReferenceTherapy").val(response.Data[0].InvestigationalDrugandReferenceTherapy);
                if (response.Data[0].Gender !== null) {
                    var gender = response.Data[0].Gender.split(',');
                    $('#ui_multiselectGender').getKendoMultiSelect().value(gender);
                }
                $("#ui_ddl_maxAge").data('kendoDropDownList').value(response.Data[0].MaximumAge);
                $("#ui_txt_exclusioncriteria,#ui_txtarea_exclusioncriteria").val(response.Data[0].KeyExclusionCriteria);
                $("#ui_txt_clinicalPharmacology,#ui_txtarea_clinicalPharmacology").val(response.Data[0].ClinicalPharmacology);
                $("#ui_ddl_interventionstatus").data('kendoDropDownList').value(response.Data[0].StudyType);
                $("#ui_txt_indicationforsciencemain,#ui_txtarea_indicationforsciencemain").val(response.Data[0].Indicationforsciencemain);
                if (response.Data[0].IsPlacebocontrolled == true)
                    $("#ui_ddl_placebocontrolled").data('kendoDropDownList').value(yes);
                if (response.Data[0].IsPlacebocontrolled == false)
                    $("#ui_ddl_placebocontrolled").data('kendoDropDownList').value(no);
                if (response.Data[0].IsPlacebocontrolled == null)
                    $("#ui_ddl_placebocontrolled").data('kendoDropDownList').value("Select");
                if (response.Data[0].PatientType !== null) {
                    var patienttype = response.Data[0].PatientType.split(',');
                    $('#ui_multiselectpatientype').getKendoMultiSelect().value(patienttype);
                }
                $("#ui_txt_patientpopulation,#ui_txtarea_patientpopulation").val(response.Data[0].PatientPopulation);
                $("#ui_txt_safetycriteria,#ui_txtarea_safetycriteria").val(response.Data[0].Safetycriteria);
                $("#ui_txt_othercompound,#ui_txtarea_othercompound").val(response.Data[0].Othercompanycompound);
                $("#ui_txt_rationaleforstudy,#ui_txtarea_rationaleforstudy").val(response.Data[0].Rationaleforstudy);
                $("#ui_txt_studydesign,#ui_txtarea_studydesign").val(response.Data[0].Studydesign);
                $("#ui_ddl_minAge").data('kendoDropDownList').value(response.Data[0].MinimumAge);
                $("#ui_txt_keyinclusioncriteria,#ui_txtarea_keyinclusioncriteria").val(response.Data[0].KeyInclusionCriteria);
                $("#ui_txt_basisfosamplesize,#ui_txtarea_basisfosamplesize").val(response.Data[0].Basisforsamplesize);
                $("#ui_txt_treatmentarmsapplyforthistrial,#ui_txtarea_treatmentarmsapplyforthistrial").val(response.Data[0].Treatmentarms);
            }
        },
        failure: function (response) {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });
}

function CheckcharacterLength() {
    $("textarea[maxlength]").keyup(function () {
        var charLength = $(this).val().length;
        var charLimit = $(this).attr("maxlength");
        $(this).nextAll("span.count").html(charLimit - charLength + " Characters left to enter");
    });
    $("input[maxlength]").keyup(function () {
        var charLength = $(this).val().length;
        var charLimit = $(this).attr("maxlength");
        $(this).nextAll("span.count").html(charLimit - charLength + " Characters left to enter");
    });
}