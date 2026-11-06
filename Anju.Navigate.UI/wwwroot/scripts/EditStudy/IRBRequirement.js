$(function () {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");

    function ValidateIRBRegistrationRequirementFields() {
        $(".error").remove();
        retval = true;
        objIRBRegistrationRequirement = new Object();
        objIRBRegistrationRequirement.StudyId = $('#StudyId').val();

        if ($('#displayIRBRequirement').is(':visible'))
            if (sessionStorage.getItem("isIRBRequirement") == "true")
            {
                if ($('#ui_ddl_registrationIRB').val() == "") {
                    $('#irbRequirement').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_IRBRequirement').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_registrationIRB').val() == yes)
                        objIRBRegistrationRequirement.IsIrbregistrationRequirement = true;
                    if ($('#ui_ddl_registrationIRB').val() == no)
                        objIRBRegistrationRequirement.IsIrbregistrationRequirement = false;
                    if ($('#ui_ddl_registrationIRB').val() == "")
                        objIRBRegistrationRequirement.IsIrbregistrationRequirement = null;
                }
            }
            else {
                if ($('#ui_ddl_registrationIRB').val() == yes)
                    objIRBRegistrationRequirement.IsIrbregistrationRequirement = true;
                if ($('#ui_ddl_registrationIRB').val() == no)
                    objIRBRegistrationRequirement.IsIrbregistrationRequirement = false;
                if ($('#ui_ddl_registrationIRB').val() == "")
                    objIRBRegistrationRequirement.IsIrbregistrationRequirement = null;
            }
    }

    //#region Remove err msg on key up for non grid text fields        
    $('#irbRequirement').change(function () {
        $(this).next("div.error").remove();
    }).change();
    //#endregion

    $("#ui_btnSaveIRBRegistrationRequirement").click(function (e) {
        ValidateIRBRegistrationRequirementFields();
        if (validator.validate() && retval === true)
            Savedetails(type = 7, objEditstudy = objIRBRegistrationRequirement);
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    });

    $("#IRBRequirement").on("click", function () {      
        $('#IRBRequirementcontents').show();
        var isEditmode = false;
        isEditmode = LoadIRBRequirementData();

        if (isEditmode == true)
            LoadIRBRequirementAttributeValues("Edit");
        else
            LoadIRBRequirementAttributeValues("Create");      
    });

    function LoadIRBRequirementAttributeValues(mode) {
        $.ajax({
            async: true,
            type: "GET",
            url: "/NewStudy/GetAttributeValues/",
            data: { attributeid: parseInt(IRBRequirementattributeid) },
            cache: false,
            dataType: "json",
            success: function (response) {
                if (response.Data == '') {
                    popupNotification.show(errorsinthepage, "error");
                } else {
                    for (i = 0; i < response.length; i++) {
                        //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                        switch (response[i].FieldType) {
                            case irbrequirement:
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
                                            $("#ui_btnSaveIRBRegistrationRequirement").attr("disabled", true);
                                    }
                                    if (iscreaterestricted == true)
                                        $("#ui_btnSaveIRBRegistrationRequirement").attr("disabled", true);
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
                                            $("#ui_btnSaveIRBRegistrationRequirement").attr("disabled", true);
                                    }
                                    if (iseditrestricted == true)
                                        $("#ui_btnSaveIRBRegistrationRequirement").attr("disabled", true);
                                }
                                if (iscreaterestricted == true || iseditrestricted == true)
                                    $("#ui_btnSaveIRBRegistrationRequirement").attr("disabled", true);
                                else
                                    $("#ui_btnSaveIRBRegistrationRequirement").removeAttr("disabled");
                                break;
                            case isirbregistrationrequirement:
                                DropDowndetails(response, "displayIRBRequirement", "ui_lbl_IRBRequirement", "ui_img_helpTextforIRBRequirement", "isIRBRequirement", mode);
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

    function LoadIRBRequirementData() {
        $.ajax({
            async: false,
            type: "GET",
            url: "/NewStudy/GetIRBRequirementData/",
            cache: false,
            dataType: "json",
            data: { "StudyId": $('#StudyId').val() },
            success: function (response) {
                if (response.Data == '')
                    popupNotification.show(errorsinthepage, "error");
                else {
                    hasdata = true;
                    var IsIrbregistrationRequirement = response.Data[0].IsIrbregistrationRequirement;
                    if (IsIrbregistrationRequirement == null)
                        $("#ui_ddl_registrationIRB").data('kendoDropDownList').value("Select");
                    else {
                        if (IsIrbregistrationRequirement == true)
                            $('#ui_ddl_registrationIRB').data('kendoDropDownList').value(yes);
                        else
                            $('#ui_ddl_registrationIRB').data('kendoDropDownList').value(no);
                    }
                }
            },
            failure: function (response) {
                popupNotification.show(errorsinthepage, "error");
            }
        });
        return hasdata;
    }
});