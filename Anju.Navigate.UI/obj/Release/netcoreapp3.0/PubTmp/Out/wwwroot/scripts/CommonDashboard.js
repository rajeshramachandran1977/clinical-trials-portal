$(document).ready(function () {
    $("#gridMyStudyList").removeClass(".k-context-menu");
    var tempMessage = document.getElementById('tempdata') ?
        document.getElementById('tempdata').value : null;
    if (tempMessage === "ActiveModel") {
        $("#ui_mySwitchProxyUserModel").modal('show');
    }

    $("#context-menu").hide();

    $(".ui_userPrefrence").click(function () {
        var proxyuser = "";
        $("#ui_proxyresult").empty();
        $("#ui_proxyresult").collapse();
        $("#ui_proxyresult").hide();
        $.ajax({
            async: true,
            type: "POST",
            url: "/Administration/GetProxyUser/",
            cache: false,
            dataType: "text",
            success: function (result) {
                proxyuser = result;
                $("#ui_txt_proxyName").val(proxyuser);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Error");
            }
        });
    });

    $('#ui_btnProxyUserSubmission').click(function () {
        var proxyuser = $("#ui_txt_proxyName").val();
        $.ajax({
            async: false,
            type: "POST",
            url: "/Administration/CreateProxyUser/",
            cache: false,
            data: { "userName": proxyuser },
            dataType: "json",
            success: function (result) {
                if (result.msgType === "Success") {
                    $('#ui_proxyresult').empty();
                    $('#ui_proxyresult').append('<span class="greenColor">Preference(s) successfully saved</span>');
                    setTimeout(function () {
                        $('.myproxyModal').modal('hide');
                    }, 4000);
                }
                else {
                    $('#ui_proxyresult').empty();
                    $('#ui_proxyresult').append('<span class="redColor">' + result.msgType + '</span>');
                }
                $("#ui_proxyresult").show();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Error");
            }
        });
    });

    $("#ui_btnSwitchProxySubmission").click(function () {
        var proxyuser = $("#ui_ddl_proxyuser").val();
        $.ajax({
            async: false,
            type: "POST",
            url: "/Login/CheckProxyUser/",
            cache: false,
            data: { "username": proxyuser },
            dataType: "json",
            success: function (result) {
                if (result.message === "PI") {

                    window.location.href = "/Dashboard/PIDashboard";
                }
                else
                    window.location.href = "/Dashboard/IISAdminDashboard";


            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Error");
            }
        });
    });   
});

var idValue = new Array();
var StudyId;
var data;
var newData;
var myContextMenu;
var removePatientAccrual = false;
var ISInitiateStudyCloseoutTaskCompleted = false;
var UserName = $("#Proxyuser").val();
var ProxyUserName = UserName.replace("on behalf of ", '');
var ANJU_AddedBy = "";
var Institution;
 
function studyListActionDisplay(e) {
    var gridRowData = $("#gridMyStudyList").data("kendoGrid");    
    if (gridRowData) {
        var data = this.dataItem($(e.currentTarget).closest("tr"));
        StudyId = data.StudyId;
        PITaskStatus = data.PITaskStatus;
        Stage = data.Stage;
        ANJU_AddedBy = data.ANJU_AddedBy;
        StudyNumber = data.StudyNumber;
        TitleofTrial = data.TitleofTrial;
         Institution = data.Institution;
        ISInitiateStudyCloseoutTaskCompleted = data.ISInitiateStudyCloseoutTaskCompleted;

        if (PITaskStatus === "Study Closeout Initiated" && Stage === "Study Closeout Initiated") {
            $('#closeStudy').show();
            $('#accuralUpdate,#amendProtocol,#updatedDocuments').hide();
        }
        if (Stage === "Active") {
            $('#closeStudy').hide();
            $('#accuralUpdate,#amendProtocol,#updatedDocuments').show();
        }
      
    }   
    addContextMenu(e);  
   // e.stopPropagation();
    $.ajax({
        async: false,
        type: "POST",
        url: '/MaintainanceAndMonitoring/GetPatientEnrollmentDetails',
        data: { "studyId": StudyId },
        success: function (result) {
            if (result.Data.length > 0 && result.Data[0].LastPatientLastVisit !== null) {
                $("#AccrualUpdate").remove();
                removePatientAccrual = true;
                         
                $("#gridMyStudyList").removeClass(".k-context-menu");
            } else {
                removePatientAccrual = false;

            }
        }
    });
    
}

