//#region Template declarations
var memplate = kendo.template($("#milestonestemplate").html());
//#endregion
//# region variables
var MilestoneName;


function OnDataBoundforMilestones() {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(milestonesattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                var grid = $("#ui_dtg_Milestones").data("kendoGrid");
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
                    grid.hideColumn(14);                    
                else 
                    grid.showColumn(14);
                    
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
                        grid.hideColumn(13);
                    return false;
                }
                else {
                    grid.showColumn(13);
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
function deleteMilestones(e) {
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
    var grid = $("#ui_dtg_Milestones").data("kendoGrid"); //Get the grid from which the pop-up is coming
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

function addMilestones() {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");
    var wnd = $("#Milestones").data("kendoWindow");
    wnd.content(memplate(kendo.template($("#milestonestemplate").html())));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadMilestonesAttributes("Create");

    CheckcharacterLength();

    isvalidRegexforname = isvalidRegexforparameters = true;

    $('#type,#phase,#estimatedcompletiondate,#milestonecompletiondate,#status,#remindersentdate').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    $("#Name,#parameters,#dependency").on("keyup", function (e) {
        $(this).nextAll("div.error").remove();
    })

    //#region Validate RegEx values for Milestones fields(Add mode)
    $("#ui_txtarea_name").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_name").val().trim();
        if (str != "")
            if ($("#regexexprforname").val() != "") {
                var expr = new RegExp($("#regexexprforname").val());
                var str = $("#ui_txtarea_name").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_name').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforname").val() + '</span>');
                    isvalidRegexforname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforname = true;
                    return true;
                }
            }
    });
    $("#ui_txt_name").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_name").val().trim();
        if (str != "")
            if ($("#regexexprforname").val() != "") {
                var expr = new RegExp($("#regexexprforname").val());
                var str = $("#ui_txt_name").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_name').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforname").val() + '</span>');
                    isvalidRegexforname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforname = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_parameters").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_parameters").val().trim();
        if (str != "")
            if ($("#regexexprforparameters").val() != "") {
                var expr = new RegExp($("#regexexprforparameters").val());
                var str = $("#ui_txtarea_parameters").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_parameters').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforparameters").val() + '</span>');
                    isvalidRegexforparameters = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforparameters = true;
                    return true;
                }
            }
    });
    $("#ui_txt_parameters").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_parameters").val().trim();
        if (str != "")
            if ($("#regexexprforparameters").val() != "") {
                var expr = new RegExp($("#regexexprforparameters").val());
                var str = $("#ui_txt_parameters").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_parameters').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforparameters").val() + '</span>');
                    isvalidRegexforparameters = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforparameters = true;
                    return true;
                }
            }
    });    
    //#endregion ValidateContactsFields

    //#region Save Milestones Actions(Add mode)
    $("#ui_btnSavemilestones").click(function (e) {
        SaveMilestones("Create");
    });
    //#endregion

}

