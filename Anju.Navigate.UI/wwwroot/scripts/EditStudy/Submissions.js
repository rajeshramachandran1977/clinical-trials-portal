
function ValidateSubmissonsFields() {    
    $(".error").remove();
    retval = true;   
    objSubmissons = new Object();
    objSubmissons.StudyId = $('#StudyId').val();
    objSubmissons.SubmissionId = $('#ui_num_submissionsid').val();

    if ($('#displaySubmissiontype').is(':visible'))
        if (sessionStorage.getItem("issubmissiontype") == "true") {

            if ($('#ui_ddl_submissiontype').val() == "") {
                $('#submissiontype').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_submissiontype').html() + ' is required</div>');
                retval = false;
            }
            else
                if ($('#ui_ddl_submissiontype').val() == "Select")
                    objSubmissons.Submissiontype = null;
                else
                    objSubmissons.Submissiontype = $('#ui_ddl_submissiontype').val();
        }
        else
            if ($('#ui_ddl_submissiontype').val() == "Select")
                objSubmissons.Submissiontype = null;
            else
                objSubmissons.Submissiontype = $('#ui_ddl_submissiontype').val();

    if ($('#displayVersion').is(':visible'))
        if (sessionStorage.getItem("isversion") == "true") {
            if ($('#ui_txt_version').is(':visible')) {
                if ($('#ui_txt_version').val() == "") {
                    $('#version').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_version').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_version').is(':visible')) {
                if ($('#ui_txtarea_version').val() == "") {
                    $('#version').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_version').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_version').is(':visible'))
                objSubmissons.Submissionversion = $('#ui_txtarea_version').val().trim();
            if ($('#ui_txt_version').is(':visible'))
                objSubmissons.Submissionversion = $('#ui_txt_version').val().trim();
        }
        else {
            if ($('#ui_txtarea_version').is(':visible'))
                objSubmissons.Submissionversion = $('#ui_txtarea_version').val().trim();
            if ($('#ui_txt_version').is(':visible'))
                objSubmissons.Submissionversion = $('#ui_txt_version').val().trim();
        }

    if ($('#displayStudyeligibilitydate').is(':visible'))
        if (sessionStorage.getItem("iseligibilitydate") == "true") {

            if ($('#ui_dt_studyeligibilitydate').val() == "month day, year") {
                $('#studyeligibilitydate').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_studyeligibilitydate').html() + ' is required</div>');
                retval = false;
            }
            else
                if ($('#ui_dt_studyeligibilitydate').val() == "month day, year")
                    objSubmissons.Studyeligibilitydate = null;
                else
                    objSubmissons.Studyeligibilitydate = $('#ui_dt_studyeligibilitydate').val();
        }
        else
            if ($('#ui_dt_studyeligibilitydate').val() == "month day, year")
                objSubmissons.Studyeligibilitydate = null;
            else
                objSubmissons.Studyeligibilitydate = $('#ui_dt_studyeligibilitydate').val();

    if ($('#displaySubmissiondate').is(':visible'))
        if (sessionStorage.getItem("issubmissiondate") == "true") {

            if ($('#ui_dt_submissiondate').val() == "month day, year") {
                $('#submissiondate').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_submissiondate').html() + ' is required</div>');
                retval = false;
            }
            else
                if ($('#ui_dt_submissiondate').val() == "month day, year")
                    objSubmissons.Submissiondate = null;
                else
                    objSubmissons.Submissiondate = $('#ui_dt_submissiondate').val();
        }
        else
            if ($('#ui_dt_submissiondate').val() == "month day, year")
                objSubmissons.Submissiondate = null;
            else
                objSubmissons.Submissiondate = $('#ui_dt_submissiondate').val();

    if ($('#displaySubmissiondetails').is(':visible'))
        if (sessionStorage.getItem("issubmissiondetails") == "true") {

            if ($("#uploadsubmissiondetailsaddmode").closest(".k-upload").find(".k-file").length <= 0) {
                $('#submissiondetails').after('<div class="error errorBackground"></span>' + $('#ui_lbl_documentname').html() + ' is required</div>');
                retval = false;
            }
            else {
                var objFile = $("#uploadsubmissiondetailsaddmode").data("kendoUpload");
                var filename = objFile.getFiles();
                objSubmissons.DocumentExtension = $('#DocumentExtension').val();
                objSubmissons.DocumentSize = $('#DocumentSize').val(); 
            }
        }
        else
            if ($("#uploadsubmissiondetailsaddmode").closest(".k-upload").find(".k-file").length <= 0 && retval === true)
                objSubmissons.Submissiondetails = null;
            else {
                 objFile = $("#uploadsubmissiondetailsaddmode").data("kendoUpload");
                 filename = objFile.getFiles();
                objSubmissons.Submissiondetails = filename[0].name;
                objSubmissons.DocumentExtension = $('#DocumentExtension').val();
                objSubmissons.DocumentSize = $('#DocumentSize').val(); 
                $.ajax({
                    async: false,
                    type: "GET",
                    url: "/TaskWorkFlow/IsDocumentNameIsUnique",
                    data: { "documentsName": objSubmissons.Submissiondetails, "studyId": $('#StudyId').val() },
                    success: function (result) {
                        if (result) {
                            retval = result;
                        }
                        else {
                            retval = result;
                            $('#submissiondetails').after('<div class="error errorBackground"></span>Document Name must be unique. Addition of a Date or Version Number is suggested.</div>');
                        }

                    }
                });

            }
}

