var PatientAccrualDateGrid = $('#ui_dtg_gridPatientAccrual').data('kendoGrid');
var level = null;
var todayDate;
var today = new Date();
var activationDate;
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

function OnPatientAccrualsaveChanges(e) {
    var grid = null;
    switch (e.type) {
        case "update":
            grid = $("#ui_dtg_gridPatientAccrual").data("kendoGrid");
            grid.dataSource.read();
            setTimeout(function () {
                grid = $("#ui_dtg_gridPatientAccrual").data("kendoGrid");
                $('#ui_dtg_gridPatientAccrual').data('kendoGrid').refresh();
                $('#ui_dtg_gridPatientAccrual').nextAll("div.error").remove();
                var totalText = $("#ui_dtg_gridPatientAccrual .k-footer-template").text();
                var datas = grid.dataSource.data();
                var checkCumulativeResult = 0;
                for (var i = 0; i < datas.length; i++) {
                    checkCumulativeResult += parseInt(datas[i].aggregates.CurrentPatients.sum) + parseInt(datas[i].aggregates.WithdrawnPatients.sum) + parseInt(datas[i].aggregates.CompletedPatients.sum);
                    if (checkCumulativeResult === null) {
                        checkCumulativeResult = 0;
                    }
                }
                var cumulativeResult = totalText.split(":");
                if (parseInt(cumulativeResult[1].trim()) !== checkCumulativeResult) {
                    $('#ui_dtg_gridPatientAccrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Total Cumlative Enrollment should be equal to sum of Current Patients, Withdrawn Patients and Completed Patients</div>');

                } else {
                    $('#ui_dtg_gridPatientAccrual').nextAll("div.error").remove();
                }
            }, 1000)
            grid.dataSource.read();
            break;
        case "destroy":
            grid = $("#ui_dtg_gridPatientAccrual").data("kendoGrid");
            grid.dataSource.read();
            break;
    }
}
function StudyDetailsID() {
    return $("#StudyId").val();
}
function OnCreateUpdateModal(e) {
    $('#ui_dtg_gridPatientAccrual').data('kendoGrid').refresh();
}

$(document).ready(function () {
    todayDate = kendo.toString(kendo.parseDate(today), 'MMM dd, yyyy');
    $("#ui_dt_dateofFirstPatientFirstVisit").change(function () {
        $('#firstPatientFirstVisit').next("div.error").remove();
    });
    $("#ui_dt_dateofLastPatientFirstVisit").change(function () {
        $('#LastPatientFirstVisit').next("div.error").remove();
    });
    $("#ui_dt_dateofLastPatientLastTreatment").change(function () {
        $('#LastPatientLastTreatment').next("div.error").remove();
    });
    $("#ui_dt_dateofLastPatientLastVisit").change(function () {
        $('#LastPatientLastVisit').next("div.error").remove();
    });

   
    $.ajax({
        async: false,
        type: "POST",
        url: '/MaintainanceAndMonitoring/GetPatientEnrollmentDetails',
        data: { "studyId": $("#StudyId").val() },
        success: function (result) {
            if (result.Data.length > 0) {
                if (result.Data[result.Data.length - 1].MonthYear !== currentMonth) {
                    createNewMonth();
                }
                else {
                    if (result.Data[0].FirstPatientFirstVisit === null) {
                        $("#CheckEnrolment").hide();
                        $("#LastPatientFirstVisit").hide();
                        $("#LastPatientLastTreatment").hide();
                        $("#LastPatientLastVisit").hide();
                        level = "firstPatientFirstVisit";
                    } else {
                         level = "patientEnrollment";
                        $("#firstPatientFirstVisit *").attr("disabled", "disabled").off('click');
                        $("#CheckEnrolment").show();
                        $("#LastPatientFirstVisit").show();
                        $("#LastPatientLastTreatment").show();
                        $("#LastPatientLastVisit").hide();
                        $("#LastPatientFirstVisit *").attr("disabled", "disabled");
                        $("#LastPatientLastTreatment *").attr("disabled", "disabled");
                        $("#ui_lbl_firstPatientFirstVisit").removeClass("mandatory");
                        $("#ui_dt_dateofFirstPatientFirstVisit").data("kendoDatePicker").value(result.Data[0].FirstPatientFirstVisit);

                        if (result.Data[0].PatientEnrollment === true) {
                            level = "patientEnrollment";
                            $("#ui_checkBox_EnablePatientEnrollment").prop('checked', true);
                            $("#ui_lbl_EnablePatientEnrollment").removeClass("mandatory");
                            $("#CheckEnrolment *").attr("disabled", "disabled");
                            $("#LastPatientFirstVisit").show();
                            $("#LastPatientLastTreatment").show();
                            $("#ui_dt_dateofLastPatientFirstVisit").data("kendoDatePicker").value(result.Data[0].LastPatientFirstVisit);
                            $("#ui_dt_dateofLastPatientLastTreatment").data("kendoDatePicker").value(result.Data[0].LastPatientLastTreatment);
                        }

                        if (result.Data[0].LastPatientFirstVisit !== null) {
                            level = "lpfv";
                            $("#ui_lbl_LastPatientFirstVisit").removeClass("mandatory");
                            $("#LastPatientLastTreatment *").removeAttr('disabled');
                        }

                        if (result.Data[0].LastPatientLastTreatment !== null) {
                            level = "lplt";
                            $("#ui_lbl_LastPatientFirstVisit").removeClass("mandatory");
                            $("#LastPatientLastTreatment *").attr("disabled", "disabled");
                            $("#LastPatientLastVisit").show();
                            PatientAccrualDateGrid.setOptions({ editable: false });
                        }
                    }
                }

            }
            else {
                var PatientAccrualDateGrid = $('#ui_dtg_gridPatientAccrual').data('kendoGrid');
                $("#CheckEnrolment").hide();
                $("#LastPatientFirstVisit").hide();
                $("#LastPatientLastTreatment").hide();
                $("#LastPatientLastVisit").hide();
                level = "firstPatientFirstVisit";
                var data = PatientAccrualDateGrid.dataSource.data();
                var monthYear = null;
                if (data !== null) {
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].MonthYear !== null) {
                            monthYear = data[i].MonthYear;
                        }
                    }
                }
                if (monthYear === null || monthYear !== currentMonth) {
                    createNewMonth();
                }

            }

        }
    });
    $.ajax({
        async: false,
        type: "POST",
        url: '/MaintainanceAndMonitoring/GetActivationDate',
        data: { "studyId": $("#StudyId").val() },
        success: function (result) { 
            activationDate = kendo.toString(kendo.parseDate(new Date(result.Data[0].StudyActivationDate)), 'MMM dd, yyyy');
        }
    });
});

