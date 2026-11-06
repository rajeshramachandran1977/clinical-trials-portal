$(function () {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");

    //#region Study Enrollment & Timelines
    $("#ui_txtarea_studyduration").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_studyduration").val().trim();
        if (str != "")
            if ($("#regexexprforstudyduration").val() != "") {
                var expr = new RegExp($("#regexexprforstudyduration").val());
                var str = $("#ui_txtarea_studyduration").val();
                if (str != "" && !expr.test(str)) {
                    $('#studyduration').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstudyduration").val() + '</div>');
                    isvalidRegexforstudyduration = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstudyduration = true;
                    return true;
                }
            }
    });
    $("#ui_txt_studyduration").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_studyduration").val().trim();
        if (str != "")
            if ($("#regexexprforstudyduration").val() != "") {
                var expr = new RegExp($("#regexexprforstudyduration").val());
                var str = $("#ui_txt_studyduration").val();
                if (str != "" && !expr.test(str)) {
                    $('#studyduration').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstudyduration").val() + '</div>');
                    isvalidRegexforstudyduration = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstudyduration = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_impactpatientaccrual").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_impactpatientaccrual").val().trim();
        if (str != "")
            if ($("#regexexprforpatientaccrual").val() != "") {
                var expr = new RegExp($("#regexexprforpatientaccrual").val());
                var str = $("#ui_txtarea_impactpatientaccrual").val();
                if (str != "" && !expr.test(str)) {
                    $('#impactPatientAcrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforpatientaccrual").val() + '</div>');
                    isvalidRegexforimpactpatientaccrual = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforimpactpatientaccrual = true;
                    return true;
                }
            }
    });
    $("#ui_txt_impactpatientaccrual").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_impactpatientaccrual").val().trim();
        if (str != "")
            if ($("#regexexprforpatientaccrual").val() != "") {
                var expr = new RegExp($("#regexexprforpatientaccrual").val());
                var str = $("#ui_txt_impactpatientaccrual").val();
                if (str != "" && !expr.test(str)) {
                    $('#impactPatientAcrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforpatientaccrual").val() + '</div>');
                    isvalidRegexforimpactpatientaccrual = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforimpactpatientaccrual = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_noofpatientspertreatmentgroup").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_noofpatientspertreatmentgroup").val().trim();
        if (str != "")
            if ($("#regexexprfornoofpatientspertreatmentgroup").val() != "") {
                var expr = new RegExp($("#regexexprfornoofpatientspertreatmentgroup").val());
                var str = $("#ui_txtarea_noofpatientspertreatmentgroup").val();
                if (str != "" && !expr.test(str)) {
                    $('#noofpatientspertreatmentgroup').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfornoofpatientspertreatmentgroup").val() + '</div>');
                    isvalidRegexfornoofpatientspertreatmentgroup = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfornoofpatientspertreatmentgroup = true;
                    return true;
                }
            }
    });
    $("#ui_txt_noofpatientspertreatmentgroup").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_noofpatientspertreatmentgroup").val().trim();
        if (str != "")
            if ($("#regexexprfornoofpatientspertreatmentgroup").val() != "") {
                var expr = new RegExp($("#regexexprfornoofpatientspertreatmentgroup").val());
                var str = $("#ui_txt_noofpatientspertreatmentgroup").val();
                if (str != "" && !expr.test(str)) {
                    $('#noofpatientspertreatmentgroup').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfornoofpatientspertreatmentgroup").val() + '</div>');
                    isvalidRegexfornoofpatientspertreatmentgroup = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfornoofpatientspertreatmentgroup = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_enrollmenthistory").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_enrollmenthistory").val().trim();
        if (str != "")
            if ($("#regexexprforenrollmenthistory").val() != "") {
                var expr = new RegExp($("#regexexprforenrollmenthistory").val());
                var str = $("#ui_txtarea_enrollmenthistory").val();
                if (str != "" && !expr.test(str)) {
                    $('#enrollmentHistory').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforenrollmenthistory").val() + '</div>');
                    isvalidRegexforenrollmenthistory = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforenrollmenthistory = true;
                    return true;
                }
            }
    });
    $("#ui_txt_enrollmenthistory").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_enrollmenthistory").val().trim();
        if (str != "")
            if ($("#regexexprforenrollmenthistory").val() != "") {
                var expr = new RegExp($("#regexexprforenrollmenthistory").val());
                var str = $("#ui_txt_enrollmenthistory").val();
                if (str != "" && !expr.test(str)) {
                    $('#enrollmentHistory').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforenrollmenthistory").val() + '</div>');
                    isvalidRegexforenrollmenthistory = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforenrollmenthistory = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_maximumallowabletimebetweenvisits").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_maximumallowabletimebetweenvisits").val().trim();
        if (str != "")
            if ($("#regexexprformaximumallowabletimebetweenvisits").val() != "") {
                var expr = new RegExp($("#regexexprformaximumallowabletimebetweenvisits").val());
                var str = $("#ui_txtarea_maximumallowabletimebetweenvisits").val();
                if (str != "" && !expr.test(str)) {
                    $('#maximumallowabletimebetweenvisits').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgformaximumallowabletimebetweenvisits").val() + '</div>');
                    isvalidRegexformaximumallowabletimebetweenvisits = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexformaximumallowabletimebetweenvisits = true;
                    return true;
                }
            }
    });
    $("#ui_txt_maximumallowabletimebetweenvisits").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_maximumallowabletimebetweenvisits").val().trim();
        if (str != "")
            if ($("#regexexprformaximumallowabletimebetweenvisits").val() != "") {
                var expr = new RegExp($("#regexexprformaximumallowabletimebetweenvisits").val());
                var str = $("#ui_txt_maximumallowabletimebetweenvisits").val();
                if (str != "" && !expr.test(str)) {
                    $('#maximumallowabletimebetweenvisits').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgformaximumallowabletimebetweenvisits").val() + '</div>');
                    isvalidRegexformaximumallowabletimebetweenvisits = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexformaximumallowabletimebetweenvisits = true;
                    return true;
                }
            }
    });
    //#endregion Study Enrollment & Timelines

    function ValidateEnrollmentandTimelinesFields() {
        $(".error").remove();
        retval = true;
        objStudyEnrollmentandTimelines = new Object();
        objStudyEnrollmentandTimelines.StudyId = $('#StudyId').val();

        if ($('#displayStudystart').is(':visible'))
            if (sessionStorage.getItem("isstudystart") == "true") {
                if ($('#ui_dt_trialStart').val() == "day of the week day month year") {
                    $('#studystart').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_studystart').html() + ' is required</div>');
                    retval = false;
                }
                else
                    objStudyEnrollmentandTimelines.TrialStart = $('#ui_dt_trialStart').val().trim();
            }
            else
                objStudyEnrollmentandTimelines.TrialStart = $('#ui_dt_trialStart').val().trim();

        if ($('#displaynoOfPatients').is(':visible'))
            if (sessionStorage.getItem("isnoofpatients") == "true") {
                if ($('#ui_num_noofpatients').val() == "") {
                    $('#noOfPatients').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_noofpatients').html() + ' is required</div>');
                    retval = false;
                }
                else
                    objStudyEnrollmentandTimelines.TotalPlannedNumberofPatients = $('#ui_num_noofpatients').val().trim();
            }
            else
                objStudyEnrollmentandTimelines.TotalPlannedNumberofPatients = $('#ui_num_noofpatients').val().trim();

        if ($('#displayStudyduration').is(':visible'))
            if (sessionStorage.getItem("isstudyduration") == "true") {
                if ($('#ui_txt_studyduration').is(':visible')) {
                    if ($('#ui_txt_studyduration').val() == "") {
                        $('#studyduration').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_studyduration').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_studyduration').is(':visible')) {
                    if ($('#ui_txtarea_studyduration').val() == "") {
                        $('#studyduration').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_studyduration').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_studyduration').is(':visible'))
                    objStudyEnrollmentandTimelines.Studyduration = $('#ui_txt_studyduration').val().trim();
                if ($('#ui_txtarea_studyduration').is(':visible'))
                    objStudyEnrollmentandTimelines.Studyduration = $('#ui_txtarea_studyduration').val().trim();
            }
            else {
                if ($('#ui_txt_studyduration').is(':visible'))
                    objStudyEnrollmentandTimelines.Studyduration = $('#ui_txt_studyduration').val().trim();
                if ($('#ui_txtarea_studyduration').is(':visible'))
                    objStudyEnrollmentandTimelines.Studyduration = $('#ui_txtarea_studyduration').val().trim();
            }

        if ($('#displayEnrollmentrate').is(':visible'))
            if (sessionStorage.getItem("isenrollmentrate") == "true") {
                if ($('#ui_num_enrollmentrate').is(':visible')) {
                    if ($('#ui_num_enrollmentrate').val() == "") {
                        $('#enrollmentrate').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_enrollmentrate').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_num_enrollmentrate').is(':visible'))
                    objStudyEnrollmentandTimelines.Enrollmentrate = $('#ui_num_enrollmentrate').val().trim();
            }
            else {
                if ($('#ui_num_enrollmentrate').is(':visible'))
                    objStudyEnrollmentandTimelines.Enrollmentrate = $('#ui_num_enrollmentrate').val().trim();
            }

        if ($('#displayImpactPatientAcrual').is(':visible'))
            if (sessionStorage.getItem("isimpactpatientaccrual") == "true") {
                if ($('#ui_txt_impactpatientaccrual').is(':visible')) {
                    if ($('#ui_txt_impactpatientaccrual').val() == "") {
                        $('#impactPatientAcrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_impactpatientaccrual').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_impactpatientaccrual').is(':visible')) {
                    if ($('#ui_txtarea_impactpatientaccrual').val() == "") {
                        $('#impactPatientAcrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_impactpatientaccrual').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_impactpatientaccrual').is(':visible'))
                    objStudyEnrollmentandTimelines.CompetingStudies = $('#ui_txt_impactpatientaccrual').val().trim();
                if ($('#ui_txtarea_impactpatientaccrual').is(':visible'))
                    objStudyEnrollmentandTimelines.CompetingStudies = $('#ui_txtarea_impactpatientaccrual').val().trim();
            }
            else {
                if ($('#ui_txt_impactpatientaccrual').is(':visible'))
                    objStudyEnrollmentandTimelines.CompetingStudies = $('#ui_txt_impactpatientaccrual').val().trim();
                if ($('#ui_txtarea_impactpatientaccrual').is(':visible'))
                    objStudyEnrollmentandTimelines.CompetingStudies = $('#ui_txtarea_impactpatientaccrual').val().trim();
            }

        if ($('#displayRecruitmentEnd').is(':visible'))
            if (sessionStorage.getItem("isrecruitmentend") == "true") {
                if ($('#ui_dt_recruitmentend').val() == "day of the week day month year") {
                    $('#recruitmentEnd').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_recruitmentend').html() + ' is required</div>');
                    retval = false;
                }
                else
                    objStudyEnrollmentandTimelines.RecruitmentEnd = $('#ui_dt_recruitmentend').val().trim();
            }
            else
                objStudyEnrollmentandTimelines.RecruitmentEnd = $('#ui_dt_recruitmentend').val().trim();

        if ($('#displayCompletionoffinalstudyreport').is(':visible'))
            if (sessionStorage.getItem("iscompletionoffinalstudyreport") == "true") {
                if ($('#ui_dt_completionoffinalstudyreport').val() == "day of the week day month year") {
                    $('#completionoffinalstudyreport').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_completionoffinalstudyreport').html() + ' is required</div>');
                    retval = false;
                }
                else
                    objStudyEnrollmentandTimelines.CompletionofTrialReport = $('#ui_dt_completionoffinalstudyreport').val().trim();
            }
            else
                objStudyEnrollmentandTimelines.CompletionofTrialReport = $('#ui_dt_completionoffinalstudyreport').val().trim();

        if ($('#displayTrialEnd').is(':visible'))
            if (sessionStorage.getItem("istrialend") == "true") {
                if ($('#ui_dt_trialend').val() == "day of the week day month year") {
                    $('#trialEnd').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_trialend').html() + ' is required</div>');
                    retval = false;
                }
                else
                    objStudyEnrollmentandTimelines.TrialEnd = $('#ui_dt_completionoffinalstudyreport').val().trim();
            }
            else
                objStudyEnrollmentandTimelines.TrialEnd = $('#ui_dt_completionoffinalstudyreport').val().trim();

        if ($('#displayNoofpatientspertreatmentgroup').is(':visible'))
            if (sessionStorage.getItem("ispatientspertreatmentgroup") == "true") {
                if ($('#ui_txt_noofpatientspertreatmentgroup').is(':visible')) {
                    if ($('#ui_txt_noofpatientspertreatmentgroup').val() == "") {
                        $('#noofpatientspertreatmentgroup').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_noofpatientspertreatmentgroup').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_noofpatientspertreatmentgroup').is(':visible')) {
                    if ($('#ui_txtarea_noofpatientspertreatmentgroup').val() == "") {
                        $('#noofpatientspertreatmentgroup').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_noofpatientspertreatmentgroup').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_noofpatientspertreatmentgroup').is(':visible'))
                    objStudyEnrollmentandTimelines.Noofpatientspertreatmentgroup = $('#ui_txt_noofpatientspertreatmentgroup').val().trim();
                if ($('#ui_txtarea_noofpatientspertreatmentgroup').is(':visible'))
                    objStudyEnrollmentandTimelines.Noofpatientspertreatmentgroup = $('#ui_txtarea_noofpatientspertreatmentgroup').val().trim();
            }
            else {
                if ($('#ui_txt_noofpatientspertreatmentgroup').is(':visible'))
                    objStudyEnrollmentandTimelines.Noofpatientspertreatmentgroup = $('#ui_txt_noofpatientspertreatmentgroup').val().trim();
                if ($('#ui_txtarea_noofpatientspertreatmentgroup').is(':visible'))
                    objStudyEnrollmentandTimelines.Noofpatientspertreatmentgroup = $('#ui_txtarea_noofpatientspertreatmentgroup').val().trim();
            }

        if ($('#displayenrollmentHistory').is(':visible'))
            if (sessionStorage.getItem("isenrollmenthistory") == "true") {
                if ($('#ui_txt_enrollmenthistory').is(':visible')) {
                    if ($('#ui_txt_enrollmenthistory').val() == "") {
                        $('#enrollmentHistory').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_enrollmenthistory').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_enrollmenthistory').is(':visible')) {
                    if ($('#ui_txtarea_enrollmenthistory').val() == "") {
                        $('#enrollmentHistory').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_enrollmenthistory').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_enrollmenthistory').is(':visible'))
                    objStudyEnrollmentandTimelines.EnrollmentHistoryforOtherRelatedStudies = $('#ui_txt_enrollmenthistory').val().trim();
                if ($('#ui_txtarea_enrollmenthistory').is(':visible'))
                    objStudyEnrollmentandTimelines.EnrollmentHistoryforOtherRelatedStudies = $('#ui_txtarea_enrollmenthistory').val().trim();
            }
            else {
                if ($('#ui_txt_enrollmenthistory').is(':visible'))
                    objStudyEnrollmentandTimelines.EnrollmentHistoryforOtherRelatedStudies = $('#ui_txt_enrollmenthistory').val().trim();
                if ($('#ui_txtarea_enrollmenthistory').is(':visible'))
                    objStudyEnrollmentandTimelines.EnrollmentHistoryforOtherRelatedStudies = $('#ui_txtarea_enrollmenthistory').val().trim();
            }

        if ($('#displayprimaryPublication').is(':visible'))
            if (sessionStorage.getItem("isprimarypublication") == "true") {
                if ($('#ui_dt_primarypublication').val() == "day of the week day month year") {
                    $('#primaryPublication').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_primarypublication').html() + ' is required</div>');
                    retval = false;
                }
                else
                    objStudyEnrollmentandTimelines.PrimaryPublicationDate = $('#ui_dt_primarypublication').val().trim();
            }
            else
                objStudyEnrollmentandTimelines.PrimaryPublicationDate = $('#ui_dt_primarypublication').val().trim();

        if ($('#displayaretherecompetingstudiesatyourinstitution').is(':visible'))
            if (sessionStorage.getItem("iscompetingstudiesatyourinstitution") == "true") {
                if ($('#ui_ddl_competingstudies').val() == "") {
                    $('#aretherecompetingstudiesatyourinstitution').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_occurrenceofotherspecialscenarios').html() + ' is required</div>');
                    retval = false;
                }
                else
                    if ($('#ui_ddl_competingstudies').val() == yes)
                        objStudyEnrollmentandTimelines.IsCompetingStudies = true;
                if ($('#ui_ddl_competingstudies').val() == no)
                    objStudyEnrollmentandTimelines.IsCompetingStudies = false;
                if ($('#ui_ddl_competingstudies').val() == "")
                    objStudyEnrollmentandTimelines.IsCompetingStudies = null;
            }
            else
                if ($('#ui_ddl_competingstudies').val() == yes)
                    objStudyEnrollmentandTimelines.IsCompetingStudies = true;
        if ($('#ui_ddl_competingstudies').val() == no)
            objStudyEnrollmentandTimelines.IsCompetingStudies = false;
        if ($('#ui_ddl_competingstudies').val() == "")
            objStudyEnrollmentandTimelines.IsCompetingStudies = null;
    }

    //#region Remove err msg on key up for non grid text fields
    $("").on("keyup", function (e) {
        $(this).next("div.error").remove();
    })

    $('').change(function () {
        $(this).next("div.error").remove();
    }).change();
    //#endregion

    $("#studyenrollmentandtimelines").on("click", function () {
        $('#studyenrollmentandtimelinescontents').show();
        LoadStudyEnrollmentandTimelinesAttributeValues();
        LoadStudyEnrollmentandTimelinesData();
    });

    $("#ui_btnSaveEnrollmentandTimelines").click(function (e) {
        ValidateEnrollmentandTimelinesFields();
        if (validator.validate() && retval === true && (isvalidRegexforstudyduration === true
            && isvalidRegexforimpactpatientaccrual === true && isvalidRegexfornoofpatientspertreatmentgroup === true
            && isvalidRegexforenrollmenthistory === true && isvalidRegexformaximumallowabletimebetweenvisits === true))
            Savedetails(type = 6, objEditstudy = objStudyEnrollmentandTimelines);
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    });

    function LoadStudyEnrollmentandTimelinesAttributeValues() {
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
                            case studystart:
                                DropDowndetails(response, "displayStudystart", "ui_lbl_studystart", "ui_img_helpTextforstudystart", "isstudystart");
                                break;
                            case totalnoofpatients:
                                DropDowndetails(response, "displaynoOfPatients", "ui_lbl_noofpatients", "ui_img_helpTextfornoofpatients", "isnoofpatients");
                                break;
                            case studyduration:
                                Textdetails(response, "displayStudyduration", "ui_lbl_studyduration", "ui_img_helpTextforstudyduration", "isstudyduration", "ui_txt_studyduration", "ui_txtarea_studyduration", "ui_lbl_charsleftforstudyduration", "regexexprforstudyduration", "validationmsgforstudyduration");
                                break;
                            case competingstudiesatinstitution:
                                DropDowndetails(response, "displayaretherecompetingstudiesatyourinstitution", "ui_lbl_competingstudiesatyourinstitution", "ui_img_helpTextforcompetingstudiesatyourinstitution", "iscompetingstudiesatyourinstitution");
                                break;
                            case impactpatientaccrualfortheproposedstudy:
                                Textdetails(response, "displayImpactPatientAcrual", "ui_lbl_impactpatientaccrual", "ui_img_helpTextforimpactPatientAcrual", "isimpactpatientaccrual", "ui_txt_impactpatientaccrual", "ui_txtarea_impactpatientaccrual", "ui_lbl_charsleftforpatientaccrual", "regexexprforpatientaccrual", "validationmsgforpatientaccrual");
                                break;
                            case recruitmentend:
                                DropDowndetails(response, "displayRecruitmentEnd", "ui_lbl_recruitmentend", "ui_img_helpTextforrecruitmentend", "isrecruitmentend");
                                break;
                            case completionoffinalstudyreport:
                                DropDowndetails(response, "displayCompletionoffinalstudyreport", "ui_lbl_completionoffinalstudyreport", "ui_img_helpTextforcompletionoffinalstudyreport", "iscompletionoffinalstudyreport");
                                break;
                            case trialend:
                                DropDowndetails(response, "displayTrialEnd", "ui_lbl_trialend", "ui_img_helpTextfortrialend", "istrialend");
                                break;
                            case noofpatientspertreatmentgroup:
                                Textdetails(response, "displayNoofpatientspertreatmentgroup", "ui_lbl_noofpatientspertreatmentgroup", "ui_img_helpTextfornoofpatientspertreatmentgroup", "ispatientspertreatmentgroup", "ui_txt_noofpatientspertreatmentgroup", "ui_txtarea_noofpatientspertreatmentgroup", "ui_lbl_charsleftfornoofpatientspertreatmentgroup", "regexexprfornoofpatientspertreatmentgroup", "validationmsgfornoofpatientspertreatmentgroup");
                                break;
                            case enrollmenthistoryforotherrelatedstudies:
                                Textdetails(response, "displayenrollmentHistory", "ui_lbl_enrollmenthistory", "ui_img_helpTextforenrollmenthistory", "isenrollmenthistory", "ui_txt_enrollmenthistory", "ui_txtarea_enrollmenthistory", "ui_lbl_charsleftforenrollmenthistory", "regexexprforenrollmenthistory", "validationmsgforenrollmenthistory");
                                break;
                            case primarypublicationdate:
                                DropDowndetails(response, "displayprimaryPublication", "ui_lbl_primarypublication", "ui_img_helpTextforprimarypublication", "isprimarypublication");
                                break;
                            case enrollmentrate:
                                NumberFielddetails(response, "displayEnrollmentrate", "ui_lbl_enrollmentrate", "ui_img_helpTextforenrollmentrate", "isenrollmentrate", "ui_num_enrollmentrate");
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

    function LoadStudyEnrollmentandTimelinesData() {
        $.ajax({
            async: true,
            type: "POST",
            url: "/NewStudy/GetStudyEnrollmentandTimelinesData/",
            cache: false,
            dataType: "json",
            data: { "StudyId": $('#StudyId').val() },
            success: function (response) {
                if (response.Data == '')
                    popupNotification.show(errorsinthepage, "error");
                else {
                    $("#ui_dt_trialStart").data("kendoDatePicker").value(response.Data[0].TrialStart);
                    $("#ui_num_noofpatients").val(response.Data[0].TotalPlannedNumberofPatients);
                    $("#ui_txt_studyduration,#ui_txtarea_studyduration").val(response.Data[0].Studyduration);
                    $("#ui_num_enrollmentrate").val(response.Data[0].Enrollmentrate);
                    $("#ui_dt_recruitmentend").data("kendoDatePicker").value(response.Data[0].RecruitmentEnd);
                    $("#ui_dt_completionoffinalstudyreport").data("kendoDatePicker").value(response.Data[0].CompletionofTrialReport);
                    $("#ui_dt_trialend").data("kendoDatePicker").value(response.Data[0].TrialEnd);
                    $("#ui_txt_enrollmentHistory").val(response.Data[0].EnrollmentHistoryforOtherRelatedStudies);
                    $("#ui_dt_primarypublication").data("kendoDatePicker").value(response.Data[0].PrimaryPublicationDate);
                    $("#ui_txt_noofpatientspertreatmentgroup,#ui_txtarea_noofpatientspertreatmentgroup").val(response.Data[0].Noofpatientspertreatmentgroup);
                    $("#ui_txt_enrollmenthistory,#ui_txtarea_enrollmenthistory").val(response.Data[0].EnrollmentHistoryforOtherRelatedStudies);
                    var IsCompetingStudies = response.Data[0].IsCompetingStudies;
                    if (IsCompetingStudies == null)
                        $("#ui_ddl_competingstudies").data('kendoDropDownList').value("Select");
                    else {
                        if (IsCompetingStudies == true)
                            $('#ui_ddl_competingstudies').data('kendoDropDownList').value(yes);
                        else
                            $('#ui_ddl_competingstudies').data('kendoDropDownList').value(no);
                    }
                    if (IsCompetingStudies === true) {
                        $('#impactPatientAcrual').show();
                        $("#ui_txt_impactpatientaccrual,#ui_txtarea_impactpatientaccrual").val(response.Data[0].CompetingStudies);
                    }
                }
            },
            failure: function (response) {
                popupNotification.show(errorsinthepage, "error");
            }
        });
    }
})