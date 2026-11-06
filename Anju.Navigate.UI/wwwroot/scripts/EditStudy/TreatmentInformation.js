//#region Template declarations
var treatementinfotemplate = kendo.template($("#treatementinfotemplate").html());
    //#endregion

function OnDataBoundforTreatmentInformation() {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(treatmentinformationsattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                var grid = $("#ui_dtg_gridTreatmentInformation").data("kendoGrid");
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
                    grid.hideColumn(11);                   
                else 
                    grid.showColumn(11);
                    
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
                        grid.hideColumn(10);
                    return false;
                }
                else {
                    grid.showColumn(10);
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
function deleteTreatmentInformationRow(e) {
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
    var grid = $("#ui_dtg_gridTreatmentInformation").data("kendoGrid"); //Get the grid from which the pop-up is coming
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
function addTreatmentInformation() {

    var wnd = $("#TreatmentInformation").data("kendoWindow");
    wnd.content(treatementinfotemplate(kendo.template($("#treatementinfotemplate").html())));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadTreatmentInformationAttributes("Create");

    CheckcharacterLength();

    isvalidRegexfortreatmentarm = isvalidRegexfornoofpatientsplanned = isvalidRegexforcompound
        = isvalidRegexformindosage = isvalidRegexformaxdosage = isvalidRegexforfrequency
        = isvalidRegexforadminroute = true;

    //#region Validate RegEx values for Treatment Information(Add mode)
    $("#ui_txtarea_treatmentarm").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_treatmentarm").val().trim();
        if (str != "")
            if ($("#regexexprfortreatmentarm").val() != "") {
                var expr = new RegExp($("#regexexprfortreatmentarm").val());
                var str = $("#ui_txtarea_treatmentarm").val();
                if (str != "" && !expr.test(str)) {
                    $('#treatmentarm').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortreatmentarm").val() + '</div>');
                    isvalidRegexfortreatmentarm = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortreatmentarm = true;
                    return true;
                }
            }
    });
    $("#ui_txt_treatmentarm").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_treatmentarm").val().trim();
        if (str != "")
            if ($("#regexexprfortreatmentarm").val() != "") {
                var expr = new RegExp($("#regexexprfortreatmentarm").val());
                var str = $("#ui_txt_treatmentarm").val();
                if (str != "" && !expr.test(str)) {
                    $('#treatmentarm').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortreatmentarm").val() + '</div>');
                    isvalidRegexfortreatmentarm = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortreatmentarm = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_noofpatientsplanned").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_noofpatientsplanned").val().trim();
        if (str != "")
            if ($("#regexexprfornoofpatientsplanned").val() != "") {
                var expr = new RegExp($("#regexexprfornoofpatientsplanned").val());
                var str = $("#ui_txtarea_noofpatientsplanned").val();
                if (str != "" && !expr.test(str)) {
                    $('#noofpatientsplanned').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgfornoofpatientsplanned").val() + '</div>');
                    isvalidRegexfornoofpatientsplanned = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfornoofpatientsplanned = true;
                    return true;
                }
            }
    });
    $("#ui_txt_noofpatientsplanned").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_noofpatientsplanned").val().trim();
        if (str != "")
            if ($("#regexexprfornoofpatientsplanned").val() != "") {
                var expr = new RegExp($("#regexexprfornoofpatientsplanned").val());
                var str = $("#ui_txt_noofpatientsplanned").val();
                if (str != "" && !expr.test(str)) {
                    $('#noofpatientsplanned').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgfornoofpatientsplanned").val() + '</div>');
                    isvalidRegexfornoofpatientsplanned = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfornoofpatientsplanned = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_compound").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_compound").val().trim();
        if (str != "")
            if ($("#regexexprforcompound").val() != "") {
                var expr = new RegExp($("#regexexprforcompound").val());
                var str = $("#ui_txtarea_compound").val();
                if (str != "" && !expr.test(str)) {
                    $('#compound').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcompound").val() + '</div>');
                    isvalidRegexforcompound = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcompound = true;
                    return true;
                }
            }
    });
    $("#ui_txt_compound").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_compound").val().trim();
        if (str != "")
            if ($("#regexexprforcompound").val() != "") {
                var expr = new RegExp($("#regexexprforcompound").val());
                var str = $("#ui_txt_compound").val();
                if (str != "" && !expr.test(str)) {
                    $('#compound').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcompound").val() + '</div>');
                    isvalidRegexforcompound = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcompound = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_mindosage").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_mindosage").val().trim();
        if (str != "")
            if ($("#regexexprformindosage").val() != "") {
                var expr = new RegExp($("#regexexprformindosage").val());
                var str = $("#ui_txtarea_mindosage").val();
                if (str != "" && !expr.test(str)) {
                    $('#mindosage').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgformindosage").val() + '</div>');
                    isvalidRegexformindosage = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexformindosage = true;
                    return true;
                }
            }
    });
    $("#ui_txt_mindosage").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_mindosage").val().trim();
        if (str != "")
            if ($("#regexexprformindosage").val() != "") {
                var expr = new RegExp($("#regexexprformindosage").val());
                var str = $("#ui_txt_mindosage").val();
                if (str != "" && !expr.test(str)) {
                    $('#mindosage').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgformindosage").val() + '</div>');
                    isvalidRegexformindosage = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexformindosage = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_maxdosage").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_maxdosage").val().trim();
        if (str != "")
            if ($("#regexexprformaxdosage").val() != "") {
                var expr = new RegExp($("#regexexprformaxdosage").val());
                var str = $("#ui_txtarea_maxdosage").val();
                if (str != "" && !expr.test(str)) {
                    $('#maxdosage').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgformaxdosage").val() + '</div>');
                    isvalidRegexformaxdosage = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexformaxdosage = true;
                    return true;
                }
            }
    });
    $("#ui_txt_maxdosage").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_maxdosage").val().trim();
        if (str != "")
            if ($("#regexexprformaxdosage").val() != "") {
                var expr = new RegExp($("#regexexprformaxdosage").val());
                var str = $("#ui_txt_maxdosage").val();
                if (str != "" && !expr.test(str)) {
                    $('#maxdosage').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgformaxdosage").val() + '</div>');
                    isvalidRegexformaxdosage = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexformaxdosage = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_frequency").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_frequency").val().trim();
        if (str != "")
            if ($("#regexexprforfrequency").val() != "") {
                var expr = new RegExp($("#regexexprforfrequency").val());
                var str = $("#ui_txtarea_frequency").val();
                if (str != "" && !expr.test(str)) {
                    $('#frequency').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforfrequency").val() + '</div>');
                    isvalidRegexforfrequency = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforfrequency = true;
                    return true;
                }
            }
    });
    $("#ui_txt_frequency").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_frequency").val().trim();
        if (str != "")
            if ($("#regexexprforfrequency").val() != "") {
                var expr = new RegExp($("#regexexprforfrequency").val());
                var str = $("#ui_txt_frequency").val();
                if (str != "" && !expr.test(str)) {
                    $('#frequency').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforfrequency").val() + '</div>');
                    isvalidRegexforfrequency = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforfrequency = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_adminroute").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_adminroute").val().trim();
        if (str != "")
            if ($("#").val() != "") {
                var expr = new RegExp($("#regexexprforadminroute").val());
                var str = $("#ui_txtarea_adminroute").val();
                if (str != "" && !expr.test(str)) {
                    $('#adminroute').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforfadminroute").val() + '</div>');
                    isvalidRegexforfrequency = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforfrequency = true;
                    return true;
                }
            }
    });
    $("#ui_txt_adminroute").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_adminroute").val().trim();
        if (str != "")
            if ($("#regexexprforadminroute").val() != "") {
                var expr = new RegExp($("#").val());
                var str = $("#ui_txt_adminroute").val();
                if (str != "" && !expr.test(str)) {
                    $('#adminroute').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforfadminroute").val() + '</div>');
                    isvalidRegexforadminroute = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforadminroute = true;
                    return true;
                }
            }
    });
    //#endregion ValidateContactsFields

    $("#ui_btnSavetreatementinfo").click(function (e) {
        SaveTreatmentInformation("Create");
    });

    $('#ui_ddl_genericacceptable,#ui_ddl_typeoftrialdrug').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    $("#treatmentarm,#noofpatientsplanned,#compound,#mindosage,#maxdosage,#frequency").on("keyup", function (e) {
        $(this).next("div.error").remove();
    })

    $("#ui_dtg_gridTreatmentInformation").data("kendoGrid").dataSource.read();
    $("#ui_dtg_gridTreatmentInformation").data("kendoGrid").refresh();
}

