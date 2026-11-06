$(function () {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");

    //#region keyreferences
    $("#ui_txt_keyreferences").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_keyreferences").val().trim();
        if (str != "")
            if ($("#regexexprforkeyreferences").val() != "") {
                var expr = new RegExp($("#regexexprforkeyreferences").val());
                var str = $("#ui_txt_keyreferences").val();
                if (str != "" && !expr.test(str)) {
                    $('#keyreferenceserrmsg').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforkeyreferences").val() + '</div>');
                    isvalidRegexforKeyreferences = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforKeyreferences = true;
                    return true;
                }
            }
    });
    //#endregion keyreferences

    $("#keyreferences").on("keyup", function (e) {
        $(this).next("div.error").remove();
    })

    function ValidateKeyReferenceFields() {
        $(".error").remove();
        retval = true;
        objKeyReference = new Object();
        objKeyReference.StudyId = $('#StudyId').val();

        if ($('#displayKeyReferences').is(':visible'))
            if (sessionStorage.getItem("iskeyreferences") == "true") {
                if ($('#ui_txt_keyreferences').is(':visible')) {
                    if ($('#ui_txt_keyreferences').val() == "") {
                        $('#keyreferenceserrmsg').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_keyreferencestab').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_keyreferences').is(':visible'))
                    objKeyReference.KeyReferences = $('#ui_txt_keyreferences').val().trim();
            }
            else {
                if ($('#ui_txt_keyreferences').is(':visible'))
                    objKeyReference.KeyReferences = $('#ui_txt_keyreferences').val().trim();
            }
    }

    $("#ui_btnSaveKeyreferences").click(function (e) {
        ValidateKeyReferenceFields();
        if (validator.validate() && retval === true && isvalidRegexforKeyreferences === true)
            Savedetails(type = 10, objEditstudy = objKeyReference);
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    });

    $("#keyreferences").on("click", function () {
        $('#keyreferencescontents').show();
        var isEditmode = false;
        isEditmode = LoadkeyreferencesData();

        if (isEditmode == true)
            LoadkeyreferencesAttributeValues("Edit");
        else
            LoadkeyreferencesAttributeValues("Create");      
    });

    function LoadkeyreferencesAttributeValues(mode) {
        $.ajax({
            async: true,
            type: "GET",
            url: "/NewStudy/GetAttributeValues/",
            data: { attributeid: parseInt(keyreferencesattributeid) },
            cache: false,
            dataType: "json",
            success: function (response) {
                if (response.Data == '') {
                    popupNotification.show(errorsinthepage, "error");
                } else {
                    for (i = 0; i < response.length; i++) {

                        //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                        switch (response[i].FieldType) {
                            case keyreferrencestab:
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
                                            $("#ui_btnSaveKeyreferences").attr("disabled", true);
                                    }
                                    if (iscreaterestricted == true)
                                        $("#ui_btnSaveKeyreferences").attr("disabled", true);
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
                                            $("#ui_btnSaveKeyreferences").attr("disabled", true);
                                    }
                                    if (iseditrestricted == true)
                                        $("#ui_btnSaveKeyreferences").attr("disabled", true);
                                }
                                if (iscreaterestricted == true || iseditrestricted == true)
                                    $("#ui_btnSaveKeyreferences").attr("disabled", true);
                                else
                                    $("#ui_btnSaveKeyreferences").removeAttr("disabled");
                                break;
                            case keyreferences:
                                InputBoxTextdetails(response, "displayKeyReferences", "ui_lbl_keyreferencestab", "ui_img_helpTextforkeyreferences", "iskeyreferences", "ui_txt_keyreferences", "ui_lbl_charsleftforkeyreferences", "regexexprforkeyreferences", "validationmsgforkeyreferences", mode);
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

    function LoadkeyreferencesData() {
        $.ajax({
            async: false,
            type: "GET",
            url: "/NewStudy/GetkeyreferencesData/",
            cache: false,
            dataType: "json",
            data: { "StudyId": $('#StudyId').val() },
            success: function (response) {
                if (response.Data == '')
                    popupNotification.show(errorsinthepage, "error");
                else {
                    hasdata = true;
                    $("#ui_txt_keyreferences").val(response.Data[0].KeyReferences);
                }
            },
            failure: function (response) {
                popupNotification.show(errorsinthepage, "error");
            }
        });
        return hasdata;
    }
});