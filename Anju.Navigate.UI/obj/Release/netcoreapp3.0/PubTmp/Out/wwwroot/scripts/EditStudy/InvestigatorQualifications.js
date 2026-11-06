$(function () {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");

    //#region Investigator Qualifications
    $("#ui_txt_medicalspecialty").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_medicalspecialty").val().trim();
        if (str != "")
            if ($("#regexexprformedicalspecialty").val() != "") {
                var expr = new RegExp($("#regexexprformedicalspecialty").val());
                var str = $("#ui_txt_medicalspecialty").val();
                if (str != "" && !expr.test(str)) {
                    $('#medicalspecialty').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgformedicalspecialty").val() + '</div>');
                    isvalidRegexformedicalspecialty = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexformedicalspecialty = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_medicalspecialty").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_medicalspecialty").val().trim();
        if (str != "")
            if ($("#regexexprformedicalspecialty").val() != "") {
                var expr = new RegExp($("#regexexprformedicalspecialty").val());
                var str = $("#ui_txtarea_medicalspecialty").val();
                if (str != "" && !expr.test(str)) {
                    $('#medicalspecialty').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgformedicalspecialty").val() + '</div>');
                    isvalidRegexformedicalspecialty = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexformedicalspecialty = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_boardcertification").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_boardcertification").val().trim();
        if (str != "")
            if ($("#regexexprforboardcertification").val() != "") {
                var expr = new RegExp($("#regexexprforboardcertification").val());
                var str = $("#ui_txtarea_boardcertification").val();
                if (str != "" && !expr.test(str)) {
                    $('#boardCertification').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforboardcertification").val() + '</div>');
                    isvalidRegexforboardCertification = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforboardCertification = true;
                    return true;
                }
            }
    });
    $("#ui_txt_boardcertification").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_boardcertification").val().trim();
        if (str != "")
            if ($("#regexexprforboardcertification").val() != "") {
                var expr = new RegExp($("#regexexprforboardcertification").val());
                var str = $("#ui_txt_boardcertification").val();
                if (str != "" && !expr.test(str)) {
                    $('#boardCertification').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforboardcertification").val() + '</div>');
                    isvalidRegexforboardCertification = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforboardCertification = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_licenseorequivalent").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_licenseorequivalent").val().trim();
        if (str != "")
            if ($("#regexexprforlicenseorequivalent").val() != "") {
                var expr = new RegExp($("#regexexprforlicenseorequivalent").val());
                var str = $("#ui_txtarea_licenseorequivalent").val();
                if (str != "" && !expr.test(str)) {
                    $('#licenseorEquivalent').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforlicenseorequivalent").val() + '</div>');
                    isvalidRegexforlicenseorequivalent = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforlicenseorequivalent = true;
                    return true;
                }
            }
    });
    $("#ui_txt_licenseorequivalent").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_licenseorequivalent").val().trim();
        if (str != "")
            if ($("#regexexprforlicenseorequivalent").val() != "") {
                var expr = new RegExp($("#regexexprforlicenseorequivalent").val());
                var str = $("#ui_txt_licenseorequivalent").val();
                if (str != "" && !expr.test(str)) {
                    $('#licenseorEquivalent').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforlicenseorequivalent").val() + '</div>');
                    isvalidRegexforlicenseorequivalent = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforlicenseorequivalent = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_whenwasyourlastGCPtraining").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_whenwasyourlastGCPtraining").val().trim();
        if (str != "")
            if ($("#regexexprforwhenwasyourlastGCPtraining").val() != "") {
                var expr = new RegExp($("#regexexprforwhenwasyourlastGCPtraining").val());
                var str = $("#ui_txtarea_whenwasyourlastGCPtraining").val();
                if (str != "" && !expr.test(str)) {
                    $('#whenwasyourlastGCPtraining').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforwhenwasyourlastGCPtraining").val() + '</div>');
                    isvalidRegexforwhenwasyourlastGCPtraining = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforwhenwasyourlastGCPtraining = true;
                    return true;
                }
            }
    });
    $("#ui_txt_whenwasyourlastGCPtraining").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_whenwasyourlastGCPtraining").val().trim();
        if (str != "")
            if ($("#regexexprforwhenwasyourlastGCPtraining").val() != "") {
                var expr = new RegExp($("#regexexprforwhenwasyourlastGCPtraining").val());
                var str = $("#ui_txt_whenwasyourlastGCPtraining").val();
                if (str != "" && !expr.test(str)) {
                    $('#whenwasyourlastGCPtraining').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforwhenwasyourlastGCPtraining").val() + '</div>');
                    isvalidRegexforwhenwasyourlastGCPtraining = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforwhenwasyourlastGCPtraining = true;
                    return true;
                }
            }
    });
    $("#ui_txt_typeoftrainingreceived").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_typeoftrainingreceived").val().trim();
        if (str != "")
            if ($("#regexexprfortypeoftrainingreceived").val() != "") {
                var expr = new RegExp($("#regexexprfortypeoftrainingreceived").val());
                var str = $("#ui_txt_typeoftrainingreceived").val();
                if (str != "" && !expr.test(str)) {
                    $('#typeoftrainingreceived').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortypeoftrainingreceived").val() + '</div>');
                    isvalidRegexfortypeoftrainingreceived = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortypeoftrainingreceived = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_typeoftrainingreceived").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_typeoftrainingreceived").val().trim();
        if (str != "")
            if ($("#regexexprfortypeoftrainingreceived").val() != "") {
                var expr = new RegExp($("#regexexprfortypeoftrainingreceived").val());
                var str = $("#ui_txtarea_typeoftrainingreceived").val();
                if (str != "" && !expr.test(str)) {
                    $('#typeoftrainingreceived').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortypeoftrainingreceived").val() + '</div>');
                    isvalidRegexfortypeoftrainingreceived = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortypeoftrainingreceived = true;
                    return true;
                }
            }
    });
    $("#ui_txt_listtrialexperience").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_listtrialexperience").val().trim();
        if (str != "")
            if ($("#regexexprforlisttrialexperience").val() != "") {
                var expr = new RegExp($("#regexexprforlisttrialexperience").val());
                var str = $("#ui_txt_listtrialexperience").val();
                if (str != "" && !expr.test(str)) {
                    $('#listtrialexperience').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforlisttrialexperience").val() + '</div>');
                    isvalidRegexforlisttrialexperience = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforlisttrialexperience = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_listtrialexperience").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_listtrialexperience").val().trim();
        if (str != "")
            if ($("#regexexprforlisttrialexperience").val() != "") {
                var expr = new RegExp($("#regexexprforlisttrialexperience").val());
                var str = $("#ui_txtarea_listtrialexperience").val();
                if (str != "" && !expr.test(str)) {
                    $('#listtrialexperience').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforlisttrialexperience").val() + '</div>');
                    isvalidRegexforlisttrialexperience = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforlisttrialexperience = true;
                    return true;
                }
            }
    });
    $("#ui_txt_datesoftrialparticipation").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_datesoftrialparticipation").val().trim();
        if (str != "")
            if ($("#regexexprfordatesoftrialparticipation").val() != "") {
                var expr = new RegExp($("#regexexprfordatesoftrialparticipation").val());
                var str = $("#ui_txt_datesoftrialparticipation").val();
                if (str != "" && !expr.test(str)) {
                    $('#datesoftrialparticipation').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordatesoftrialparticipation").val() + '</div>');
                    isvalidRegexfordatesoftrialparticipation = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordatesoftrialparticipation = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_datesoftrialparticipation").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_datesoftrialparticipation").val().trim();
        if (str != "")
            if ($("#regexexprfordatesoftrialparticipation").val() != "") {
                var expr = new RegExp($("#regexexprfordatesoftrialparticipation").val());
                var str = $("#ui_txtarea_datesoftrialparticipation").val();
                if (str != "" && !expr.test(str)) {
                    $('#datesoftrialparticipation').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordatesoftrialparticipation").val() + '</div>');
                    isvalidRegexfordatesoftrialparticipation = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordatesoftrialparticipation = true;
                    return true;
                }
            }
    });
    $("#ui_txt_drugnames").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_drugnames").val().trim();
        if (str != "")
            if ($("#regexexprfordrugnames").val() != "") {
                var expr = new RegExp($("#regexexprfordrugnames").val());
                var str = $("#ui_txt_drugnames").val();
                if (str != "" && !expr.test(str)) {
                    $('#drugnames').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordrugnames").val() + '</div>');
                    isvalidRegexfordrugnames = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordrugnames = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_drugnames").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_drugnames").val().trim();
        if (str != "")
            if ($("#regexexprfordrugnames").val() != "") {
                var expr = new RegExp($("#regexexprfordrugnames").val());
                var str = $("#ui_txtarea_drugnames").val();
                if (str != "" && !expr.test(str)) {
                    $('#drugnames').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordrugnames").val() + '</div>');
                    isvalidRegexfordrugnames = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordrugnames = true;
                    return true;
                }
            }
    });
    $("#ui_txt_protocolnumbers").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_protocolnumbers").val().trim();
        if (str != "")
            if ($("#regexexprforprotocolnumbers").val() != "") {
                var expr = new RegExp($("#regexexprforprotocolnumbers").val());
                var str = $("#ui_txt_protocolnumbers").val();
                if (str != "" && !expr.test(str)) {
                    $('#protocolnumbers').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforprotocolnumbers").val() + '</div>');
                    isvalidRegexforprotocolnumbers = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforprotocolnumbers = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_protocolnumbers").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_protocolnumbers").val().trim();
        if (str != "")
            if ($("#regexexprforprotocolnumbers").val() != "") {
                var expr = new RegExp($("#regexexprforprotocolnumbers").val());
                var str = $("#ui_txtarea_protocolnumbers").val();
                if (str != "" && !expr.test(str)) {
                    $('#protocolnumbers').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforprotocolnumbers").val() + '</div>');
                    isvalidRegexforprotocolnumbers = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforprotocolnumbers = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_numberofongoingclinicaltrials").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_numberofongoingclinicaltrials").val().trim();
        if (str != "")
            if ($("#regexexprfornumberofongoingclinicaltrials").val() != "") {
                var expr = new RegExp($("#regexexprfornumberofongoingclinicaltrials").val());
                var str = $("#ui_txtarea_numberofongoingclinicaltrials").val();
                if (str != "" && !expr.test(str)) {
                    $('#numberofongoingclinicaltrials').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfornumberofongoingclinicaltrials").val() + '</div>');
                    isvalidRegexfornumberofongoingclinicaltrials = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfornumberofongoingclinicaltrials = true;
                    return true;
                }
            }
    });
    $("#ui_txt_numberofongoingclinicaltrials").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_numberofongoingclinicaltrials").val().trim();
        if (str != "")
            if ($("#regexexprfornumberofongoingclinicaltrials").val() != "") {
                var expr = new RegExp($("#regexexprfornumberofongoingclinicaltrials").val());
                var str = $("#ui_txt_numberofongoingclinicaltrials").val();
                if (str != "" && !expr.test(str)) {
                    $('#numberofongoingclinicaltrials').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfornumberofongoingclinicaltrials").val() + '</div>');
                    isvalidRegexfornumberofongoingclinicaltrials = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfornumberofongoingclinicaltrials = true;
                    return true;
                }
            }
    });
    $("#ui_txt_whichhealthauthority").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_whichhealthauthority").val().trim();
        if (str != "")
            if ($("#regexexprforwhichhealthauthority").val() != "") {
                var expr = new RegExp($("#regexexprforwhichhealthauthority").val());
                var str = $("#ui_txt_whichhealthauthority").val();
                if (str != "" && !expr.test(str)) {
                    $('#whichhealthauthority').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforwhichhealthauthority").val() + '</div>');
                    isvalidRegexforwhichhealthauthority = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforwhichhealthauthority = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_whichhealthauthority").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_whichhealthauthority").val().trim();
        if (str != "")
            if ($("#regexexprforwhichhealthauthority").val() != "") {
                var expr = new RegExp($("#regexexprforwhichhealthauthority").val());
                var str = $("#ui_txtarea_whichhealthauthority").val();
                if (str != "" && !expr.test(str)) {
                    $('#whichhealthauthority').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforwhichhealthauthority").val() + '</div>');
                    isvalidRegexforwhichhealthauthority = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforwhichhealthauthority = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_detailsofthemainobservations").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_detailsofthemainobservations").val().trim();
        if (str != "")
            if ($("#regexexprfordetailsofthemainobservations").val() != "") {
                var expr = new RegExp($("#regexexprfordetailsofthemainobservations").val());
                var str = $("#ui_txtarea_detailsofthemainobservations").val();
                if (str != "" && !expr.test(str)) {
                    $('#detailsofthemainobservations').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordetailsofthemainobservations").val() + '</div>');
                    isvalidRegexfordetailsofthemainobservations = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordetailsofthemainobservations = true;
                    return true;
                }
            }
    });
    $("#ui_txt_detailsofthemainobservations").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_detailsofthemainobservations").val().trim();
        if (str != "")
            if ($("#regexexprfordetailsofthemainobservations").val() != "") {
                var expr = new RegExp($("#regexexprfordetailsofthemainobservations").val());
                var str = $("#ui_txt_detailsofthemainobservations").val();
                if (str != "" && !expr.test(str)) {
                    $('#detailsofthemainobservations').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordetailsofthemainobservations").val() + '</div>');
                    isvalidRegexfordetailsofthemainobservations = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordetailsofthemainobservations = true;
                    return true;
                }
            }
    });
    //#endregion Investigator Qualifications        

    function ValidateInvestigatorQualificationsFields() {
        $(".error").remove();
        retval = true;
        objInvestigatorQualifications = new Object();
        objInvestigatorQualifications.StudyId = $('#StudyId').val();

        if ($('#displayMedicalSpecialty').is(':visible'))
            if (sessionStorage.getItem("ismedicalspecialty") == "true") {
                if ($('#ui_txt_medicalspecialty').is(':visible')) {
                    if ($('#ui_txt_medicalspecialty').val() == "") {
                        $('#medicalspecialty').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_medicalspecialty').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_medicalspecialty').is(':visible')) {
                    if ($('#ui_txtarea_medicalspecialty').val() == "") {
                        $('#medicalspecialty').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_medicalspecialty').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_medicalspecialty').is(':visible'))
                    objInvestigatorQualifications.MedicalSpecialty = $('#ui_txt_medicalspecialty').val().trim();
                if ($('#ui_txtarea_medicalspecialty').is(':visible'))
                    objInvestigatorQualifications.MedicalSpecialty = $('#ui_txtarea_medicalspecialty').val().trim();
            }
            else {
                if ($('#ui_txt_medicalspecialty').is(':visible'))
                    objInvestigatorQualifications.MedicalSpecialty = $('#ui_txt_medicalspecialty').val().trim();
                if ($('#ui_txtarea_medicalspecialty').is(':visible'))
                    objInvestigatorQualifications.MedicalSpecialty = $('#ui_txtarea_medicalspecialty').val().trim();
            }

        if ($('#displayBoardCertification').is(':visible'))
            if (sessionStorage.getItem("isboardcertification") == "true") {
                if ($('#ui_txt_boardcertification').is(':visible')) {
                    if ($('#ui_txt_boardcertification').val() == "") {
                        $('#boardCertification').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_boardcertification').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_boardcertification').is(':visible')) {
                    if ($('#ui_txtarea_boardcertification').val() == "") {
                        $('#boardCertification').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_boardcertification').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_boardcertification').is(':visible'))
                    objInvestigatorQualifications.BoardCertification = $('#ui_txt_boardcertification').val().trim();
                if ($('#ui_txtarea_boardcertification').is(':visible'))
                    objInvestigatorQualifications.BoardCertification = $('#ui_txtarea_boardcertification').val().trim();
            }
            else {
                if ($('#ui_txt_boardcertification').is(':visible'))
                    objInvestigatorQualifications.BoardCertification = $('#ui_txt_boardcertification').val().trim();
                if ($('#ui_txtarea_boardcertification').is(':visible'))
                    objInvestigatorQualifications.BoardCertification = $('#ui_txtarea_boardcertification').val().trim();
            }

        if ($('#displayLicenseorEquivalent').is(':visible'))
            if (sessionStorage.getItem("islicenseorequivalent") == "true") {
                if ($('#ui_txt_licenseorequivalent').is(':visible')) {
                    if ($('#ui_txt_licenseorequivalent').val() == "") {
                        $('#licenseorEquivalent').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_licenseorequivalent').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_licenseorequivalent').is(':visible')) {
                    if ($('#ui_txtarea_licenseorequivalent').val() == "") {
                        $('#licenseorEquivalent').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_licenseorequivalent').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_licenseorequivalent').is(':visible'))
                    objInvestigatorQualifications.MedicalLicense = $('#ui_txt_licenseorequivalent').val().trim();
                if ($('#ui_txtarea_licenseorequivalent').is(':visible'))
                    objInvestigatorQualifications.MedicalLicense = $('#ui_txtarea_licenseorequivalent').val().trim();
            }
            else {
                if ($('#ui_txt_licenseorequivalent').is(':visible'))
                    objInvestigatorQualifications.MedicalLicense = $('#ui_txt_licenseorequivalent').val().trim();
                if ($('#ui_txtarea_licenseorequivalent').is(':visible'))
                    objInvestigatorQualifications.MedicalLicense = $('#ui_txtarea_licenseorequivalent').val().trim();
            }

        if ($('#displayisreceivedGCPtraining').is(':visible'))
            if (sessionStorage.getItem("isreceivedGCPtraining") == "true") {
                if ($('#ui_ddl_isreceivedGCPtraining').val() == "") {
                    $('#isreceivedGCPtraining').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_isreceivedGCPtraining').html() + ' is required</span>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_isreceivedGCPtraining').val() == yes)
                        objInvestigatorQualifications.IsOtherTrainingsReceived = true;
                    if ($('#ui_ddl_isreceivedGCPtraining').val() == no)
                        objInvestigatorQualifications.IsOtherTrainingsReceived = false;
                    if ($('#ui_ddl_isreceivedGCPtraining').val() == "")
                        objInvestigatorQualifications.IsOtherTrainingsReceived = null;
                }
            }
            else {
                if ($('#ui_ddl_isreceivedGCPtraining').val() == yes)
                    objInvestigatorQualifications.IsOtherTrainingsReceived = true;
                if ($('#ui_ddl_isreceivedGCPtraining').val() == no)
                    objInvestigatorQualifications.IsOtherTrainingsReceived = false;
                if ($('#ui_ddl_isreceivedGCPtraining').val() == "")
                    objInvestigatorQualifications.IsOtherTrainingsReceived = null;
            }

        if ($('#displayWhenwasyourlastGCPtraining').is(':visible'))
            if (sessionStorage.getItem("islastGCPtraining") == "true") {
                if ($('#ui_txt_whenwasyourlastGCPtraining').is(':visible')) {
                    if ($('#ui_txt_whenwasyourlastGCPtraining').val() == "") {
                        $('#whenwasyourlastGCPtraining').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_whenwasyourlastGCPtraining').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_whenwasyourlastGCPtraining').is(':visible')) {
                    if ($('#ui_txtarea_whenwasyourlastGCPtraining').val() == "") {
                        $('#whenwasyourlastGCPtraining').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_whenwasyourlastGCPtraining').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_whenwasyourlastGCPtraining').is(':visible'))
                    objInvestigatorQualifications.LastTrainingDetails = $('#ui_txt_whenwasyourlastGCPtraining').val().trim();
                if ($('#ui_txtarea_whenwasyourlastGCPtraining').is(':visible'))
                    objInvestigatorQualifications.LastTrainingDetails = $('#ui_txtarea_whenwasyourlastGCPtraining').val().trim();
            }
            else {
                if ($('#ui_txt_whenwasyourlastGCPtraining').is(':visible'))
                    objInvestigatorQualifications.LastTrainingDetails = $('#ui_txt_whenwasyourlastGCPtraining').val().trim();
                if ($('#ui_txtarea_whenwasyourlastGCPtraining').is(':visible'))
                    objInvestigatorQualifications.LastTrainingDetails = $('#ui_txtarea_whenwasyourlastGCPtraining').val().trim();
            }

        if ($('#displayTypeoftrainingreceived').is(':visible'))
            if (sessionStorage.getItem("istypeoftrainingreceived") == "true") {
                if ($('#ui_txt_typeoftrainingreceived').is(':visible')) {
                    if ($('#ui_txt_typeoftrainingreceived').val() == "") {
                        $('#typeoftrainingreceived').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_typeoftrainingreceived').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_typeoftrainingreceived').is(':visible')) {
                    if ($('#ui_txtarea_typeoftrainingreceived').val() == "") {
                        $('#typeoftrainingreceived').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_typeoftrainingreceived').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_typeoftrainingreceived').is(':visible'))
                    objInvestigatorQualifications.TypeOfTraining = $('#ui_txt_typeoftrainingreceived').val().trim();
                if ($('#ui_txtarea_typeoftrainingreceived').is(':visible'))
                    objInvestigatorQualifications.TypeOfTraining = $('#ui_txtarea_typeoftrainingreceived').val().trim();
            }
            else {
                if ($('#ui_txt_typeoftrainingreceived').is(':visible'))
                    objInvestigatorQualifications.TypeOfTraining = $('#ui_txt_typeoftrainingreceived').val().trim();
                if ($('#ui_txtarea_typeoftrainingreceived').is(':visible'))
                    objInvestigatorQualifications.TypeOfTraining = $('#ui_txtarea_typeoftrainingreceived').val().trim();
            }

        if ($('#displayListtrialexperience').is(':visible'))
            if (sessionStorage.getItem("islisttrialexperience") == "true") {
                if ($('#ui_txt_listtrialexperience').is(':visible')) {
                    if ($('#ui_txt_listtrialexperience').val() == "") {
                        $('#listtrialexperience').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_listtrialexperience').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_listtrialexperience').is(':visible')) {
                    if ($('#ui_txtarea_listtrialexperience').val() == "") {
                        $('#listtrialexperience').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_listtrialexperience').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_listtrialexperience').is(':visible'))
                    objInvestigatorQualifications.TrialExperiences = $('#ui_txt_listtrialexperience').val().trim();
                if ($('#ui_txtarea_listtrialexperience').is(':visible'))
                    objInvestigatorQualifications.TrialExperiences = $('#ui_txtarea_listtrialexperience').val().trim();
            }
            else {
                if ($('#ui_txt_listtrialexperience').is(':visible'))
                    objInvestigatorQualifications.TrialExperiences = $('#ui_txt_listtrialexperience').val().trim();
                if ($('#ui_txtarea_listtrialexperience').is(':visible'))
                    objInvestigatorQualifications.TrialExperiences = $('#ui_txtarea_listtrialexperience').val().trim();
            }

        if ($('#displayisparticipatedinacompanytrial').is(':visible'))
            if (sessionStorage.getItem("isparticipatedinacompanytrial") == "true") {
                if ($('#ui_ddl_isparticipatedinacompanytrial').val() == "") {
                    $('#isparticipatedinacompanytrial').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_isparticipatedinacompanytrial').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_isparticipatedinacompanytrial').val() == yes)
                        objInvestigatorQualifications.IsCompanySponsoredtrial = true;
                    if ($('#ui_ddl_isparticipatedinacompanytrial').val() == no)
                        objInvestigatorQualifications.IsCompanySponsoredtrial = false;
                    if ($('#ui_ddl_isparticipatedinacompanytrial').val() == "")
                        objInvestigatorQualifications.IsCompanySponsoredtrial = null;
                }
            }
            else {
                if ($('#ui_ddl_isparticipatedinacompanytrial').val() == yes)
                    objInvestigatorQualifications.IsCompanySponsoredtrial = true;
                if ($('#ui_ddl_isparticipatedinacompanytrial').val() == no)
                    objInvestigatorQualifications.IsCompanySponsoredtrial = false;
                if ($('#ui_ddl_isparticipatedinacompanytrial').val() == "")
                    objInvestigatorQualifications.IsCompanySponsoredtrial = null;
            }

        if ($('#displayDatesoftrialparticipation').is(':visible'))
            if (sessionStorage.getItem("isdatesoftrialparticipation") == "true") {
                if ($('#ui_txt_datesoftrialparticipation').is(':visible')) {
                    if ($('#ui_txt_datesoftrialparticipation').val() == "") {
                        $('#datesoftrialparticipation').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_datesoftrialparticipation').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_datesoftrialparticipation').is(':visible')) {
                    if ($('#ui_txtarea_datesoftrialparticipation').val() == "") {
                        $('#datesoftrialparticipation').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_datesoftrialparticipation').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_datesoftrialparticipation').is(':visible'))
                    objInvestigatorQualifications.TrialParticipation = $('#ui_txt_datesoftrialparticipation').val().trim();
                if ($('#ui_txtarea_datesoftrialparticipation').is(':visible'))
                    objInvestigatorQualifications.TrialParticipation = $('#ui_txtarea_datesoftrialparticipation').val().trim();
            }
            else {
                if ($('#ui_txt_datesoftrialparticipation').is(':visible'))
                    objInvestigatorQualifications.TrialParticipation = $('#ui_txt_datesoftrialparticipation').val().trim();
                if ($('#ui_txtarea_datesoftrialparticipation').is(':visible'))
                    objInvestigatorQualifications.TrialParticipation = $('#ui_txtarea_datesoftrialparticipation').val().trim();
            }

        if ($('#displayDrugnames').is(':visible'))
            if (sessionStorage.getItem("isdrugnames") == "true") {
                if ($('#ui_txt_drugnames').is(':visible')) {
                    if ($('#ui_txt_drugnames').val() == "") {
                        $('#drugnames').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_drugnames').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_drugnames').is(':visible')) {
                    if ($('#ui_txtarea_drugnames').val() == "") {
                        $('#drugnames').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_drugnames').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_drugnames').is(':visible'))
                    objInvestigatorQualifications.DrugName = $('#ui_txt_drugnames').val().trim();
                if ($('#ui_txtarea_drugnames').is(':visible'))
                    objInvestigatorQualifications.DrugName = $('#ui_txtarea_drugnames').val().trim();
            }
            else {
                if ($('#ui_txt_drugnames').is(':visible'))
                    objInvestigatorQualifications.DrugName = $('#ui_txt_drugnames').val().trim();
                if ($('#ui_txtarea_drugnames').is(':visible'))
                    objInvestigatorQualifications.DrugName = $('#ui_txtarea_drugnames').val().trim();
            }

        if ($('#displayProtocolnumbers').is(':visible'))
            if (sessionStorage.getItem("isprotocolnumbers") == "true") {
                if ($('#ui_txt_protocolnumbers').is(':visible')) {
                    if ($('#ui_txt_protocolnumbers').val() == "") {
                        $('#protocolnumbers').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_protocolnumbers').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_protocolnumbers').is(':visible')) {
                    if ($('#ui_txtarea_protocolnumbers').val() == "") {
                        $('#protocolnumbers').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_protocolnumbers').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_protocolnumbers').is(':visible'))
                    objInvestigatorQualifications.ProtocolNumber = $('#ui_txt_protocolnumbers').val().trim();
                if ($('#ui_txtarea_protocolnumbers').is(':visible'))
                    objInvestigatorQualifications.ProtocolNumber = $('#ui_txtarea_protocolnumbers').val().trim();
            }
            else {
                if ($('#ui_txt_protocolnumbers').is(':visible'))
                    objInvestigatorQualifications.ProtocolNumber = $('#ui_txt_protocolnumbers').val().trim();
                if ($('#ui_txtarea_protocolnumbers').is(':visible'))
                    objInvestigatorQualifications.ProtocolNumber = $('#ui_txtarea_protocolnumbers').val().trim();
            }

        if ($('#displayNumberofongoingclinicaltrials').is(':visible'))
            if (sessionStorage.getItem("isnumberofongoingclinicaltrials") == "true") {
                if ($('#ui_txt_numberofongoingclinicaltrials').is(':visible')) {
                    if ($('#ui_txt_numberofongoingclinicaltrials').val() == "") {
                        $('#numberofongoingclinicaltrials').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_numberofongoingclinicaltrials').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_numberofongoingclinicaltrials').is(':visible')) {
                    if ($('#ui_txtarea_numberofongoingclinicaltrials').val() == "") {
                        $('#numberofongoingclinicaltrials').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_numberofongoingclinicaltrials').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_numberofongoingclinicaltrials').is(':visible'))
                    objInvestigatorQualifications.NumberOfOngoingTrials = $('#ui_txt_numberofongoingclinicaltrials').val().trim();
                if ($('#ui_txtarea_numberofongoingclinicaltrials').is(':visible'))
                    objInvestigatorQualifications.NumberOfOngoingTrials = $('#ui_txtarea_numberofongoingclinicaltrials').val().trim();
            }
            else {
                if ($('#ui_txt_numberofongoingclinicaltrials').is(':visible'))
                    objInvestigatorQualifications.NumberOfOngoingTrials = $('#ui_txt_numberofongoingclinicaltrials').val().trim();
                if ($('#ui_txtarea_numberofongoingclinicaltrials').is(':visible'))
                    objInvestigatorQualifications.NumberOfOngoingTrials = $('#ui_txtarea_numberofongoingclinicaltrials').val().trim();
            }

        if ($('#displayisinspectedbyahealthauthority').is(':visible'))
            if (sessionStorage.getItem("isinspectedbyahealthauthority") == "true") {
                if ($('#ui_ddl_isinspectedbyahealthauthority').val() == "") {
                    $('#isinspectedbyahealthauthority').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_isinspectedbyahealthauthority').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_isinspectedbyahealthauthority').val() == yes)
                        objInvestigatorQualifications.IsSiteInspectedByHealthAuthority = true;
                    if ($('#ui_ddl_isinspectedbyahealthauthority').val() == no)
                        objInvestigatorQualifications.IsSiteInspectedByHealthAuthority = false;
                    if ($('#ui_ddl_isinspectedbyahealthauthority').val() == "")
                        objInvestigatorQualifications.IsSiteInspectedByHealthAuthority = null;
                }
            }
            else {
                if ($('#ui_ddl_isinspectedbyahealthauthority').val() == yes)
                    objInvestigatorQualifications.IsSiteInspectedByHealthAuthority = true;
                if ($('#ui_ddl_isinspectedbyahealthauthority').val() == no)
                    objInvestigatorQualifications.IsSiteInspectedByHealthAuthority = false;
                if ($('#ui_ddl_isinspectedbyahealthauthority').val() == "")
                    objInvestigatorQualifications.IsSiteInspectedByHealthAuthority = null;
            }

        if ($('#displayWhichhealthauthority').is(':visible'))
            if (sessionStorage.getItem("iswhichhealthauthority") == "true") {
                if ($('#ui_txt_whichhealthauthority').is(':visible')) {
                    if ($('#ui_txt_whichhealthauthority').val() == "") {
                        $('#whichhealthauthority').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_whichhealthauthority').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_whichhealthauthority').is(':visible')) {
                    if ($('#ui_txtarea_whichhealthauthority').val() == "") {
                        $('#whichhealthauthority').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_whichhealthauthority').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_whichhealthauthority').is(':visible'))
                    objInvestigatorQualifications.NameOfHealthAuthority = $('#ui_txt_whichhealthauthority').val().trim();
                if ($('#ui_txtarea_whichhealthauthority').is(':visible'))
                    objInvestigatorQualifications.NameOfHealthAuthority = $('#ui_txtarea_whichhealthauthority').val().trim();
            }
            else {
                if ($('#ui_txt_whichhealthauthority').is(':visible'))
                    objInvestigatorQualifications.NameOfHealthAuthority = $('#ui_txt_whichhealthauthority').val().trim();
                if ($('#ui_txtarea_whichhealthauthority').is(':visible'))
                    objInvestigatorQualifications.NameOfHealthAuthority = $('#ui_txtarea_whichhealthauthority').val().trim();
            }

        if ($('#displayDetailsofthemainobservations').is(':visible'))
            if (sessionStorage.getItem("isdetailsofthemainobservations") == "true") {
                if ($('#ui_txt_detailsofthemainobservations').is(':visible')) {
                    if ($('#ui_txt_detailsofthemainobservations').val() == "") {
                        $('#detailsofthemainobservations').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_detailsofthemainobservations').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_detailsofthemainobservations').is(':visible')) {
                    if ($('#ui_txtarea_detailsofthemainobservations').val() == "") {
                        $('#detailsofthemainobservations').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_detailsofthemainobservations').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_detailsofthemainobservations').is(':visible'))
                    objInvestigatorQualifications.DetailsOfObservation = $('#ui_txt_detailsofthemainobservations').val().trim();
                if ($('#ui_txtarea_detailsofthemainobservations').is(':visible'))
                    objInvestigatorQualifications.DetailsOfObservation = $('#ui_txtarea_detailsofthemainobservations').val().trim();
            }
            else {
                if ($('#ui_txt_whichhealthauthority').is(':visible'))
                    objInvestigatorQualifications.DetailsOfObservation = $('#ui_txt_whichhealthauthority').val().trim();
                if ($('#ui_txtarea_whichhealthauthority').is(':visible'))
                    objInvestigatorQualifications.DetailsOfObservation = $('#ui_txtarea_whichhealthauthority').val().trim();
            }

        if ($('#displayDateoflastinspection').is(':visible'))
            if (sessionStorage.getItem("isdateoflastinspection") == "true") {
                if ($('#ui_dt_dateoflastinspection').val() == "") {
                    $('#dateoflastinspection').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_dateoflastinspection').html() + ' is required</div>');
                    retval = false;
                }
                else
                    objInvestigatorQualifications.DateOflastInspection = $('#ui_dt_dateoflastinspection').val();
            }
            else
                objInvestigatorQualifications.DateOflastInspection = $('#ui_dt_dateoflastinspection').val();

        if ($('#displayIsinspectedbytheFDA').is(':visible'))
            if (sessionStorage.getItem("isinspectedbytheFDA") == "true") {
                if ($('#ui_ddl_isinspectedbytheFDA').val() == "") {
                    $('#isinspectedbytheFDA').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_isinspectedbytheFDA').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_isinspectedbytheFDA').val() == yes)
                        objInvestigatorQualifications.IsSiteInspectedByFda = true;
                    if ($('#ui_ddl_isinspectedbytheFDA').val() == no)
                        objInvestigatorQualifications.IsSiteInspectedByFda = false;
                    if ($('#ui_ddl_isinspectedbytheFDA').val() == "")
                        objInvestigatorQualifications.IsSiteInspectedByFda = null;
                }
            }
            else {
                if ($('#ui_ddl_isinspectedbytheFDA').val() == yes)
                    objInvestigatorQualifications.IsSiteInspectedByFda = true;
                if ($('#ui_ddl_isinspectedbytheFDA').val() == no)
                    objInvestigatorQualifications.IsSiteInspectedByFda = false;
                if ($('#ui_ddl_isinspectedbytheFDA').val() == "")
                    objInvestigatorQualifications.IsSiteInspectedByFda = null;
            }

        if ($('#displayDateofFDAinspection').is(':visible'))
            if (sessionStorage.getItem("isdateofFDAinspection") == "true") {
                if ($('#ui_dt_dateofFDAinspection').val() == "") {
                    $('#dateofFDAinspection').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_dateofFDAinspection').html() + ' is required</div>');
                    retval = false;
                }
                else
                    objInvestigatorQualifications.DateOfFdainspection = $('#ui_dt_dateofFDAinspection').val();
            }
            else
                objInvestigatorQualifications.DateOfFdainspection = $('#ui_dt_dateofFDAinspection').val();

        if ($('#displayIsFDAissuedaFDA483form').is(':visible'))
            if (sessionStorage.getItem("isFDAissuedaFDA483form") == "true") {
                if ($('#ui_ddl_isFDAissuedaFDA483form').val() == "") {
                    $('#isFDAissuedaFDA483form').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_isFDAissuedaFDA483form').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_isFDAissuedaFDA483form').val() == yes)
                        objInvestigatorQualifications.Isfda483formIssued = true;
                    if ($('#ui_ddl_isFDAissuedaFDA483form').val() == no)
                        objInvestigatorQualifications.Isfda483formIssued = false;
                    if ($('#ui_ddl_isFDAissuedaFDA483form').val() == "")
                        objInvestigatorQualifications.Isfda483formIssued = null;
                }
            }
            else {
                if ($('#ui_ddl_isFDAissuedaFDA483form').val() == yes)
                    objInvestigatorQualifications.Isfda483formIssued = true;
                if ($('#ui_ddl_isFDAissuedaFDA483form').val() == no)
                    objInvestigatorQualifications.Isfda483formIssued = false;
                if ($('#ui_ddl_isFDAissuedaFDA483form').val() == "")
                    objInvestigatorQualifications.Isfda483formIssued = null;
            }
    }

    //#region Remove err msg on key up for non grid text fields
    $("#medicalspecialty,#boardCertification,#licenseorEquivalent,#whenwasyourlastGCPtraining, \
           #typeoftrainingreceived,#listtrialexperience,#datesoftrialparticipation,#drugnames, \
           #protocolnumbers,#numberofongoingclinicaltrials,#whichhealthauthority,#dateoflastinspection, \
           #dateofFDAinspection,#detailsofthemainobservations").on("keyup", function (e) {
        $(this).next("div.error").remove();
    })

    $('#isreceivedGCPtraining,#isparticipatedinacompanytrial,#isinspectedbyahealthauthority').change(function () {
        $(this).next("div.error").remove();
    }).change();
    //#endregion

    $("#ui_btnSaveInvestigatorQualifications").click(function (e) {
        ValidateInvestigatorQualificationsFields();
        if (validator.validate() && retval === true && isvalidRegexformedicalspecialty === true
            && isvalidRegexforboardCertification === true && isvalidRegexforlicenseorequivalent
            && isvalidRegexforwhenwasyourlastGCPtraining === true && isvalidRegexfortypeoftrainingreceived === true
            && isvalidRegexforlisttrialexperience === true && isvalidRegexfordatesoftrialparticipation === true
            && isvalidRegexfordrugnames === true && isvalidRegexforprotocolnumbers === true
            && isvalidRegexfornumberofongoingclinicaltrials === true && isvalidRegexforwhichhealthauthority === true
            && isvalidRegexfordetailsofthemainobservations === true)
            Savedetails(type = 13, objEditstudy = objInvestigatorQualifications);
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    });

    $("#investigatorqualifications").on("click", function () {
        $('#investigatorqualificationsdetails').show();
        LoadInvestigatorQualificationsAttributes();
        LoadInvestigatorQualificationsData();
    });

    function LoadInvestigatorQualificationsAttributes() {
        $.ajax({
            async: true,
            type: "POST",
            url: "/NewStudy/GetAttributeValues/",
            cache: false,
            dataType: "json",
            success: function (response) {
                if (response.Data == '') {
                    popupNotification.show(errorsinthepage, "error");
                } else {
                    for (i = 0; i < response.length; i++) {
                        //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                        switch (response[i].FieldType) {
                            case medicalspecialty:
                                Textdetails(response, "displayMedicalSpecialty", "ui_lbl_medicalspecialty", "ui_img_helpTextformedicalspecialty", "ismedicalspecialty", "ui_txt_medicalspecialty", "ui_txtarea_medicalspecialty", "ui_lbl_charsleftformedicalspecialty", "regexexprformedicalspecialty", "validationmsgformedicalspecialty");
                                break;
                            case boardcertification:
                                Textdetails(response, "displayBoardCertification", "ui_lbl_boardcertification", "ui_img_helpTextforboardcertification", "isboardcertification", "ui_txt_boardcertification", "ui_txtarea_boardcertification", "ui_lbl_charsleftforboardcertification", "regexexprforboardcertification", "validationmsgforboardcertification");
                                break;
                            case licenseorequivalent:
                                Textdetails(response, "displayLicenseorEquivalent", "ui_lbl_licenseorequivalent", "ui_img_helpTextforlicenseorequivalent", "islicenseorequivalent", "ui_txt_licenseorequivalent", "ui_txtarea_licenseorequivalent", "ui_lbl_charsleftforlicenseorequivalent", "regexexprforlicenseorequivalent", "validationmsgforlicenseorequivalent");
                                break;
                            case isreceivedgcptrainingthepast3years:
                                DropDowndetails(response, "displayisreceivedGCPtraining", "ui_lbl_isreceivedGCPtraining", "ui_img_helpTextforreceivedGCPtraining", "isreceivedGCPtraining");
                                break;
                            case lastgcptraining:
                                Textdetails(response, "displayWhenwasyourlastGCPtraining", "ui_lbl_whenwasyourlastGCPtraining", "ui_img_helpTextforwhenwasyourlastGCPtraining", "islastGCPtraining", "ui_txt_whenwasyourlastGCPtraining", "ui_txtarea_whenwasyourlastGCPtraining", "ui_lbl_charsleftforwhenwasyourlastGCPtraining", "regexexprforwhenwasyourlastGCPtraining", "validationmsgforwhenwasyourlastGCPtraining");
                                break;
                            case typeoftrainingreceived:
                                Textdetails(response, "displayTypeoftrainingreceived", "ui_lbl_typeoftrainingreceived", "ui_img_helpTextfortypeoftrainingreceived", "istypeoftrainingreceived", "ui_txt_typeoftrainingreceived", "ui_txtarea_typeoftrainingreceived", "ui_lbl_charsleftfortypeoftrainingreceived", "regexexprfortypeoftrainingreceived", "validationmsgfortypeoftrainingreceived");
                                break;
                            case listtrialexperience:
                                Textdetails(response, "displayListtrialexperience", "ui_lbl_listtrialexperience", "ui_img_helpTextforlisttrialexperience", "islisttrialexperience", "ui_txt_listtrialexperience", "ui_txtarea_listtrialexperience", "ui_lbl_charsleftforlisttrialexperience", "regexexprforlisttrialexperience", "validationmsgforlisttrialexperience");
                                break;
                            case isparticipatedinacompanytrial:
                                DropDowndetails(response, "displayisparticipatedinacompanytrial", "ui_lbl_isparticipatedinacompanytrial", "ui_img_helpTextforisparticipatedinacompanytrial", "isparticipatedinacompanytrial");
                                break;
                            case datesoftrialparticipation:
                                Textdetails(response, "displayDatesoftrialparticipation", "ui_lbl_datesoftrialparticipation", "ui_img_helpTextfordatesoftrialparticipation", "isdatesoftrialparticipation", "ui_txt_datesoftrialparticipation", "ui_txtarea_datesoftrialparticipation", "ui_lbl_charsleftfordatesoftrialparticipation", "regexexprfordatesoftrialparticipation", "validationmsgfordatesoftrialparticipation");
                                break;
                            case drugnames:
                                Textdetails(response, "displayDrugnames", "ui_lbl_drugnames", "ui_img_helpTextfordrugnames", "isdrugnames", "ui_txt_drugnames", "ui_txtarea_drugnames", "ui_lbl_charsleftfordrugnames", "regexexprfordrugnames", "validationmsgfordrugnames");
                                break;
                            case protocolnumbers:
                                Textdetails(response, "displayProtocolnumbers", "ui_lbl_protocolnumbers", "ui_img_helpTextforprotocolnumbers", "isprotocolnumbers", "ui_txt_protocolnumbers", "ui_txtarea_protocolnumbers", "ui_lbl_charsleftforprotocolnumbers", "regexexprforprotocolnumbers", "validationmsgforprotocolnumbers");
                                break;
                            case noofongoingclinicaltrials:
                                Textdetails(response, "displayNumberofongoingclinicaltrials", "ui_lbl_numberofongoingclinicaltrials", "ui_img_helpTextfornumberofongoingclinicaltrials", "isnumberofongoingclinicaltrials", "ui_txt_numberofongoingclinicaltrials", "ui_txtarea_numberofongoingclinicaltrials", "ui_lbl_charsleftfornumberofongoingclinicaltrials", "regexexprfornumberofongoingclinicaltrials", "validationmsgfornumberofongoingclinicaltrials");
                                break;
                            case isinspectedbyahealthauthority:
                                DropDowndetails(response, "displayisinspectedbyahealthauthority", "ui_lbl_isinspectedbyahealthauthority", "ui_img_helpTextforisinspectedbyahealthauthority", "isinspectedbyahealthauthority");
                                break;
                            case whichhealthauthority:
                                Textdetails(response, "displayWhichhealthauthority", "ui_lbl_whichhealthauthority", "ui_img_helpTextforwhichhealthauthority", "iswhichhealthauthority", "ui_txt_whichhealthauthority", "ui_txtarea_whichhealthauthority", "ui_lbl_charsleftforwhichhealthauthority", "regexexprforwhichhealthauthority", "validationmsgforwhichhealthauthority");
                                break;
                            case dateoflastinspection:
                                DropDowndetails(response, "displayDateoflastinspection", "ui_lbl_dateoflastinspection", "ui_img_helpTextfordateoflastinspection", "isdateoflastinspection");
                                break;
                            case isinspectedbythefda:
                                DropDowndetails(response, "displayIsinspectedbytheFDA", "ui_lbl_isinspectedbytheFDA", "ui_img_isinspectedbytheFDA", "isinspectedbytheFDA");
                                break;
                            case dateoffdainspection:
                                DropDowndetails(response, "displayDateofFDAinspection", "ui_lbl_dateofFDAinspection", "ui_img_helpTextfordateofFDAinspection", "isdateofFDAinspection");
                                break;
                            case isfdaissueafda483form:
                                DropDowndetails(response, "displayIsFDAissuedaFDA483form", "ui_lbl_isFDAissuedaFDA483form", "ui_img_isFDAissuedaFDA483form", "isFDAissuedaFDA483form");
                                break;
                            case detailsofthemainobservations:
                                Textdetails(response, "displayDetailsofthemainobservations", "ui_lbl_detailsofthemainobservations", "ui_img_helpTextfordetailsofthemainobservations", "isdetailsofthemainobservations", "ui_txt_detailsofthemainobservations", "ui_txtarea_detailsofthemainobservations", "ui_lbl_charsleftfordetailsofthemainobservations", "regexexprfordetailsofthemainobservations", "validationmsgfordetailsofthemainobservations");
                                break;
                            default:
                                break;
                        }
                    }
                }
            },
            failure: function (response) {
                popupNotification.show(errorsinthepage, "error");
            }
        });
    }

    function LoadInvestigatorQualificationsData() {
        $.ajax({
            async: true,
            type: "POST",
            url: "/NewStudy/GetInvestigatorQualificationsData/",
            cache: false,
            dataType: "json",
            data: { "StudyId": $('#StudyId').val() },
            success: function (response) {
                if (response.Data == '') {
                    popupNotification.show(errorsinthepage, "error");
                } else {
                    $("#ui_txt_medicalspecialty,#ui_txtarea_medicalspecialty").val(response.Data[0].MedicalSpecialty);
                    $("#ui_txt_boardcertification,#ui_txtarea_boardcertification").val(response.Data[0].BoardCertification);
                    $("#ui_txt_licenseorequivalent,#ui_txtarea_licenseorequivalent").val(response.Data[0].MedicalLicense);
                    var IsOtherTrainingsReceived = response.Data[0].IsOtherTrainingsReceived;
                    if (IsOtherTrainingsReceived == null)
                        $("#ui_ddl_isreceivedGCPtraining").data('kendoDropDownList').value("Select");
                    else {
                        if (IsOtherTrainingsReceived == true)
                            $('#ui_ddl_isreceivedGCPtraining').data('kendoDropDownList').value(yes);
                        else
                            $('#ui_ddl_isreceivedGCPtraining').data('kendoDropDownList').value(no);
                    }
                    $("#ui_txt_whenwasyourlastGCPtraining,#ui_txtarea_whenwasyourlastGCPtraining").val(response.Data[0].LastTrainingDetails);
                    $("#ui_txt_typeoftrainingreceived,#ui_txtarea_typeoftrainingreceived").val(response.Data[0].TypeOfTraining);
                    $("#ui_txt_listtrialexperience,#ui_txtarea_listtrialexperience").val(response.Data[0].TrialExperiences);
                    var IsCompanySponsoredtrial = response.Data[0].IsCompanySponsoredtrial;
                    if (IsCompanySponsoredtrial == null)
                        $("#ui_ddl_isparticipatedinacompanytrial").data('kendoDropDownList').value("Select");
                    else {
                        if (IsCompanySponsoredtrial == true)
                            $('#ui_ddl_isparticipatedinacompanytrial').data('kendoDropDownList').value(yes);
                        else
                            $('#ui_ddl_isparticipatedinacompanytrial').data('kendoDropDownList').value(no);
                    }
                    $("#ui_txt_datesoftrialparticipation,#ui_txtarea_datesoftrialparticipation").val(response.Data[0].TrialParticipation);
                    $("#ui_txt_drugnames,#ui_txtarea_drugnames").val(response.Data[0].DrugName);
                    $("#ui_txt_protocolnumbers,#ui_txtarea_protocolnumbers").val(response.Data[0].ProtocolNumber);
                    $("#ui_txt_numberofongoingclinicaltrials,#ui_txtarea_numberofongoingclinicaltrials").val(response.Data[0].NumberOfOngoingTrials);
                    var IsSiteInspectedByHealthAuthority = response.Data[0].IsSiteInspectedByHealthAuthority;
                    if (IsSiteInspectedByHealthAuthority == null)
                        $("#ui_ddl_isinspectedbyahealthauthority").data('kendoDropDownList').value("Select");
                    else {
                        if (IsSiteInspectedByHealthAuthority == true)
                            $('#ui_ddl_isinspectedbyahealthauthority').data('kendoDropDownList').value(yes);
                        else
                            $('#ui_ddl_isinspectedbyahealthauthority').data('kendoDropDownList').value(no);
                    }
                    $("#ui_txt_whichhealthauthority,#ui_txtarea_whichhealthauthority").val(response.Data[0].NameOfHealthAuthority);
                    $("#ui_dt_dateoflastinspection").val(response.Data[0].DateOflastInspection);
                    var IsSiteInspectedByFda = response.Data[0].IsSiteInspectedByFda;
                    if (IsSiteInspectedByFda == null)
                        $("#ui_ddl_isinspectedbytheFDA").data('kendoDropDownList').value("Select");
                    else {
                        if (IsSiteInspectedByFda == true)
                            $('#ui_ddl_isinspectedbytheFDA').data('kendoDropDownList').value(yes);
                        else
                            $('#ui_ddl_isinspectedbytheFDA').data('kendoDropDownList').value(no);
                    }
                    $("#dateofFDAinspection").val(response.Data[0].DateOfFdainspection);
                    var Isfda483formIssued = response.Data[0].Isfda483formIssued;
                    if (Isfda483formIssued == null)
                        $("#ui_ddl_isFDAissuedaFDA483form").data('kendoDropDownList').value("Select");
                    else {
                        if (Isfda483formIssued == true)
                            $('#ui_ddl_isFDAissuedaFDA483form').data('kendoDropDownList').value(yes);
                        else
                            $('#ui_ddl_isFDAissuedaFDA483form').data('kendoDropDownList').value(no);
                    }
                    $("#ui_txt_detailsofthemainobservations,#ui_txtarea_detailsofthemainobservations").val(response.Data[0].DetailsOfObservation);
                }
            },
            failure: function (response) {
                popupNotification.show(errorsinthepage, "error");
            }
        });

    }
});