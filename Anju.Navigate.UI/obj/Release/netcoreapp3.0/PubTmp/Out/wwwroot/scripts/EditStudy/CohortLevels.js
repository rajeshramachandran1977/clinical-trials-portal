//#region Template declarations
var cohorttemplate = kendo.template($("#cohorttemplate").html());
    //#endregion

//#region delete row functions in grids
function deleteCohortRow(e) {
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
    var grid = $("#ui_dtg_gridCohortLevels").data("kendoGrid"); //Get the grid from which the pop-up is coming
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

//#region Add and Edit values
function addCohortLevels() {
    var wnd = $("#Cohortlevels").data("kendoWindow");
    wnd.content(cohorttemplate(kendo.template($("#cohorttemplate").html())));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadCohortAttributes();

    CheckcharacterLength();

    isvalidRegexforcohortnoofpatients = isvalidRegexforcohortlevel = isvalidRegexfordrugAdoseandfreq = isvalidRegexfordrugBdoseandfreq = true;
    //#region Validate RegEx values for Cohort fields(Add mode)
    $("#ui_txtarea_cohortnoofpatients").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_cohortnoofpatients").val().trim();
        if (str != "")
            if ($("#regexexprforcohortnoofpatients").val() != "") {
                var expr = new RegExp($("#regexexprforcohortnoofpatients").val());
                var str = $("#ui_txtarea_cohortnoofpatients").val();
                if (str != "" && !expr.test(str)) {
                    $('#cohortnoofpatients').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcohortnoofpatients").val() + '</div>');
                    isvalidRegexforcohortnoofpatients = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcohortnoofpatients = true;
                    return true;
                }
            }
    });
    $("#ui_txt_cohortnoofpatients").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_cohortnoofpatients").val().trim();
        if (str != "")
            if ($("#regexexprforcohortnoofpatients").val() != "") {
                var expr = new RegExp($("#regexexprforcohortnoofpatients").val());
                var str = $("#ui_txt_cohortnoofpatients").val();
                if (str != "" && !expr.test(str)) {
                    $('#cohortnoofpatients').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcohortnoofpatients").val() + '</div>');
                    isvalidRegexforcohortnoofpatients = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcohortnoofpatients = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_cohortlevel").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_cohortlevel").val().trim();
        if (str != "")
            if ($("#regexexprforcohortlevel").val() != "") {
                var expr = new RegExp($("#regexexprforcohortlevel").val());
                var str = $("#ui_txtarea_cohortlevel").val();
                if (str != "" && !expr.test(str)) {
                    $('#cohortlevel').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcohortlevel").val() + '</div>');
                    isvalidRegexforcohortlevel = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcohortlevel = true;
                    return true;
                }
            }
    });
    $("#ui_txt_cohortlevel").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_cohortlevel").val().trim();
        if (str != "")
            if ($("#regexexprforcohortlevel").val() != "") {
                var expr = new RegExp($("#regexexprforcohortlevel").val());
                var str = $("#ui_txt_cohortlevel").val();
                if (str != "" && !expr.test(str)) {
                    $('#cohortlevel').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcohortlevel").val() + '</div>');
                    isvalidRegexforcohortlevel = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcohortlevel = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_drugAdoseandfreq").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_drugAdoseandfreq").val().trim();
        if (str != "")
            if ($("#regexexprfordrugAdoseandfreq").val() != "") {
                var expr = new RegExp($("#regexexprfordrugAdoseandfreq").val());
                var str = $("#ui_txtarea_drugAdoseandfreq").val();
                if (str != "" && !expr.test(str)) {
                    $('#drugAdoseandfreq').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordrugAdoseandfreq").val() + '</div>');
                    isvalidRegexfordrugAdoseandfreq = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordrugAdoseandfreq = true;
                    return true;
                }
            }
    });
    $("#ui_txt_drugAdoseandfreq").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_drugAdoseandfreq").val().trim();
        if (str != "")
            if ($("#regexexprfordrugAdoseandfreq").val() != "") {
                var expr = new RegExp($("#regexexprfordrugAdoseandfreq").val());
                var str = $("#ui_txt_drugAdoseandfreq").val();
                if (str != "" && !expr.test(str)) {
                    $('#drugAdoseandfreq').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordrugAdoseandfreq").val() + '</div>');
                    isvalidRegexfordrugAdoseandfreq = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordrugAdoseandfreq = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_drugBdoseandfreq").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_drugBdoseandfreq").val().trim();
        if (str != "")
            if ($("#regexexprfordrugBdoseandfreq").val() != "") {
                var expr = new RegExp($("#regexexprfordrugBdoseandfreq").val());
                var str = $("#ui_txtarea_drugBdoseandfreq").val();
                if (str != "" && !expr.test(str)) {
                    $('#drugBdoseandfreq').after('<span class="error errorBackground" ><div class="k-icon k-i-warning"></span>' + $("#validationmsgfordrugBdoseandfreq").val() + '</div>');
                    isvalidRegexfordrugBdoseandfreq = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordrugBdoseandfreq = true;
                    return true;
                }
            }
    });
    $("#ui_txt_drugBdoseandfreq").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_drugBdoseandfreq").val().trim();
        if (str != "")
            if ($("#regexexprfordrugBdoseandfreq").val() != "") {
                var expr = new RegExp($("#regexexprfordrugBdoseandfreq").val());
                var str = $("#ui_txt_drugBdoseandfreq").val();
                if (str != "" && !expr.test(str)) {
                    $('#drugBdoseandfreq').after('<span class="error errorBackground" ><div class="k-icon k-i-warning"></span>' + $("#validationmsgfordrugBdoseandfreq").val() + '</div>');
                    isvalidRegexfordrugBdoseandfreq = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordrugBdoseandfreq = true;
                    return true;
                }
            }
    });
    //#endregion ValidateContactsFields

    $("#ui_btnSavecohortlevels").click(function (e) {
        SaveCohortLevels("Create");
    });

    $("#cohortnoofpatients,#cohortlevel,#drugAdoseandfreq,#drugBdoseandfreq").on("keyup", function (e) {
        $(this).next("div.error").remove();
    })
}

