$(function () {
    var validator = $("#ui_frmEditStudy").kendoValidator().data("kendoValidator");

    function ValidateDiseaseFields() {
        $(".error").remove();
        retval = true;
        objDisease = new Object();
        objDisease.StudyId = $('#StudyId').val();

        if ($('#displayFranchise').is(':visible'))
            if (sessionStorage.getItem("isfranchise") == "true") {
                if ($('#ui_ddl_franchise').val() == "") {
                    $('#franchise').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_franchise').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_franchise').val() == "")
                        objDisease.Franchise = null;
                    else
                        objDisease.Franchise = $('#ui_ddl_franchise').val();
                }
            }
            else {
                if ($('#ui_ddl_franchise').val() == "")
                    objDisease.Franchise = null;
                else
                    objDisease.Franchise = $('#ui_ddl_franchise').val();
            }

        if ($('#displayRandomization').is(':visible'))
            if (sessionStorage.getItem("israndomization") == "true") {
                if ($('#ui_ddl_randomization').val() == "") {
                    $('#randomization').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_randomization').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_randomization').val() == "")
                        objDisease.Randomized = null;
                    else
                        objDisease.Randomized = $('#ui_ddl_randomization').val();
                }
            }
            else {
                if ($('#ui_ddl_randomization').val() == "")
                    objDisease.Randomized = null;
                else
                    objDisease.Randomized = $('#ui_ddl_randomization').val();
            }

        if ($('#displayBlinding').is(':visible'))
            if (sessionStorage.getItem("isblinding") == "true") {
                if ($('#ui_ddl_blinding').val() == "") {
                    $('#blinding').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_blinding').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_blinding').val() == "")
                        objDisease.Binding = null;
                    else
                        objDisease.Binding = $('#ui_ddl_blinding').val();
                }
            }
            else {
                if ($('#ui_ddl_blinding').val() == "")
                    objDisease.Binding = null;
                else
                    objDisease.Binding = $('#ui_ddl_blinding').val();
            }

        if ($('#displayRiskfactors').is(':visible'))
            if (sessionStorage.getItem("isriskfactors") == "true") {
                if ($('#ui_riskfactors').data("kendoMultiSelect").value().length <= 0) {
                    $('#riskfactors').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_riskfactors').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_riskfactors').val() == "")
                        objDisease.Riskfactors = null;
                    else
                        objDisease.Riskfactors = $('#ui_riskfactors').val().toString();
                }
            }
            else {
                if ($('#ui_riskfactors').val() == "")
                    objDisease.Riskfactors = null;
                else
                    objDisease.Riskfactors = $('#ui_riskfactors').val().toString();
            }

        if ($('#displayGenomicprofile').is(':visible'))
            if (sessionStorage.getItem("isgenomicprofile") == "true") {
                if ($('#ui_genomicprofile').data("kendoMultiSelect").value().length <= 0) {
                    $('#genomicprofile').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_genomicprofile').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_genomicprofile').val() == "")
                        objDisease.GenomicProfile = null;
                    else
                        objDisease.GenomicProfile = $('#ui_genomicprofile').val().toString();
                }
            }
            else {
                if ($('#ui_genomicprofile').val() == "")
                    objDisease.GenomicProfile = null;
                else
                    objDisease.GenomicProfile = $('#ui_genomicprofile').val().toString();
            }

        if ($('#displayStructure').is(':visible'))
            if (sessionStorage.getItem("isstructure") == "true") {
                if ($('#ui_ddl_structure').val() == "") {
                    $('#structure').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_structure').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_structure').val() == "")
                        objDisease.Structure = null;
                    else
                        objDisease.Structure = $('#ui_ddl_structure').val();
                }
            }
            else {
                if ($('#ui_ddl_structure').val() == "")
                    objDisease.Structure = null;
                else
                    objDisease.Structure = $('#ui_ddl_structure').val();
            }

        if ($('#displayLineoftherapy').is(':visible'))
            if (sessionStorage.getItem("islineoftherapy") == "true") {
                if ($('#ui_lineoftherapy').data("kendoMultiSelect").value().length <= 0) {
                    $('#lineoftherapy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_lineoftherapy').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_lineoftherapy').val() == "")
                        objDisease.Lineoftherapy = null;
                    else
                        objDisease.Lineoftherapy = $('#ui_lineoftherapy').val().toString();
                }
            }
            else {
                if ($('#ui_lineoftherapy').val() == "")
                    objDisease.Lineoftherapy = null;
                else
                    objDisease.Lineoftherapy = $('#ui_lineoftherapy').val().toString();
            }

        if ($('#displayDisease').is(':visible'))
            if (sessionStorage.getItem("isdisease") == "true") {
                if ($('#ui_ddl_disease').val() == "") {
                    $('#disease').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_disease').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_disease').val() == "")
                        objDisease.Disease = null;
                    else
                        objDisease.Disease = $('#ui_ddl_structure').val();
                }
            }
            else {
                if ($('#ui_ddl_disease').val() == "")
                    objDisease.Disease = null;
                else
                    objDisease.Disease = $('#ui_ddl_disease').val();
            }

        if ($('#displaydiseasePatientPopulation').is(':visible'))
            if (sessionStorage.getItem("isdiseasepatientpopulation") == "true") {
                if ($('#ui_diseasepatientpopulation').data("kendoMultiSelect").value().length <= 0) {
                    $('#diseasePatientPopulation').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_diseasepatientpopulation').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_diseasepatientpopulation').val() == "")
                        objDisease.Diseasepaatientpopulation = null;
                    else
                        objDisease.Diseasepaatientpopulation = $('#ui_diseasepatientpopulation').val().toString();
                }
            }
            else {
                if ($('#ui_diseasepatientpopulation').val() == "")
                    objDisease.Diseasepaatientpopulation = null;
                else
                    objDisease.Diseasepaatientpopulation = $('#ui_diseasepatientpopulation').val().toString();
            }

        if ($('#displayStage').is(':visible'))
            if (sessionStorage.getItem("isstage") == "true") {
                if ($('#ui_ddl_stage').val() == "") {
                    $('#stage').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_stage').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_stage').val() == "")
                        objDisease.DiseaseStage = null;
                    else
                        objDisease.DiseaseStage = $('#ui_ddl_stage').val();
                }
            }
            else {
                if ($('#ui_ddl_stage').val() == "")
                    objDisease.DiseaseStage = null;
                else
                    objDisease.DiseaseStage = $('#ui_ddl_stage').val();
            }

        if ($('#displayTreatmentSegment').is(':visible'))
            if (sessionStorage.getItem("istreatmentsegment") == "true") {
                if ($('#ui_ddl_treatmentsegment').val() == "") {
                    $('#treatmentSegment').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_treatmentsegment').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_treatmentsegment').val() == "")
                        objDisease.TreatmentSegment = null;
                    else
                        objDisease.TreatmentSegment = $('#ui_ddl_treatmentsegment').val();
                }
            }
            else {
                if ($('#ui_ddl_treatmentsegment').val() == "")
                    objDisease.TreatmentSegment = null;
                else
                    objDisease.TreatmentSegment = $('#ui_ddl_treatmentsegment').val();
            }

        if ($('#displayLineofTreatment').is(':visible'))
            if (sessionStorage.getItem("islineoftreatment") == "true") {
                if ($('#ui_ddl_lineoftreatment').val() == "") {
                    $('#lineoftreatment').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_lineoftreatment').html() + ' is required</div>');
                    retval = false;
                }
                else {
                    if ($('#ui_ddl_treatmentsegment').val() == "")
                        objDisease.LineofTreatment = null;
                    else
                        objDisease.LineofTreatment = $('#ui_ddl_lineoftreatment').val();
                }
            }
            else
                objDisease.LineofTreatment = $('#ui_ddl_lineoftreatment').val();

        if ($('#displayQOL').is(':visible'))
            if (sessionStorage.getItem("isqualityoflife") == "true") {
                if ($('#ui_ddl_qol').val() == "") {
                    $('#QOL').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_qol').html() + ' is required</div>');
                    retval = false;
                }
                else
                    objDisease.Qualityoflife = $('#ui_ddl_qol').val();
            }
            else
                objDisease.Qualityoflife = $('#ui_ddl_qol').val();
    }

    //#region Remove err msg on key up for non grid text fields
    $('#franchise,#disease,#diseasePatientPopulation,#randomization,#blinding,#riskfactors, \
           #genomicprofile,#structure,#lineoftherapy,#stage,#treatmentSegment,#lineoftreatment, \
           #QOL').change(function () {
        $(this).next("div.error").remove();
    }).change();
    //#endregion

    $("#ui_btnSaveDiseases").click(function (e) {
        ValidateDiseaseFields();
        if (validator.validate() && retval === true)
            Savedetails(type = 2, objEditstudy = objDisease);
        else
            popupNotification.show("There are errors on the page.Please correct them to continue.", "error");
        return false;
    });

    $("#diseasestates").on("click", function () {
        $('#diseasestatescontents').show();
        LoadDiseaseStatesAttributeValues();
        LoadDiseaseData();
    });

});

