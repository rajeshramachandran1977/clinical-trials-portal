//#region Template declarations
var objectivesandendpointstemplate = kendo.template($("#objectivesandendpointstemplate").html());
//#endregion

function deleteObjectivesandendpoints(e) {
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
    var grid = $("#ui_dtg_gridObjectivesandEndpoints").data("kendoGrid"); //Get the grid from which the pop-up is coming
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

function addObjectivesandendpoints() {
    var wnd = $("#ObjectivesandEndpoints").data("kendoWindow");
    wnd.content(objectivesandendpointstemplate(kendo.template($("#objectivesandendpointstemplate").html())));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadObjectivesandendpointsattributes();

    CheckcharacterLength();

    isvalidRegexforobjectivedescription = isvalidRegexforendpointdescription = true;

    $('#objectivetype,#objectivename,#objectivedescription,#endpointDescription').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    //#region Validate RegEx values for Treatment Information(Add mode)
    $("#ui_txtarea_objectivedescription").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_objectivedescription").val().trim();
        if (str != "")
            if ($("#regexexprforobjectivedescription").val() != "") {
                var expr = new RegExp($("#regexexprforobjectivedescription").val());
                var str = $("#ui_txtarea_objectivedescription").val();
                if (str != "" && !expr.test(str)) {
                    $('#objectivedescription').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforobjectivedescription").val() + '</div>');
                    isvalidRegexforobjectivedescription = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforobjectivedescription = true;
                    return true;
                }
            }
    });
    $("#ui_txt_objectivedescription").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_objectivedescription").val().trim();
        if (str != "")
            if ($("#regexexprforobjectivedescription").val() != "") {
                var expr = new RegExp($("#regexexprforobjectivedescription").val());
                var str = $("#ui_txt_objectivedescription").val();
                if (str != "" && !expr.test(str)) {
                    $('#objectivedescription').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforobjectivedescription").val() + '</div>');
                    isvalidRegexforobjectivedescription = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforobjectivedescription = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_endpointdescription").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_endpointdescription").val().trim();
        if (str != "")
            if ($("#regexexprforendpointdescription").val() != "") {
                var expr = new RegExp($("#regexexprforendpointdescription").val());
                var str = $("#ui_txtarea_endpointdescription").val();
                if (str != "" && !expr.test(str)) {
                    $('#endpointDescription').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforendpointdescription").val() + '</div>');
                    isvalidRegexforendpointdescription = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforendpointdescription = true;
                    return true;
                }
            }
    });
    $("#ui_txt_endpointdescription").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_endpointdescription").val().trim();
        if (str != "")
            if ($("#regexexprforendpointdescription").val() != "") {
                var expr = new RegExp($("#regexexprforendpointdescription").val());
                var str = $("#ui_txt_endpointdescription").val();
                if (str != "" && !expr.test(str)) {
                    $('#endpointDescription').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforendpointdescription").val() + '</div>');
                    isvalidRegexforendpointdescription = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforendpointdescription = true;
                    return true;
                }
            }
    });

    $("#ui_btnSaveObjectivesandendpoints").click(function (e) {
        SaveObjectivesandendpoints("Create");
    });

    $("#ui_dtg_gridObjectivesandEndpoints").data("kendoGrid").dataSource.read();
    $("#ui_dtg_gridObjectivesandEndpoints").data("kendoGrid").refresh();
}