function showCohortLevels(e) {
    var grid = $("#ui_dtg_gridCohortLevels").getKendoGrid();
    var wnd = $("#Cohortlevels").data("kendoWindow");
    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(cohorttemplate(dataItem));
    wnd.center().open();

    LoadCohortAttributes();

    CheckcharacterLength();

    isvalidRegexforcohortnoofpatients = isvalidRegexforcohortlevel = isvalidRegexfordrugAdoseandfreq = isvalidRegexfordrugBdoseandfreq = true;
    //#region Validate RegEx values for Cohort fields(Edit mode)
    $("#ui_txtarea_cohortnoofpatients").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_cohortnoofpatients").val().trim();
        if (str != "")
            if ($("#regexexprforcohortnoofpatients").val() != "") {
                var expr = new RegExp($("#regexexprforcohortnoofpatients").val());
                var str = $("#ui_txtarea_cohortnoofpatients").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_cohortnoofpatients').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcohortnoofpatients").val() + '</span>');
                    isvalidRegexforcontacttypedetails = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontacttypedetails = true;
                    return true;
                }
            }
    });
    $("#ui_txt_cohortnoofpatients").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_cohortnoofpatients").val().trim();
        if (str != "")
            if ($("#regexexprforcohortnoofpatients").val() != "") {
                var expr = new RegExp($("#regexexprforcohortnoofpatients").val());
                var str = $("#ui_txt_cohortnoofpatients").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_cohortnoofpatients').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcohortnoofpatients").val() + '</span>');
                    isvalidRegexforcontacttypedetails = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontacttypedetails = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_cohortlevel").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_cohortlevel").val().trim();
        if (str != "")
            if ($("#regexexprforcohortlevel").val() != "") {
                var expr = new RegExp($("#regexexprforcohortlevel").val());
                var str = $("#ui_txtarea_cohortlevel").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_cohortlevel').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcohortlevel").val() + '</span>');
                    isvalidRegexforcontacttypedetails = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontacttypedetails = true;
                    return true;
                }
            }
    });
    $("#ui_txt_cohortlevel").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_cohortlevel").val().trim();
        if (str != "")
            if ($("#regexexprforcohortlevel").val() != "") {
                var expr = new RegExp($("#regexexprforcohortlevel").val());
                var str = $("#ui_txt_cohortlevel").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_cohortlevel').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcohortlevel").val() + '</span>');
                    isvalidRegexforcontacttypedetails = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontacttypedetails = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_drugAdoseandfreq").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_drugAdoseandfreq").val().trim();
        if (str != "")
            if ($("#regexexprfordrugAdoseandfreq").val() != "") {
                var expr = new RegExp($("#regexexprfordrugAdoseandfreq").val());
                var str = $("#ui_txtarea_drugAdoseandfreq").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_drugAdoseandfreq').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordrugAdoseandfreq").val() + '</span>');
                    isvalidRegexforcontacttypedetails = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontacttypedetails = true;
                    return true;
                }
            }
    });
    $("#ui_txt_drugAdoseandfreq").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_drugAdoseandfreq").val().trim();
        if (str != "")
            if ($("#regexexprfordrugAdoseandfreq").val() != "") {
                var expr = new RegExp($("#regexexprfordrugAdoseandfreq").val());
                var str = $("#ui_txt_drugAdoseandfreq").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_drugAdoseandfreq').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordrugAdoseandfreq").val() + '</span>');
                    isvalidRegexforcontacttypedetails = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontacttypedetails = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_drugBdoseandfreq").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_drugBdoseandfreq").val().trim();
        if (str != "")
            if ($("#regexexprfordrugBdoseandfreq").val() != "") {
                var expr = new RegExp($("#regexexprfordrugBdoseandfreq").val());
                var str = $("#ui_txtarea_drugBdoseandfreq").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_drugBdoseandfreq').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordrugBdoseandfreq").val() + '</span>');
                    isvalidRegexforcontacttypedetails = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontacttypedetails = true;
                    return true;
                }
            }
    });
    $("#ui_txt_drugBdoseandfreq").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_drugBdoseandfreq").val().trim();
        if (str != "")
            if ($("#regexexprfordrugBdoseandfreq").val() != "") {
                var expr = new RegExp($("#regexexprfordrugBdoseandfreq").val());
                var str = $("#ui_txt_drugBdoseandfreq").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_drugBdoseandfreq').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordrugBdoseandfreq").val() + '</span>');
                    isvalidRegexforcontacttypedetails = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcontacttypedetails = true;
                    return true;
                }
            }
    });
    //#endregion ValidateContactsFields

    //#region Get existing Cohort Levels
    $("#ui_num_cohortid").val(dataItem.CohortId);
    $("#ui_txt_cohortnoofpatients,#ui_txtarea_cohortnoofpatients").val(dataItem.NoofPatients);
    $("#ui_txt_cohortlevel,#ui_txtarea_cohortlevel").val(dataItem.NoofPatients);
    $("#ui_txt_drugAdoseandfreq,#ui_txtarea_drugAdoseandfreq").val(dataItem.DoseandFrequencyDrugA);
    $("#ui_txt_drugBdoseandfreq,#ui_txtarea_drugBdoseandfreq").val(dataItem.DoseandFrequencyDrugB);
    //#endregion

    $("#ui_btnSavecohortlevels").click(function (e) {
        SaveCohortLevels("Edit");
    });

    $("#cohortnoofpatients,#cohortlevel,#drugAdoseandfreq,#drugBdoseandfreq").on("keyup", function (e) {
        $(this).next("div.error").remove();
    })

    $("#ui_dtg_gridCohortLevels").data("kendoGrid").dataSource.read();
    $("#ui_dtg_gridCohortLevels").data("kendoGrid").refresh();
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

