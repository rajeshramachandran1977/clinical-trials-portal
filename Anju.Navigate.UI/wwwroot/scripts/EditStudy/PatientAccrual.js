//#region Template declarations
var patientaccrualtemplate = kendo.template($("#patientaccrualtemplate").html());
var added = false;
var modes = null;
var restrictMonth = new Array();
var uneditableMonth = null;
var treatedThisMonth = 0;
var compltedPatients = 0;
var withdrawnPateints = 0;
var currentPatients = 0;
//#endregion

function OnDataBoundforPatientAccrual() {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(patientaccrualattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                var grid = $("#ui_dtg_Patientaccrual").data("kendoGrid");
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
                    grid.hideColumn(8);                    
                else 
                    grid.showColumn(8);
                    
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
                        grid.hideColumn(7);
                    return false;
                }
                else {
                    grid.showColumn(7);
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
function deletePatientaccrual(e) {
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
    var grid = $("#ui_dtg_Patientaccrual").data("kendoGrid"); //Get the grid from which the pop-up is coming
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

function addPatientaccrual() {
    modes = "add";
    var wnd = $("#Patientaccrual").data("kendoWindow");
    wnd.content(patientaccrualtemplate(kendo.template($("#patientaccrualtemplate").html())));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    $("#ui_dt_monthandyearofaccrual").attr("readonly", true);

    LoadPatientAccrualAttributes("Create");

    CheckcharacterLength();

    $("#monthandyearofaccrual,#noofnewpatientstreatedthismonth,#totalnoofpatientscurrentlyontreatment, \
            #totalnoofpatientswithdrawnfromtreatment,#totalnoofpatientscompletedtreatment").on("keyup", function (e) {
        $(this).nextAll("div.error").remove();
    })

    //#region Save Milestones Actions(Add mode)
    $("#ui_btnSavepatientaccrual").click(function (e) {
        SavePatientAccrual("Create");
    });
    //#endregion
}

function showPatientaccrual(e) {
    modes = "edit";
    var grid = $("#ui_dtg_Patientaccrual").getKendoGrid();
    var wnd = $("#Patientaccrual").data("kendoWindow");
    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(patientaccrualtemplate(dataItem));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadPatientAccrualAttributes("Edit");

    CheckcharacterLength();

    $("#monthandyearofaccrual,#noofnewpatientstreatedthismonth,#totalnoofpatientscurrentlyontreatment, \
            #totalnoofpatientswithdrawnfromtreatment,#totalnoofpatientscompletedtreatment").on("keyup", function (e) {
        $(this).nextAll("div.error").remove();
    })
    
    //#region Get existing Patient accruals
    $("#ui_num_id").val(dataItem.PatientaccrualId);
    $("#ui_dt_monthandyearofaccrual").data("kendoDatePicker").value(new Date(dataItem.MonthYear));
    $("#ui_num_noofnewpatientstreatedthismonth").val(dataItem.TreatedPatients);
    $("#ui_num_totalnoofpatientscurrentlyontreatment").val(dataItem.CurrentPatients);
    $("#ui_num_totalnoofpatientswithdrawnfromtreatment").val(dataItem.WithdrawnPatients);
    $("#ui_num_totalnoofpatientscompletedtreatment").val(dataItem.CompletedPatients);
    restrictMonth = dataItem.MonthYear.split('-');
    uneditableMonth = restrictMonth[0] + " " + restrictMonth[1];
    //#endregion

    //#region Save Milestones Actions(Add mode)
    $("#ui_btnSavepatientaccrual").click(function (e) {
        SavePatientAccrual("Edit");
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

//#region Patient Accrual fields
function ValidatePatientAccrualFields() {
    added = false;
    $(".error").remove();
    retval = true;
    objPatientAccrual = new Object();
    objPatientAccrual.StudyId = $('#StudyId').val();
    objPatientAccrual.PatientaccrualId = $('#ui_num_id').val();
    var today = new Date($('#ui_dt_monthandyearofaccrual').val()); 
    var currentMonthValue = today.getMonth();
    var currentYear = today.getFullYear();
    var currentMonth;
    switch (currentMonthValue) {
        case 0: currentMonth = "Jan-" + currentYear.toString();
            break;
        case 1: currentMonth = "Feb-" + currentYear.toString();
            break;
        case 2: currentMonth = "Mar-" + currentYear.toString();
            break;
        case 3: currentMonth = "Apr-" + currentYear.toString();
            break;
        case 4: currentMonth = "May-" + currentYear.toString();
            break;
        case 5: currentMonth = "Jun-" + currentYear.toString();
            break;
        case 6: currentMonth = "Jul-" + currentYear.toString();
            break;
        case 7: currentMonth = "Aug-" + currentYear.toString();
            break;
        case 8: currentMonth = "Sep-" + currentYear.toString();
            break;
        case 9: currentMonth = "Oct-" + currentYear.toString();
            break;
        case 10: currentMonth = "Nov-" + currentYear.toString();
            break;
        case 11: currentMonth = "Dec-" + currentYear.toString();
            break;
    }



    if ($('#displayMonthandYearofaccrual').is(':visible'))
        if (sessionStorage.getItem("ismonthandyearofaccrual") == "true") {
            if ($('#ui_dt_monthandyearofaccrual').val() == "") {
                $('#monthandyearofaccrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_monthandyearofaccrual').html() + ' is required</div>');
                retval = false;
            } else {
                
               
                if ($('#ui_dt_monthandyearofaccrual').val() == "")
                    objPatientAccrual.MonthYear = null;
                else {
                    added = true;
                    if (modes === "add") {
                        for (var i = 0; i < monthYearList.length; i++) {
                            if (monthYearList[i] == currentMonth) {
                                $(".error").remove();
                                $('#monthandyearofaccrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Month-Year value already exists.</div>');
                                retval = false;
                            }
                            
                            var lesserMonth = new Date(monthYearList[i]);
                            if (lesserMonth.getFullYear().toString() + "-" + lesserMonth.getMonth().toString() > currentYear + "-" + currentMonthValue) {
                                $(".error").remove();
                                $('#monthandyearofaccrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Can not enter lesser value than available months in list.</div>');
                                retval = false;
                            }

                        }
                        var compareFutureDate = new Date();
                        var futureMonthValue = compareFutureDate.getMonth().toString();
                        futureMonthValue = futureMonthValue.length > 1 ? futureMonthValue : '0' + futureMonthValue;
                        var compareCurrentMonth = currentMonthValue.toString();
                        compareCurrentMonth = compareCurrentMonth.length > 1 ? compareCurrentMonth : '0' + compareCurrentMonth;
                        var futureYearValue = compareFutureDate.getFullYear();
                        if ($('#ui_dt_monthandyearofaccrual').val() == "month year") {
                            $('#monthandyearofaccrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please enter a valid month.</div>');
                            retval = false;
                        }
                        else if (futureYearValue.toString() + "-" + futureMonthValue < currentYear.toString() + "-" + compareCurrentMonth) {
                            $('#monthandyearofaccrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Can not enter Future Month Value.</div>');
                            retval = false;
                        }

                    }
                    else {
                        if ($('#ui_dt_monthandyearofaccrual').val() != uneditableMonth) {
                            $('#monthandyearofaccrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Do not update month please set date back to ' + uneditableMonth + '.</div>');
                            retval = false;
                        }
                    }
                    objPatientAccrual.Year = currentYear;
                    objPatientAccrual.MonthYear = currentMonth;
                }
             }
        }
        else {
            
            if ($('#ui_dt_monthandyearofaccrual').val() == "")
                objPatientAccrual.MonthYear = null;
            else { 
                added = true;
                if (modes === "add") {   
                    
                    for (var i = 0; i < monthYearList.length; i++) {
                        if (monthYearList[i] == currentMonth) {
                            $(".error").remove();
                            $('#monthandyearofaccrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Month-Year value already exists.</div>');
                            retval = false;
                        }
                        var lesserMonth = new Date(monthYearList[i]);
                        if (lesserMonth.getFullYear().toString() + "-" + lesserMonth.getMonth().toString() > currentYear + "-" + currentMonthValue) {
                            $(".error").remove();
                            $('#monthandyearofaccrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Can not enter lesser value than available months in list.</div>');
                            retval = false;
                        } 

                    }
                    var compareFutureDate = new Date();
                    var futureMonthValue = compareFutureDate.getMonth().toString();
                    futureMonthValue = futureMonthValue.length > 1 ? futureMonthValue : '0' + futureMonthValue;
                    var compareCurrentMonth = currentMonthValue.toString();
                    compareCurrentMonth = compareCurrentMonth.length > 1 ? compareCurrentMonth : '0' + compareCurrentMonth;
                    var futureYearValue = compareFutureDate.getFullYear();
                    if ($('#ui_dt_monthandyearofaccrual').val() == "month year") {
                        $('#monthandyearofaccrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please enter a valid month.</div>');
                        retval = false;
                    }
                    else if (futureYearValue.toString() + "-" + futureMonthValue < currentYear.toString() + "-" + compareCurrentMonth) {
                        $('#monthandyearofaccrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Can not enter Future Month Value.</div>');
                        retval = false;
                    }

                }
                else {
                    if ($('#ui_dt_monthandyearofaccrual').val() != uneditableMonth) {
                        $('#monthandyearofaccrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Do not update month please set date back to ' + uneditableMonth + '.</div>');
                        retval = false;
                    }
                }
                objPatientAccrual.Year = currentYear;
                objPatientAccrual.MonthYear = currentMonth;
            }
               
        }


    if ($('#displayNoofnewpatientstreatedthismonth').is(':visible'))
        if (sessionStorage.getItem("isnoofnewpatientstreatedthismonth") == "true") {
            if ($('#ui_num_noofnewpatientstreatedthismonth').is(':visible')) {
                if ($('#ui_num_noofnewpatientstreatedthismonth').val() == "") {
                    $('#noofnewpatientstreatedthismonth').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_noofnewpatientstreatedthismonth').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_num_noofnewpatientstreatedthismonth').is(':visible'))
                objPatientAccrual.TreatedPatients = $('#ui_num_noofnewpatientstreatedthismonth').val().trim();
        }
        else {
            if ($('#ui_num_noofnewpatientstreatedthismonth').is(':visible'))
                objPatientAccrual.TreatedPatients = $('#ui_num_noofnewpatientstreatedthismonth').val().trim();
        }

    if ($('#displayTotalnoofpatientscurrentlyontreatment').is(':visible'))
        if (sessionStorage.getItem("istotalnoofpatientscurrentlyontreatment") == "true") {
            if ($('#ui_num_totalnoofpatientscurrentlyontreatment').is(':visible')) {
                if ($('#ui_num_totalnoofpatientscurrentlyontreatment').val() == "") {
                    $('#totalnoofpatientscurrentlyontreatment').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_totalnoofpatientscurrentlyontreatment').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_num_totalnoofpatientscurrentlyontreatment').is(':visible'))
                objPatientAccrual.CurrentPatients = $('#ui_num_totalnoofpatientscurrentlyontreatment').val().trim();
        }
        else {
            if ($('#ui_num_totalnoofpatientscurrentlyontreatment').is(':visible'))
                objPatientAccrual.CurrentPatients = $('#ui_num_totalnoofpatientscurrentlyontreatment').val().trim();
        }


    if ($('#displayTotalnoofpatientswithdrawnfromtreatment').is(':visible'))
        if (sessionStorage.getItem("istotalnoofpatientswithdrawnfromtreatment") == "true") {
            if ($('#ui_num_totalnoofpatientswithdrawnfromtreatment').is(':visible')) {
                if ($('#ui_num_totalnoofpatientswithdrawnfromtreatment').val() == "") {
                    $('#totalnoofpatientswithdrawnfromtreatment').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_totalnoofpatientswithdrawnfromtreatment').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_num_totalnoofpatientswithdrawnfromtreatment').is(':visible'))
                objPatientAccrual.WithdrawnPatients = $('#ui_num_totalnoofpatientswithdrawnfromtreatment').val().trim();
        }
        else {
            if ($('#ui_num_totalnoofpatientswithdrawnfromtreatment').is(':visible'))
                objPatientAccrual.WithdrawnPatients = $('#ui_num_totalnoofpatientswithdrawnfromtreatment').val().trim();
        }

    if ($('#displayTotalnoofpatientscompletedtreatment').is(':visible'))
        if (sessionStorage.getItem("istotalnoofpatientscompletedtreatment") == "true") {
            if ($('#ui_num_totalnoofpatientscompletedtreatment').is(':visible')) {
                if ($('#ui_num_totalnoofpatientscompletedtreatment').val() == "") {
                    $('#totalnoofpatientscompletedtreatment').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_totalnoofpatientscompletedtreatment').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_num_totalnoofpatientscompletedtreatment').is(':visible'))
                objPatientAccrual.CompletedPatients = $('#ui_num_totalnoofpatientscompletedtreatment').val().trim();
        }
        else {
            if ($('#ui_num_totalnoofpatientscompletedtreatment').is(':visible'))
                objPatientAccrual.CompletedPatients = $('#ui_num_totalnoofpatientscompletedtreatment').val().trim();
        }
    
    if ($('#ui_num_noofnewpatientstreatedthismonth').val() != "") {
        treatedThisMonth = parseInt($('#ui_num_noofnewpatientstreatedthismonth').val());
    }
    if ($('#ui_num_totalnoofpatientscompletedtreatment').val() != "") {
        compltedPatients = parseInt($('#ui_num_totalnoofpatientscompletedtreatment').val());
    }
    if ($('#ui_num_totalnoofpatientswithdrawnfromtreatment').val() != "") {
        withdrawnPateints = parseInt($('#ui_num_totalnoofpatientswithdrawnfromtreatment').val());
    }
    if ($('#ui_num_totalnoofpatientscurrentlyontreatment').val() != "") {
        currentPatients = parseInt($('#ui_num_totalnoofpatientscurrentlyontreatment').val());
    }
    if (treatedThisMonth != compltedPatients + withdrawnPateints + currentPatients) {
        $('#totalnoofpatientscompletedtreatment').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Total number of patients treated this month should be equal to sum of Current Patients, Withdrawn Patients and Completed Patients</div>');
        retval = false;
    }


}
//#endregion

function SavePatientAccrual(mode) {
    var validator = $("#ui_dtg_Patientaccrual").kendoValidator().data("kendoValidator");
    ValidatePatientAccrualFields();
    if (($('#ui_dt_monthandyearofaccrual').val() == "" || $('#ui_dt_monthandyearofaccrual').val() == "month year") && $('#ui_num_noofnewpatientstreatedthismonth').val() == "" &&
        $('#ui_num_totalnoofpatientscurrentlyontreatment').val() == "" && $('#ui_num_totalnoofpatientswithdrawnfromtreatment').val() == "" &&
        $('#ui_num_totalnoofpatientscompletedtreatment').val() == "") {
        popupNotification.show("Empty record detected,please enter some values.", "info");
        return false;
    } else {
        if (validator.validate() && retval === true) {
            Savedetails(type = 24, objEditstudy = objPatientAccrual);
            if (added)
            location.reload();
        }
           
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    }
}

function LoadPatientAccrualAttributes(mode) {
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(patientaccrualattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {                       
                        case monthandyearofaccrual:
                            DropDowndetails(response, "displayMonthandYearofaccrual", "ui_lbl_monthandyearofaccrual", "ui_img_helpTextformonthandyearofaccrual", "ismonthandyearofaccrual",mode);
                            break;
                        case numberofnewpatientstreatedthismonth:
                            NumberFielddetails(response, "displayNoofnewpatientstreatedthismonth", "ui_lbl_noofnewpatientstreatedthismonth", "ui_img_helpTextfornoofnewpatientstreatedthismonth", "isnoofnewpatientstreatedthismonth", "ui_num_noofnewpatientstreatedthismonth", mode);
                            break;
                        case totalnoofpatientscurrentlyontreatment:
                            NumberFielddetails(response, "displayTotalnoofpatientscurrentlyontreatment", "ui_lbl_totalnoofpatientscurrentlyontreatment", "ui_img_helpTextfortotalnoofpatientscurrentlyontreatment", "istotalnoofpatientscurrentlyontreatment", "ui_num_totalnoofpatientscurrentlyontreatment", mode);
                            break;
                        case totalnoofpatientswithdrawnfromtreatment:
                            NumberFielddetails(response, "displayTotalnoofpatientswithdrawnfromtreatment", "ui_lbl_totalnoofpatientswithdrawnfromtreatment", "ui_img_helpTextfortotalnoofpatientswithdrawnfromtreatment", "istotalnoofpatientswithdrawnfromtreatment", "ui_num_totalnoofpatientswithdrawnfromtreatment",mode);
                            break;
                        case totalnoofpatientscompletedtreatment:
                            NumberFielddetails(response, "displayTotalnoofpatientscompletedtreatment", "ui_lbl_totalnoofpatientscompletedtreatment", "ui_img_helpTextfortotalnoofpatientscompletedtreatment", "istotalnoofpatientscompletedtreatment", "ui_num_totalnoofpatientscompletedtreatment", mode);
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


$("#patientaccrual").on("click", function () {
    $('#patientaccrualdetails').removeClass('patientaccrualdetails');
});

var monthYearList = new Array();

$(document).ready(function () {
    //LoadPatientAccrualAttributes();
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(patientaccrualattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case patientaccrual:
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
                                        $("#ui_btn_AddPatientAccrual").attr("disabled", true);
                                }
                                if (iscreaterestricted == true)
                                    $("#ui_btn_AddPatientAccrual").attr("disabled", true);
                            }
                            if (iscreaterestricted == true)
                                $("#ui_btn_AddPatientAccrual").attr("disabled", true);
                            else
                                $("#ui_btn_AddPatientAccrual").removeAttr("disabled");
                            break;
                        case monthandyearofaccrual:
                            $("#ui_dtg_Patientaccrual th[data-field=MonthYear]").html(response[i].Name);
                            break;
                        case numberofnewpatientstreatedthismonth:
                            $("#ui_dtg_Patientaccrual th[data-field=TreatedPatients]").html(response[i].Name);
                            break;
                        case totalnoofpatientscurrentlyontreatment:
                            $("#ui_dtg_Patientaccrual th[data-field=CurrentPatients]").html(response[i].Name);
                            break;
                        case totalnoofpatientswithdrawnfromtreatment:
                            $("#ui_dtg_Patientaccrual th[data-field=WithdrawnPatients]").html(response[i].Name);
                            break;
                        case totalnoofpatientscompletedtreatment:
                            $("#ui_dtg_Patientaccrual th[data-field=CompletedPatients]").html(response[i].Name);
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
    $.ajax({
        async: false,
        type: "POST",
        url: '/MaintainanceAndMonitoring/GetPatientEnrollmentDetails',
        data: { "studyId": $("#StudyId").val() },
        success: function (result) {
            for (var i = 0; i < result.Data.length; i++) {
                monthYearList[i] = result.Data[i].MonthYear;
            }

        }
    });
});
