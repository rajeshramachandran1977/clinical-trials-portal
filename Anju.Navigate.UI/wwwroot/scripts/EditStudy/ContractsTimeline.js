
//#region Template declarations
var contractstimelinetemplate = kendo.template($("#contractstimelinetemplate").html());
//#endregion

function OnDataBoundforContractsTimeline() {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(contractstimelineattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                var grid = $("#ui_dtg_ContractsTimeline").data("kendoGrid");
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
                    grid.hideColumn(10);                   
                else 
                    grid.showColumn(10);
                    
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
                        grid.hideColumn(9);
                    return false;
                }
                else {
                    grid.showColumn(9);
                    return false;
                }
            }
        },
        failure: function (response) {
            popupNotification.show(errorsinthepage, "error");
        }
    });
}

//#region delete row functions in grids
function deleteContractsTimelinedetails(e) {
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
    var grid = $("#ui_dtg_ContractsTimeline").data("kendoGrid"); //Get the grid from which the pop-up is coming
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
//#endregion

function addContractsTimelinedetails() {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");
    var wnd = $("#Contractstimeline").data("kendoWindow");
    wnd.content(contractstimelinetemplate(kendo.template($("#contractstimelinetemplate").html())));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadContractsTimelineAttributes("Create");

    CheckcharacterLength();

    isvalidRegexforversion = isvalidRegexforcontactname = true;

    $('#contracttype,#contractstatus,#currentlocation,#statuschangedate').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    $("#version,#contactname,#comments").on("keyup", function (e) {
        $(this).nextAll("div.error").remove();
    })

    //#region Validate RegEx values for ContractsTimeline fields(Add mode)
    $("#ui_txtarea_versioncontractstimeline").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_versioncontractstimeline").val().trim();
        if (str != "")
            if ($("#regexexprforversioncontractstimeline").val() != "") {
                var expr = new RegExp($("#regexexprforversioncontractstimeline").val());
                var str = $("#ui_txtarea_versioncontractstimeline").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_versioncontractstimeline').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforversioncontractstimeline").val() + '</span>');
                    isvalidRegexforversion = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforversion = true;
                    return true;
                }
            }
    });
    $("#ui_txt_versioncontractstimeline").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_versioncontractstimeline").val().trim();
        if (str != "")
            if ($("#regexexprforversioncontractstimeline").val() != "") {
                var expr = new RegExp($("#regexexprforversioncontractstimeline").val());
                var str = $("#ui_txt_versioncontractstimeline").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_versioncontractstimeline').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforversioncontractstimeline").val() + '</span>');
                    isvalidRegexforversion = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforversion = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_contactname").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_contactname").val().trim();
        if (str != "")
            if ($("#regexexprforcontactname").val() != "") {
                var expr = new RegExp($("#regexexprforcontactname").val());
                var str = $("#ui_txtarea_contactname").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_contactname').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcontactname").val() + '</span>');
                    isvalidRegexforcontactname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontactname = true;
                    return true;
                }
            }
    });
    $("#ui_txt_contactname").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_contactname").val().trim();
        if (str != "")
            if ($("#regexexprforcontactname").val() != "") {
                var expr = new RegExp($("#regexexprforcontactname").val());
                var str = $("#ui_txt_contactname").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_contactname').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcontactname").val() + '</span>');
                    isvalidRegexforcontactname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontactname = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_contractcomments").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_contractcomments").val().trim();
        if (str != "")
            if ($("#regexexprforcomments").val() != "") {
                var expr = new RegExp($("#regexexprforcomments").val());
                var str = $("#ui_txtarea_contractcomments").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_contractcomments').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcomments").val() + '</span>');
                    isvalidRegexforcontactname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontactname = true;
                    return true;
                }
            }
    });
    $("#ui_txt_contractcomments").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_contractcomments").val().trim();
        if (str != "")
            if ($("#regexexprforcomments").val() != "") {
                var expr = new RegExp($("#regexexprforcomments").val());
                var str = $("#ui_txt_contractcomments").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_contractcomments').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcomments").val() + '</span>');
                    isvalidRegexforcontactname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontactname = true;
                    return true;
                }
            }
    });
    //#endregion

    //#region Save Milestones Actions(Add mode)
    $("#ui_btnSavecontractstimeline").click(function (e) {
        SaveContractsTimeline("Create");
    });
    //#endregion

}

