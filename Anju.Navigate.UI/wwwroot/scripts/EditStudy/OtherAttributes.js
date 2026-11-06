$(function () {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");

    $("#ui_txt_conditionsofapproval").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_conditionsofapproval").val().trim();
        if (str != "")
            if ($("#regexforconditionsofapproval").val() != "") {
                var expr = new RegExp($("#regexforconditionsofapproval").val());
                var str = $("#ui_txt_conditionsofapproval").val();
                if (str != "" && !expr.test(str)) {
                    $('#conditionsofapproval').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforconditionsofapproval").val() + '</div>');
                    isvalidRegexforconditionsofapproval = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforconditionsofapproval = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_conditionsofapproval").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_conditionsofapproval").val().trim();
        if (str != "")
            if ($("#regexforconditionsofapproval").val() != "") {
                var expr = new RegExp($("#regexforconditionsofapproval").val());
                var str = $("#ui_txtarea_conditionsofapproval").val();
                if (str != "" && !expr.test(str)) {
                    $('#conditionsofapproval').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforconditionsofapproval").val() + '</div>');
                    isvalidRegexforconditionsofapproval = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforconditionsofapproval = true;
                    return true;
                }
            }
    });

    $("#otherattributes").on("click", function () {
        $('#otherattributescontents').show();
        var isEditmode = false;
        isEditmode = LoadOtherAttributesData();

        if (isEditmode == true)
            LoadOtherAttributesValues("Edit");
        else
            LoadOtherAttributesValues("Create");
    });

    //#region Validate Other Attributes Fields
    function ValidateOtherAttributesFields() {
        $(".error").remove();
        retval = true;
        objOtherAttributes = new Object();
        objOtherAttributes.StudyId = $('#StudyId').val();

        if ($('#displayAmendmentrequestincludesachangeintheprimaryinvestigator').is(':visible'))
            if (sessionStorage.getItem("isamendmentrequestincludesachangeintheprimaryinvestigator") == "true") {
                if (($('#ui_chkbox_amendmentrequestincludesachangeintheprimaryinvestigator').prop("checked") == false)) {
                    $('#amendmentrequestincludesachangeintheprimaryinvestigatordiv').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_amendmentrequestincludesachangeintheprimaryinvestigator').html() + ' is required</div>');
                    retval = false;
                }
                else
                    objOtherAttributes.Isamendmentrequestincludesachangeintheprimaryinvestigator = $('#ui_chkbox_amendmentrequestincludesachangeintheprimaryinvestigator').prop("checked");

            }
            else
                objOtherAttributes.Isamendmentrequestincludesachangeintheprimaryinvestigator = $('#ui_chkbox_amendmentrequestincludesachangeintheprimaryinvestigator').prop("checked");

        if ($('#displayAutoproxyenabled').is(':visible'))
            if (sessionStorage.getItem("isautoproxyenabled") == "true") {
                if (($('#ui_chkbox_autoproxyenabled').prop("checked") == false)) {
                    $('#autoproxyenabled').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_autoproxyenabled').html() + ' is required</div>');
                    retval = false;
                }
                else
                    objOtherAttributes.Isautoproxyenabled = $('#ui_chkbox_autoproxyenabled').prop("checked");

            }
            else
                objOtherAttributes.Isautoproxyenabled = $('#ui_chkbox_autoproxyenabled').prop("checked");

        if ($('#displayLeadorganization').is(':visible'))
            if (sessionStorage.getItem("isleadorganization") == "true") {
                if ($('#ui_ddl_leadorganization').val() == "") {
                    $('#leadorganization').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_leadorganization').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_leadorganization').val() == "")
                        objOtherAttributes.Leadorganization = null;
                    else
                        objOtherAttributes.Leadorganization = $('#ui_ddl_leadorganization').val();
                }
            }
            else {
                if ($('#ui_ddl_leadorganization').val() == "")
                    objOtherAttributes.Leadorganization = null;
                else
                    objOtherAttributes.Leadorganization = $('#ui_ddl_leadorganization').val();
            }

        if ($('#displayConditionalapproval').is(':visible'))
            if (sessionStorage.getItem("isconditionalapproval") == "true") {
                if ($('#ui_ddl_conditionalapproval').val() == "") {
                    $('#conditionalapproval').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_conditionalapproval').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_conditionalapproval').val() == "@ConstDefaultValue.YES")
                        objOtherAttributes.Isconditionalapproval = true;
                    if ($('#ui_ddl_conditionalapproval').val() == "@ConstDefaultValue.NO")
                        objOtherAttributes.Isconditionalapproval = false;
                    if ($('#ui_ddl_conditionalapproval').val() == "")
                        objOtherAttributes.Isconditionalapproval = null;
                }
            }
            else {
                if ($('#ui_ddl_conditionalapproval').val() == "@ConstDefaultValue.YES")
                    objOtherAttributes.Isconditionalapproval = true;
                if ($('#ui_ddl_conditionalapproval').val() == "@ConstDefaultValue.NO")
                    objOtherAttributes.Isconditionalapproval = false;
                if ($('#ui_ddl_conditionalapproval').val() == "")
                    objOtherAttributes.Isconditionalapproval = null;
            }

        if ($('#displayConditionsofapproval').is(':visible'))
            if (sessionStorage.getItem("isconditionsofapproval") == "true") {
                if ($('#ui_txt_conditionsofapproval').is(':visible')) {
                    if ($('#ui_txt_conditionsofapproval').val() == "") {
                        $('#conditionsofapproval').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_conditionsofapproval').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_conditionsofapproval').is(':visible')) {
                    if ($('#ui_txtarea_conditionsofapproval').val() == "") {
                        $('#conditionsofapproval').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_conditionsofapproval').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_conditionsofapproval').is(':visible'))
                    objOtherAttributes.Conditionsofapproval = $('#ui_txt_conditionsofapproval').val().trim();
                if ($('#ui_txtarea_conditionsofapproval').is(':visible'))
                    objOtherAttributes.Conditionsofapproval = $('#ui_txtarea_conditionsofapproval').val().trim();
            }
            else {
                if ($('#ui_txt_conditionsofapproval').is(':visible'))
                    objOtherAttributes.Conditionsofapproval = $('#ui_txt_conditionsofapproval').val().trim();
                if ($('#ui_txtarea_conditionsofapproval').is(':visible'))
                    objOtherAttributes.Conditionsofapproval = $('#ui_txtarea_conditionsofapproval').val().trim();
            }

        if ($('#displayICFReview').is(':visible'))
            if (sessionStorage.getItem("isICFReview") == "true") {
                if ($('#ui_ddl_ICFReview').val() == "") {
                    $('#ICFReview').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_ICFReview').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_ICFReview').val() == "")
                        objOtherAttributes.ICFReview = null;
                    else
                        objOtherAttributes.ICFReview = $('#ui_ddl_ICFReview').val();
                }
            }
            else {
                if ($('#ui_ddl_ICFReview').val() == "")
                    objOtherAttributes.ICFReview = null;
                else
                    objOtherAttributes.ICFReview = $('#ui_ddl_ICFReview').val();
            }

        if ($('#displayAmendmentstatus').is(':visible'))
            if (sessionStorage.getItem("isamendmentstatus") == "true") {
                if ($('#ui_ddl_amendmentstatus').val() == "") {
                    $('#amendmentstatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_amendmentstatus').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_amendmentstatus').val() == "")
                        objOtherAttributes.Amendmentstatus = null;
                    else
                        objOtherAttributes.Amendmentstatus = $('#ui_ddl_amendmentstatus').val();
                }
            }
            else {
                if ($('#ui_ddl_amendmentstatus').val() == "")
                    objOtherAttributes.Amendmentstatus = null;
                else
                    objOtherAttributes.Amendmentstatus = $('#ui_ddl_amendmentstatus').val();
            }

        if ($('#displayAmendmenttype').is(':visible'))
            if (sessionStorage.getItem("isamendmenttype") == "true") {
                if ($('#ui_ddl_amendmenttype').val() == "") {
                    $('#amendmenttype').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_amendmenttype').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_amendmenttype').val() == "")
                        objOtherAttributes.Amendmenttype = null;
                    else
                        objOtherAttributes.Amendmenttype = $('#ui_ddl_amendmenttype').val();
                }
            }
            else {
                if ($('#ui_ddl_amendmenttype').val() == "")
                    objOtherAttributes.Amendmenttype = null;
                else
                    objOtherAttributes.Amendmenttype = $('#ui_ddl_amendmenttype').val();
            }

        if ($('#displayContractamendmentrequired').is(':visible'))
            if (sessionStorage.getItem("iscontractamendmentrequired") == "true") {
                if ($('#ui_ddl_contractamendmentrequired').val() == "") {
                    $('#contractamendmentrequired').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_contractamendmentrequired').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_contractamendmentrequired').val() == yes)
                        objOtherAttributes.Contractamendmentrequired = true;
                    if ($('#ui_ddl_contractamendmentrequired').val() == no)
                        objOtherAttributes.Contractamendmentrequired = false;
                    if ($('#ui_ddl_contractamendmentrequired').val() == na)
                        objOtherAttributes.Contractamendmentrequired = na;
                    if ($('#ui_ddl_contractamendmentrequired').val() == "")
                        objOtherAttributes.Contractamendmentrequired = null;
                }
            }
            else {
                if ($('#ui_ddl_contractamendmentrequired').val() == yes)
                    objOtherAttributes.Contractamendmentrequired = true;
                if ($('#ui_ddl_contractamendmentrequired').val() == no)
                    objOtherAttributes.Contractamendmentrequired = false;
                if ($('#ui_ddl_contractamendmentrequired').val() == na)
                    objOtherAttributes.Contractamendmentrequired = na;
                if ($('#ui_ddl_contractamendmentrequired').val() == "")
                    objOtherAttributes.Contractamendmentrequired = null;
            }

        if ($('#displayIsPIstudysponsor').is(':visible'))
            if (sessionStorage.getItem("isPIstudyssponsor") == "true") {
                if ($('#ui_ddl_isPIstudyssponsor').val() == "") {
                    $('#isPIstudyssponsor').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_isPIstudyssponsor').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_isPIstudyssponsor').val() == yes)
                        objOtherAttributes.Ipistudyssponsor = true;
                    if ($('#ui_ddl_isPIstudyssponsor').val() == no)
                        objOtherAttributes.Ipistudyssponsor = false;
                    if ($('#ui_ddl_isPIstudyssponsor').val() == "")
                        objOtherAttributes.Ipistudyssponsor = null;
                }
            }
            else {
                if ($('#ui_ddl_isPIstudyssponsor').val() == yes)
                    objOtherAttributes.Ipistudyssponsor = true;
                if ($('#ui_ddl_isPIstudyssponsor').val() == no)
                    objOtherAttributes.Ipistudyssponsor = false;
                if ($('#ui_ddl_isPIstudyssponsor').val() == "")
                    objOtherAttributes.Ipistudyssponsor = null;
            }

        if ($('#displayContractexecutiondate').is(':visible'))
            if (sessionStorage.getItem("iscontractexecutiondate") == "true") {
                if ($('#ui_dt_contractexecutiondate').val() == "month day, year") {
                    $('#contractexecutiondate').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_contractexecutiondate').html() + ' is required</div>');
                    retval = false;
                } else {
                    if ($('#ui_dt_contractexecutiondate').val() == "month day, year")
                        objOtherAttributes.ExecutionDate = null;
                    else
                        objOtherAttributes.ExecutionDate = $('#ui_dt_contractexecutiondate').val();
                }
            }
            else {
                if ($('#ui_dt_contractexecutiondate').val() == "")
                    objOtherAttributes.ExecutionDate = null;
                else
                    objOtherAttributes.ExecutionDate = $('#ui_dt_contractexecutiondate').val();
            }

        if ($('#displayMigrationdate').is(':visible'))
            if (sessionStorage.getItem("ismigrationdate") == "true") {
                if ($('#ui_dt_migrationdate').val() == "month day, year") {
                    $('#migrationdate').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_migrationdate').html() + ' is required</div>');
                    retval = false;
                } else {
                    if ($('#ui_dt_migrationdate').val() == "month day, year")
                        objOtherAttributes.Migrationdate = null;
                    else
                        objOtherAttributes.Migrationdate = $('#ui_dt_migrationdate').val();
                }
            }
            else {
                if ($('#ui_dt_migrationdate').val() == "")
                    objOtherAttributes.Migrationdate = null;
                else
                    objOtherAttributes.Migrationdate = $('#ui_dt_migrationdate').val();
            }

        if ($('#displayConversionstatus').is(':visible'))
            if (sessionStorage.getItem("isconversionstatus") == "true") {
                if ($('#ui_ddl_conversionstatus').val() == "") {
                    $('#conversionstatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_conversionstatus').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_conversionstatus').val() == "")
                        objOtherAttributes.Conversionstatus = null;
                    else
                        objOtherAttributes.Conversionstatus = $('#ui_ddl_conversionstatus').val();
                }
            }
            else {
                if ($('#ui_ddl_conversionstatus').val() == "")
                    objOtherAttributes.Conversionstatus = null;
                else
                    objOtherAttributes.Conversionstatus = $('#ui_ddl_conversionstatus').val();
            }

        if ($('#displayMilestoneupdatefrequencydays').is(':visible'))
            if (sessionStorage.getItem("ismilestoneupdatefrequencydays") == "true") {
                if ($('#ui_num_milestoneupdatefrequencydays').is(':visible')) {
                    if ($('#ui_num_milestoneupdatefrequencydays').val() == "") {
                        $('#milestoneupdatefrequencydays').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_milestoneupdatefrequencydays').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_num_milestoneupdatefrequencydays').is(':visible'))
                    objOtherAttributes.Milestoneupdatefrequencydays = parseInt($('#ui_num_milestoneupdatefrequencydays').val().trim());
            }
            else {
                if ($('#ui_num_milestoneupdatefrequencydays').is(':visible'))
                    objOtherAttributes.Milestoneupdatefrequencydays = parseInt($('#ui_num_milestoneupdatefrequencydays').val().trim());
            }

        if ($('#displayAccrualmilestoneupdatefrequencydays').is(':visible'))
            if (sessionStorage.getItem("isaccrualmilestoneupdatefrequencydays") == "true") {
                if ($('#ui_num_accrualmilestoneupdatefrequencydays').is(':visible')) {
                    if ($('#ui_num_accrualmilestoneupdatefrequencydays').val() == "") {
                        $('#accrualmilestoneupdatefrequencydays').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_accrualmilestoneupdatefrequencydays').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_num_accrualmilestoneupdatefrequencydays').is(':visible'))
                    objOtherAttributes.Accrualmilestoneupdatefrequencydays = parseInt($('#ui_num_accrualmilestoneupdatefrequencydays').val().trim());
            }
            else {
                if ($('#ui_num_accrualmilestoneupdatefrequencydays').is(':visible'))
                    objOtherAttributes.Accrualmilestoneupdatefrequencydays = parseInt($('#ui_num_accrualmilestoneupdatefrequencydays').val().trim());
            }

        if ($('#displayLastsendemail').is(':visible'))
            if (sessionStorage.getItem("issendemail") == "true") {
                if ($('#ui_dt_lastsendemail').val() == "month day, year") {
                    $('#lastsendemail').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_lastsendemail').html() + ' is required</div>');
                    retval = false;
                } else {
                    if ($('#ui_dt_lastsendemail').val() == "month day, year")
                        objOtherAttributes.Lastsendemail = null;
                    else
                        objOtherAttributes.Lastsendemail = $('#ui_dt_lastsendemail').val();
                }
            }
            else {
                if ($('#ui_dt_lastsendemail').val() == "")
                    objOtherAttributes.Lastsendemail = null;
                else
                    objOtherAttributes.Lastsendemail = $('#ui_dt_lastsendemail').val();
            }

        if ($('#displaySAEFrequency').is(':visible'))
            if (sessionStorage.getItem("isSAEFrequency") == "true") {
                if ($('#ui_ddl_saefrequency').val() == "") {
                    $('#SAEFrequency').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_SAEFrequency').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_saefrequency').val() == "")
                        objOtherAttributes.SaereconciliationFrequency = null;
                    else
                        objOtherAttributes.SaereconciliationFrequency = $('#ui_ddl_saefrequency').val();
                }
            }
            else {
                if ($('#ui_ddl_saefrequency').val() == "")
                    objOtherAttributes.SaereconciliationFrequency = null;
                else
                    objOtherAttributes.SaereconciliationFrequency = $('#ui_ddl_saefrequency').val();
            }
    }

    //#endregion

    $("#conditionsofapproval,#milestoneupdatefrequencydays,#accrualmilestoneupdatefrequencydays").on("keyup", function (e) {
        $(this).next("div.error").remove();
    })

    $('#amendmentrequestincludesachangeintheprimaryinvestigatordiv,#autoproxyenabled,#leadorganization,#conditionalapproval,#ICFReview,#amendmentstatus,#amendmenttype, \
           #keyinclusioncriteria,#contractamendmentrequired,#isPIstudyssponsor,#contractexecutiondate, \
           #migrationdate,#conversionstatus,#lastsendemail,#SAEFrequency').change(function () {
        $(this).next("div.error").remove();
    }).change();

    isvalidRegexforconditionsofapproval = true;

    $("#ui_btnSaveOtherAttributes").click(function (e) {
        ValidateOtherAttributesFields();
        if (validator.validate() && retval === true && isvalidRegexforconditionsofapproval === true)
            Savedetails(type = 30, objEditstudy = objOtherAttributes);
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    });
});


