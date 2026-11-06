
function LoadEditStudyMasterTabs() {
    $.ajax({
        async: false,
        type: "GET",
        url: "/NewStudy/GetTabTitles/",
        data: { tabtype: "Parent Tab" },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case scientificrationale:
                            $("#ui_lbl_scientificrationale").html(response[i].Name);
                            break;
                        case personnelsitesandsupport:
                            $("#ui_lbl_personnelsitesandsupport").html(response[i].Name);
                            break;
                        case tracking:
                            $("#ui_lbl_tracking").html(response[i].Name);
                            break;
                        case "Generaldetails":
                            $("#ui_lbl_generaldetails").html(response[i].Name);
                            break;

                    }
                   
                    var tabstripRoot = $("#tabstripRoot").kendoTabStrip().data("kendoTabStrip");
                    if (response[i].IsViewable == true) {
                        if (response[i].RestrictViewUser != null) {
                            var restrictviewuserArray = response[i].RestrictViewUser.split(',');
                            for (var j = 0; j < restrictviewuserArray.length; j++) {
                                if (restrictviewuserArray[j] == $('#UserType').val()) {
                                    $(tabstripRoot.items()[i]).hide();
                                    break;
                                }
                                else
                                    $(tabstripRoot.items()[i]).show();
                            }
                        }
                    }
                    else
                        $(tabstripRoot.items()[i]).hide();                   
                }
            }
        },
        failure: function (response) {
            popupNotification.show(errorsinthepage, "error");
        }
    });
}

function LoadChildTabs() {
    LoadScientificRationale();
    LoadPersonnelSitesandSupport();
    LoadTracking();
    LoadGeneralDetails();
}

function LoadScientificRationale() {
    $.ajax({
        async: false,
        type: "GET",
        url: "/NewStudy/GetTabTitles/",
        data: { tabtype: "Tab", category: scientificrationale },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case sciencemain:
                            $("#ui_lbl_sciencemain").html(response[i].Name);
                            break;
                        case diseasestates:
                            $("#ui_lbl_diseasestates").html(response[i].Name);
                            break;
                        case cohortlevels:
                            $("#ui_lbl_cohortlevels").html(response[i].Name);
                            break;
                        case treatmentinformation:
                            $("#ui_lbl_treatmentinformation").html(response[i].Name);
                            break;
                        case correlativescience:
                            $("#ui_lbl_correlativescience").html(response[i].Name);
                            break;
                        case studycompounds:
                            $("#ui_lbl_studycoumpounds").html(response[i].Name);
                            break;
                        case indicationtab:
                            $("#ui_lbl_indications").html(response[i].Name);
                            break
                        case objectives:
                            $("#ui_lbl_objectives").html(response[i].Name);
                            break;
                        case pharmacovigilance:
                            $("#ui_lbl_pharmacovigilance").html(response[i].Name);
                            break;
                        case studyenrollmentandtimelines:
                            $("#ui_lbl_studyenrollmentandtimelines").html(response[i].Name);
                            break;
                        case irbrequirement:
                            $("#ui_lbl_IRBRequirementfield").html(response[i].Name);
                            break;
                        case pandemicpreparednesstrialcategorization:
                            $("#ui_lbl_pandemicpreparednesstrialcategorizationfield").html(response[i].Name);
                            break;
                        case regulatoryrequirements:
                            $("#ui_lbl_regulatoryrequirements").html(response[i].Name);
                            break;
                        case studyprotocolnumberstab:
                            $("#ui_lbl_studyprotocolnumbersfield").html(response[i].Name);
                            break;
                        case keyreferrencestab:
                            $("#ui_lbl_keyreferences").html(response[i].Name);
                            break;
                    }
                    
                    var tabstripChild1 = $("#tabstripChild1").kendoTabStrip().data("kendoTabStrip");
                    if (response[i].IsViewable == true) {
                        if (response[i].RestrictViewUser != null) {
                            var restrictviewuserArray = response[i].RestrictViewUser.split(',');
                            for (var j = 0; j < restrictviewuserArray.length; j++) {
                                if (restrictviewuserArray[j] == $('#UserType').val()) {
                                    $(tabstripChild1.items()[i]).hide();
                                    break;
                                }
                                else
                                    $(tabstripChild1.items()[i]).show();
                            }
                        }
                    }
                    else
                        $(tabstripChild1.items()[i]).hide();                   

                                    
                }
            }
        },
        failure: function (response) {
            popupNotification.show(errorsinthepage, "error");
        }
    });
}