function showObjectivesandendpoints(e) {
    var grid = $("#ui_dtg_gridObjectivesandEndpoints").getKendoGrid();
    var wnd = $("#ObjectivesandEndpoints").data("kendoWindow");
    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(objectivesandendpointstemplate(dataItem));
    wnd.center().open();

    LoadObjectivesandendpointsattributes();

    CheckcharacterLength();

    isvalidRegexforobjectivedescription = isvalidRegexforendpointdescription = true;

    $('#objectivetype,#objectivename,#objectivedescription,#endpointDescription').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    //#region Get existing Indications
    $('#ui_num_objandendpointsid').val(dataItem.ObjandEndPointsId);
    $("#ui_ddl_objectivetype").data('kendoDropDownList').value(dataItem.ObjectiveType);
    $("#ui_ddl_objectivename").data('kendoDropDownList').value(dataItem.ObjectiveName);
    $("#ui_txt_objectivedescription,#ui_txtarea_objectivedescription").val(dataItem.ObjectiveDescription);
    $("#ui_txt_endpointdescription,#ui_txtarea_endpointdescription").val(dataItem.EndpointDescription);
    //#endregion

    $("#ui_btnSaveObjectivesandendpoints").click(function (e) {
        SaveObjectivesandendpoints("Edit");
    });
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

//#region Validate Objectives and end points Fields
function ValidateObjectivesandendpointsFields() {
    $(".error").remove();
    retval = true;
    objObjectivesandendpoints = new Object();
    objObjectivesandendpoints.StudyId = $('#StudyId').val();
    objObjectivesandendpoints.ObjandEndPointsId = $('#ui_num_objandendpointsid').val();

    if ($('#displayObjectivetype').is(':visible'))
        if (sessionStorage.getItem("isobjectivetype") == "true") {

            if ($('#ui_ddl_objectivetype').val() == "") {
                $('#objectivetype').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_objectivetype').html() + ' is required</div>');
                retval = false;
            }
            else
                objObjectivesandendpoints.ObjectiveType = $('#ui_ddl_objectivetype').val();
        }
        else
            objObjectivesandendpoints.ObjectiveType = $('#ui_ddl_objectivetype').val();

    if ($('#displayObjectiveName').is(':visible'))
        if (sessionStorage.getItem("isobjectivename") == "true") {
            if ($('#ui_ddl_objectivename').val() == "") {
                $('#objectivename').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_objectivename').html() + ' is required</div>');
                retval = false;
            }
            else
                objObjectivesandendpoints.ObjectiveName = $('#ui_ddl_objectivename').val();
        }
        else
            objObjectivesandendpoints.ObjectiveName = $('#ui_ddl_objectivename').val();

    if ($('#displayObjectivedescription').is(':visible'))
        if (sessionStorage.getItem("isobjectivedescription") == "true") {
            if ($('#ui_txt_objectivedescription').is(':visible')) {
                if ($('#ui_txt_objectivedescription').val() == "") {
                    $('#objectivedescription').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_objectivedescription').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_objectivedescription').is(':visible')) {
                if ($('#ui_txtarea_objectivedescription').val() == "") {
                    $('#objectivedescription').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_objectivedescription').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_objectivedescription').is(':visible'))
                objObjectivesandendpoints.ObjectiveDescription = $('#ui_txtarea_objectivedescription').val().trim();
            if ($('#ui_txt_objectivedescription').is(':visible'))
                objObjectivesandendpoints.ObjectiveDescription = $('#ui_txt_objectivedescription').val().trim();
        }
        else {
            if ($('#ui_txtarea_objectivedescription').is(':visible'))
                objObjectivesandendpoints.ObjectiveDescription = $('#ui_txtarea_objectivedescription').val().trim();
            if ($('#ui_txt_objectivedescription').is(':visible'))
                objObjectivesandendpoints.ObjectiveDescription = $('#ui_txt_objectivedescription').val().trim();
        }

    if ($('#displayEndpointDescription').is(':visible'))
        if (sessionStorage.getItem("isendpointdescription") == "true") {
            if ($('#ui_txt_endpointdescription').is(':visible')) {
                if ($('#ui_txt_endpointdescription').val() == "") {
                    $('#endpointDescription').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_endpointdescription').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_endpointdescription').is(':visible')) {
                if ($('#ui_txtarea_endpointdescription').val() == "") {
                    $('#endpointDescription').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_endpointdescription').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_endpointdescription').is(':visible'))
                objObjectivesandendpoints.EndpointDescription = $('#ui_txtarea_endpointdescription').val().trim();
            if ($('#ui_txt_endpointdescription').is(':visible'))
                objObjectivesandendpoints.EndpointDescription = $('#ui_txt_endpointdescription').val().trim();
        }
        else {
            if ($('#ui_txtarea_endpointdescription').is(':visible'))
                objObjectivesandendpoints.EndpointDescription = $('#ui_txtarea_endpointdescription').val().trim();
            if ($('#ui_txt_endpointdescription').is(':visible'))
                objObjectivesandendpoints.EndpointDescription = $('#ui_txt_endpointdescription').val().trim();
        }
}
    //#endregion

//#region Save Objectives and endpoints
function SaveObjectivesandendpoints(mode) {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");
    ValidateObjectivesandendpointsFields();
    if ($('#ui_ddl_objectivetype').val() == "" && $('#ui_ddl_objectivename').val() == ""
        && $('#ui_txt_objectivedescription').val() == "" && $('#ui_txtarea_objectivedescription').val() == ""
        && $('#ui_txt_endpointdescription').val() == "" && $('#ui_txtarea_endpointdescription').val() == "") {
        popupNotification.show("Empty record detected,please enter some values.", "info");
        return false;
    }
    else {
        if (validator.validate() && retval === true) {
            Savedetails(type = 17, objEditstudy = objObjectivesandendpoints, mode = mode);
            $("#ObjectivesandEndpoints").data("kendoWindow").close();
            return true;
        }
        else
            popupNotification.show("There are errors on the page.Please correct them to continue.", "error");
        return false;
    }
}
    //#endregion

function LoadObjectivesandendpointsattributes() {
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/GetAttributeValues/",
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case objectivetypes:
                            DropDowndetails(response, "displayObjectivetype", "ui_lbl_objectivetype", "ui_img_helpTextforobjectivetype", "isobjectivetype");
                            break;
                        case objectivenames:
                            DropDowndetails(response, "displayObjectiveName", "ui_lbl_objectivename", "ui_img_helpTextforobjectivename", "isobjectivename");
                            break;
                        case objectivedescription:
                            Textdetails(response, "displayObjectivedescription", "ui_lbl_objectivedescription", "ui_img_helpTextforobjectivedescription", "isobjectivedescription", "ui_txt_objectivedescription", "ui_txtarea_objectivedescription", "ui_lbl_charsleftforobjectivedescription", "regexexprforobjectivedescription", "validationmsgforobjectivedescription")
                            break;
                        case endpointdescription:
                            Textdetails(response, "displayEndpointDescription", "ui_lbl_endpointdescription", "ui_img_helpTextforendpointdescription", "isendpointdescription", "ui_txt_endpointdescription", "ui_txtarea_endpointdescription", "ui_lbl_charsleftforendpointdescription", "regexexprforendpointdescription", "validationmsgforendpointdescription")
                            break;
                        default:
                            break;
                    }
                }
            }
        },
        failure: function (response) {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });
}

$(document).ready(function () {
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/GetAttributeValues/",
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case objectivetypes:
                            $("#ui_dtg_gridObjectivesandEndpoints th[data-field=ObjectiveType]").html(response[i].Name);
                            break;
                        case objectivenames:
                            $("#ui_dtg_gridObjectivesandEndpoints th[data-field=ObjectiveName]").html(response[i].Name);
                            break;
                        case objectivedescription:
                            $("#ui_dtg_gridObjectivesandEndpoints th[data-field=ObjectiveDescription]").html(response[i].Name);
                            break;
                        case endpointdescription:
                            $("#ui_dtg_gridObjectivesandEndpoints th[data-field=EndpointDescription]").html(response[i].Name);
                        default:
                            break;
                    }
                }
            }
        },
        failure: function (response) {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });
});