function LoadOtherAttributesValues(mode) {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(otherattributesattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case otherattributes:
                            var iscreaterestricted = false;
                            var iseditrestricted = false;
                            if (response[i].RestrictCreateUser != null) {
                                var restrictcreateUserArray = response[i].RestrictCreateUser.split(',');
                                for (var j = 0; j < restrictcreateUserArray.length; j++) {
                                    if (restrictcreateUserArray[j] == $('#UserType').val()) {
                                        iscreaterestricted = true;
                                        break;
                                    }
                                    else
                                        iscreaterestricted = false;
                                    if (iscreaterestricted == true)
                                        $("#ui_btnSaveOtherAttributes").attr("disabled", true);
                                }
                                if (iscreaterestricted == true)
                                    $("#ui_btnSaveOtherAttributes").attr("disabled", true);
                            }
                            if (response[i].RestrictEditUser != null) {
                                var restrictedituserArray = response[i].RestrictEditUser.split(',');
                                for (var j = 0; j < restrictedituserArray.length; j++) {
                                    if (restrictedituserArray[j] == $('#UserType').val()) {
                                        iseditrestricted = true;
                                        break;
                                    }
                                    else
                                        iseditrestricted = false;
                                    if (iseditrestricted == true)
                                        $("#ui_btnSaveOtherAttributes").attr("disabled", true);
                                }
                                if (iseditrestricted == true)
                                    $("#ui_btnSaveOtherAttributes").attr("disabled", true);
                            }
                            if (iscreaterestricted == true || iseditrestricted == true)
                                $("#ui_btnSaveOtherAttributes").attr("disabled", true);
                            else
                                $("#ui_btnSaveOtherAttributes").removeAttr("disabled");
                            break;
                        case amendmentrequestincludesachangeintheprimaryinvestigator:
                            CheckBoxdetails(response, "displayAmendmentrequestincludesachangeintheprimaryinvestigator", "ui_lbl_amendmentrequestincludesachangeintheprimaryinvestigator", "ui_img_helpTextforamendmentrequestincludesachangeintheprimaryinvestigator", "isamendmentrequestincludesachangeintheprimaryinvestigator", mode);
                            break;
                        case autoproxyenabled:
                            CheckBoxdetails(response, "displayAutoproxyenabled", "ui_lbl_autoproxyenabled", "ui_img_helpTextforautoproxyenabled", "isautoproxyenabled", mode);
                            break;
                        case leadorganization:
                            DropDowndetails(response, "displayLeadorganization", "ui_lbl_leadorganization", "ui_img_helpTextforleadorganization", "isleadorganization", mode);
                            break;
                        case conditionalapproval:
                            DropDowndetails(response, "displayConditionalapproval", "ui_lbl_conditionalapproval", "ui_img_helpTextforconditionalapproval", "isconditionalapproval", mode);
                            break;
                        case conditionsofapproval:
                            Textdetails(response, "displayConditionsofapproval", "ui_lbl_conditionsofapproval", "ui_img_helpTextforconditionsofapproval", "isconditionsofapproval", "ui_txt_conditionsofapproval", "ui_txtarea_conditionsofapproval", "ui_lbl_charsleftforconditionsofapproval", "regexforconditionsofapproval", "validationmsgforconditionsofapproval", mode);
                            break;
                        case icfreview:
                            DropDowndetails(response, "displayICFReview", "ui_lbl_ICFReview", "ui_img_helpTextforICFReview", "isICFReview", mode);
                            break;
                        case amendmentstatus:
                            DropDowndetails(response, "displayAmendmentstatus", "ui_lbl_amendmentstatus", "ui_img_helpTextforamendmentstatus", "isamendmentstatus", mode);
                            break;
                        case amendmenttype:
                            DropDowndetails(response, "displayAmendmenttype", "ui_lbl_amendmenttype", "ui_img_helpTextforamendmenttype", "isamendmenttype", mode);
                            break;
                        case contractamendmentrequired:
                            DropDowndetails(response, "displayContractamendmentrequired", "ui_lbl_contractamendmentrequired", "ui_img_helpTextforcontractamendmentrequired", "iscontractamendmentrequired", mode);
                            break;
                        case ispistudysponsor:
                            DropDowndetails(response, "displayIsPIstudysponsor", "ui_lbl_isPIstudyssponsor", "ui_img_helpTextforisPIstudyssponsor", "isPIstudyssponsor", mode);
                            break;
                        case contractexecutiondate:
                            DropDowndetails(response, "displayContractexecutiondate", "ui_lbl_contractexecutiondate", "ui_img_helpTextforiscontractexecutiondate", "iscontractexecutiondate", mode);
                            break;
                        case migrationdate:
                            DropDowndetails(response, "displayMigrationdate", "ui_lbl_migrationdate", "ui_img_helpTextformigrationdate", "ismigrationdate", mode);
                            break;
                        case conversionstatus:
                            DropDowndetails(response, "displayConversionstatus", "ui_lbl_conversionstatus", "ui_img_helpTextforconversionstatus", "isconversionstatus", mode);
                            break;
                        case milestoneupdatefrequencydays:
                            NumberFielddetails(response, "displayMilestoneupdatefrequencydays", "ui_lbl_milestoneupdatefrequencydays", "ui_img_helpTextformilestoneupdatefrequencydays", "ismilestoneupdatefrequencydays", "ui_num_milestoneupdatefrequencydays", mode);
                            break;
                        case accrualmilestoneupdatefrequencydays:
                            NumberFielddetails(response, "displayAccrualmilestoneupdatefrequencydays", "ui_lbl_accrualmilestoneupdatefrequencydays", "ui_img_helpTextforaccrualmilestoneupdatefrequencydays", "isaccrualmilestoneupdatefrequencydays", "ui_num_accrualmilestoneupdatefrequencydays", mode);
                            break;
                        case lastsendemail:
                            DropDowndetails(response, "displayLastsendemail", "ui_lbl_lastsendemail", "ui_img_helpTextforlastsendemail", "issendemail", mode);
                            break;
                        case saefrequency:
                            DropDowndetails(response, "displaySAEFrequency", "ui_lbl_SAEFrequency", "ui_img_helpTextforSAEFrequency", "isSAEFrequency", mode);
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

function LoadOtherAttributesData() {
    $.ajax({
        async: false,
        type: "GET",
        url: "/NewStudy/GetOtherAttributesData/",
        data: { attributeid: parseInt(otherattributesattributeid) },
        cache: false,
        dataType: "json",
        data: { "StudyId": $('#StudyId').val() },
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                hasdata = true;
                $("#ui_txt_conditionsofapproval,#ui_txtarea_conditionsofapproval").val(response.Data[0].Conditionsofapproval);
                $("#ui_ddl_leadorganization").data('kendoDropDownList').value(response.Data[0].Leadorganization);
                if (response.Data[0].Isamendmentrequestincludesachangeintheprimaryinvestigator == true)
                    $("#ui_chkbox_amendmentrequestincludesachangeintheprimaryinvestigator").prop('checked', true);
                if (response.Data[0].Isautoproxyenabled == true)
                    $("#ui_chkbox_autoproxyenabled").prop('checked', true);
                if (response.Data[0].Isconditionalapproval == true)
                    $("#ui_ddl_conditionalapproval").data('kendoDropDownList').value(yes);
                if (response.Data[0].Isconditionalapproval == false)
                    $("#ui_ddl_conditionalapproval").data('kendoDropDownList').value(no);
                if (response.Data[0].Isconditionalapproval == null)
                    $("#ui_ddl_conditionalapproval").data('kendoDropDownList').value("Select");
                $("#ui_ddl_ICFReview").data('kendoDropDownList').value(response.Data[0].ICFReview);
                $("#ui_ddl_amendmentstatus").data('kendoDropDownList').value(response.Data[0].Amendmentstatus);
                $("#ui_ddl_amendmenttype").data('kendoDropDownList').value(response.Data[0].Amendmenttype);
                if (response.Data[0].Contractamendmentrequired == true)
                    $("#ui_ddl_contractamendmentrequired").data('kendoDropDownList').value(yes);
                if (response.Data[0].Contractamendmentrequired == false)
                    $("#ui_ddl_contractamendmentrequired").data('kendoDropDownList').value(no);
                if (response.Data[0].Contractamendmentrequired == "@ConstDefaultValue.NOTAPPLICABLE")
                    $("#ui_ddl_contractamendmentrequired").data('kendoDropDownList').value("@ConstDefaultValue.NOTAPPLICABLE");
                if (response.Data[0].Contractamendmentrequired == null)
                    $("#ui_ddl_contractamendmentrequired").data('kendoDropDownList').value("Select");
                if (response.Data[0].Ipistudyssponsor == true)
                    $("#ui_ddl_isPIstudyssponsor").data('kendoDropDownList').value(yes);
                if (response.Data[0].Ipistudyssponsor == false)
                    $("#ui_ddl_isPIstudyssponsor").data('kendoDropDownList').value(no);
                if (response.Data[0].Ipistudyssponsor == null)
                    $("#ui_ddl_isPIstudyssponsor").data('kendoDropDownList').value("Select");
                $("#ui_dt_contractexecutiondate").data("kendoDatePicker").value(response.Data[0].ExecutionDate);
                $("#ui_dt_migrationdate").data("kendoDatePicker").value(response.Data[0].Migrationdate);
                $("#ui_ddl_conversionstatus").data('kendoDropDownList').value(response.Data[0].Conversionstatus);
                $("#ui_num_milestoneupdatefrequencydays").val(response.Data[0].Milestoneupdatefrequencydays);
                $("#ui_num_accrualmilestoneupdatefrequencydays").val(response.Data[0].Accrualmilestoneupdatefrequencydays);
                $("#ui_dt_lastsendemail").data("kendoDatePicker").value(response.Data[0].Lastsendemail);
                $("#ui_ddl_saefrequency").data('kendoDropDownList').value(response.Data[0].SaereconciliationFrequency);
            }
        },
        failure: function (response) {
            popupNotification.show(errorsinthepage, "error");
        }
    });
    return hasdata;
}