function showTreatmentInformation(e) {
    var grid = $("#ui_dtg_gridTreatmentInformation").getKendoGrid();
    var wnd = $("#TreatmentInformation").data("kendoWindow");
    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(treatementinfotemplate(dataItem));
    wnd.center().open();

    LoadTreatmentInformationAttributes("Edit");

    CheckcharacterLength();

    isvalidRegexfortreatmentarm = isvalidRegexfornoofpatientsplanned = isvalidRegexforcompound
        = isvalidRegexformindosage = isvalidRegexformaxdosage = isvalidRegexforfrequency
        = isvalidRegexforadminroute = true;

    $('#ui_ddl_genericacceptable,#ui_ddl_typeoftrialdrug').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    //#region Validate RegEx values for Treatment Information(Edit mode)
    $("#ui_txtarea_treatmentarm").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_treatmentarm").val().trim();
        if (str != "")
            if ($("#regexexprfortreatmentarm").val() != "") {
                var expr = new RegExp($("#regexexprfortreatmentarm").val());
                var str = $("#ui_txtarea_treatmentarm").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_treatmentarm').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortreatmentarm").val() + '</span>');
                    isvalidRegexfortreatmentarm = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortreatmentarm = true;
                    return true;
                }
            }
    });
    $("#ui_txt_treatmentarm").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_treatmentarm").val().trim();
        if (str != "")
            if ($("#regexexprfortreatmentarm").val() != "") {
                var expr = new RegExp($("#regexexprfortreatmentarm").val());
                var str = $("#ui_txt_treatmentarm").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_treatmentarm').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgfortreatmentarm").val() + '</span>');
                    isvalidRegexfortreatmentarm = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfortreatmentarm = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_noofpatientsplanned").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_noofpatientsplanned").val().trim();
        if (str != "")
            if ($("#regexexprfornoofpatientsplanned").val() != "") {
                var expr = new RegExp($("#regexexprfornoofpatientsplanned").val());
                var str = $("#ui_txtarea_noofpatientsplanned").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_noofpatientsplanned').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgfornoofpatientsplanned").val() + '</span>');
                    isvalidRegexfornoofpatientsplanned = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfornoofpatientsplanned = true;
                    return true;
                }
            }
    });
    $("#ui_txt_noofpatientsplanned").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_noofpatientsplanned").val().trim();
        if (str != "")
            if ($("#regexexprfornoofpatientsplanned").val() != "") {
                var expr = new RegExp($("#regexexprfornoofpatientsplanned").val());
                var str = $("#ui_txt_noofpatientsplanned").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_noofpatientsplanned').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgfornoofpatientsplanned").val() + '</span>');
                    isvalidRegexfornoofpatientsplanned = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfornoofpatientsplanned = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_compound").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_compound").val().trim();
        if (str != "")
            if ($("#regexexprforcompound").val() != "") {
                var expr = new RegExp($("#regexexprforcompound").val());
                var str = $("#ui_txtarea_compound").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_compound').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcompound").val() + '</span>');
                    isvalidRegexforcompound = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcompound = true;
                    return true;
                }
            }
    });
    $("#ui_txt_compound").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_compound").val().trim();
        if (str != "")
            if ($("#regexexprforcompound").val() != "") {
                var expr = new RegExp($("#regexexprforcompound").val());
                var str = $("#ui_txt_compound").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_compound').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforcompound").val() + '</span>');
                    isvalidRegexforcompound = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforcompound = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_mindosage").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_mindosage").val().trim();
        if (str != "")
            if ($("#regexexprformindosage").val() != "") {
                var expr = new RegExp($("#regexexprformindosage").val());
                var str = $("#ui_txtarea_mindosage").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_mindosage').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgformindosage").val() + '</span>');
                    isvalidRegexformindosage = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexformindosage = true;
                    return true;
                }
            }
    });
    $("#ui_txt_mindosage").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_mindosage").val().trim();
        if (str != "")
            if ($("#regexexprformindosage").val() != "") {
                var expr = new RegExp($("#regexexprformindosage").val());
                var str = $("#ui_txt_mindosage").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_mindosage').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgformindosage").val() + '</span>');
                    isvalidRegexformindosage = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexformindosage = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_maxdosage").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_maxdosage").val().trim();
        if (str != "")
            if ($("#regexexprformaxdosage").val() != "") {
                var expr = new RegExp($("#regexexprformaxdosage").val());
                var str = $("#ui_txtarea_maxdosage").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_maxdosage').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgformaxdosage").val() + '</span>');
                    isvalidRegexformaxdosage = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexformaxdosage = true;
                    return true;
                }
            }
    });
    $("#ui_txt_maxdosage").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_maxdosage").val().trim();
        if (str != "")
            if ($("#regexexprformaxdosage").val() != "") {
                var expr = new RegExp($("#regexexprformaxdosage").val());
                var str = $("#ui_txt_maxdosage").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_maxdosage').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgformaxdosage").val() + '</span>');
                    isvalidRegexformaxdosage = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexformaxdosage = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_frequency").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_frequency").val().trim();
        if (str != "")
            if ($("#regexexprforfrequency").val() != "") {
                var expr = new RegExp($("#regexexprforfrequency").val());
                var str = $("#ui_txtarea_frequency").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_frequency').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforfrequency").val() + '</span>');
                    isvalidRegexforfrequency = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforfrequency = true;
                    return true;
                }
            }
    });
    $("#ui_txt_frequency").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_frequency").val().trim();
        if (str != "")
            if ($("#regexexprforfrequency").val() != "") {
                var expr = new RegExp($("#regexexprforfrequency").val());
                var str = $("#ui_txt_frequency").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_frequency').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforfrequency").val() + '</span>');
                    isvalidRegexforfrequency = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforfrequency = true;
                    return true;
                }
            }
    });
    $("#ui_txtarea_adminroute").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_adminroute").val().trim();
        if (str != "")
            if ($("#").val() != "") {
                var expr = new RegExp($("#regexexprforadminroute").val());
                var str = $("#ui_txtarea_adminroute").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_adminroute').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforfadminroute").val() + '</span>');
                    isvalidRegexforfrequency = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforfrequency = true;
                    return true;
                }
            }
    });
    $("#ui_txt_adminroute").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_adminroute").val().trim();
        if (str != "")
            if ($("#regexexprforadminroute").val() != "") {
                var expr = new RegExp($("#").val());
                var str = $("#ui_txt_adminroute").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_adminroute').after('<span class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $("#validationmsgforfadminroute").val() + '</span>');
                    isvalidRegexforadminroute = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforadminroute = true;
                    return true;
                }
            }
    });
    //#endregion ValidateTreatmentInformationFields

    //#region Get existing Treatment Information
    $("#ui_num_treatmentinfoid").val(dataItem.TreatmentInfoId);
    $("#ui_ddl_typeoftrialdrug").data('kendoDropDownList').value(dataItem.TypeofTrialDrug);
    $("#ui_txt_treatmentarm,#ui_txtarea_treatmentarm").val(dataItem.TreatmentArm);
    $("#ui_txt_noofpatientsplanned,#ui_txtarea_noofpatientsplanned").val(dataItem.NoofPatientsPlanned);
    $("#ui_txt_compound,#ui_txtarea_compound").val(dataItem.Compound);
    $("#ui_txt_mindosage,#ui_txtarea_mindosage").val(dataItem.Mindosage);
    $("#ui_txt_maxdosage,#ui_txtarea_maxdosage").val(dataItem.Maxdosage);
    $("#ui_txt_frequency,#ui_txtarea_frequency").val(dataItem.Frequency);
    $("#ui_txt_adminroute,#ui_txtarea_adminroute").val(dataItem.AdminRoute);
    if (dataItem.GenericAcceptable == true)
        $("#ui_ddl_genericacceptable").data('kendoDropDownList').value(yes);
    else
        $("#ui_ddl_genericacceptable").data('kendoDropDownList').value(no);
    //#endregion

    $("#ui_btnSavetreatementinfo").click(function (e) {
        SaveTreatmentInformation("Edit");
    });

    $("#ui_dtg_gridTreatmentInformation").data("kendoGrid").dataSource.read();
    $("#ui_dtg_gridTreatmentInformation").data("kendoGrid").refresh();
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

