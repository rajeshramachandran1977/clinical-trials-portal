$(function () {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");

    //#region Original Financial Request
    $("#ui_txt_othersupportdescription").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_othersupportdescription").val().trim();
        if (str != "")
            if ($("#regexexprforothersupportdescription").val() != "") {
                var expr = new RegExp($("#regexexprforothersupportdescription").val());
                var str = $("#ui_txt_othersupportdescription").val();
                if (str != "" && !expr.test(str)) {
                    $('#othersupportdescription').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforothersupportdescription").val() + '</div>');
                    isvalidRegexforothersupportdescription = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforothersupportdescription = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_othersupportdescription").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_othersupportdescription").val().trim();
        if (str != "")
            if ($("#regexexprforothersupportdescription").val() != "") {
                var expr = new RegExp($("#regexexprforothersupportdescription").val());
                var str = $("#ui_txtarea_othersupportdescription").val();
                if (str != "" && !expr.test(str)) {
                    $('#othersupportdescription').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforothersupportdescription").val() + '</span>');
                    isvalidRegexforothersupportdescription = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforothersupportdescription = true;
                    return true;
                }
            }
    });

    $("#ui_txt_governmentsupportdescription").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_governmentsupportdescription").val().trim();
        if (str != "")
            if ($("#regexexprforgovernmentsupportdescription").val() != "") {
                var expr = new RegExp($("#regexexprforgovernmentsupportdescription").val());
                var str = $("#ui_txt_governmentsupportdescription").val();
                if (str != "" && !expr.test(str)) {
                    $('#governmentsupportdescription').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforgovernmentsupportdescription").val() + '</div>');
                    isvalidRegexforgovernmentsupportdescription = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforgovernmentsupportdescription = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_governmentsupportdescription").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_governmentsupportdescription").val().trim();
        if (str != "")
            if ($("#regexexprforgovernmentsupportdescription").val() != "") {
                var expr = new RegExp($("#regexexprforgovernmentsupportdescription").val());
                var str = $("#ui_txtarea_governmentsupportdescription").val();
                if (str != "" && !expr.test(str)) {
                    $('#governmentsupportdescription').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforgovernmentsupportdescription").val() + '</div>');
                    isvalidRegexforgovernmentsupportdescription = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforgovernmentsupportdescription = true;
                    return true;
                }
            }
    });

    $("#ui_txt_noncompanysupportsources").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_noncompanysupportsources").val().trim();
        if (str != "")
            if ($("#regexexprfornoncompanysupportsources").val() != "") {
                var expr = new RegExp($("#regexexprfornoncompanysupportsources").val());
                var str = $("#ui_txt_noncompanysupportsources").val();
                if (str != "" && !expr.test(str)) {
                    $('#noncompanysupportsources').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfornoncompanysupportsources").val() + '</div>');
                    isvalidRegexfornoncompanysupportsources = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfornoncompanysupportsources = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_noncompanysupportsources").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_noncompanysupportsources").val().trim();
        if (str != "")
            if ($("#regexexprfornoncompanysupportsources").val() != "") {
                var expr = new RegExp($("#regexexprfornoncompanysupportsources").val());
                var str = $("#ui_txtarea_noncompanysupportsources").val();
                if (str != "" && !expr.test(str)) {
                    $('#noncompanysupportsources').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfornoncompanysupportsources").val() + '</div>');
                    isvalidRegexfornoncompanysupportsources = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfornoncompanysupportsources = true;
                    return true;
                }
            }
    });

    //#endregion Original Financial Request

    function ValidateOriginalFinancialRequestFields() {
        $(".error").remove();
        retval = true;
        objectOriginalFinancialRequest = new Object();
        objectOriginalFinancialRequest.StudyId = $('#StudyId').val();

        if ($('#displayAreyourequestingacompanystudycompound').is(':visible'))
            if (sessionStorage.getItem("isrequestingacompanystudycompound") == "true") {
                if ($('#ui_ddl_areyourequestingacompanystudycompound').val() == "") {
                    $('#areyourequestingacompanystudycompound').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_areyourequestingacompanystudycompound').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_areyourequestingacompanystudycompound').val() == yes)
                        objectOriginalFinancialRequest.Isrequestingacompanystudycompound = true;
                    if ($('#ui_ddl_areyourequestingacompanystudycompound').val() == no)
                        objectOriginalFinancialRequest.Isrequestingacompanystudycompound = false;
                    if ($('#ui_ddl_areyourequestingacompanystudycompound').val() == "")
                        objectOriginalFinancialRequest.Isrequestingacompanystudycompound = null;
                }
            }
            else {
                if ($('#ui_ddl_areyourequestingacompanystudycompound').val() == yes)
                    objectOriginalFinancialRequest.Isrequestingacompanystudycompound = true;
                if ($('#ui_ddl_areyourequestingacompanystudycompound').val() == no)
                    objectOriginalFinancialRequest.Isrequestingacompanystudycompound = false;
                if ($('#ui_ddl_areyourequestingacompanystudycompound').val() == "")
                    objectOriginalFinancialRequest.Isrequestingacompanystudycompound = null;
            }

        if ($('#displayAreyourequestingstudyfunding').is(':visible'))
            if (sessionStorage.getItem("isareyourequestingstudyfunding") == "true") {
                if ($('#ui_ddl_areyourequestingstudyfunding').val() == "") {
                    $('#areyourequestingstudyfunding').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_areyourequestingstudyfunding').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_areyourequestingstudyfunding').val() == yes)
                        objectOriginalFinancialRequest.IsRequestedForFinancialSupport = true;
                    if ($('#ui_ddl_areyourequestingstudyfunding').val() == no)
                        objectOriginalFinancialRequest.IsRequestedForFinancialSupport = false;
                    if ($('#ui_ddl_areyourequestingstudyfunding').val() == "")
                        objectOriginalFinancialRequest.IsRequestedForFinancialSupport = null;
                }
            }
            else {
                if ($('#ui_ddl_areyourequestingstudyfunding').val() == yes)
                    objectOriginalFinancialRequest.IsRequestedForFinancialSupport = true;
                if ($('#ui_ddl_areyourequestingstudyfunding').val() == no)
                    objectOriginalFinancialRequest.IsRequestedForFinancialSupport = false;
                if ($('#ui_ddl_areyourequestingstudyfunding').val() == "")
                    objectOriginalFinancialRequest.IsRequestedForFinancialSupport = null;
            }

        if ($('#displayWillsupportbeprovidedfromothersources').is(':visible'))
            if (sessionStorage.getItem("issupportbeprovidedfromothersources") == "true") {
                if ($('#ui_ddl_willsupportbeprovidedfromothersources').val() == "") {
                    $('#willsupportbeprovidedfromothersources').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_willsupportbeprovidedfromothersources').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_willsupportbeprovidedfromothersources').val() == yes)
                        objectOriginalFinancialRequest.IsSupportProvidedByOtherSources = true;
                    if ($('#ui_ddl_willsupportbeprovidedfromothersources').val() == no)
                        objectOriginalFinancialRequest.IsSupportProvidedByOtherSources = false;
                    if ($('#ui_ddl_willsupportbeprovidedfromothersources').val() == "")
                        objectOriginalFinancialRequest.IsSupportProvidedByOtherSources = null;
                }
            }
            else {
                if ($('#ui_ddl_willsupportbeprovidedfromothersources').val() == yes)
                    objectOriginalFinancialRequest.IsSupportProvidedByOtherSources = true;
                if ($('#ui_ddl_willsupportbeprovidedfromothersources').val() == no)
                    objectOriginalFinancialRequest.IsSupportProvidedByOtherSources = false;
                if ($('#ui_ddl_willsupportbeprovidedfromothersources').val() == "")
                    objectOriginalFinancialRequest.IsSupportProvidedByOtherSources = null;
            }

        if ($('#displayOthersupportdescription').is(':visible'))
            if (sessionStorage.getItem("isothersupportdescription") == "true") {
                if ($('#ui_txt_othersupportdescription').is(':visible')) {
                    if ($('#ui_txt_othersupportdescription').val() == "") {
                        $('#othersupportdescription').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_othersupportdescription').html() + ' is required</span>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_othersupportdescription').is(':visible')) {
                    if ($('#ui_txtarea_othersupportdescription').val() == "") {
                        $('#othersupportdescription').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_othersupportdescription').html() + ' is required</span>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_othersupportdescription').is(':visible'))
                    objectOriginalFinancialRequest.Othersupportdescription = $('#ui_txt_othersupportdescription').val().trim();
                if ($('#ui_txtarea_othersupportdescription').is(':visible'))
                    objectOriginalFinancialRequest.Othersupportdescription = $('#ui_txtarea_othersupportdescription').val().trim();
            }
            else {
                if ($('#ui_txt_othersupportdescription').is(':visible'))
                    objectOriginalFinancialRequest.Othersupportdescription = $('#ui_txt_othersupportdescription').val().trim();
                if ($('#ui_txtarea_othersupportdescription').is(':visible'))
                    objectOriginalFinancialRequest.Othersupportdescription = $('#ui_txtarea_othersupportdescription').val().trim();
            }

        if ($('#displayWillgovernmentsupportbeprovided').is(':visible'))
            if (sessionStorage.getItem("isgovernmentsupportbeprovided") == "true") {
                if ($('#ui_ddl_willgovernmentsupportbeprovided').val() == "") {
                    $('#willgovernmentsupportbeprovided').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_willgovernmentsupportbeprovided').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_willgovernmentsupportbeprovided').val() == yes)
                        objectOriginalFinancialRequest.IsGovernmentSupportProvided = true;
                    if ($('#ui_ddl_willgovernmentsupportbeprovided').val() == no)
                        objectOriginalFinancialRequest.IsGovernmentSupportProvided = false;
                    if ($('#ui_ddl_willgovernmentsupportbeprovided').val() == "")
                        objectOriginalFinancialRequest.IsGovernmentSupportProvided = null;
                }
            }
            else {
                if ($('#ui_ddl_willgovernmentsupportbeprovided').val() == yes)
                    objectOriginalFinancialRequest.IsGovernmentSupportProvided = true;
                if ($('#ui_ddl_willgovernmentsupportbeprovided').val() == no)
                    objectOriginalFinancialRequest.IsGovernmentSupportProvided = false;
                if ($('#ui_ddl_willgovernmentsupportbeprovided').val() == "")
                    objectOriginalFinancialRequest.IsGovernmentSupportProvided = null;
            }

        if ($('#displayOriginalrequestedstudyamount').is(':visible'))
            if (sessionStorage.getItem("isoriginalrequestedstudyamount") == "true") {
                if ($('#ui_num_originalrequestedstudyamount').val() == "") {
                    $('#originalrequestedstudyamount').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_originalrequestedstudyamount').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_num_originalrequestedstudyamount').val() == "")
                        objectOriginalFinancialRequest.BudgetRequestedForTrial = null;
                    else
                        objectOriginalFinancialRequest.BudgetRequestedForTrial = $('#ui_num_originalrequestedstudyamount').val().trim();
                }
            }
            else {
                if ($('#ui_num_originalrequestedstudyamount').val() == "")
                    objectOriginalFinancialRequest.BudgetRequestedForTrial = null;
                else
                    objectOriginalFinancialRequest.BudgetRequestedForTrial = $('#ui_num_originalrequestedstudyamount').val().trim();
            }

        if ($('#displayGovernmentsupportdescription').is(':visible'))
            if (sessionStorage.getItem("isgovtsupportdescription") == "true") {
                if ($('#ui_txt_governmentsupportdescription').is(':visible')) {
                    if ($('#ui_txt_governmentsupportdescription').val() == "") {
                        $('#governmentsupportdescription').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_governmentsupportdescription').html() + ' is required</span>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_governmentsupportdescription').is(':visible')) {
                    if ($('#ui_txtarea_governmentsupportdescription').val() == "") {
                        $('#governmentsupportdescription').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_governmentsupportdescription').html() + ' is required</span>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_governmentsupportdescription').is(':visible'))
                    objectOriginalFinancialRequest.SupportDescription = $('#ui_txt_governmentsupportdescription').val().trim();
                if ($('#ui_txtarea_governmentsupportdescription').is(':visible'))
                    objectOriginalFinancialRequest.SupportDescription = $('#ui_txtarea_governmentsupportdescription').val().trim();
            }
            else {
                if ($('#ui_txt_governmentsupportdescription').is(':visible'))
                    objectOriginalFinancialRequest.SupportDescription = $('#ui_txt_governmentsupportdescription').val().trim();
                if ($('#ui_txtarea_governmentsupportdescription').is(':visible'))
                    objectOriginalFinancialRequest.SupportDescription = $('#ui_txtarea_governmentsupportdescription').val().trim();
            }

        if ($('#displayAreyourequestingsupportfromcompanyotherthandrugorfunding').is(':visible'))
            if (sessionStorage.getItem("isrequestingsupportfromcompanyotherthandrugorfunding") == "true") {
                if ($('#ui_ddl_areyourequestingsupportfromcompanyotherthandrugorfunding').val() == "") {
                    $('#areyourequestingsupportfromcompanyotherthandrugorfunding').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_areyourequestingsupportfromcompanyotherthandrugorfunding').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_areyourequestingsupportfromcompanyotherthandrugorfunding').val() == yes)
                        objectOriginalFinancialRequest.Isrequestingsupportfromcompanyotherthandrugorfunding = true;
                    if ($('#ui_ddl_areyourequestingsupportfromcompanyotherthandrugorfunding').val() == no)
                        objectOriginalFinancialRequest.Isrequestingsupportfromcompanyotherthandrugorfunding = false;
                    if ($('#ui_ddl_areyourequestingsupportfromcompanyotherthandrugorfunding').val() == "")
                        objectOriginalFinancialRequest.Isrequestingsupportfromcompanyotherthandrugorfunding = null;
                }
            }
            else {
                if ($('#ui_ddl_areyourequestingsupportfromcompanyotherthandrugorfunding').val() == yes)
                    objectOriginalFinancialRequest.Isrequestingsupportfromcompanyotherthandrugorfunding = true;
                if ($('#ui_ddl_areyourequestingsupportfromcompanyotherthandrugorfunding').val() == no)
                    objectOriginalFinancialRequest.Isrequestingsupportfromcompanyotherthandrugorfunding = false;
                if ($('#ui_ddl_areyourequestingsupportfromcompanyotherthandrugorfunding').val() == "")
                    objectOriginalFinancialRequest.Isrequestingsupportfromcompanyotherthandrugorfunding = null;
            }

        if ($('#displayNoncompanysupportsources').is(':visible'))
            if (sessionStorage.getItem("isnoncompanysupportsources") == "true") {
                if ($('#ui_txt_noncompanysupportsources').is(':visible')) {
                    if ($('#ui_txt_noncompanysupportsources').val() == "") {
                        $('#noncompanysupportsources').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_noncompanysupportsources').html() + ' is required</span>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_noncompanysupportsources').is(':visible')) {
                    if ($('#ui_txtarea_noncompanysupportsources').val() == "") {
                        $('#noncompanysupportsources').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_noncompanysupportsources').html() + ' is required</span>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_noncompanysupportsources').is(':visible'))
                    objectOriginalFinancialRequest.SupportSources = $('#ui_txt_noncompanysupportsources').val().trim();
                if ($('#ui_txtarea_noncompanysupportsources').is(':visible'))
                    objectOriginalFinancialRequest.SupportSources = $('#ui_txtarea_noncompanysupportsources').val().trim();
            }
            else {
                if ($('#ui_txt_noncompanysupportsources').is(':visible'))
                    objectOriginalFinancialRequest.SupportSources = $('#ui_txt_noncompanysupportsources').val().trim();
                if ($('#ui_txtarea_noncompanysupportsources').is(':visible'))
                    objectOriginalFinancialRequest.SupportSources = $('#ui_txtarea_noncompanysupportsources').val().trim();
            }

        if ($('#displayGlobalfundingrequested').is(':visible'))
            if (sessionStorage.getItem("isglobalfundingrequested") == "true") {
                if ($('#ui_num_globalfundingrequested').val() == "") {
                    $('#globalfundingrequested').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_Globalfundingrequested').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_num_globalfundingrequested').val() == "")
                        objectOriginalFinancialRequest.Globalfundingrequested = null;
                    else
                        objectOriginalFinancialRequest.Globalfundingrequested = $('#ui_num_globalfundingrequested').val().trim();
                }
            }
            else {
                if ($('#ui_num_globalfundingrequested').val() == "")
                    objectOriginalFinancialRequest.Globalfundingrequested = null;
                else
                    objectOriginalFinancialRequest.Globalfundingrequested = $('#ui_num_globalfundingrequested').val().trim();
            }
    }

    //#region Remove err msg on key up for non grid text fields
    $("#othersupportdescription,#originalrequestedstudyamount,#governmentsupportdescription, \
          #noncompanysupportsources,#globalfundingrequested").on("keyup", function (e) {
        $(this).next("div.error").remove();
    })

    $('#areyourequestingacompanystudycompound,#areyourequestingstudyfunding,#willsupportbeprovidedfromothersources \
          #willgovernmentsupportbeprovided,#areyourequestingsupportfromcompanyotherthandrugorfunding').change(function () {
        $(this).next("div.error").remove();
    }).change();
    //#endregion

    $("#ui_btnSaveoriginalfinancialrequestdetails").click(function (e) {       
        ValidateOriginalFinancialRequestFields();       
        if (validator.validate() && retval === true && (isvalidRegexfornoncompanysupportsources === true
            && isvalidRegexforgovernmentsupportdescription === true && isvalidRegexforothersupportdescription === true))
            Savedetails(type = 21, objEditstudy = objectOriginalFinancialRequest);
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    });

    $("#originalfinancialrequest").on("click", function () {
        $('#originalfinancialrequestdetailscontents').show();
        var isEditmode = false;
        isEditmode = LoadoriginalfinancialrequestData();

        if (isEditmode == true)
            LoadoriginalfinancialrequestAttributeValues("Edit");
        else
            LoadoriginalfinancialrequestAttributeValues("Create");
    });

    function LoadoriginalfinancialrequestAttributeValues(mode) {
        $.ajax({
            async: true,
            type: "POST",
            url: "/NewStudy/GetAttributeValues/",
            data: { attributeid: parseInt(originalfinancialrequestattributeid) },
            cache: false,
            dataType: "json",
            success: function (response) {
                if (response.Data == '') {
                    popupNotification.show(errorsinthepage, "error");
                } else {
                    for (i = 0; i < response.length; i++) {

                        //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                        switch (response[i].FieldType) {
                            case originalfinancialrequest:
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
                                            $("#ui_btnSaveoriginalfinancialrequestdetails").attr("disabled", true);
                                    }
                                    if (iscreaterestricted == true)
                                        $("#ui_btnSaveoriginalfinancialrequestdetails").attr("disabled", true);
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
                                            $("#ui_btnSaveoriginalfinancialrequestdetails").attr("disabled", true);
                                    }
                                    if (iseditrestricted == true)
                                        $("#ui_btnSaveoriginalfinancialrequestdetails").attr("disabled", true);
                                }
                                if (iscreaterestricted == true || iseditrestricted == true)
                                    $("#ui_btnSaveoriginalfinancialrequestdetails").attr("disabled", true);
                                else
                                    $("#ui_btnSaveoriginalfinancialrequestdetails").removeAttr("disabled");
                                break;
                            case isrequestingacompanystudycompound:
                                DropDowndetails(response, "displayAreyourequestingacompanystudycompound", "ui_lbl_areyourequestingacompanystudycompound", "ui_img_helpTextforareyourequestingacompanystudycompound", "isrequestingacompanystudycompound", mode);
                                break;
                            case isrequestingstudyfunding:
                                DropDowndetails(response, "displayAreyourequestingstudyfunding", "ui_lbl_areyourequestingstudyfunding", "ui_img_helpTextforareyourequestingstudyfunding", "isareyourequestingstudyfunding", mode);
                                break;
                            case issupportbeprovidedfromothersources:
                                DropDowndetails(response, "displayWillsupportbeprovidedfromothersources", "ui_lbl_willsupportbeprovidedfromothersources", "ui_img_helpTextforwillsupportbeprovidedfromothersources", "issupportbeprovidedfromothersources", mode);
                                break;
                            case othersupportdescription:
                                Textdetails(response, "displayOthersupportdescription", "ui_lbl_othersupportdescription", "ui_img_helpTextforothersupportdescription", "isothersupportdescription", "ui_txt_othersupportdescription", "ui_txtarea_othersupportdescription", "ui_lbl_charsleftforothersupportdescription", "regexexprforothersupportdescription", "validationmsgforothersupportdescription", mode);
                                break;
                            case isgovernmentsupportbeprovided:
                                DropDowndetails(response, "displayWillgovernmentsupportbeprovided", "ui_lbl_willgovernmentsupportbeprovided", "ui_img_helpTextforwillgovernmentsupportbeprovided", "isgovernmentsupportbeprovided", mode);
                                break;
                            case originalrequestedstudyamount:
                                NumberFielddetails(response, "displayOriginalrequestedstudyamount", "ui_lbl_originalrequestedstudyamount", "ui_img_helpTextfororiginalrequestedstudyamount", "isoriginalrequestedstudyamount", "ui_num_originalrequestedstudyamount", mode);
                                break;
                            case governmentsupportdescription:
                                Textdetails(response, "displayGovernmentsupportdescription", "ui_lbl_governmentsupportdescription", "ui_img_governmentsupportdescription", "isgovtsupportdescription", "ui_txt_governmentsupportdescription", "ui_txtarea_governmentsupportdescription", "ui_lbl_charsleftforgovernmentsupportdescription", "regexexprforgovernmentsupportdescription", "validationmsgforgovernmentsupportdescription", mode);
                                break;
                            case isrequestingsupportfromcompanyotherthandrugorfunding:
                                DropDowndetails(response, "displayAreyourequestingsupportfromcompanyotherthandrugorfunding", "ui_lbl_areyourequestingsupportfromcompanyotherthandrugorfunding", "ui_img_helpTextforareyourequestingsupportfromcompanyotherthandrugorfunding", "isrequestingsupportfromcompanyotherthandrugorfunding", mode);
                                break;
                            case noncompanysupportsources:
                                Textdetails(response, "displayNoncompanysupportsources", "ui_lbl_noncompanysupportsources", "ui_img_noncompanysupportsources", "isnoncompanysupportsources", "ui_txt_noncompanysupportsources", "ui_txtarea_noncompanysupportsources", "regexexprfornoncompanysupportsources", "validationmsgfornoncompanysupportsources", mode);
                                break;
                            case globalfundingrequested:
                                NumberFielddetails(response, "displayGlobalfundingrequested", "ui_lbl_Globalfundingrequested", "ui_img_helpTextforglobalfundingrequested", "isglobalfundingrequested", "ui_num_globalfundingrequested", mode);
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

    function LoadoriginalfinancialrequestData() {
        $.ajax({
            async: false,
            type: "GET",
            url: "/NewStudy/GetoriginalfinancialrequestData/",
            cache: false,
            dataType: "json",
            data: { "StudyId": $('#StudyId').val() },
            success: function (response) {
                if (response.Data == '')
                    popupNotification.show(errorsinthepage, "error");
                else {
                    hasdata = true;
                    var Isrequestingacompanystudycompound = response.Data[0].Isrequestingacompanystudycompound;
                    if (Isrequestingacompanystudycompound === null)
                        $("#ui_ddl_areyourequestingacompanystudycompound").data('kendoDropDownList').value("");
                    else {
                        if (Isrequestingacompanystudycompound == true)
                            $('#ui_ddl_areyourequestingacompanystudycompound').data('kendoDropDownList').value(yes);
                        else
                            $('#ui_ddl_areyourequestingacompanystudycompound').data('kendoDropDownList').value(no);
                    }
                    var IsRequestedForFinancialSupport = response.Data[0].IsRequestedForFinancialSupport;
                    if (IsRequestedForFinancialSupport === null)
                        $("#ui_ddl_areyourequestingstudyfunding").data('kendoDropDownList').value("");
                    else {
                        if (IsRequestedForFinancialSupport == true)
                            $('#ui_ddl_areyourequestingstudyfunding').data('kendoDropDownList').value(yes);
                        else
                            $('#ui_ddl_areyourequestingstudyfunding').data('kendoDropDownList').value(no);
                    }
                    var IsSupportProvidedByOtherSources = response.Data[0].IsSupportProvidedByOtherSources;
                    if (IsSupportProvidedByOtherSources === null)
                        $("#ui_ddl_willsupportbeprovidedfromothersources").data('kendoDropDownList').value("");
                    else {
                        if (IsSupportProvidedByOtherSources == true)
                            $('#ui_ddl_willsupportbeprovidedfromothersources').data('kendoDropDownList').value(yes);
                        else
                            $('#ui_ddl_willsupportbeprovidedfromothersources').data('kendoDropDownList').value(no);
                    }
                    $("#ui_txtarea_othersupportdescription,#ui_txt_othersupportdescription").val(response.Data[0].Othersupportdescription);
                    var IsGovernmentSupportProvided = response.Data[0].IsGovernmentSupportProvided;
                    if (IsGovernmentSupportProvided === null)
                        $("#ui_ddl_willgovernmentsupportbeprovided").data('kendoDropDownList').value("");
                    else {
                        if (IsGovernmentSupportProvided == true)
                            $('#ui_ddl_willgovernmentsupportbeprovided').data('kendoDropDownList').value(yes);
                        else
                            $('#ui_ddl_willgovernmentsupportbeprovided').data('kendoDropDownList').value(no);
                    }
                    $("#ui_num_originalrequestedstudyamount").val(response.Data[0].BudgetRequestedForTrial);
                    $("#ui_txtarea_governmentsupportdescription,#ui_txt_governmentsupportdescription").val(response.Data[0].SupportDescription);
                    var Isrequestingsupportfromcompanyotherthandrugorfunding = response.Data[0].Isrequestingsupportfromcompanyotherthandrugorfunding;
                    if (Isrequestingsupportfromcompanyotherthandrugorfunding === null)
                        $("#ui_ddl_areyourequestingsupportfromcompanyotherthandrugorfunding").data('kendoDropDownList').value("");
                    else {
                        if (Isrequestingsupportfromcompanyotherthandrugorfunding == true)
                            $('#ui_ddl_areyourequestingsupportfromcompanyotherthandrugorfunding').data('kendoDropDownList').value(yes);
                        else
                            $('#ui_ddl_areyourequestingsupportfromcompanyotherthandrugorfunding').data('kendoDropDownList').value(no);
                    }
                    $("#ui_txtarea_noncompanysupportsources,#ui_txt_noncompanysupportsources").val(response.Data[0].SupportSources);
                    $("#ui_num_globalfundingrequested").val(response.Data[0].Globalfundingrequested);
                }
            },
            failure: function (response) {
                popupNotification.show(errorsinthepage, "error");
            }
        });
        return hasdata;
    }
})