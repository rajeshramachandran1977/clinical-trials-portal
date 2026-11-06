//#region Template declarations
var indicationstemplate = kendo.template($("#indicationstemplate").html());
    //#endregion

function deleteIndications(e) {
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
    var grid = $("#ui_dtg_gridindications").data("kendoGrid"); //Get the grid from which the pop-up is coming
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

function addIndications() {
    var wnd = $("#Indications").data("kendoWindow");
    wnd.content(indicationstemplate(kendo.template($("#indicationstemplate").html())));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadIndicationsattributes();

    CheckcharacterLength();

    $("#ui_btnSaveindications").click(function (e) {
        SaveIndications("Create");
    });

    $('#indication,#indicationtype').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    $("#ui_dtg_gridindications").data("kendoGrid").dataSource.read();
    $("#ui_dtg_gridindications").data("kendoGrid").refresh();
}

function showIndications(e) {
    var grid = $("#ui_dtg_gridindications").getKendoGrid();
    var wnd = $("#Indications").data("kendoWindow");
    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(indicationstemplate(dataItem));
    wnd.center().open();

    LoadIndicationsattributes();

    CheckcharacterLength();

    $('#indication,#indicationtype').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    //#region Get existing Indications
    $('#ui_num_indicationid').val(dataItem.IndicationId);
    $("#ui_ddl_indication").data('kendoDropDownList').value(dataItem.IndicationCauses);
    $("#ui_ddl_indicationtype").data('kendoDropDownList').value(dataItem.IndicationType);
    //#endregion

    $("#ui_btnSaveindications").click(function (e) {
        SaveIndications("Edit");
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

//#region Validate Indications Fields
function ValidateIndicationsFields() {
    $(".error").remove();
    retval = true;
    objIndications = new Object();
    objIndications.StudyId = $('#StudyId').val();
    objIndications.IndicationId = $('#ui_num_indicationid').val();

    if ($('#displayIndicationtype').is(':visible'))
        if (sessionStorage.getItem("isindicationtype") == "true") {
            if ($('#ui_ddl_indicationtype').val() == "") {
                $('#indicationtype').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_indicationtype').html() + ' is required</div>');
                retval = false;
            }
            else {
                if ($('#ui_ddl_indicationtype').val() == "")
                    objIndications.Indicationtype = null;
                else
                    objIndications.Indicationtype = $('#ui_ddl_indicationtype').val();
            }
        }
        else {
            if ($('#ui_ddl_indicationtype').val() == "")
                objIndications.Indicationtype = null;
            else
                objIndications.Indicationtype = $('#ui_ddl_indicationtype').val();
        }

    if ($('#displayIndication').is(':visible'))
        if (sessionStorage.getItem("isindication") == "true") {
            if ($('#ui_ddl_indication').val() == "") {
                $('#indication').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_Indication').html() + ' is required</div>');
                retval = false;
            }
            else {
                if ($('#ui_ddl_indication').val() == "")
                    objIndications.Indicationcauses = null;
                else
                    objIndications.Indicationcauses = $('#ui_ddl_indication').val();
            }
        }
        else {
            if ($('#ui_ddl_indication').val() == "")
                objIndications.Indicationcauses = null;
            else
                objIndications.Indicationcauses = $('#ui_ddl_indication').val();
        }
}
    //#endregion

//#region Save Indications
function SaveIndications(mode) {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");
    ValidateIndicationsFields();
    if ($('#ui_ddl_indicationtype').val() == "" && $('#ui_ddl_indication').val() == "") {
        popupNotification.show("Empty record detected,please enter some values.", "info");
        return false;
    }
    else {
        if (validator.validate() && retval === true) {
            Savedetails(type = 4, objEditstudy = objIndications, mode = mode);
            $("#Indications").data("kendoWindow").close();
            return true;
        }
        else
            popupNotification.show("There are errors on the page.Please correct them to continue.", "error");
        return false;
    }
}
    //#endregion

function LoadIndicationsattributes() {
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
                        case indication:
                            DropDowndetails(response, "displayIndication", "ui_lbl_indication", "ui_img_helpTextforIndication", "isindication");
                            break;
                        case indicationtype:
                            DropDowndetails(response, "displayIndicationtype", "ui_lbl_indicationtype", "ui_img_helpTextforindicationtype", "isindicationtype");
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

$(function () {
    $("#ui_btnSaveIndications").click(function (e) {
        ValidateIndicationFields();
        if (validator.validate() && retval === true && retisvalidRegex === true)
            Savedetails(type = 4, objEditstudy = objIndication);
        else
            popupNotification.show("There are errors on the page.Please correct them to continue.", "error");
        return false;
    });
})

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
                        case indication:
                            $("#ui_dtg_gridindications th[data-field=IndicationCauses]").html(response[i].Name);
                            break;
                        case indicationtype:
                            $("#ui_dtg_gridindications th[data-field=IndicationType]").html(response[i].Name);
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
});