function ValidateSubmissonsFieldsinEditMode() {
    $(".error").remove();
    retval = true;
    objSubmissons = new Object();
    objSubmissons.StudyId = $('#StudyId').val();
    objSubmissons.SubmissionId = $('#ui_num_submissionsideditmode').val();

    if ($('#displaySubmissiontypeeditmode').is(':visible'))
        if (sessionStorage.getItem("issubmissiontype") == "true") {

            if ($('#ui_ddl_submissiontypeeditmode').val() == "") {
                $('#submissiontypeeditmode').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_submissiontypeeditmode').html() + ' is required</div>');
                retval = false;
            }
            else
                if ($('#ui_ddl_submissiontypeeditmode').val() == "Select")
                    objSubmissons.Submissiontype = null;
                else
                    objSubmissons.Submissiontype = $('#ui_ddl_submissiontypeeditmode').val();
        }
        else
            if ($('#ui_ddl_submissiontypeeditmode').val() == "Select")
                objSubmissons.Submissiontype = null;
            else
                objSubmissons.Submissiontype = $('#ui_ddl_submissiontypeeditmode').val();

    if ($('#displayVersioneditmode').is(':visible'))
        if (sessionStorage.getItem("isversion") == "true") {
            if ($('#ui_txt_versioneditmode').is(':visible')) {
                if ($('#ui_txt_versioneditmode').val() == "") {
                    $('#versioneditmode').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_versioneditmode').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_versioneditmode').is(':visible')) {
                if ($('#ui_txtarea_versioneditmode').val() == "") {
                    $('#versioneditmode').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_versioneditmode').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_versioneditmode').is(':visible'))
                objSubmissons.Submissionversion = $('#ui_txtarea_versioneditmode').val().trim();
            if ($('#ui_txt_versioneditmode').is(':visible'))
                objSubmissons.Submissionversion = $('#ui_txt_versioneditmode').val().trim();
        }
        else {
            if ($('#ui_txtarea_versioneditmode').is(':visible'))
                objSubmissons.Submissionversion = $('#ui_txtarea_versioneditmode').val().trim();
            if ($('#ui_txt_versioneditmode').is(':visible'))
                objSubmissons.Submissionversion = $('#ui_txt_versioneditmode').val().trim();
        }

    if ($('#displayStudyeligibilitydateeditmode').is(':visible'))
        if (sessionStorage.getItem("iseligibilitydate") == "true") {

            if ($('#ui_dt_studyeligibilitydateeditmode').val() == "month day, year") {
                $('#studyeligibilitydateeditmode').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_studyeligibilitydateeditmode').html() + ' is required</div>');
                retval = false;
            }
            else
                if ($('#ui_dt_studyeligibilitydateeditmode').val() == "month day, year")
                    objSubmissons.Studyeligibilitydate = null;
                else
                    objSubmissons.Studyeligibilitydate = $('#ui_dt_studyeligibilitydateeditmode').val();
        }
        else
            if ($('#ui_dt_studyeligibilitydateeditmode').val() == "month day, year")
                objSubmissons.Studyeligibilitydate = null;
            else
                objSubmissons.Studyeligibilitydate = $('#ui_dt_studyeligibilitydateeditmode').val();

    if ($('#displaySubmissiondateeditmode').is(':visible'))
        if (sessionStorage.getItem("issubmissiondate") == "true") {

            if ($('#ui_dt_submissiondateeditmode').val() == "month day, year") {
                $('#submissiondateeditmode').after('<div class="error errorBackground" ><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_submissiondateeditmode').html() + ' is required</div>');
                retval = false;
            }
            else
                if ($('#ui_dt_submissiondateeditmode').val() == "month day, year")
                    objSubmissons.Submissiondate = null;
                else
                    objSubmissons.Submissiondate = $('#ui_dt_submissiondateeditmode').val();
        }
        else
            if ($('#ui_dt_submissiondateeditmode').val() == "month day, year")
                objSubmissons.Submissiondate = null;
            else
                objSubmissons.Submissiondate = $('#ui_dt_submissiondateeditmode').val();

    if ($('#displaySubmissiondetailseditmode').is(':visible'))
        if (sessionStorage.getItem("issubmissiondetails") == "true") {

            if ($("#uploadsubmissiondetailseditmode").closest(".k-upload").find(".k-file").length <= 0) {
                $('#submissiondetailseditmode').after('<div class="error errorBackground"></span>' + $('#ui_lbl_submissiondetailseditmode').html() + ' is required</div>');
                retval = false;
            }
            else {
                var objFile = $("#uploadsubmissiondetailseditmode").data("kendoUpload");
                var filename = objFile.getFiles();
                objSubmissons.DocumentExtension = $('#DocumentExtension').val();
                objSubmissons.DocumentSize = $('#DocumentSize').val();
            }
        }
        else
            if ($("#uploadsubmissiondetailseditmode").closest(".k-upload").find(".k-file").length <= 0 && retval === true) {
                objSubmissons.Submissiondetails = null;
                objSubmissons.DocumentExtension = null;
            }
            else {
                objFile = $("#uploadsubmissiondetailseditmode").data("kendoUpload");
                filename = objFile.getFiles();
                objSubmissons.Submissiondetails = filename[0].name;
                objSubmissons.DocumentExtension = $('#DocumentExtension').val();
                objSubmissons.DocumentSize = $('#DocumentSize').val();
                $.ajax({
                    async: false,
                    type: "GET",
                    url: "/TaskWorkFlow/IsDocumentNameIsUnique",
                    data: { "documentsName": objSubmissons.Submissiondetails, "studyId": $('#StudyId').val() },
                    success: function (result) {
                        if (result) {
                            retval = result;
                        }
                        else {
                            retval = result;
                            $('#submissiondetailseditmode').after('<div class="error errorBackground"></span>Document Name must be unique. Addition of a Date or Version Number is suggested.</div>');
                        }

                    }
                });

            }
}

