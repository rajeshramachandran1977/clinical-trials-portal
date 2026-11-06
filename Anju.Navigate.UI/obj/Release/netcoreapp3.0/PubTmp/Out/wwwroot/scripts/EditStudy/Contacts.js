//#region Template declarations
var contactstemplate = kendo.template($("#contactstemplate").html());
//#endregion

//#region delete row functions in grids
function deleteContacts(e) {
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
    var grid = $("#ui_dtg_Contacts").data("kendoGrid"); //Get the grid from which the pop-up is coming
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

function addContacts() {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");
    var wnd = $("#Contacts").data("kendoWindow");
    wnd.content(contactstemplate(kendo.template($("#contactstemplate").html())));
    wnd.center().open();
    $(".k-window").addClass("customWidth");
    var url = url;
    $('#ui_multiselectcredentials').kendoMultiSelect({
        dataTextField: "Code",
        dataValueField: "CodeId",
        optionLabel: 'Select',
        autoClose: false,
        dataSource: {
            transport: {
                read: {
                    dataType: "json",
                    url: url
                }
            }
        }
    });

    LoadContactsAttributes();

    CheckcharacterLength();

    isvalidRegexforcontacttypedetails = isvalidRegexfortaxid = isvalidRegexforfirstname =
        isvalidRegexforlastname = isvalidRegexfortitle = isvalidRegexforaddressline1 =
        isvalidRegexforaddressline2 = isvalidRegexforaddressline3 = isvalidRegexforcity = isvalidRegexforstate =
        isvalidRegexforpostalcode = isvalidRegexforphone = isvalidRegexforfax = isvalidRegexforemail = isvalidRegexfornpi = true

    $('#contactType,#salutation,#suffix,#credentials,#institution,#state,#city,#country,#region').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    $("#siteIndex,#contactTypeDetails,#taxID,#firstname,#lastname,#title,#addressline1,#addressline2,#addressline3,#postalCode,#phone,#fax,#email,#npi").on("keyup", function (e) {
        $(this).nextAll("div.error").remove();
    })

    //#region Validate RegEx values for Contacts fields(Add mode)
    $("#ui_txtarea_contacttypedetails").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_contacttypedetails").val().trim();
        if (str != "")
            if ($("#regexexprforcontacttypedetails").val() != "") {
                var expr = new RegExp($("#regexexprforcontacttypedetails").val());
                var str = $("#ui_txtarea_contacttypedetails").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_contacttypedetails').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcontacttypedetails").val() + '</span>');
                    isvalidRegexforcontacttypedetails = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontacttypedetails = true;
                    return true;
                }
            }
    });
    $("#ui_txt_contacttypedetails").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_contacttypedetails").val().trim();
        if (str != "")
            if ($("#regexexprforcontacttypedetails").val() != "") {
                var expr = new RegExp($("#regexexprforcontacttypedetails").val());
                var str = $("#ui_txt_contacttypedetails").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_contacttypedetails').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcontacttypedetails").val() + '</span>');
                    isvalidRegexforcontacttypedetails = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontacttypedetails = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_taxid").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_taxid").val().trim();
        if (str != "")
            if ($("#regexexprfortaxid").val() != "") {
                var expr = new RegExp($("#regexexprfortaxid").val());
                var str = $("#ui_txtarea_taxid").val();
                if (str != "" && !expr.test(str)) {
                    $('#taxID').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortaxid").val() + '</div>');
                    isvalidRegexfortaxid = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortaxid = true;
                    return true;
                }
            }
    });
    $("#ui_txt_taxid").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_taxid").val().trim();
        if (str != "")
            if ($("#regexexprfortaxid").val() != "") {
                var expr = new RegExp($("#regexexprfortaxid").val());
                var str = $("#ui_txt_taxid").val();
                if (str != "" && !expr.test(str)) {
                    $('#taxID').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortaxid").val() + '</div>');
                    isvalidRegexfortaxid = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortaxid = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_firstname").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_firstname").val().trim();
        if (str != "")
            if ($("#regexexprforfirstname").val() != "") {
                var expr = new RegExp($("#regexexprforfirstname").val());
                var str = $("#ui_txtarea_firstname").val();
                if (str != "" && !expr.test(str)) {
                    $('#firstname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforfirstname").val() + '</div>');
                    isvalidRegexforfirstname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforfirstname = true;
                    return true;
                }
            }
    });
    $("#ui_txt_firstname").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_firstname").val().trim();
        if (str != "")
            if ($("#regexexprforfirstname").val() != "") {
                var expr = new RegExp($("#regexexprforfirstname").val());
                var str = $("#ui_txt_firstname").val();
                if (str != "" && !expr.test(str)) {
                    $('#firstname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforfirstname").val() + '</div>');
                    isvalidRegexforfirstname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforfirstname = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_lastname").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_lastname").val().trim();
        if (str != "")
            if ($("#regexexprforlastname").val() != "") {
                var expr = new RegExp($("#regexexprforlastname").val());
                var str = $("#ui_txtarea_lastname").val();
                if (str != "" && !expr.test(str)) {
                    $('#lastname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforlastname").val() + '</div>');
                    isvalidRegexforlastname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforlastname = true;
                    return true;
                }
            }
    });
    $("#ui_txt_lastname").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_lastname").val().trim();
        if (str != "")
            if ($("#regexexprforlastname").val() != "") {
                var expr = new RegExp($("#regexexprforlastname").val());
                var str = $("#ui_txt_lastname").val();
                if (str != "" && !expr.test(str)) {
                    $('#lastname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforlastname").val() + '</div>');
                    isvalidRegexforlastname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforlastname = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_title").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_title").val().trim();
        if (str != "")
            if ($("#regexexprfortitle").val() != "") {
                var expr = new RegExp($("#regexexprfortitle").val());
                var str = $("#ui_txtarea_title").val();
                if (str != "" && !expr.test(str)) {
                    $('#title').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortitle").val() + '</div>');
                    isvalidRegexfortitle = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortitle = true;
                    return true;
                }
            }
    });
    $("#ui_txt_title").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_title").val().trim();
        if (str != "")
            if ($("#regexexprfortitle").val() != "") {
                var expr = new RegExp($("#regexexprfortitle").val());
                var str = $("#ui_txt_title").val();
                if (str != "" && !expr.test(str)) {
                    $('#title').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortitle").val() + '</div>');
                    isvalidRegexfortitle = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortitle = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_addressline1").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_addressline1").val().trim();
        if (str != "")
            if ($("#regexexprforaddressline1").val() != "") {
                var expr = new RegExp($("#regexexprforaddressline1").val());
                var str = $("#ui_txtarea_addressline1").val();
                if (str != "" && !expr.test(str)) {
                    $('#addressline1').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforaddressline1").val() + '</div>');
                    isvalidRegexforaddressline1 = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforaddressline1 = true;
                    return true;
                }
            }
    });
    $("#ui_txt_addressline1").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_addressline1").val().trim();
        if (str != "")
            if ($("#regexexprforaddressline1").val() != "") {
                var expr = new RegExp($("#regexexprforaddressline1").val());
                var str = $("#ui_txt_addressline1").val();
                if (str != "" && !expr.test(str)) {
                    $('#addressline1').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforaddressline1").val() + '</div>');
                    isvalidRegexforaddressline1 = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforaddressline1 = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_addressline2").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_addressline2").val().trim();
        if (str != "")
            if ($("#regexexprforaddressline2").val() != "") {
                var expr = new RegExp($("#regexexprforaddressline2").val());
                var str = $("#ui_txtarea_addressline2").val();
                if (str != "" && !expr.test(str)) {
                    $('#addressline2').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforaddressline2").val() + '</div>');
                    isvalidRegexforaddressline2 = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforaddressline2 = true;
                    return true;
                }
            }
    });
    $("#ui_txt_addressline2").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_addressline2").val().trim();
        if (str != "")
            if ($("#regexexprforaddressline2").val() != "") {
                var expr = new RegExp($("#regexexprforaddressline2").val());
                var str = $("#ui_txt_addressline2").val();
                if (str != "" && !expr.test(str)) {
                    $('#addressline2').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforaddressline2").val() + '</div>');
                    isvalidRegexforaddressline2 = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforaddressline2 = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_addressline3").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_addressline3").val().trim();
        if (str != "")
            if ($("#regexexprforaddressline3").val() != "") {
                var expr = new RegExp($("#regexexprforaddressline3").val());
                var str = $("#ui_txtarea_addressline3").val();
                if (str != "" && !expr.test(str)) {
                    $('#addressline3').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforaddressline3").val() + '</div>');
                    isvalidRegexforaddressline3 = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforaddressline3 = true;
                    return true;
                }
            }
    });
    $("#ui_txt_addressline3").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_addressline3").val().trim();
        if (str != "")
            if ($("#regexexprforaddressline3").val() != "") {
                var expr = new RegExp($("#regexexprforaddressline3").val());
                var str = $("#ui_txt_addressline3").val();
                if (str != "" && !expr.test(str)) {
                    $('#addressline3').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforaddressline3").val() + '</div>');
                    isvalidRegexforaddressline3 = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforaddressline3 = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_city").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_city").val().trim();
        if (str != "")
            if ($("#regexexprforcity").val() != "") {
                var expr = new RegExp($("#regexexprforcity").val());
                var str = $("#ui_txtarea_city").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_city').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcity").val() + '</span>');
                    isvalidRegexforcity = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcity = true;
                    return true;
                }
            }
    });
    $("#ui_txt_city").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_city").val().trim();
        if (str != "")
            if ($("#regexexprforcity").val() != "") {
                var expr = new RegExp($("#regexexprforcity").val());
                var str = $("#ui_txt_city").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_city').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcity").val() + '</span>');
                    isvalidRegexforcity = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcity = true;
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
    $("#ui_txtarea_postalcode").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_postalcode").val().trim();
        if (str != "")
            if ($("#regexexprforpostalcode").val() != "") {
                var expr = new RegExp($("#regexexprforpostalcode").val());
                var str = $("#ui_txtarea_postalcode").val();
                if (str != "" && !expr.test(str)) {
                    $('#postalCode').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforpostalcode").val() + '</div>');
                    isvalidRegexforpostalcode = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforpostalcode = true;
                    return true;
                }
            }
    });
    $("#ui_txt_postalcode").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_postalcode").val().trim();
        if (str != "")
            if ($("#regexexprforpostalcode").val() != "") {
                var expr = new RegExp($("#regexexprforpostalcode").val());
                var str = $("#ui_txt_postalcode").val();
                if (str != "" && !expr.test(str)) {
                    $('#postalCode').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforpostalcode").val() + '</div>');
                    isvalidRegexforpostalcode = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforpostalcode = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_phone").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_phone").val().trim();
        if (str != "")
            if ($("#regexexprforphone").val() != "") {
                var expr = new RegExp($("#regexexprforphone").val());
                var str = $("#ui_txtarea_phone").val();
                if (str != "" && !expr.test(str)) {
                    $('#phone').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforphone").val() + '</div>');
                    isvalidRegexforphone = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforphone = true;
                    return true;
                }
            }
    });
    $("#ui_txt_phone").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_phone").val().trim();
        if (str != "")
            if ($("#regexexprforphone").val() != "") {
                var expr = new RegExp($("#regexexprforphone").val());
                var str = $("#ui_txt_phone").val();
                if (str != "" && !expr.test(str)) {
                    $('#phone').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforphone").val() + '</div>');
                    isvalidRegexforphone = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforphone = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_fax").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_fax").val().trim();
        if (str != "")
            if ($("#regexexprforfax").val() != "") {
                var expr = new RegExp($("#regexexprforfax").val());
                var str = $("#ui_txtarea_fax").val();
                if (str != "" && !expr.test(str)) {
                    $('#fax').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforfax").val() + '</div>');
                    isvalidRegexforfax = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforfax = true;
                    return true;
                }
            }
    });
    $("#ui_txt_fax").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_fax").val().trim();
        if (str != "")
            if ($("#regexexprforfax").val() != "") {
                var expr = new RegExp($("#regexexprforfax").val());
                var str = $("#ui_txt_fax").val();
                if (str != "" && !expr.test(str)) {
                    $('#fax').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforfax").val() + '</div>');
                    isvalidRegexforfax = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforfax = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_email").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_email").val().trim();
        if (str != "")
            if ($("#regexexprforemail").val() != "") {
                var expr = new RegExp($("#regexexprforemail").val());
                var str = $("#ui_txtarea_email").val();
                if (str != "" && !expr.test(str)) {
                    $('#email').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforemail").val() + '</div>');
                    isvalidRegexforemail = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforemail = true;
                    return true;
                }
            }
    });
    $("#ui_txt_email").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_email").val().trim();
        if (str != "")
            if ($("#regexexprforemail").val() != "") {
                var expr = new RegExp($("#regexexprforemail").val());
                var str = $("#ui_txt_email").val();
                if (str != "" && !expr.test(str)) {
                    $('#email').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforemail").val() + '</div>');
                    isvalidRegexforemail = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforemail = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_npi").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_npi").val().trim();
        if (str != "")
            if ($("#regexexprfornpi").val() != "") {
                var expr = new RegExp($("#regexexprfornpi").val());
                var str = $("#ui_txtarea_npi").val();
                if (str != "" && !expr.test(str)) {
                    $('#npi').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfornpi").val() + '</div>');
                    isvalidRegexfornpi = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfornpi = true;
                    return true;
                }
            }
    });
    $("#ui_txt_npi").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_npi").val().trim();
        if (str != "")
            if ($("#regexexprfornpi").val() != "") {
                var expr = new RegExp($("#regexexprfornpi").val());
                var str = $("#ui_txt_npi").val();
                if (str != "" && !expr.test(str)) {
                    $('#npi').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfornpi").val() + '</div>');
                    isvalidRegexfornpi = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfornpi = true;
                    return true;
                }
            }
    });
    //#endregion ValidateContactsFields

    //#region Save Contacts Actions(Add mode)
    $("#ui_btnSavecontacts").click(function (e) {
        SaveContacts("Create");
    });
    //#endregion

}