function showMilestones(e) {
    var grid = $("#ui_dtg_Milestones").getKendoGrid();
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");
    var wnd = $("#Milestones").data("kendoWindow");
    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(memplate(dataItem));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadMilestonesAttributes("Edit");

    CheckcharacterLength();

    isvalidRegexforname = isvalidRegexforparameters = true;

    $('#type,#phase,#estimatedcompletiondate,#milestonecompletiondate,#status,#remindersentdate').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    $("#Name,#parameters,#dependency").on("keyup", function (e) {
        $(this).nextAll("div.error").remove();
    })


    //#region Validate RegEx values for Milestones fields(Edit mode)
    $("#ui_txtarea_name").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_name").val().trim();
        if (str != "")
            if ($("#regexexprforname").val() != "") {
                var expr = new RegExp($("#regexexprforname").val());
                var str = $("#ui_txtarea_name").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_name').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforname").val() + '</span>');
                    isvalidRegexforname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforname = true;
                    return true;
                }
            }
    });
    $("#ui_txt_name").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_name").val().trim();
        if (str != "")
            if ($("#regexexprforname").val() != "") {
                var expr = new RegExp($("#regexexprforname").val());
                var str = $("#ui_txt_name").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_name').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforname").val() + '</span>');
                    isvalidRegexforname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforname = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_parameters").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_parameters").val().trim();
        if (str != "")
            if ($("#regexexprforparameters").val() != "") {
                var expr = new RegExp($("#regexexprforparameters").val());
                var str = $("#ui_txtarea_parameters").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_parameters').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforparameters").val() + '</span>');
                    isvalidRegexforparameters = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforparameters = true;
                    return true;
                }
            }
    });
    $("#ui_txt_parameters").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_parameters").val().trim();
        if (str != "")
            if ($("#regexexprforparameters").val() != "") {
                var expr = new RegExp($("#regexexprforparameters").val());
                var str = $("#ui_txt_parameters").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_parameters').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforparameters").val() + '</span>');
                    isvalidRegexforparameters = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforparameters = true;
                    return true;
                }
            }
    });
    //#endregion ValidateContactsFields

    //#region Get existing Milestones
    $("#ui_num_milestoneid").val(dataItem.MilestoneId);
    $("#ui_txt_name,#ui_txtarea_name").val(dataItem.Name);
    MilestoneName = dataItem.Name;
    $("#ui_ddl_type").data('kendoDropDownList').value(dataItem.Type);
    $("#ui_ddl_phase").data('kendoDropDownList').value(dataItem.Phase);
    $("#ui_txt_parameters,#ui_txtarea_parameters").val(dataItem.Parameters);
    $("#ui_num_dependency").val(dataItem.Dependency);
    $("#ui_dt_estimatedcompletiondate").data("kendoDatePicker").value(dataItem.Estimatedcompletiondate);
    $("#ui_dt_milestonecompletiondate").data('kendoDatePicker').value(dataItem.Milestonecompletiondate);
    $("#ui_ddl_milestonestatus").data('kendoDropDownList').value(dataItem.MilestoneStatus);
    $("#ui_dt_remindersentdate").data('kendoDatePicker').value(dataItem.Remindersentdate);

    if ($('#ui_dt_milestonecompletiondate').val() === "" || $('#ui_dt_milestonecompletiondate').val() === "month day, year") {
        $('#ui_dt_milestonecompletiondate').data('kendoDatePicker').enable(false);
    }
    else {

        $('#ui_dt_milestonecompletiondate').data('kendoDatePicker').enable(true);
    }
    //#endregion

    //#region Save Milestones Actions(Add mode)
    $("#ui_btnSavemilestones").click(function (e) {
        SaveMilestones("Create");
    });
    //#endregion

}

function CheckcharacterLength() {
    $("textarea[maxlength]").keyup(function () {
        var charLength = $(this).val().length;
        var charLimit = $(this).attr("maxlength");
        $(this).nextAll("span.count").html(charLimit - charLength + " Characters left to enter");
    });
    $("input[maxlength]").keyup(function () {
        var charLength = $(this).val().length;
        var charLimit = $(this).attr("maxlength");
        $(this).nextAll("span.count").html(charLimit - charLength + " Characters left to enter");
    });
}