function createNewMonth() {
    var PatientAccrualDateGrid = $('#ui_dtg_gridPatientAccrual').data('kendoGrid');
    objPatientAccrual = new Object();
    objPatientAccrual.StudyId = $("#StudyId").val();
    objPatientAccrual.MonthYear = currentMonth;
    objPatientAccrual.Year = currentYear;
    objPatientAccrual.TreatedPatients = null;
    objPatientAccrual.CurrentPatients = null;
    objPatientAccrual.WithdrawnPatients = null;
    objPatientAccrual.CompletedPatients = null;
    objPatientAccrual.FirstPatientFirstVisit = null;
    objPatientAccrual.PatientEnrollment = null;
    objPatientAccrual.LastPatientFirstVisit = null;
    objPatientAccrual.LastPatientLastTreatment = null;
    objPatientAccrual.LastPatientLastVisit = null;
    objPatientAccrual.IsActive = true;
    objPatientAccrual.IsDeleted = false;
    objPatientAccrual.ANJU_AddedBy = $("#userName").val();
    objPatientAccrual.Anju_AddedDate = null;
    objPatientAccrual.ANJU_ChangedBy = null;
    objPatientAccrual.ANJU_ChangeDate = null;
    $.ajax({
        async: false,
        type: "POST",
        url: '/MaintainanceAndMonitoring/CreatePatientEnrollmentDetails',
        data: { "patientAccrual": objPatientAccrual },
        success: function (result) {
            PatientAccrualDateGrid.dataSource.read();
        }
    });
}