//#region Validate Cohorts Levels fields
function ValidateCohortsLevelsFields() {
    $(".error").remove();
    retval = true;
    objCohortsLevels = new Object();
    objCohortsLevels.StudyId = $('#StudyId').val();
    objCohortsLevels.CohortId = $('#ui_num_cohortid').val();
    if ($('#displayCohortnoofpatients').is(':visible'))
        if (sessionStorage.getItem("iscohortnoofpatients") == "true") {
            if ($('#ui_txt_cohortnoofpatients').is(':visible')) {
                if ($('#ui_txt_cohortnoofpatients').val() == "") {
                    $('#cohortnoofpatients').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_cohortnoofpatients').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_cohortnoofpatients').is(':visible')) {
                if ($('#ui_txtarea_cohortnoofpatients').val() == "") {
                    $('#cohortnoofpatients').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_cohortnoofpatients').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_cohortnoofpatients').is(':visible'))
                objCohortsLevels.NoofPatients = $('#ui_txt_cohortnoofpatients').val().trim();
            if ($('#ui_txtarea_cohortnoofpatients').is(':visible'))
                objCohortsLevels.NoofPatients = $('#ui_txtarea_cohortnoofpatients').val().trim();
        }
        else {
            if ($('#ui_txtarea_cohortnoofpatients').is(':visible'))
                objCohortsLevels.NoofPatients = $('#ui_txtarea_cohortnoofpatients').val().trim();
            if ($('#ui_txt_cohortnoofpatients').is(':visible'))
                objCohortsLevels.NoofPatients = $('#ui_txt_cohortnoofpatients').val().trim();
        }
    if ($('#displayCohortlevel').is(':visible'))
        if (sessionStorage.getItem("iscohortlevel") == "true") {
            if ($('#ui_txt_cohortlevel').is(':visible')) {
                if ($('#ui_txt_cohortlevel').val() == "") {
                    $('#cohortlevel').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_cohortlevel').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_cohortlevel').is(':visible')) {
                if ($('#ui_txtarea_cohortlevel').val() == "") {
                    $('#cohortlevel').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_cohortlevel').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_cohortlevel').is(':visible'))
                objCohortsLevels.Cohortlevel = $('#ui_txtarea_cohortlevel').val().trim();
            if ($('#ui_txt_cohortlevel').is(':visible'))
                objCohortsLevels.Cohortlevel = $('#ui_txt_cohortlevel').val().trim();
        }
        else {
            if ($('#ui_txtarea_cohortlevel').is(':visible'))
                objCohortsLevels.Cohortlevel = $('#ui_txtarea_cohortlevel').val().trim();
            if ($('#ui_txt_cohortlevel').is(':visible'))
                objCohortsLevels.Cohortlevel = $('#ui_txt_cohortlevel').val().trim();
        }
    if ($('#displayDrugAdoseandfreq').is(':visible'))
        if (sessionStorage.getItem("isdrugAdoseandfreq") == "true") {
            if ($('#ui_txt_drugAdoseandfreq').is(':visible')) {
                if ($('#ui_txt_drugAdoseandfreq').val() == "") {
                    $('#drugAdoseandfreq').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_drugAdoseandfreq').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_drugAdoseandfreq').is(':visible')) {
                if ($('#ui_txtarea_drugAdoseandfreq').val() == "") {
                    $('#drugAdoseandfreq').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_drugAdoseandfreq').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_drugAdoseandfreq').is(':visible'))
                objCohortsLevels.DoseandFrequencyDrugA = $('#ui_txtarea_drugAdoseandfreq').val().trim();
            if ($('#ui_txt_drugAdoseandfreq').is(':visible'))
                objCohortsLevels.DoseandFrequencyDrugA = $('#ui_txt_drugAdoseandfreq').val().trim();
        }
        else {
            if ($('#ui_txtarea_drugAdoseandfreq').is(':visible'))
                objCohortsLevels.DoseandFrequencyDrugA = $('#ui_txtarea_drugAdoseandfreq').val().trim();
            if ($('#ui_txt_drugAdoseandfreq').is(':visible'))
                objCohortsLevels.DoseandFrequencyDrugA = $('#ui_txt_drugAdoseandfreq').val().trim();
        }
    if ($('#displayDrugBdoseandfreq').is(':visible'))
        if (sessionStorage.getItem("isdrugBdoseandfreq") == "true") {
            if ($('#ui_txt_drugBdoseandfreq').is(':visible')) {
                if ($('#ui_txt_drugBdoseandfreq').val() == "") {
                    $('#drugBdoseandfreq').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_drugBdoseandfreq').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_drugBdoseandfreq').is(':visible')) {
                if ($('#ui_txtarea_drugBdoseandfreq').val() == "") {
                    $('#drugBdoseandfreq').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_drugBdoseandfreq').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_drugBdoseandfreq').is(':visible'))
                objCohortsLevels.DoseandFrequencyDrugB = $('#ui_txtarea_drugBdoseandfreq').val().trim();
            if ($('#ui_txt_drugBdoseandfreq').is(':visible'))
                objCohortsLevels.DoseandFrequencyDrugB = $('#ui_txt_drugBdoseandfreq').val().trim();
        }
        else {
            if ($('#ui_txtarea_drugBdoseandfreq').is(':visible'))
                objCohortsLevels.DoseandFrequencyDrugB = $('#ui_txtarea_drugBdoseandfreq').val().trim();
            if ($('#ui_txt_drugAdoseandfreq').is(':visible'))
                objCohortsLevels.DoseandFrequencyDrugB = $('#ui_txt_drugBdoseandfreq').val().trim();
        }
}
    //#endregion Validate Cohorts Levels fields

