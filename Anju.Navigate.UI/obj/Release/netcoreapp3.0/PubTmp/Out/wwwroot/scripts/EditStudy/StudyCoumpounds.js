//#region Template declarations
var studycompoundstemplate = kendo.template($("#studycompoundstemplate").html());
//#endregion

function deleteStudycompounds(e) {
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
    var grid = $("#ui_dtg_gridstudycompounds").data("kendoGrid"); //Get the grid from which the pop-up is coming
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

function addStudyComponents() {
    var wnd = $("#StudyCompounds").data("kendoWindow");
    wnd.content(studycompoundstemplate(kendo.template($("#studycompoundstemplate").html())));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadStudyComponentsattributes();

    $("#ui_btnSavestudycompounds").click(function (e) {
        SaveStudyComponents("Create");
    });

    $('#compoundtype,#primary,#drugorCompoundcategory,#noncompanycompound').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    $("#ui_dtg_gridstudycompounds").data("kendoGrid").dataSource.read();
    $("#ui_dtg_gridstudycompounds").data("kendoGrid").refresh();
}

function showStudycompounds(e) {
    var grid = $("#ui_dtg_gridstudycompounds").getKendoGrid();
    var wnd = $("#StudyCompounds").data("kendoWindow");
    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(studycompoundstemplate(dataItem));
    wnd.center().open();

    LoadStudyComponentsattributes();

    $('#compoundtype,#primary,#drugorCompoundcategory,#noncompanycompound').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    //#region Get existing Study Components
    $("#ui_num_studycomponentid").val(dataItem.StudyComponentId);
    $("#ui_ddl_compoundtype").data('kendoDropDownList').value(dataItem.CompoundType);
    $("#ui_ddl_companycompound").data('kendoDropDownList').value(dataItem.CompanyCompound);
    $("#ui_ddl_compoundcategory").data('kendoDropDownList').value(dataItem.CompoundCategory);
    $("#ui_ddl_noncompanycompound").data('kendoDropDownList').value(dataItem.NonCompanyCompound);
    //#endregion

    $("#ui_btnSavestudycompounds").click(function (e) {
        SaveStudyComponents("Edit");
    });
}

//#region Validate Save Study ComponentsFields
function ValidateSaveStudyComponentsFields() {
    $(".error").remove();
    retval = true;
    objStudyComponents = new Object();
    objStudyComponents.StudyId = $('#StudyId').val();
    objStudyComponents.StudyComponentId = $('#ui_num_studycomponentid').val();

    if ($('#displayCompoundtype').is(':visible'))
        if (sessionStorage.getItem("iscompoundtype") == "true") {
            if ($('#ui_ddl_compoundtype').val() == "") {
                $('#compoundtype').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_compoundtype').html() + ' is required</div>');
                retval = false;
            }
            else
                objStudyComponents.CompoundType = $('#ui_ddl_compoundtype').val();
        }
        else
            objStudyComponents.CompoundType = $('#ui_ddl_compoundtype').val();

    if ($('#displayPrimary').is(':visible'))
        if (sessionStorage.getItem("iscompanycompound") == "true") {
            if ($('#ui_ddl_companycompound').val() == "") {
                $('#primary').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_companycompound').html() + ' is required</div>');
                retval = false;
            }
            else
                objStudyComponents.CompanyCompound = $('#ui_ddl_companycompound').val();
        }
        else
            objStudyComponents.CompanyCompound = $('#ui_ddl_companycompound').val();

    if ($('#displayNoncompanycompound').is(':visible'))
        if (sessionStorage.getItem("isnoncompanycompound") == "true") {
            if ($('#ui_ddl_noncompanycompound').val() == "") {
                $('#noncompanycompound').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_noncompanycompound').html() + ' is required</div>');
                retval = false;
            }
            else
                objStudyComponents.NonCompanyCompound = $('#ui_ddl_noncompanycompound').val();
        }
        else
            objStudyComponents.NonCompanyCompound = $('#ui_ddl_noncompanycompound').val();

    if ($('#displayDrugorCompoundcategory').is(':visible'))
        if (sessionStorage.getItem("iscompoundcategory") == "true") {
            if ($('#ui_ddl_compoundcategory').val() == "") {
                $('#drugorCompoundcategory').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_compoundcategory').html() + ' is required</div>');
                retval = false;
            }
            else
                objStudyComponents.CompoundCategory = $('#ui_ddl_compoundcategory').val();
        }
        else
            objStudyComponents.CompoundCategory = $('#ui_ddl_compoundcategory').val();


}
//#endregion

//#region Save Study Components
function SaveStudyComponents(mode) {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");
    ValidateSaveStudyComponentsFields();
    if ($('#ui_ddl_compoundtype').val() == "" && $('#ui_ddl_companycompound').val() == ""
        && $('#ui_ddl_noncompanycompound').val() == "" && $('#ui_ddl_compoundcategory').val() == "") {
        popupNotification.show("Empty record detected,please enter some values.", "info");
        return false;
    }
    else {
        if (validator.validate() && retval === true) {
            Savedetails(type = 16, objEditstudy = objStudyComponents, mode = mode);
            $("#StudyCompounds").data("kendoWindow").close();
            return true;
        }
        else
            popupNotification.show("There are errors on the page.Please correct them to continue.", "error");
        return false;
    }
}
    //#endregion

function LoadStudyComponentsattributes() {
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
                        case primary:
                            DropDowndetails(response, "displayPrimary", "ui_lbl_companycompound", "ui_img_helpTextforcompoundprimary", "iscompanycompound");
                            break;
                        case compoundtype:
                            DropDowndetails(response, "displayCompoundtype", "ui_lbl_compoundtype", "ui_img_helpTextforcompoundprimary", "iscompoundtype");
                            break;
                        case noncompanycompound:
                            DropDowndetails(response, "displayNoncompanycompound", "ui_lbl_noncompanycompound", "ui_img_helpTextfornoncompanycompound", "isnoncompanycompound");
                            break;
                        case drugorcompoundsecondarytype:
                            DropDowndetails(response, "displayDrugorCompoundcategory", "ui_lbl_compoundcategory", "ui_img_helpTextforcompoundcategory", "iscompoundcategory");
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
                        case primary:
                            $("#ui_dtg_gridstudycompounds th[data-field=CompanyCompound]").html(response[i].Name);
                            break;
                        case compoundtype:
                            $("#ui_dtg_gridstudycompounds th[data-field=CompoundType]").html(response[i].Name);
                            break;
                        case noncompanycompound:
                            $("#ui_dtg_gridstudycompounds th[data-field=NonCompanyCompound]").html(response[i].Name);
                            break;
                        case drugorcompoundsecondarytype:
                            $("#ui_dtg_gridstudycompounds th[data-field=CompoundCategory]").html(response[i].Name);
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