$("#btn-Submit").click(function () {
    $('#ui_dtg_gridPatientAccrual').nextAll("div.error").remove();
    $("#ui_dtg_gridPatientAccrual").data("kendoGrid").refresh();
    var totalText = $("#ui_dtg_gridPatientAccrual .k-footer-template").text();
    var grid = $("#ui_dtg_gridPatientAccrual").data("kendoGrid");
    var datas = grid.dataSource.data();
    var lastItem = datas[datas.length - 1].items.length - 1;
    var checkCumulativeResult = 0;

    for (var i = 0; i < datas.length; i++) {
        checkCumulativeResult += parseInt(datas[i].aggregates.CurrentPatients.sum) + parseInt(datas[i].aggregates.WithdrawnPatients.sum) + parseInt(datas[i].aggregates.CompletedPatients.sum);
        if (checkCumulativeResult === null) {
            checkCumulativeResult = 0;
        }
    }

    if (datas[datas.length - 1].items[lastItem].CurrentPatients > 0 && $("#ui_dt_dateofLastPatientLastTreatment").val() !== "month day, year" && $("#ui_dt_dateofLastPatientLastTreatment").val() !== "") {
        $('#ui_dtg_gridPatientAccrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span> Current Patients for the current months should be equal to zero</div>');
        return false;
    }
    var cumulativeResult = totalText.split(":");
    if (parseInt(cumulativeResult[1].trim()) !== checkCumulativeResult) {
        $('#ui_dtg_gridPatientAccrual').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Total Cumlative Enrollment should be equal to sum of Current Patients, Withdrawn Patients and Completed Patients</div>');

    } else {
        var assignStudyId = parseInt($("#StudyId").val());
        var todayDate = kendo.toString(kendo.parseDate(new Date()), 'MMM dd, yyyy');
        var FirstPatientFirstVisit = kendo.toString(kendo.parseDate(new Date($("#ui_dt_dateofFirstPatientFirstVisit").val())), 'MMM dd, yyyy');
        var LastPatientFirstVisit = kendo.toString(kendo.parseDate(new Date($("#ui_dt_dateofLastPatientFirstVisit").val())), 'MMM dd, yyyy');
        var LastPatientLastTreatment = kendo.toString(kendo.parseDate(new Date($("#ui_dt_dateofLastPatientLastTreatment").val())), 'MMM dd, yyyy');
        var LastPatientLastVisit = kendo.toString(kendo.parseDate(new Date($("#ui_dt_dateofLastPatientLastVisit").val())), 'MMM dd, yyyy');
        $('.error').remove();
        if (level === "firstPatientFirstVisit") {
            if (activationDate >= FirstPatientFirstVisit) {
                $('#firstPatientFirstVisit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Date of first patient first visit cannot be less than date of activation</div>');
                retval = false;
            }
            else if (todayDate < FirstPatientFirstVisit) {
                $('#firstPatientFirstVisit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please enter a valid date</div>');
                retval = false;
            } else {               
                objPatientAccrual = new Object();
                objPatientAccrual.FirstPatientFirstVisit = $("#ui_dt_dateofFirstPatientFirstVisit").val();
                objPatientAccrual.PatientEnrollment = null;
                objPatientAccrual.LastPatientFirstVisit = null;
                objPatientAccrual.LastPatientLastTreatment = null;
                objPatientAccrual.LastPatientLastVisit = null;
                objPatientAccrual.IsActive = true;
                objPatientAccrual.IsDeleted = false;
                objPatientAccrual.ANJU_AddedBy = null;
                objPatientAccrual.Anju_AddedDate = null;
                objPatientAccrual.ANJU_ChangedBy = $("#userName").val();
                objPatientAccrual.ANJU_ChangeDate = null;
                $.ajax({
                    async: false,
                    type: "POST",
                    url: '/MaintainanceAndMonitoring/UpdatePatientEnrollmentDates',
                    data: { "patientAccrual": objPatientAccrual, "studyId": assignStudyId },
                    success: function (result) {
                        window.close();
                    }
                });
            }

        }
        else if (level === "patientEnrollment") {
            if (todayDate < LastPatientFirstVisit) {
                $('#LastPatientFirstVisit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please enter a valid date</div>');
                retval = false;
            } else if (LastPatientFirstVisit < FirstPatientFirstVisit) {
                $('#LastPatientFirstVisit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Date of last patient first visit cannot be less than date of first patient first visit</div>');
                retval = false;
            } else if (LastPatientLastTreatment < LastPatientFirstVisit) {
                $('#LastPatientLastTreatment').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Date of last patient first treatment cannot be less than date of first patient first visit</div>');
                retval = false;
            }  else if ($("#ui_dt_dateofLastPatientLastTreatment").val() !== "month day, year" && $("#ui_dt_dateofLastPatientLastTreatment").val() !== "") {
                if (LastPatientLastTreatment > todayDate) {
                    $('#LastPatientLastTreatment').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please enter a valid date</div>');
                    retval = false;
                }
                else
                    UpdatePatientInfo(assignStudyId);
            }
            else {  
                UpdatePatientInfo(assignStudyId);
            }
        }
        else if (level === "lpfv") {
            if (todayDate < LastPatientLastTreatment && LastPatientLastTreatment !== "M NaN, 0NaN") {
                $('#LastPatientLastTreatment').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please enter a valid date</div>');
                retval = false;
            } else if (LastPatientLastTreatment < FirstPatientFirstVisit) {
                $('#LastPatientLastTreatment').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Date of last patient first visit cannot be less than date of first patient first visit</div>');
                retval = false;
            } else if (LastPatientLastTreatment < LastPatientFirstVisit) {
                $('#LastPatientLastTreatment').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Date of last patient first treatment cannot be less than date of first patient first visit</div>');
                retval = false;
            }          
            else {
                
                objPatientAccrual = new Object();
                objPatientAccrual.FirstPatientFirstVisit = $("#ui_dt_dateofFirstPatientFirstVisit").val();
                objPatientAccrual.PatientEnrollment = true;
                objPatientAccrual.LastPatientFirstVisit = $("#ui_dt_dateofLastPatientFirstVisit").val();
                objPatientAccrual.LastPatientLastTreatment = $("#ui_dt_dateofLastPatientLastTreatment").val();
                objPatientAccrual.LastPatientLastVisit = null;
                objPatientAccrual.IsActive = true;
                objPatientAccrual.IsDeleted = false;
                objPatientAccrual.ANJU_AddedBy = null;
                objPatientAccrual.Anju_AddedDate = null;
                objPatientAccrual.ANJU_ChangedBy = $("#userName").val();
                objPatientAccrual.ANJU_ChangeDate = null;
                $.ajax({
                    async: false,
                    type: "POST",
                    url: '/MaintainanceAndMonitoring/UpdatePatientEnrollmentDates',
                    data: { "patientAccrual": objPatientAccrual, "studyId": assignStudyId },
                    success: function (result) {
                        window.close();
                    }
                });
            }
        }
        else if (level === "lplt") {
            if (todayDate < LastPatientLastVisit) {
                $('#LastPatientLastVisit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please enter a valid date</div>');
                retval = false;
            } else if (FirstPatientFirstVisit > LastPatientLastVisit) {
                $('#LastPatientLastVisit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Date of last patient Last visit cannot be less than date of first patient first visit</div>');
                retval = false;
            } else if (LastPatientLastVisit < LastPatientFirstVisit) {
                $('#LastPatientLastVisit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Date of last patient last visit cannot be less than date of last patient first visit</div>');
                retval = false;
            } else if (LastPatientLastTreatment > LastPatientLastVisit) {
                $('#LastPatientLastVisit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Date of last patient last visit cannot be less than date of last patient last treatment</div>');
                retval = false;
            } else {               
                objPatientAccrual = new Object();
                objPatientAccrual.FirstPatientFirstVisit = $("#ui_dt_dateofFirstPatientFirstVisit").val();
                objPatientAccrual.PatientEnrollment = true;
                objPatientAccrual.LastPatientFirstVisit = $("#ui_dt_dateofLastPatientFirstVisit").val();
                objPatientAccrual.LastPatientLastTreatment = $("#ui_dt_dateofLastPatientLastTreatment").val();
                objPatientAccrual.LastPatientLastVisit = $("#ui_dt_dateofLastPatientLastVisit").val();
                objPatientAccrual.IsActive = true;
                objPatientAccrual.IsDeleted = false;
                objPatientAccrual.ANJU_AddedBy = null;
                objPatientAccrual.Anju_AddedDate = null;
                objPatientAccrual.ANJU_ChangedBy = $("#userName").val();
                objPatientAccrual.ANJU_ChangeDate = null;
                $.ajax({
                    async: false,
                    type: "POST",
                    url: '/MaintainanceAndMonitoring/UpdatePatientEnrollmentDates',
                    data: { "patientAccrual": objPatientAccrual, "studyId": assignStudyId },
                    success: function (result) {
                        var lsmailParameter = new Array();
                        var appUrl = $(location)[0].origin;
                        var StudyURL = "<a href='" + appUrl + "'> Navigate</a>";
                        lsmailParameter.push($('#LogedinUserName').val());
                        lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + TitleofTrial + "</a>");
                        lsmailParameter.push(StudyURL);
                        $.ajax({
                            type: "POST",
                            url: "/Common/SendEmail/",
                            cache: false,
                            data: { "mailMessage": "Safety Reporting confirmation email", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $('#txtUserName').val(), "ccMail": " " },
                            dataType: "json",
                            success: function (results) {
                                popupNotification.show('Email Sent Successfully', "success");
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                popupNotification.show('Sending Email Failed', "error");
                            }

                        });
                        window.close();
                    }
                });
            }

        }
        else if (level === "lastPatientLastVisit") {
            if (todayDate < LastPatientLastVisit) {
                $('#LastPatientLastVisit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please enter a valid date</div>');
                retval = false;
            } else if (LastPatientLastVisit < FirstPatientFirstVisit) {
                $('#LastPatientLastVisit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Date of last patient Last visit cannot be less than date of first patient first visit</div>');
                retval = false;
            } else if (LastPatientLastVisit < LastPatientFirstVisit) {
                $('#LastPatientLastVisit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Date of last patient last visit cannot be less than date of last patient first visit</div>');
                retval = false;
            } else if (LastPatientLastVisit < LastPatientLastTreatment) {
                $('#LastPatientLastTreatment').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Date of last patient last visit cannot be less than date of last patient last treatment</div>');
                retval = false;
            } else {
                objPatientAccrual = new Object();
                objPatientAccrual.FirstPatientFirstVisit = $("#ui_dt_dateofFirstPatientFirstVisit").val();
                objPatientAccrual.PatientEnrollment = true;
                objPatientAccrual.LastPatientFirstVisit = $("#ui_dt_dateofLastPatientFirstVisit").val();
                objPatientAccrual.LastPatientLastTreatment = $("#ui_dt_dateofLastPatientLastTreatment").val();
                objPatientAccrual.LastPatientLastVisit = null;
                objPatientAccrual.IsActive = true;
                objPatientAccrual.IsDeleted = false;
                objPatientAccrual.ANJU_AddedBy = null;
                objPatientAccrual.Anju_AddedDate = null;
                objPatientAccrual.ANJU_ChangedBy = $("#userName").val();
                objPatientAccrual.ANJU_ChangeDate = null;
                $.ajax({
                    async: false,
                    type: "POST",
                    url: '/MaintainanceAndMonitoring/UpdatePatientEnrollmentDates',
                    data: { "patientAccrual": objPatientAccrual, "studyId": assignStudyId },
                    success: function (result) {
                        window.close();
                    }
                });
            }
        }
    }



});

