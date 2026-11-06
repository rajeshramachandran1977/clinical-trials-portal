//#region Template declarations
var statustemplate = kendo.template($("#statustemplate").html());
//#endregion

//#region delete row functions in grids
function deleteStatus(e) {
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
    var grid = $("#ui_dtg_Status").data("kendoGrid"); //Get the grid from which the pop-up is coming
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

function addStatusdetails() {
    var wnd = $("#Status").data("kendoWindow");
    wnd.content(statustemplate(kendo.template($("#statustemplate").html())));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadStatusAttributes();

    CheckcharacterLength();

    $('#date').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    $("#stage,#state,#status,#time").on("keyup", function (e) {
        $(this).nextAll("div.error").remove();
    })

    isvalidRegexforstage = isvalidRegexforstate = isvalidRegexforstatus = isvalidRegexfortime = true;

    //#region Validate RegEx values for Status fields(Add mode)
    $("#ui_txtarea_stage").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_stage").val().trim();
        if (str != "")
            if ($("#regexexprforstage").val() != "") {
                var expr = new RegExp($("#regexexprforstage").val());
                var str = $("#ui_txtarea_stage").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_stage').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstage").val() + '</span>');
                    isvalidRegexforstage = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstage = true;
                    return true;
                }
            }
    });
    $("#ui_txt_stage").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_stage").val().trim();
        if (str != "")
            if ($("#regexexprforstage").val() != "") {
                var expr = new RegExp($("#regexexprforstage").val());
                var str = $("#ui_txt_stage").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_stage').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstage").val() + '</span>');
                    isvalidRegexforstage = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstage = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_state").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_state").val().trim();
        if (str != "")
            if ($("#regexexprforstate").val() != "") {
                var expr = new RegExp($("#regexexprforstate").val());
                var str = $("#ui_txtarea_state").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_state').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstate").val() + '</span>');
                    isvalidRegexforstate = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstate = true;
                    return true;
                }
            }
    });
    $("#ui_txt_state").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_state").val().trim();
        if (str != "")
            if ($("#regexexprforstate").val() != "") {
                var expr = new RegExp($("#regexexprforstate").val());
                var str = $("#ui_txt_state").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_state').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstate").val() + '</span>');
                    isvalidRegexforstate = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstate = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_status").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_status").val().trim();
        if (str != "")
            if ($("#regexexprforstatus").val() != "") {
                var expr = new RegExp($("#regexexprforstatus").val());
                var str = $("#ui_txtarea_status").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_status').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstatus").val() + '</span>');
                    isvalidRegexforstatus = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstatus = true;
                    return true;
                }
            }
    });
    $("#ui_txt_status").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_status").val().trim();
        if (str != "")
            if ($("#regexexprforstatus").val() != "") {
                var expr = new RegExp($("#regexexprforstatus").val());
                var str = $("#ui_txt_status").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_status').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstatus").val() + '</span>');
                    isvalidRegexforstatus = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstatus = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_time").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_time").val().trim();
        if (str != "")
            if ($("#regexexprfortime").val() != "") {
                var expr = new RegExp($("#regexexprfortime").val());
                var str = $("#ui_txtarea_time").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_time').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortime").val() + '</span>');
                    isvalidRegexfortime = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortime = true;
                    return true;
                }
            }
    });
    $("#ui_txt_time").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_time").val().trim();
        if (str != "")
            if ($("#regexexprfortime").val() != "") {
                var expr = new RegExp($("#regexexprfortime").val());
                var str = $("#ui_txt_time").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_time').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortime").val() + '</span>');
                    isvalidRegexfortime = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortime = true;
                    return true;
                }
            }
    });

    //#endregion

    //#region Save Status(Add mode)
    $("#ui_btnSavestatus").click(function (e) {
        SaveStatus("Create");
    });
    //#endregion

}

