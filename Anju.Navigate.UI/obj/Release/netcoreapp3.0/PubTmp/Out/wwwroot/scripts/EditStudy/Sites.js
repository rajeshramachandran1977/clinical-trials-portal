//#region Template declarations
var sitestemplate = kendo.template($("#sitestemplate").html());
//#endregion

function deleteStudysites(e) {
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
    var grid = $("#ui_dtg_studysites").data("kendoGrid"); //Get the grid from which the pop-up is coming
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

function addSites() {
    var wnd = $("#Sites").data("kendoWindow");
    wnd.content(sitestemplate(kendo.template($("#sitestemplate").html())));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadSitesattributes();

    CheckcharacterLength();

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

    isvalidRegexforsiteinstitutionname = true;

    $('#institutioninternal,#sitecountry,#isdrugshippedtosite,#iscontractdirectwithsite').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    //#region Validate RegEx values for Sites(Add mode)
    $("#ui_txtarea_siteinstitutionname").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_siteinstitutionname").val().trim();
        if (str != "")
            if ($("#regexexprforsiteinstitutionname").val() != "") {
                var expr = new RegExp($("#regexexprforsiteinstitutionname").val());
                var str = $("#ui_txtarea_siteinstitutionname").val();
                if (str != "" && !expr.test(str)) {
                    $('#siteinstitutionname').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforsiteinstitutionname").val() + '</div>');
                    isvalidRegexforsiteinstitutionname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforsiteinstitutionname = true;
                    return true;
                }
            }
    });
    $("#ui_txt_siteinstitutionname").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_siteinstitutionname").val().trim();
        if (str != "")
            if ($("#regexexprforsiteinstitutionname").val() != "") {
                var expr = new RegExp($("#regexexprforsiteinstitutionname").val());
                var str = $("#ui_txt_siteinstitutionname").val();
                if (str != "" && !expr.test(str)) {
                    $('#siteinstitutionname').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforsiteinstitutionname").val() + '</div>');
                    isvalidRegexforsiteinstitutionname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforsiteinstitutionname = true;
                    return true;
                }
            }
    });
    //#endregion Validate RegEx

    $("#ui_btnSavesites").click(function (e) {
        SaveSites("Create");
    });

    $("#ui_txt_siteinstitutionname,#ui_txtarea_siteinstitutionname").on("keydown", function (e) {
        $(this).nextAll("div.error").remove();
    });

    $("#ui_dtg_studysites").data("kendoGrid").dataSource.read();
    $("#ui_dtg_studysites").data("kendoGrid").refresh();
}

function showStudysites(e) {
    var grid = $("#ui_dtg_studysites").getKendoGrid();
    var wnd = $("#Sites").data("kendoWindow");
    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(sitestemplate(dataItem));
    wnd.center().open();

    LoadSitesattributes();

    CheckcharacterLength();

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

    isvalidRegexforsiteinstitutionname = true;

    $('#institutioninternal,#sitecountry,#isdrugshippedtosite,#iscontractdirectwithsite').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    //#region Validate RegEx values for Sites(Edit mode)
    $("#ui_txtarea_siteinstitutionname").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_siteinstitutionname").val().trim();
        if (str != "")
            if ($("#regexexprforsiteinstitutionname").val() != "") {
                var expr = new RegExp($("#regexexprforsiteinstitutionname").val());
                var str = $("#ui_txtarea_siteinstitutionname").val();
                if (str != "" && !expr.test(str)) {
                    $('#siteinstitutionname').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforsiteinstitutionname").val() + '</div>');
                    isvalidRegexforsiteinstitutionname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforsiteinstitutionname = true;
                    return true;
                }
            }
    });
    $("#ui_txt_siteinstitutionname").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_siteinstitutionname").val().trim();
        if (str != "")
            if ($("#regexexprforsiteinstitutionname").val() != "") {
                var expr = new RegExp($("#regexexprforsiteinstitutionname").val());
                var str = $("#ui_txt_siteinstitutionname").val();
                if (str != "" && !expr.test(str)) {
                    $('#siteinstitutionname').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforsiteinstitutionname").val() + '</div>');
                    isvalidRegexforsiteinstitutionname = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforsiteinstitutionname = true;
                    return true;
                }
            }
    });
    //#endregion Validate RegEx

    //#region Get existing Sites
    $("#ui_num_siteid").val(dataItem.SiteId);
    if (dataItem.InstitutionInternal == null)
        $('#ui_ddl_institutioninternal').data('kendoDropDownList').value('Select');
    else
        $('#ui_ddl_institutioninternal').data('kendoDropDownList').value(dataItem.InstitutionInternal);

    if (dataItem.SiteCountry == null)
        $("#ui_ddl_sitecountry").data('kendoDropDownList').value('Select');
    else
        $("#ui_ddl_sitecountry").data('kendoDropDownList').value(dataItem.SiteCountry);

    if (dataItem.IsDrugShippedtoSite == true)
        $("#ui_ddl_isdrugshippedtosite").data('kendoDropDownList').value(yes);
    if (dataItem.IsDrugShippedtoSite == false)
        $("#ui_ddl_isdrugshippedtosite").data('kendoDropDownList').value(no);
    if (dataItem.IsDrugShippedtoSite == null)
        $("#ui_ddl_isdrugshippedtosite").data('kendoDropDownList').value('Select');

    if (dataItem.IsContractdirectwithSite == true)
        $("#ui_ddl_isiscontractdirectwithsite").data('kendoDropDownList').value(yes);
    if (dataItem.IsContractdirectwithSite == false)
        $("#ui_ddl_isiscontractdirectwithsite").data('kendoDropDownList').value(no);
    if (dataItem.IsContractdirectwithSite == null)
        $("#ui_ddl_isiscontractdirectwithsite").data('kendoDropDownList').value('Select');

    $("#ui_txt_siteinstitutionname,#ui_txtarea_siteinstitutionname").val(dataItem.SiteInstitution);
    //#endregion

    $("#ui_btnSavesites").click(function (e) {
        SaveSites("Edit");
    });

    $("#ui_txt_siteinstitutionname,#ui_txtarea_siteinstitutionname").on("keydown", function (e) {
        $(this).nextAll("div.error").remove();
    });

    $("#ui_dtg_studysites").data("kendoGrid").dataSource.read();
    $("#ui_dtg_studysites").data("kendoGrid").refresh();
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

