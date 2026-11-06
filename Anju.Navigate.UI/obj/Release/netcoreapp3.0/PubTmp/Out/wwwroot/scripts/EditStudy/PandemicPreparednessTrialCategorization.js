$(function () {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");

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


    function ValidatePandemicPreparednessFields() {
        $(".error").remove();
        retval = true;
        objPandemicPreparedness = new Object();
        objPandemicPreparedness.StudyId = $('#StudyId').val();

        if ($('#displayPandemicpreparednesstrialcategorization').is(':visible'))
            if (sessionStorage.getItem("ispandemicpreparednesstrialcategorization") == "true") {
                if ($('#ui_ddl_pandemicpreparednesstrialcategorization').val() == "") {
                    $('#pandemicpreparednesstrialcategorization').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_pandemicpreparednesstrialcategorization').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_pandemicpreparednesstrialcategorization').val() == "")
                        objPandemicPreparedness.TrialCategorization = null;
                    else
                        objPandemicPreparedness.TrialCategorization = $('#ui_ddl_pandemicpreparednesstrialcategorization').val();
                }
            }
            else {
                if ($('#ui_ddl_pandemicpreparednesstrialcategorization').val() == "")
                    objPandemicPreparedness.TrialCategorization = null;
                else
                    objPandemicPreparedness.TrialCategorization = $('#ui_ddl_pandemicpreparednesstrialcategorization').val();
            }


        if ($('#displaySafetymonitoringinterval').is(':visible'))
            if (sessionStorage.getItem("issafetymonitoringinterval") == "true") {
                if ($('#ui_ddl_safetymonitoringinterval').val() == "") {
                    $('#safetymonitoringinterval').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_safetymonitoringinterval').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_safetymonitoringinterval').val() == yes)
                        objPandemicPreparedness.MonitoringInterval = true;
                    if ($('#ui_ddl_safetymonitoringinterval').val() == no)
                        objPandemicPreparedness.MonitoringInterval = false;
                    if ($('#ui_ddl_safetymonitoringinterval').val() == "")
                        objPandemicPreparedness.MonitoringInterval = null;
                }
            }
            else {
                if ($('#ui_ddl_safetymonitoringinterval').val() == yes)
                    objPandemicPreparedness.MonitoringInterval = true;
                if ($('#ui_ddl_safetymonitoringinterval').val() == no)
                    objPandemicPreparedness.MonitoringInterval = false;
                if ($('#ui_ddl_safetymonitoringinterval').val() == "")
                    objPandemicPreparedness.MonitoringInterval = null;
            }

        if ($('#displayMaximumallowabletimebetweenvisits').is(':visible'))
            if (sessionStorage.getItem("issafetymaximumallowabletimebetweenvisits") == "true") {
                if ($('#ui_txt_maximumallowabletimebetweenvisits').is(':visible')) {
                    if ($('#ui_txt_maximumallowabletimebetweenvisits').val() == "") {
                        $('#maximumallowabletimebetweenvisits').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_safetymaximumallowabletimebetweenvisits').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_maximumallowabletimebetweenvisits').is(':visible')) {
                    if ($('#ui_txtarea_maximumallowabletimebetweenvisits').val() == "") {
                        $('#maximumallowabletimebetweenvisits').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_safetymaximumallowabletimebetweenvisits').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_maximumallowabletimebetweenvisits').is(':visible'))
                    objPandemicPreparedness.MaximumAllowableVists = $('#ui_txt_maximumallowabletimebetweenvisits').val().trim();
                if ($('#ui_txtarea_maximumallowabletimebetweenvisits').is(':visible'))
                    objPandemicPreparedness.MaximumAllowableVists = $('#ui_txtarea_maximumallowabletimebetweenvisits').val().trim();
            }
            else {
                if ($('#ui_txt_maximumallowabletimebetweenvisits').is(':visible'))
                    objPandemicPreparedness.MaximumAllowableVists = $('#ui_txt_maximumallowabletimebetweenvisits').val().trim();
                if ($('#ui_txtarea_maximumallowabletimebetweenvisits').is(':visible'))
                    objPandemicPreparedness.MaximumAllowableVists = $('#ui_txtarea_maximumallowabletimebetweenvisits').val().trim();
            }
    }

    //#region Remove err msg on key up for non grid text fields
    $("#maximumallowabletimebetweenvisits").on("keyup", function (e) {
        $(this).next("div.error").remove();
    })

    $('#pandemicpreparednesstrialcategorization,#safetymonitoringinterval').change(function () {
        $(this).next("div.error").remove();
    }).change();
    //#endregion

    $("#ui_btnSavePandemicPreparedness").click(function (e) {
        ValidatePandemicPreparednessFields();
        if (validator.validate() && retval === true && isvalidRegexformaximumallowabletimebetweenvisits === true)
            Savedetails(type = 8, objEditstudy = objPandemicPreparedness);
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    });

    $("#Pandemicpreparednesstrialcategorization").on("click", function () {
        $('#Pandemicpreparednesstrialcategorizationcontents').show();
        LoadPandemicpreparednesstrialcategorizationAttributeValues();
        LoadPandemicpreparednesstrialcategorizationData();
    });

    function LoadPandemicpreparednesstrialcategorizationAttributeValues() {
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
                            case panademicpreparednesstrialcategorization:
                                DropDowndetails(response, "displayPandemicpreparednesstrialcategorization", "ui_lbl_pandemicpreparednesstrialcategorization", "ui_img_helpTextforpandemicpreparednesstrialcategorization", "ispandemicpreparednesstrialcategorization");
                                break;
                            case issafetymonitoringinterval:
                                DropDowndetails(response, "displaySafetymonitoringinterval", "ui_lbl_safetymonitoringinterval", "ui_img_helpTextforsafetymonitoringinterval", "issafetymonitoringinterval");
                                break;
                            case maximumallowabletimebetweenvisits:
                                Textdetails(response, "displayMaximumallowabletimebetweenvisits", "ui_lbl_safetymaximumallowabletimebetweenvisits", "ui_img_helpTextformaximumallowabletimebetweenvisits", "issafetymaximumallowabletimebetweenvisits", "ui_txt_maximumallowabletimebetweenvisits", "ui_txtarea_maximumallowabletimebetweenvisits", "ui_lbl_charsleftformaximumallowabletimebetweenvisits", "regexexprformaximumallowabletimebetweenvisits", "validationmsgformaximumallowabletimebetweenvisits");
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

    function LoadPandemicpreparednesstrialcategorizationData() {
        $.ajax({
            async: true,
            type: "POST",
            url: "/NewStudy/GetPandemicpreparednesstrialcategorizationData/",
            cache: false,
            dataType: "json",
            data: { "StudyId": $('#StudyId').val() },
            success: function (response) {
                if (response.Data == '')
                    popupNotification.show(errorsinthepage, "error");
                else {
                    var PandemicPreparednessTrialCategorization = response.Data[0].TrialCategorization;
                    if (PandemicPreparednessTrialCategorization === null)
                        $("#ui_ddl_pandemicpreparednesstrialcategorization").data('kendoDropDownList').value("Select");
                    else
                        $("#ui_ddl_pandemicpreparednesstrialcategorization").data('kendoDropDownList').value(PandemicPreparednessTrialCategorization);
                    var SafetyMonitoringInterval = response.Data[0].MonitoringInterval;
                    if (SafetyMonitoringInterval === null)
                        $("#ui_ddl_safetymonitoringinterval").data('kendoDropDownList').value("Select");
                    else {
                        if (SafetyMonitoringInterval == true)
                            $('#ui_ddl_safetymonitoringinterval').data('kendoDropDownList').value(yes);
                        else
                            $('#ui_ddl_safetymonitoringinterval').data('kendoDropDownList').value(no);
                    }
                    $("#ui_txt_maximumallowabletimebetweenvisits,#ui_txtarea_maximumallowabletimebetweenvisits").val(response.Data[0].MaximumAllowableVists);
                }
            },
            failure: function (response) {
                popupNotification.show(errorsinthepage, "error");
            }
        });
    }
});