function addSubmissions() {
    
    LoadSubmissionsAttributes("Create");

    isregexexprforversion = true;

    //#region Validate RegEx values for Submissions fields(Add mode)
    $("#ui_txtarea_version").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_version").val().trim();
        if (str != "")
            if ($("#regexexprforversion").val() != "") {
                var expr = new RegExp($("#regexexprforversion").val());
                var str = $("#ui_txtarea_version").val();
                if (str != "" && !expr.test(str)) {
                    $('#username').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforversion").val() + '</span>');
                    isregexexprforversion = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isregexexprforversion = true;
                    return true;
                }
            }
    });
    $("#ui_txt_version").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_version").val().trim();
        if (str != "")
            if ($("#regexexprforversion").val() != "") {
                var expr = new RegExp($("#regexexprforversion").val());
                var str = $("#ui_txt_version").val();
                if (str != "" && !expr.test(str)) {
                    $('#username').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforversion").val() + '</span>');
                    isregexexprforversion = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isregexexprforversion = true;
                    return true;
                }
            }
    });

    $("#ui_btnSaveSubmissonsaddmode").click(function () {  
        ValidateSubmissonsFields();
        if (retval === true && isregexexprforversion === true) {
            $(".k-upload-selected").click();
            Savedetails(type = 29, objEditstudy = objSubmissons);              
            $('#addSubmissionsModal').modal('hide');
            $("#ui_dtg_Submissions").data("kendoGrid").dataSource.read();
            $("#ui_dtg_Submissions").data("kendoGrid").refresh();
        }         
    });
}

