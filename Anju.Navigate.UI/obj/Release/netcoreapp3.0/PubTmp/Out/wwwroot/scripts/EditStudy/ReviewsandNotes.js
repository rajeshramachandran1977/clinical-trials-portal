//#region Template declarations
var reviewsandnotestemplate = kendo.template($("#reviewsandnotestemplate").html());
//#endregion

//#region delete row functions in grids
function deleteReviewsandNotes(e) {
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
    var grid = $("#ui_dtg_ReviewsandNotes").data("kendoGrid"); //Get the grid from which the pop-up is coming
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

function addReviewsandNotesdetails() {
    var wnd = $("#ReviewsandNotes").data("kendoWindow");
    wnd.content(reviewsandnotestemplate(kendo.template($("#reviewsandnotestemplate").html())));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadReviewsandNotesAttributes();

    CheckcharacterLength();

    $('#reviewdate').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    $("#username,#role,#reviewstep,#submissioncomments,#decision").on("keyup", function (e) {
        $(this).nextAll("div.error").remove();
    })

    isvalidRegexforusername = isvalidRegexforrole = isvalidRegexforreviewstep = isvalidRegexforsubmissioncomments =
        isvalidRegexfordecision = true;

    //#region Validate RegEx values for Reviews and Notes` fields(Add mode)
    $("#ui_txtarea_username").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_username").val().trim();
        if (str != "")
            if ($("#regexexprforusername").val() != "") {
                var expr = new RegExp($("#regexexprforusername").val());
                var str = $("#ui_txtarea_username").val();
                if (str != "" && !expr.test(str)) {
                    $('#username').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforusername").val() + '</span>');
                    isvalidRegexforusername = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforusername = true;
                    return true;
                }
            }
    });
    $("#ui_txt_username").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_username").val().trim();
        if (str != "")
            if ($("#regexexprforusername").val() != "") {
                var expr = new RegExp($("#regexexprforusername").val());
                var str = $("#ui_txt_username").val();
                if (str != "" && !expr.test(str)) {
                    $('#username').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforusername").val() + '</span>');
                    isvalidRegexforusername = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforusername = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_role").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_role").val().trim();
        if (str != "")
            if ($("#regexexprforrole").val() != "") {
                var expr = new RegExp($("#regexexprforrole").val());
                var str = $("#ui_txtarea_role").val();
                if (str != "" && !expr.test(str)) {
                    $('#role').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforrole").val() + '</span>');
                    isvalidRegexforrole = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforrole = true;
                    return true;
                }
            }
    });
    $("#ui_txt_role").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_role").val().trim();
        if (str != "")
            if ($("#regexexprforrole").val() != "") {
                var expr = new RegExp($("#regexexprforrole").val());
                var str = $("#ui_txt_role").val();
                if (str != "" && !expr.test(str)) {
                    $('#role').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforrole").val() + '</span>');
                    isvalidRegexforrole = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforrole = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_reviewstep").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_reviewstep").val().trim();
        if (str != "")
            if ($("#regexexprforreviewstep").val() != "") {
                var expr = new RegExp($("#regexexprforreviewstep").val());
                var str = $("#ui_txtarea_reviewstep").val();
                if (str != "" && !expr.test(str)) {
                    $('#reviewstep').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforreviewstep").val() + '</span>');
                    isvalidRegexforreviewstep = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforreviewstep = true;
                    return true;
                }
            }
    });
    $("#ui_txt_reviewstep").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_reviewstep").val().trim();
        if (str != "")
            if ($("#regexexprforreviewstep").val() != "") {
                var expr = new RegExp($("#regexexprforreviewstep").val());
                var str = $("#ui_txt_reviewstep").val();
                if (str != "" && !expr.test(str)) {
                    $('#reviewstep').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforreviewstep").val() + '</span>');
                    isvalidRegexforreviewstep = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforreviewstep = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_submissioncomments").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_submissioncomments").val().trim();
        if (str != "")
            if ($("#regexexprforsubmissioncomments").val() != "") {
                var expr = new RegExp($("#regexexprforsubmissioncomments").val());
                var str = $("#ui_txtarea_submissioncomments").val();
                if (str != "" && !expr.test(str)) {
                    $('#submissioncomments').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforsubmissioncomments").val() + '</span>');
                    isvalidRegexforsubmissioncomments = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforsubmissioncomments = true;
                    return true;
                }
            }
    });
    $("#ui_txt_submissioncomments").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_submissioncomments").val().trim();
        if (str != "")
            if ($("#regexexprforsubmissioncomments").val() != "") {
                var expr = new RegExp($("#regexexprforsubmissioncomments").val());
                var str = $("#ui_txt_submissioncomments").val();
                if (str != "" && !expr.test(str)) {
                    $('#submissioncomments').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforsubmissioncomments").val() + '</span>');
                    isvalidRegexforsubmissioncomments = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforsubmissioncomments = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_decision").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_decision").val().trim();
        if (str != "")
            if ($("#regexexprfordecision").val() != "") {
                var expr = new RegExp($("#regexexprfordecision").val());
                var str = $("#ui_txtarea_decision").val();
                if (str != "" && !expr.test(str)) {
                    $('#decision').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordecision").val() + '</span>');
                    isvalidRegexfordecision = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordecision = true;
                    return true;
                }
            }
    });
    $("#ui_txt_decision").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_decision").val().trim();
        if (str != "")
            if ($("#regexexprfordecision").val() != "") {
                var expr = new RegExp($("#regexexprfordecision").val());
                var str = $("#ui_txt_decision").val();
                if (str != "" && !expr.test(str)) {
                    $('#decision').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordecision").val() + '</span>');
                    isvalidRegexfordecision = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordecision = true;
                    return true;
                }
            }
    });
    //#endregion

    //#region Reviews and Notes(Add mode)
    $("#ui_btnSavereviewsandnotes").click(function (e) {
        SaveReviewsandNotes("Create");
    });
    //#endregion

}