function addContextMenu(e) {  
    var x = e.pageX;
    var y = e.pageY;
    $('#context-menu li').remove();        
    if (ISInitiateStudyCloseoutTaskCompleted === false || ISInitiateStudyCloseoutTaskCompleted === null) {
        $('#context-menu').hide();
        $.ajax({
            async: false,
            type: "POST",
            url: '/NewStudy/GetSysCodeValues',
            data: { "type": "MaintainanceAndMonitoring" },
            success: function (result) {                
                for (var i = 0; i < result.length; i++) {
                    var idValue = result[i].Description;
                    $("#context-menu").append("<li class='ui_label' id=" + idValue + ">" + result[i].Code + "</li>");
                }  
            }
        });                
        myContextMenu = $("#context-menu").kendoContextMenu({
            target: "#target",
            select: function (e) {
                RedirectToPages($(e.item).text());
                //$('#context-menu').hide();
            },
            openOnClick: true
        }).data("kendoContextMenu");
        myContextMenu.open(x, y);
    }
    if (ISInitiateStudyCloseoutTaskCompleted === true) {        
        $.ajax({
            async: false,
            type: "POST",
            url: '/StudyCloseout/GetGearTasks',
            data: { "studyId": StudyId },
            success: function (closeOutResult) {             
                for (var i = 0; i < closeOutResult.length; i++) {
                    var idValue = closeOutResult[i].TaskName;
                    if (ProxyUserName.length > 0 && closeOutResult[i].AssignedTo === ProxyUserName) {
                        $("#context-menu").append("<li class='ui_label' id=" + idValue + ">" + closeOutResult[i].TaskName + "</li>");
                    }
                    else if (closeOutResult[i].AssignedTo === $("#Username").val() && ProxyUserName.length === 0) {
                        $("#context-menu").append("<li class='ui_label' id=" + idValue + ">" + closeOutResult[i].TaskName + "</li>");
                    }
                }                              
            }
        });
        myContextMenu = $("#context-menu").kendoContextMenu({
            target: "#target",
            select: function (e) {
                RedirectToPages($(e.item).text());
                //$('#context-menu').hide();
            }
        }).data("kendoContextMenu");
        myContextMenu.open(x, y);
    }
}

function RedirectToPages(PageName) {    
    var w = 1020;
    var h = 600;
    var left = Number((screen.width / 2) - (w / 2));
    var top = Number((screen.height / 2) - (h / 2));
    var gridRowData = $("#gridMyStudyList").data("kendoGrid");
    var piTaskStatus = "Active";
    if (PageName === "Accrual Update") {        
        if (gridRowData) {          
            obj = new Object();
            obj.StudyId = StudyId;
            obj.mode = "Update";
            obj.PITaskStatus = piTaskStatus;
            obj.StudyNumber = StudyNumber;
            obj.TitleofTrial = TitleofTrial;
            obj.Institution = Institution;
            $.ajax({
                async: false,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        $("#context-menu").hide();
                        window.open("../MaintainanceAndMonitoring/PatientAccrual", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=no,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
    }
    else if (PageName === "Amend Protocol/budget") {
       
        if (gridRowData) {           
            obj = new Object();
            obj.StudyId = StudyId;
            obj.mode = "Update";
            obj.PITaskStatus = piTaskStatus;
            obj.StudyNumber = StudyNumber;
            obj.TitleofTrial = TitleofTrial;
            obj.Institution = Institution;

            $.ajax({
                async: false,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        $("#context-menu").hide();
                        window.open("../MaintainanceAndMonitoring/AmendProtocolOrBudget", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=no,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');

                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }

    }
    else if (PageName === "Update Documents") {
        if (gridRowData) {         
            obj = new Object();
            obj.StudyId = StudyId;
            obj.mode = "Update";
            obj.PITaskStatus = piTaskStatus;
            obj.StudyNumber = StudyNumber;
            obj.TitleofTrial = TitleofTrial;
            obj.Institution = Institution;

            $.ajax({
                async: false,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        $("#context-menu").hide();
                        window.open("../MaintainanceAndMonitoring/UpdateDocumentforPatientAccrualUpdate", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=no,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');

                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }

    }
    else if (PageName === "Final Study Data/Report") {
        if (gridRowData) {           
            obj = new Object();
            obj.StudyId = StudyId;
            obj.ANJU_AddedBy = ANJU_AddedBy;
            obj.GMRCTaskName = PageName;
            obj.TitleofTrial = TitleofTrial;
            obj.Institution = Institution;
            obj.StudyNumber = StudyNumber;

            $.ajax({
                async: true,
                type: "POST",
                url: "/Login/OpenNewWindow",
                data: { "obj": obj },
                success: function (results) {
                    if (results.data === "Success") {
                        window.open("../StudyCloseout/StudyCloseout", 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=no,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
                    }
                    else {
                        alert("Error");
                    }
                }
            });
        }
    }
}