function showContractsTimelinedetails(e) {
    var grid = $("#ui_dtg_ContractsTimeline").getKendoGrid();
    var wnd = $("#Contractstimeline").data("kendoWindow");
    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(contractstimelinetemplate(dataItem));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadContractsTimelineAttributes("Edit");

    isvalidRegexforversion = isvalidRegexforcontactname = true;

    $('#contracttype,#contractstatus,#currentlocation,#statuschangedate').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    $("#version,#contactname,#comments").on("keyup", function (e) {
        $(this).nextAll("div.error").remove();
    })

    //#region Validate RegEx values for ContractsTimeline fields(Add mode)
    $("#ui_txtarea_versioncontractstimeline").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_versioncontractstimeline").val().trim();
        if (str != "")
            if ($("#regexexprforversioncontractstimeline").val() != "") {
                var expr = new RegExp($("#regexexprforversioncontractstimeline").val());
                var str = $("#ui_txtarea_versioncontractstimeline").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_versioncontractstimeline').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforversioncontractstimeline").val() + '</span>');
                    isvalidRegexforversion = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforversion = true;
                    return true;
                }
            }
    });
    $("#ui_txt_versioncontractstimeline").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_versioncontractstimeline").val().trim();
        if (str != "")
            if ($("#regexexprforversioncontractstimeline").val() != "") {
                var expr = new RegExp($("#regexexprforversioncontractstimeline").val());
                var str = $("#ui_txt_versioncontractstimeline").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_versioncontractstimeline').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforversioncontractstimeline").val() + '</span>');
                    isvalidRegexforversion = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforversion = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_contactname").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_contactname").val().trim();
        if (str != "")
            if ($("#regexexprforcontactname").val() != "") {
                var expr = new RegExp($("#regexexprforcontactname").val());
                var str = $("#ui_txtarea_contactname").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_contactname').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcontactname").val() + '</span>');
                    isvalidRegexforcontactname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontactname = true;
                    return true;
                }
            }
    });
    $("#ui_txt_contactname").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_contactname").val().trim();
        if (str != "")
            if ($("#regexexprforcontactname").val() != "") {
                var expr = new RegExp($("#regexexprforcontactname").val());
                var str = $("#ui_txt_contactname").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_contactname').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcontactname").val() + '</span>');
                    isvalidRegexforcontactname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontactname = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_contractcomments").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_contractcomments").val().trim();
        if (str != "")
            if ($("#regexexprforcomments").val() != "") {
                var expr = new RegExp($("#regexexprforcomments").val());
                var str = $("#ui_txtarea_contractcomments").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_contractcomments').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcomments").val() + '</span>');
                    isvalidRegexforcontactname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontactname = true;
                    return true;
                }
            }
    });
    $("#ui_txt_contractcomments").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_contractcomments").val().trim();
        if (str != "")
            if ($("#regexexprforcomments").val() != "") {
                var expr = new RegExp($("#regexexprforcomments").val());
                var str = $("#ui_txt_contractcomments").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_contractcomments').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcomments").val() + '</span>');
                    isvalidRegexforcontactname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontactname = true;
                    return true;
                }
            }
    });
    //#endregion

    //#region Get existing ContractsTimeline
    $("#ui_num_contractid").val(dataItem.ContractId);
    $("#ui_ddl_contracttype").data('kendoDropDownList').value(dataItem.Contracttype);
    $("#ui_ddl_contractstatus").data('kendoDropDownList').value(dataItem.Contracttimelinestatus);
    $("#ui_txt_versioncontractstimeline,#ui_txtarea_versioncontractstimeline").val(dataItem.Contractversion);
    $("#ui_ddl_currentlocation").data('kendoDropDownList').value(dataItem.Currentlocation);
    $("#ui_txt_contactname,#ui_txtarea_contactname").val(dataItem.Contactname);
    $("#ui_dt_statuschangedate").data("kendoDatePicker").value(dataItem.Statuschange);
    $("#ui_txt_contractcomments,#ui_txtarea_contractcomments").val(dataItem.Comments);


    //#endregion

    //#region Save ContractsTimeline Actions(Add mode)
    $("#ui_btnSavecontractstimeline").click(function (e) {
        SaveContractsTimeline("Edit");
    });
    //#endregion

}