//#region Milestones fields
function ValidateMilestonesFields() {
    $(".error").remove();
    retval = true;
    objMilestones = new Object();
    objMilestones.StudyId = $('#StudyId').val();
    objMilestones.MilestoneId = $('#ui_num_milestoneid').val();
    objMilestones.Name = MilestoneName;

    if ($('#displayName').is(':visible'))
        if (sessionStorage.getItem("isname") === "true") {
            if ($('#ui_txt_name').is(':visible')) {
                if ($('#ui_txt_name').val() === "") {
                    $('#Name').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_name').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_name').is(':visible')) {
                if ($('#ui_txtarea_name').val() === "") {
                    $('#Name').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_name').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_name').is(':visible'))
                objMilestones.Name = $('#ui_txt_name').val().trim();
            if ($('#ui_txtarea_name').is(':visible'))
                objMilestones.Name = $('#ui_txtarea_name').val().trim();
        }
        else {
            if ($('#ui_txt_name').is(':visible'))
                objMilestones.Name = $('#ui_txt_name').val().trim();
            if ($('#ui_txtarea_name').is(':visible'))
                objMilestones.Name = $('#ui_txtarea_name').val().trim();
        }

    if ($('#displayType').is(':visible'))
        if (sessionStorage.getItem("istype") === "true") {
            if ($('#ui_ddl_type').val() === "") {
                $('#type').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_type').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_type').val() === "")
                    objMilestones.Type = null;
                else
                    objMilestones.Type = $('#ui_ddl_type').val();
            }
        }
        else {
            if ($('#ui_ddl_type').val() === "")
                objMilestones.Type = null;
            else
                objMilestones.Type = $('#ui_ddl_type').val();
        }

    if ($('#displayPhase').is(':visible'))
        if (sessionStorage.getItem("isphase") === "true") {
            if ($('#ui_ddl_phase').val() === "") {
                $('#phase').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_phase').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_phase').val() === "")
                    objMilestones.Phase = null;
                else
                    objMilestones.Phase = $('#ui_ddl_phase').val();
            }
        }
        else {
            if ($('#ui_ddl_phase').val() === "")
                objMilestones.Phase = null;
            else
                objMilestones.Phase = $('#ui_ddl_phase').val();
        }

    if ($('#displayParameters').is(':visible'))
        if (sessionStorage.getItem("isparameters") === "true") {
            if ($('#ui_txt_parameters').is(':visible')) {
                if ($('#ui_txt_parameters').val() === "") {
                    $('#parameters').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_parameters').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_parameters').is(':visible')) {
                if ($('#ui_txtarea_parameters').val() === "") {
                    $('#parameters').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_parameters').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_parameters').is(':visible'))
                objMilestones.Parameters = $('#ui_txt_parameters').val().trim();
            if ($('#ui_txtarea_parameters').is(':visible'))
                objMilestones.Parameters = $('#ui_txtarea_parameters').val().trim();
        }
        else {
            if ($('#ui_txt_parameters').is(':visible'))
                objMilestones.Parameters = $('#ui_txt_parameters').val().trim();
            if ($('#ui_txtarea_parameters').is(':visible'))
                objMilestones.Parameters = $('#ui_txtarea_parameters').val().trim();
        }

    if ($('#displayDependency').is(':visible'))
        if (sessionStorage.getItem("isdependency") == "true") {
            if ($('#ui_num_dependency').is(':visible')) {
                if ($('#ui_num_dependency').val() == "") {
                    $('#dependency').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_dependency').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_num_dependency').is(':visible'))
                objMilestones.Dependency = $('#ui_num_dependency').val().trim();
        }
        else {
            if ($('#ui_num_dependency').is(':visible'))
                objMilestones.Dependency = $('#ui_num_dependency').val().trim();
        }

    if ($('#displayEstimatedcompletiondate').is(':visible'))
        if (sessionStorage.getItem("isestimatedcompletiondate") === "true") {
            if ($('#ui_dt_estimatedcompletiondate').val() ==="") {
                $('#estimatedcompletiondate').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_estimatedcompletiondate').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_dt_estimatedcompletiondate').val() === "")
                    objMilestones.Estimatedcompletiondate = null;
                else
                    objMilestones.Estimatedcompletiondate = $('#ui_dt_estimatedcompletiondate').val();
            }
        }
        else {
            if ($('#ui_dt_estimatedcompletiondate').val() === "")
                objMilestones.Estimatedcompletiondate = null;
            else
                objMilestones.Estimatedcompletiondate = $('#ui_dt_estimatedcompletiondate').val();
        }

    if ($('#displayMilestonecompletiondate').is(':visible'))
        if (sessionStorage.getItem("ismilestonecompletiondate") === "true") {
            if ($('#ui_dt_milestonecompletiondate').val() === "") {
                $('#milestonecompletiondate').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_milestonecompletiondate').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_dt_milestonecompletiondate').val() === "")
                    objMilestones.Milestonecompletiondate = null;
                else
                    objMilestones.Milestonecompletiondate = $('#ui_dt_milestonecompletiondate').val();
            }
        }
        else {
            if ($('#ui_dt_milestonecompletiondate').val() === "")
                objMilestones.Milestonecompletiondate = null;
            else
                objMilestones.Milestonecompletiondate = $('#ui_dt_milestonecompletiondate').val();
        }

    if ($('#displayStatus').is(':visible'))
        if (sessionStorage.getItem("isstatus") === "true") {
            if ($('#ui_ddl_milestonestatus').val() === "") {
                $('#status').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_status').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_milestonestatus').val() === "")
                    objMilestones.MilestoneStatus = null;
                else
                    objMilestones.MilestoneStatus = $('#ui_ddl_milestonestatus').val();
            }
        }
        else {
            if ($('#ui_ddl_milestonestatus').val() === "")
                objMilestones.MilestoneStatus = null;
            else
                objMilestones.MilestoneStatus = $('#ui_ddl_milestonestatus').val();
        }

    if ($('#displayRemindersentdate').is(':visible'))
        if (sessionStorage.getItem("isremindersentdate") === "true") {
            if ($('#ui_dt_remindersentdate').val() === "") {
                $('#remindersentdate').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_remindersentdate').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_dt_remindersentdate').val() === "")
                    objMilestones.Remindersentdate = null;
                else
                    objMilestones.Remindersentdate = $('#ui_dt_remindersentdate').val();
            }
        }
        else {
            if ($('#ui_dt_remindersentdate').val() ==="")
                objMilestones.Remindersentdate = null;
            else
                objMilestones.Remindersentdate = $('#ui_dt_remindersentdate').val();
        }

}
//#endregion

