
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

function onUpload(e) {
}


function OnCreateUpdateModal(e) {

    $('#ui_dtg_emailList').data('kendoGrid').refresh();
}
function onChangeofsponsoredtrial(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Value === "") {
        $('#Iscompanysponsoredtrial').hide();
        $('#IsNotcompanysponsoredtrial').hide();
    }
    else if (dataItem.Value === "Yes") {
        $('#Iscompanysponsoredtrial').show();
        $('#IsNotcompanysponsoredtrial').hide();
    }
    else if (dataItem.Value === "No") {
        $('#Iscompanysponsoredtrial').hide();
        $('#IsNotcompanysponsoredtrial').show();
    }
}
function onChangeofreceivedGCPtraining(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Value === "Yes") {
        $('#ifReceivedGCPtrainingYes').show();
    }
    else if (dataItem.Value === "" || dataItem.Value === "No") {
        $('#ifReceivedGCPtrainingYes').hide();
    }
}
function onChangeofGovtSupportProvided(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Value === "Yes") {
        $('#govtSupportDesc').show();
    }
    else if (dataItem.Value === "" || dataItem.Value === "No") {
        $('#govtSupportDesc').hide();
    }
}
function onChangeofOtherSupportProvided(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Value === "Yes") {
        $('#nonCompanySupportSources').show();
    }
    else if (dataItem.Value === "" || dataItem.Value === "No") {
        $('#nonCompanySupportSources').hide();
    }
}
function onChangeofCooperativeGroupStudy(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Value === "Yes") {
        $('#cooperativeGroupName').show();
    }
    else if (dataItem.Value === "" || dataItem.Value === "No") {
        $('#cooperativeGroupName').hide();
    }
}
function onChangeofPhysicalNetworkStudy(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Value === "Yes") {
        $('#physicianNetworkName').show();
    }
    else if (dataItem.Value === "" || dataItem.Value === "No") {
        $('#physicianNetworkName').hide();
    }
}
function onChangeofInspectedHealth(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Value === "Yes") {
        $('#ifInspectedHealthYes').show();
    }
    else if (dataItem.Value === "" || dataItem.Value === "No") {
        $('#ifInspectedHealthYes').hide();
    }
}
function onChangeofFDAForm(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Value === "Yes") {
        $('#mainObservation').show();
    }
    else if (dataItem.Value === "" || dataItem.Value === "No") {
        $('#mainObservation').hide();
    }
}
function onChangeofHealthAuthority(e) {
    var dataItem = this.dataItem(e.item);
    if (dataItem.Value === "" || dataItem.Value === "Yes") {
        $('#ifHealthAuthorityYes').show();
    }
    if (dataItem.Value === "" || dataItem.Value === "No") {
        $('#ifHealthAuthorityYes').hide();
    }
}
function filterStates() {
    return {
        countryId: $("#ui_ddl_country").val()
    };
}
function filterCities() {
    return {
        stateId: $("#ui_ddl_state").val()
    };
}
function filterPayeeStates() {
    return {
        countryId: $("#ui_ddl_payee_country").val()
    };
}
function filterPayeeCities() {
    return {
        stateId: $("#ui_ddl_payee_state").val()
    };
}
function filterShipmentStates() {
    return {
        countryId: $("#ui_ddl_shipment_country").val()
    };
}
function filterShipmentCities() {
    return {
        stateId: $("#ui_ddl_shipment_state").val()
    };
}
function filterContractsStates() {
    return {
        countryId: $("#ui_ddl_contracts_country").val()
    };
}
function filterContractsCities() {
    return {
        stateId: $("#ui_ddl_contracts_state").val()
    };
}
function filterCoordinatorStates() {
    return {
        countryId: $("#ui_ddl_coordinator_country").val()
    };
}
function filterCoordinatorCities() {
    return {
        stateId: $("#ui_ddl_coordinator_state").val()
    };
}

