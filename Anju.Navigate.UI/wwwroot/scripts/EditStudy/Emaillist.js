//#region Template declarations
var emailtemplate = kendo.template($("#emailtemplate").html());
//#endregion

function OnDataBoundforEmailList() {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(emaillistattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                var grid = $("#ui_dtg_gridEmailList").data("kendoGrid");
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

function deleteEmailList(e) {
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
    var grid = $("#ui_dtg_gridEmailList").data("kendoGrid"); //Get the grid from which the pop-up is coming
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

//#region Email Lists
function addEmaillist() {
    var wnd = $("#EmailLists").data("kendoWindow");
    wnd.content(emailtemplate(kendo.template($("#emailtemplate").html())));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadEmailListsAttributes("Create");

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

    isvalidRegexforrecipient = true;

    //#region Validate RegEx values for Email list(Add mode)
    $("#ui_txtarea_recipient").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_recipient").val().trim();
        if (str != "")
            if ($("#regexexprforrecipient").val() != "") {
                var expr = new RegExp($("#regexexprforrecipient").val());
                var str = $("#ui_txtarea_recipient").val();
                if (str != "" && !expr.test(str)) {
                    $('#recipient').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforrecipient").val() + '</div>');
                    isvalidRegexforrecipient = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforrecipient = true;
                    return true;
                }
            }
    });
    $("#ui_txt_recipient").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_recipient").val().trim();
        if (str != "")
            if ($("#regexexprforrecipient").val() != "") {
                var expr = new RegExp($("#regexexprforrecipient").val());
                var str = $("#ui_txt_recipient").val();
                if (str != "" && !expr.test(str)) {
                    $('#recipient').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforrecipient").val() + '</div>');
                    isvalidRegexforrecipient = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforrecipient = true;
                    return true;
                }
            }
    });

    //#endregion Validate RegEx

    $("#ui_btnSaveemaillists").click(function (e) {
        SaveEmaillists("Create");
    });

    $("#recipient").on("keydown", function (e) {
        $(this).nextAll("div.error").remove();
    });

    $("#ui_dtg_gridEmailList").data("kendoGrid").dataSource.read();
    $("#ui_dtg_gridEmailList").data("kendoGrid").refresh();
}

function showEmailList(e) {
    var grid = $("#ui_dtg_gridEmailList").getKendoGrid();
    var wnd = $("#EmailLists").data("kendoWindow");
    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(emailtemplate(dataItem));
    wnd.center().open();

    LoadEmailListsAttributes("Edit");

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

    isvalidRegexforrecipient = true;

    //#region Validate RegEx values for Email list(Add mode)
    $("#ui_txtarea_recipient").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_recipient").val().trim();
        if (str != "")
            if ($("#regexexprforrecipient").val() != "") {
                var expr = new RegExp($("#regexexprforrecipient").val());
                var str = $("#ui_txtarea_recipient").val();
                if (str != "" && !expr.test(str)) {
                    $('#recipient').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforrecipient").val() + '</div>');
                    isvalidRegexforrecipient = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforrecipient = true;
                    return true;
                }
            }
    });
    $("#ui_txt_recipient").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_recipient").val().trim();
        if (str != "")
            if ($("#regexexprforrecipient").val() != "") {
                var expr = new RegExp($("#regexexprforrecipient").val());
                var str = $("#ui_txt_recipient").val();
                if (str != "" && !expr.test(str)) {
                    $('#recipient').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforrecipient").val() + '</div>');
                    isvalidRegexforrecipient = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforrecipient = true;
                    return true;
                }
            }
    });

    //#endregion Validate RegEx

    $("#ui_btnSaveemaillists").click(function (e) {
        SaveEmaillists("Edit");
    });

    $('#ui_num_emaillistid').val(dataItem.Id);
    $("#ui_txt_recipient,#ui_txtarea_recipient").val(dataItem.Email);

    $("#recipient").on("keydown", function (e) {
        $(this).nextAll("div.error").remove();
    });

    $("#ui_dtg_gridEmailList").data("kendoGrid").dataSource.read();
    $("#ui_dtg_gridEmailList").data("kendoGrid").refresh();
}

//#region Validate Email List Fields
function ValidateEmailListFields() {
    $(".error").remove();
    retval = true;
    objEmailLists = new Object();
    objEmailLists.StudyId = $('#StudyId').val();
    objEmailLists.Id = $('#ui_num_emaillistid').val();

    if ($('#displayRecipient').is(':visible'))
        if (sessionStorage.getItem("isrecipient") == "true") {
            if ($('#ui_txt_recipient').is(':visible')) {
                if ($('#ui_txt_recipient').val() == "") {
                    $('#recipient').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_recipient').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_recipient').is(':visible')) {
                if ($('#ui_txtarea_recipient').val() == "") {
                    $('#recipient').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_recipient').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_recipient').is(':visible'))
                objEmailLists.Email = $('#ui_txtarea_recipient').val().trim();
            if ($('#ui_txt_recipient').is(':visible'))
                objEmailLists.Email = $('#ui_txt_recipient').val().trim();
        }
        else {
            if ($('#ui_txtarea_recipient').is(':visible'))
                objEmailLists.Email = $('#ui_txtarea_recipient').val().trim();
            if ($('#ui_txt_recipient').is(':visible'))
                objEmailLists.Email = $('#ui_txt_recipient').val().trim();
        }
}
//#endregion

function LoadEmailListsAttributes(mode) {
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(emaillistattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case recipient:
                            Textdetails(response, "displayRecipient", "ui_lbl_recipient", "ui_img_helpTextforrecipient", "isrecipient", "ui_txt_recipient", "ui_txtarea_recipient", "ui_lbl_charsleftforrecipient", "regexexprforrecipient", "validationmsgforrecipient", mode);
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

$("#emailList").on("click", function () {
    $('#emaillistdetails').removeClass('emaillistdetails');
});

//#region Email lists
function SaveEmaillists(mode) {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");
    ValidateEmailListFields();
    if ($('#ui_txtarea_recipient').val() == "" && $('#ui_txt_recipient').val() == "") {
        popupNotification.show("Empty record detected,please enter some values.", "info");
        return false;
    }
    else {
        if (validator.validate() && retval === true && isvalidRegexforrecipient === true) {
            Savedetails(type = 22, objEditstudy = objEmailLists, mode = mode);
            $("#EmailLists").data("kendoWindow").close();
            return true;
        }
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    }
}
//#endregion

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

$(document).ready(function () {
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(emaillistattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case emaillist:
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
                                        $("#ui_btn_AddEmailList").attr("disabled", true);
                                }
                                if (iscreaterestricted == true)
                                    $("#ui_btn_AddEmailList").attr("disabled", true);
                            }
                            if (iscreaterestricted == true)
                                $("#ui_btn_AddEmailList").attr("disabled", true);
                            else
                                $("#ui_btn_AddEmailList").removeAttr("disabled");
                            break;
                        case recipient:
                            $("#ui_dtg_gridEmailList th[data-field=Email]").html(response[i].Name);
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

//#endregion