//#region Validate Treatement Info fields  fields
function ValidateTreatmentInfoFields() {
    $(".error").remove();
    retval = true;
    objTreatementInfo = new Object();
    objTreatementInfo.StudyId = $('#StudyId').val();
    objTreatementInfo.TreatmentInfoId = $('#ui_num_treatmentinfoid').val();
    if ($('#displayTreatmentarm').is(':visible'))
        if (sessionStorage.getItem("istreatmentarm") == "true") {
            if ($('#ui_txt_treatmentarm').is(':visible')) {
                if ($('#ui_txt_treatmentarm').val() == "") {
                    $('#treatmentarm').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_treatmentarm').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_treatmentarm').is(':visible')) {
                if ($('#ui_txtarea_treatmentarm').val() == "") {
                    $('#treatmentarm').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_treatmentarm').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_treatmentarm').is(':visible'))
                objTreatementInfo.TreatmentArm = $('#ui_txt_treatmentarm').val().trim();
            if ($('#ui_txtarea_treatmentarm').is(':visible'))
                objTreatementInfo.TreatmentArm = $('#ui_txtarea_treatmentarm').val().trim();
        }
        else {
            if ($('#ui_txtarea_treatmentarm').is(':visible'))
                objTreatementInfo.TreatmentArm = $('#ui_txtarea_treatmentarm').val().trim();
            if ($('#ui_txt_treatmentarm').is(':visible'))
                objTreatementInfo.TreatmentArm = $('#ui_txt_treatmentarm').val().trim();
        }
    if ($('#displayNoofpatientsplanned').is(':visible'))
        if (sessionStorage.getItem("isnoofpatientsplanned") == "true") {
            if ($('#ui_txt_noofpatientsplanned').is(':visible')) {
                if ($('#ui_txt_noofpatientsplanned').val() == "") {
                    $('#noofpatientsplanned').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_noofpatientsplanned').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_noofpatientsplanned').is(':visible')) {
                if ($('#ui_txtarea_noofpatientsplanned').val() == "") {
                    $('#noofpatientsplanned').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_noofpatientsplanned').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_noofpatientsplanned').is(':visible'))
                objTreatementInfo.NoofPatientsPlanned = $('#ui_txtarea_noofpatientsplanned').val().trim();
            if ($('#ui_txt_noofpatientsplanned').is(':visible'))
                objTreatementInfo.NoofPatientsPlanned = $('#ui_txt_noofpatientsplanned').val().trim();
        }
        else {
            if ($('#ui_txtarea_noofpatientsplanned').is(':visible'))
                objTreatementInfo.NoofPatientsPlanned = $('#ui_txtarea_noofpatientsplanned').val().trim();
            if ($('#ui_txt_noofpatientsplanned').is(':visible'))
                objTreatementInfo.NoofPatientsPlanned = $('#ui_txt_noofpatientsplanned').val().trim();
        }

    if ($('#displayTypeoftrialdrug').is(':visible'))
        if (sessionStorage.getItem("istypeoftrialdrug") == "true") {
            if ($('#ui_ddl_typeoftrialdrug').val() == "") {
                $('#typeoftrialdrug').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_typeoftrialdrug').html() + ' is required</div>');
                retval = false;
            }
            else
                objTreatementInfo.TypeofTrialDrug = $('#ui_ddl_typeoftrialdrug').val();
        }
        else
            objTreatementInfo.TypeofTrialDrug = $('#ui_ddl_typeoftrialdrug').val();

    if ($('#displayCompound').is(':visible'))
        if (sessionStorage.getItem("iscompound") == "true") {
            if ($('#ui_txt_compound').is(':visible')) {
                if ($('#ui_txt_compound').val() == "") {
                    $('#compound').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_compound').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_compound').is(':visible')) {
                if ($('#ui_txtarea_compound').val() == "") {
                    $('#compound').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_compound').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_compound').is(':visible'))
                objTreatementInfo.Compound = $('#ui_txtarea_compound').val().trim();
            if ($('#ui_txt_compound').is(':visible'))
                objTreatementInfo.Compound = $('#ui_txt_compound').val().trim();
        }
        else {
            if ($('#ui_txtarea_compound').is(':visible'))
                objTreatementInfo.Compound = $('#ui_txtarea_compound').val().trim();
            if ($('#ui_txt_compound').is(':visible'))
                objTreatementInfo.Compound = $('#ui_txt_compound').val().trim();
        }

    if ($('#displayMaxdosage').is(':visible'))
        if (sessionStorage.getItem("ismaxdosage") == "true") {
            if ($('#ui_txt_maxdosage').is(':visible')) {
                if ($('#ui_txt_maxdosage').val() == "") {
                    $('#maxdosage').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_maxdosage').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_maxdosage').is(':visible')) {
                if ($('#ui_txtarea_maxdosage').val() == "") {
                    $('#maxdosage').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_maxdosage').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_maxdosage').is(':visible'))
                objTreatementInfo.maxdosage = $('#ui_txtarea_maxdosage').val().trim();
            if ($('#ui_txt_maxdosage').is(':visible'))
                objTreatementInfo.maxdosage = $('#ui_txt_maxdosage').val().trim();
        }
        else {
            if ($('#ui_txtarea_maxdosage').is(':visible'))
                objTreatementInfo.maxdosage = $('#ui_txtarea_maxdosage').val().trim();
            if ($('#ui_txt_maxdosage').is(':visible'))
                objTreatementInfo.maxdosage = $('#ui_txt_maxdosage').val().trim();
        }

    if ($('#displayMindosage').is(':visible'))
        if (sessionStorage.getItem("ismindosage") == "true") {
            if ($('#ui_txt_mindosage').is(':visible')) {
                if ($('#ui_txt_mindosage').val() == "") {
                    $('#mindosage').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_mindosage').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_mindosage').is(':visible')) {
                if ($('#ui_txtarea_mindosage').val() == "") {
                    $('#mindosage').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_mindosage').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_mindosage').is(':visible'))
                objTreatementInfo.Mindosage = $('#ui_txtarea_mindosage').val().trim();
            if ($('#ui_txt_mindosage').is(':visible'))
                objTreatementInfo.Mindosage = $('#ui_txt_mindosage').val().trim();
        }
        else {
            if ($('#ui_txtarea_mindosage').is(':visible'))
                objTreatementInfo.Mindosage = $('#ui_txtarea_mindosage').val().trim();
            if ($('#ui_txt_mindosage').is(':visible'))
                objTreatementInfo.Mindosage = $('#ui_txt_mindosage').val().trim();
        }

    if ($('#displayFrequency').is(':visible'))
        if (sessionStorage.getItem("isfrequency") == "true") {
            if ($('#ui_txt_frequency').is(':visible')) {
                if ($('#ui_txt_frequency').val() == "") {
                    $('#frequency').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_frequency').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_frequency').is(':visible')) {
                if ($('#ui_txtarea_frequency').val() == "") {
                    $('#frequency').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_frequency').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_frequency').is(':visible'))
                objTreatementInfo.Frequency = $('#ui_txtarea_frequency').val().trim();
            if ($('#ui_txt_frequency').is(':visible'))
                objTreatementInfo.Frequency = $('#ui_txt_frequency').val().trim();
        }
        else {
            if ($('#ui_txtarea_frequency').is(':visible'))
                objTreatementInfo.Frequency = $('#ui_txtarea_frequency').val().trim();
            if ($('#ui_txt_frequency').is(':visible'))
                objTreatementInfo.Frequency = $('#ui_txt_frequency').val().trim();
        }

    if ($('#displayAdminRoute').is(':visible'))
        if (sessionStorage.getItem("isadminroute") == "true") {
            if ($('#ui_txt_adminroute').is(':visible')) {
                if ($('#ui_txt_adminroute').val() == "") {
                    $('#adminroute').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_adminroute').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_adminroute').is(':visible')) {
                if ($('#ui_txtarea_adminroute').val() == "") {
                    $('#adminroute').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_adminroute').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_adminroute').is(':visible'))
                objTreatementInfo.AdminRoute = $('#ui_txtarea_adminroute').val().trim();
            if ($('#ui_txt_adminroute').is(':visible'))
                objTreatementInfo.AdminRoute = $('#ui_txt_adminroute').val().trim();
        }
        else {
            if ($('#ui_txtarea_adminroute').is(':visible'))
                objTreatementInfo.AdminRoute = $('#ui_txtarea_adminroute').val().trim();
            if ($('#ui_txt_adminroute').is(':visible'))
                objTreatementInfo.AdminRoute = $('#ui_txt_adminroute').val().trim();
        }

    if ($('#displayGenericacceptable').is(':visible'))
        if (sessionStorage.getItem("isgenericacceptable") == "true") {
            if ($('#ui_ddl_genericacceptable').val() == "") {
                $('#genericacceptable').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_genericacceptable').html() + ' is required</div>');
                retval = false;
            }
            else
                if ($('#ui_ddl_genericacceptable').val() == yes)
                    objTreatementInfo.GenericAcceptable = true;
                else
                    objTreatementInfo.GenericAcceptable = false;
        }
        else
            if ($('#ui_ddl_genericacceptable').val() == yes)
                objTreatementInfo.GenericAcceptable = true;
            else
                objTreatementInfo.GenericAcceptable = false;
}
    //#endregion Treatement Info fields

