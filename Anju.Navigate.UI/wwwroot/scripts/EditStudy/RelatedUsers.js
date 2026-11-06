//#region Template declarations
var relateduserstemplate = kendo.template($("#relateduserstemplate").html());
//#endregion

function OnDataBoundforRelatedUsers() {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(relatedusersattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                var grid = $("#ui_dtg_Users").data("kendoGrid");
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
                    grid.hideColumn(9);                   
                else
                    grid.showColumn(9);
                    
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
                        grid.hideColumn(8);
                    return false;
                }
                else {
                    grid.showColumn(8);
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
function deleteRelatedUsers(e) {
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
    var grid = $("#ui_dtg_Users").data("kendoGrid"); //Get the grid from which the pop-up is coming
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

function addRelatedUsersdetails() {
    var wnd = $("#RelatedUsers").data("kendoWindow");
    wnd.content(relateduserstemplate(kendo.template($("#relateduserstemplate").html())));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadRelatedUsersAttributes("Create");

    $('#firstandlastname,#role,#begindate').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();


    //#region RelatedUsers(Add mode)
    $("#ui_btnSaverelatedusers").click(function (e) {
        SaveRelatedUsers("Create");
    });
    //#endregion

}

function showRelatedUsers(e) {
    var grid = $("#ui_dtg_Users").getKendoGrid();
    var wnd = $("#RelatedUsers").data("kendoWindow");
    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(relateduserstemplate(dataItem));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadRelatedUsersAttributes("Edit");

    $('#firstandlastname,#role,#begindate').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    //#region Get existing Users
    $("#ui_num_relatedusers").val(dataItem.IISAdmindetailsid);
    //var fullname = dataItem.FirstName + ' ' + dataItem.LastName;
    $("#ui_ddl_firstandlastname").data('kendoDropDownList').value(dataItem.UserId);
    $("#ui_ddl_role").data('kendoDropDownList').value(dataItem.UserType);
    $("#ui_dt_begindate").data("kendoDatePicker").value(dataItem.ANJU_AddDate);
    //#endregion  

    //#region RelatedUsers(Edit mode)
    $("#ui_btnSaverelatedusers").click(function (e) {
        SaveRelatedUsers("Create");
    });
    //#endregion
    //#endregion

}


//#region Related Users fields
function ValidateRelatedUsersFields() {
    $(".error").remove();
    retval = true;
    objRelatedUsers = new Object();
    objRelatedUsers.StudyId = $('#StudyId').val();
    //objRelatedUsers.UserId = $('#ui_num_relatedusers').val();

    if ($('#displayFirstandLastname').is(':visible'))
        //if (sessionStorage.getItem("isfirstandlastname") == "true") {
            if ($('#ui_ddl_firstandlastname').val() == "") {
                $('#firstandlastname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_firstandlastname').html() + ' is required</div>');
                retval = false;
            }
            else {
                if ($('#ui_ddl_firstandlastname').val() == "")
                    objRelatedUsers.UserId = null;
                else
                    objRelatedUsers.UserId = $('#ui_ddl_firstandlastname').val();
            }
        //}
        else {
            if ($('#ui_ddl_firstandlastname').val() == "")
                objRelatedUsers.UserId = null;
            else
                objRelatedUsers.UserId = $('#ui_ddl_firstandlastname').val();
        }

    if ($('#displayRole').is(':visible'))
        //if (sessionStorage.getItem("isrole") == "true") {
            if ($('#ui_ddl_role').val() == "") {
                $('#role').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_role').html() + ' is required</div>');
                retval = false;
            }
            else {
                if ($('#ui_ddl_role').val() == "")
                    objRelatedUsers.Name = null;
                else
                    objRelatedUsers.Name = $('#ui_ddl_role').val();
            }
        //}
        else {
            if ($('#ui_ddl_role').val() == "")
                objRelatedUsers.Name = null;
            else
                objRelatedUsers.Name = $('#ui_ddl_role').val();
        }

    if ($('#displayBegindate').is(':visible'))
        //if (sessionStorage.getItem("isbegindate") == "true") {
            if ($('#ui_dt_begindate').val() == "month day, year") {
                $('#begindate').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_begindate').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_dt_begindate').val() == "month day, year")
                    objRelatedUsers.ANJU_AddDate = null;
                else
                    objRelatedUsers.ANJU_AddDate = $('#ui_dt_begindate').val();
            }
        //}
        else {
            if ($('#ui_dt_begindate').val() == "month day, year")
                objRelatedUsers.ANJU_AddDate = null;
            else
                objRelatedUsers.ANJU_AddDate = $('#ui_dt_begindate').val();
        }
}
//#endregion

function SaveRelatedUsers(mode) {    
    var validator = $("#ui_dtg_Users").kendoValidator().data("kendoValidator");
    ValidateRelatedUsersFields();
    if (validator.validate() && retval === true)
        Savedetails(type = 31, objEditstudy = objRelatedUsers);
    else
        popupNotification.show(errorsinthepage, "error");
    return false;
}

function LoadRelatedUsersAttributes(mode) {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(relatedusersattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case fullname:
                            DropDowndetails(response, "displayFirstandLastname", "ui_lbl_firstandlastname", "ui_img_helpTextforfirstandlastname", "isfirstandlastname", mode);
                            break;
                        case relatedusersrole:
                            DropDowndetails(response, "displayRole", "ui_lbl_role", "ui_img_helpTextforrole", "isrole", mode);
                            break;
                        case relatedusersbegindate:
                            DropDowndetails(response, "displayBegindate", "ui_lbl_begindate", "ui_img_helpTextforbegindate", "isbegindate", mode);
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

$(document).ready(function () {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(relatedusersattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case relatedusers:
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
                                        $("#ui_btn_AddRelatedUsers").attr("disabled", true);
                                }
                                if (iscreaterestricted == true)
                                    $("#ui_btn_AddRelatedUsers").attr("disabled", true);
                            }
                            if (iscreaterestricted == true)
                                $("#ui_btn_AddRelatedUsers").attr("disabled", true);
                            else
                                $("#ui_btn_AddRelatedUsers").removeAttr("disabled");
                            break;
                        case fullname:
                            $("#ui_dtg_Users th[data-field=Cohortlevel]").html(response[i].Name);
                            break;
                        case relatedusersrole:
                            $("#ui_dtg_Users th[data-field=Cohortlevel]").html(response[i].Name);
                            break;
                        case relatedusersbegindate:
                            $("#ui_dtg_Users th[data-field=Cohortlevel]").html(response[i].Name);
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