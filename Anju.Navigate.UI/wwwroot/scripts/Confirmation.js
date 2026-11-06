function onCancel() {
    opener.location.reload();
    window.close();
}

function StudyDetailsID() {
    return {
        studyId: $('#StudyId').val()
    };
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

if ($("#pITaskStatus").val() === RESUBMITPROPOSAL) {
    $('#taskHeading').text("Re-Submit Proposal");
    $('.border-right').removeClass('border-right');
    $('#deleteBtn,#deleteBtnEnd').hide();
}
else if ($('#TaskName').val() === RESUBMITPROTOCOL) {
    $('#taskHeading').text("Re-Submit Protocol");
    $('.border-right').removeClass('border-right');
    $('#deleteBtn,#deleteBtnEnd').hide();

}
if ($('#TaskName').val() === SUBMITPROTOCOL) {
    $('#taskHeading').text("Submit Protocol");
    $('.border-right').removeClass('border-right');
    $('#deleteBtn,#deleteBtnEnd').hide();
}

$(document).ready(function () {
    var state = "";
    var TitleofTrial = "";
    var mSLUserame = "";
    var taskStatus = "";
    var stage = "";

    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/GetStudyTaskDetails",
        data: { "studyId": $('#StudyId').val() },
        success: function (result) {
            if (result.Data.length > 0) {
                state = result.Data[0].State;
                TitleofTrial = result.Data[0].TitleofTrial;
                taskStatus = result.Data[0].TaskName;
                stage = result.Data[0].Stage;
            }
            else {
                popupNotification.show(result.msgType, "error");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            popupNotification.show('Error', "error");
        }
    });
    //$.ajax({
    //          async: true,
    //          type: "GET",
    //          url: "/TaskWorkFlow/GetMSLReviewDetailsByStudyId/",
    //          dataType: "json",
    //          data: { "StudyId": $('#StudyId').val() },
    //          success: function (result) {
    //              if (result.length > 0) {
    //                  mSLUserame = result[0].MsluserName;
    //              }
    //          },
    //          failure: function (response) {
    //              popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
    //          }
    //      });

    $.ajax({
        async: false,
        type: "POST",
        url: '/NewStudy/GetUserNameByUserTypeAndStudyId',
        data: { "studyId": $('#StudyId').val(), "userType": MSL },
        success: function (result) {
            if (result !== "") {
                mSLUserame = result;
            }
        }
    });

    $("#ui_btnSubmit, #ui_btnSubmitEnd").click(function () {
        SaveConfirmationDetails();
    });

    function SaveConfirmationDetails() {
        objnewstudy = new Object();
        objnewstudy.StudyId = $('#StudyId').val();
        objnewstudy.Stage = "Proposed";
        objnewstudy.ANJU_ChangedBy = $("#txtUserName").val();

        if (state === GMRCREQUESTEDRESUBMISSION) {
            objnewstudy.PITaskStatus = RESUBMITPROPOSALCOMPLETE;
            objnewstudy.TaskName = GMRCMSLREVIEW;
            objnewstudy.State = CONCEPTRESUBMITTED;
            objnewstudy.TaskStatus = GMRCPENDINGMSLCONCEPTREVIEW;
        }
        else if ($("#pITaskStatus").val() === NEWSUBMISSION) {
            objnewstudy.State = CONCEPTSUBMITTED;
            objnewstudy.TaskName = ASSIGNMSLANDPL;
            objnewstudy.TaskStatus = PENDINGMANUALMSLANDPLASSIGNMENT;
            objnewstudy.PITaskStatus = NEWSUBMISSION;
        }
        else if ($("#pITaskStatus").val() === RESUBMITPROPOSAL) {
            objnewstudy.PITaskStatus = RESUBMITPROPOSALCOMPLETE;
            objnewstudy.TaskName = MSLLOIREVIEW;
            objnewstudy.State = CONCEPTRESUBMITTED;
            objnewstudy.TaskStatus = PENDINGMSLCONCEPTREVIEW;
        }
        else if ($("#pITaskStatus").val() === SUBMITPROTOCOL || $('#TaskName').val() === RESUBMITPROTOCOL) {
            objnewstudy.TaskStatus = PROTOCOLSUBMISSIONCOMPLETED;
            objnewstudy.Stage = DECISIONAPPROVED;
            objnewstudy.State = GMRCPREACTIVITIESINPROGRESS;
            objnewstudy.PITaskStatus = $("#pITaskStatus").val();
            objnewstudy.TaskName = $('#TaskName').val();
        }

        var lsmailParameter = new Array();
        var appUrl = $(location)[0].origin;

        var StudyURL = "<a href='" + appUrl + "'> Navigate</a>";
        $.ajax({
            async: false,
            type: "POST",
            url: "/NewStudy/SaveConfirmationDetails",
            data: { "newstudy": objnewstudy },
            success: function (results) {
                if (results.msgType === "Success") {
                    opener.location.reload();
                    if ($("#pITaskStatus").val() === NEWSUBMISSION) {
                        lsmailParameter.push($("#txtUserName").val());
                        lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + TitleofTrial + "</a>");
                        lsmailParameter.push("Netserv");
                        lsmailParameter.push(StudyURL);
                        $.ajax({
                            type: "POST",
                            url: "/Common/SendEmail/",
                            cache: false,
                            data: { "mailMessage": "LOI Submitted", "lsparameter": lsmailParameter, "subParam": appName, "toMail": $("#txtUserName").val(), "ccMail": IISADMIN },
                            dataType: "json",
                            success: function (results) {
                                popupNotification.show('Email Sent Successfully', "success");
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                popupNotification.show('Sending Email Failed', "error");
                            }
                        });
                    }
                    else if ($("#pITaskStatus").val() === RESUBMITPROPOSAL && taskStatus === RESUBMITPROPOSAL && state === GMRCREQUESTEDRESUBMISSION) {
                        lsmailParameter.push($("#txtUserName").val());
                        lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + TitleofTrial + "</a>");
                        lsmailParameter.push(mSLUserame);
                        lsmailParameter.push(StudyURL);
                        $.ajax({
                            type: "POST",
                            url: "/Common/SendEmail/",
                            cache: false,
                            data: { "mailMessage": "Resubmit LOI IRC (notification)", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $("#txtUserName").val(), "ccMail": " " },
                            dataType: "json",
                            success: function (results) {
                                popupNotification.show('Email Sent Successfully', "success");
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                popupNotification.show('Sending Email Failed', "error");
                            }
                        });
                    }
                    else if ($("#pITaskStatus").val() === RESUBMITPROPOSAL) {
                        lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + TitleofTrial + "</a>");
                        lsmailParameter.push($("#txtUserName").val());
                        lsmailParameter.push(StudyURL);
                        $.ajax({
                            async:false,
                            type: "POST",
                            url: "/Common/SendEmail/",
                            cache: false,
                            data: { "mailMessage": "Review Resubmitted LOI", "lsparameter": lsmailParameter, "subParam": " ", "toMail": mSLUserame, "ccMail": " " },
                            dataType: "json",
                            success: function (results) {
                                popupNotification.show('Email Sent Successfully', "success");
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                popupNotification.show('Sending Email Failed', "error");
                            }
                        });

                        var lsmailParameterMSL = new Array();                        
                        lsmailParameterMSL.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + $('#TitleofTrial').val() + "</a>");
                        lsmailParameterMSL.push(StudyURL);
                        $.ajax({
                            async:false,
                            type: "POST",
                            url: "/Common/SendEmail/",
                            cache: false,
                            data: { "mailMessage": "Resubmit LOI IRC (notification) MSL", "lsparameter": lsmailParameterMSL, "subParam": " ", "toMail": mSLUserame, "ccMail": " " },
                            dataType: "json",
                            success: function (results) {
                                popupNotification.show('Email Sent Successfully', "success");
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                popupNotification.show('Sending Email Failed', "error");
                            }
                        });
                    }
                    else if ($("#pITaskStatus").val() === SUBMITPROTOCOL) {
                        lsmailParameter.push($("#txtUserName").val());
                        lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + TitleofTrial + "</a>");
                        lsmailParameter.push(StudyURL);
                        $.ajax({
                            type: "POST",
                            url: "/Common/SendEmail/",
                            cache: false,
                            data: { "mailMessage": "Submit Protocol", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $("#txtUserName").val(), "ccMail": " " },
                            dataType: "json",
                            success: function (results) {
                                popupNotification.show('Email Sent Successfully', "success");
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                popupNotification.show('Sending Email Failed', "error");
                            }
                        });
                    }
                    else if ($("#pITaskStatus").val() === RESUBMITPROTOCOL) {
                        lsmailParameter.push($("#txtUserName").val());
                        lsmailParameter.push(StudyURL);
                        lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + ':' + TitleofTrial + "</a>");
                        $.ajax({
                            type: "POST",
                            url: "/Common/SendEmail/",
                            cache: false,
                            data: { "mailMessage": "Finalize protocol changes", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $("#txtUserName").val(), "ccMail": " " },
                            dataType: "json",
                            success: function (results) {
                                popupNotification.show('Email Sent Successfully', "success");
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                popupNotification.show('Sending Email Failed', "error");
                            }
                        });
                    }
                    window.close();
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

    $("#ui_btndeleteNewStudy").click(function () {
        $.ajax({
            async: true,
            type: "POST",
            url: "/NewStudy/DeleteStudy/",
            data: { "studyId": $('#StudyId').val() },
            cache: false,
            dataType: "json",
            failure: function (response) {
                popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
            }
        });
    });

    var RegisterConstants = {
        elementIDConstant: {
            multiselect_gender: "#ui_multiselectGender"
        }
    };

    //Multi Select drop down
    $(RegisterConstants.elementIDConstant.multiselect_gender).kendoMultiSelect({
        dataTextField: "Code",
        dataValueField: "CodeId",
        optionLabel: 'Select',
        autoClose: false,
        dataSource: {
            transport: {
                read: {
                    dataType: "json",
                    url: "../Common/GetGender"
                }
            }
        }
    });

    function convertDate(d) {
        var date = new Date(d);
        var year = date.getFullYear();
        var month = date.getMonth() + 1 //getMonth is zero based;
        var day = date.getDate();
        var formatted = (year + "-" + month + "-" + day);
        return formatted;
    }

    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/GetCompleteNewStudyDetails/",
        cache: false,
        dataType: "json",
        //data: { "StudyId": parseInt(('#StudyId').val()) },
        //data: { "pageId": parseInt("1") },
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
            }
            else {
                //Page 1
                DisplayScientificRationaleI(response);
                //Page 2
                DisplayScientificRationaleII(response);
                //Page 3
                DisplayPersonalResearchDetails(response);
                //Page 4
                DisplayRequestedSupport(response);
            }
        },
        failure: function (response) {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });

    function DisplayScientificRationaleI(response) {
        var phasevalue = "";
        $("#ui_txt_titleOfTrial").val(response.TitleofTrial);
        $("#ui_txt_interventionStatus").val(response.StudyType);
        if (response.StudyType == "Interventional") {
            if (response.PhaseI == true) {
                $("#PhaseI").prop('checked', true);
                phasevalue = "check";
            }
            if (response.PhaseII == true) {
                $("#PhaseII").prop('checked', true);
                phasevalue = "check";
            }
            if (response.PhaseIII == true) {
                $("#PhaseIII").prop('checked', true);
                phasevalue = "check";
            }
            if (response.PhaseIV == true) {
                $("#PhaseIV").prop('checked', true);
                phasevalue = "check";
            }
        }
        if (phasevalue == "check")
            showhidediv("ui_interventionStatus", "check");
        else if (response.StudyType == "Interventional")
            showhidediv("ui_interventionStatus", null);
        $("#ui_txt_primaryDrug").val(response.Primarydrug);
        $("#ui_txt_secondaryDrug").val(response.Secondarydrug);
        showhidediv("ui_secondaryDrug", response.Secondarydrug);
        $("#ui_txt_tertiaryDrug").val(response.Tertiarydrug);
        showhidediv("ui_tertiaryDrug", response.Tertiarydrug);
        $("#ui_txt_drugOrCompoundTypeForSecondary").val(response.SecondaryType);
        $("#ui_txt_drugOrCompoundTypeForTertiary").val(response.TertiaryaryType);
        $("#ui_txt_indication").val(response.Indication);
        $("#ui_txt_rationaleForTrial").val(response.RationaleforTrial);
        $("#ui_txt_trialDesign").val(response.TrialDesign);
        if (response.StudyType == "Interventional") {
            $("#ui_txt_blinding").val(response.Binding);
            showhidediv("ui_blinding", response.Binding);
            $("#ui_txt_structure").val(response.Structure);
            showhidediv("ui_structure", response.Structure);
            $("#ui_txt_randomized").val(response.Randomized);
            showhidediv("ui_randomized", response.Randomized);
            $("#ui_txt_treatmentArms").val(response.Treatmentarms);
            showhidediv("ui_treatmentArms", response.Treatmentarms);
            var grid = $("#ui_dtg_gridCohortLevels").getKendoGrid();
            var datas = grid.dataSource.data();
            if (datas.length < 1) {
                showhidediv("ui_grid_coherent_lbl", "undefined");
                showhidediv("ui_grid_coherent", "undefined");

            }
                
        }
        else {
            showhidediv("ui_blinding", response.Binding);
            showhidediv("ui_structure", response.Structure);
            showhidediv("ui_randomized", response.Randomized);
            showhidediv("ui_treatmentArms", response.Treatmentarms);
        }

        if (response.Gender != null) {
            var gender = response.Gender.split(',');
            $(RegisterConstants.elementIDConstant.multiselect_gender).getKendoMultiSelect().value(gender);
        }
        $("#ui_txt_minAge").val(response.MinimumAge);
        $("#ui_txt_maxAge").val(response.MaximumAge);
        $("#ui_txt_patientPopulation").val(response.PatientPopulation);
        $("#ui_txt_keyInclusionCriteria").val(response.KeyInclusionCriteria);
        $("#ui_txt_exclusionCriteria").val(response.KeyExclusionCriteria);


    }

    function DisplayScientificRationaleII(response) {
        $("#ui_txt_sampleSizeJustification").val(response.SampleSizeJustificationandStatisticalAnalysis);
        $("#ui_txt_clinicalPharmacology").val(response.ClinicalPharmacology);
        if ($("#pITaskStatus").val().toUpperCase() == $("#pISubmitProtocol").val().toUpperCase()) {
            $("#ui_txt_siteprotocol").val(response.InvestigationalSiteProtocolNumber);
            showhidediv("ui_siteprotocol", response.InvestigationalSiteProtocolNumber);
        }
        var IsincludeCorrelativeScience = response.IsincludeCorrelativeScience;
        IsincludeCorrelativeScience === true ? $("#ui_txt_correlativeScience").val("Yes") : $("#ui_txt_correlativeScience").val("No");
        if (IsincludeCorrelativeScience === true) {
            $('#ifCorrelativeScienceYes').show();
            $("#ui_txt_correlativescienceAtStudySite").val(response.BiomarkerStudiesperformedatStudySite);
            $("#ui_txt_correlativescienceAtCompanySite").val(response.BiomarkerStudiesperformedatCompanySite);
            $("#ui_txt_correlativeScienceSamplingDet").val(response.BiomarkerSamplingDetails);
        }
        else
            $('#ifCorrelativeScienceYes').hide();
        $("#ui_txt_trialStart").val(convertDate(response.TrialStart));
        $("#ui_txt_recruitmentEnd").val(convertDate(response.RecruitmentEnd));
        $("#ui_txt_trialEnd").val(convertDate(response.TrialEnd));
        $("#ui_txt_completionOfTrialReport").val(convertDate(response.CompletionofTrialReport));
        $("#ui_txt_primaryPublication").val(convertDate(response.PrimaryPublicationDate));
        $("#ui_txt_noOfPatients").val(response.TotalPlannedNumberofPatients);
        $("#ui_txt_plannedNoOfCenters").val(response.PlannedNumberofCenters);
        showhidediv("ui_proposedcenter", response.PlannedNumberofCenters)
        $("#ui_txt_enrollmentHistory").val(response.EnrollmentHistoryforOtherRelatedStudies);
        showhidediv("ui_enrollmentHistory", response.EnrollmentHistoryforOtherRelatedStudies);
        var IsCompetingStudies = response.IsCompetingStudies;
        IsCompetingStudies === true ? $("#ui_txt_competingStudies").val("Yes") : $("#ui_txt_competingStudies").val("No");
        if (IsCompetingStudies === true) {
            $('#impactPatientAcrual').show();
            $("#ui_txt_impactPatientAccrual").val(response.CompetingStudies);
        }
        else
            $('#impactPatientAcrual').hide();
        var IsIndsubmission = response.IsIndsubmission;
        IsIndsubmission === false ? $("#ui_txt_proposedStudyIND").val("No") : $("#ui_txt_proposedStudyIND").val("Yes");
        if (IsIndsubmission === false) {
            $('#rationaleINDExemption').show();
            $("#ui_txt_rationaleForINDExemption").val(response.RationaleforINDExemption);
        }
        else
            $('#rationaleINDExemption').hide();
        if (response.StudyType == "Interventional") {
            var IsIrbregistrationRequirement = response.IsIrbregistrationRequirement;
            IsIrbregistrationRequirement === true ? $("#ui_txt_registrationIRB").val("Yes") : $("#ui_txt_registrationIRB").val("No");
            showhidediv("ui_registrationIRB", IsIrbregistrationRequirement)
        }
        else
            showhidediv("ui_registrationIRB", null)
        var TrialType = response.TrialType;
        $("#ui_txt_interventionalTrial").val(TrialType);
        showhidediv("ui_interventionalTrial", TrialType)
        if (TrialType == 'Involving PRIMARY DATA COLLECTION WITHOUT a  Product of Focus') {
            $("#chkBoxConditions").show();
            if (response.IsAllnonseriousAes == true)
                $("#ui_chkbox_allnonseriousAEs").prop('checked', true);
            if (response.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios == true)
                $("#ui_chkbox_allreportsdescribingtheoccurrenceofotherspecialscenarios").prop('checked', true);
        }
        else
            $("#chkBoxConditions").hide();
        if (TrialType == 'Involving PRIMARY DATA COLLECTION WITHOUT a ' + appName + ' Product of Focus' ||
            TrialType == 'Involving PRIMARY DATA COLLECTION WITH a ' + appName + ' Product of Focus') {
            $("#safetyDataforWithandWithout").show();
            $("#ui_txt_Specifywhatsafetydata").val(response.Safetydata);
        }
        else
            $("#safetyDataforWithandWithout").hide();
        $("#ui_txt_adverseEvents").val(response.AdverseEventsExemptfromCollection);
        showhidediv("ui_adverseEvents", response.AdverseEventsExemptfromCollection)
        $("#ui_txt_keyReferences").val(response.KeyReferences);
        var plannednoofcenter = $("#ui_txt_plannedNoOfCenters").val();        
        if (plannednoofcenter < 2)
            $('#ui_dtg_Center_grid').css('display', 'none');
    }

    function DisplayPersonalResearchDetails(response) {
        $("#ui_txt_firstName").val(response.FirstName);
        $("#ui_txt_lastName").val(response.LastName);
        $("#ui_txt_salutation").val(response.Salutation);
        showhidediv("ui_salutation", response.Salutation)
        $("#ui_txt_suffix").val(response.Suffix);
        $("#ui_txt_title").val(response.Title);
        showhidediv("ui_title", response.Title)
        $("#ui_txt_country").val(response.CountryName);
        //$("#ui_txt_curriculumvitae").val(result.DocumentName);
        $("#ui_txt_state").val(response.StateName);
        $("#ui_txt_city").val(response.CityName);
        var degreeArray = response.Degree.split(',');
        $("#ui_multiselect_credentials").getKendoMultiSelect().value(degreeArray);
        $('#ui_txt_npi').val(response.Npinumber);
        showhidediv("ui_npi", response.Npinumber)
        $('#ui_txt_Institution').val(response.Institution);
        $('#ui_txt_addressLine1').val(response.Address1);
        $('#ui_txt_addressLine2').val(response.Address2);
        showhidediv("ui_addressLine2", response.Address2)
        $('#ui_txt_postalCode').val(response.PostalCode);
        $('#ui_txt_phone').val(response.Phone);
        $('#ui_txt_fax').val(response.Fax);
        showhidediv("ui_fax", response.Fax)
        $('#ui_txt_email').val(response.PrimaryEmailId);
        $("#ui_txt_medicalSpecialty").val(response.MedicalSpecialty);
        $("#ui_txt_boardcrtification").val(response.BoardCertification);
        $("#ui_txt_medicalLicense").val(response.MedicalLicense);
        var isParticipatedinaCompany = response.IsCompanySponsoredtrial;
        isParticipatedinaCompany === true ? $("#ui_txt_isParticipatedinaCompanysponsoredtrial").val("Yes") : $("#ui_txt_isParticipatedinaCompanysponsoredtrial").val("No");
        if (isParticipatedinaCompany === true) {
            $('#Iscompanysponsoredtrial').show();
            $('#IsNotcompanysponsoredtrial').hide();
            $("#ui_txt_drugname").val(response.DrugName);
            $("#ui_txt_protocolNumbers").val(response.ProtocolNumber);
            $("#ui_txt_datesoftrialparticipation").val(response.TrialParticipation);
        }
        else {
            $('#Iscompanysponsoredtrial').hide();
            $('#IsNotcompanysponsoredtrial').show();
            var IsreceivedGCPtraining = response.IsOtherTrainingsReceived;
            IsreceivedGCPtraining === true ? $("#ui_txt_IsreceivedGCPtraining").val("Yes") : $("#ui_txt_IsreceivedGCPtraining").val("No");
            if (IsreceivedGCPtraining === true) {
                $('#ifReceivedGCPtrainingYes').show();
                $("#ui_txt_lastGCPtraining").val(response.LastTrainingDetails);
                $('#ui_txt_typeoftrainingreceived').val(response.TypeOfTraining);
            }
            else {
                $('#ifReceivedGCPtrainingYes').hide();
            }
        }
        $('#ui_txt_listtrialexperience').val(response.TrialExperiences);
        showhidediv("ui_listtrialexperience", response.TrialExperiences)
        $('#ui_txt_numberofongoingclinicaltrials').val(response.NumberOfOngoingTrials);

        var isInspectedbyaHealthAuth = response.IsSiteInspectedByHealthAuthority;
        isInspectedbyaHealthAuth === true ? $("#ui_txt_isInspectedbyaHealthAuthority").val("Yes") : $("#ui_txt_isInspectedbyaHealthAuthority").val("No");
        if (isInspectedbyaHealthAuth === true) {
            $('#ifHealthAuthorityYes').show();
            $('#ui_txt_whichhealthauthority').val(response.NameOfHealthAuthority);
            showhidediv("ui_whichhealthauthority", response.NameOfHealthAuthority)
            $("#ui_txt_dateoflastinspection").val(response.DateOflastInspection);
            showhidediv("ui_dateoflastinspection", response.DateOflastInspection)
        }
        else {
            $('#ifHealthAuthorityYes').hide();
            showhidediv("ifHealthAuthorityYes", null)
        }
        var isinspectedbytheFDA = response.IsSiteInspectedByFda;
        isinspectedbytheFDA === true ? $("#ui_txt_isinspectedbytheFDA").val("Yes") : $("#ui_txt_isinspectedbytheFDA").val("No");
        if (isinspectedbytheFDA === true) {
            $('#ifInspectedHealthYes').show();
            //need to check date
            $("#ui_txt_dateofinspection").val(response.DateOfFdainspection);
            showhidediv("ui_dateofinspection", response.DateOfFdainspection);
            var Isfda = response.Isfda483formIssued;
            Isfda === true ? $("#ui_txt_fDAIssue").val("Yes") : $("#ui_txt_fDAIssue").val("No");
            if (Isfda === true) {
                $('#mainObservation').show();
                $("#ui_txt_detailsofthemainobservations").val(response.DetailsOfObservation);
            }
            else {
                $('#mainObservation').hide();
                showhidediv("ui_dateofinspection", "undefined");
            }
        }
        else {
            $('#ifInspectedHealthYes').hide();
        }
        var IsCooperative = response.IsCooperativeGroupStudy;
        IsCooperative === true ? $("#ui_txt_isCooperativeGroupStudy").val("Yes") : $("#ui_txt_isCooperativeGroupStudy").val("No");
        if (IsCooperative === true) {
            $('#cooperativeGroupName').show();
            $("#ui_txt_cooperativeGroupName").val(response.CooperativeGroupName);
        }
        else {
            $('#cooperativeGroupName').hide();
        }
        var physicianNetworkStudy = response.IsPhysicianNetworkStudy;
        physicianNetworkStudy === true ? $("#ui_txt_physicianNetworkStudy").val("Yes") : $("#ui_txt_physicianNetworkStudy").val("No");
        if (physicianNetworkStudy === true) {
            $('#physicianNetworkName').show();
            $("#ui_txtPhysicianNetworkName").val(response.PhysicianNetworkName);
        }
        else {
            $('#physicianNetworkName').hide();
        }
        var isGovernmentSupportProvided = response.IsGovernmentSupportProvided;
        isGovernmentSupportProvided === true ? $("#ui_txt_isGovernmentSupportProvided").val("Yes") : $("#ui_txt_isGovernmentSupportProvided").val("No");
        if (isGovernmentSupportProvided === true) {
            $('#govtSupportDesc').show();

            $("#ui_txt_GovernmentSupportDescription").val(response.SupportDescription);

        }
        else {
            $('#govtSupportDesc').hide();
        }
        var issupportbeprovidedfromothersource = response.IsSupportProvidedByOtherSources;
        issupportbeprovidedfromothersource === true ? $("#ui_txt_issupportbeprovidedfromothersource").val("Yes") : $("#ui_txt_issupportbeprovidedfromothersource").val("No");
        if (issupportbeprovidedfromothersource === true) {
            $('#nonCompanySupportSources').show();
            $("#ui_txt_nonCompanySupportSources").val(response.SupportSources);
        }
        else {
            $('#nonCompanySupportSources').hide();
        }

        var grid = $("#ui_dtg_emailList").getKendoGrid();
        var datas = grid.dataSource.data();
        if (datas.length < 1)
            showhidediv("ui_emailList", "undefined")

        //Submit Protocol start
        if (response.lsPayeeInformation.length > 0) {
            for (let i = 0; i < response.lsPayeeInformation.length; i++) {
                var categoryId = response.lsPayeeInformation[i].PayeeInformationID;
                switch (categoryId) {
                    case 2:
                        $("#ui_txt_payee_firstname").val(response.lsPayeeInformation[i].FirstName);
                        showhidediv("payee_firstname", response.lsPayeeInformation[i].FirstName);
                        $("#ui_txt_payee_lastname").val(response.lsPayeeInformation[i].LastName);
                        showhidediv("payee_lastname", response.lsPayeeInformation[i].LastName);
                        $("#ui_txt_payee_salutation").val(response.lsPayeeInformation[i].Salutation);
                        showhidediv("payee_salutation", response.lsPayeeInformation[i].Salutation);
                        $("#ui_txt_payee_sufix").val(response.lsPayeeInformation[i].Suffix);
                        showhidediv("payee_sufix", response.lsPayeeInformation[i].Suffix);
                        $("#ui_txt_payee_title").val(response.lsPayeeInformation[i].Title);
                        showhidediv("payee_title", response.lsPayeeInformation[i].Title);
                        $("#ui_txt_payee_country").val(response.lsPayeeInformation[i].CountryName);
                        showhidediv("payee_country", response.lsPayeeInformation[i].CountryName);
                        //$("#ui_txt_curriculumvitae").val(result.DocumentName);
                        $("#ui_txt_payee_state").val(response.lsPayeeInformation[i].StateName);
                        showhidediv("payee_state", response.lsPayeeInformation[i].StateName);
                        $("#ui_txt_payee_city").val(response.lsPayeeInformation[i].CityName);
                        showhidediv("payee_city", response.lsPayeeInformation[i].CityName);
                        var degreeArray = response.lsPayeeInformation[i].Degree ? response.lsPayeeInformation[i].Degree.split(',') : 'undefined';
                        if (degreeArray !== "undefined")
                            $("#ui_multiselect_payee_credentials").getKendoMultiSelect().value(degreeArray);
                        showhidediv("payee_degree", degreeArray);
                        $('#ui_txt_payee_institution').val(response.lsPayeeInformation[i].Institution);
                        showhidediv("payee_institution", response.lsPayeeInformation[i].Institution);
                        $('#ui_txt_payee_addressLine1').val(response.lsPayeeInformation[i].Address1);
                        showhidediv("payee_address1", response.lsPayeeInformation[i].Address1);
                        $('#ui_txt_payee_addressLine2').val(response.lsPayeeInformation[i].Address2);
                        showhidediv("payee_address2", response.lsPayeeInformation[i].Address2);
                        $('#ui_txt_payee_postalcode').val(response.lsPayeeInformation[i].PostalCode);
                        showhidediv("payee_postal", response.lsPayeeInformation[i].PostalCode);
                        $('#ui_txt_payee_phone').val(response.lsPayeeInformation[i].Phone);
                        showhidediv("payee_phone", response.lsPayeeInformation[i].Phone);
                        $('#ui_txt_payee_fax').val(response.lsPayeeInformation[i].Fax);
                        showhidediv("payee_fax", response.lsPayeeInformation[i].FAX);
                        $('#ui_txt_payee_email').val(response.lsPayeeInformation[i].PrimaryEmailId);
                        showhidediv("payee_email", response.lsPayeeInformation[i].PrimaryEmailId);
                        break;
                    case 3:
                        $("#ui_txt_shipment_firstname").val(response.lsPayeeInformation[i].FirstName);
                        showhidediv("shipment_firstname", response.lsPayeeInformation[i].FirstName);
                        $("#ui_txt_shipment_lastName").val(response.lsPayeeInformation[i].LastName);
                        showhidediv("shipment_lastname", response.lsPayeeInformation[i].LastName);
                        $("#ui_txt_shipment_salutation").val(response.lsPayeeInformation[i].Salutation);
                        showhidediv("shipment_salutation", response.lsPayeeInformation[i].Salutation);
                        $("#ui_txt_shipment_sufix").val(response.lsPayeeInformation[i].Suffix);
                        showhidediv("shipment_sufix", response.lsPayeeInformation[i].Salutation);
                        $("#ui_txt_shipment_title").val(response.lsPayeeInformation[i].Title);
                        showhidediv("shipment_title", response.lsPayeeInformation[i].Title);
                        $("#ui_txt_shipment_country").val(response.lsPayeeInformation[i].CountryName);
                        showhidediv("shipment_country", response.lsPayeeInformation[i].CountryName);
                        $("#ui_txt_shipment_state").val(response.lsPayeeInformation[i].StateName);
                        showhidediv("shipment_state", response.lsPayeeInformation[i].StateName);
                        $("#ui_txt_shipment_city").val(response.lsPayeeInformation[i].CityName);
                        showhidediv("shipment_city", response.lsPayeeInformation[i].CityName);
                        var degreeArray = response.lsPayeeInformation[i].Degree ? response.lsPayeeInformation[i].Degree.split(',') : 'undefined';
                        if (degreeArray !== "undefined")
                            $("#ui_multiselect_shipment_credentials").getKendoMultiSelect().value(degreeArray);
                        showhidediv("shipment_credentials", degreeArray);
                        $('#ui_txt_shipment_institution').val(response.lsPayeeInformation[i].Institution);
                        showhidediv("shipment_institution", response.lsPayeeInformation[i].Institution);
                        $('#ui_txt_shipment_addressline1').val(response.lsPayeeInformation[i].Address1);
                        showhidediv("shipment_address1", response.lsPayeeInformation[i].Address1);
                        $('#ui_txt_shipment_addressline2').val(response.lsPayeeInformation[i].Address2);
                        showhidediv("shipment_address2", response.lsPayeeInformation[i].Address2);
                        $('#ui_txt_shipment_postalCode').val(response.lsPayeeInformation[i].PostalCode);
                        showhidediv("shipment_postal", response.lsPayeeInformation[i].PostalCode);
                        $('#ui_txt_shipment_phone').val(response.lsPayeeInformation[i].Phone);
                        showhidediv("shipment_phone", response.lsPayeeInformation[i].Phone);
                        $('#ui_txt_shipment_fax').val(response.lsPayeeInformation[i].Fax);
                        showhidediv("shipment_fax", response.lsPayeeInformation[i].Fax);
                        $('#ui_txt_shipment_email').val(response.lsPayeeInformation[i].PrimaryEmailId);
                        showhidediv("shipment_email", response.lsPayeeInformation[i].PrimaryEmailId);
                        break;
                    case 4:
                        $("#ui_txt_contracts_firstName").val(response.lsPayeeInformation[i].FirstName);
                        showhidediv("contracts_firstname", response.lsPayeeInformation[i].FirstName);
                        $("#ui_txt_contracts_lastname").val(response.lsPayeeInformation[i].LastName);
                        showhidediv("contracts_lastname", response.lsPayeeInformation[i].LastName);
                        $("#ui_txt_contracts_salutation").val(response.lsPayeeInformation[i].Salutation);
                        showhidediv("contracts_salutation", response.lsPayeeInformation[i].Salutation);
                        $("#ui_txt_contracts_sufix").val(response.lsPayeeInformation[i].Suffix);
                        showhidediv("contracts_sufix", response.lsPayeeInformation[i].Suffix);
                        $("#ui_txt_contracts_title").val(response.lsPayeeInformation[i].Title);
                        showhidediv("contracts_title", response.lsPayeeInformation[i].Title);
                        $("#ui_txt_contracts_country").val(response.lsPayeeInformation[i].CountryName);
                        showhidediv("contracts_country", response.lsPayeeInformation[i].CountryName);
                        $("#ui_txt_contracts_state").val(response.lsPayeeInformation[i].StateName);
                        showhidediv("contracts_state", response.lsPayeeInformation[i].StateName);
                        $("#ui_txt_contracts_city").val(response.lsPayeeInformation[i].CityName);
                        showhidediv("contracts_city", response.lsPayeeInformation[i].CityName);
                        var degreeArray = response.lsPayeeInformation[i].Degree ? response.lsPayeeInformation[i].Degree.split(',') : 'undefined';
                        if (degreeArray !== "undefined")
                            $("#ui_multiselect_contracts_credentials").getKendoMultiSelect().value(degreeArray);
                        showhidediv("contracts_credentials", degreeArray);
                        $('#ui_txt_contracts_institution').val(response.lsPayeeInformation[i].Institution);
                        showhidediv("contracts_institution", response.lsPayeeInformation[i].Institution);
                        $('#ui_txt_contracts_addressline1').val(response.lsPayeeInformation[i].Address1);
                        showhidediv("contracts_address1", response.lsPayeeInformation[i].Address1);
                        $('#ui_txt_contracts_addressline2').val(response.lsPayeeInformation[i].Address2);
                        showhidediv("contracts_address2", response.lsPayeeInformation[i].Address2);
                        $('#ui_txt_contracts_postalCode').val(response.lsPayeeInformation[i].PostalCode);
                        showhidediv("contracts_postal", response.lsPayeeInformation[i].PostalCode);
                        $('#ui_txt_contracts_phone').val(response.lsPayeeInformation[i].Phone);
                        showhidediv("contracts_phone", response.lsPayeeInformation[i].Phone);
                        $('#ui_txt_contracts_fax').val(response.lsPayeeInformation[i].Fax);
                        showhidediv("contracts_fax", response.lsPayeeInformation[i].Fax);
                        $('#ui_txt_contracts_email').val(response.lsPayeeInformation[i].PrimaryEmailId);
                        showhidediv("contracts_email", response.lsPayeeInformation[i].PrimaryEmailId);
                        break;

                    default:
                        $("#ui_txt_coordinator_firstname").val(response.lsPayeeInformation[i].FirstName);
                        showhidediv("coordinator_firstname", response.lsPayeeInformation[i].FirstName);
                        $("#ui_txt_coordinator_lastname").val(response.lsPayeeInformation[i].LastName);
                        showhidediv("coordinator_lastname", response.lsPayeeInformation[i].LastName);
                        $("#ui_txt_coordinator_salutation").val(response.lsPayeeInformation[i].Salutation);
                        showhidediv("coordinator_salutation", response.lsPayeeInformation[i].Salutation);
                        $("#ui_txt_coordinator_sufix").val(response.lsPayeeInformation[i].Suffix);
                        showhidediv("coordinator_sufix", response.lsPayeeInformation[i].Suffix);
                        $("#ui_txt_coordinator_title").val(response.lsPayeeInformation[i].Title);
                        showhidediv("coordinator_title", response.lsPayeeInformation[i].Title);
                        $("#ui_txt_coordinator_country").val(response.lsPayeeInformation[i].CountryName);
                        showhidediv("coordinator_country", response.lsPayeeInformation[i].CountryName);
                        $("#ui_txt_coordinator_state").val(response.lsPayeeInformation[i].StateName);
                        showhidediv("coordinator_state", response.lsPayeeInformation[i].StateName);
                        $("#ui_txt_coordinator_city").val(response.lsPayeeInformation[i].CityName);
                        showhidediv("coordinator_city", response.lsPayeeInformation[i].CityName);
                        var degreeArray = response.lsPayeeInformation[i].Degree ? response.lsPayeeInformation[i].Degree.split(',') : 'undefined';
                        if (degreeArray !== "undefined")
                            $("#ui_multiselect_coordinator_credentials").getKendoMultiSelect().value(degreeArray);
                        showhidediv("coordinator_credential", degreeArray);
                        $('#ui_txt_coordinator_institution').val(response.lsPayeeInformation[i].Institution);
                        showhidediv("coordinator_institution", response.lsPayeeInformation[i].Institution);
                        $('#ui_txt_coordinator_addressline1').val(response.lsPayeeInformation[i].Address1);
                        showhidediv("coordinator_address1", response.lsPayeeInformation[i].Address1);
                        $('#ui_txt_coordinator_addressline2').val(response.lsPayeeInformation[i].Address2);
                        showhidediv("coordinator_address2", response.lsPayeeInformation[i].Address2);
                        $('#ui_txt_coordinator_postalCode').val(response.lsPayeeInformation[i].PostalCode);
                        showhidediv("coordinator_postal", response.lsPayeeInformation[i].PostalCode);
                        $('#ui_txt_coordinator_phone').val(response.lsPayeeInformation[i].Phone);
                        showhidediv("coordinator_phone", response.lsPayeeInformation[i].Phone);
                        $('#ui_txt_coordinator_fax').val(response.lsPayeeInformation[i].Fax);
                        showhidediv("coordinator_fax", response.lsPayeeInformation[i].Fax);
                        $('#ui_txt_coordinator_email').val(response.lsPayeeInformation[i].PrimaryEmailId);
                        showhidediv("coordinator_email", response.lsPayeeInformation[i].PrimaryEmailId);

                }
            }
        }
        //Submit Protocol End
    }

    function showhidediv(divid, divvalue) {
        if (divvalue == null || divvalue === "undefined")
            //document.getElementById(divid).style.display = "none"
            $('#' + divid).css('display', 'none');
    }

    function DisplayRequestedSupport(response) {
        var IsRequestedForDrugSupply = response.IsRequestedForDrugSupply;
        if (IsRequestedForDrugSupply === true) {
            $("#ui_txt_reqDrugSupply").val("Yes");
        }
        else if (IsRequestedForDrugSupply === false) {
            $("#ui_txt_reqDrugSupply").val("No");
        }
        else {
            $("#ui_txt_reqDrugSupply").val("Select");
        }
        var IsRequestedForFinancialSupport = response.IsRequestedForFinancialSupport;
        if (IsRequestedForFinancialSupport === true) {
            $("#ui_txt_reqFinancialSupport").val("Yes");
        }
        else if (IsRequestedForFinancialSupport === false) {
            $("#ui_txt_reqFinancialSupport").val("No");
        }
        else {
            $("#ui_txt_reqFinancialSupport").val("Select");
        }
        if (IsRequestedForFinancialSupport === true) {
            $('#ifReqFinancialSupportYes').show();
            $('#ui_txt_currency').val("$" + response.BudgetRequestedForTrial);

            $('#ui_txt_Path').val(response.Path);
        }
        else {
            $('#ifReqFinancialSupportYes').hide();
        }
    }

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

    $('#ui_multiselect_payee_credentials').kendoMultiSelect({
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

    $('#ui_multiselect_shipment_credentials').kendoMultiSelect({
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

    $('#ui_multiselect_contracts_credentials').kendoMultiSelect({
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

    $('#ui_multiselect_coordinator_credentials').kendoMultiSelect({
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

    $('#confirmation').removeClass('btn-submission').addClass('activePage');

    $(function () {
        $("#ui_btnPreviousSection, #ui_btnPreviousSectionEnd").click(function () {
            // window.history.pushState({ prevUrl: window.location.href }, null, "/NewStudy/RequestedSupport?StudyId=" + $('#StudyId').val() + '&&mode=Update' + '&&StudyType=' + $('#studyType').val());
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
                        window.location.href = "/NewStudy/RequestedSupport";
                    }
                    else {
                        popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
                    }
                }
            });
        });
    });
});