function showReviewsandNotes(e) {
    var grid = $("#ui_dtg_ReviewsandNotes").getKendoGrid();
    var wnd = $("#ReviewsandNotes").data("kendoWindow");
    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(reviewsandnotestemplate(dataItem));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadReviewsandNotesAttributes();

    CheckcharacterLength();

    $('#reviewdate').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    $("#username,#role,#reviewstep,#submissioncomments,#decision").on("keyup", function (e) {
        $(this).nextAll("div.error").remove();
    })

    isvalidRegexforusername = isvalidRegexforrole = isvalidRegexforreviewstep = isvalidRegexforsubmissioncomments =
        isvalidRegexfordecision = true;

    //#region Validate RegEx values for Reviews and Notes` fields(Edit mode)
    $("#ui_txtarea_username").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_username").val().trim();
        if (str != "")
            if ($("#regexexprforusername").val() != "") {
                var expr = new RegExp($("#regexexprforusername").val());
                var str = $("#ui_txtarea_username").val();
                if (str != "" && !expr.test(str)) {
                    $('#username').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforusername").val() + '</span>');
                    isvalidRegexforusername = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforusername = true;
                    return true;
                }
            }
    });
    $("#ui_txt_username").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_username").val().trim();
        if (str != "")
            if ($("#regexexprforusername").val() != "") {
                var expr = new RegExp($("#regexexprforusername").val());
                var str = $("#ui_txt_username").val();
                if (str != "" && !expr.test(str)) {
                    $('#username').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforusername").val() + '</span>');
                    isvalidRegexforusername = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforusername = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_role").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_role").val().trim();
        if (str != "")
            if ($("#regexexprforrole").val() != "") {
                var expr = new RegExp($("#regexexprforrole").val());
                var str = $("#ui_txtarea_role").val();
                if (str != "" && !expr.test(str)) {
                    $('#role').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforrole").val() + '</span>');
                    isvalidRegexforrole = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforrole = true;
                    return true;
                }
            }
    });
    $("#ui_txt_role").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_role").val().trim();
        if (str != "")
            if ($("#regexexprforrole").val() != "") {
                var expr = new RegExp($("#regexexprforrole").val());
                var str = $("#ui_txt_role").val();
                if (str != "" && !expr.test(str)) {
                    $('#role').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforrole").val() + '</span>');
                    isvalidRegexforrole = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforrole = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_reviewstep").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_reviewstep").val().trim();
        if (str != "")
            if ($("#regexexprforreviewstep").val() != "") {
                var expr = new RegExp($("#regexexprforreviewstep").val());
                var str = $("#ui_txtarea_reviewstep").val();
                if (str != "" && !expr.test(str)) {
                    $('#reviewstep').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforreviewstep").val() + '</span>');
                    isvalidRegexforreviewstep = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforreviewstep = true;
                    return true;
                }
            }
    });
    $("#ui_txt_reviewstep").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_reviewstep").val().trim();
        if (str != "")
            if ($("#regexexprforreviewstep").val() != "") {
                var expr = new RegExp($("#regexexprforreviewstep").val());
                var str = $("#ui_txt_reviewstep").val();
                if (str != "" && !expr.test(str)) {
                    $('#reviewstep').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforreviewstep").val() + '</span>');
                    isvalidRegexforreviewstep = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforreviewstep = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_submissioncomments").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_submissioncomments").val().trim();
        if (str != "")
            if ($("#regexexprforsubmissioncomments").val() != "") {
                var expr = new RegExp($("#regexexprforsubmissioncomments").val());
                var str = $("#ui_txtarea_submissioncomments").val();
                if (str != "" && !expr.test(str)) {
                    $('#submissioncomments').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforsubmissioncomments").val() + '</span>');
                    isvalidRegexforsubmissioncomments = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforsubmissioncomments = true;
                    return true;
                }
            }
    });
    $("#ui_txt_submissioncomments").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_submissioncomments").val().trim();
        if (str != "")
            if ($("#regexexprforsubmissioncomments").val() != "") {
                var expr = new RegExp($("#regexexprforsubmissioncomments").val());
                var str = $("#ui_txt_submissioncomments").val();
                if (str != "" && !expr.test(str)) {
                    $('#submissioncomments').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforsubmissioncomments").val() + '</span>');
                    isvalidRegexforsubmissioncomments = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforsubmissioncomments = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_decision").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_decision").val().trim();
        if (str != "")
            if ($("#regexexprfordecision").val() != "") {
                var expr = new RegExp($("#regexexprfordecision").val());
                var str = $("#ui_txtarea_decision").val();
                if (str != "" && !expr.test(str)) {
                    $('#decision').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordecision").val() + '</span>');
                    isvalidRegexfordecision = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordecision = true;
                    return true;
                }
            }
    });
    $("#ui_txt_decision").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_decision").val().trim();
        if (str != "")
            if ($("#regexexprfordecision").val() != "") {
                var expr = new RegExp($("#regexexprfordecision").val());
                var str = $("#ui_txt_decision").val();
                if (str != "" && !expr.test(str)) {
                    $('#decision').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordecision").val() + '</span>');
                    isvalidRegexfordecision = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordecision = true;
                    return true;
                }
            }
    });
    //#endregion

    //#region Get existing I
    $("#ui_num_reviewsandnotesid").val(dataItem.ReviewsandNotesId);
    $("#ui_dt_reviewdate").data("kendoDatePicker").value(dataItem.Reviewdate);
    $("#ui_txt_username,#ui_txtarea_username").val(dataItem.Username);
    $("#ui_txt_role,#ui_txtarea_role").val(dataItem.Role);
    $("#ui_txt_reviewstep,#ui_txtarea_reviewstep").val(dataItem.Reviewstep);
    $("#ui_txt_submissioncomments,#ui_txtarea_submissioncomments").val(dataItem.Submissioncomments);
    $("#ui_txt_decision,#ui_txtarea_decision").val(dataItem.Decision);
    //#endregion

    //#region Save Status(Add mode)
    $("#ui_btnSavereviewsandnotes").click(function (e) {
        SaveReviewsandNotes("Create");
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

//#region Reviews and Notes fields
function ValidateReviewsandNotesFields() {
    $(".error").remove();
    retval = true;
    objReviewsandNotes = new Object();
    objReviewsandNotes.StudyId = $('#StudyId').val();
    objReviewsandNotes.ReviewsandNotesId = $('#ui_num_reviewsandnotesid').val();

    if ($('#displayReviewdate').is(':visible'))
        if (sessionStorage.getItem("isreviewdate") == "true") {
            if ($('#ui_dt_reviewdate').val() == "month day, year") {
                $('#reviewdate').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_reviewdate').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_dt_reviewdate').val() == "month day, year")
                    objReviewsandNotes.Reviewdate = null;
                else
                    objReviewsandNotes.Reviewdate = $('#ui_dt_reviewdate').val();
            }
        }
        else {
            if ($('#ui_dt_reviewdate').val() == "month day, year")
                objReviewsandNotes.Reviewdate = null;
            else
                objReviewsandNotes.Reviewdate = $('#ui_dt_reviewdate').val();
        }

    if ($('#displayUsername').is(':visible')) {
        if (sessionStorage.getItem("isusername") == "true") {
            if ($('#ui_txt_username').is(':visible')) {
                if ($('#ui_txt_username').val() == "") {
                    $('#username').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_username').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_username').is(':visible')) {
                if ($('#ui_txtarea_username').val() == "") {
                    $('#username').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_username').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_username').is(':visible'))
                objReviewsandNotes.Username = $('#ui_txt_username').val().trim();
            if ($('#ui_txtarea_username').is(':visible'))
                objReviewsandNotes.Username = $('#ui_txtarea_username').val().trim();
        }
        else {
            if ($('#ui_txt_username').is(':visible'))
                objReviewsandNotes.Username = $('#ui_txt_username').val().trim();
            if ($('#ui_txtarea_time').is(':visible'))
                objReviewsandNotes.Username = $('#ui_txtarea_time').val().trim();
        }
    }
     else
    {
        if ($('#ui_txt_username').is(':visible'))
            objReviewsandNotes.Username = $('#ui_txt_username').val().trim();
        if ($('#ui_txtarea_time').is(':visible'))
            objReviewsandNotes.Username = $('#ui_txtarea_time').val().trim();
    }

    if ($('#displayRole').is(':visible'))
        if (sessionStorage.getItem("isrole") == "true") {
            if ($('#ui_txt_role').is(':visible')) {
                if ($('#ui_txt_username').val() == "") {
                    $('#role').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_role').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_role').is(':visible')) {
                if ($('#ui_txtarea_role').val() == "") {
                    $('#role').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_role').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_role').is(':visible'))
                objReviewsandNotes.Role = $('#ui_txt_role').val().trim();
            if ($('#ui_txtarea_role').is(':visible'))
                objReviewsandNotes.Role = $('#ui_txtarea_role').val().trim();
        }
        else {
            if ($('#ui_txt_role').is(':visible'))
                objReviewsandNotes.Role = $('#ui_txt_role').val().trim();
            if ($('#ui_txtarea_role').is(':visible'))
                objReviewsandNotes.Role = $('#ui_txtarea_role').val().trim();
        }

    if ($('#displayReviewstep').is(':visible'))
        if (sessionStorage.getItem("isreviewstep") == "true") {
            if ($('#ui_txt_reviewstep').is(':visible')) {
                if ($('#ui_txt_reviewstep').val() == "") {
                    $('#reviewstep').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_reviewstep').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_reviewstep').is(':visible')) {
                if ($('#ui_txtarea_reviewstep').val() == "") {
                    $('#reviewstep').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_reviewstep').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_reviewstep').is(':visible'))
                objReviewsandNotes.Reviewstep = $('#ui_txt_reviewstep').val().trim();
            if ($('#ui_txtarea_reviewstep').is(':visible'))
                objReviewsandNotes.Reviewstep = $('#ui_txtarea_reviewstep').val().trim();
        }
        else {
            if ($('#ui_txt_reviewstep').is(':visible'))
                objReviewsandNotes.Reviewstep = $('#ui_txt_reviewstep').val().trim();
            if ($('#ui_txtarea_reviewstep').is(':visible'))
                objReviewsandNotes.Reviewstep = $('#ui_txtarea_reviewstep').val().trim();
        }

    if ($('#displaySubmissioncomments').is(':visible'))
        if (sessionStorage.getItem("issubmissioncomments") == "true") {
            if ($('#ui_txt_submissioncomments').is(':visible')) {
                if ($('#ui_txt_submissioncomments').val() == "") {
                    $('#submissioncomments').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_submissioncomments').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_submissioncomments').is(':visible')) {
                if ($('#ui_txtarea_submissioncomments').val() == "") {
                    $('#submissioncomments').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_submissioncomments').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_submissioncomments').is(':visible'))
                objReviewsandNotes.Submissioncomments = $('#ui_txt_submissioncomments').val().trim();
            if ($('#ui_txtarea_submissioncomments').is(':visible'))
                objReviewsandNotes.Submissioncomments = $('#ui_txtarea_submissioncomments').val().trim();
        }
        else {
            if ($('#ui_txt_submissioncomments').is(':visible'))
                objReviewsandNotes.Submissioncomments = $('#ui_txt_submissioncomments').val().trim();
            if ($('#ui_txtarea_submissioncomments').is(':visible'))
                objReviewsandNotes.Submissioncomments = $('#ui_txtarea_submissioncomments').val().trim();
        }

    if ($('#displayDecision').is(':visible'))
        if (sessionStorage.getItem("isdecision") == "true") {
            if ($('#ui_txt_decision').is(':visible')) {
                if ($('#ui_txt_decision').val() == "") {
                    $('#decision').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_decision').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_decision').is(':visible')) {
                if ($('#ui_txtarea_decision').val() == "") {
                    $('#decision').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_decision').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_decision').is(':visible'))
                objReviewsandNotes.Decision = $('#ui_txt_decision').val().trim();
            if ($('#ui_txtarea_decision').is(':visible'))
                objReviewsandNotes.Decision = $('#ui_txtarea_submissioncomments').val().trim();
        }
        else {
            if ($('#ui_txt_decision').is(':visible'))
                objReviewsandNotes.Decision = $('#ui_txt_decision').val().trim();
            if ($('#ui_txtarea_decision').is(':visible'))
                objReviewsandNotes.Decision = $('#ui_txtarea_submissioncomments').val().trim();
        }
}
//#endregion

