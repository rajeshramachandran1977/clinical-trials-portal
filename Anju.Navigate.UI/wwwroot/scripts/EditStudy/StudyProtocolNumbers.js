//#region Template declarations
var studyprotocolnumberstemplate = kendo.template($("#studyprotocolnumberstemplate").html());
//#endregion

function OnDataBoundforStudyProtocol() {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(studyprotocolsattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                var grid = $("#ui_dtg_gridstudyprotocol").data("kendoGrid");
                var isdeleterestricted = false;
                for (i = 0; i < response.length; i++) {
                    if (response[i].RestrictDeleteUser != null) {
                        var restrictdeleteArray = response[i].RestrictDeleteUser.split(',');
                        for (var j = 0; j < restrictdeleteArray.length; j++) {
                            if (restrictdeleteArray[j] == $('#UserType').val()) {
                                isdeleterestricted = true;
                                break;
                            }
                            else
                                isdeleterestricted = false;
                            if (isdeleterestricted == true)
                                break;
                        }
                        if (isdeleterestricted == true)
                            break;
                    }
                }
                if (isdeleterestricted == true) 
                    grid.hideColumn(4);                    
                else 
                    grid.showColumn(4);
                    
                var iseditrestricted = false;
                var iseditredtrictedattablevel = false;
                for (i = 0; i < response.length; i++) {
                    if (response[i].RestrictEditUser != null) {
                        var restricteditArray = response[i].RestrictEditUser.split(',');
                        for (var j = 0; j < restricteditArray.length; j++) {
                            if (restricteditArray[j] == $('#UserType').val()) {
                                iseditrestricted = true;
                                if (response[i].Type == "Tab")
                                    iseditredtrictedattablevel = true;
                                break;
                            }
                            else
                                iseditrestricted = false;
                            if (iseditrestricted == true)
                                break;
                        }
                        if (iseditrestricted == true)
                            break;
                    }
                }
                if (iseditrestricted == true) {
                    if (iseditredtrictedattablevel == true)
                        grid.hideColumn(3);
                    return false;
                }
                else {
                    grid.showColumn(3);
                    return false;
                }
            }
        },
        failure: function (response) {
            popupNotification.show(errorsinthepage, "error");
        }
    });
}

function deleteStudyProtocol(e) {
    e.preventDefault ? e.preventDefault() : e.returnValue = false;
    $(document).ready(function () {
        wnd = $("#modalWindow").kendoWindow({
            title: deleteMsg,
            modal: true,
            visible: false,
            resizable: false,
            width: 400
        }).data("kendoWindow");
    });
    var grid = $("#ui_dtg_gridstudyprotocol").data("kendoGrid"); //Get the grid from which the pop-up is coming
    var tr = $(e.target).closest("tr"); //get the row for deletion
    var data = this.dataItem(tr);
    wnd.center().open();

    $("#ui_btn_yes").click(function () {
        grid.dataSource.remove(data);
        grid.dataSource.sync();
        wnd.close();
    });
    $("#ui_btn_no").click(function () {
        wnd.close();
    });
}