function LoadContractsTimelineAttributes(mode) {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(contractstimelineattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case contracttype:
                            DropDowndetails(response, "displayContracttype", "ui_lbl_contracttype", "ui_img_helpTextforcontracttype", "iscontracttype", mode);
                            break;
                        case contractstatus:
                            DropDowndetails(response, "displayContractstatus", "ui_lbl_contractstatus", "ui_img_helpTextforcontractstatus", "iscontractstatus", mode);
                            break;
                        case version:
                            Textdetails(response, "displayVersionforcontractstimeline", "ui_lbl_versioncontractstimeline", "ui_img_helpTextforversioncontractstimeline", "isversioncontractstimeline", "ui_txt_versioncontractstimeline", "ui_txtarea_versioncontractstimeline", "ui_lbl_charsleftforversioncontractstimeline", "regexexprforversioncontractstimeline", "validationmsgforversioncontractstimeline", mode);
                            break;
                        case currentlocation:
                            DropDowndetails(response, "displayCurrentlocation", "ui_lbl_currentlocation", "ui_img_helpTextforcurrentlocation", "iscurrentlocation", mode);
                            break;
                        case contactname:
                            Textdetails(response, "displayContactname", "ui_lbl_contactname", "ui_img_helpTextforcontactname", "iscontactname", "ui_txt_contactname", "ui_txtarea_contactname", "ui_lbl_charsleftforcontactname", "regexexprforcontactname", "validationmsgforcontactname", mode);
                            break;
                        case statuschangedate:
                            DropDowndetails(response, "displayStatuschangedate", "ui_lbl_statuschangedate", "ui_img_helpTextforstatuschangedate", "isstatuschangedate", mode);
                            break;
                        case comments:
                            Textdetails(response, "displayComments", "ui_lbl_comments", "ui_img_helpTextforcomments", "iscomments", "ui_txt_contractcomments", "ui_txtarea_contractcomments", "ui_lbl_charsleftforcomments", "regexexprforcomments", "validationmsgforcomments",mode);
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

$("#contractstimeline").on("click", function () {
    $('#contractstimelinedetails').removeClass('contractstimelinedetails');
});

//#region validate Contracts Timeline fields
function ValidateContractsTimelineFields()  { 
    $(".error").remove();
    retval = true;
    objContractsTimeline = new Object();
    objContractsTimeline.StudyId = $('#StudyId').val();
    objContractsTimeline.ContractId = $('#ui_num_contractid').val();

    if ($('#displayContracttype').is(':visible'))
        if (sessionStorage.getItem("iscontracttype") == "true") {
            if ($('#ui_ddl_contracttype').val() == "") {
                $('#contracttype').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_contracttype').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_contracttype').val() == "")
                    objContractsTimeline.Contracttype = null;
                else
                    objContractsTimeline.Contracttype = $('#ui_ddl_contracttype').val();
            }
        }
        else {
            if ($('#ui_ddl_contracttype').val() == "")
                objContractsTimeline.Contracttype = null;
            else
                objContractsTimeline.Contracttype = $('#ui_ddl_contracttype').val();
        }

    if ($('#displayContractstatus').is(':visible'))
        if (sessionStorage.getItem("iscontractstatus") == "true") {
            if ($('#ui_ddl_contractstatus').val() == "") {
                $('#contractstatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_contractstatus').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_contractstatus').val() == "")
                    objContractsTimeline.Contracttimelinestatus = null;
                else
                    objContractsTimeline.Contracttimelinestatus = $('#ui_ddl_contractstatus').val();
            }
        }
        else {
            if ($('#ui_ddl_contractstatus').val() == "")
                objContractsTimeline.Contracttimelinestatus = null;
            else
                objContractsTimeline.Contracttimelinestatus = $('#ui_ddl_contractstatus').val();
        }

    if ($('#displayVersionforcontractstimeline').is(':visible'))
        if (sessionStorage.getItem("isversioncontractstimeline") == "true") {
            if ($('#ui_txt_versioncontractstimeline').is(':visible')) {
                if ($('#ui_txt_versioncontractstimeline').val() == "") {
                    $('#version').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_version').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_versioncontractstimeline').is(':visible')) {
                if ($('#ui_txtarea_versioncontractstimeline').val() == "") {
                    $('#version').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_version').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_versioncontractstimeline').is(':visible'))
                objContractsTimeline.Contractversion = $('#ui_txt_versioncontractstimeline').val().trim();
            if ($('#ui_txtarea_versioncontractstimeline').is(':visible'))
                objContractsTimeline.Contractversion = $('#ui_txtarea_versioncontractstimeline').val().trim();
        }
        else {
            if ($('#ui_txt_versioncontractstimeline').is(':visible'))
                objContractsTimeline.Contractversion = $('#ui_txt_versioncontractstimeline').val().trim();
            if ($('#ui_txtarea_versioncontractstimeline').is(':visible'))
                objContractsTimeline.Contractversion = $('#ui_txtarea_versioncontractstimeline').val().trim();
        }

    if ($('#displayCurrentlocation').is(':visible'))
        if (sessionStorage.getItem("iscurrentlocation") == "true") {
            if ($('#ui_ddl_currentlocation').val() == "") {
                $('#currentlocation').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_currentlocation').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_currentlocation').val() == "")
                    objContractsTimeline.Currentlocation = null;
                else
                    objContractsTimeline.Currentlocation = $('#ui_ddl_currentlocation').val();
            }
        }
        else {
            if ($('#ui_ddl_currentlocation').val() == "")
                objContractsTimeline.Currentlocation = null;
            else
                objContractsTimeline.Currentlocation = $('#ui_ddl_currentlocation').val();
        }

    if ($('#displayContactname').is(':visible'))
        if (sessionStorage.getItem("iscontactname") == "true") {
            if ($('#ui_txt_contactname').is(':visible')) {
                if ($('#ui_txt_contactname').val() == "") {
                    $('#contactname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_contactname').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_contactname').is(':visible')) {
                if ($('#ui_txtarea_contactname').val() == "") {
                    $('#contactname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_contactname').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_contactname').is(':visible'))
                objContractsTimeline.Contactname = $('#ui_txt_contactname').val().trim();
            if ($('#ui_txtarea_contactname').is(':visible'))
                objContractsTimeline.Contactname = $('#ui_txtarea_contactname').val().trim();
        }
        else {
            if ($('#ui_txt_contactname').is(':visible'))
                objContractsTimeline.Contactname = $('#ui_txt_contactname').val().trim();
            if ($('#ui_txtarea_contactname').is(':visible'))
                objContractsTimeline.Contactname = $('#ui_txtarea_contactname').val().trim();
        }

    if ($('#displayStatuschangedate').is(':visible'))
        if (sessionStorage.getItem("isstatuschangedate") == "true") {
            if ($('#ui_dt_statuschangedate').val() == "") {
                $('#statuschangedate').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_statuschangedate').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_dt_statuschangedate').val() == "")
                    objContractsTimeline.Statuschange = null;
                else
                    objContractsTimeline.Statuschange = $('#ui_dt_statuschangedate').val();
            }
        }
        else {
            if ($('#ui_dt_statuschangedate').val() == "")
                objContractsTimeline.Statuschange = null;
            else
                objContractsTimeline.Statuschange = $('#ui_dt_statuschangedate').val();
        }

    if ($('#displayComments').is(':visible'))
        if (sessionStorage.getItem("iscomments") == "true") {
            if ($('#ui_txt_contractcomments').is(':visible')) {
                if ($('#ui_txt_contractcomments').val() == "") {
                    $('#comments').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_comments').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_contractcomments').is(':visible')) {
                if ($('#ui_txtarea_contractcomments').val() == "") {
                    $('#comments').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_comments').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_contractcomments').is(':visible'))
                objContractsTimeline.Comments = $('#ui_txt_contractcomments').val().trim();
            if ($('#ui_txtarea_contractcomments').is(':visible'))
                objContractsTimeline.Comments = $('#ui_txtarea_contractcomments').val().trim();
        }
        else {
            if ($('#ui_txt_contractcomments').is(':visible'))
                objContractsTimeline.Comments = $('#ui_txt_contractcomments').val().trim();
            if ($('#ui_txtarea_contractcomments').is(':visible'))
                objContractsTimeline.Comments = $('#ui_txtarea_contractcomments').val().trim();
        }

}
//#endregion

