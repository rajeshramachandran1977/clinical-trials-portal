$(function () {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");

    //#region Pharmacovigilance
    $("#ui_txtarea_specifywhatsafetydata").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_specifywhatsafetydata").val().trim();
        if (str != "")
            if ($("#regexexprforspecifywhatsafetydata").val() != "") {
                var expr = new RegExp($("#regexexprforspecifywhatsafetydata").val());
                var str = $("#ui_txtarea_specifywhatsafetydata").val();
                if (str != "" && !expr.test(str)) {
                    $('#specifywhatsafetydata').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforspecifywhatsafetydata").val() + '</div>');
                    isvalidRegexforspecifywhatsafetydata = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforspecifywhatsafetydata = true;
                    return true;
                }
            }
    });
    $("#ui_txt_specifywhatsafetydata").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_specifywhatsafetydata").val().trim();
        if (str != "")
            if ($("#regexexprforspecifywhatsafetydata").val() != "") {
                var expr = new RegExp($("#regexexprforspecifywhatsafetydata").val());
                var str = $("#ui_txt_specifywhatsafetydata").val();
                if (str != "" && !expr.test(str)) {
                    $('#specifywhatsafetydata').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforspecifywhatsafetydata").val() + '</div>');
                    isvalidRegexforspecifywhatsafetydata = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforspecifywhatsafetydata = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_adverseevents").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_adverseevents").val().trim();
        if (str != "")
            if ($("#regexexprforadverseEvents").val() != "") {
                var expr = new RegExp($("#regexexprforadverseEvents").val());
                var str = $("#ui_txtarea_adverseevents").val();
                if (str != "" && !expr.test(str)) {
                    $('#adverseEvents').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforadverseEvents").val() + '</div>');
                    isvalidRegexforadverseEvents = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforadverseEvents = true;
                    return true;
                }
            }
    });
    $("#ui_txt_adverseevents").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_adverseevents").val().trim();
        if (str != "")
            if ($("#regexexprforadverseEvents").val() != "") {
                var expr = new RegExp($("#regexexprforadverseEvents").val());
                var str = $("#ui_txt_adverseevents").val();
                if (str != "" && !expr.test(str)) {
                    $('#adverseEvents').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforadverseEvents").val() + '</div>');
                    isvalidRegexforadverseEvents = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforadverseEvents = true;
                    return true;
                }
            }
    });
    //#endregion Pharmacovigilance

    function ValidatePharmacovigilanceRequirementsFields() {
        $(".error").remove();
        retval = true;
        objPharmacovigilanceRequirements = new Object();
        objPharmacovigilanceRequirements.StudyId = $('#StudyId').val();

        if ($('#displayDatacollectioninterventional').is(':visible'))
            if (sessionStorage.getItem("isdatacollectioninterventional") == "true") {
                if ($('#ui_ddl_interventionaltrial').val() == "") {
                    $('#datacollectioninterventional').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_datacollectioninterventional').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_interventionaltrial').val() == "")
                        objPharmacovigilanceRequirements.Interventionaltrialdatacollection = null;
                    else
                        objPharmacovigilanceRequirements.Interventionaltrialdatacollection = $('#ui_ddl_interventionaltrial').val();
                }
            }
            else {
                if ($('#ui_ddl_interventionaltrial').val() == "")
                    objPharmacovigilanceRequirements.Interventionaltrialdatacollection = null;
                else
                    objPharmacovigilanceRequirements.Interventionaltrialdatacollection = $('#ui_ddl_interventionaltrial').val();
            }


        if ($('#displayDatacollectionnoninterventional').is(':visible'))
            if (sessionStorage.getItem("isdatacollectionnoninterventional") == "true") {
                if ($('#ui_ddl_noninterventionalTrial').val() == "") {
                    $('#datacollectionnoninterventional').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_datacollectionnoninterventional').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_noninterventionalTrial').val() == "")
                        objPharmacovigilanceRequirements.NonInterventionaltrialdatacollection = null;
                    else
                        objPharmacovigilanceRequirements.NonInterventionaltrialdatacollection = $('#ui_ddl_noninterventionalTrial').val();
                }
            }
            else {
                if ($('#ui_ddl_noninterventionalTrial').val() == "")
                    objPharmacovigilanceRequirements.NonInterventionaltrialdatacollection = null;
                else
                    objPharmacovigilanceRequirements.NonInterventionaltrialdatacollection = $('#ui_ddl_noninterventionalTrial').val();
            }

        if ($('#displayOccurrenceofotherspecialscenarios').is(':visible'))
            if (sessionStorage.getItem("isoccurrenceofotherspecialscenarios") == "true") {
                if ($('#ui_ddl_occurrenceofotherspecialscenarios').val() == "") {
                    $('#occurrenceofotherspecialscenarios').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_occurrenceofotherspecialscenarios').html() + ' is required</div>');
                    retval = false;
                }
                else
                    if ($('#ui_ddl_occurrenceofotherspecialscenarios').val() == yes)
                        objPharmacovigilanceRequirements.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios = true;
                if ($('#ui_ddl_occurrenceofotherspecialscenarios').val() == no)
                    objPharmacovigilanceRequirements.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios = false;
                if ($('#ui_ddl_occurrenceofotherspecialscenarios').val() == "")
                    objPharmacovigilanceRequirements.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios = null;
            }
            else
                if ($('#ui_ddl_occurrenceofotherspecialscenarios').val() == yes)
                    objPharmacovigilanceRequirements.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios = true;
        if ($('#ui_ddl_occurrenceofotherspecialscenarios').val() == no)
            objPharmacovigilanceRequirements.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios = false;
        if ($('#ui_ddl_occurrenceofotherspecialscenarios').val() == "")
            objPharmacovigilanceRequirements.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios = null;

        if ($('#displaySpecifywhatsafetydata').is(':visible'))
            if (sessionStorage.getItem("isspecifywhatsafetydata") == "true") {
                if ($('#ui_txt_specifywhatsafetydata').is(':visible')) {
                    if ($('#ui_txt_specifywhatsafetydata').val() == "") {
                        $('#specifywhatsafetydata').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_specifywhatsafetydata').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_specifywhatsafetydata').is(':visible')) {
                    if ($('#ui_txtarea_specifywhatsafetydata').val() == "") {
                        $('#specifywhatsafetydata').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_specifywhatsafetydata').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_specifywhatsafetydata').is(':visible'))
                    objPharmacovigilanceRequirements.Safetydata = $('#ui_txt_specifywhatsafetydata').val().trim();
                if ($('#ui_txtarea_specifywhatsafetydata').is(':visible'))
                    objPharmacovigilanceRequirements.Safetydata = $('#ui_txtarea_specifywhatsafetydata').val().trim();
            }
            else {
                if ($('#ui_txt_specifywhatsafetydata').is(':visible'))
                    objPharmacovigilanceRequirements.Safetydata = $('#ui_txt_specifywhatsafetydata').val().trim();
                if ($('#ui_txtarea_specifywhatsafetydata').is(':visible'))
                    objPharmacovigilanceRequirements.Safetydata = $('#ui_txtarea_specifywhatsafetydata').val().trim();
            }

        if ($('#displayAdverseEvents').is(':visible'))
            if (sessionStorage.getItem("isadverseevents") == "true") {
                if ($('#ui_txt_adverseevents').is(':visible')) {
                    if ($('#ui_txt_adverseevents').val() == "") {
                        $('#adverseEvents').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_adverseEvents').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_adverseevents').is(':visible')) {
                    if ($('#ui_txtarea_adverseevents').val() == "") {
                        $('#adverseEvents').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_adverseEvents').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_adverseevents').is(':visible'))
                    objPharmacovigilanceRequirements.AdverseEventsExemptfromCollection = $('#ui_txt_adverseevents').val().trim();
                if ($('#ui_txtarea_adverseevents').is(':visible'))
                    objPharmacovigilanceRequirements.AdverseEventsExemptfromCollection = $('#ui_txtarea_adverseevents').val().trim();
            }
            else {
                if ($('#ui_txt_adverseevents').is(':visible'))
                    objPharmacovigilanceRequirements.AdverseEventsExemptfromCollection = $('#ui_txt_adverseevents').val().trim();
                if ($('#ui_txtarea_adverseevents').is(':visible'))
                    objPharmacovigilanceRequirements.AdverseEventsExemptfromCollection = $('#ui_txtarea_adverseevents').val().trim();
            }

        if ($('#displayAllnonseriousAEs').is(':visible'))
            if (sessionStorage.getItem("isallnonseriousaes") == "true") {
                if ($('#ui_ddl_allnonseriousaes').val() == "") {
                    $('#allnonseriousAEs').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_allnonseriousaes').html() + ' is required</div>');
                    retval = false;
                }
                else
                    if ($('#ui_ddl_allnonseriousaes').val() == yes)
                        objPharmacovigilanceRequirements.IsAllnonseriousAes = true;
                if ($('#ui_ddl_allnonseriousaes').val() == no)
                    objPharmacovigilanceRequirements.IsAllnonseriousAes = false;
                if ($('#ui_ddl_allnonseriousaes').val() == "")
                    objPharmacovigilanceRequirements.IsAllnonseriousAes = null;
            }
            else
                if ($('#ui_ddl_allnonseriousaes').val() == yes)
                    objPharmacovigilanceRequirements.IsAllnonseriousAes = true;
        if ($('#ui_ddl_allnonseriousaes').val() == no)
            objPharmacovigilanceRequirements.IsAllnonseriousAes = false;
        if ($('#ui_ddl_allnonseriousaes').val() == "")
            objPharmacovigilanceRequirements.IsAllnonseriousAes = null;
    }

    //#region Remove err msg on key up for non grid text fields
    $("#specifywhatsafetydata,#adverseEvents").on("keyup", function (e) {
        $(this).next("div.error").remove();
    })

    $('#datacollectioninterventional,#datacollectionnoninterventional,#occurrenceofotherspecialscenarios,#allnonseriousAEs').change(function () {
        $(this).next("div.error").remove();
    }).change();
    //#endregion

    $("#ui_btnSavePharmacovigilance").click(function (e) {        
        ValidatePharmacovigilanceRequirementsFields();
        if (validator.validate() && retval === true && isvalidRegexforspecifywhatsafetydata === true
            && isvalidRegexforadverseEvents === true)
            Savedetails(type = 5, objEditstudy = objPharmacovigilanceRequirements);
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    });

    $("#pharmacovigilance").on("click", function () {       
        $('#pharmacovigilancecontents').show();
        var isEditmode = false;
        isEditmode = LoadPharmacovigilanceData();

        if (isEditmode == true)
            LoadPharmacovigilanceAttributeValues("Edit");
        else
            LoadPharmacovigilanceAttributeValues("Create");        
    });

    function LoadPharmacovigilanceAttributeValues(mode) {
        $.ajax({
            async: true,
            type: "POST",
            url: "/NewStudy/GetAttributeValues/",
            data: { attributeid: parseInt(pharmacovigilanceattributeid) },
            cache: false,
            dataType: "json",
            success: function (response) {
                if (response.Data == '') {
                    popupNotification.show(errorsinthepage, "error");
                } else {
                    for (i = 0; i < response.length; i++) {
                        //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                        switch (response[i].FieldType) {
                            case pharmacovigilance:
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
                                            $("#ui_btnSavePharmacovigilance").attr("disabled", true);
                                    }
                                    if (iscreaterestricted == true)
                                        $("#ui_btnSavePharmacovigilance").attr("disabled", true);
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
                                            $("#ui_btnSavePharmacovigilance").attr("disabled", true);
                                    }
                                    if (iseditrestricted == true)
                                        $("#ui_btnSavePharmacovigilance").attr("disabled", true);
                                }
                                if (iscreaterestricted == true || iseditrestricted == true)
                                    $("#ui_btnSavePharmacovigilance").attr("disabled", true);
                                else
                                    $("#ui_btnSavePharmacovigilance").removeAttr("disabled");
                                break;
                            case datacollectioninterventional:
                                DropDowndetails(response, "displayDatacollectioninterventional", "ui_lbl_datacollectioninterventional", "ui_img_helpTextfordatacollectioninterventional", "isdatacollectioninterventional", mode);
                                break;
                            case datacollectionnoninterventional:
                                DropDowndetails(response, "displayDatacollectionnoninterventional", "ui_lbl_datacollectionnoninterventional", "ui_img_helpTextfordatacollectionnoninterventional", "isdatacollectionnoninterventional", mode);
                                break;
                            case occurrenceofotherspecialscenarios:
                                if (response[i].StudyType != "Interventional")
                                    DropDowndetails(response, "displayOccurrenceofotherspecialscenarios", "ui_lbl_occurrenceofotherspecialscenarios", "ui_img_helpTextforoccurrenceofotherspecialscenarios", "isoccurrenceofotherspecialscenarios", mode);
                                break;
                            case allnonseriousaes:
                                if (response[i].StudyType != "Interventional")
                                    DropDowndetails(response, "displayAllnonseriousAEs", "ui_lbl_allnonseriousaes", "ui_img_helpTextforallnonseriousaes", "isallnonseriousaes", mode);
                                break;
                            case safetydata:
                                Textdetails(response, "displaySpecifywhatsafetydata", "ui_lbl_specifywhatsafetydata", "ui_img_helpTextforspecifywhatsafetydata", "isspecifywhatsafetydata", "ui_txt_specifywhatsafetydata", "ui_txtarea_specifywhatsafetydata", "ui_lbl_charsleftforspecifywhatsafetydata", "regexexprforspecifywhatsafetydata", "validationmsgforspecifywhatsafetydata", mode);
                                break;
                            case adverseevents:
                                Textdetails(response, "displayAdverseEvents", "ui_lbl_adverseEvents", "ui_img_helpTextforadverseEvents", "isadverseevents", "ui_txt_adverseevents", "ui_txtarea_adverseevents", "ui_lbl_charsleftforadverseEvents", "regexexprforadverseEvents", "validationmsgforadverseEvents", mode);
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

    function LoadPharmacovigilanceData() {
        $.ajax({
            async: false,
            type: "GET",
            url: "/NewStudy/GetPharmacovigilanceData/",
            cache: false,
            dataType: "json",
            data: { "StudyId": $('#StudyId').val() },
            success: function (response) {
                if (response.Data == '')
                    popupNotification.show(errorsinthepage, "error");
                else {
                    hasdata = true;
                    $("#ui_ddl_interventionaltrial").data("kendoDropDownList").value(response.Data[0].Interventionaltrialdatacollection);
                    $("#ui_ddl_noninterventionalTrial").data("kendoDropDownList").value(response.Data[0].NonInterventionaltrialdatacollection);
                    if (response.Data[0].IsAllnonseriousAes == true)
                        $('#ui_ddl_occurrenceofotherspecialscenarios').data('kendoDropDownList').value(yes);
                    if (response.Data[0].IsAllnonseriousAes == false)
                        $('#ui_ddl_occurrenceofotherspecialscenarios').data('kendoDropDownList').value(no);
                    if (response.Data[0].IsAllnonseriousAes == null)
                        $('#ui_ddl_occurrenceofotherspecialscenarios').data('kendoDropDownList').value("Select");
                    if (response.Data[0].IsAllreportsdescribingtheoccurrenceofotherspecialscenarios == true)
                        $('#ui_ddl_allnonseriousaes').data('kendoDropDownList').value(yes);
                    if (response.Data[0].IsAllreportsdescribingtheoccurrenceofotherspecialscenarios == false) {
                        $('#ui_ddl_allnonseriousaes').data('kendoDropDownList').value(no);
                        $("#ui_txt_specifywhatsafetydata,#ui_txtarea_specifywhatsafetydata").val(response.Data[0].Safetydata);
                        $("#ui_txt_adverseevents,#ui_txtarea_adverseevents").val(response.Data[0].AdverseEventsExemptfromCollection);
                    }
                    if (response.Data[0].IsAllreportsdescribingtheoccurrenceofotherspecialscenarios == null)
                        $('#ui_ddl_allnonseriousaes').data('kendoDropDownList').value("Select");
                }
            },
            failure: function (response) {
                popupNotification.show(errorsinthepage, "error");
            }
        });
        return hasdata;
    }
})   