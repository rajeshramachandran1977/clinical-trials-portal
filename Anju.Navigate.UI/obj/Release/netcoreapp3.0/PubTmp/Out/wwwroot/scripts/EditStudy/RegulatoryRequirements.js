$(function () {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");

    $("#ui_txt_rationaleForINDExemption").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_rationaleForINDExemption").val().trim();
        if (str != "")
            if ($("#regexexprforrationaleForINDExemption").val() != "") {
                var expr = new RegExp($("#regexexprforrationaleForINDExemption").val());
                var str = $("#ui_txt_rationaleForINDExemption").val();
                if (str != "" && !expr.test(str)) {
                    $('#rationaleINDExemptionerrmsg').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforrationaleForINDExemption").val() + '</div>');
                    isvalidRegexforrationaleForINDExemption = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforrationaleForINDExemption = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_rationaleForINDExemption").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_rationaleForINDExemption").val().trim();
        if (str != "")
            if ($("#regexexprforrationaleForINDExemption").val() != "") {
                var expr = new RegExp($("#regexexprforrationaleForINDExemption").val());
                var str = $("#ui_txtarea_rationaleForINDExemption").val();
                if (str != "" && !expr.test(str)) {
                    $('#rationaleINDExemptionerrmsg').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforrationaleForINDExemption").val() + '</div>');
                    isvalidRegexforrationaleForINDExemption = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforrationaleForINDExemption = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_indnumber").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_indnumber").val().trim();
        if (str != "")
            if ($("#regexexprforindnumber").val() != "") {
                var expr = new RegExp($("#regexexprforindnumber").val());
                var str = $("#ui_txtarea_indnumber").val();
                if (str != "" && !expr.test(str)) {
                    $('#INDNumber').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforindnumber").val() + '</div>');
                    isvalidRegexforINDNumber = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforINDNumber = true;
                    return true;
                }
            }
    });
    $("#ui_txt_indnumber").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_indnumber").val().trim();
        if (str != "")
            if ($("#regexexprforindnumber").val() != "") {
                var expr = new RegExp($("#regexexprforindnumber").val());
                var str = $("#ui_txt_indnumber").val();
                if (str != "" && !expr.test(str)) {
                    $('#INDNumber').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforindnumber").val() + '</div>');
                    isvalidRegexforINDNumber = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforINDNumber = true;
                    return true;
                }
            }
    });

    function ValidateRegulatoryRequirementsFields() {
        $(".error").remove();
        retval = true;
        objRegulatoryRequirements = new Object();
        objRegulatoryRequirements.StudyId = $('#StudyId').val();

        if ($('#displayProposedStudyIND').is(':visible'))
            if (sessionStorage.getItem("isproposedStudyIND") == "true") {
                if ($('#ui_ddl_proposedStudyIND').val() == "") {
                    $('#proposedStudyIND').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_proposedStudyIND').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_proposedStudyIND').val() == yes)
                        objRegulatoryRequirements.IsINDSubmission = true;
                    if ($('#ui_ddl_proposedStudyIND').val() == no)
                        objRegulatoryRequirements.IsINDSubmission = false;
                    if ($('#ui_ddl_proposedStudyIND').val() == "")
                        objRegulatoryRequirements.IsINDSubmission = null;
                }
            }
            else {
                if ($('#ui_ddl_proposedStudyIND').val() == yes)
                    objRegulatoryRequirements.IsINDSubmission = true;
                if ($('#ui_ddl_proposedStudyIND').val() == no)
                    objRegulatoryRequirements.IsINDSubmission = false;
                if ($('#ui_ddl_proposedStudyIND').val() == "")
                    objRegulatoryRequirements.IsINDSubmission = null;
            }

        if ($('#displayrationaleINDExemption').is(':visible'))
            if (sessionStorage.getItem("isrationaleINDExemption") == "true") {
                if ($('#ui_txt_rationaleForINDExemption').is(':visible')) {
                    if ($('#ui_txt_rationaleForINDExemption').val() == "") {
                        $('#rationaleINDExemptionerrmsg').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_rationaleINDExemption').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_rationaleForINDExemption').is(':visible')) {
                    if ($('#ui_txtarea_rationaleForINDExemption').val() == "") {
                        $('#rationaleINDExemptionerrmsg').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_rationaleINDExemption').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_rationaleForINDExemption').is(':visible'))
                    objRegulatoryRequirements.RationaleforINDExemption = $('#ui_txt_rationaleForINDExemption').val().trim();
                if ($('#ui_txtarea_rationaleForINDExemption').is(':visible'))
                    objRegulatoryRequirements.RationaleforINDExemption = $('#ui_txtarea_rationaleForINDExemption').val().trim();
            }
            else {
                if ($('#ui_txt_rationaleForINDExemption').is(':visible'))
                    objRegulatoryRequirements.RationaleforINDExemption = $('#ui_txt_rationaleForINDExemption').val().trim();
                if ($('#ui_txtarea_rationaleForINDExemption').is(':visible'))
                    objRegulatoryRequirements.RationaleforINDExemption = $('#ui_txtarea_rationaleForINDExemption').val().trim();
            }

        if ($('#displayFinalINDStatus').is(':visible'))
            if (sessionStorage.getItem("isfinalindstatus") == "true") {
                if ($('#ui_ddl_finalindstatus').val() == "") {
                    $('#finalINDStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_finalindstatus').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_finalindstatus').val() == "")
                        objRegulatoryRequirements.FinalINDStatus = null;
                    else
                        objRegulatoryRequirements.FinalINDStatus = $('#ui_ddl_finalindstatus').val();
                }
            }
            else {
                if ($('#ui_ddl_finalindstatus').val() == "")
                    objRegulatoryRequirements.FinalINDStatus = null;
                else
                    objRegulatoryRequirements.FinalINDStatus = $('#ui_ddl_finalindstatus').val();
            }


        if ($('#displayINDNumber').is(':visible'))
            if (sessionStorage.getItem("isindnumber") == "true") {
                if ($('#ui_txt_indnumber').is(':visible')) {
                    if ($('#ui_txt_indnumber').val() == "") {
                        $('#INDNumber').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_rationaleINDExemption').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_indnumber').is(':visible')) {
                    if ($('#ui_txtarea_indnumber').val() == "") {
                        $('#INDNumber').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_rationaleINDExemption').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_indnumber').is(':visible'))
                    objRegulatoryRequirements.INDNumber = $('#ui_txt_indnumber').val().trim();
                if ($('#ui_txtarea_indnumber').is(':visible'))
                    objRegulatoryRequirements.INDNumber = $('#ui_txtarea_indnumber').val().trim();
            }
            else {
                if ($('#ui_txt_indnumber').is(':visible'))
                    objRegulatoryRequirements.INDNumber = $('#ui_txt_indnumber').val().trim();
                if ($('#ui_txtarea_indnumber').is(':visible'))
                    objRegulatoryRequirements.INDNumber = $('#ui_txtarea_indnumber').val().trim();
            }
    }

    //#region Remove err msg on key up for non grid text fields
    $("#INDNumber,#rationaleINDExemptionerrmsg").on("keyup", function (e) {
        $(this).next("div.error").remove();
    })

    $('#proposedStudyIND,#finalINDStatus').change(function () {
        $(this).next("div.error").remove();
    }).change();
    //#endregion

    $("#ui_btnSaveRegulatoryRequirements").click(function (e) {
        ValidateRegulatoryRequirementsFields();
        if (validator.validate() && retval === true &&
            isvalidRegexforrationaleForINDExemption === true && isvalidRegexforINDNumber === true)
            Savedetails(type = 9, objEditstudy = objRegulatoryRequirements);
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    });

    $("#Regulatoryrequirements").on("click", function () {
        $('#Regulatoryrequirementscontents').show();
        LoadRegulatoryrequirementsAttributeValues();
        LoadRegulatoryrequirementsData();
    });

    function LoadRegulatoryrequirementsAttributeValues() {
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
                            case issubmitanindfortheproposedstudy:
                                DropDowndetails(response, "displayProposedStudyIND", "ui_lbl_proposedStudyIND", "ui_img_helpTextforproposedStudyIND", "isproposedStudyIND");
                                break;
                            case rationaleforindexemption:
                                Textdetails(response, "displayrationaleINDExemption", "ui_lbl_rationaleINDExemption", "ui_img_helpTextforrationaleINDExemption", "isrationaleINDExemption", "ui_txt_rationaleForINDExemption", "ui_txtarea_rationaleForINDExemption", "ui_lbl_charsleftforrationaleForINDExemption", "regexexprforrationaleForINDExemption", "validationmsgforrationaleForINDExemption");
                                break;
                            case finalindstatus:
                                DropDowndetails(response, "displayFinalINDStatus", "ui_lbl_finalindstatus", "ui_img_helpTextforfinalindstatus", "isfinalindstatus");
                                break;
                            case indnumber:
                                Textdetails(response, "displayINDNumber", "ui_lbl_indnumber", "ui_img_helpTextforindnumber", "isindnumber", "ui_txt_indnumber", "ui_txtarea_indnumber", "ui_lbl_charsleftforindnumber", "regexexprforindnumber", "validationmsgforindnumber");
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

    function LoadRegulatoryrequirementsData() {
        $.ajax({
            async: true,
            type: "POST",
            url: "/NewStudy/GetRegulatoryrequirementsData/",
            cache: false,
            dataType: "json",
            data: { "StudyId": $('#StudyId').val() },
            success: function (response) {
                if (response.Data == '')
                    popupNotification.show(errorsinthepage, "error");
                else {
                    var IsIndsubmission = response.Data[0].IsIndsubmission;
                    if (IsIndsubmission == null)
                        $("#ui_ddl_proposedStudyIND").data('kendoDropDownList').value("Select");
                    else {
                        if (IsIndsubmission == true)
                            $('#ui_ddl_proposedStudyIND').data('kendoDropDownList').value(yes);
                        else
                            $('#ui_ddl_proposedStudyIND').data('kendoDropDownList').value(no);
                    }
                    if (IsIndsubmission === false) {
                        $('#rationaleINDExemption').show();
                        $("#ui_txt_rationaleForINDExemption,#ui_txtarea_rationaleForINDExemption").val(response.Data[0].RationaleforINDExemption);

                    }
                    var finalindstatus = response.Data[0].FinalINDStatus;
                    if (finalindstatus === null)
                        $("#ui_ddl_finalindstatus").data('kendoDropDownList').value("Select");
                    else
                        $("#ui_ddl_finalindstatus").data('kendoDropDownList').value(finalindstatus);
                    $("#ui_txt_indnumber,#ui_txtarea_indnumber").val(response.Data[0].INDNumber);
                }
            },
            failure: function (response) {
                popupNotification.show(errorsinthepage, "error");
            }
        });
    }
});
$(document).ready(function () {
    isvalidRegexforrationaleForINDExemption = isvalidRegexforINDNumber = true;
});