function SaveContractsTimeline(mode) {   
    var validator = $("#ui_dtg_ContractsTimeline").kendoValidator().data("kendoValidator");
    ValidateContractsTimelineFields();
    if ($('#ui_txt_version').val() == "" && $('#ui_txtarea_version').val() == "" &&
        $('#ui_txt_contactname').val() == "" && $('#ui_txtarea_contactname').val() == "" &&
        $('#ui_ddl_contracttype').val() == "" && $('#ui_ddl_contractstatus').val() == "" && $('#ui_ddl_currentlocation').val() == "" &&
        $('#ui_dt_statuschangedate').val() == "" && $('#ui_txt_comments').val() == "" &&
        $('#ui_txtarea_comments').val() == "") {
        popupNotification.show("Empty record detected,please enter some values.", "info");
        return false;
    } else {
        if (validator.validate() && retval === true &&
            (isvalidRegexforversion === true && isvalidRegexforcontactname === true))
            Savedetails(type = 26, objEditstudy = objContractsTimeline);
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    }
}

$(document).ready(function () {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(contractstimelineattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case contractstimeline:
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
                                        $("#ui_btn_AddContractsTimeline").attr("disabled", true);
                                }
                                if (iscreaterestricted == true)
                                    $("#ui_btn_AddContractsTimeline").attr("disabled", true);
                            }
                            if (iscreaterestricted == true)
                                $("#ui_btn_AddContractsTimeline").attr("disabled", true);
                            else
                                $("#ui_btn_AddContractsTimeline").removeAttr("disabled");
                            break;
                        case contracttype:
                            $("#ui_dtg_ContractsTimeline th[data-field=ContractType]").html(response[i].Name);
                            break;
                        case contractstatus:
                            $("#ui_dtg_ContractsTimeline th[data-field=ContractStatus]").html(response[i].Name);
                            break;
                        case version:
                            $("#ui_dtg_ContractsTimeline th[data-field=Version]").html(response[i].Name);
                            break;
                        case currentlocation:
                            $("#ui_dtg_ContractsTimeline th[data-field=CurrentLocation]").html(response[i].Name);
                            break;
                        case contactname:
                            $("#ui_dtg_ContractsTimeline th[data-field=ContactName]").html(response[i].Name);
                            break;
                        case statuschangedate:
                            $("#ui_dtg_ContractsTimeline th[data-field=StatusChangeDate]").html(response[i].Name);
                            break;
                        case comments:
                            $("#ui_dtg_ContractsTimeline th[data-field=Comments]").html(response[i].Name);
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