function showContacts(e) {
    var grid = $("#ui_dtg_Contacts").getKendoGrid();
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");
    var wnd = $("#Contacts").data("kendoWindow");
    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(contactstemplate(dataItem));
    wnd.center().open();

    var url = url;
    $('#ui_multiselectcredentials').kendoMultiSelect({
        dataTextField: "Code",
        dataValueField: "CodeId",
        optionLabel: 'Select',
        autoClose: false,
        dataSource: {
            transport: {
                read: {
                    dataType: "json",
                    url: url
                }
            }
        }
    });

    LoadContactsAttributes();

    CheckcharacterLength();

    //#region Get existing Contacts
    $("#ui_num_principalInvestigatorid").val(dataItem.PrincipalInvestigatorId);
    $("#ui_num_siteindex").val(dataItem.SiteIndex);
    $("#ui_ddl_contacttype").data('kendoDropDownList').value(dataItem.ContactType);
    $("#ui_txt_contacttypedetails,#ui_txtarea_contacttypedetails").val(dataItem.ContactTypeDetails);
    $("#ui_txt_taxid,#ui_txtarea_taxid").val(dataItem.ContactTypeDetails);
    $("#ui_txt_firstname,#ui_txtarea_firstname").val(dataItem.FirstName);
    $("#ui_txt_lastname,#ui_txtarea_lastname").val(dataItem.LastName);
    $("#ui_ddl_salutation").data('kendoDropDownList').value(dataItem.Salutation);
    $("#ui_ddl_suffix").data('kendoDropDownList').value(dataItem.Suffix);
    $("#ui_txt_title,#ui_txtarea_title").val(dataItem.Title);
    $("#ui_ddl_country").data('kendoDropDownList').value(dataItem.CountryId);
    $("#ui_ddl_state").data('kendoDropDownList').value(dataItem.StateId);
    $("#ui_ddl_city").data('kendoDropDownList').value(dataItem.CityId);
    if (dataItem.Degree !== null) {
        var degreeArray = dataItem.Degree.split(',');
        $("#ui_multiselectcredentials").getKendoMultiSelect().value(degreeArray);
    }
    $('#ui_txt_npi,#ui_txtarea_npi').val(dataItem.Npinumber);
    $("#ui_ddl_institution").data('kendoDropDownList').value(dataItem.Institution);
    $('#ui_txt_addressline1,#ui_txtarea_addressline1').val(dataItem.Address1);
    $('#ui_txt_addressline2,#ui_txtarea_addressline2').val(dataItem.Address2);
    $('#ui_txt_addressline3,#ui_txtarea_addressline3').val(dataItem.Address3);
    $('#ui_txt_postalcode,#ui_txtarea_postalcode').val(dataItem.PostalCode);
    $('#ui_txt_phone,#ui_txtarea_phone').val(dataItem.Phone);
    $('#ui_txt_fax,#ui_txtarea_fax').val(dataItem.Fax);
    $('#ui_txt_email,#ui_txtarea_email').val(dataItem.PrimaryEmailId);
    $("#ui_ddl_region").data('kendoDropDownList').value(dataItem.Region);
    //#endregion

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

    isvalidRegexforcontacttypedetails = isvalidRegexfortaxid = isvalidRegexforfirstname =
        isvalidRegexforlastname = isvalidRegexfortitle = isvalidRegexforaddressline1 =
        isvalidRegexforaddressline2 = isvalidRegexforaddressline3 = isvalidRegexforcity = isvalidRegexforstate =
        isvalidRegexforpostalcode = isvalidRegexforphone = isvalidRegexforfax = isvalidRegexforemail = isvalidRegexfornpi = true

    $('#contactType,#salutation,#suffix,#credentials,#institution,#city, \
    #country,#region').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    $("#siteIndex,#contactTypeDetails,#taxID,#firstname,#lastname,#title,#addressline1,#addressline2,#addressline3,#postalCode,#phone,#fax,#email,#npi").on("keyup", function (e) {
        $(this).nextAll("div.error").remove();
    })

    //#region Validate RegEx values for Contacts fields(Edit mode)
    $("#ui_txtarea_contacttypedetails").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_contacttypedetails").val().trim();
        if (str != "")
            if ($("#regexexprforcontacttypedetails").val() != "") {
                var expr = new RegExp($("#regexexprforcontacttypedetails").val());
                var str = $("#ui_txtarea_contacttypedetails").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_contacttypedetails').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcontacttypedetails").val() + '</span>');
                    isvalidRegexforcontacttypedetails = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontacttypedetails = true;
                    return true;
                }
            }
    });
    $("#ui_txt_contacttypedetails").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_contacttypedetails").val().trim();
        if (str != "")
            if ($("#regexexprforcontacttypedetails").val() != "") {
                var expr = new RegExp($("#regexexprforcontacttypedetails").val());
                var str = $("#ui_txt_contacttypedetails").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_contacttypedetails').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcontacttypedetails").val() + '</span>');
                    isvalidRegexforcontacttypedetails = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontacttypedetails = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_taxid").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_taxid").val().trim();
        if (str != "")
            if ($("#regexexprfortaxid").val() != "") {
                var expr = new RegExp($("#regexexprfortaxid").val());
                var str = $("#ui_txtarea_taxid").val();
                if (str != "" && !expr.test(str)) {
                    $('#taxID').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortaxid").val() + '</div>');
                    isvalidRegexfortaxid = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortaxid = true;
                    return true;
                }
            }
    });
    $("#ui_txt_taxid").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_taxid").val().trim();
        if (str != "")
            if ($("#regexexprfortaxid").val() != "") {
                var expr = new RegExp($("#regexexprfortaxid").val());
                var str = $("#ui_txt_taxid").val();
                if (str != "" && !expr.test(str)) {
                    $('#taxID').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortaxid").val() + '</div>');
                    isvalidRegexfortaxid = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortaxid = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_firstname").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_firstname").val().trim();
        if (str != "")
            if ($("#regexexprforfirstname").val() != "") {
                var expr = new RegExp($("#regexexprforfirstname").val());
                var str = $("#ui_txtarea_firstname").val();
                if (str != "" && !expr.test(str)) {
                    $('#firstname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforfirstname").val() + '</div>');
                    isvalidRegexforfirstname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforfirstname = true;
                    return true;
                }
            }
    });
    $("#ui_txt_firstname").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_firstname").val().trim();
        if (str != "")
            if ($("#regexexprforfirstname").val() != "") {
                var expr = new RegExp($("#regexexprforfirstname").val());
                var str = $("#ui_txt_firstname").val();
                if (str != "" && !expr.test(str)) {
                    $('#firstname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforfirstname").val() + '</div>');
                    isvalidRegexforfirstname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforfirstname = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_lastname").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_lastname").val().trim();
        if (str != "")
            if ($("#regexexprforlastname").val() != "") {
                var expr = new RegExp($("#regexexprforlastname").val());
                var str = $("#ui_txtarea_lastname").val();
                if (str != "" && !expr.test(str)) {
                    $('#lastname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforlastname").val() + '</div>');
                    isvalidRegexforlastname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforlastname = true;
                    return true;
                }
            }
    });
    $("#ui_txt_lastname").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_lastname").val().trim();
        if (str != "")
            if ($("#regexexprforlastname").val() != "") {
                var expr = new RegExp($("#regexexprforlastname").val());
                var str = $("#ui_txt_lastname").val();
                if (str != "" && !expr.test(str)) {
                    $('#lastname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforlastname").val() + '</div>');
                    isvalidRegexforlastname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforlastname = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_title").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_title").val().trim();
        if (str != "")
            if ($("#regexexprfortitle").val() != "") {
                var expr = new RegExp($("#regexexprfortitle").val());
                var str = $("#ui_txtarea_title").val();
                if (str != "" && !expr.test(str)) {
                    $('#title').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortitle").val() + '</div>');
                    isvalidRegexfortitle = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortitle = true;
                    return true;
                }
            }
    });
    $("#ui_txt_title").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_title").val().trim();
        if (str != "")
            if ($("#regexexprfortitle").val() != "") {
                var expr = new RegExp($("#regexexprfortitle").val());
                var str = $("#ui_txt_title").val();
                if (str != "" && !expr.test(str)) {
                    $('#title').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortitle").val() + '</div>');
                    isvalidRegexfortitle = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortitle = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_addressline1").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_addressline1").val().trim();
        if (str != "")
            if ($("#regexexprforaddressline1").val() != "") {
                var expr = new RegExp($("#regexexprforaddressline1").val());
                var str = $("#ui_txtarea_addressline1").val();
                if (str != "" && !expr.test(str)) {
                    $('#addressline1').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforaddressline1").val() + '</div>');
                    isvalidRegexforaddressline1 = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforaddressline1 = true;
                    return true;
                }
            }
    });
    $("#ui_txt_addressline1").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_addressline1").val().trim();
        if (str != "")
            if ($("#regexexprforaddressline1").val() != "") {
                var expr = new RegExp($("#regexexprforaddressline1").val());
                var str = $("#ui_txt_addressline1").val();
                if (str != "" && !expr.test(str)) {
                    $('#addressline1').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforaddressline1").val() + '</div>');
                    isvalidRegexforaddressline1 = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforaddressline1 = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_addressline2").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_addressline2").val().trim();
        if (str != "")
            if ($("#regexexprforaddressline2").val() != "") {
                var expr = new RegExp($("#regexexprforaddressline2").val());
                var str = $("#ui_txtarea_addressline2").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_addressline2').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforaddressline2").val() + '</span>');
                    isvalidRegexforaddressline2 = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforaddressline2 = true;
                    return true;
                }
            }
    });
    $("#ui_txt_addressline2").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_addressline2").val().trim();
        if (str != "")
            if ($("#regexexprforaddressline2").val() != "") {
                var expr = new RegExp($("#regexexprforaddressline2").val());
                var str = $("#ui_txt_addressline2").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_addressline2').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforaddressline2").val() + '</span>');
                    isvalidRegexforaddressline2 = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforaddressline2 = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_addressline3").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_addressline3").val().trim();
        if (str != "")
            if ($("#regexexprforaddressline3").val() != "") {
                var expr = new RegExp($("#regexexprforaddressline3").val());
                var str = $("#ui_txtarea_addressline3").val();
                if (str != "" && !expr.test(str)) {
                    $('#addressline3').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforaddressline3").val() + '</div>');
                    isvalidRegexforaddressline3 = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforaddressline3 = true;
                    return true;
                }
            }
    });
    $("#ui_txt_addressline3").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_addressline3").val().trim();
        if (str != "")
            if ($("#regexexprforaddressline3").val() != "") {
                var expr = new RegExp($("#regexexprforaddressline3").val());
                var str = $("#ui_txt_addressline3").val();
                if (str != "" && !expr.test(str)) {
                    $('#addressline3').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforaddressline3").val() + '</div>');
                    isvalidRegexforaddressline3 = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforaddressline3 = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_city").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_city").val().trim();
        if (str != "")
            if ($("#regexexprforcity").val() != "") {
                var expr = new RegExp($("#regexexprforcity").val());
                var str = $("#ui_txtarea_city").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_city').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcity").val() + '</span>');
                    isvalidRegexforcity = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcity = true;
                    return true;
                }
            }
    });
    $("#ui_txt_city").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_city").val().trim();
        if (str != "")
            if ($("#regexexprforcity").val() != "") {
                var expr = new RegExp($("#regexexprforcity").val());
                var str = $("#ui_txt_city").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_city').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcity").val() + '</span>');
                    isvalidRegexforcity = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcity = true;
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
    $("#ui_txtarea_postalcode").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_postalcode").val().trim();
        if (str != "")
            if ($("#regexexprforpostalcode").val() != "") {
                var expr = new RegExp($("#regexexprforpostalcode").val());
                var str = $("#ui_txtarea_postalcode").val();
                if (str != "" && !expr.test(str)) {
                    $('#postalCode').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforpostalcode").val() + '</div>');
                    isvalidRegexforpostalcode = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforpostalcode = true;
                    return true;
                }
            }
    });
    $("#ui_txt_postalcode").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_postalcode").val().trim();
        if (str != "")
            if ($("#regexexprforpostalcode").val() != "") {
                var expr = new RegExp($("#regexexprforpostalcode").val());
                var str = $("#ui_txt_postalcode").val();
                if (str != "" && !expr.test(str)) {
                    $('#postalCode').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforpostalcode").val() + '</div>');
                    isvalidRegexforpostalcode = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforpostalcode = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_phone").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_phone").val().trim();
        if (str != "")
            if ($("#regexexprforphone").val() != "") {
                var expr = new RegExp($("#regexexprforphone").val());
                var str = $("#ui_txtarea_phone").val();
                if (str != "" && !expr.test(str)) {
                    $('#phone').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforphone").val() + '</div>');
                    isvalidRegexforphone = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforphone = true;
                    return true;
                }
            }
    });
    $("#ui_txt_phone").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_phone").val().trim();
        if (str != "")
            if ($("#regexexprforphone").val() != "") {
                var expr = new RegExp($("#regexexprforphone").val());
                var str = $("#ui_txt_phone").val();
                if (str != "" && !expr.test(str)) {
                    $('#phone').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforphone").val() + '</div>');
                    isvalidRegexforphone = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforphone = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_fax").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_fax").val().trim();
        if (str != "")
            if ($("#regexexprforfax").val() != "") {
                var expr = new RegExp($("#regexexprforfax").val());
                var str = $("#ui_txtarea_fax").val();
                if (str != "" && !expr.test(str)) {
                    $('#fax').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforfax").val() + '</div>');
                    isvalidRegexforfax = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforfax = true;
                    return true;
                }
            }
    });
    $("#ui_txt_fax").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_fax").val().trim();
        if (str != "")
            if ($("#regexexprforfax").val() != "") {
                var expr = new RegExp($("#regexexprforfax").val());
                var str = $("#ui_txt_fax").val();
                if (str != "" && !expr.test(str)) {
                    $('#fax').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforfax").val() + '</div>');
                    isvalidRegexforfax = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforfax = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_email").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_email").val().trim();
        if (str != "")
            if ($("#regexexprforemail").val() != "") {
                var expr = new RegExp($("#regexexprforemail").val());
                var str = $("#ui_txtarea_email").val();
                if (str != "" && !expr.test(str)) {
                    $('#email').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforemail").val() + '</div>');
                    isvalidRegexforemail = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforemail = true;
                    return true;
                }
            }
    });
    $("#ui_txt_email").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_email").val().trim();
        if (str != "")
            if ($("#regexexprforemail").val() != "") {
                var expr = new RegExp($("#regexexprforemail").val());
                var str = $("#ui_txt_email").val();
                if (str != "" && !expr.test(str)) {
                    $('#email').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforemail").val() + '</div>');
                    isvalidRegexforemail = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforemail = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_npi").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_npi").val().trim();
        if (str != "")
            if ($("#regexexprfornpi").val() != "") {
                var expr = new RegExp($("#regexexprfornpi").val());
                var str = $("#ui_txtarea_npi").val();
                if (str != "" && !expr.test(str)) {
                    $('#npi').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfornpi").val() + '</div>');
                    isvalidRegexfornpi = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfornpi = true;
                    return true;
                }
            }
    });
    $("#ui_txt_npi").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_npi").val().trim();
        if (str != "")
            if ($("#regexexprfornpi").val() != "") {
                var expr = new RegExp($("#regexexprfornpi").val());
                var str = $("#ui_txt_npi").val();
                if (str != "" && !expr.test(str)) {
                    $('#npi').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfornpi").val() + '</div>');
                    isvalidRegexfornpi = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfornpi = true;
                    return true;
                }
            }
    });
    //#endregion ValidateContactsFields

    //#region Save Contacts Actions(Add mode)
    $("#ui_btnSavecontacts").click(function (e) {
        SaveContacts("Edit");
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

//#region Validate Contacts fields
function ValidateContactsFields() {
    $(".error").remove();
    retval = true;
    objContacts = new Object();
    objContacts.StudyId = $('#StudyId').val();
    objContacts.PrincipalInvestigatorId = $('#ui_num_principalInvestigatorid').val();

    if ($('#displaySiteIndex').is(':visible'))
        if (sessionStorage.getItem("issiteindex") == "true") {
            if ($('#ui_num_siteindex').val() == "") {
                $('#siteIndex').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_siteindex').html() + ' is required</div>');
                retval = false;
            } else
                objContacts.SiteIndex = $('#ui_num_siteindex').val().trim();
        }
        else
            objContacts.SiteIndex = $('#ui_num_siteindex').val().trim();

    if ($('#displayContactType').is(':visible'))
        if (sessionStorage.getItem("iscontacttype") == "true") {
            if ($('#ui_ddl_contacttype').val() == "") {
                $('#contactType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_contacttype').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_contacttype').val() == "")
                    objContacts.ContactType = null;
                else
                    objContacts.ContactType = $('#ui_ddl_contacttype').val();
            }
        }
        else {
            if ($('#ui_ddl_contacttype').val() == "")
                objContacts.ContactType = null;
            else
                objContacts.ContactType = $('#ui_ddl_contacttype').val();
        }

    if ($('#displayContactTypeDetails').is(':visible'))
        if (sessionStorage.getItem("iscontacttypedetails") == "true") {
            if ($('#ui_txt_contacttypedetails').is(':visible')) {
                if ($('#ui_txt_contacttypedetails').val() == "") {
                    $('#contactTypeDetails').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_contacttypedetails').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_contacttypedetails').is(':visible')) {
                if ($('#ui_txtarea_contacttypedetails').val() == "") {
                    $('#contactTypeDetails').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_contacttypedetails').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_contacttypedetails').is(':visible'))
                objContacts.ContactTypeDetails = $('#ui_txt_contacttypedetails').val().trim();
            if ($('#ui_txtarea_contacttypedetails').is(':visible'))
                objContacts.ContactTypeDetails = $('#ui_txtarea_contacttypedetails').val().trim();
        }
        else {
            if ($('#ui_txt_contacttypedetails').is(':visible'))
                objContacts.ContactTypeDetails = $('#ui_txt_contacttypedetails').val().trim();
            if ($('#ui_txtarea_contacttypedetails').is(':visible'))
                objContacts.ContactTypeDetails = $('#ui_txtarea_contacttypedetails').val().trim();
        }

    if ($('#displayTaxID').is(':visible'))
        if (sessionStorage.getItem("istaxid") == "true") {
            if ($('#ui_txt_taxid').is(':visible')) {
                if ($('#ui_txt_taxid').val() == "") {
                    $('#taxID').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_taxid').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_taxid').is(':visible')) {
                if ($('#ui_txtarea_taxid').val() == "") {
                    $('#taxID').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_taxid').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_taxid').is(':visible'))
                objContacts.TaxID = $('#ui_txt_taxid').val().trim();
            if ($('#ui_txtarea_taxid').is(':visible'))
                objContacts.TaxID = $('#ui_txtarea_taxid').val().trim();
        }
        else {
            if ($('#ui_txt_taxid').is(':visible'))
                objContacts.TaxID = $('#ui_txt_taxid').val().trim();
            if ($('#ui_txtarea_taxid').is(':visible'))
                objContacts.TaxID = $('#ui_txtarea_taxid').val().trim();
        }

    if ($('#displaySalutation').is(':visible'))
        if (sessionStorage.getItem("issalutation") == "true") {
            if ($('#ui_ddl_salutation').val() == "") {
                $('#salutation').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_salutation').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_salutation').val() == "")
                    objContacts.Salutation = null;
                else
                    objContacts.Salutation = $('#ui_ddl_salutation').val();
            }
        }
        else {
            if ($('#ui_ddl_salutation').val() == "")
                objContacts.Salutation = null;
            else
                objContacts.Salutation = $('#ui_ddl_salutation').val();
        }

    if ($('#displayFirstname').is(':visible'))
        if (sessionStorage.getItem("isfirstname") == "true") {
            if ($('#ui_txt_firstname').is(':visible')) {
                if ($('#ui_txt_firstname').val() == "") {
                    $('#firstname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_firstname').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_firstname').is(':visible')) {
                if ($('#ui_txtarea_firstname').val() == "") {
                    $('#firstname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_firstname').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_firstname').is(':visible'))
                objContacts.FirstName = $('#ui_txt_firstname').val().trim();
            if ($('#ui_txtarea_firstname').is(':visible'))
                objContacts.FirstName = $('#ui_txtarea_firstname').val().trim();
        }
        else {
            if ($('#ui_txt_firstname').is(':visible'))
                objContacts.FirstName = $('#ui_txt_firstname').val().trim();
            if ($('#ui_txtarea_firstname').is(':visible'))
                objContacts.FirstName = $('#ui_txtarea_firstname').val().trim();
        }

    if ($('#displayLastname').is(':visible'))
        if (sessionStorage.getItem("islastname") == "true") {
            if ($('#ui_txt_lastname').is(':visible')) {
                if ($('#ui_txt_lastname').val() == "") {
                    $('#lastname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_firstname').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_lastname').is(':visible')) {
                if ($('#ui_txtarea_lastname').val() == "") {
                    $('#lastname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_firstname').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_lastname').is(':visible'))
                objContacts.LastName = $('#ui_txt_lastname').val().trim();
            if ($('#ui_txtarea_lastname').is(':visible'))
                objContacts.LastName = $('#ui_txtarea_lastname').val().trim();
        }
        else {
            if ($('#ui_txt_lastname').is(':visible'))
                objContacts.LastName = $('#ui_txt_lastname').val().trim();
            if ($('#ui_txtarea_lastname').is(':visible'))
                objContacts.LastName = $('#ui_txtarea_lastname').val().trim();
        }

    if ($('#displaySuffix').is(':visible'))
        if (sessionStorage.getItem("issuffix") == "true") {
            if ($('#ui_ddl_suffix').val() == "") {
                $('#suffix').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_suffix').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_suffix').val() == "")
                    objContacts.Suffix = null;
                else
                    objContacts.Suffix = $('#ui_ddl_suffix').val();
            }
        }
        else {
            if ($('#ui_ddl_suffix').val() == "")
                objContacts.Suffix = null;
            else
                objContacts.Suffix = $('#ui_ddl_suffix').val();
        }

    if ($('#displayTitle').is(':visible'))
        if (sessionStorage.getItem("istitle") == "true") {
            if ($('#ui_txt_title').is(':visible')) {
                if ($('#ui_txt_title').val() == "") {
                    $('#title').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_title').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_title').is(':visible')) {
                if ($('#ui_txtarea_title').val() == "") {
                    $('#title').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_title').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_title').is(':visible'))
                objContacts.Title = $('#ui_txt_title').val().trim();
            if ($('#ui_txtarea_title').is(':visible'))
                objContacts.Title = $('#ui_txtarea_title').val().trim();
        }
        else {
            if ($('#ui_txt_title').is(':visible'))
                objContacts.Title = $('#ui_txt_title').val().trim();
            if ($('#ui_txtarea_title').is(':visible'))
                objContacts.Title = $('#ui_txtarea_title').val().trim();
        }

    if ($('#displayCredentials').is(':visible'))
        if (sessionStorage.getItem("iscredentials") == "true") {
            if ($('#ui_multiselectcredentials').data("kendoMultiSelect").value().length <= 0) {
                $('#credentials').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_credentials').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_multiselectcredentials').val() == "")
                    objContacts.Degree = null;
                else
                    objContacts.Degree = $('#ui_multiselectcredentials').val();
            }
        }
        else {
            if ($('#ui_multiselectcredentials').val() == "")
                objContacts.Degree = null;
            else
                objContacts.Degree = $('#ui_multiselectcredentials').val();
        }

    if ($('#displayInstitution').is(':visible'))
        if (sessionStorage.getItem("isinstitution") == "true") {
            if ($('#ui_ddl_institution').val() == "") {
                $('#institution').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_institution').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_institution').val() == "")
                    objContacts.Institution = null;
                else
                    objContacts.Institution = $('#ui_ddl_institution').val();
            }
        }
        else {
            if ($('#ui_ddl_institution').val() == "")
                objContacts.Institution = null;
            else
                objContacts.Institution = $('#ui_ddl_institution').val();
        }


    if ($('#displayAddressLine1').is(':visible'))
        if (sessionStorage.getItem("isaddressline1") == "true") {
            if ($('#ui_txt_addressline1').is(':visible')) {
                if ($('#ui_txt_addressline1').val() == "") {
                    $('#addressline1').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_addressline1').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_addressline1').is(':visible')) {
                if ($('#ui_txtarea_addressline1').val() == "") {
                    $('#addressline1').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_addressline1').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_addressline1').is(':visible'))
                objContacts.Address1 = $('#ui_txt_addressline1').val().trim();
            if ($('#ui_txtarea_addressline1').is(':visible'))
                objContacts.Address1 = $('#ui_txtarea_addressline1').val().trim();
        }
        else {
            if ($('#ui_txt_addressline1').is(':visible'))
                objContacts.Address1 = $('#ui_txt_addressline1').val().trim();
            if ($('#ui_txtarea_addressline1').is(':visible'))
                objContacts.Address1 = $('#ui_txtarea_addressline1').val().trim();
        }

    if ($('#displayAddressLine2').is(':visible'))
        if (sessionStorage.getItem("isaddressline2") == "true") {
            if ($('#ui_txt_addressline2').is(':visible')) {
                if ($('#ui_txt_addressline2').val() == "") {
                    $('#addressline2').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_addressline2').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_addressline2').is(':visible')) {
                if ($('#ui_txtarea_addressline2').val() == "") {
                    $('#addressline2').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_addressline2').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_addressline2').is(':visible'))
                objContacts.Address2 = $('#ui_txt_addressline2').val().trim();
            if ($('#ui_txtarea_addressline2').is(':visible'))
                objContacts.Address2 = $('#ui_txtarea_addressline2').val().trim();
        }
        else {
            if ($('#ui_txt_addressline2').is(':visible'))
                objContacts.Address2 = $('#ui_txt_addressline2').val().trim();
            if ($('#ui_txtarea_addressline2').is(':visible'))
                objContacts.Address2 = $('#ui_txtarea_addressline2').val().trim();
        }

    if ($('#displayAddressLine3').is(':visible'))
        if (sessionStorage.getItem("isaddressline3") == "true") {
            if ($('#ui_txt_addressline3').is(':visible')) {
                if ($('#ui_txt_addressline3').val() == "") {
                    $('#addressline3').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_addressline3').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_addressline3').is(':visible')) {
                if ($('#ui_txtarea_addressline3').val() == "") {
                    $('#addressline3').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_addressline3').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_addressline3').is(':visible'))
                objContacts.Address3 = $('#ui_txt_addressline3').val().trim();
            if ($('#ui_txtarea_addressline3').is(':visible'))
                objContacts.Address3 = $('#ui_txtarea_addressline3').val().trim();
        }
        else {
            if ($('#ui_txt_addressline3').is(':visible'))
                objContacts.Address3 = $('#ui_txt_addressline3').val().trim();
            if ($('#ui_txtarea_addressline3').is(':visible'))
                objContacts.Address3 = $('#ui_txtarea_addressline3').val().trim();
        }

    if ($('#displayCity').is(':visible'))
        if (sessionStorage.getItem("iscity") == "true") {
            if ($('#ui_ddl_city').val() == "") {
                $('#city').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_city').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_city').val() == "")
                    objContacts.CityId = null;
                else
                    objContacts.CityId = $('#ui_ddl_city').val();
            }
        }
        else {
            if ($('#ui_ddl_city').val() == "")
                objContacts.CityId = null;
            else
                objContacts.CityId = $('#ui_ddl_city').val();
        }

    if ($('#displayState').is(':visible'))
        if (sessionStorage.getItem("isstate") == "true") {
            if ($('#ui_ddl_state').val() == "") {
                $('#state').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_state').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_state').val() == "")
                    objContacts.StateId = null;
                else
                    objContacts.StateId = $('#ui_ddl_state').val();
            }
        }
        else {
            if ($('#ui_ddl_state').val() == "")
                objContacts.StateId = null;
            else
                objContacts.StateId = $('#ui_ddl_state').val();
        }


    if ($('#displayPostalCode').is(':visible'))
        if (sessionStorage.getItem("ispostalcode") == "true") {
            if ($('#ui_txt_postalcode').is(':visible')) {
                if ($('#ui_txt_postalcode').val() == "") {
                    $('#postalCode').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_postalcode').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_postalcode').is(':visible')) {
                if ($('#ui_txtarea_postalcode').val() == "") {
                    $('#postalCode').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_postalcode').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_postalcode').is(':visible'))
                objContacts.PostalCode = $('#ui_txt_postalcode').val().trim();
            if ($('#ui_txtarea_postalcode').is(':visible'))
                objContacts.PostalCode = $('#ui_txtarea_postalcode').val().trim();
        }
        else {
            if ($('#ui_txt_postalcode').is(':visible'))
                objContacts.PostalCode = $('#ui_txt_postalcode').val().trim();
            if ($('#ui_txtarea_postalcode').is(':visible'))
                objContacts.PostalCode = $('#ui_txtarea_postalcode').val().trim();
        }


    if ($('#displayCountry').is(':visible'))
        if (sessionStorage.getItem("iscountry") == "true") {
            if ($('#ui_ddl_country').val() == "") {
                $('#country').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_country').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_country').val() == "")
                    objContacts.CountryId = null;
                else
                    objContacts.CountryId = $('#ui_ddl_country').val();
            }
        }
        else {
            if ($('#ui_ddl_country').val() == "")
                objContacts.CountryId = null;
            else
                objContacts.CountryId = $('#ui_ddl_country').val();
        }

    if ($('#displayPhone').is(':visible'))
        if (sessionStorage.getItem("isphone") == "true") {
            if ($('#ui_txt_phone').is(':visible')) {
                if ($('#ui_txt_phone').val() == "") {
                    $('#phone').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_phone').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_phone').is(':visible')) {
                if ($('#ui_txtarea_phone').val() == "") {
                    $('#phone').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_phone').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_phone').is(':visible'))
                objContacts.Phone = $('#ui_txt_phone').val().trim();
            if ($('#ui_txtarea_phone').is(':visible'))
                objContacts.Phone = $('#ui_txtarea_phone').val().trim();
        }
        else {
            if ($('#ui_txt_phone').is(':visible'))
                objContacts.Phone = $('#ui_txt_phone').val().trim();
            if ($('#ui_txtarea_phone').is(':visible'))
                objContacts.Phone = $('#ui_txtarea_phone').val().trim();
        }

    if ($('#displayFax').is(':visible'))
        if (sessionStorage.getItem("isfax") == "true") {
            if ($('#ui_txt_fax').is(':visible')) {
                if ($('#ui_txt_fax').val() == "") {
                    $('#fax').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_fax').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_fax').is(':visible')) {
                if ($('#ui_txtarea_fax').val() == "") {
                    $('#fax').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_fax').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_fax').is(':visible'))
                objContacts.Fax = $('#ui_txt_fax').val().trim();
            if ($('#ui_txtarea_fax').is(':visible'))
                objContacts.Fax = $('#ui_txtarea_fax').val().trim();
        }
        else {
            if ($('#ui_txt_fax').is(':visible'))
                objContacts.Fax = $('#ui_txt_fax').val().trim();
            if ($('#ui_txtarea_fax').is(':visible'))
                objContacts.Fax = $('#ui_txtarea_fax').val().trim();
        }

    if ($('#displayEmail').is(':visible'))
        if (sessionStorage.getItem("isemail") == "true") {
            if ($('#ui_txt_email').is(':visible')) {
                if ($('#ui_txt_email').val() == "") {
                    $('#email').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_email').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_email').is(':visible')) {
                if ($('#ui_txtarea_email').val() == "") {
                    $('#email').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_email').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_email').is(':visible'))
                objContacts.PrimaryEmailID = $('#ui_txt_email').val().trim();
            if ($('#ui_txtarea_email').is(':visible'))
                objContacts.PrimaryEmailID = $('#ui_txtarea_email').val().trim();
        }
        else {
            if ($('#ui_txt_email').is(':visible'))
                objContacts.PrimaryEmailID = $('#ui_txt_email').val().trim();
            if ($('#ui_txtarea_email').is(':visible'))
                objContacts.PrimaryEmailID = $('#ui_txtarea_email').val().trim();
        }

    if ($('#displayNPI').is(':visible'))
        if (sessionStorage.getItem("isnpi") == "true") {
            if ($('#ui_txt_npi').is(':visible')) {
                if ($('#ui_txt_npi').val() == "") {
                    $('#npi').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_npi').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_npi').is(':visible')) {
                if ($('#ui_txtarea_npi').val() == "") {
                    $('#npi').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_npi').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_npi').is(':visible'))
                objContacts.NPINumber = $('#ui_txt_npi').val().trim();
            if ($('#ui_txtarea_npi').is(':visible'))
                objContacts.NPINumber = $('#ui_txtarea_npi').val().trim();
        }
        else {
            if ($('#ui_txt_npi').is(':visible'))
                objContacts.NPINumber = $('#ui_txt_npi').val().trim();
            if ($('#ui_txtarea_npi').is(':visible'))
                objContacts.NPINumber = $('#ui_txtarea_npi').val().trim();
        }

    if ($('#displayRegion').is(':visible'))
        if (sessionStorage.getItem("isregion") == "true") {
            if ($('#ui_ddl_region').val() == "") {
                $('#region').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_region').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_region').val() == "")
                    objContacts.Region = null;
                else
                    objContacts.Region = $('#ui_ddl_region').val();
            }
        }
        else {
            if ($('#ui_ddl_region').val() == "")
                objContacts.Region = null;
            else
                objContacts.Region = $('#ui_ddl_region').val();
        }
}
//#endregion