function UpdatePatientInfo(assignStudyId) {

    objPatientAccrual = new Object();
    objPatientAccrual.FirstPatientFirstVisit = $("#ui_dt_dateofFirstPatientFirstVisit").val();
    objPatientAccrual.PatientEnrollment = true;
    objPatientAccrual.LastPatientFirstVisit = $("#ui_dt_dateofLastPatientFirstVisit").val();
    objPatientAccrual.LastPatientLastTreatment = $("#ui_dt_dateofLastPatientLastTreatment").val();
    objPatientAccrual.LastPatientLastVisit = null;
    objPatientAccrual.IsActive = true;
    objPatientAccrual.IsDeleted = false;
    objPatientAccrual.ANJU_AddedBy = null;
    objPatientAccrual.Anju_AddedDate = null;
    objPatientAccrual.ANJU_ChangedBy = $("#userName").val();
    objPatientAccrual.ANJU_ChangeDate = null;
    $.ajax({
        async: false,
        type: "POST",
        url: '/MaintainanceAndMonitoring/UpdatePatientEnrollmentDates',
        data: { "patientAccrual": objPatientAccrual, "studyId": assignStudyId },
        success: function (result) {
            window.close();
        }
    });

}
var isChecked;

$("#ui_checkBox_EnablePatientEnrollment").click(function () {  
    enrollFlag = false;
    isChecked = $("#ui_checkBox_EnablePatientEnrollment").prop('checked');
    if (isChecked === true) {
        $('#enrollmentCompleteModal').modal('show');       
    } else {         
        $("#LastPatientFirstVisit *").attr("disabled", "disabled");
        $("#LastPatientLastTreatment *").attr("disabled", "disabled");
    }
});
var enrollFlag = false;
$('#ui_btn_ok').click(function () {
    $('#enrollmentCompleteModal').modal('hide');
    level = "patientEnrollment";
    $("#LastPatientFirstVisit *").removeAttr('disabled');
    $("#LastPatientLastTreatment *").removeAttr('disabled');
    enrollFlag = true;
})
$('#enrollmentCompleteModal').on('hidden.bs.modal',  function () {        
        if (enrollFlag === false) {
            $("#ui_checkBox_EnablePatientEnrollment").prop('checked', false);
        } else {
            $("#ui_checkBox_EnablePatientEnrollment").prop('checked', true);
        }
    })

function onCancel() {
    window.close();
}
function onEdit(e) {
    if (e.model.MonthYear !== currentMonth) {
        $('#ui_dtg_gridPatientAccrual').data("kendoGrid").closeCell();
    }
}