function addStudyProtocolNumbers() {
    var wnd = $("#Studyprotocols").data("kendoWindow");
    wnd.content(studyprotocolnumberstemplate(kendo.template($("#studyprotocolnumberstemplate").html())));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadStudyProtocolNumbersattributes("Create");

    CheckcharacterLength();

    isvalidRegexforstudyprotocolnumbers = true;

    $("#ui_txt_studyprotocolnumbers").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_studyprotocolnumbers").val().trim();
        if (str != "")
            if ($("#regexexprforstudyprotocolnumbers").val() != "") {
                var expr = new RegExp($("#regexexprforstudyprotocolnumbers").val());
                var str = $("#ui_txt_studyprotocolnumbers").val();
                if (str != "" && !expr.test(str)) {
                    $('#studyprotocolnumberserrmsg').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstudyprotocolnumbers").val() + '</div>');
                    isvalidRegexforstudyprotocolnumbers = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstudyprotocolnumbers = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_studyprotocolnumbers").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_studyprotocolnumbers").val().trim();
        if (str != "")
            if ($("#regexexprforstudyprotocolnumbers").val() != "") {
                var expr = new RegExp($("#regexexprforstudyprotocolnumbers").val());
                var str = $("#ui_txtarea_studyprotocolnumbers").val();
                if (str != "" && !expr.test(str)) {
                    $('#studyprotocolnumberserrmsg').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstudyprotocolnumbers").val() + '</div>');
                    isvalidRegexforstudyprotocolnumbers = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstudyprotocolnumbers = true;
                    return true;
                }
            }
    });

    $('#studyprotocolnumberserrmsg').on("keyup", function (e) {
        $(this).next("div.error").remove();
    }).change();

    $('#organization').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    //#region Validate RegEx values for Study Protocol(Add mode)
    $("#ui_txtarea_studyprotocolnumbers").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_studyprotocolnumbers").val().trim();
        if (str != "")
            if ($("#regexexprforstudyprotocolnumbers").val() != "") {
                var expr = new RegExp($("#regexexprforstudyprotocolnumbers").val());
                var str = $("#ui_txtarea_studyprotocolnumbers").val();
                if (str != "" && !expr.test(str)) {
                    $('#studyprotocolnumbers').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstudyprotocolnumbers").val() + '</div>');
                    isvalidRegexforStudyProtocolNumbers = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforStudyProtocolNumbers = true;
                    return true;
                }
            }
    });
    $("#ui_txt_studyprotocolnumbers").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_studyprotocolnumbers").val().trim();
        if (str != "")
            if ($("#regexexprforstudyprotocolnumbers").val() != "") {
                var expr = new RegExp($("#regexexprforstudyprotocolnumbers").val());
                var str = $("#ui_txt_studyprotocolnumbers").val();
                if (str != "" && !expr.test(str)) {
                    $('#studyprotocolnumbers').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstudyprotocolnumbers").val() + '</div>');
                    isvalidRegexforStudyProtocolNumbers = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforStudyProtocolNumbers = true;
                    return true;
                }
            }
    });
    //#endregion

    //#region Save Study Protocol Numbers
    function SaveStudyprotocolnos(mode) {
        var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");
        ValidateStudyprotocolnosFields();
        //if ($('#ui_ddl_organization').val() == "" && $('#ui_txtarea_studyprotocolnumbers').val() == ""
        //    && $('#ui_txt_studyprotocolnumbers').val() == "") {
        //    popupNotification.show("Empty record detected,please enter some values.", "info");
        //    return false;
        //}
        //else {
        if (validator.validate() && isvalidRegexforStudyProtocolNumbers == true && retval === true) {
                Savedetails(type = 18, objEditstudy = objStudyprotocolnos, mode = mode);
                $("#Studyprotocols").data("kendoWindow").close();
                return true;
            }
            else
                popupNotification.show(errorsinthepage, "error");
            return false;
        //}
    }
    //#endregion

    $("#ui_btnSavestudyprotocolnos").click(function (e) {
        SaveStudyprotocolnos("Create");
    });

    //#region Validate Study Protocol Numbers Fields
    function ValidateStudyprotocolnosFields() {
        $(".error").remove();
        retval = true;
        objStudyprotocolnos = new Object();
        objStudyprotocolnos.StudyId = $('#StudyId').val();
        objStudyprotocolnos.StudyProtocolId = $('#ui_num_studyprotocolid').val();

        if ($('#displayOrganization').is(':visible'))
            if (sessionStorage.getItem("isorganization") == "true") {

                if ($('#ui_ddl_organization').val() == "") {
                    $('#organization').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_organization').html() + ' is required</div>');
                    retval = false;
                }
                else
                    if ($('#ui_ddl_organization').val() == "Select")
                        objStudyprotocolnos.Organization = null;
                    else
                        objStudyprotocolnos.Organization = $('#ui_ddl_organization').val();
            }
            else
                if ($('#ui_ddl_organization').val() == "Select")
                    objStudyprotocolnos.Organization = null;
                else
                    objStudyprotocolnos.Organization = $('#ui_ddl_organization').val();

        if ($('#displayStudyProtocolNumbers').is(':visible'))
            if (sessionStorage.getItem("isstudyprotocolnumbers") == "true") {
                if ($('#ui_txt_studyprotocolnumbers').is(':visible')) {
                    if ($('#ui_txt_studyprotocolnumbers').val() == "") {
                        $('#studyprotocolnumberserrmsg').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_studyprotocolnumbers').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_studyprotocolnumbers').is(':visible')) {
                    if ($('#ui_txtarea_studyprotocolnumbers').val() == "") {
                        $('#studyprotocolnumberserrmsg').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_studyprotocolnumbers').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_studyprotocolnumbers').is(':visible'))
                    objStudyprotocolnos.StudyProtocolnos = $('#ui_txtarea_studyprotocolnumbers').val().trim();
                if ($('#ui_txt_studyprotocolnumbers').is(':visible'))
                    objStudyprotocolnos.StudyProtocolnos = $('#ui_txt_studyprotocolnumbers').val().trim();
            }
            else {
                if ($('#ui_txtarea_studyprotocolnumbers').is(':visible'))
                    objStudyprotocolnos.StudyProtocolnos = $('#ui_txtarea_studyprotocolnumbers').val().trim();
                if ($('#ui_txt_studyprotocolnumbers').is(':visible'))
                    objStudyprotocolnos.StudyProtocolnos = $('#ui_txt_studyprotocolnumbers').val().trim();
            }
    }
    //#endregion   

    $("#ui_dtg_gridstudyprotocol").data("kendoGrid").dataSource.read();
    $("#ui_dtg_gridstudyprotocol").data("kendoGrid").refresh();
}