function SaveContacts(mode) {
    var validator = $("#ui_frm_contacts").kendoValidator().data("kendoValidator");
    ValidateContactsFields();
    if ($('#ui_num_siteindex').val() == "" && $('#ui_txtarea_title').val() == "" &&
        $('#ui_multiselectcredentials').val() == null && $('#ui_ddl_institution').val() == "" && $('#ui_txt_addressline1').val() == "" &&
        $('#ui_txtarea_addressline1').val() == "" && $('#ui_txt_addressline2').val() == "" &&
        $('#ui_txtarea_addressline2').val() == "" && $('#ui_txt_addressline3').val() == "" &&
        $('#ui_txtarea_addressline3').val() == "" && $('#ui_ddl_city').val() == "" &&
        $('#ui_ddl_state').val() == "" && $('#ui_txt_postalcode').val() == "" &&
        $('#ui_txtarea_postalcode').val() == "" && $('#ui_ddl_country').val() == "" &&
        $('#ui_txt_phone').val() == "" && $('#ui_txtarea_phone').val() == "" && $('#ui_txt_fax').val() == "" &&
        $('#ui_txtarea_fax').val() == "" && $('#ui_txt_email').val() == "" && $('#ui_txtarea_email').val() == "" &&
        $('#ui_txt_npi').val() == "" && $('#ui_txtarea_npi').val() == "" && $('#ui_ddl_region').val() == "" &&
        $('#ui_ddl_contacttype').val() == "" && $('#ui_txt_contacttypedetails').val() == "" &&
        $('#ui_txtarea_contacttypedetails').val() == "" && $('#ui_txt_taxid').val() == "" && $('#ui_txtarea_taxid').val() == "" &&
        $('#ui_ddl_salutation' && $('#ui_txt_firstname').val() == "" && $('#ui_txtarea_firstname').val() == "" &&
            $('#ui_txt_lastname').val() == "" && $('#ui_txtarea_lastname').val() == "" && $('#ui_ddl_suffix').val() == "" &&
            $('#ui_txt_title').val() == "")) {
        popupNotification.show("Empty record detected,please enter some values.", "info");
        return false;
    } else {
        if (validator.validate() && retval === true &&
            (isvalidRegexforcontacttypedetails === true && isvalidRegexfortaxid === true &&
                isvalidRegexforfirstname === true && isvalidRegexforlastname === true &&
                isvalidRegexfortitle === true && isvalidRegexforaddressline1 === true &&
                isvalidRegexforaddressline2 === true && isvalidRegexforaddressline3 === true &&
                isvalidRegexforaddressline2 === true && isvalidRegexforaddressline3 === true &&
                isvalidRegexforcity === true && isvalidRegexforstate === true &&
                isvalidRegexforpostalcode === true && isvalidRegexforphone === true &&
                isvalidRegexforfax === true && isvalidRegexforemail === true &&
                isvalidRegexfornpi === true))
            Savedetails(type = 11, objEditstudy = objContacts);
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    }
}