//#region Save Cohort Levels
function SaveCohortLevels(mode) {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");
    ValidateCohortsLevelsFields();
    if ($('#ui_txtarea_cohortnoofpatients').val() == "" && $('#ui_txt_cohortnoofpatients').val() == ""
        && $('#ui_txtarea_cohortlevel').val() == null && $('#ui_txt_cohortlevel').val() == ""
        && $('#ui_txtarea_drugAdoseandfreq').val() == "" && $('#ui_txt_drugAdoseandfreq').val() == ""
        && $('#ui_txtarea_drugBdoseandfreq').val() == "" && $('#ui_txt_drugBdoseandfreq').val() == "") {
        popupNotification.show("Empty record detected,please enter some values.", "info");
        return false;
    }
    else {
        if (validator.validate() && retval === true
            && (isvalidRegexforcohortnoofpatients === true && isvalidRegexforcohortlevel === true
                && isvalidRegexfordrugAdoseandfreq === true && isvalidRegexfordrugBdoseandfreq === true)) {
            Savedetails(type = 14, objEditstudy = objCohortsLevels, mode = mode);
            $("#Cohortlevels").data("kendoWindow").close();
            return true;
        }
        else
            popupNotification.show("There are errors on the page.Please correct them to continue.", "error");
        return false;
    }
}
    //#endregion