function showStatus(e) {
    var grid = $("#ui_dtg_Status").getKendoGrid();
    var wnd = $("#Status").data("kendoWindow");
    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(statustemplate(dataItem));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadStatusAttributes();

    CheckcharacterLength();

    $('#date').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    $("#stage,#state,#status,#time").on("keyup", function (e) {
        $(this).nextAll("div.error").remove();
    })

    isvalidRegexforstage = isvalidRegexforstate = isvalidRegexforstatus = isvalidRegexfortime = true;

    //#region Validate RegEx values for Status fields(Add mode)
    $("#ui_txtarea_stage").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_stage").val().trim();
        if (str != "")
            if ($("#regexexprforstage").val() != "") {
                var expr = new RegExp($("#regexexprforstage").val());
                var str = $("#ui_txtarea_stage").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_stage').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstage").val() + '</span>');
                    isvalidRegexforstage = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstage = true;
                    return true;
                }
            }
    });
    $("#ui_txt_stage").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_stage").val().trim();
        if (str != "")
            if ($("#regexexprforstage").val() != "") {
                var expr = new RegExp($("#regexexprforstage").val());
                var str = $("#ui_txt_stage").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_stage').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstage").val() + '</span>');
                    isvalidRegexforstage = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstage = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_state").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_state").val().trim();
        if (str != "")
            if ($("#regexexprforstate").val() != "") {
                var expr = new RegExp($("#regexexprforstate").val());
                var str = $("#ui_txtarea_state").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_state').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstate").val() + '</span>');
                    isvalidRegexforstate = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstate = true;
                    return true;
                }
            }
    });
    $("#ui_txt_state").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_state").val().trim();
        if (str != "")
            if ($("#regexexprforstate").val() != "") {
                var expr = new RegExp($("#regexexprforstate").val());
                var str = $("#ui_txt_state").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_state').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstate").val() + '</span>');
                    isvalidRegexforstate = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstate = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_status").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_status").val().trim();
        if (str != "")
            if ($("#regexexprforstatus").val() != "") {
                var expr = new RegExp($("#regexexprforstatus").val());
                var str = $("#ui_txtarea_status").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_status').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstatus").val() + '</span>');
                    isvalidRegexforstatus = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstatus = true;
                    return true;
                }
            }
    });
    $("#ui_txt_status").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_status").val().trim();
        if (str != "")
            if ($("#regexexprforstatus").val() != "") {
                var expr = new RegExp($("#regexexprforstatus").val());
                var str = $("#ui_txt_status").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_status').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforstatus").val() + '</span>');
                    isvalidRegexforstatus = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforstatus = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_time").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_time").val().trim();
        if (str != "")
            if ($("#regexexprfortime").val() != "") {
                var expr = new RegExp($("#regexexprfortime").val());
                var str = $("#ui_txtarea_time").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_time').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortime").val() + '</span>');
                    isvalidRegexfortime = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortime = true;
                    return true;
                }
            }
    });
    $("#ui_txt_time").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_time").val().trim();
        if (str != "")
            if ($("#regexexprfortime").val() != "") {
                var expr = new RegExp($("#regexexprfortime").val());
                var str = $("#ui_txt_time").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_time').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortime").val() + '</span>');
                    isvalidRegexfortime = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortime = true;
                    return true;
                }
            }
    });

    //#endregion

    //#region Get existing Invoices
    $("#ui_num_statusid").val(dataItem.StatusId);
    $("#ui_txt_stage,#ui_txtarea_stage").val(dataItem.Stage);
    $("#ui_txt_state,#ui_txtarea_state").val(dataItem.State);
    $("#ui_txt_status,#ui_txtarea_status").val(dataItem.StudyStatus);
    $("#ui_dt_date").data("kendoDatePicker").value(dataItem.Date);
    $("#ui_txt_time,#ui_txtarea_time").val(dataItem.Time);
    //#endregion

    //#region Save Status(Add mode)
    $("#ui_btnSavestatus").click(function (e) {
        SaveStatus("Create");
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

//#region Status fields
function ValidateStatusFields() {
    $(".error").remove();
    retval = true;
    objStatus = new Object();
    objStatus.StudyId = $('#StudyId').val();
    objStatus.StatusId = $('#ui_num_statusid').val();

    if ($('#displayStatusstage').is(':visible'))
        if (sessionStorage.getItem("isstage") == "true") {
            if ($('#ui_txt_stage').is(':visible')) {
                if ($('#ui_txt_stage').val() == "") {
                    $('#stage').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_stag').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_stage').is(':visible')) {
                if ($('#ui_txtarea_stage').val() == "") {
                    $('#stage').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_stag').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_stage').is(':visible'))
                objStatus.Stage = $('#ui_txt_stage').val().trim();
            if ($('#ui_txtarea_stage').is(':visible'))
                objStatus.Stage = $('#ui_txtarea_stage').val().trim();
        }
        else {
            if ($('#ui_txt_stage').is(':visible'))
                objStatus.Stage = $('#ui_txt_stage').val().trim();
            if ($('#ui_txtarea_stage').is(':visible'))
                objStatus.Stage = $('#ui_txtarea_stage').val().trim();
        }

    if ($('#displayState').is(':visible'))
        if (sessionStorage.getItem("isstate") == "true") {
            if ($('#ui_txt_state').is(':visible')) {
                if ($('#ui_txt_state').val() == "") {
                    $('#state').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_state').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_state').is(':visible')) {
                if ($('#ui_txtarea_state').val() == "") {
                    $('#state').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_state').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_state').is(':visible'))
                objStatus.State = $('#ui_txt_state').val().trim();
            if ($('#ui_txtarea_state').is(':visible'))
                objStatus.State = $('#ui_txtarea_state').val().trim();
        }
        else {
            if ($('#ui_txt_state').is(':visible'))
                objStatus.State = $('#ui_txt_state').val().trim();
            if ($('#ui_txtarea_state').is(':visible'))
                objStatus.State = $('#ui_txtarea_state').val().trim();
        }

    if ($('#displayStatus').is(':visible'))
        if (sessionStorage.getItem("isstatus") == "true") {
            if ($('#ui_txt_status').is(':visible')) {
                if ($('#ui_txt_status').val() == "") {
                    $('#status').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_status').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_status').is(':visible')) {
                if ($('#ui_txtarea_status').val() == "") {
                    $('#status').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_status').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_status').is(':visible'))
                objStatus.StudyStatus = $('#ui_txt_status').val().trim();
            if ($('#ui_txtarea_status').is(':visible'))
                objStatus.StudyStatus = $('#ui_txtarea_status').val().trim();
        }
        else {
            if ($('#ui_txt_status').is(':visible'))
                objStatus.StudyStatus = $('#ui_txt_status').val().trim();
            if ($('#ui_txtarea_status').is(':visible'))
                objStatus.StudyStatus = $('#ui_txtarea_status').val().trim();
        }

    if ($('#displayDate').is(':visible'))
        if (sessionStorage.getItem("isdate") == "true") {
            if ($('#ui_dt_date').val() == "month day, year") {
                $('#date').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_date').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_dt_date').val() == "month day, year")
                    objStatus.Date = null;
                else
                    objStatus.Date = $('#ui_dt_date').val();
            }
        }
        else {
            if ($('#ui_dt_date').val() == "month day, year")
                objStatus.Date = null;
            else
                objStatus.Date = $('#ui_dt_date').val();
        }

    if ($('#displayTime').is(':visible'))
        if (sessionStorage.getItem("istime") == "true") {
            if ($('#ui_txt_time').is(':visible')) {
                if ($('#ui_txt_time').val() == "") {
                    $('#time').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_time').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_time').is(':visible')) {
                if ($('#ui_txtarea_time').val() == "") {
                    $('#time').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_time').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_time').is(':visible'))
                objStatus.Time = $('#ui_txt_time').val().trim();
            if ($('#ui_txtarea_time').is(':visible'))
                objStatus.Time = $('#ui_txtarea_time').val().trim();
        }
        else {
            if ($('#ui_txt_time').is(':visible'))
                objStatus.Time = $('#ui_txt_time').val().trim();
            if ($('#ui_txtarea_time').is(':visible'))
                objStatus.Time = $('#ui_txtarea_time').val().trim();
        }
}
//#endregion