function SaveReviewsandNotes(mode) {
    var validator = $("#ui_dtg_ReviewsandNotes").kendoValidator().data("kendoValidator");
    ValidateReviewsandNotesFields();
    if (validator.validate() && retval === true &&
        (isvalidRegexforusername === true && isvalidRegexforrole === true && isvalidRegexforreviewstep === true
            && isvalidRegexforsubmissioncomments === true && isvalidRegexfordecision === true))
        Savedetails(type = 28, objEditstudy = objReviewsandNotes);
    else
        popupNotification.show(errorsinthepage, "error");
    return false;
}

function LoadReviewsandNotesAttributes() {
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
                        case reviewdate:
                            DropDowndetails(response, "displayReviewdate", "ui_lbl_reviewdate", "ui_img_helpTextforreviewdate", "isreviewdate");
                            break;
                        case username:
                            Textdetails(response, "displayUsername", "ui_lbl_username", "ui_img_helpTextforusername", "isusername", "ui_txt_username", "ui_txtarea_username", "ui_lbl_charsleftforusername", "regexexprforusername", "validationmsgforusername");
                            break;
                        case roleforgeneraldetails:
                            Textdetails(response, "displayRole", "ui_lbl_role", "ui_img_helpTextforrole", "isrole", "ui_txt_role", "ui_txtarea_role", "ui_lbl_charsleftforrole", "regexexprforrole", "validationmsgforrole");
                            break;
                        case reviewstep:
                            Textdetails(response, "displayReviewstep", "ui_lbl_reviewstep", "ui_img_helpTextforreviewstep", "isreviewstep", "ui_txt_reviewstep", "ui_txtarea_reviewstep", "ui_lbl_charsleftforreviewstep", "regexexprforreviewstep", "validationmsgforreviewstep");
                            break;
                        case submissioncomments:
                            Textdetails(response, "displaySubmissioncomments", "ui_lbl_submissioncomments", "ui_img_helpTextforsubmissioncomments", "issubmissioncomments", "ui_txt_submissioncomments", "ui_txtarea_submissioncomments", "ui_img_helpTextforsubmissioncomments", "regexexprforsubmissioncomments", "validationmsgforsubmissioncomments");
                            break;
                        case decision:
                            Textdetails(response, "displayDecision", "ui_lbl_decision", "ui_img_helpTextfordecision", "isdecision", "ui_txt_decision", "ui_txtarea_decision", "ui_img_helpTextfordecision", "regexexprfordecision", "validationmsgfordecision");
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

$("#reviewsandnotes").on("click", function () {
    $('#reviewsandnotesdetails').removeClass('reviewsandnotesdetails');
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
                    switch (response[i].FieldType) {
                        case reviewdate:
                            $("#ui_dtg_ReviewsandNotes th[data-field=Reviewdate]").html(response[i].Name);
                            break;
                        case username:
                            $("#ui_dtg_ReviewsandNotes th[data-field=Username]").html(response[i].Name);
                            break;
                        case roleforgeneraldetails:
                            $("#ui_dtg_ReviewsandNotes th[data-field=Role]").html(response[i].Name);
                            break;
                        case reviewstep:
                            $("#ui_dtg_ReviewsandNotes th[data-field=Reviewstep]").html(response[i].Name);
                            break;
                        case submissioncomments:
                            $("#ui_dtg_ReviewsandNotes th[data-field=Submissioncomments]").html(response[i].Name);
                            break;
                        case decision:
                            $("#ui_dtg_ReviewsandNotes th[data-field=Decision]").html(response[i].Name);
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