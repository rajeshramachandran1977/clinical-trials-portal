function onCancel() {
    opener.location.reload();
    window.close();
}
//Delete Current Submission
function onCancelDelete() {    
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/DeleteStudy/",
        data: {
            "studyId": $('#StudyId').val()
        },
        cache: false,
        dataType: "json",
        failure: function (response) {
            popupNotification.show(errorsinthepage, "error");
        }
    });
    opener.location.reload();
    window.close();
}
//set default value for currency as 0
$('#currency').val(0);

function onUpload(e) {
    $('#protocolUploadfile').next("div.error").remove();
}
var ProtocolReUploadDocumentName = "";
function onSelectReUploadDocuments(e) {
    var src = $("#fileReUploadProtocolDoc").val();
    $('#reUploadProtocolFile').next("div.error").remove();
    $.each(e.files, function (index, value) {
        ProtocolReUploadDocumentName = value.name;
    });
}
function onSuccessReUploadDocuments(e) {
    $.each(e.files, function (index, value) {
        ProtocolReUploadDocumentName = value.name;
    });
}


function onChangeOfReqFinancialSupport(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Value === "Yes") {
        $('#ifReqFinancialSupportYes').show();
        $(".k-upload-files").remove();
        $(".k-upload-status").remove();
        $(".k-upload.k-header").addClass("k-upload-empty");
        $(".k-upload-button").removeClass("k-state-focused");
    }
    if (dataItem.Value === "" || dataItem.Value === "No") {
        $('#ifReqFinancialSupportYes').hide();
        DeleteBudgetDocument();

    }
}
function DeleteBudgetDocument() {
    objDocument = new Object();
    objDocument.StudyId = $('#StudyId').val();
    objDocument.SubModuleName = "RequestedSupport";
    objDocument.ANJU_ChangedBy = $("#txtUserName").val();

    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/DeleteDocuments",
        data: { "documents": objDocument },
        failure: function (response) {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });

}

function onselect(e) {
    var selected = e.files;
    var filesInList = $(".k-upload-files .k-filename");

    for (var i = 0; i < selected.length; i++) {
        var filename = selected[i].name;

        filesInList.each(function () {
            if ($(this).text() === filename) {
                e.preventDefault();
            }
        });
    }
}

if ($("#pITaskStatus").val() === "Re-submit Proposal") {
    //if ($("#pITaskStatus").val() === "@Messages.RESUBMITPROPOSAL") {
    $('#taskHeading').text("Re-Submit Proposal");
    $('.border-right').removeClass('border-right');
    $('#deleteBtn,#deleteBtnEnd').hide();
}
else if ($('#TaskName').val() === "Resubmit Protocol") {

    $('#taskHeading').text("Resubmit Protocol");
    $('.border-right').removeClass('border-right');
    $('#deleteBtn,#deleteBtnEnd').hide();
}
if ($('#TaskName').val() === "Submit Protocol") {
    $('#taskHeading').text("Submit Protocol");
    $('.border-right').removeClass('border-right');
    $('#deleteBtn,#deleteBtnEnd').hide();
}