function Show(e) {
    var gridRowData = $("#ui_dtg_Submissions").data("kendoGrid");
    if (gridRowData) {
        var data = gridRowData.dataItem($(e).closest("tr"));
        var subModuleFolderName = "Submissions";
        var fileName = data.Submissiondetails;
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + $('#StudyId').val();
    }
}

function LoadSubmissionsAttributes(mode) {
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(submissionsattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case submissiontype:
                            DropDowndetails(response, "displaySubmissiontype", "ui_lbl_submissiontype", "ui_img_helpTextforsubmissiontype", "issubmissiontype", mode);
                            break;
                        case submissionsversion:
                            Textdetails(response, "displayVersion", "ui_lbl_version", "ui_img_helpTextforversion", "isversion", "ui_txt_version", "ui_txtarea_version", "ui_lbl_charsleftforversion", "regexexprforversion", "validationmsgforversion", mode);
                            break;
                        case studyeligibilitydate:
                            DropDowndetails(response, "displayStudyeligibilitydate", "ui_lbl_studyeligibilitydate", "ui_img_helpTextforstudyeligibilitydate", "iseligibilitydate", mode);
                            break;
                        case submissiondate:
                            DropDowndetails(response, "displaySubmissiondate", "ui_lbl_submissiondate", "ui_img_helpTextforsubmissiondate", "issubmissiondate", mode);
                            break;
                        case submissiondetails:
                            DropDowndetails(response, "displaySubmissiondetails", "ui_lbl_submissiondetails", "ui_img_helpTextforsubmissiondetails", "issubmissiondetails", mode);
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

function LoadSubmissionsAttributesEditMode(mode) {
    
    $.ajax({
        async: true,
        type: "GET",
        url: "/NewStudy/GetAttributeValues/",
        data: { attributeid: parseInt(submissionsattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case submissiontype:
                            DropDowndetails(response, "displaySubmissiontypeeditmode", "ui_lbl_submissiontypeeditmode", "ui_img_helpTextforsubmissiontypeeditmode", "issubmissiontype", mode);
                            break;
                        case submissionsversion:
                            Textdetails(response, "displayVersioneditmode", "ui_lbl_versioneditmode", "ui_img_helpTextforversioneditmode", "isversion", "ui_txt_versioneditmode", "ui_txtarea_versioneditmode", "ui_lbl_charsleftforversioneditmode", "regexexprforversioneditmode", "validationmsgforversioneditmode", mode);
                            break;
                        case studyeligibilitydate:
                            DropDowndetails(response, "displayStudyeligibilitydateeditmode", "ui_lbl_studyeligibilitydateeditmode", "ui_img_helpTextforstudyeligibilitydateeditmode", "iseligibilitydate", mode);
                            break;
                        case submissiondate:
                            DropDowndetails(response, "displaySubmissiondateeditmode", "ui_lbl_submissiondateeditmode", "ui_img_helpTextforsubmissiondateeditmode", "issubmissiondate", mode);
                            break;
                        case submissiondetails:
                            DropDowndetails(response, "displaySubmissiondetailseditmode", "ui_lbl_submissiondetailseditmode", "ui_img_helpTextforsubmissiondetailseditmode", "issubmissiondetails", mode);
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
        data: { attributeid: parseInt(submissionsattributeid) },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case submissions:
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
                                        $("#ui_btn_AddSubmissions").attr("disabled", true);
                                }
                                if (iscreaterestricted == true)
                                    $("#ui_btn_AddSubmissions").attr("disabled", true);
                            }
                            if (iscreaterestricted == true)
                                $("#ui_btn_AddSubmissions").attr("disabled", true);
                            else
                                $("#ui_btn_AddSubmissions").removeAttr("disabled");
                            break;
                        case submissiontype:
                            $("#ui_dtg_Submissions th[data-field=Submissiontype]").html(response[i].Name);
                            break;
                        case submissionsversion:
                            $("#ui_dtg_Submissions th[data-field=Submissionversion]").html(response[i].Name);
                            break;
                        case studyeligibilitydate:
                            $("#ui_dtg_Submissions th[data-field=Studyeligibilitydate]").html(response[i].Name);
                            break;
                        case submissiondate:
                            $("#ui_dtg_Submissions th[data-field=Submissiondate]").html(response[i].Name);
                            break;
                        case submissiondetails:
                            $("#ui_dtg_Submissions th[data-field=Submissiondetails]").html(response[i].Name);
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