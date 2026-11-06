$(document).ready(function () {
    var documentactivate = "";
    var pagename = $("#Pagetital").val();
    if (pagename === "ReviewAUpdatedDocument") {
        var html = '';
        var count = 0;
        var i;
        var path = '';
        var firstreplace = '';
        var seconreplace = '';
        $.ajax({
            async: false,
            type: "POST",
            url: "/MaintainanceAndMonitoring/GetReviewUpdatedDocuments",
            success: function (results) {
                if (results !== null) {
                    $.each(results.Data, function (index, item) {
                        count++;
                        path = results.Data[index].Path;
                        firstreplace = path.replace('/', '%');
                        firstreplace = path.replace('\\', '%');
                        html += '<tr class="col-md-12 pl-md-2"><td class="ui_label" id=ui_text_review' + count + '>' + '<a href="#" onclick="Downloads(this ,' + results.Data[index].StudyId + ')">' + results.Data[index].DocumentName + '</a>' + '</td>';
                        html += '<td><input id=ui_ddl_review' + count + '  /></td>';
                        html += '</tr>';
                    });
                    $(html).appendTo($("#reviewactivationdocuments"));
                }
                else {
                    popupNotification.show(results.msgType, "error");
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                popupNotification.show('Error', "error");
            }
        });

        var totalRowCount = $("#reviewactivationdocuments tr").length
        for (i = 1; i <= totalRowCount; i++) {
            $("#ui_ddl_review" + i).kendoDropDownList({
                autoBind: false,
                optionLabel: "Select",
                dataTextField: "Code",
                dataValueField: "Code",
                dataSource: {
                    transport: {
                        read: {
                            dataType: "json",
                            url: "/ProtocolPhase/GetReviewDecision",
                        }
                    }
                }
            });
            var dropdownlist = $("#ui_ddl_review" + i).data("kendoDropDownList");
            dropdownlist.bind("select", dropdownlist_select);
        }
    }
    else {
        $.ajax({
            async: false,
            type: "POST",
            url: "/TaskWorkFlow/GetDocumentDetails",
            success: function (results) {
                if (results.length > 0) {
                    var tableData = $('#ActivationDocumentsTable tbody');
                    $(results).each(function (index, fetchDocument) {
                        tableData.append('<tr><td class="row_description"><input type="checkbox" name="chkOrgRow" /></td>' +
                            '<td class="row_description">' + fetchDocument.DocumentName +
                            '</td><td class="row_description">' + fetchDocument.DocumentType +
                            '</td></tr>');
                    });
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                popupNotification.show('Error', "error");
            }
        });
    }


    $("#addDocumentType").click(addNewDocument);

    function addNewDocument() {
        $(".error").remove();
        var documentname = $("#ui_txt_addDocumentName").val();
        var documenttype = $("#ui_ddl_addDocumentType").val();
        var tableData = $('#ActivationDocumentsTable tbody');
        if (documentname === "" || documenttype === "") {
            $('#addDocumentType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please add document name and select document type</div>');
            retVal = false;

        }
        else {
            tableData.append('<tr><td class="row_description yellow"><input type="checkbox" Checked /></td>' +
                '<td class="row_description yellow">' + documentname +
                '</td><td class="row_description yellow">' + documenttype +
                '</td></tr>');
        }
    }


    $("#btn-Submit").click(saveDocuments);
    function saveDocuments() {
        //Reference the Table.
        var grid = document.getElementById("ActivationDocumentsTable");
        var StudyId = $("#StudyId").val();
        //Reference the CheckBoxes in Table.
        var studyowner = $("#txtStudyOwner").val();
        var checkBoxes = grid.getElementsByTagName("INPUT");
        var lsDocuments = new Array();

        for (var i = 0; i < checkBoxes.length; i++) {
            var Documents = {};
            if (checkBoxes[i].checked) {
                var row = checkBoxes[i].parentNode.parentNode;
                Documents.DocumentName = row.cells[1].innerHTML;
                Documents.DocumentType = row.cells[2].innerHTML;
                Documents.StudyId = StudyId;
                lsDocuments.push(Documents);
            }
        }

        $.ajax({
            async: false,
            type: "POST",
            url: "/MaintainanceAndMonitoring/SaveUpdateDocuments/",
            cache: false,
            data: { "lsDocuments": lsDocuments, "studyowner": studyowner },
            dataType: "json",
            success: function (results) {
                if (results.msgType === "Success") {
                    opener.location.reload();
                    window.close();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Error");
            }
        });
    }

    //Select all checkbox
    $('#selectAll').click(function (e) {
        $('tbody :checkbox').change(function () {
            $(this).closest('tr').toggleClass('yellow', this.checked);
        });
        $('thead :checkbox').change(function () {
            $('tbody :checkbox').prop('checked', this.checked).trigger('change');
        });

    });

    $('input[name="chkOrgRow"]').on('change', function () {
        $(this).closest('tr').toggleClass('yellow', $(this).is(':checked'));
    });

    function dropdownlist_select(e) {

        var item = e.item;
        var text = item.text();
        var element = documentactivate;
        $.ajax({
            async: false,
            type: "POST",
            url: "/MaintainanceAndMonitoring/ActivateUpdatedDocuments",
            data: { "documentname": documentactivate, "status": text },
            success: function (results) {
                if (results.msgType === "Success") {
                    $("#ui_dtg_UpdatedDocuments").data("kendoGrid").dataSource.read();
                    $("#ui_dtg_UpdatedDocuments").data("kendoGrid").refresh();
                    // $("#Details").data("kendoWindow").close();
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

    $("#reviewactivationdocuments td").click(function () {
        var row_num = parseInt($(this).parent().index()) + 1;
        documentactivate = $("#ui_text_review" + row_num).text();
        $('#ui_text_review').addClass(".ui_label")
    });
});
function onDataBound(e) {
    var dropdownlist = $("#ui_ddl_documentType").data("kendoDropDownList");
    dropdownlist.select(function (dataItem) {
        return dataItem.Code === "Other";
    });
}

function onSubTypeDataBound(e) {
    if ($("#ui_ddl_documentSubType").data("kendoDropDownList").dataSource._data.length > 0) {
        $("#ui_ddl_documentSubType").data("kendoDropDownList").enable(true);
        $('#documentSubTypeLabel').addClass("mandatory");
    }
    else {
        $("#ui_ddl_documentSubType").data("kendoDropDownList").enable(false);
        $('#documentSubTypeLabel').removeClass("mandatory");
        $('#documentSubType').next("div.error").remove();
    }
}

function onDocumentTypeChange() {
    if ($("#ui_ddl_documentType").data("kendoDropDownList").value() === "") {
        $('#documentSubTypeLabel').removeClass("mandatory");
        $('#documentSubType').next("div.error").remove();
    }
}

function onCancel() {
    window.close();
}
var detailsTemplate = kendo.template($("#template").html());
function showDetails(e) {
    e.preventDefault();
    var grid = $("#ui_dtg_UpdatedDocuments").getKendoGrid();

    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    var wnd = $("#Details").data("kendoWindow");
    wnd.content(detailsTemplate(dataItem));
    wnd.center().open();

    //Fill document window   
    var retVal = true;
    var LogedinUserName = $('#txtUserName').val();

    $("#ui_txt_uploadedBy").val(LogedinUserName);
    $("#ui_txt_documentName").val(dataItem.DocumentName);
    $("#ui_ddl_documentStatus").data('kendoDropDownList').value(dataItem.DocumentStatus);
    $("#ui_ddl_documentType").data('kendoDropDownList').value(dataItem.DocumentTypeId);
    $("#ui_ddl_documentSubType").data('kendoDropDownList').value(dataItem.DocumentSubType);
    $("#ui_ddl_amendmentVersion").data('kendoDropDownList').value(dataItem.DocumentVersion);
    $("#ui_dt_originalDate").data("kendoDatePicker").value(dataItem.OriginalDate);
    $("#ui_dt_expirationDate").data("kendoDatePicker").value(dataItem.ExpirationDate);
    var fileName = dataItem.DocumentName;
    var subModuleFolderName = dataItem.SubModuleName;
    var studyId = dataItem.StudyId;
    var documentId = dataItem.DocumentId;
    var path = dataItem.Path;

    $('.fileDownload').click(function () {
        fileName = $(this).attr('filename');
        subModuleFolderName = $(this).attr('subModuleFolderName');
        studyId = $(this).attr('studyId');
        //window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + studyId;
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + studyId + '&&path=' + path;

    });

    $("#btn-DocumentSubmit").click(function () {
        ValidateModalMandatoryFields();
        SaveDcouemntDetails();
    });

    $("#btn-DocumentCancel").click(function () {
        $("#Details").data("kendoWindow").close();
    });

    function ValidateModalMandatoryFields() {
        retVal = true;
        $(".error").remove();

        if ($("#ui_txt_documentName").val() === "" || $("#ui_txt_documentName").val() === null) {
            $('#documentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name is required</div>');
            retVal = false;
        }
        if ($('#ui_ddl_documentStatus').val() === 'Select' || $('#ui_ddl_documentStatus').val() === "") {
            $('#documentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Status is required</div>');
            retVal = false;
        }
        if ($('#ui_ddl_documentType').val() === 'Select' || $('#ui_ddl_documentType').val() === "") {
            $('#documentType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Type is required</div>');
            retVal = false;
        }

        if ($('#ui_ddl_documentStatus').val() === 'Pending Review') {
            $('#documentStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document should be reviewed, Please change the Document Status from Pending Review</div>');
            retVal = false;
        }

        if ($('#ui_ddl_documentType').val() !== 'Select' || $('#ui_ddl_documentType').val() !== "") {
            if (($('#ui_ddl_documentSubType').val() === 'Select' || $('#ui_ddl_documentSubType').val() === "") && $('#documentSubTypeLabel').hasClass("mandatory")) {
                $('#documentSubType').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Sub-Type is required</div>');
                retVal = false;
            }
        }
        if ($('#ui_ddl_amendmentVersion').val() === 'Select' || $('#ui_ddl_amendmentVersion').val() === "") {
            $('#amendmentVersion').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Original / Amendment Version is required</div>');
            retVal = false;
        }
        var grid = $("#ui_dtg_UpdatedDocuments").getKendoGrid();
        var datas = grid.dataSource.data();
        for (var i = 0; i < datas.length; i++) {
            if (documentId !== datas[i].DocumentId && datas[i].DocumentNameWithOutExtension === $("#ui_txt_documentName").val()) {
                $('#documentName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Document Name should be Unique</div>');
                retVal = false;
                break;
            }
        }
    }

    $('#ui_txt_documentName').on("keyup", function () {
        $('#documentName').next("div.error").remove();
    });
    $('#ui_ddl_documentStatus').on("change", function () {
        $('#documentStatus').next("div.error").remove();
    });
    $('#ui_ddl_documentType').on("change", function () {
        $('#documentType').next("div.error").remove();
    });
    $('#ui_ddl_documentSubType').on("change", function () {
        $('#documentSubType').next("div.error").remove();
    });
    $('#ui_ddl_amendmentVersion').on("change", function () {
        $('#amendmentVersion').next("div.error").remove();
    });

    function SaveDcouemntDetails() {
        if (retVal === true) {
            objDocumentDetails = new Object();
            objDocumentDetails.DocumentId = documentId;
            objDocumentDetails.StudyId = $('#StudyId').val();
            objDocumentDetails.SubModuleName = subModuleFolderName;
            objDocumentDetails.DocumentName = fileName;
            objDocumentDetails.DocumentNameWithOutExtension = "";
            objDocumentDetails.DocumentStatus = $('#ui_ddl_documentStatus').data("kendoDropDownList").text();
            objDocumentDetails.DocumentType = $('#ui_ddl_documentType').data("kendoDropDownList").text();
            objDocumentDetails.DocumentSubType = $('#ui_ddl_documentSubType').data("kendoDropDownList").text();
            objDocumentDetails.DocumentVersion = $('#ui_ddl_amendmentVersion').data("kendoDropDownList").text();
            objDocumentDetails.OriginalDate = $("#ui_dt_originalDate").val();
            objDocumentDetails.ExpirationDate = $("#ui_dt_expirationDate").val();
            objDocumentDetails.ANJU_ChangedBy = $('#LogedinUserName').val();
            $.ajax({
                async: false,
                type: "POST",
                url: "/TaskWorkFlow/UpdateDocumentDetails",
                data: { "documents": objDocumentDetails },
                success: function (results) {
                    if (results.msgType === "Success") {
                        $("#ui_dtg_UpdatedDocuments").data("kendoGrid").dataSource.read();
                        $("#ui_dtg_UpdatedDocuments").data("kendoGrid").refresh();
                        $("#Details").data("kendoWindow").close();
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
}

function filterDocumentSubType() {
    return {
        documentTypeId: $("#ui_ddl_documentType").val()
    };
}


function Show(e) {
    var gridRowData = $("#ui_dtg_UpdatedDocuments").data("kendoGrid");
    if (gridRowData) {
        var data = gridRowData.dataItem($(e).closest("tr"));
        var subModuleFolderName = data.SubModuleName;
        var fileName = data.DocumentName;
        var path = data.Path;
        window.location = "/NewStudy/DownloadFiles?fileName=" + fileName + '&&subModuleFolderName=' + subModuleFolderName + '&&studyId=' + $('#StudyId').val() + '&&path=' + path;
    }
}

$("#btn-ReviewUpdateSubmit").click(function () {
    ValidateDocument();
    SaveUpdatedDcouemntDetails();
});
var lsmailParameter = new Array();
var appUrl = $(location)[0].origin;
function ValidateDocument() {
    $(".error").remove();
    retVal = true;
    var totalRowCount = $("#reviewactivationdocuments tr").length;
    var decision = "";
    var documentRejectedName = ""
    var documentsAcceptedName = ""
    for (i = 1; i <= totalRowCount; i++) {
        decision = $("#ui_ddl_review" + i).val();
        if (decision === "") {
            $('#ui_dtg_UpdatedDocuments').before('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please specify decision for all document</div>');
            retVal = false;
            break;
        }
        if (decision === "Rejected") {
            documentRejectedName = documentRejectedName + "<li>" + $("#ui_text_review" + i).val() + "</li>" + "<br>";
        }
    }

    var StudyURL = "<a href='" + appUrl + "'> Navigate</a>";
    lsmailParameter.push($('#txtUserName').val());
    lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + "</a>");
    lsmailParameter.push(documentRejectedName);
    lsmailParameter.push($("#ui_txt_RejectedReviewCmts").val());

    //$.ajax({
    //    type: "POST",
    //    url: "/Common/SendEmail/",
    //    cache: false,
    //    data: { "mailMessage": "Document submission  rejected", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $('#txtUserName').val(), "ccMail": " " },
    //    dataType: "json",
    //    success: function (results) {
    //        popupNotification.show('Email Sent Successfully', "success");
    //    },
    //    error: function (XMLHttpRequest, textStatus, errorThrown) {
    //        popupNotification.show('Sending Email Failed', "error");
    //    }
    //});
    var grid = $("#ui_dtg_UpdatedDocuments").getKendoGrid();
    var datas = grid.dataSource.data();
    for (var item in datas) {
        if (datas[item].DocumentVersion === null) {
            $('#ui_dtg_UpdatedDocuments').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please review and classify all documents</div>');
            retVal = false;
            break;
        }
    }

}

function SaveUpdatedDcouemntDetails() {
    var studyowner = $("#txtUserName").val();
    var studyid = $("#StudyId").val();
    var comment = $("#ui_txt_RejectedReviewCmts").val();
    if (retVal) {
        $.ajax({
            async: false,
            type: "POST",
            url: "/TaskWorkFlow/AddRejectedUpdatedDocument",
            data: { "studyowner": studyowner, "studyid": studyid, "comment": comment },
            success: function (results) {
                if (results.msgType === "Success") {
                    opener.location.reload();
                    lsmailParameter.push("<a href='" + appUrl + "'>" + $('#StudyId').val() + "</a>");
                    $.ajax({
                        type: "POST",
                        url: "/Common/SendEmail/",
                        cache: false,
                        data: { "mailMessage": "Document submission review", "lsparameter": lsmailParameter, "subParam": " ", "toMail": $('#LogedinUserName').val(), "ccMail": " " },
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
                else {
                    popupNotification.show(results.msgType, "error");
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                popupNotification.show('Error', "error");
            }
        });
    }

}

function Downloads(e, studyid) {
    var documentname = e.innerHTML;
    $.ajax({
        async: false,
        type: "POST",
        url: "/TaskWorkFlow/GetDocumentByName",
        data: { "documentname": documentname, "studyid": studyid },
        success: function (results) {
            if (results !== null) {
                $.each(results.Data, function (index, item) {
                    window.location = "/NewStudy/DownloadFiles?fileName=" + results.Data[index].DocumentName + '&&subModuleFolderName=' + results.Data[index].SubModuleName + '&&studyId=' + results.Data[index].StudyId + '&&path=' + results.Data[index].Path;
                });
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            popupNotification.show('Error', "error");
        }
    });

}