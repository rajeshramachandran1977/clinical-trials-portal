$(function () {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");

    $('#ui_multiselectphysiciannetworknames').kendoMultiSelect({
        dataTextField: "Code",
        dataValueField: "CodeId",
        optionLabel: 'Select',
        autoClose: false,
        dataSource: {
            transport: {
                read: {
                    dataType: "json",
                    url: url
                }
            }
        }
    });

    //#region Research Group Description
    $("#ui_txt_studysponsorname").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_studysponsorname").val().trim();
        if (str != "")
            if ($("#regexexprforstudysponsorname").val() != "") {
                var expr = new RegExp($("#regexexprforstudysponsorname").val());
                var str = $("#ui_txt_studysponsorname").val();
                if (str != "" && !expr.test(str)) {
                    $('#studysponsorname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstudysponsorname").val() + '</div>');
                    isvalidRegexforstudysponsorname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstudysponsorname = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_studysponsorname").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_studysponsorname").val().trim();
        if (str != "")
            if ($("#regexexprforstudysponsorname").val() != "") {
                var expr = new RegExp($("#regexexprforstudysponsorname").val());
                var str = $("#ui_txtarea_studysponsorname").val();
                if (str != "" && !expr.test(str)) {
                    $('#studysponsorname').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstudysponsorname").val() + '</span>');
                    isvalidRegexforstudysponsorname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstudysponsorname = true;
                    return true;
                }
            }
    });
    $("#ui_txt_studydrugsource").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_studydrugsource").val().trim();
        if (str != "")
            if ($("#regexexprforstudydrugsource").val() != "") {
                var expr = new RegExp($("#regexexprforstudydrugsource").val());
                var str = $("#ui_txt_studydrugsource").val();
                if (str != "" && !expr.test(str)) {
                    $('#studydrugsource').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstudydrugsource").val() + '</div>');
                    isvalidRegexforstudydrugsource = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstudydrugsource = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_studydrugsource").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_studydrugsource").val().trim();
        if (str != "")
            if ($("#regexexprforstudydrugsource").val() != "") {
                var expr = new RegExp($("#regexexprforstudydrugsource").val());
                var str = $("#ui_txtarea_studydrugsource").val();
                if (str != "" && !expr.test(str)) {
                    $('#studydrugsource').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstudydrugsource").val() + '</div>');
                    isvalidRegexforstudydrugsource = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstudydrugsource = true;
                    return true;
                }
            }
    });
    $("#ui_txt_cooperativegroupnameother").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_cooperativegroupnameother").val().trim();
        if (str != "")
            if ($("#regexexprforstudydrugsource").val() != "") {
                var expr = new RegExp($("#regexexprforstudydrugsource").val());
                var str = $("#ui_txt_cooperativegroupnameother").val();
                if (str != "" && !expr.test(str)) {
                    $('#cooperativegroupnameother').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstudydrugsource").val() + '</div>');
                    isvalidRegexforcooperativegroupnameother = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcooperativegroupnameother = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_cooperativegroupnameother").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_cooperativegroupnameother").val().trim();
        if (str != "")
            if ($("#regexexprforstudydrugsource").val() != "") {
                var expr = new RegExp($("#regexexprforstudydrugsource").val());
                var str = $("#ui_txtarea_cooperativegroupnameother").val();
                if (str != "" && !expr.test(str)) {
                    $('#cooperativegroupnameother').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstudydrugsource").val() + '</div>');
                    isvalidRegexforcooperativegroupnameother = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcooperativegroupnameother = true;
                    return true;
                }
            }
    });
    //#endregion Research Group Description

    function ValidateResearchGroupDescriptionFields() {
        $(".error").remove();
        retval = true;
        objectResearchGroupDescription = new Object();
        objectResearchGroupDescription.StudyId = $('#StudyId').val();
        if ($('#displayStudysponsorname').is(':visible'))
            if (sessionStorage.getItem("isstudysponsorname") == "true") {
                if ($('#ui_txt_studysponsorname').is(':visible')) {
                    if ($('#ui_txt_studysponsorname').val() == "") {
                        $('#studysponsorname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_studysponsorname').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_studysponsorname').is(':visible')) {
                    if ($('#ui_txtarea_studysponsorname').val() == "") {
                        $('#studysponsorname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_studysponsorname').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_studysponsorname').is(':visible'))
                    objectResearchGroupDescription.StudySponsor = $('#ui_txt_studysponsorname').val().trim();
                if ($('#ui_txtarea_studysponsorname').is(':visible'))
                    objectResearchGroupDescription.StudySponsor = $('#ui_txtarea_studysponsorname').val().trim();
            }
            else {
                if ($('#ui_txt_studysponsorname').is(':visible'))
                    objectResearchGroupDescription.StudySponsor = $('#ui_txt_studysponsorname').val().trim();
                if ($('#ui_txtarea_studysponsorname').is(':visible'))
                    objectResearchGroupDescription.StudySponsor = $('#ui_txtarea_studysponsorname').val().trim();
            }

        if ($('#displayStudydrugsource').is(':visible'))
            if (sessionStorage.getItem("isstudydrugsource") == "true") {
                if ($('#ui_txt_studydrugsource').is(':visible')) {
                    if ($('#ui_txt_studydrugsource').val() == "") {
                        $('#studydrugsource').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_studydrugsource').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_studydrugsource').is(':visible')) {
                    if ($('#ui_txtarea_studydrugsource').val() == "") {
                        $('#studydrugsource').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_studydrugsource').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_studydrugsource').is(':visible'))
                    objectResearchGroupDescription.StudyDrugSource = $('#ui_txt_studydrugsource').val().trim();
                if ($('#ui_txtarea_studydrugsource').is(':visible'))
                    objectResearchGroupDescription.StudyDrugSource = $('#ui_txtarea_studydrugsource').val().trim();
            }
            else {
                if ($('#ui_txt_studydrugsource').is(':visible'))
                    objectResearchGroupDescription.StudyDrugSource = $('#ui_txt_studydrugsource').val().trim();
                if ($('#ui_txtarea_studydrugsource').is(':visible'))
                    objectResearchGroupDescription.StudyDrugSource = $('#ui_txtarea_studydrugsource').val().trim();
            }

        if ($('#displayCooperativegroupstudy').is(':visible'))
            if (sessionStorage.getItem("iscooperativegroupstudy") == "true") {
                if ($('#ui_ddl_cooperativegroupstudy').val() == "") {
                    $('#cooperativegroupstudy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_cooperativegroupstudy').html() + ' is required</div>');
                    retval = false;
                }
                else
                    if ($('#ui_ddl_cooperativegroupstudy').val() == yes)
                        objectResearchGroupDescription.IsCooperativeGroupStudy = true;
                if ($('#ui_ddl_cooperativegroupstudy').val() == no)
                    objectResearchGroupDescription.IsCooperativeGroupStudy = false;
                else
                    objectResearchGroupDescription.IsCooperativeGroupStudy = null;
            }
            else
                if ($('#ui_ddl_cooperativegroupstudy').val() == yes)
                    objectResearchGroupDescription.IsCooperativeGroupStudy = true;
        if ($('#ui_ddl_cooperativegroupstudy').val() == no)
            objectResearchGroupDescription.IsCooperativeGroupStudy = false;
        else
            objectResearchGroupDescription.IsCooperativeGroupStudy = null;

        if ($('#displayCooperativegroupname').is(':visible'))
            if (sessionStorage.getItem("iscooperativegroupname") == "true") {
                if ($('#ui_ddl_cooperativegroupname').val() == "") {
                    $('#cooperativegroupname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_cooperativegroupname').html() + ' is required</div>');
                    retval = false;
                }
                else
                    objectResearchGroupDescription.CooperativeGroupName = $('#ui_ddl_cooperativegroupname').val();
            }
            else
                objectResearchGroupDescription.CooperativeGroupName = $('#ui_ddl_cooperativegroupname').val();

        if ($('#displayCooperativegroupnameother').is(':visible'))
            if (sessionStorage.getItem("iscooperativegroupnameother") == "true") {
                if ($('#ui_txt_cooperativegroupnameother').is(':visible')) {
                    if ($('#ui_txt_cooperativegroupnameother').val() == "") {
                        $('#cooperativegroupnameother').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_cooperativegroupnameother').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_cooperativegroupnameother').is(':visible')) {
                    if ($('#ui_txtarea_cooperativegroupnameother').val() == "") {
                        $('#cooperativegroupnameother').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_cooperativegroupnameother').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txt_cooperativegroupnameother').is(':visible'))
                    objectResearchGroupDescription.OtherCooperativeGroup = $('#ui_txt_cooperativegroupnameother').val().trim();
                if ($('#ui_txtarea_cooperativegroupnameother').is(':visible'))
                    objectResearchGroupDescription.OtherCooperativeGroup = $('#ui_txtarea_cooperativegroupnameother').val().trim();
            }
            else {
                if ($('#ui_txt_cooperativegroupnameother').is(':visible'))
                    objectResearchGroupDescription.OtherCooperativeGroup = $('#ui_txt_cooperativegroupnameother').val().trim();
                if ($('#ui_txtarea_cooperativegroupnameother').is(':visible'))
                    objectResearchGroupDescription.OtherCooperativeGroup = $('#ui_txtarea_cooperativegroupnameother').val().trim();
            }

        if ($('#displayPhysiciannetworkstudy').is(':visible'))
            if (sessionStorage.getItem("isphysiciannetworkstudy") == "true") {
                if ($('#ui_ddl_physiciannetworkstudy').val() == "") {
                    $('#physiciannetworkstudy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_physiciannetworkstudy').html() + ' is required</div>');
                    retval = false;
                }
                else
                    if ($('#ui_ddl_physiciannetworkstudy').val() == yes)
                        objectResearchGroupDescription.IsPhysicianNetworkStudy = true;
                if ($('#ui_ddl_physiciannetworkstudy').val() == no)
                    objectResearchGroupDescription.IsPhysicianNetworkStudy = false;
                else
                    objectResearchGroupDescription.IsPhysicianNetworkStudy = null;
            }
            else
                if ($('#ui_ddl_physiciannetworkstudy').val() == yes)
                    objectResearchGroupDescription.IsPhysicianNetworkStudy = true;
        if ($('#ui_ddl_physiciannetworkstudy').val() == no)
            objectResearchGroupDescription.IsPhysicianNetworkStudy = false;
        else
            objectResearchGroupDescription.IsPhysicianNetworkStudy = null;

        if ($('#displayPhysiciannetworknames').is(':visible'))
            if (sessionStorage.getItem("ismultiselectPhysiciannetworknames") == "true") {
                if ($('#ui_multiselectphysiciannetworknames').data("kendoMultiSelect").value().length <= 0) {
                    $('#physiciannetworknames').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_multiselectphysiciannetworknames').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_multiselectphysiciannetworknames').val() == "")
                        objectResearchGroupDescription.PhysicianNetworkName = null;
                    else
                        objectResearchGroupDescription.PhysicianNetworkName = $('#ui_multiselectphysiciannetworknames').val().toString();
                }
            }
            else {
                if ($('#ui_multiselectphysiciannetworknames').val() == "")
                    objectResearchGroupDescription.PhysicianNetworkName = null;
                else
                    objectResearchGroupDescription.PhysicianNetworkName = $('#ui_multiselectphysiciannetworknames').val().toString();
            }


    }

    //#region Remove err msg on key up for non grid text fields
    $("#studysponsorname,#studydrugsource,#cooperativegroupnameother").on("keyup", function (e) {
        $(this).next("div.error").remove();
    })

    $('#cooperativegroupnameother,#cooperativegroupname,#physiciannetworkstudy,#physiciannetworknames').change(function () {
        $(this).next("div.error").remove();
    }).change();
    //#endregion

    $("#ui_btnSaveResearchGroupDescription").click(function (e) {
        ValidateResearchGroupDescriptionFields();
        if (validator.validate() && retval === true && (isvalidRegexforstudysponsorname === true
            && isvalidRegexforstudydrugsource === true && isvalidRegexforcooperativegroupnameother === true))
            Savedetails(type = 20, objEditstudy = objectResearchGroupDescription);
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    });

    $("#researchgroupdescription").on("click", function () {
        $('#originalfinancialrequestdetailscontents').show();
        LoadResearchGroupDescriptionAttributes();
        LoadResearchGroupDescriptionData();
    });

    function LoadResearchGroupDescriptionAttributes() {
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
                            case studysponsor:
                                Textdetails(response, "displayStudysponsorname", "ui_lbl_studysponsorname", "ui_img_helpTextforstudysponsorname", "isstudysponsorname", "ui_txt_studysponsorname", "ui_txtarea_studysponsorname", "ui_lbl_charsleftforstudysponsorname", "regexexprforstudysponsorname", "validationmsgforstudysponsorname");
                                break;
                            case studydrugsource:
                                Textdetails(response, "displayStudydrugsource", "ui_lbl_studydrugsource", "ui_img_studydrugsource", "isstudydrugsource", "ui_txt_studydrugsource", "ui_txtarea_studydrugsource", "ui_lbl_charsleftforstudydrugsource", "regexexprforstudydrugsource", "validationmsgforstudydrugsource");
                                break;
                            case iscooperativegroupstudy:
                                DropDowndetails(response, "displayCooperativegroupstudy", "ui_lbl_cooperativegroupstudy", "ui_img_cooperativegroupstudy", "iscooperativegroupstudy");
                                break;
                            case cooperativegroupname:
                                DropDowndetails(response, "displayCooperativegroupname", "ui_lbl_cooperativegroupname", "ui_img_cooperativegroupname", "iscooperativegroupname");
                                break;
                            case cooperativegroupnameother:
                                Textdetails(response, "displayCooperativegroupnameother", "ui_lbl_cooperativegroupnameother", "ui_img_cooperativegroupnameother", "iscooperativegroupname", "ui_txt_cooperativegroupnameother", "ui_txtarea_cooperativegroupnameother", "ui_lbl_charsleftforcooperativegroupnameother", "regexforcooperativegroupnameother", "validationmsgforcooperativegroupnameother");
                                break;
                            case isphysiciannetworkstudy:
                                DropDowndetails(response, "displayPhysiciannetworkstudy", "ui_lbl_physiciannetworkstudy", "ui_img_physiciannetworkstudy", "isphysiciannetworkstudy");
                                break;
                            case physiciannetworknames:
                                DropDowndetails(response, "displayPhysiciannetworknames", "ui_lbl_multiselectphysiciannetworknames", "ui_img_multiselectphysiciannetworknames", "ismultiselectPhysiciannetworknames");
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

    function LoadResearchGroupDescriptionData() {
        $.ajax({
            async: true,
            type: "POST",
            url: "/NewStudy/GetResearchGroupDescriptionData/",
            cache: false,
            dataType: "json",
            data: { "StudyId": $('#StudyId').val() },
            success: function (response) {
                if (response.Data == '')
                    popupNotification.show(errorsinthepage, "error");
                else {
                    $("#ui_txt_studysponsorname,#ui_txtarea_studysponsorname").val(response.Data[0].StudySponsor);
                    $("#ui_txt_studydrugsource,#ui_txtarea_studydrugsource").val(response.Data[0].StudyDrugSource);
                    $("#ui_txt_cooperativegroupnameother,#ui_txtarea_cooperativegroupnameother").val(response.Data[0].OtherCooperativeGroup);
                    var IsCooperativeGroupStudy = response.Data[0].IsCooperativeGroupStudy;
                    if (IsCooperativeGroupStudy === null)
                        $("#ui_ddl_cooperativegroupstudy").data('kendoDropDownList').value("Select");
                    else {
                        if (IsCooperativeGroupStudy == true)
                            $('#ui_ddl_cooperativegroupstudy').data('kendoDropDownList').value(yes);
                        else
                            $('#ui_ddl_cooperativegroupstudy').data('kendoDropDownList').value(no);
                    }
                    var Isphysiciannetworkstudy = response.Data[0].IsPhysicianNetworkStudy;
                    if (Isphysiciannetworkstudy === null)
                        $("#ui_ddl_physiciannetworkstudy").data('kendoDropDownList').value("Select");
                    else {
                        if (Isphysiciannetworkstudy == true)
                            $('#ui_ddl_physiciannetworkstudy').data('kendoDropDownList').value(yes);
                        else
                            $('#ui_ddl_physiciannetworkstudy').data('kendoDropDownList').value(no);
                    }
                    if (response.Data[0].PhysicianNetworkName !== null) {
                        var physiciannetworkname = response.Data[0].PhysicianNetworkName.split(',');
                        $('#ui_multiselectphysiciannetworknames').getKendoMultiSelect().value(physiciannetworkname);
                    }
                    var CooperativeGroupName = response.Data[0].CooperativeGroupName;
                    if (CooperativeGroupName === null)
                        $("#ui_ddl_cooperativegroupname").data('kendoDropDownList').value("Select");
                    else
                        $("#ui_ddl_cooperativegroupname").data('kendoDropDownList').value(CooperativeGroupName);
                }
            },
            failure: function (response) {
                popupNotification.show(errorsinthepage, "error");
            }
        });
    }
})