$(document).ready(function () {  
   
    var StudyType = $('#StudyType').val();

    if (StudyType === "Interventional") {

        $("#ui_ddl_reqDrugSupply").change(function () {            
            $('#reqDrugSupply').next("div.error").remove();               
        });      

    }
    $("#ui_ddl_reqFinancialSupport").change(function () {
        $('#reqFinancialSupport').next("div.error").remove();
    });
    $("#currency").on("change keyup", function (e) {
        $('#currencyError').next("div.error").remove();
    });
    $("#files").change(function () {
        $('#uploadFile').next("div.error").remove();
    });
   
    //download files
    $(".k-file-name").css("cursor", "pointer");
    $(".k-file-name").click(function () {
        
        var fileName = this.innerText;    
        if (this.parentElement.parentElement.parentElement.parentElement.parentElement.id === 'budgetDocuments')
            window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=RequestedSupport';
        else if ($('#TaskName').val() === "Resubmit Protocol")        {
            subModuleFolderName = "RequestedSupportProtocolDocuments";
            $.ajax({
                async: false,
                type: "POST",
                url: '/NewStudy/GetDocumentsByStudyID/',
                data: { "studyId": $('#StudyId').val(), "subModuleName": subModuleFolderName },
                success: function (result) {
                    if (result.Data.length > 0) {                        
                        ProtocoldocumentName = result.Data[0].DocumentNameWithOutExtension + result.Data[0].DocumentExtension;
                        path = result.Data[0].Path;
                        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + $('#StudyId').val() + '&&path=' + path;
                    }
                }
            });
        }
        else
            window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=RequestedSupportAdditionalDocuments';
    });
   
    $("#ui_btnPreviousSection, #ui_btnPreviousSectionEnd").click(function (e) {
        //window.history.pushState({ prevUrl: window.location.href }, null, "/NewStudy/PersonalandResearchSites?StudyId=" + $('#StudyId').val() + '&&mode=Update' + '&&StudyType=' + $('#StudyType').val() + '&&piTaskStatus=' + $('#pITaskStatus').val());
        obj = new Object();
        obj.StudyId = $('#StudyId').val();
        obj.mode = "Update";
        obj.StudyType = $('#StudyType').val();
        obj.PITaskStatus = $('#pITaskStatus').val();
        obj.TaskName = $('#TaskName').val();

        $.ajax({
            async: true,
            type: "POST",
            url: "/Login/OpenNewWindow",
            data: { "obj": obj },
            success: function (results) {
                if (results.data === "Success") {
                    window.location.href = "/NewStudy/PersonalandResearchSites";
                }
                else {
                    popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
                }
            }
        });
    });   
    
    $('#requestedSupport').removeClass('btn-submission').addClass('activePage');

    $('#step-4').removeClass('d-none').addClass('d-block');

    $('#ifReqFinancialSupportYes').hide();
    $('#button').hide();
     
    var navListItems = $('div.setup-panel div a'),
        allWells = $('.setup-content'),
        allNextBtn = $('.nextBtn'),
        allPrevBtn = $('.prevBtn');

    allWells.hide();

    navListItems.click(function (e) {
        e.preventDefault();
        var $target = $($(this).attr('href')),
            $item = $(this);

        if (!$item.hasClass('disabled')) {
            navListItems.removeClass('btn-primary').addClass('btn-default');
            $item.addClass('btn-primary');
            allWells.hide();
            $target.show();
            $target.find('input:eq(0)').focus();
        }
    });

    allPrevBtn.click(function () {
        var curStep = $(this).closest(".setup-content"),
            curStepBtn = curStep.attr("id"),
            prevStepWizard = $('div.setup-panel div a[href="#' + curStepBtn + '"]').parent().prev().children("a");

        prevStepWizard.removeAttr('disabled').trigger('click');
    });

    allNextBtn.click(function () {
        var curStep = $(this).closest(".setup-content"),
            curStepBtn = curStep.attr("id"),
            nextStepWizard = $('div.setup-panel div a[href="#' + curStepBtn + '"]').parent().next().children("a"),
            curInputs = curStep.find("input[type='text'],input[type='url']"),
            isValid = true;

        $(".form-group").removeClass("has-error");
        for (var i = 0; i < curInputs.length; i++) {
            if (!curInputs[i].validity.valid) {
                isValid = false;
                $(curInputs[i]).closest(".form-group").addClass("has-error");
            }
        }

        if (isValid)
            nextStepWizard.removeAttr('disabled').trigger('click');
    });

    $('div.setup-panel div a.btn-primary').trigger('click');

    var mode = $('#mode').val();
    // Display entered data if in Edit/read mode

    if (mode === "Update") {       
        $.ajax({
            async: true,
            type: "POST",
            url: "/NewStudy/GetRequestedSupportDetails/",
            cache: false,
            dataType: "json",
            data: { "StudyId": $('#StudyId').val() },
            success: function (result) {
                if (result.Data.length === 0) {
                    popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
                }
                else {                  
                    var IsRequestedForDrugSupply = result.Data[0].IsRequestedForDrugSupply;  
                    if (StudyType === "Interventional") {
                        if (IsRequestedForDrugSupply === true) {
                            $("#ui_ddl_reqDrugSupply").data('kendoDropDownList').value("Yes");
                        }
                        else if (IsRequestedForDrugSupply === false) {
                            $("#ui_ddl_reqDrugSupply").data('kendoDropDownList').value("No");
                        }
                        else {
                            $("#ui_ddl_reqDrugSupply").data('kendoDropDownList').value("Select");
                        }
                    }
                    var IsRequestedForFinancialSupport = result.Data[0].IsRequestedForFinancialSupport;                  
                    if (IsRequestedForFinancialSupport === true) {
                        $("#ui_ddl_reqFinancialSupport").data('kendoDropDownList').value("Yes");
                    }
                    else if (IsRequestedForFinancialSupport === false) {
                        $("#ui_ddl_reqFinancialSupport").data('kendoDropDownList').value("No");
                    }
                    else {
                        $("#ui_ddl_reqFinancialSupport").data('kendoDropDownList').value("Select");
                    }
                    if (IsRequestedForFinancialSupport === true) {
                        $('#ifReqFinancialSupportYes').show();
                        $('#currency').val(result.Data[0].BudgetRequestedForTrial);
                    }
                    else {

                        $('#ifReqFinancialSupportYes').hide();
                    }
                }
            },
            failure: function (response) {
                popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
            }
        });
    }
    var EventName = '';
    $("#ui_btnSaveandExit, #ui_btnSaveandExitEnd").click(function () {

        EventName = "SaveandExit";        
        SaveRequestedSupportdetails(EventName);
    });

    $("#ui_btnSaveandContinue, #ui_btnSaveandContinueEnd").click(function () {

        EventName = "SaveandContinue";
        CheckConditionalValidationFields();
        SaveRequestedSupportdetails(EventName);
    });

    var retval = true;
    var studyType = $('#StudyType').val();

    $('#downloadProtocol').click(function () {       
        subModuleFolderName = "RedlinedReviewProtocolDocument";
        studyId = $('#StudyId').val();
        var ProtocoldocumentName = "";
        var path = "";
        $.ajax({
            async: false,
            type: "POST",
            url: '/NewStudy/GetDocumentsByStudyID/',
            data: { "studyId": $('#StudyId').val(), "subModuleName": subModuleFolderName },
            success: function (result) {
                if (result.Data.length > 0) {                  
                    ProtocoldocumentName = result.Data[0].DocumentNameWithOutExtension + result.Data[0].DocumentExtension;
                    path = result.Data[0].Path;
                    window.location = "/NewStudy/DownloadFiles?fileName=" + ProtocoldocumentName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + studyId + '&&path=' + path;
                }
            }
        });
    });

    function CheckConditionalValidationFields() {       
        $(".error").remove();
        retval = true;

        if (studyType === "Interventional") {
        var IsRequestedForDrugSupply = $('#ui_ddl_reqDrugSupply').val();
        if (IsRequestedForDrugSupply === 'Select' || IsRequestedForDrugSupply  === "") {
            $('#reqDrugSupply').after('<div class="error errorBackground" id="reqDrugSupply"><span class="k-icon k-i-warning"></span>Please specify,Request for drug supply</div>');
            retval = false;
            }
        }
        
        if ($('#pITaskStatus').val().toUpperCase() === $('#pIsubmitprotocol').val().toUpperCase()) {
            if ($("#Protocolfile").closest(".k-upload").find(".k-file").length <= 0) {
                $('#protocolUploadfile').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
                retval = false;
            }
        }
        if ($('#TaskName').val() === "Resubmit Protocol") {
            if ($("#fileReUploadProtocolDoc").closest(".k-upload").find(".k-file").length <= 0) {
                $('#reUploadProtocolFile').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
                retval = false;
            }
        }
        var IsRequestedForFinancialSupport = $('#ui_ddl_reqFinancialSupport').val();
        if (IsRequestedForFinancialSupport === 'Select' || IsRequestedForFinancialSupport === "") {
            $('#reqFinancialSupport').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please specify,Request for financial support</div>');
            retval = false;
        }
        if (IsRequestedForFinancialSupport === 'Yes') {
            if ($('#currency').val < 0 || $('#currency').val().trim() === "") {
                $('#currencyError').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please specify,Request for financial support</div>');
                retval = false;
            }
            if ($("#files").closest(".k-upload").find(".k-file").length <= 0) {
                $('#uploadFile').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
                retval = false;
            }
        }
    }

    var validator = $("#ui_frmRequestedSupport").kendoValidator().data("kendoValidator");

    function SaveRequestedSupportdetails(EventName) {
        if (validator.validate() && retval === true) {

            objnewstudy = new Object();
            objnewstudy.StudyId = $('#StudyId').val();
            objnewstudy.TaskName = $('#TaskName').val();
            if (studyType === "Interventional") {
                var IsRequestedForDrugSupply = $("#ui_ddl_reqDrugSupply").val();                
                if (IsRequestedForDrugSupply === 'Yes') {
                    objnewstudy.IsRequestedForDrugSupply = true;
                   
                }
                else if (IsRequestedForDrugSupply === 'No') {
                    objnewstudy.IsRequestedForDrugSupply = false;
                   
                }
                else {
                    objnewstudy.IsRequestedForDrugSupply = null;
                }
            }
            else
                objnewstudy.IsRequestedForDrugSupply = null;

            var IsRequestedForFinancialSupport = $("#ui_ddl_reqFinancialSupport").val();
            if (IsRequestedForFinancialSupport === 'Yes') 
            {
                objnewstudy.IsRequestedForFinancialSupport = true;
            }
            else if (IsRequestedForFinancialSupport === 'No') {
                objnewstudy.IsRequestedForFinancialSupport = false;
            }
            else
                objnewstudy.IsRequestedForFinancialSupport = null;

            if (IsRequestedForFinancialSupport === 'Yes') {
                objnewstudy.BudgetRequestedForTrial = $("#currency").val();
            }
            else {
                objnewstudy.BudgetRequestedForTrial = null;
                $(".k-upload-files").remove();
                $(".k-upload-status").remove();
                $(".k-upload.k-header").addClass("k-upload-empty");
                $(".k-upload-button").removeClass("k-state-focused");
            }

            objDocument = new Object();
            if ($('#TaskName').val() === "Resubmit Protocol") {
            objDocument.StudyId = $('#StudyId').val();
            objDocument.DocumentName = ProtocolReUploadDocumentName;
            objDocument.IsActive = true;
            objDocument.IsDeleted = false;
            }
            objnewstudy.ANJU_ChangedBy = $('#LogedinUserName').val();
           
            $.ajax({
                async: false,
                type: "POST",
                url: "/NewStudy/CreateUpdateRequestedSupportDetails",
                data: { "newstudy": objnewstudy, "objDocument": objDocument },
                success: function (results) {                    
                    if (results.msgType === "Success") {                      
                        if (EventName === "SaveandExit") {
                            DestroySession();
                            opener.location.reload();
                            window.close();
                        }

                        else {                            
                            obj = new Object();
                            obj.StudyId = $('#StudyId').val();
                            obj.mode = $('#mode').val();
                            obj.StudyType = $('#StudyType').val();
                            obj.piTaskStatus = $('#pITaskStatus').val();
                            obj.TaskName = $('#TaskName').val();

                            $.ajax({
                                async: true,
                                type: "POST",
                                url: "/Login/OpenNewWindow",
                                data: { "obj": obj },
                                success: function (results) {
                                    if (results.data === "Success") {
                                        window.location.href = "/NewStudy/Confirmation";
                                    }
                                    else {
                                        popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
                                    }
                                }
                            });
                        } 
                    }
                    else {
                        popupNotification.show(results.ErrorMessage, "error");
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    popupNotification.show('Error', "error");
                }
            });
        }
        else {

            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }

    }

    function DestroySession() {
        $.ajax({
            async: true,
            type: "POST",
            url: "/NewStudy/DestroyStudySession/",
            cache: false,
            dataType: "json",
            failure: function (response) {
                popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
            }
        });
    }
});