function LoadCohortAttributes() {
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
                        case noofpatients:
                            Textdetails(response, "displayCohortnoofpatients", "ui_lbl_cohortnoofpatients", "ui_img_helpTextforcohortnoofpatients", "iscohortnoofpatients", "ui_txt_cohortnoofpatients", "ui_txtarea_cohortnoofpatients", "ui_lbl_charsleftforcohortnoofpatients", "regexexprforcohortnoofpatients", "validationmsgforcohortnoofpatients");
                            break;
                        case cohortlevel:
                            Textdetails(response, "displayCohortlevel", "ui_lbl_cohortlevel", "ui_img_helpTextforcohortlevel", "iscohortlevel", "ui_txt_cohortlevel", "ui_txtarea_cohortlevel", "ui_lbl_charsleftforcohortlevel", "regexexprforcohortlevel", "validationmsgforcohortlevel");
                            break;
                        case drugadoseandfreq:
                            Textdetails(response, "displayDrugAdoseandfreq", "ui_lbl_drugAdoseandfreq", "ui_img_helpTextfordrugAdoseandfreq", "isdrugAdoseandfreq", "ui_txt_drugAdoseandfreq", "ui_txtarea_drugAdoseandfreq", "ui_lbl_charsleftfordrugAdoseandfreq", "regexexprfordrugAdoseandfreq", "validationmsgfordrugAdoseandfreq");
                            break;
                        case drugbdoseandfreq:
                            Textdetails(response, "displayDrugBdoseandfreq", "ui_lbl_drugBdoseandfreq", "ui_img_helpTextfordrugBdoseandfreq", "isdrugBdoseandfreq", "ui_txt_drugBdoseandfreq", "ui_txtarea_drugBdoseandfreq", "ui_lbl_charsleftfordrugBdoseandfreq", "regexexprfordrugBdoseandfreq", "validationmsgfordrugBdoseandfreq");
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
                        case noofpatients:
                            $("#ui_dtg_gridCohortLevels th[data-field=NoofPatients]").html(response[i].Name);
                            break;
                        case cohortlevel:
                            $("#ui_dtg_gridCohortLevels th[data-field=Cohortlevel]").html(response[i].Name);
                            break;
                        case drugadoseandfreq:
                            $("#ui_dtg_gridCohortLevels th[data-field=DoseandFrequencyDrugA]").html(response[i].Name);
                            break;
                        case drugbdoseandfreq:
                            $("#ui_dtg_gridCohortLevels th[data-field=DoseandFrequencyDrugB]").html(response[i].Name);
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