//#region Save Treatment Information
function SaveTreatmentInformation(mode) {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");
    ValidateTreatmentInfoFields();
    if ($('#ui_txtarea_treatmentarm').val() == "" && $('#ui_txt_treatmentarm').val() == ""
        && $('#ui_txtarea_noofpatientsplanned').val() == null && $('#ui_txt_noofpatientsplanned').val() == ""
        && $('#ui_ddl_typeoftrialdrug').val() == "" && $('#ui_txtarea_compound').val() == ""
        && $('#ui_txt_compound').val() == "" && $('#ui_txtarea_mindosage').val() == ""
        && $('#ui_txt_mindosage').val() == "" && $('#ui_txtarea_maxdosage').val() == ""
        && $('#ui_txt_maxdosage').val() == "" && $('#ui_txtarea_frequency').val() == ""
        && $('#ui_txt_frequency').val() == "" && $('#ui_txtarea_adminroute').val() == ""
        && $('#ui_txt_adminroute').val() == "" && $('#ui_ddl_genericacceptable').val() == "") {
        popupNotification.show("Empty record detected,please enter some values.", "info");
        return false;
    }
    else {
        if (validator.validate() && retval === true
            && (isvalidRegexfortreatmentarm === true && isvalidRegexfornoofpatientsplanned === true
                && isvalidRegexforcompound === true && isvalidRegexformindosage === true
                && isvalidRegexformaxdosage === true && isvalidRegexforfrequency === true
                && isvalidRegexforadminroute === true)) {
            Savedetails(type = 15, objEditstudy = objTreatementInfo, mode = mode);
            $("#TreatmentInformation").data("kendoWindow").close();
            return true;
        }
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    }
}
    //#endregion