function StudyDetailsID() {
    return {
        studyId: $('#StudyId').val()
    };
}
function OnsaveChanges(e) {
    var grid = null;
    switch (e.type) {
        case "create":
            grid = $("#ui_dtg_emailList").data("kendoGrid");
            grid.dataSource.read();
            break;
        case "update":
            grid = $("#ui_dtg_emailList").data("kendoGrid");
            grid.dataSource.read();
            break;
        case "destroy":
            grid = $("#ui_dtg_emailList").data("kendoGrid");
            grid.dataSource.read();
            break;
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
    ///Validation changes
    $("#ui_txt_firstName").on("keyup", function (e) {
        $('#firstName').next("div.error").remove();
    });
    $("#ui_txt_lastName").on("keyup", function (e) {
        $('#lastName').next("div.error").remove();
    });
    $("#ui_multiselect_credentials").change(function () {
        $('#multiselectCredentials').next("div.error").remove();
    });

    $("#ui_txt_Institution").on("keyup", function (e) {
        $('#institution').next("div.error").remove();
    });
    $("#ui_ddl_country").change(function () {
        $('#country').next("div.error").remove();
    });
    $("#ui_ddl_state").change(function () {
        $('#state').next("div.error").remove();
    });
    $("#ui_ddl_city").change(function () {
        $('#city').next("div.error").remove();
    });
    $("#files").change(function () {
        $('#uploadFile').next("div.error").remove();
    });
    $("#ui_txt_addressLine1").on("keyup", function (e) {
        $('#addressLine1').next("div.error").remove();
    });
    $("#ui_txt_postalCode").on("keyup", function (e) {
        $('#postalCode').next("div.error").remove();
    });
    $("#ui_txt_phone").on("keyup", function (e) {
        $('#phonePI').next("div.error").remove();
    });
    $("#ui_txt_email").on("keyup", function (e) {
        $('#email').next("div.error").remove();
    });
    $("#ui_ddl_isParticipatedinaCompanysponsoredtrial").change(function () {
        $('#isParticipatedinaCompanysponsoredtrial').next("div.error").remove();
    });
    $("#ui_ddl_isInspectedbyaHealthAuthority").change(function () {
        $('#isInspectedByAHealthAuthority').next("div.error").remove();
    });
    $("#ui_ddl_isinspectedbytheFDA").change(function () {
        $('#isInspectedByTheFDA').next("div.error").remove();
    });
    $("#ui_ddl_isCooperativeGroupStudy").change(function () {
        $('#isCooperativeGroupStudy').next("div.error").remove();
    });
    $("#ui_ddl_physicianNetworkStudy").change(function () {
        $('#physicianNetworkStudy').next("div.error").remove();
    });
    $("#ui_ddl_isGovernmentSupportProvided").change(function () {
        $('#isGovernmentSupportProvided').next("div.error").remove();
    });
    $("#ui_ddl_issupportbeprovidedfromothersource").change(function () {
        $('#isSupportBeProvidedFromOtherSource').next("div.error").remove();
    });
    $("#ui_txt_medicalSpecialty").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_txt_boardcrtification").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_txt_medicalLicense").on("keyup", function (e) {
        $(this).next("div.error").remove();

    });
    $("#ui_txt_listtrialexperience").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_txt_numberofongoingclinicaltrials").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });

    $("#ui_ddl_isParticipatedinaCompanysponsoredtrial").change(function () {
        if ($("#ui_ddl_isParticipatedinaCompanysponsoredtrial").val() === 'No') {
            $("#ui_ddl_IsreceivedGCPtraining").change(function () {
                $('#isReceivedGCPTraining').next("div.error").remove();
            });
        }
    });

    $("#ui_ddl_cooperativeGroupName").change(function () {
        $('#cooperativeGroup').next("div.error").remove();
    });

    $("#ui_txtPhysicianNetworkName").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_txt_GovernmentSupportDescription").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    $("#ui_txt_nonCompanySupportSources").on("keyup", function (e) {
        $(this).next("div.error").remove();
    });
    //validation ends

    //download files
    $(".k-file-name").css("cursor", "pointer");
    $(".k-file-name").click(function () {
        var fileName = this.innerText;
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=PersonalandResearchSites';
    });

    var retval = true;
    $('#personnelResearchSites').removeClass('btn-submission').addClass('activePage');
    
    $("#ui_btnPreviousSection,#ui_btnPreviousSectionEnd").click(function () {
       // var studyType = $('#studyType').val();
        //  window.history.pushState({ prevUrl: window.location.href }, null, "../NewStudy/ScientificRationaleII?StudyId=" + $('#StudyId').val() + '&&mode=Update' + '&&StudyType=' + studyType + '&&piTaskStatus=' + $('#pITaskStatus').val());
       
        obj = new Object();
        obj.StudyId = $('#StudyId').val();
        obj.mode = "Update";
        obj.StudyType = $('#studyType').val();
        obj.PITaskStatus = $('#pITaskStatus').val();
        obj.TaskName = $('#TaskName').val();

        $.ajax({
            async: true,
            type: "POST",
            url: "/Login/OpenNewWindow",
            data: { "obj": obj },
            success: function (results) {
                if (results.data === "Success") {
                    window.location.href = "../NewStudy/ScientificRationaleII";
                }
                else {
                    popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
                }
            }        
       });
});

    var validator = $("#ui_frmPersonalandResearchSite").kendoValidator().data("kendoValidator");

    $('#step-3').removeClass('d-none').addClass('d-block');
    //page 3
    $('#Iscompanysponsoredtrial').hide();
    $('#IsNotcompanysponsoredtrial').hide();
    $('#ifReceivedGCPtrainingYes').hide();
    $('#govtSupportDesc').hide();
    $('#nonCompanySupportSources').hide();
    $('#cooperativeGroupName').hide();
    $('#physicianNetworkName').hide();
    $('#ifInspectedHealthYes').hide();
    $('#mainObservation').hide();
    $('#ifHealthAuthorityYes').hide();

    $('#ui_multiselect_credentials').kendoMultiSelect({
        dataTextField: "Code",
        dataValueField: "CodeId",
        optionLabel: 'Select',
        autoClose: false,
        dataSource: {
            transport: {
                read: {
                    dataType: "json",
                    url: "../Register/GetCredentials"
                }
            }
        }
    });
    

    $('#ui_payee_multiselect_credentials').kendoMultiSelect({
        dataTextField: "Code",
        dataValueField: "CodeId",
        optionLabel: 'Select',
        autoClose: false,
        dataSource: {
            transport: {
                read: {
                    dataType: "json",
                    url: "../Register/GetCredentials"
                }
            }
        }
    });

    $('#ui_shipment_multiselect_credentials').kendoMultiSelect({
        dataTextField: "Code",
        dataValueField: "CodeId",
        optionLabel: 'Select',
        autoClose: false,
        dataSource: {
            transport: {
                read: {
                    dataType: "json",
                    url: "../Register/GetCredentials"
                }
            }
        }
    });
    $('#ui_contracts_multiselect_credentials').kendoMultiSelect({
        dataTextField: "Code",
        dataValueField: "CodeId",
        optionLabel: 'Select',
        autoClose: false,
        dataSource: {
            transport: {
                read: {
                    dataType: "json",
                    url: "../Register/GetCredentials"
                }
            }
        }
    });
    
    $('#ui_coordinator_multiselect_credentials').kendoMultiSelect({
        dataTextField: "Code",
        dataValueField: "CodeId",
        optionLabel: 'Select',
        autoClose: false,
        dataSource: {
            transport: {
                read: {
                    dataType: "json",
                    url: "../Register/GetCredentials"
                }
            }
        }
    });
    var mode = $('#mode').val();
    // Display entered data if in Edit/read mode

    if (mode === "Update") {
        $.ajax({
            async: true,
            type: "POST",
            url: "/NewStudy/GetPersonalandResearchSiteDetails/",
            cache: false,
            dataType: "json",
            data: { "StudyId": $('#StudyId').val() },
            success: function (result) {
                if (result.Data.length === 0) {
                    GetUserDetailsByUserName();
                }
                else {
                    for (let i = 0; i < result.Data.length; i++) {
                        if (result.Data[i].CategoryID === 1) {
                            $("#ui_txt_firstName").val(result.Data[i].FirstName);
                            $("#ui_txt_lastName").val(result.Data[i].LastName);
                            $("#ui_ddl_salutation").data('kendoDropDownList').value(result.Data[i].Salutation);
                            $("#ui_ddl_suffix").data('kendoDropDownList').value(result.Data[i].Suffix);
                            $("#ui_txt_title").val(result.Data[i].Title);
                            $("#ui_ddl_country").data('kendoDropDownList').value(result.Data[i].CountryId);
                            $("#ui_ddl_state").data('kendoDropDownList').value(result.Data[i].StateId);
                            $("#ui_ddl_city").data('kendoDropDownList').value(result.Data[i].CityId);
                            if (result.Data[i].Degree !== null) {
                                var degreeArray = result.Data[i].Degree.split(',');
                                $("#ui_multiselect_credentials").getKendoMultiSelect().value(degreeArray);
                            }

                            $('#ui_txt_npi').val(result.Data[i].Npinumber);
                            $('#ui_txt_Institution').val(result.Data[i].Institution);
                            $('#ui_txt_addressLine1').val(result.Data[i].Address1);
                            $('#ui_txt_addressLine2').val(result.Data[i].Address2);
                            $('#ui_txt_postalCode').val(result.Data[i].PostalCode);
                            $('#ui_txt_phone').val(result.Data[i].Phone);
                            $('#ui_txt_fax').val(result.Data[i].Fax);
                            $('#ui_txt_email').val(result.Data[i].PrimaryEmailId);
                            $("#ui_txt_medicalSpecialty").val(result.Data[i].MedicalSpecialty);
                            noOfCharactersLeft(result.Data[i].MedicalSpecialty, 'ui_txt_medicalSpecialty');
                            $("#ui_txt_boardcrtification").val(result.Data[i].BoardCertification);
                            noOfCharactersLeft(result.Data[i].BoardCertification, 'ui_txt_boardcrtification');
                            $("#ui_txt_medicalLicense").val(result.Data[i].MedicalLicense);
                            noOfCharactersLeft(result.Data[i].MedicalLicense, 'ui_txt_medicalLicense');                           
                            var isParticipatedinaCompany = result.Data[i].IsCompanySponsoredtrial;
                            if (result.Data[i].IsCompanySponsoredtrial !== null) {
                                isParticipatedinaCompany === true ? $("#ui_ddl_isParticipatedinaCompanysponsoredtrial").data('kendoDropDownList').value("Yes") : $("#ui_ddl_isParticipatedinaCompanysponsoredtrial").data('kendoDropDownList').value("No");
                            }
                            if (isParticipatedinaCompany === true) {
                                $('#Iscompanysponsoredtrial').show();
                                $('#IsNotcompanysponsoredtrial').hide();
                                $("#ui_txt_drugname").val(result.Data[i].DrugName);
                                noOfCharactersLeft(result.Data[i].DrugName, 'ui_txt_drugname');
                                $("#ui_txt_protocolNumbers").val(result.Data[i].ProtocolNumber);
                                noOfCharactersLeft(result.Data[i].ProtocolNumber, 'ui_txt_protocolNumbers');
                                $("#ui_txt_datesoftrialparticipation").val(result.Data[i].TrialParticipation);
                                noOfCharactersLeft(result.Data[i].TrialParticipation, 'ui_txt_datesoftrialparticipation');
                            }
                            else if (isParticipatedinaCompany === false) {
                                $('#Iscompanysponsoredtrial').hide();
                                $('#IsNotcompanysponsoredtrial').show();
                            }
                            else {
                                $('#Iscompanysponsoredtrial').hide();
                                $('#IsNotcompanysponsoredtrial').hide();
                            }

                            var IsreceivedGCPtraining = result.Data[i].IsOtherTrainingsReceived;
                            if (result.Data[i].IsOtherTrainingsReceived !== null) {
                                IsreceivedGCPtraining === true ? $("#ui_ddl_IsreceivedGCPtraining").data('kendoDropDownList').value("Yes") : $("#ui_ddl_IsreceivedGCPtraining   ").data('kendoDropDownList').value("No");
                            }
                            if (IsreceivedGCPtraining === true) {
                                $('#ifReceivedGCPtrainingYes').show();
                                $("#ui_txt_lastGCPtraining").val(result.Data[i].LastTrainingDetails);
                                noOfCharactersLeft(result.Data[i].LastTrainingDetails, 'ui_txt_lastGCPtraining');
                                $('#ui_txt_typeoftrainingreceived').val(result.Data[i].TypeOfTraining);
                                noOfCharactersLeft(result.Data[i].TypeOfTraining, 'ui_txt_typeoftrainingreceived');
                            }
                            else {
                                $('#ifReceivedGCPtrainingYes').hide();
                            }

                            $('#ui_txt_listtrialexperience').val(result.Data[i].TrialExperiences);
                            noOfCharactersLeft(result.Data[i].TrialExperiences, 'ui_txt_listtrialexperience');
                            $('#ui_txt_numberofongoingclinicaltrials').val(result.Data[i].NumberOfOngoingTrials);
                            noOfCharactersLeft(result.Data[i].NumberOfOngoingTrials, 'ui_txt_numberofongoingclinicaltrials');

                            var isInspectedbyaHealthAuth = result.Data[i].IsSiteInspectedByHealthAuthority;
                            if (result.Data[i].IsSiteInspectedByHealthAuthority !== null) {
                                isInspectedbyaHealthAuth === true ? $("#ui_ddl_isInspectedbyaHealthAuthority").data('kendoDropDownList').value("Yes") : $("#ui_ddl_isInspectedbyaHealthAuthority").data('kendoDropDownList').value("No");
                            }
                            if (isInspectedbyaHealthAuth === true) {
                                $('#ifHealthAuthorityYes').show();

                                $('#ui_txt_whichhealthauthority').val(result.Data[i].NameOfHealthAuthority);
                                noOfCharactersLeft(result.Data[i].NameOfHealthAuthority, 'ui_txt_whichhealthauthority');
                                //need to check date
                                $("#ui_dt_dateoflastinspection").data("kendoDatePicker").value(result.Data[i].DateOflastInspection);
                            }
                            else {
                                $('#ifHealthAuthorityYes').hide();
                            }
                            var isinspectedbytheFDA = result.Data[i].IsSiteInspectedByFda;
                            if (result.Data[i].IsSiteInspectedByFda !== null) {
                                isinspectedbytheFDA === true ? $("#ui_ddl_isinspectedbytheFDA").data('kendoDropDownList').value("Yes") : $("#ui_ddl_isinspectedbytheFDA").data('kendoDropDownList').value("No");
                            }
                            if (isinspectedbytheFDA === true) {
                                $('#ifInspectedHealthYes').show();
                                //need to check date
                                $("#ui_dt_dateofinspection").data("kendoDatePicker").value(result.Data[i].DateOfFdainspection);
                                var Isfda = result.Data[i].Isfda483formIssued;
                                if (result.Data[i].Isfda483formIssued !== null) {
                                    Isfda === true ? $("#ui_ddl_fDAIssue").data('kendoDropDownList').value("Yes") : $("#ui_ddl_fDAIssue").data('kendoDropDownList').value("No");
                                }
                                if (Isfda === true) {
                                    $('#mainObservation').show();

                                    $("#ui_txt_detailsofthemainobservations").val(result.Data[i].DetailsOfObservation);
                                    noOfCharactersLeft(result.Data[i].DetailsOfObservation, 'ui_txt_detailsofthemainobservations');

                                }
                                else {
                                    $('#mainObservation').hide();
                                }
                            }
                            else {
                                $('#ifInspectedHealthYes').hide();
                            }
                            var IsCooperative = result.Data[i].IsCooperativeGroupStudy;
                            if (result.Data[i].IsCooperativeGroupStudy !== null)
                                IsCooperative === true ? $("#ui_ddl_isCooperativeGroupStudy").data('kendoDropDownList').value("Yes") : $("#ui_ddl_isCooperativeGroupStudy").data('kendoDropDownList').value("No");
                            if (IsCooperative === true) {
                                $('#cooperativeGroupName').show();
                                $("#ui_ddl_cooperativeGroupName").data('kendoDropDownList').value(result.Data[i].CooperativeGroupName);
                            }
                            else {
                                $('#cooperativeGroupName').hide();
                            }
                            var physicianNetworkStudy = result.Data[i].IsPhysicianNetworkStudy;
                            if (result.Data[i].IsPhysicianNetworkStudy !== null )
                                physicianNetworkStudy === true ? $("#ui_ddl_physicianNetworkStudy").data('kendoDropDownList').value("Yes") : $("#ui_ddl_physicianNetworkStudy").data('kendoDropDownList').value("No");
                            if (physicianNetworkStudy === true) {
                                $('#physicianNetworkName').show();
                                $("#ui_txtPhysicianNetworkName").val(result.Data[i].PhysicianNetworkName);
                                noOfCharactersLeft(result.Data[i].PhysicianNetworkName, 'ui_txtPhysicianNetworkName');
                            }
                            else {
                                $('#physicianNetworkName').hide();
                            }
                            var isGovernmentSupportProvided = result.Data[i].IsGovernmentSupportProvided;
                            if (result.Data[i].IsGovernmentSupportProvided !== null)
                             isGovernmentSupportProvided === true ? $("#ui_ddl_isGovernmentSupportProvided").data('kendoDropDownList').value("Yes") : $("#ui_ddl_isGovernmentSupportProvided").data('kendoDropDownList').value("No");
                            if (isGovernmentSupportProvided === true) {
                                $('#govtSupportDesc').show();

                                $("#ui_txt_GovernmentSupportDescription").val(result.Data[i].SupportDescription);
                                noOfCharactersLeft(result.Data[i].SupportDescription, 'ui_txt_GovernmentSupportDescription');
                            }
                            else {
                                $('#govtSupportDesc').hide();
                            }
                            var issupportbeprovidedfromothersource = result.Data[i].IsSupportProvidedByOtherSources;
                            if (issupportbeprovidedfromothersource !== null)
                            issupportbeprovidedfromothersource === true ? $("#ui_ddl_issupportbeprovidedfromothersource").data('kendoDropDownList').value("Yes") : $("#ui_ddl_issupportbeprovidedfromothersource").data('kendoDropDownList').value("No");
                            if (issupportbeprovidedfromothersource === true) {
                                $('#nonCompanySupportSources').show();
                                $("#ui_txt_nonCompanySupportSources").val(result.Data[i].SupportSources);
                                noOfCharactersLeft(result.Data[i].SupportSources, 'ui_txt_nonCompanySupportSources');
                            }
                            else {
                                $('#nonCompanySupportSources').hide();
                            }

                        }
                        
                        else if(result.Data[i].CategoryID === 2) {

                            $('#ui_ddl_payee_salutation').data('kendoDropDownList').value(result.Data[i].Salutation);
                            $('#ui_txt_payee_firstName').val(result.Data[i].FirstName);
                            $('#ui_txt_payee_lastName').val(result.Data[i].LastName);
                            $('#ui_ddl_payee_suffix').data('kendoDropDownList').value(result.Data[i].Suffix);
                            $('#ui_txt_payee_title').val(result.Data[i].Title);
                            if (result.Data[i].Degree !== null) {
                                var SeconddegreeArray = result.Data[i].Degree.split(',');
                                $("#ui_payee_multiselect_credentials").getKendoMultiSelect().value(SeconddegreeArray);
                            }
                            $('#ui_txt_payee_institution').val(result.Data[i].Institution);
                            $('#ui_txt_payee_institutiontax').val(result.Data[i].TaxID);
                            $('#ui_ddl_payee_country').data('kendoDropDownList').value(result.Data[i].CountryId);
                            $('#ui_ddl_payee_state').data('kendoDropDownList').value(result.Data[i].StateId);
                            $('#ui_ddl_payee_city').data('kendoDropDownList').value(result.Data[i].CityId);
                            $('#ui_txt_payee_addressLine1').val(result.Data[i].Address1);
                            $('#ui_txt_payee_addressLine2').val(result.Data[i].Address2);
                            $('#ui_txt_payee_postalCode').val(result.Data[i].PostalCode);
                            $('#ui_txt_payee_phone').val(result.Data[i].Phone);
                            $('#ui_txt_payee_fax').val(result.Data[i].Fax);
                            $('#ui_txt_payee_email').val(result.Data[i].PrimaryEmailId);

                        }

                        else if (result.Data[i].CategoryID === 3) {

                            $('#ui_ddl_shipment_salutation').data('kendoDropDownList').value(result.Data[i].Salutation);
                            $('#ui_txt_shipment_firstName').val(result.Data[i].FirstName);
                            $('#ui_txt_shipment_lastName').val(result.Data[i].LastName);
                            $('#ui_ddl_shipment_suffix').data('kendoDropDownList').value(result.Data[i].Suffix);
                            $('#ui_txt_shipment_title').val(result.Data[i].Title);
                            if (result.Data[i].Degree !== null) {
                                var ThirddegreeArray = result.Data[i].Degree.split(',');
                                $("#ui_shipment_multiselect_credentials").getKendoMultiSelect().value(ThirddegreeArray);
                            }
                            $('#ui_txt_shipment_Institution').val(result.Data[i].Institution);                            
                            $('#ui_ddl_shipment_country').data('kendoDropDownList').value(result.Data[i].CountryId);
                            $('#ui_ddl_shipment_state').data('kendoDropDownList').value(result.Data[i].StateId);
                            $('#ui_ddl_shipment_city').data('kendoDropDownList').value(result.Data[i].CityId);
                            $('#ui_txt_shipment_addressLine1').val(result.Data[i].Address1);
                            $('#ui_txt_shipment_addressLine2').val(result.Data[i].Address2);
                            $('#ui_txt_shipment_postalCode').val(result.Data[i].PostalCode);
                            $('#ui_txt_shipment_phone').val(result.Data[i].Phone);
                            $('#ui_txt_shipment_fax').val(result.Data[i].Fax);
                            $('#ui_txt_shipment_email').val(result.Data[i].PrimaryEmailId);

                        }

                        else if (result.Data[i].CategoryID === 4) {

                            $('#ui_ddl_contracts_salutation').data('kendoDropDownList').value(result.Data[i].Salutation);
                            $('#ui_txt_contracts_firstName').val(result.Data[i].FirstName);
                            $('#ui_txt_contracts_lastName').val(result.Data[i].LastName);
                            $('#ui_ddl_contracts_suffix').data('kendoDropDownList').value(result.Data[i].Suffix);
                            $('#ui_txt_contracts_title').val(result.Data[i].Title);
                            if (result.Data[i].Degree !== null) {
                                var FourthdegreeArray = result.Data[i].Degree.split(',');
                                $("#ui_contracts_multiselect_credentials").getKendoMultiSelect().value(FourthdegreeArray);
                            }
                            $('#ui_txt_contracts_Institution').val(result.Data[i].Institution);
                            $('#ui_ddl_contracts_country').data('kendoDropDownList').value(result.Data[i].CountryId);
                            $('#ui_ddl_contracts_state').data('kendoDropDownList').value(result.Data[i].StateId);
                            $('#ui_ddl_contracts_city').data('kendoDropDownList').value(result.Data[i].CityId);
                            $('#ui_txt_contracts_addressLine1').val(result.Data[i].Address1);
                            $('#ui_txt_contracts_addressLine2').val(result.Data[i].Address2);
                            $('#ui_txt_contracts_postalCode').val(result.Data[i].PostalCode);
                            $('#ui_txt_contracts_phone').val(result.Data[i].Phone);
                            $('#ui_txt_contracts_fax').val(result.Data[i].Fax);
                            $('#ui_txt_contracts_email').val(result.Data[i].PrimaryEmailId);

                        }
                        else {
                            $('#ui_ddl_coordinator_salutation').data('kendoDropDownList').value(result.Data[i].Salutation);
                            $('#ui_txt_coordinator_firstName').val(result.Data[i].FirstName);
                            $('#ui_txt_coordinator_lastName').val(result.Data[i].LastName);
                            $('#ui_ddl_coordinator_suffix').data('kendoDropDownList').value(result.Data[i].Suffix);
                            $('#ui_txt_coordinator_title').val(result.Data[i].Title);
                            if (result.Data[i].Degree !== null) {
                                var DefaultdegreeArray = result.Data[i].Degree.split(',');
                                $("#ui_coordinator_multiselect_credentials").getKendoMultiSelect().value(DefaultdegreeArray);
                            }
                            $('#ui_txt_coordinator_Institution').val(result.Data[i].Institution);
                            $('#ui_ddl_coordinator_country').data('kendoDropDownList').value(result.Data[i].CountryId);
                            $('#ui_ddl_coordinator_state').data('kendoDropDownList').value(result.Data[i].StateId);
                            $('#ui_ddl_coordinator_city').data('kendoDropDownList').value(result.Data[i].CityId);
                            $('#ui_txt_coordinator_addressLine1').val(result.Data[i].Address1);
                            $('#ui_txt_coordinator_addressLine2').val(result.Data[i].Address2);
                            $('#ui_txt_coordinator_postalCode').val(result.Data[i].PostalCode);
                            $('#ui_txt_coordinator_phone').val(result.Data[i].Phone);
                            $('#ui_txt_coordinator_fax').val(result.Data[i].Fax);
                            $('#ui_txt_coordinator_email').val(result.Data[i].PrimaryEmailId);
                        }
                    }
                }
                //end
            },
            failure: function (response) {
                popupNotification.show("There appears to be an error,please retry or contact Administrator if issue persists.", "error");
            }
        });
    }
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
    var userName = $('#txtUserName').val();
    var userId = 0;

    if (mode === "Create") {

        GetUserDetailsByUserName();
    }
    function GetUserDetailsByUserName() {
        $.ajax({
            async: false,
            type: "POST",
            url: '/NewStudy/GetUserDetailsByUserName',
            data: { "userName": userName },
            success: function (result) {

                if (result !== null) {

                    userId = result.UserId;
                    $("#ui_txt_firstName").val(result.FirstName);
                    $("#ui_txt_lastName").val(result.LastName);
                    $("#ui_ddl_salutation").data('kendoDropDownList').value(result.Salutation);
                    $("#ui_ddl_suffix").data('kendoDropDownList').value(result.Suffix);
                    $("#ui_txt_title").val(result.Title);
                    $("#ui_ddl_country").data('kendoDropDownList').value(result.CountryId);
                    $("#ui_ddl_state").data('kendoDropDownList').value(result.StateId);
                    $("#ui_ddl_city").data('kendoDropDownList').value(result.CityId);
                    $('#ui_txt_addressLine1').val(result.Address1);
                    $('#ui_txt_addressLine2').val(result.Address2);
                    $('#ui_txt_postalCode').val(result.Zip);
                    $('#ui_txt_phone').val(result.MobileNumber);
                    $('#ui_txt_fax').val(result.Fax);
                    $('#ui_txt_email').val(result.PrimaryEmailId);
                    $('#ui_txt_Institution').val(result.OrganizationName);
                }

            }
        });
        $.ajax({
            async: false,
            type: "POST",
            url: '/Register/GetUserCredentialsByUserId',
            data: { "userId": userId },
            success: function (result) {
                if (result !== null) {

                    var credential = [];
                    $.each(result.Data, function (index, item) {
                        credential.push(result.Data[index].CredentialId);
                    });
                    $("#ui_multiselect_credentials").getKendoMultiSelect().value(credential);

                }
            }
        });
    }
    var EventName = '';
    $("#ui_btnSaveandExit, #ui_btnSaveandExitEnd").click(function () {
        EventName = "SaveandExit";
        SavePersonalandResearchDetails(EventName);
    });

    $("#ui_btnSaveandContinue, #ui_btnSaveandContinueEnd").click(function () {
        EventName = "SaveandContinue";
        ValidateMandatoryFields();
        SavePersonalandResearchDetails(EventName);
    });

    function ValidateMandatoryFields() {
        $(".error").remove();
        retval = true;

        if ($('#ui_txt_firstName').val().length <= 0) {
            $('#firstName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>First Name is required</div>');
            retval = false;
        }
        if ($('#ui_txt_lastName').val().length <= 0) {
            $('#lastName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Last Name is required</div>');
            retval = false;
        }
        if ($("#ui_multiselect_credentials").data("kendoMultiSelect").value().length <= 0) {
            $('#multiselectCredentials').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Degree is required</div>');
            retval = false;
        }

        if ($('#ui_txt_Institution').val().length <= 0) {
            $('#institution').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Institution is required</div>');
            retval = false;
        }
        if ($('#ui_ddl_country').val() === 'Select' || $('#ui_ddl_country').val() === "") {
            $('#country').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Country is required</div>');
            retval = false;
        }
        if ($('#ui_ddl_country').val() !== 'Select' || $('#ui_ddl_country').val() !== "") {
            if ($('#ui_ddl_state').val() === 'Select' || $('#ui_ddl_state').val() === "") {
                $('#state').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>State/Province is required</div>');
                retval = false;
            }
        }
        if ($('#ui_ddl_state').val() !== 'Select' || $('#ui_ddl_state').val() !== "") {
            if ($('#ui_ddl_city').val() === 'Select' || $('#ui_ddl_city').val() === "") {
                $('#city').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>City is required</div>');
                retval = false;
            }
        }
        if ($('#ui_txt_addressLine1').val().length <= 0) {
            $('#addressLine1').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Address Line 1 is required</div>');
            retval = false;
        }
        if ($('#ui_txt_postalCode').val().length <= 0) {
            $('#postalCode').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Zip/Postal Code is required</div>');
            retval = false;
        }
        if ($('#ui_txt_phone').val().length <= 0) {
            $('#phonePI').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Phone is required</div>');
            retval = false;
        }
        if ($('#ui_txt_email').val().length <= 0) {
            $('#email').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Email is required</div>');
            retval = false;
        }
        if ($('#ui_ddl_isParticipatedinaCompanysponsoredtrial').val() === 'Select' || $('#ui_ddl_isParticipatedinaCompanysponsoredtrial').val() === "") {
            $('#isParticipatedinaCompanysponsoredtrial').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Have you ever participated in a '+ appName +' sponsored trial is required</div>');
            retval = false;
        }
        if ($('#ui_ddl_isInspectedbyaHealthAuthority').val() === 'Select' || $('#ui_ddl_isInspectedbyaHealthAuthority').val() === "") {
            $('#isInspectedByAHealthAuthority').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Have you or your site been inspected by a Health Authority, IRB/EC is required</div>');
            retval = false;
        }
        if ($('#ui_ddl_isinspectedbytheFDA').val() === 'Select' || $('#ui_ddl_isinspectedbytheFDA').val() === "") {
            $('#isInspectedByTheFDA').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Have you or your site been inspected by the FDA is required</div>');
            retval = false;
        }
        if ($('#ui_ddl_isCooperativeGroupStudy').val() === 'Select' || $('#ui_ddl_isCooperativeGroupStudy').val() === "") {
            $('#isCooperativeGroupStudy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Cooperative Group Study is required</div>');
            retval = false;
        }
        if ($('#ui_ddl_physicianNetworkStudy').val() === 'Select' || $('#ui_ddl_physicianNetworkStudy').val() === "") {
            $('#physicianNetworkStudy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Physician Network Study is required</div>');
            retval = false;
        }
        if ($('#ui_ddl_isGovernmentSupportProvided').val() === 'Select' || $('#ui_ddl_isGovernmentSupportProvided').val() === "") {
            $('#isGovernmentSupportProvided').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Will Government Support be Provided is required</div>');
            retval = false;
        }
        if ($('#ui_ddl_issupportbeprovidedfromothersource').val() === 'Select' || $('#ui_ddl_issupportbeprovidedfromothersource').val() === "") {
            $('#isSupportBeProvidedFromOtherSource').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Will support be provided from other sources is required</div>');
            retval = false;
        }
        if ($('#ui_txt_medicalSpecialty').val().length <= 0) {
            $('#ui_txt_medicalSpecialty').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Medical Specialty is required</div>');
            retval = false;
        }
        if ($('#ui_txt_boardcrtification').val().length <= 0) {
            $('#ui_txt_boardcrtification').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Board Certification or equivalent according to local regulations is required</div>');
            retval = false;
        }
        if ($('#ui_txt_medicalLicense').val().length <= 0) {
            $('#ui_txt_medicalLicense').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Medical License/proof of right to practice (eg Medical License number), or equivalent according to local regulations is required</div>');
            retval = false;
        }
        if ($("#ui_ddl_isParticipatedinaCompanysponsoredtrial").val() === 'No') {

            var IsreceivedGCPtraining = $('#ui_ddl_IsreceivedGCPtraining').val();
            if (IsreceivedGCPtraining === 'Select' || IsreceivedGCPtraining === "") {
                $('#isReceivedGCPTraining').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Have you received GCP training the past 3 years is required</div>');
                retval = false;
            }
            if ($('#ui_txt_listtrialexperience').val().length <= 0) {
                $('#ui_txt_listtrialexperience').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>List trial experience is required</div>');
                retval = false;
            }
        }

        if ($('#ui_txt_numberofongoingclinicaltrials').val().length <= 0) {
            $('#ui_txt_numberofongoingclinicaltrials').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Number of ongoing clinical trials is required</div>');
            retval = false;
        }
        if ($("#ui_ddl_isCooperativeGroupStudy").val() === 'Yes') {
            if ($("#ui_ddl_cooperativeGroupName").val().length <= 0) {
                $('#cooperativeGroup').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Cooperative Group Name is required</div>');
                retval = false;
            }
        }
        if ($("#ui_ddl_physicianNetworkStudy").val() === 'Yes') {
            if ($("#ui_txtPhysicianNetworkName").val().length <= 0) {
                $('#ui_txtPhysicianNetworkName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Physician Network Name is required</div>');
                retval = false;
            }
        }
        if ($("#ui_ddl_isGovernmentSupportProvided").val() === 'Yes') {
            if ($("#ui_txt_GovernmentSupportDescription").val().length <= 0) {
                $('#ui_txt_GovernmentSupportDescription').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Government Support Description is required</div>');
                retval = false;
            }
        }
        if ($("#ui_ddl_issupportbeprovidedfromothersource").val() === 'Yes') {
            if ($("#ui_txt_nonCompanySupportSources").val().length <= 0) {
                $('#ui_txt_nonCompanySupportSources').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Non-' + appName +' Support Sources is required</div>');
                retval = false;
            }
        }
        if ($("#files").closest(".k-upload").find(".k-file").length <= 0) {
            $('#uploadFile').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please upload</div>');
            retval = false;
        }

    }

    function getFormattedDate(date) {

        var startdate = new Date(date);
        var year = startdate.getFullYear();
        var month = (1 + startdate.getMonth()).toString();
        month = month.length > 1 ? month : '0' + month;
        var day = startdate.getDate().toString();
        day = day.length > 1 ? day : '0' + day;
        return year + '-' + month + '-' + day;
    }


    function SavePersonalandResearchDetails(EventName) {        
        if (validator.validate() && retval === true) {
            var lsPrincipalInvestigator = new Array();
            objPayeeInformationDetails = new Object();
            objPersonalandResearchDetails = new Object();
            objPersonalandResearchDetails.CategoryID = 1;
            objPersonalandResearchDetails.Salutation = $('#ui_ddl_salutation').val();
            objPersonalandResearchDetails.FirstName = $('#ui_txt_firstName').val();
            objPersonalandResearchDetails.LastName = $('#ui_txt_lastName').val();
            objPersonalandResearchDetails.Suffix = $('#ui_ddl_suffix').val();
            objPersonalandResearchDetails.Title = $('#ui_txt_title').val();
            if ($('#ui_multiselect_credentials').val() !== null)
                objPersonalandResearchDetails.Degree = $('#ui_multiselect_credentials').val().toString();//tostring will give result with comma separate
            objPersonalandResearchDetails.Npinumber = $('#ui_txt_npi').val();
            objPersonalandResearchDetails.Institution = $('#ui_txt_Institution').val();
            objPersonalandResearchDetails.CountryId = $('#ui_ddl_country').val();
            objPersonalandResearchDetails.StateId = $('#ui_ddl_state').val();
            objPersonalandResearchDetails.CityId = $('#ui_ddl_city').val();
            objPersonalandResearchDetails.Address1 = $('#ui_txt_addressLine1').val();
            objPersonalandResearchDetails.Address2 = $('#ui_txt_addressLine2').val();
            objPersonalandResearchDetails.PostalCode = $('#ui_txt_postalCode').val();
            objPersonalandResearchDetails.Phone = $('#ui_txt_phone').val();
            objPersonalandResearchDetails.Fax = $('#ui_txt_fax').val();
            objPersonalandResearchDetails.PrimaryEmailId = $('#ui_txt_email').val();
            lsPrincipalInvestigator.push(objPersonalandResearchDetails);
            //Submit Protocol start
            if ($('#pITaskStatus').val().toUpperCase() === $('#pIsubmitprotocol').val().toUpperCase() || $('#TaskName').val() === "Resubmit Protocol") {
                //Payee Information start
                objPayeeInformationDetails.CategoryID = 2;
                objPayeeInformationDetails.Salutation = $('#ui_ddl_payee_salutation').val();
                objPayeeInformationDetails.FirstName = $('#ui_txt_payee_firstName').val();
                objPayeeInformationDetails.LastName = $('#ui_txt_payee_lastName').val();
                objPayeeInformationDetails.Suffix = $('#ui_ddl_payee_suffix').val();
                objPayeeInformationDetails.Title = $('#ui_txt_payee_title').val();
                if ($('#ui_payee_multiselect_credentials').val() !== null)
                    objPayeeInformationDetails.Degree = $('#ui_payee_multiselect_credentials').val().toString();//tostring will give result with comma separate           
                objPayeeInformationDetails.Institution = $('#ui_txt_payee_institution').val();
                objPayeeInformationDetails.TaxID = $('#ui_txt_payee_institutiontax').val();
                objPayeeInformationDetails.CountryId = $('#ui_ddl_payee_country').val();
                objPayeeInformationDetails.StateId = $('#ui_ddl_payee_state').val();
                objPayeeInformationDetails.CityId = $('#ui_ddl_payee_city').val();
                objPayeeInformationDetails.Address1 = $('#ui_txt_payee_addressLine1').val();
                objPayeeInformationDetails.Address2 = $('#ui_txt_payee_addressLine2').val();
                objPayeeInformationDetails.PostalCode = $('#ui_txt_payee_postalCode').val();
                objPayeeInformationDetails.Phone = $('#ui_txt_payee_phone').val();
                objPayeeInformationDetails.Fax = $('#ui_txt_payee_fax').val();
                objPayeeInformationDetails.PrimaryEmailId = $('#ui_txt_payee_email').val();
                lsPrincipalInvestigator.push(objPayeeInformationDetails);
                //Payee Information End

                //Drugshipment Information Start
                objdrugshipmentInformationDetails = new Object();
                objdrugshipmentInformationDetails.CategoryID = 3;
                objdrugshipmentInformationDetails.Salutation = $('#ui_ddl_shipment_salutation').val();
                objdrugshipmentInformationDetails.FirstName = $('#ui_txt_shipment_firstName').val();
                objdrugshipmentInformationDetails.LastName = $('#ui_txt_shipment_lastName').val();
                objdrugshipmentInformationDetails.Suffix = $('#ui_ddl_shipment_suffix').val();
                objdrugshipmentInformationDetails.Title = $('#ui_txt_shipment_title').val();
                if ($('#ui_shipment_multiselect_credentials').val() !== null)
                    objdrugshipmentInformationDetails.Degree = $('#ui_shipment_multiselect_credentials').val().toString();//tostring will give result with comma separate           
                objdrugshipmentInformationDetails.Institution = $('#ui_txt_shipment_Institution').val();
                objdrugshipmentInformationDetails.CountryId = $('#ui_ddl_shipment_country').val();
                objdrugshipmentInformationDetails.StateId = $('#ui_ddl_shipment_state').val();
                objdrugshipmentInformationDetails.CityId = $('#ui_ddl_shipment_city').val();
                objdrugshipmentInformationDetails.Address1 = $('#ui_txt_shipment_addressLine1').val();
                objdrugshipmentInformationDetails.Address2 = $('#ui_txt_shipment_addressLine2').val();
                objdrugshipmentInformationDetails.PostalCode = $('#ui_txt_shipment_postalCode').val();
                objdrugshipmentInformationDetails.Phone = $('#ui_txt_shipment_phone').val();
                objdrugshipmentInformationDetails.Fax = $('#ui_txt_shipment_fax').val();
                objdrugshipmentInformationDetails.PrimaryEmailId = $('#ui_txt_shipment_email').val();
                lsPrincipalInvestigator.push(objdrugshipmentInformationDetails);
                //Drugshipment Information End

                //Contracts Contact Information Start
                objcontractsInformationDetails = new Object();
                objcontractsInformationDetails.CategoryID = 4;
                objcontractsInformationDetails.Salutation = $('#ui_ddl_contracts_salutation').val();
                objcontractsInformationDetails.FirstName = $('#ui_txt_contracts_firstName').val();
                objcontractsInformationDetails.LastName = $('#ui_txt_contracts_lastName').val();
                objcontractsInformationDetails.Suffix = $('#ui_ddl_contracts_suffix').val();
                objcontractsInformationDetails.Title = $('#ui_txt_contracts_title').val();
                if ($('#ui_contracts_multiselect_credentials').val() !== null)
                    objcontractsInformationDetails.Degree = $('#ui_contracts_multiselect_credentials').val().toString();//tostring will give result with comma separate           
                objcontractsInformationDetails.Institution = $('#ui_txt_contracts_Institution').val();
                objcontractsInformationDetails.CountryId = $('#ui_ddl_contracts_country').val();
                objcontractsInformationDetails.StateId = $('#ui_ddl_contracts_state').val();
                objcontractsInformationDetails.CityId = $('#ui_ddl_contracts_city').val();
                objcontractsInformationDetails.Address1 = $('#ui_txt_contracts_addressLine1').val();
                objcontractsInformationDetails.Address2 = $('#ui_txt_contracts_addressLine2').val();
                objcontractsInformationDetails.PostalCode = $('#ui_txt_contracts_postalCode').val();
                objcontractsInformationDetails.Phone = $('#ui_txt_contracts_phone').val();
                objcontractsInformationDetails.Fax = $('#ui_txt_contracts_fax').val();
                objcontractsInformationDetails.PrimaryEmailId = $('#ui_txt_contracts_email').val();
                lsPrincipalInvestigator.push(objcontractsInformationDetails);
                //Contracts Contact Information End

                //Study Coordinatort Information Start
                objcoordinatorInformationDetails = new Object();
                objcoordinatorInformationDetails.CategoryID = 5;
                objcoordinatorInformationDetails.Salutation = $('#ui_ddl_coordinator_salutation').val();
                objcoordinatorInformationDetails.FirstName = $('#ui_txt_coordinator_firstName').val();
                objcoordinatorInformationDetails.LastName = $('#ui_txt_coordinator_lastName').val();
                objcoordinatorInformationDetails.Suffix = $('#ui_ddl_coordinator_suffix').val();
                objcoordinatorInformationDetails.Title = $('#ui_txt_coordinator_title').val();
                if ($('#ui_coordinator_multiselect_credentials').val() !== null)
                    objcoordinatorInformationDetails.Degree = $('#ui_coordinator_multiselect_credentials').val().toString();//tostring will give result with comma separate           
                objcoordinatorInformationDetails.Institution = $('#ui_txt_coordinator_Institution').val();
                objcoordinatorInformationDetails.CountryId = $('#ui_ddl_coordinator_country').val();
                objcoordinatorInformationDetails.StateId = $('#ui_ddl_coordinator_state').val();
                objcoordinatorInformationDetails.CityId = $('#ui_ddl_coordinator_city').val();
                objcoordinatorInformationDetails.Address1 = $('#ui_txt_coordinator_addressLine1').val();
                objcoordinatorInformationDetails.Address2 = $('#ui_txt_coordinator_addressLine2').val();
                objcoordinatorInformationDetails.PostalCode = $('#ui_txt_coordinator_postalCode').val();
                objcoordinatorInformationDetails.Phone = $('#ui_txt_coordinator_phone').val();
                objcoordinatorInformationDetails.Fax = $('#ui_txt_coordinator_fax').val();
                objcoordinatorInformationDetails.PrimaryEmailId = $('#ui_txt_coordinator_email').val();
                lsPrincipalInvestigator.push(objcoordinatorInformationDetails);
                //Study Coordinator Information End
            }
            else
                objPayeeInformationDetails = null;
            //Payee Information End
            //Submit Protocol start

            objnewstudy = new Object();
            var StudyId = $('#StudyId').val();
            var Mode = $('#mode').val();
            objnewstudy.StudyId = StudyId;
            objnewstudy.CountryName = $('#ui_ddl_country').data("kendoDropDownList").text();
            objnewstudy.StateName = $('#ui_ddl_state').data("kendoDropDownList").text();
            objnewstudy.CityName = $('#ui_ddl_city').data("kendoDropDownList").text();
            objnewstudy.MedicalSpecialty = $("#ui_txt_medicalSpecialty").val();
            objnewstudy.BoardCertification = $("#ui_txt_boardcrtification").val();
            objnewstudy.MedicalLicense = $("#ui_txt_medicalLicense").val();
            if ($("#ui_ddl_isParticipatedinaCompanysponsoredtrial").val() !== "") {
                var isParticipatedinaCompany = $("#ui_ddl_isParticipatedinaCompanysponsoredtrial").val();
                objnewstudy.IsCompanySponsoredtrial = isParticipatedinaCompany === 'Yes' ? true : false;
            }
            if (objnewstudy.IsCompanySponsoredtrial === true) {
                objnewstudy.DrugName = $("#ui_txt_drugname").val();
                objnewstudy.ProtocolNumber = $("#ui_txt_protocolNumbers").val();
                objnewstudy.TrialParticipation = $("#ui_txt_datesoftrialparticipation").val();

                //update null for no fields
                objnewstudy.IsOtherTrainingsReceived = false;
                objnewstudy.LastTrainingDetails = null;
                objnewstudy.TypeOfTraining = null;

            }
            else {
                objnewstudy.DrugName = null;
                objnewstudy.ProtocolNumber = null;
                objnewstudy.TrialParticipation = null;
                if ($('#ui_ddl_IsreceivedGCPtraining').val() !== "") {
                    var IsreceivedGCPtraining = $('#ui_ddl_IsreceivedGCPtraining').val();
                    objnewstudy.IsOtherTrainingsReceived = IsreceivedGCPtraining === 'Yes' ? true : false;
                }
                if (objnewstudy.IsOtherTrainingsReceived === true) {
                    objnewstudy.LastTrainingDetails = $('#ui_txt_lastGCPtraining').val();
                    objnewstudy.TypeOfTraining = $('#ui_txt_typeoftrainingreceived').val();
                }
                else {
                    objnewstudy.LastTrainingDetails = null;
                    objnewstudy.TypeOfTraining = null;

                }
                objnewstudy.TrialExperiences = $('#ui_txt_listtrialexperience').val();
            }
            objnewstudy.NumberOfOngoingTrials = $('#ui_txt_numberofongoingclinicaltrials').val();
            if ($('#ui_ddl_isInspectedbyaHealthAuthority').val() !== "") {
                var isInspectedbyaHealthAuth = $('#ui_ddl_isInspectedbyaHealthAuthority').val();
                objnewstudy.IsSiteInspectedByHealthAuthority = isInspectedbyaHealthAuth === 'Yes' ? true : false;
            }

            if (objnewstudy.IsSiteInspectedByHealthAuthority === true) {
                objnewstudy.NameOfHealthAuthority = $('#ui_txt_whichhealthauthority').val();
                objnewstudy.DateOflastInspection = $("#ui_dt_dateoflastinspection").val();
            }
            else {
                objnewstudy.NameOfHealthAuthority = null;
                objnewstudy.DateOflastInspection = null;
            }

            if ($('#ui_ddl_isinspectedbytheFDA').val() !== "") {
                var isinspectedbytheFDA = $('#ui_ddl_isinspectedbytheFDA').val();
                objnewstudy.IsSiteInspectedByFda = isinspectedbytheFDA === 'Yes' ? true : false;
            }
            if (objnewstudy.IsSiteInspectedByFda === true) {

                var dt = $("#ui_dt_dateofinspection").val();
                var formattedfdadate = getFormattedDate(dt);
                objnewstudy.DateOfFdainspection = formattedfdadate;
                var Isfda = $("#ui_ddl_fDAIssue").val();
                objnewstudy.Isfda483formIssued = Isfda === 'Yes' ? true : false;
                if (objnewstudy.Isfda483formIssued === true) {
                    objnewstudy.DetailsOfObservation = $("#ui_txt_detailsofthemainobservations").val();
                }
                else {
                    objnewstudy.DetailsOfObservation = null;
                }
            }
            else {
                objnewstudy.DateOfFdainspection = null;
                objnewstudy.Isfda483formIssued = false;
                objnewstudy.DetailsOfObservation = null;
            }

            if ($("#ui_ddl_isCooperativeGroupStudy").val() !== "") {
                var IsCooperative = $("#ui_ddl_isCooperativeGroupStudy").val();
                objnewstudy.IsCooperativeGroupStudy = IsCooperative === 'Yes' ? true : false;
            }
            if (objnewstudy.IsCooperativeGroupStudy === true) {
                objnewstudy.CooperativeGroupName = $('#ui_ddl_cooperativeGroupName').val();
            }
            else {
                objnewstudy.CooperativeGroupName = null;
            }

            if ($("#ui_ddl_physicianNetworkStudy").val() !== "") {
            var physicianNetworkStudy = $("#ui_ddl_physicianNetworkStudy").val();
                objnewstudy.IsPhysicianNetworkStudy = physicianNetworkStudy === 'Yes' ? true : false;
            }
            if (objnewstudy.IsPhysicianNetworkStudy) {
                objnewstudy.PhysicianNetworkName = $("#ui_txtPhysicianNetworkName").val();
            }
            else {
                objnewstudy.PhysicianNetworkName = null;
            }

            if ($("#ui_ddl_isGovernmentSupportProvided").val() !== "") {
            var isGovernmentSupportProvided = $("#ui_ddl_isGovernmentSupportProvided").val();
                objnewstudy.IsGovernmentSupportProvided = isGovernmentSupportProvided === 'Yes' ? true : false;
            }
            if (objnewstudy.IsGovernmentSupportProvided === true) {
                objnewstudy.SupportDescription = $("#ui_txt_GovernmentSupportDescription").val();
            }
            else {
                objnewstudy.SupportDescription = null;
            }
            if ($("#ui_ddl_issupportbeprovidedfromothersource").val() !== "") {
            var issupportbeprovidedfromothersource = $("#ui_ddl_issupportbeprovidedfromothersource").val();
                objnewstudy.IsSupportProvidedByOtherSources = issupportbeprovidedfromothersource === 'Yes' ? true : false;
            }
            if (objnewstudy.IsSupportProvidedByOtherSources === true) {
                objnewstudy.SupportSources = $("#ui_txt_nonCompanySupportSources").val();
            }
            else {
                objnewstudy.SupportSources = null;
            }

            $.ajax({
                async: false,
                type: "POST",
                url: "/NewStudy/CreateUpdatePersonalResearchdetails",
                data: { "newstudy": objnewstudy, "lspersonalandResearchDetails": lsPrincipalInvestigator, "mode": Mode },
                success: function (results) {
                    if (results.msgType === "Success") {
                        if (EventName === "SaveandExit") {
                            DestroySession();
                            opener.location.reload();
                            window.close();
                        }
                        else {
                            // window.location.href = "../NewStudy/RequestedSupport?StudyId=" + $('#StudyId').val() + '&&mode=' + $('#mode').val() + '&&StudyType=' + $('#studyType').val() + '&&piTaskStatus=' + $('#pITaskStatus').val();
                            obj = new Object();
                            obj.StudyId = $('#StudyId').val();
                            obj.mode = $('#mode').val();
                            obj.StudyType = $('#studyType').val();
                            obj.piTaskStatus = $('#pITaskStatus').val();
                            obj.TaskName = $('#TaskName').val();

                            $.ajax({
                                async: true,
                                type: "POST",
                                url: "/Login/OpenNewWindow",
                                data: { "obj": obj },
                                success: function (results) {
                                    if (results.data === "Success") {
                                        window.location.href = "/NewStudy/RequestedSupport";
                                    }
                                    else {
                                        popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
                                    }
                                }
                            });
                        }

                    }  
                    else {
                        popupNotification.show(results.msgType, "error");
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
                popupNotification.show("There appears to be an error,please retry or contact Administrator if issue persists.", "error");
            }
        });
    }
});