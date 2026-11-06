$(document).ready(function () {
    var userId = 0;
    var UserType = '';
    var UserStatus = '';
    $.ajax({
        async: false,
        type: "POST",
        url: '/NewStudy/GetUserDetailsByUserName',
        data: { "userName": $('#LoginUsername').val() },
        success: function (result) {
            if (result !== null) {
                userId = result.UserId;
                $("#ui_txt_firstName").val(result.FirstName);
                $("#ui_ddl_salutation").data('kendoDropDownList').value(result.Salutation);
                $("#ui_txt_title").val(result.Title);
                $('#ui_txt_organizationName').val(result.OrganizationName);
                $("#ui_ddl_country").data('kendoDropDownList').value(result.CountryId);
                $("#ui_ddl_state").data('kendoDropDownList').value(result.StateId);
                $("#ui_ddl_city").data('kendoDropDownList').value(result.CityId);
                $('#ui_txt_primaryEmailAddress').val(result.PrimaryEmailId);
                $("#ui_txt_lastName").val(result.LastName);
                $("#ui_ddl_suffix").data('kendoDropDownList').value(result.Suffix);
                $('#ui_txt_zip').val(result.Zip);
                $('#ui_txt_phone').val(result.MobileNumber);
                $('#ui_txt_fax').val(result.Fax);
                $('#ui_txt_addressLine1').val(result.Address1);
                $('#ui_txt_addressLine2').val(result.Address2);
                $('#ui_txt_userName').val(result.UserName);
                $('#ui_txt_department').val(result.Department);
                UserType = result.UserType;
                UserStatus = result.UserStatus;
            }
        }
    });

    var retVal = true;
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

    $("#ui_btn_myProfile").click(updateProfile);
    function updateProfile() {
        ValidateMandatoryFields();
        UpdateUserDetails();
    }

    function ValidateMandatoryFields() {
        retVal = true;
        $('.error').remove();

        if ($('#ui_txt_primaryEmailAddress').val().length <= 0) {
            $('#primaryEmailAddress').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Primary Email Address is required</div>');
            retVal = false;
        }
        if ($('#ui_txt_userName').val().length <= 0) {
            $('#userName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>User Name is required</div>');
            retVal = false;
        }
        if (($('#ui_ddl_salutation').val() === "Select") || ($('#ui_ddl_salutation').val() === "")) {
            $('#salutation').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Salutation is required</div>');
            retVal = false;
        }
        if ($('#ui_txt_firstName').val().length <= 0) {
            $('#firstName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>First Name is required</div>');
            retVal = false;
        }
        if ($('#ui_txt_lastName').val().length <= 0) {
            $('#lastName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Last Name is required</div>');
            retVal = false;
        }
        if ($("#ui_multiselect_credentials").data("kendoMultiSelect").value().length <= 0) {
            $('#multiselectCredentials').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Credentials is required</div>');
            retVal = false;
        }
        if ($('#ui_txt_addressLine1').val().length <= 0) {
            $('#addressLine1').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Address Line 1 is required</div>');
            retVal = false;
        }
        if ($('#ui_ddl_country').val() === 'Select' || $('#ui_ddl_country').val() === "") {
            $('#country').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Country is required</div>');
            retVal = false;
        }
        if ($('#ui_ddl_country').val() !== 'Select' || $('#ui_ddl_country').val() !== "") {
            if ($('#ui_ddl_state').val() === 'Select' || $('#ui_ddl_state').val() === "") {
                $('#state').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>State/Region is required</div>');
                retVal = false;
            }
        }
        if ($('#ui_ddl_state').val() !== 'Select' || $('#ui_ddl_state').val() !== "") {
            if ($('#ui_ddl_city').val() === 'Select' || $('#ui_ddl_city').val() === "") {
                $('#city').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>City is required</div>');
                retVal = false;
            }
        }
        if ($('#ui_txt_zip').val().length <= 0) {
            $('#zipPostalCode').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Zip/Postal Code is required</div>');
            retVal = false;
        }

        if ($('#ui_txt_phone').val().length <= 0) {
            $('#phone').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Phone is required</div>');
            retVal = false;
        }
        if ($('#ui_txt_organizationName').val().length <= 0) {
            $('#organizationName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Organization Name is required</div>');
            retVal = false;
        }
        if ($('#ui_txt_department').val().length <= 0) {
            $('#department').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Department Name is required</div>');
            retVal = false;
        }
    }
    $("#ui_txt_firstName").on("keyup", function (e) {
        $('#firstName').next("div.error").remove();
    });
    $("#ui_ddl_salutation").change(function () {
        $('#salutation').next("div.error").remove();
    });
    $("#ui_txt_organizationName").keyup(function () {
        $('#organizationName').next("div.error").remove();
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
    $("#ui_txt_primaryEmailAddress").keyup(function () {
        $('#primaryEmailAddress').next("div.error").remove();
    });
    $("#ui_txt_lastName").keyup(function () {
        $('#lastName').next("div.error").remove();
    });
    $("#ui_multiselect_credentials").change(function () {
        $('#multiselectCredentials').next("div.error").remove();
    });
    $("#ui_txt_department").keyup(function () {
        $('#department').next("div.error").remove();
    });
    $("#ui_txt_zip").keyup(function () {
        $('#zipPostalCode').next("div.error").remove();
    });
    $("#ui_txt_phone").keyup(function () {
        $('#phone').next("div.error").remove();
    });
    $("#ui_txt_userName").keyup(function () {
        $('#userName').next("div.error").remove();
    });
    $("#ui_txt_addressLine1").keyup(function () {
        $('#addressLine1').next("div.error").remove();
    });

    function UpdateUserDetails() {
        if (retVal === true) {
            var credetials = $("#ui_multiselect_credentials").val();
            objUsers = new Object();
            objUsers.UserId = userId;
            objUsers.FirstName = $("#ui_txt_firstName").val();
            objUsers.Salutation = $("#ui_ddl_salutation").val();
            objUsers.Title = $("#ui_txt_title").val();
            objUsers.OrganizationName = $("#ui_txt_organizationName").val();
            objUsers.CountryId = $("#ui_ddl_country").val();
            objUsers.StateId = $("#ui_ddl_state").val();
            objUsers.CityId = $("#ui_ddl_city").val();
            objUsers.PrimaryEmailId = $("#ui_txt_primaryEmailAddress").val();
            objUsers.LastName = $("#ui_txt_lastName").val();
            objUsers.Suffix = $("#ui_ddl_suffix").val();
            objUsers.Department = $("#ui_txt_department").val();
            objUsers.Zip = $("#ui_txt_zip").val();
            objUsers.MobileNumber = $("#ui_txt_phone").val();
            objUsers.Fax = $("#ui_txt_fax").val();
            objUsers.UserName = $("#ui_txt_userName").val();
            objUsers.Address1 = $("#ui_txt_addressLine1").val();
            objUsers.Address2 = $("#ui_txt_addressLine2").val();
            objUsers.UserType = UserType;
            objUsers.UserStatus = UserStatus;
            objUsers.IsActive = true;
            objUsers.IsDeleted = false;
            $.ajax({
                async: false,
                type: "POST",
                url: "../Register/UpdateUserDetails",
                data: { "objUsers": objUsers, "credetials": credetials },
                success: function (results) {
                    if (results.msgType === "Success") {
                        popupNotification.show(results.data, "info");
                        $('#piDashboardHome').hide();
                        $('#piDashboardHelp').hide();
                        $('#piDashboardMyProfile').hide();
                        $('#piDashboardProfileSubmit').show();
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
    }
});

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

$("#ui_btn_myProfilesubmitted").click(function () {
    window.location.href = "/Dashboard/PIDashboard";
});