function showStudyProtocolNumbers(e) {
    var grid = $("#ui_dtg_gridstudyprotocol").getKendoGrid();
    var wnd = $("#Studyprotocols").data("kendoWindow");
    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(studyprotocolnumberstemplate(dataItem));
    wnd.center().open();

    LoadStudyProtocolNumbersattributes("Edit");

    CheckcharacterLength();

    isvalidRegexforstudyprotocolnumbers = true;

    $("#ui_txt_studyprotocolnumbers").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_studyprotocolnumbers").val().trim();
        if (str != "")
            if ($("#regexexprforstudyprotocolnumbers").val() != "") {
                var expr = new RegExp($("#regexexprforstudyprotocolnumbers").val());
                var str = $("#ui_txt_studyprotocolnumbers").val();
                if (str != "" && !expr.test(str)) {
                    $('#studyprotocolnumberserrmsg').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstudyprotocolnumbers").val() + '</div>');
                    isvalidRegexforstudyprotocolnumbers = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstudyprotocolnumbers = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_studyprotocolnumbers").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_studyprotocolnumbers").val().trim();
        if (str != "")
            if ($("#regexexprforstudyprotocolnumbers").val() != "") {
                var expr = new RegExp($("#regexexprforstudyprotocolnumbers").val());
                var str = $("#ui_txtarea_studyprotocolnumbers").val();
                if (str != "" && !expr.test(str)) {
                    $('#studyprotocolnumberserrmsg').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstudyprotocolnumbers").val() + '</div>');
                    isvalidRegexforstudyprotocolnumbers = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstudyprotocolnumbers = true;
                    return true;
                }
            }
    });

    $('#studyprotocolnumberserrmsg').on("keyup", function (e) {
        $(this).next("div.error").remove();
    }).change();

    $('#organization').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    //#region Save Study Protocol Numbers
    function SaveStudyprotocolnos(mode) {
        var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");
        ValidateStudyprotocolnosFields();
        if ($('#ui_ddl_organization').val() == "" && $('#ui_txtarea_studyprotocolnumbers').val() == ""
            && $('#ui_txt_studyprotocolnumbers').val() == "") {
            popupNotification.show("Empty record detected,please enter some values.", "info");
            return false;
        }
        else {
            if (validator.validate() && retval === true) {
                Savedetails(type = 18, objEditstudy = objStudyprotocolnos, mode = mode);
                $("#Studyprotocols").data("kendoWindow").close();
                return true;
            }
            else
                popupNotification.show(errorsinthepage, "error");
            return false;
        }
    }
    //#endregion

    //#region Validate Study Protocol Numbers Fields
    function ValidateStudyprotocolnosFields() {
        $(".error").remove();
        retval = true;
        objStudyprotocolnos = new Object();
        objStudyprotocolnos.StudyId = $('#StudyId').val();
        objStudyprotocolnos.StudyProtocolId = $('#ui_num_studyprotocolid').val();

        if ($('#displayOrganization').is(':visible'))
            if (sessionStorage.getItem("isorganization") == "true") {

                if ($('#ui_ddl_organization').val() == "") {
                    $('#organization').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_organization').html() + ' is required</div>');
                    retval = false;
                }
                else
                    if ($('#ui_ddl_organization').val() == "Select")
                        objStudyprotocolnos.Organization = null;
                    else
                        objStudyprotocolnos.Organization = $('#ui_ddl_organization').val();
            }
            else
                if ($('#ui_ddl_organization').val() == "Select")
                    objStudyprotocolnos.Organization = null;
                else
                    objStudyprotocolnos.Organization = $('#ui_ddl_organization').val();

        if ($('#displayStudyProtocolNumbers').is(':visible'))
            if (sessionStorage.getItem("isstudyprotocolnumbers") == "true") {
                if ($('#ui_txt_studyprotocolnumbers').is(':visible')) {
                    if ($('#ui_txt_studyprotocolnumbers').val() == "") {
                        $('#studyprotocolnumberserrmsg').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_studyprotocolnumbers').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_studyprotocolnumbers').is(':visible')) {
                    if ($('#ui_txtarea_studyprotocolnumbers').val() == "") {
                        $('#studyprotocolnumberserrmsg').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_studyprotocolnumbers').html() + ' is required</div>');
                        retval = false;
                    }
                }
                if ($('#ui_txtarea_studyprotocolnumbers').is(':visible'))
                    objStudyprotocolnos.StudyProtocolnos = $('#ui_txtarea_studyprotocolnumbers').val().trim();
                if ($('#ui_txt_studyprotocolnumbers').is(':visible'))
                    objStudyprotocolnos.StudyProtocolnos = $('#ui_txt_studyprotocolnumbers').val().trim();
            }
            else {
                if ($('#ui_txtarea_studyprotocolnumbers').is(':visible'))
                    objStudyprotocolnos.StudyProtocolnos = $('#ui_txtarea_studyprotocolnumbers').val().trim();
                if ($('#ui_txt_studyprotocolnumbers').is(':visible'))
                    objStudyprotocolnos.StudyProtocolnos = $('#ui_txt_studyprotocolnumbers').val().trim();
            }
    }
    //#endregion

    //#region Validate RegEx values for Study Protocol(Edit mode)
    $("#ui_txtarea_studyprotocolnumbers").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_studyprotocolnumbers").val().trim();
        if (str != "")
            if ($("#regexexprforstudyprotocolnumbers").val() != "") {
                var expr = new RegExp($("#regexexprforstudyprotocolnumbers").val());
                var str = $("#ui_txtarea_studyprotocolnumbers").val();
                if (str != "" && !expr.test(str)) {
                    $('#studyprotocolnumbers').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstudyprotocolnumbers").val() + '</div>');
                    isvalidRegexforStudyProtocolNumbers = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforStudyProtocolNumbers = true;
                    return true;
                }
            }
    });
    $("#ui_txt_studyprotocolnumbers").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_studyprotocolnumbers").val().trim();
        if (str != "")
            if ($("#regexexprforstudyprotocolnumbers").val() != "") {
                var expr = new RegExp($("#regexexprforstudyprotocolnumbers").val());
                var str = $("#ui_txt_studyprotocolnumbers").val();
                if (str != "" && !expr.test(str)) {
                    $('#studyprotocolnumbers').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstudyprotocolnumbers").val() + '</div>');
                    isvalidRegexforStudyProtocolNumbers = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforStudyProtocolNumbers = true;
                    return true;
                }
            }
    });
    //#endregion

    //#region Get existing  Study Protocol
    $('#ui_num_studyprotocolid').val(dataItem.StudyProtocolId);
    if (dataItem.Organization == null)
        $("#ui_ddl_organization").data('kendoDropDownList').value('Select');
    else
        $("#ui_ddl_organization").data('kendoDropDownList').value(dataItem.Organization);
    $("#ui_txt_studyprotocolnumbers,#ui_txtarea_studyprotocolnumbers").val(dataItem.StudyProtocolnos);

    //#endregion

    $("#ui_btnSavestudyprotocolnos").click(function (e) {
        SaveStudyprotocolnos("Edit");
    });
}

