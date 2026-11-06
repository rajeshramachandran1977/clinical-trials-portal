//#region Template declarations
var indicationstemplate = kendo.template($("#indicationstemplate").html());
//#endregion

function OnDataBoundforStudyIndication() {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(indicationsattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                var grid = $("#ui_dtg_gridindications").data("kendoGrid");
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

    LoadIndicationsattributes("Create");

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

    LoadIndicationsattributes("Edit");

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
            popupNotification.show(errorsinthepage, "error");
        return false;
    }
}
//#endregion

function LoadIndicationsattributes(mode) {
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(indicationsattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case indication:
                            DropDowndetails(response, "displayIndication", "ui_lbl_indication", "ui_img_helpTextforIndication", "isindication", mode);
                            break;
                        case indicationtype:
                            DropDowndetails(response, "displayIndicationtype", "ui_lbl_indicationtype", "ui_img_helpTextforindicationtype", "isindicationtype", mode);
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

$(function () {
    $("#ui_btnSaveIndications").click(function (e) {
        ValidateIndicationFields();
        if (validator.validate() && retval === true && retisvalidRegex === true)
            Savedetails(type = 4, objEditstudy = objIndication);
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    });
})

$(document).ready(function () {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(indicationsattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case indicationtab:
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
                                        $("#ui_btn_AddIndications").attr("disabled", true);
                                }
                                if (iscreaterestricted == true)
                                    $("#ui_btn_AddIndications").attr("disabled", true);
                            }
                            if (iscreaterestricted == true)
                                $("#ui_btn_AddIndications").attr("disabled", true);
                            else
                                $("#ui_btn_AddIndications").removeAttr("disabled");
                            break;
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
            popupNotification.show(errorsinthepage, "error");
        }
    });
});