//#region Validate Sites Fields
function ValidateSitesFields() {
    $(".error").remove();
    retval = true;
    objSites = new Object();
    objSites.StudyId = $('#StudyId').val();
    objSites.SiteId = $('#ui_num_siteid').val();

    if ($('#displayInstitutioninternal').is(':visible'))
        if (sessionStorage.getItem("isinstitutioninternal") == "true") {
            if ($('#ui_ddl_institutioninternal').val() == "") {
                $('#institutioninternal').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_institutioninternal').html() + ' is required</div>');
                retval = false;
            }
            else
                objSites.InstitutionInternal = $('#ui_ddl_institutioninternal').val();
        }
        else
            objSites.InstitutionInternal = $('#ui_ddl_institutioninternal').val();

    if ($('#displaySitecountry').is(':visible'))
        if (sessionStorage.getItem("issitecountry") == "true") {
            if ($('#ui_ddl_sitecountry').val() == "") {
                $('#sitecountry').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_sitecountry').html() + ' is required</div>');
                retval = false;
            }
            else
                objSites.SiteCountry = $('#ui_ddl_sitecountry').val();
        }
        else
            objSites.SiteCountry = $('#ui_ddl_sitecountry').val();

    if ($('#displayIsdrugshippedtosite').is(':visible'))
        if (sessionStorage.getItem("isdrugshippedtosite") == "true") {
            if ($('#ui_ddl_isdrugshippedtosite').val() == "") {
                $('#isdrugshippedtosite').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_isdrugshippedtosite').html() + ' is required</div>');
                retval = false;
            }
            else
                if ($('#ui_ddl_isdrugshippedtosite').val() == yes)
                    objSites.IsDrugShippedtoSite = true;
            if ($('#ui_ddl_isdrugshippedtosite').val() == no)
                objSites.IsDrugShippedtoSite = false;
            if ($('#ui_ddl_isdrugshippedtosite').val() == "Select")
                objSites.IsDrugShippedtoSite = null;
        }
        else
            if ($('#ui_ddl_isdrugshippedtosite').val() == yes)
                objSites.IsDrugShippedtoSite = true;
    if ($('#ui_ddl_isdrugshippedtosite').val() == no)
        objSites.IsDrugShippedtoSite = false;
    if ($('#ui_ddl_isdrugshippedtosite').val() == "Select")
        objSites.IsDrugShippedtoSite = null;

    if ($('#displayIscontractdirectwithsite').is(':visible'))
        if (sessionStorage.getItem("iscontractdirectwithsite") == "true") {
            if ($('#ui_ddl_isiscontractdirectwithsite').val() == "") {
                $('#iscontractdirectwithsite').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_iscontractdirectwithsite').html() + ' is required</div>');
                retval = false;
            }
            else
                if ($('#ui_ddl_isiscontractdirectwithsite').val() == yes)
                    objSites.IsContractdirectwithSite = true;
            if ($('#ui_ddl_isiscontractdirectwithsite').val() == no)
                objSites.IsContractdirectwithSite = false;
            if ($('#ui_ddl_isiscontractdirectwithsite').val() == "Select")
                objSites.IsContractdirectwithSite = null;
        }
        else
            if ($('#ui_ddl_isiscontractdirectwithsite').val() == yes)
                objSites.IsContractdirectwithSite = true;
    if ($('#ui_ddl_isiscontractdirectwithsite').val() == no)
        objSites.IsContractdirectwithSite = false;
    if ($('#ui_ddl_isiscontractdirectwithsite').val() == "Select")
        objSites.IsContractdirectwithSite = null;

    if ($('#displaySiteinstitutionname').is(':visible'))
        if (sessionStorage.getItem("issiteinstitutionname") == "true") {
            if ($('#ui_txt_siteinstitutionname').is(':visible')) {
                if ($('#ui_txt_siteinstitutionname').val() == "") {
                    $('#siteinstitutionname').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_siteinstitutionname').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_siteinstitutionname').is(':visible')) {
                if ($('#ui_txtarea_siteinstitutionname').val() == "") {
                    $('#ui_txtarea_siteinstitutionname').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_siteinstitutionname').html() + ' is required</span>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_siteinstitutionname').is(':visible'))
                objSites.SiteInstitution = $('#ui_txtarea_siteinstitutionname').val().trim();
            if ($('#ui_txt_siteinstitutionname').is(':visible'))
                objSites.SiteInstitution = $('#ui_txt_siteinstitutionname').val().trim();
        }
        else {
            if ($('#ui_txtarea_siteinstitutionname').is(':visible'))
                objSites.SiteInstitution = $('#ui_txtarea_siteinstitutionname').val().trim();
            if ($('#ui_txt_siteinstitutionname').is(':visible'))
                objSites.SiteInstitution = $('#ui_txt_siteinstitutionname').val().trim();
        }
}
    //#endregion

//#region Save Sites
function SaveSites(mode) {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");
    ValidateSitesFields();
    if ($('#ui_ddl_institutioninternal').val() == "" && $('#ui_ddl_sitecountry').val() == ""
        && $('#ui_ddl_isdrugshippedtosite').val() == "" && $('#ui_ddl_isiscontractdirectwithsite').val() == ""
        && $('#ui_txtarea_siteinstitutionname').val() == "" && $('#ui_txt_siteinstitutionname').val() == "") {
        popupNotification.show("Empty record detected,please enter some values.", "info");
        return false;
    }
    else {
        if (validator.validate() && retval === true) {
            Savedetails(type = 19, objEditstudy = objSites, mode = mode);
            $("#Sites").data("kendoWindow").close();
            return true;
        }
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    }
}
    //#endregion

function LoadSitesattributes() {
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
                        case institutioninternal:
                            DropDowndetails(response, "displayInstitutioninternal", "ui_lbl_institutioninternal", "ui_img_helpTextforinstitutioninternal", "isinstitutioninternal");
                            break;
                        case siteinstitution:
                            Textdetails(response, "displaySiteinstitutionname", "ui_lbl_siteinstitutionname", "ui_img_helpTextforsiteinstitutionname", "issiteinstitutionname", "ui_txt_siteinstitutionname", "ui_txtarea_siteinstitutionname", "ui_lbl_charsleftforsiteinstitutionname", "regexexprforsiteinstitutionname", "validationmsgforsiteinstitutionname");
                            break;
                        case country:
                            DropDowndetails(response, "displaySitecountry", "ui_lbl_sitecountry", "ui_img_helpTextforsitecountry", "issitecountry");
                            break;
                        case isdrugshippedtosite:
                            DropDowndetails(response, "displayIsdrugshippedtosite", "ui_lbl_isdrugshippedtosite", "ui_img_helpTextforisdrugshippedtosite", "isdrugshippedtosite");
                            break;
                        case iscontractdirectwithsite:
                            DropDowndetails(response, "displayIscontractdirectwithsite", "ui_lbl_iscontractdirectwithsite", "ui_img_helpTextforisiscontractdirectwithsite", "iscontractdirectwithsite");
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
                        case institutioninternal:
                            $("#ui_dtg_studysites th[data-field=InstitutionInternal]").html(response[i].Name);
                            break;
                        case siteinstitution:
                            $("#ui_dtg_studysites th[data-field=SiteInstitution]").html(response[i].Name);
                            break;
                        case country:
                            $("#ui_dtg_studysites th[data-field=SiteCountry]").html(response[i].Name);
                            break;
                        case isdrugshippedtosite:
                            $("#ui_dtg_studysites th[data-field=IsDrugShippedtoSite]").html(response[i].Name);
                            break;
                        case iscontractdirectwithsite:
                            $("#ui_dtg_studysites th[data-field=IsContractdirectwithSite]").html(response[i].Name);
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