function LoadStudyProtocolNumbersattributes(mode) {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(studyprotocolsattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case studyprotocolnumbers:
                            Textdetails(response, "displayStudyProtocolNumbers", "ui_lbl_studyprotocolnumbers", "ui_img_helpTextforstudyprotocolnumbers", "isstudyprotocolnumbers", "ui_txt_studyprotocolnumbers", "ui_txtarea_studyprotocolnumbers", "ui_lbl_charsleftforstudyprotocolnumbers", "regexexprforstudyprotocolnumbers", "validationmsgforstudyprotocolnumbers", mode);
                            break;
                        case organization:
                            DropDowndetails(response, "displayOrganization", "ui_lbl_organization", "ui_img_helpTextfororganization", "isorganization", mode);
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

$("#ui_btnSaveStudyProtocolNumbers").click(function (e) {
    ValidateStudyProtocolNumbersFields();
    if (validator.validate() && retval === true && isvalidRegexforstudyprotocolnumbers === true)
        Savedetails(type = 18, objEditstudy = objStudyProtocolNumbers);
    else
        popupNotification.show(errorsinthepage, "error");
    return false;
});

$(document).ready(function () {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(studyprotocolsattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case studyprotocolnumberstab:
                            var iscreaterestricted = false;
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
                                        $("#ui_btn_AddStudyProtocolNumbers").attr("disabled", true);
                                }
                                if (iscreaterestricted == true)
                                    $("#ui_btn_AddStudyProtocolNumbers").attr("disabled", true);
                            }
                            if (iscreaterestricted == true)
                                $("#ui_btn_AddStudyProtocolNumbers").attr("disabled", true);
                            else
                                $("#ui_btn_AddStudyProtocolNumbers").removeAttr("disabled");
                            break;
                        case studyprotocolnumbers:
                            $("#ui_dtg_gridstudyprotocol th[data-field=StudyProtocolnos]").html(response[i].Name);
                            break;
                        case organization:
                            $("#ui_dtg_gridstudyprotocol th[data-field=Organization]").html(response[i].Name);
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
});