function SaveStatus(mode) {
    var validator = $("#ui_dtg_Status").kendoValidator().data("kendoValidator");   
    ValidateStatusFields();
    if (validator.validate() && retval === true &&
        (isvalidRegexforstage === true && isvalidRegexforstate === true &&
            isvalidRegexforstatus === true && isvalidRegexfortime === true))
        Savedetails(type = 27, objEditstudy = objStatus);
    else
        popupNotification.show(errorsinthepage, "error");
    return false;
}

function LoadStatusAttributes() {
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
                        case statusstage:
                            Textdetails(response, "displayStatusstage", "ui_lbl_stag", "ui_img_helpTextforstage", "isstage", "ui_txt_stage", "ui_txtarea_stage", "ui_lbl_charsleftforstage", "regexexprforstage", "validationmsgforstage");
                            break;
                        case statusstate:
                            Textdetails(response, "displayState", "ui_lbl_state", "ui_img_helpTextforstate", "isstate", "ui_txt_state", "ui_txtarea_state", "ui_lbl_charsleftforstate", "regexexprforstate", "validationmsgforstate");
                            break;
                        case status:
                            Textdetails(response, "displayStatus", "ui_lbl_status", "ui_img_helpTextforstatus", "isstatus", "ui_txt_status", "ui_txtarea_status", "ui_lbl_charsleftforstatus", "regexexprforstatus", "validationmsgforstatus");
                            break;
                        case date:
                            DropDowndetails(response, "displayDate", "ui_lbl_date", "ui_img_helpTextfordate", "isdate");
                            break;
                        case time:
                            Textdetails(response, "displayTime", "ui_lbl_time", "ui_img_helpTextfortime", "istime", "ui_txt_time", "ui_txtarea_time", "ui_lbl_charsleftfortime", "regexexprfortime", "validationmsgfortime");
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

$("#status").on("click", function () {
    $('#statusdetails').removeClass('statusdetails');
});

$(document).ready(function () {
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
                    switch (response[i].FieldType) {
                        case statusstage:
                            $("#ui_dtg_Status th[data-field=Stage]").html(response[i].Name);
                            break;
                        case statusstate:
                            $("#ui_dtg_Status th[data-field=State]").html(response[i].Name);
                            break;
                        case status:
                            $("#ui_dtg_Status th[data-field=StudyStatus]").html(response[i].Name);
                            break;
                        case date:
                            $("#ui_dtg_Status th[data-field=Date]").html(response[i].Name);
                            break;
                        case time:
                            $("#ui_dtg_Status th[data-field=Time]").html(response[i].Name);
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