function LoadPersonnelSitesandSupport() {
    $.ajax({
        async: false,
        type: "GET",
        url: "/NewStudy/GetTabTitles/",
        data: { tabtype: "Tab", category: "Personnel Sites & Support" },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case contacts:
                            $("#ui_lbl_contacts").html(response[i].Name);
                            break;
                        case investigatorqualifications:
                            $("#ui_lbl_investigatorqualifications").html(response[i].Name);
                            break;
                        case sites:
                            $("#ui_lbl_sites").html(response[i].Name);
                            break;
                        case researchgroupdescription:
                            $("#ui_lbl_researchgroupdescription").html(response[i].Name);
                            break;
                        case originalfinancialrequest:
                            $("#ui_lbl_originalfinancialrequest").html(response[i].Name);
                            break;
                        case emaillist:
                            $("#ui_lbl_emailList").html(response[i].Name);
                            break;
                    }

                    var tabstripChild2 = $("#tabstripChild2").kendoTabStrip().data("kendoTabStrip");
                    if (response[i].IsViewable == true) {
                        if (response[i].RestrictViewUser != null) {
                            var restrictviewuserArray = response[i].RestrictViewUser.split(',');
                            for (var j = 0; j < restrictviewuserArray.length; j++) {
                                if (restrictviewuserArray[j] == $('#UserType').val()) {
                                    $(tabstripChild2.items()[i]).hide();
                                    break;
                                }
                                else
                                    $(tabstripChild2.items()[i]).show();
                            }
                        }
                    }
                    else
                        $(tabstripChild2.items()[i]).hide();           
                }
            }
        },
        failure: function (response) {
            popupNotification.show(errorsinthepage, "error");
        }
    });
}

function LoadTracking() {
    $.ajax({
        async: false,
        type: "GET",
        url: "/NewStudy/GetTabTitles/",
        data: { tabtype: "Tab", category: tracking },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case milestones:
                            $("#ui_lbl_milestones").html(response[i].Name);
                            break;
                        case patientaccrual:
                            $("#ui_lbl_patientaccrual").html(response[i].Name);
                            break;
                        case contractstimeline:
                            $("#ui_lbl_contractstimeline").html(response[i].Name);
                            break;
                        case invoices:
                            $("#ui_lbl_invoices").html(response[i].Name);
                            break;
                        case statusineditstudy:
                            $("#ui_lbl_status").html(response[i].Name);
                            break;
                    }

                    var tabstripChild3 = $("#tabstripChild3").kendoTabStrip().data("kendoTabStrip");
                    if (response[i].IsViewable == true) {
                        if (response[i].RestrictViewUser != null) {
                            var restrictviewuserArray = response[i].RestrictViewUser.split(',');
                            for (var j = 0; j < restrictviewuserArray.length; j++) {
                                if (restrictviewuserArray[j] == $('#UserType').val()) {
                                    $(tabstripChild3.items()[i]).hide();
                                    break;
                                }
                                else
                                    $(tabstripChild3.items()[i]).show();
                            }
                        }
                    }
                    else
                        $(tabstripChild3.items()[i]).hide();    
                }
            }
        },
        failure: function (response) {
            popupNotification.show(errorsinthepage, "error");
        }
    });
}

function LoadGeneralDetails() {
    $.ajax({
        async: false,
        type: "GET",
        url: "/NewStudy/GetTabTitles/",
        data: { tabtype: "Tab", category: generaldetails },
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case reviewsandnotes:
                            $("#ui_lbl_reviewsandnotes").html(response[i].Name);
                            break;
                        case documentstab:
                            $("#ui_lbl_documents").html(response[i].Name);
                            break;
                        case submissions:
                            $("#ui_lbl_submissions").html(response[i].Name);
                            break;
                        case otherattributes:
                            $("#ui_lbl_otherattributes").html(response[i].Name);
                            break;
                        case relatedusers:
                            $("#ui_lbl_relatedusers").html(response[i].Name);
                            break;
                    }

                    var tabstripChild4 = $("#tabstripChild4").kendoTabStrip().data("kendoTabStrip");
                    if (response[i].IsViewable == true) {
                        if (response[i].RestrictViewUser != null) {
                            var restrictviewuserArray = response[i].RestrictViewUser.split(',');
                            for (var j = 0; j < restrictviewuserArray.length; j++) {
                                if (restrictviewuserArray[j] == $('#UserType').val()) {
                                    $(tabstripChild4.items()[i]).hide();
                                    break;
                                }
                                else
                                    $(tabstripChild4.items()[i]).show();
                            }
                        }
                    }
                    else
                        $(tabstripChild4.items()[i]).hide();    
                }
            }
        },
        failure: function (response) {
            popupNotification.show(errorsinthepage, "error");
        }
    });
}