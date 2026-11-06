$(document).ready(function () {
    var RegisterConstants = {
        elementIDConstant: {          
            btnConfirm: "#btnConfirm",
            btnEdit: "#btnEdit"  
        }
    }; 
    $(RegisterConstants.elementIDConstant.btnConfirm).click(function () {
        SaveNewUserDetails();        
    });
    $(RegisterConstants.elementIDConstant.btnEdit).click(function () {
        $('#formdetails').show();
        $('#summarydetails').hide();
    });
  
    function SaveNewUserDetails() {
        
        var credetials = $('#ui_multiselect_credentials').val();
        objUsers = new Object();
        objUsers.Salutation = $('#ui_ddl_salutation').val();
        objUsers.FirstName = $('#ui_txt_firstName').val();
        objUsers.LastName = $('#ui_txt_lastName').val();
        objUsers.Title = $('#ui_txt_title').val();
        objUsers.OrganizationName = $('#ui_txt_organizationName').val();
        objUsers.Department = $('#ui_txt_department').val();
        objUsers.Address1 = $('#ui_txt_addressLine1').val();
        objUsers.Address2 = $('#ui_txt_addressLine2').val();
        objUsers.CountryId = $('#ui_ddl_country').val();
        objUsers.CountryName = $('#ui_ddl_country').data("kendoDropDownList").text();
        objUsers.StateName = $('#ui_ddl_state').data("kendoDropDownList").text();
        objUsers.CityName = $('#ui_ddl_city').data("kendoDropDownList").text();   
        objUsers.StateId = $('#ui_ddl_state').val();
        objUsers.CityId = $('#ui_ddl_city').val();
        objUsers.Zip = $('#ui_txt_zip').val();
        objUsers.MobileNumber = $('#ui_txt_phone').val();
        objUsers.Fax = $('#ui_txt_fax').val();
        objUsers.PrimaryEmailId = $('#ui_txt_primaryEmailAddress').val();
        objUsers.UserName = $('#ui_txt_userName').val();
        objUsers.Password = $('#ui_txt_password').val();
        objUsers.EndUserType = "ExternalUser";
        objUsers.UserType = "PI";
        objUsers.UserStatus = "Active";

        $.ajax({
            async: false,
            type: "POST",
            url: "../Register/SaveUserDetails",
            data: { "objUsers": objUsers, "credetials": credetials },
            success: function (results) {               
                $("#errorMsg").empty();
                $("#infoMsg").empty();
                if (results.msgType === "Success") {
                    popupNotification.show(results.data, "success");                   
                    window.location.href = "/Login/Logout";
                }
                else {
                    popupNotification.show(results.data, "error");
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                popupNotification.show('Error', "error");
            }
        });
    }
});

function onCancel() {
    window.location.href = "/";
}