function LoadContactsAttributes() {
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
                        case siteindex:
                            DropDowndetails(response, "displaySiteIndex", "ui_lbl_siteindex", "ui_img_helpTextforsiteindex", "issiteindex");
                            break;
                        case contacttype:
                            DropDowndetails(response, "displayContactType", "ui_lbl_contacttype", "ui_img_helpTextforcontacttype", "iscontacttype");
                            break;
                        case contacttypedetails:
                            Textdetails(response, "displayContactTypeDetails", "ui_lbl_contacttypedetails", "ui_img_helpTextforcontacttypedetails", "iscontacttypedetails", "ui_txt_contacttypedetails", "ui_txtarea_contacttypedetails", "ui_lbl_charsleftforcontacttypedetails", "regexexprforcontacttypedetails", "validationmsgforcontacttypedetails");
                            break;
                        case taxid:
                            Textdetails(response, "displayTaxID", "ui_lbl_taxid", "ui_img_helpTextfortaxid", "istaxid", "ui_txt_taxid", "ui_txtarea_taxid", "ui_lbl_charsleftfortaxid", "regexexprfortaxid", "validationmsgfortaxid");
                            break;
                        case salutation:
                            DropDowndetails(response, "displaySalutation", "ui_lbl_salutation", "ui_img_helpTextforsalutation", "issalutation");
                            break;
                        case firstname:
                            Textdetails(response, "displayFirstname", "ui_lbl_firstname", "ui_img_helpTextforfirstname", "isfirstname", "ui_txt_firstname", "ui_txtarea_firstname", "ui_lbl_charsleftforfirstname", "regexexprforfirstname", "validationmsgforfirstname");
                            break;
                        case lastname:
                            Textdetails(response, "displayLastname", "ui_lbl_lastname", "ui_img_helpTextforlastname", "islastname", "ui_txt_lastname", "ui_txtarea_lastname", "ui_lbl_charsleftforlastname", "regexexprforlastname", "validationmsgforlastname");
                            break;
                        case suffix:
                            DropDowndetails(response, "displaySuffix", "ui_lbl_suffix", "ui_img_helpTextforsuffix", "issuffix");
                            break;
                        case title:
                            Textdetails(response, "displayTitle", "ui_lbl_title", "ui_img_helpTextfortitle", "istitle", "ui_txt_title", "ui_txtarea_title", "ui_lbl_charsleftfortitle", "regexexprfortitle", "validationmsgfortitle");
                            break;
                        case credentials:
                            DropDowndetails(response, "displayCredentials", "ui_lbl_credentials", "ui_img_helpTextforcredentials", "iscredentials");
                            break;
                        case piiinstitution:
                            DropDowndetails(response, "displayInstitution", "ui_lbl_institution", "ui_img_helpTextforinstitution", "isinstitution");
                            break;
                        case address1:
                            Textdetails(response, "displayAddressLine1", "ui_lbl_addressline1", "ui_img_helpTextforaddressline1", "isaddressline1", "ui_txt_addressline1", "ui_txtarea_addressline1", "ui_lbl_charsleftforaddressline1", "regexexprforaddressline1", "validationmsgforaddressline1");
                            break;
                        case address2:
                            Textdetails(response, "displayAddressLine2", "ui_lbl_addressline2", "ui_img_helpTextforaddressline2", "isaddressline2", "ui_txt_addressline2", "ui_txtarea_addressline2", "ui_lbl_charsleftforaddressline2", "regexexprforaddressline2", "validationmsgforaddressline2");
                            break;
                        case address3:
                            Textdetails(response, "displayAddressLine3", "ui_lbl_addressline3", "ui_img_helpTextforaddressline3", "isaddressline3", "ui_txt_addressline3", "ui_txtarea_addressline3", "ui_lbl_charsleftforaddressline3", "regexexprforaddressline3", "validationmsgforaddressline3");
                            break;
                        case city:
                            Textdetails(response, "displayCity", "ui_lbl_city", "ui_img_helpTextforcity", "iscity", "ui_txt_city", "ui_txtarea_city", "ui_lbl_charsleftforcity", "regexexprforcity", "validationmsgforcity");
                            break;
                        case state:
                            Textdetails(response, "displayState", "ui_lbl_state", "ui_img_helpTextforstate", "isstate", "ui_txt_state", "ui_txtarea_state", "ui_lbl_charsleftforstate", "regexexprforstate", "validationmsgforstate");
                            break;
                        case postalcode:
                            Textdetails(response, "displayPostalCode", "ui_lbl_postalcode", "ui_img_helpTextforpostalcode", "ispostalcode", "ui_txt_postalcode", "ui_txtarea_postalcode", "ui_lbl_charsleftforpostalcode", "regexexprforpostalcode", "validationmsgforpostalcode");
                            break;
                        case country:
                            DropDowndetails(response, "displayCountry", "ui_lbl_country", "ui_img_helpTextforcountry", "iscountry");
                            break;
                        case phone:
                            Textdetails(response, "displayPhone", "ui_lbl_phone", "ui_img_helpTextforphone", "isphone", "ui_txt_phone", "ui_txtarea_phone", "ui_lbl_charsleftforphone", "regexexprforphone", "validationmsgforphone");
                            break;
                        case fax:
                            Textdetails(response, "displayFax", "ui_lbl_fax", "ui_img_helpTextforfax", "isfax", "ui_txt_fax", "ui_txtarea_fax", "ui_lbl_charsleftforfax", "regexexprforfax", "validationmsgforfax");
                            break;
                        case email:
                            Textdetails(response, "displayEmail", "ui_lbl_email", "ui_img_helpTextforemail", "isemail", "ui_txt_email", "ui_txtarea_email", "ui_lbl_charsleftforemail", "regexexprforemail", "validationmsgforemail");
                            break;
                        case npi:
                            Textdetails(response, "displayNPI", "ui_lbl_npi", "ui_img_helpTextfornpi", "isnpi", "ui_txt_npi", "ui_txtarea_npi", "ui_lbl_charsleftfornpi", "regexexprfornpi", "validationmsgfornpi");
                            break;
                        case region:
                            DropDowndetails(response, "displayRegion", "ui_lbl_region", "ui_img_helpTextforregion", "isregion");
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

$("#contacts").on("click", function () {
    $('#contactsdetails').removeClass('contactsdetails');
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
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case siteindex:
                            $("#ui_dtg_Contacts th[data-field=SiteIndex]").html(response[i].Name);
                            break;
                        case contacttype:
                            $("#ui_dtg_Contacts th[data-field=ContactType]").html(response[i].Name);
                            break;
                        case contacttypedetails:
                            $("#ui_dtg_Contacts th[data-field=ContactTypeDetails]").html(response[i].Name);
                            break;
                        case taxid:
                            $("#ui_dtg_Contacts th[data-field=TaxID]").html(response[i].Name);
                            break;
                        case salutation:
                            $("#ui_dtg_Contacts th[data-field=Salutation]").html(response[i].Name);
                            break;
                        case firstname:
                            $("#ui_dtg_Contacts th[data-field=FirstName]").html(response[i].Name);
                            break;
                        case lastname:
                            $("#ui_dtg_Contacts th[data-field=LastName]").html(response[i].Name);
                            break;
                        case suffix:
                            $("#ui_dtg_Contacts th[data-field=Suffix]").html(response[i].Name);
                            break;
                        case title:
                            $("#ui_dtg_Contacts th[data-field=Title]").html(response[i].Name);
                            break;
                        case credentials:
                            $("#ui_dtg_Contacts th[data-field=Degree]").html(response[i].Name);
                            break;
                        case piiinstitution:
                            $("#ui_dtg_Contacts th[data-field=Institution]").html(response[i].Name);
                            break;
                        case address1:
                            $("#ui_dtg_Contacts th[data-field=Address1]").html(response[i].Name);
                            break;
                        case address2:
                            $("#ui_dtg_Contacts th[data-field=Address2]").html(response[i].Name);
                            break;
                        case address3:
                            $("#ui_dtg_Contacts th[data-field=Address3]").html(response[i].Name);
                            break;
                        case city:
                            $("#ui_dtg_Contacts th[data-field=CityName]").html(response[i].Name);
                            break;
                        case state:
                            $("#ui_dtg_Contacts th[data-field=StateName]").html(response[i].Name);
                            break;
                        case postalcode:
                            $("#ui_dtg_Contacts th[data-field=PostalCode]").html(response[i].Name);
                            break;
                        case country:
                            $("#ui_dtg_Contacts th[data-field=CountryName]").html(response[i].Name);
                            break;
                        case phone:
                            $("#ui_dtg_Contacts th[data-field=Phone]").html(response[i].Name);
                            break;
                        case fax:
                            $("#ui_dtg_Contacts th[data-field=Fax]").html(response[i].Name);
                            break;
                        case email:
                            $("#ui_dtg_Contacts th[data-field=PrimaryEmailId]").html(response[i].Name);
                            break;
                        case npi:
                            $("#ui_dtg_Contacts th[data-field=Npinumber]").html(response[i].Name);
                            break;
                        case region:
                            $("#ui_dtg_Contacts th[data-field=Region]").html(response[i].Name);
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