function LoadDiseaseStatesAttributeValues() {
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
                        case franchise:
                            DropDowndetails(response, "displayFranchise", "ui_lbl_franchise", "ui_img_franchise", "isfranchise");
                            break;
                        //case randomized:
                        //    //if (response[i].StudyType == "Interventional") {
                        //    DropDowndetails(response, "displayRandomization", "ui_lbl_randomization", "ui_img_randomization", "israndomization");
                        //    break;
                        ////}
                        case blinding:
                            DropDowndetails(response, "displayBlinding", "ui_lbl_blinding", "ui_img_blinding", "isblinding");
                            break;
                        case riskfactors:
                            DropDowndetails(response, "displayRiskfactors", "ui_lbl_riskfactors", "ui_img_riskfactors", "isriskfactors");
                            break;
                        case genomicprofile:
                            DropDowndetails(response, "displayGenomicprofile", "ui_lbl_genomicprofile", "ui_img_genomicprofile", "isgenomicprofile");
                            break;
                        case structure:
                            DropDowndetails(response, "displayStructure", "ui_lbl_structure", "ui_img_structure", "isstructure");
                            break;
                        case lineoftherapy:
                            DropDowndetails(response, "displayLineoftherapy", "ui_lbl_lineoftherapy", "ui_img_lineoftherapy", "islineoftherapy");
                            break;
                        case disease:
                            DropDowndetails(response, "displayDisease", "ui_lbl_disease", "ui_img_disease", "isdisease");
                            break;
                        case diseaseforpatientpopulation:
                            DropDowndetails(response, "displaydiseasePatientPopulation", "ui_lbl_diseasepatientpopulation", "ui_img_diseasepatientpopulation", "isdisease");
                            break;
                        case stage:
                            DropDowndetails(response, "displayStage", "ui_lbl_stage", "ui_img_stage", "isstage");
                            break;
                        case treatmentsegment:
                            DropDowndetails(response, "displayTreatmentSegment", "ui_lbl_treatmentsegment", "ui_img_treatmentsegment", "istreatmentsegment");
                            break;
                        case lineoftreatment:
                            DropDowndetails(response, "displayLineofTreatment", "ui_lbl_lineoftreatment", "ui_img_lineoftreatment", "islineoftreatment");
                            break;
                        case qualityoflife:
                            DropDowndetails(response, "displayQOL", "ui_lbl_qol", "ui_img_qol", "isqualityoflife");
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

function LoadDiseaseData() {
$.ajax({
    async: true,
    type: "POST",
    url: "/NewStudy/GetDiseasesData/",
    cache: false,
    dataType: "json",
    data: { "StudyId": $('#StudyId').val() },
    success: function (response) {
        if (response.Data == '') {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        } else {
            $("#ui_ddl_franchise").data('kendoDropDownList').value(response.Data[0].Franchise);
            $("#ui_ddl_disease").data('kendoDropDownList').value(response.Data[0].Disease);
            if (response.Data[0].Diseasepaatientpopulation !== null) {
                var diseasepatientpopulation = response.Data[0].Diseasepaatientpopulation.split(',');
                $('#ui_diseasepatientpopulation').getKendoMultiSelect().value(diseasepatientpopulation);
            }
            $("#ui_ddl_lineoftreatment").data('kendoDropDownList').value(response.Data[0].LineofTreatment);
            $("#ui_ddl_randomization").data('kendoDropDownList').value(response.Data[0].Randomized);
            $("#ui_ddl_blinding").data('kendoDropDownList').value(response.Data[0].Binding);
            if (response.Data[0].Riskfactors !== null) {
                var riskfactors = response.Data[0].Riskfactors.split(',');
                $('#ui_riskfactors').getKendoMultiSelect().value(riskfactors);
            }
            if (response.Data[0].Riskfactors !== null) {
                var riskfactors = response.Data[0].Riskfactors.split(',');
                $('#ui_riskfactors').getKendoMultiSelect().value(riskfactors);
            }
            if (response.Data[0].GenomicProfile !== null) {
                var genomicprofile = response.Data[0].GenomicProfile.split(',');
                $('#ui_genomicprofile').getKendoMultiSelect().value(genomicprofile);
            }
            $("#ui_ddl_structure").data('kendoDropDownList').value(response.Data[0].Disease);
            if (response.Data[0].Lineoftherapy !== null) {
                var lineoftherapy = response.Data[0].Lineoftherapy.split(',');
                $('#ui_lineoftherapy').getKendoMultiSelect().value(lineoftherapy);
            }
            $("#ui_ddl_stage").data('kendoDropDownList').value(response.Data[0].DiseaseStage);
            $("#ui_ddl_treatmentsegment").data('kendoDropDownList').value(response.Data[0].TreatmentSegment);
            $("#ui_ddl_qol").data('kendoDropDownList').value(response.Data[0].Qualityoflife);
        }
    },
    failure: function (response) {
        popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
    }
});

}  

$('#ui_riskfactors').kendoMultiSelect({
    dataTextField: "Code",
    dataValueField: "CodeId",
    optionLabel: 'Select',
    autoClose: false,
    dataSource: {
        transport: {
            read: {
                dataType: "json",
                url: urlriskfactors
            }
        }
    }
});

$('#ui_genomicprofile').kendoMultiSelect({
    dataTextField: "Code",
    dataValueField: "CodeId",
    optionLabel: 'Select',
    autoClose: false,
    dataSource: {
        transport: {
            read: {
                dataType: "json",
                url: urlgenomicprofile
            }
        }
    }
});

$('#ui_lineoftherapy').kendoMultiSelect({
    dataTextField: "Code",
    dataValueField: "CodeId",
    optionLabel: 'Select',
    autoClose: false,
    dataSource: {
        transport: {
            read: {
                dataType: "json",
                url: urllineoftherapy
            }
        }
    }
});

$('#ui_diseasepatientpopulation').kendoMultiSelect({
    dataTextField: "Code",
    dataValueField: "CodeId",
    optionLabel: 'Select',
    autoClose: false,
    dataSource: {
        transport: {
            read: {
                dataType: "json",
                url: urldiseasepatientpopulation
            }
        }
    }
});