function SaveMilestones(mode) {
    var validator = $("#ui_dtg_Milestones").kendoValidator().data("kendoValidator");
    ValidateMilestonesFields();
    if ($('#ui_txt_name').val() == "" && $('#ui_txtarea_name').val() == "" &&
        $('#ui_txtarea_parameters').val() == "" && $('#ui_txt_parameters').val() == "" &&
        $('#ui_ddl_city').val() == "" && $('#ui_ddl_type').val() == "" && $('#ui_ddl_phase').val() == "" &&
        $('#ui_dt_estimatedcompletiondate').val() == "" && $('#ui_dt_milestonecompletiondate').val() == "" &&
        $('#ui_ddl_milestonestatus').val() == "" && $('#ui_dt_remindersentdate').val() == "") {
        popupNotification.show("Empty record detected,please enter some values.", "info");
        return false;
    } else {
        if (validator.validate() && retval === true &&
            (isvalidRegexforname === true && isvalidRegexforparameters === true))
            Savedetails(type = 23, objEditstudy = objMilestones);
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    }
}

function LoadMilestonesAttributes(mode) {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(milestonesattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case milestonename:
                            Textdetails(response, "displayName", "ui_lbl_name", "ui_img_helpTextforname", "isname", "ui_txt_name", "ui_txtarea_name", "ui_lbl_charsleftforname", "regexexprforname", "validationmsgforname", mode);
                            break;
                        case milestonetype:
                            DropDowndetails(response, "displayType", "ui_lbl_type", "ui_img_helpTextfortype", "istype", mode);
                            break;
                        case milestonephase:
                            DropDowndetails(response, "displayPhase", "ui_lbl_phase", "ui_img_helpTextforphase", "isphase", mode);
                            break;
                        case milestoneparameters:
                            Textdetails(response, "displayParameters", "ui_lbl_parameters", "ui_img_helpTextforparameters", "isparameters", "ui_txt_parameters", "ui_txtarea_parameters", "ui_lbl_charsleftforparameters", "regexexprforparameters", "validationmsgforparameters", mode);
                            break;
                        case dependency:
                            NumberFielddetails(response, "displayDependency", "ui_lbl_dependency", "ui_img_helpTextfordependency", "isdependency", "ui_num_dependency", mode);
                            break;
                        case estimatedcompletiondate:
                            DropDowndetails(response, "displayEstimatedcompletiondate", "ui_lbl_estimatedcompletiondate", "ui_img_helpTextforestimatedcompletiondate", "isestimatedcompletiondate", mode);
                            break;
                        case milestonecompletiondate:
                            DropDowndetails(response, "displayMilestonecompletiondate", "ui_lbl_milestonecompletiondate", "ui_img_helpTextformilestonecompletiondate", "ismilestonecompletiondate", mode);
                            break;
                        case status:
                            DropDowndetails(response, "displayStatus", "ui_lbl_status", "ui_img_helpTextforstatus", "isstatus", mode);
                            break;
                        case remindersentdate:
                            DropDowndetails(response, "displayRemindersentdate", "ui_lbl_remindersentdate", "ui_img_helpTextforremindersentdate", "isremindersentdate", mode);
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

$("#milestones").on("click", function () {
    $('#milestonesdetails').removeClass('milestonesdetails');
});

$(document).ready(function () {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(milestonesattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    switch (response[i].FieldType) {
                        case milestones:
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
                                        $("#ui_btn_AddMilestones").attr("disabled", true);
                                }
                                if (iscreaterestricted == true)
                                    $("#ui_btn_AddMilestones").attr("disabled", true);
                            }
                            if (iscreaterestricted == true)
                                $("#ui_btn_AddMilestones").attr("disabled", true);
                            else
                                $("#ui_btn_AddMilestones").removeAttr("disabled");
                            break;
                        case milestonename:
                            $("#ui_dtg_Milestones th[data-field=Name]").html(response[i].Name);
                            break;
                        case milestonetype:
                            $("#ui_dtg_Milestones th[data-field=Type]").html(response[i].Name);
                            break;
                        case milestonephase:
                            $("#ui_dtg_Milestones th[data-field=Phase]").html(response[i].Name);
                            break;
                        case milestoneparameters:
                            $("#ui_dtg_Milestones th[data-field=Parameters]").html(response[i].Name);
                            break;
                        case dependency:
                            $("#ui_dtg_Milestones th[data-field=Dependency]").html(response[i].Name);
                            break;
                        case estimatedcompletiondate:
                            $("#ui_dtg_Milestones th[data-field=Estimatedcompletiondate]").html(response[i].Name);
                            break;
                        case milestonecompletiondate:
                            $("#ui_dtg_Milestones th[data-field=Milestonecompletiondate]").html(response[i].Name);
                            break;
                        case status:
                            $("#ui_dtg_Milestones th[data-field=MilestoneStatus]").html(response[i].Name);
                            break;
                        case remindersentdate:
                            $("#ui_dtg_Milestones th[data-field=Remindersentdate]").html(response[i].Name);
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

//#adding row number to Milestones fields
var rowNumber = 0;

function resetRowNumber(e) {
    e.preventDefault();
    rowNumber = 0;
}

function renderNumber(data) {
    if (data.MilestoneId !== 0)
        return ++rowNumber;
}
function renderRecordNumber(data) {
    if (data.MilestoneId !== 0) {
        var page = parseInt($("#ui_dtg_Milestones").data("kendoGrid").dataSource.page()) - 1;
        var pagesize = $("#ui_dtg_Milestones").data("kendoGrid").dataSource.pageSize();
        return parseInt(rowNumber + (parseInt(page) * parseInt(pagesize)));
    }
    else
        return "";
}
//#endregion