function LoadTreatmentInformationAttributes(mode) {
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(treatmentinformationsattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case treatmentarm:
                            Textdetails(response, "displayTreatmentarm", "ui_lbl_treatmentarm", "ui_img_helpTextfortreatmentarm", "istreatmentarm", "ui_txt_treatmentarm", "ui_txtarea_treatmentarm", "ui_lbl_charsleftfortreatmentarm", "regexexprfortreatmentarm", "validationmsgfortreatmentarm", mode);
                            break;
                        case noofpatientsplanned:
                            Textdetails(response, "displayNoofpatientsplanned", "ui_lbl_noofpatientsplanned", "ui_img_helpTextfornoofpatientsplanned", "isnoofpatientsplanned", "ui_txt_noofpatientsplanned", "ui_txtarea_noofpatientsplanned", "ui_lbl_charsleftforisnoofpatientsplanned", "regexexprforisnoofpatientsplanned", "validationmsgforisnoofpatientsplanned", mode);
                            break;
                        case typeoftrialdrug:
                            DropDowndetails(response, "displayTypeoftrialdrug", "ui_lbl_typeoftrialdrug", "ui_img_helpTextfortypeoftrialdrug", "istypeoftrialdrug", mode);
                            break;
                        case compound:
                            Textdetails(response, "displayCompound", "ui_lbl_compound", "ui_img_helpTextforcompound", "iscompound", "ui_txt_compound", "ui_txtarea_compound", "ui_lbl_charsleftforcompound", "regexexprforcompound", "validationmsgforcompound", mode);
                            break;
                        case mindosage:
                            Textdetails(response, "displayMindosage", "ui_lbl_mindosage", "ui_img_helpTextformindosage", "ismindosage", "ui_txt_mindosage", "ui_txtarea_mindosage", "ui_lbl_charsleftformindosage", "regexexprformindosage", "validationmsgformindosage", mode);
                            break;
                        case maxdosage:
                            Textdetails(response, "displayMaxdosage", "ui_lbl_maxdosage", "ui_img_helpTextformaxdosage", "ismaxdosage", "ui_txt_maxdosage", "ui_txtarea_maxdosage", "ui_lbl_charsleftformaxdosage", "regexexprformaxdosage", "validationmsgformaxdosage", mode);
                            break;
                        case frequency:
                            Textdetails(response, "displayFrequency", "ui_lbl_frequency", "ui_img_helpTextforfrequency", "isfrequency", "ui_txt_frequency", "ui_txtarea_frequency", "ui_lbl_charsleftforfrequency", "regexexprforfrequency", "validationmsgforfrequency", mode);
                            break;
                        case adminroute:
                            Textdetails(response, "displayAdminRoute", "ui_lbl_adminroute", "ui_img_helpTextforadminroute", "isadminroute", "ui_txt_adminroute", "ui_txtarea_adminroute", "ui_lbl_charsleftforadminroute", "regexexprforadminroute", "validationmsgforadminroute", mode);
                            break;
                        case genericacceptable:
                            DropDowndetails(response, "displayGenericacceptable", "ui_lbl_genericacceptable", "ui_img_helpTextforgenericacceptable", "isgenericacceptable", mode);
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
    $("#treatmentinformation").on("click", function () {
        $('#treatmentinformationcontents').removeClass('treatmentinformation');
});

$.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(treatmentinformationsattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case treatmentinformation:
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
                                        $("#ui_btn_AddTreatmentInformation").attr("disabled", true);
                                }
                                if (iscreaterestricted == true)
                                    $("#ui_btn_AddTreatmentInformation").attr("disabled", true);
                            }
                            if (iscreaterestricted == true)
                                $("#ui_btn_AddTreatmentInformation").attr("disabled", true);
                            else
                                $("#ui_btn_AddTreatmentInformation").removeAttr("disabled");
                            break;
                        case treatmentarm:
                            $("#ui_dtg_gridTreatmentInformation th[data-field=TreatmentArm]").html(response[i].Name);
                            break;
                        case noofpatientsplanned:
                            $("#ui_dtg_gridTreatmentInformation th[data-field=NoofPatientsPlanned]").html(response[i].Name);
                            break;
                        case typeoftrialdrug:
                            $("#ui_dtg_gridTreatmentInformation th[data-field=TypeofTrialDrug]").html(response[i].Name);
                            break;
                        case compound:
                            $("#ui_dtg_gridTreatmentInformation th[data-field=Compound]").html(response[i].Name);
                            break;
                        case mindosage:
                            $("#ui_dtg_gridTreatmentInformation th[data-field=Mindosage]").html(response[i].Name);
                            break;
                        case mindosage:
                            $("#ui_dtg_gridTreatmentInformation th[data-field=Maxdosage]").html(response[i].Name);
                            break;
                        case frequency:
                            $("#ui_dtg_gridTreatmentInformation th[data-field=Frequency]").html(response[i].Name);
                            break;
                        case adminroute:
                            $("#ui_dtg_gridTreatmentInformation th[data-field=AdminRoute]").html(response[i].Name);
                            break;
                        case genericacceptable:
                            $("#ui_dtg_gridTreatmentInformation th[data-field=GenericAcceptable]").html(response[i].Name);
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