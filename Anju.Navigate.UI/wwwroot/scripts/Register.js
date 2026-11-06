$(document).ready(function () {
    var retVal = true;
    var validator = $("#ui_frmRegister").kendoValidator().data("kendoValidator");
    var pwdLength;
    var pwdIncUpperandLowerCase;
    var pwdEnforceOneNumber;
    var pwdSpecialChar;
    var isCheckPasswordLength = false;
    var isIncUpperandLowerCase = false;
    var isEnforceOneNumber = false;
    var isSpecialChar = false;
    var count = 0;
    var EmailvalidationCheck = true;
    var UserNameValidationCheck = true;
    var PasswordvalidationCheck = true;
    var IsPasswordMatch = true;
    $('#summarydetails').hide();
    $('.show_hide_icon').hide();
    $('.show_hide_email_icon').hide();

    var RegisterConstants = {
        elementIDConstant: {
            ui_ddl_salutation: "#ui_ddl_salutation",
            ui_txt_firstName: "#ui_txt_firstName",
            ui_txt_lastName: "#ui_txt_lastName",
            ui_txt_title: "#ui_txt_title",
            ui_txt_organizationName: "#ui_txt_organizationName",
            ui_txt_department: "#ui_txt_department",
            ui_txt_addressLine1: "#ui_txt_addressLine1",
            ui_txt_addressLine2: "#ui_txt_addressLine2",
            ui_ddl_country: "#ui_ddl_country",
            ui_ddl_state: "#ui_ddl_state",
            ui_ddl_city: "#ui_ddl_city",
            ui_txt_zip: "#ui_txt_zip",
            ui_txt_phone: "#ui_txt_phone",
            ui_txt_fax: "#ui_txt_fax",
            ui_txt_primaryEmailAddress: "#ui_txt_primaryEmailAddress",
            ui_txt_userName: "#ui_txt_userName",
            ui_txt_password: "#ui_txt_password",
            ui_txt_confirmPassword: "#ui_txt_confirmPassword",
            btnNext: "#btnNext",
            multiselect_credentials: "#ui_multiselect_credentials",
            ui_ddl_suffix: '#ui_ddl_suffix',
        }
    };

    $(RegisterConstants.elementIDConstant.multiselect_credentials).kendoMultiSelect({
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

    //toggle password
    $(document).on('click', '.toggle-password', function () {
        $(this).toggleClass("fa-eye fa-eye-slash");
        var input = $(RegisterConstants.elementIDConstant.ui_txt_password);
        input.attr('type') === 'password' ? input.attr('type', 'text') : input.attr('type', 'password');
    });
    // show and hide checkicon when user name is filled
    $(RegisterConstants.elementIDConstant.ui_txt_userName).blur(function () {
        if ($(this).val().length > 0) {
            $.ajax({
                async: true,
                type: "POST",
                url: "../Register/ValidateUserName",
                data: { "userName": $(this).val() },
                success: function (results) {
                    if (results) {
                        $('.show_hide_icon').show();
                        UserNameValidationCheck = true;
                        if (EmailvalidationCheck === true && UserNameValidationCheck === true) {
                            $('#btnNext').attr("disabled", false);
                        }
                    }
                    else {
                        $('.show_hide_icon').hide();
                        popupNotification.show("UserName should be unique.", "error");
                        UserNameValidationCheck = false;
                        $("#btnNext").attr("disabled", true);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        }
        else
            $('.show_hide_icon').hide();
    });

    // show and hide password notification
    $(RegisterConstants.elementIDConstant.ui_txt_password).keyup(function () {
        $(this).val().length === 0 ? $('.show_hide_notification').hide() : $('.show_hide_notification').show();
    }).keyup();

    //stepper functionality
    $('#ui_txt_firstName,#ui_txt_lastName').blur(function () {
        fillPersonalDetails();
    });

    $('#ui_multiselect_credentials,#ui_ddl_salutation').change(function () {
        fillPersonalDetails();
    });

    function fillPersonalDetails() {
        if ($(RegisterConstants.elementIDConstant.ui_ddl_salutation).val() !== "" && $(RegisterConstants.elementIDConstant.ui_txt_firstName).val() !== ''
            && $(RegisterConstants.elementIDConstant.ui_txt_lastName).val() !== '' && $(RegisterConstants.elementIDConstant.multiselect_credentials).val() !== null) {
            $('#personalDetails').addClass('fillColor');
            $('#personalDetails').parent().addClass('fillColor');
            $('#personalDetails').attr('src', '/Images/personalDetailsGreen.jpg');
        }
        else {
            $('#personalDetails').removeClass('fillColor');
            $('#personalDetails').parent().removeClass('fillColor');
            $('#personalDetails').attr('src', '/Images/personalDetails.jpg');
        }
    }

    $('#ui_txt_organizationName, #ui_txt_department, #ui_txt_addressLine1,#ui_txt_zip, #ui_txt_phone').blur(function () {
        fillCompanyDetails();
    });

    $(' #ui_ddl_country, #ui_ddl_state, #ui_ddl_city').change(function () {
        fillCompanyDetails();
    });

    function fillCompanyDetails() {
        if ($(RegisterConstants.elementIDConstant.ui_txt_organizationName).val() !== '' && $(RegisterConstants.elementIDConstant.ui_txt_department).val() !== ''
            && $(RegisterConstants.elementIDConstant.ui_txt_addressLine1).val() !== ''
            && $(RegisterConstants.elementIDConstant.ui_ddl_country).val() !== '' && $(RegisterConstants.elementIDConstant.ui_ddl_state).val() !== '' &&
            $(RegisterConstants.elementIDConstant.ui_ddl_city).val() !== '' && $(RegisterConstants.elementIDConstant.ui_txt_zip).val() !== ''
            && $(RegisterConstants.elementIDConstant.ui_txt_phone).val() !== '') {
            $('#companyDetails').addClass('fillColor');
            $('#companyDetails').parent().addClass('fillColor');
            $('#companyDetails').attr('src', '/Images/companyDetailsGreen.jpg');
        }
        else {
            $('#companyDetails').removeClass('fillColor');
            $('#companyDetails').parent().removeClass('fillColor');
            $('#companyDetails').attr('src', '/Images/companyDetails.jpg');
        }
    }

    $('#ui_txt_primaryEmailAddress,#ui_txt_userName,#ui_txt_password,#ui_txt_confirmPassword').blur(function () {
        if ($(RegisterConstants.elementIDConstant.ui_txt_primaryEmailAddress).val() !== '' && $(RegisterConstants.elementIDConstant.ui_txt_userName).val() !== ''
            && $(RegisterConstants.elementIDConstant.ui_txt_password).val() !== '' && $(RegisterConstants.elementIDConstant.ui_txt_confirmPassword).val() !== '') {
            $('#loginCredentials').addClass('fillColor');
            $('#loginCredentials').parent().addClass('fillColor');
            $('#loginCredentials').attr('src', '/Images/LoginCredentialsGreen.jpg');
        }
        else {
            $('#loginCredentials').removeClass('fillColor');
            $('#loginCredentials').parent().removeClass('fillColor');
            $('#loginCredentials').attr('src', '/Images/loginCredentials.jpg');
        }
    });

    $("#ui_txt_primaryEmailAddress").blur(function () {
       
        if ($(this).val().length > 0) {
            var expr = (/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);
            var EmailId = $(RegisterConstants.elementIDConstant.ui_txt_primaryEmailAddress).val();
            if (EmailId.match(expr)) {
                $.ajax({
                    async: true,
                    type: "POST",
                    url: "../Register/ValidateEmail",
                    data: { "email": $(this).val() },
                    success: function (results) {
                        if (results) {
                            $('.show_hide_email_icon').show();
                            IsEmailUnique = true;
                            EmailvalidationCheck  = true;
                            if (EmailvalidationCheck  === true && UserNameValidationCheck === true) {
                                $('#btnNext').attr("disabled", false);
                            }
                        }
                        else {
                            $('.show_hide_email_icon').hide();
                            IsEmailUnique = false;
                            popupNotification.show("Email should be unique.", "error");
                            $('.show_hide_email_icon').hide();
                            EmailvalidationCheck = false;
                            $("#btnNext").attr("disabled", true);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    }
                });
            }
            else {
                popupNotification.show("Invalid Primary Email Address", "error");
            }

        }
        else {
            $('.show_hide_email_icon').hide();
            popupNotification.show("Please fill Email Address", "error");
        }

    });

    //$("#ui_txt_password").blur(function () {

    //    var expr = (/^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[ !"#$%&'()*+,-./: ;<=>?@@[\]^ _`{|}~])[A-Za-z\d !"#$%&'()*+,-./:;<=>?@@[\]^_`{|}~]{2,}$/);
    //    var password = $(RegisterConstants.elementIDConstant.ui_txt_password).val();

    //    if (password.match(expr)) {
    //        if (password.length >= pwdLength) {
    //            PasswordvalidationCheck = true;
    //            if (EmailvalidationCheck === true && UserNameValidationCheck === true && PasswordvalidationCheck === true)
    //                $('#btnNext').attr("disabled", false);
    //        }
    //    }
    //    else {
    //        PasswordvalidationCheck = false;
    //        $("#btnNext").attr("disabled", true);

    //    }
    //});

    $("#ui_txt_password").blur(function () {
        var password = $("#ui_txt_password").val();
        if (isCheckPasswordLength) {
            if (parseInt(password.length) >= pwdLength)
                PasswordvalidationCheck = true;
            else 
                PasswordvalidationCheck = false;
        }
        if (PasswordvalidationCheck === true && isIncUpperandLowerCase === true) {
            if (password.match(/[A-Z]/) && password.match(/[a-z]/)) {
                PasswordvalidationCheck = true;
            }
            else
                PasswordvalidationCheck = false;              
        }
        else
            PasswordvalidationCheck = false;

        if (PasswordvalidationCheck === true &&isEnforceOneNumber === true) {
            if (password.match(/\d/)) {
                PasswordvalidationCheck = true;
            } else {
                PasswordvalidationCheck = false; 
            }
        }
        else
            PasswordvalidationCheck = false;

        if (PasswordvalidationCheck === true && isSpecialChar === true) {
            if (password.match(/[!"#$%&'()*+,-./:;<=>?@@[\]^_`{|}~]/)) {
                PasswordvalidationCheck = true;
            } else {
                PasswordvalidationCheck = false; 
            }
        }
        else
            PasswordvalidationCheck = false;

        if (EmailvalidationCheck === true && UserNameValidationCheck === true && PasswordvalidationCheck === true)
            $('#btnNext').attr("disabled", false);
        else {
            PasswordvalidationCheck = false;
            $("#btnNext").attr("disabled", true);
        }
       
    });

    $("#ui_txt_confirmPassword").blur(function () {       
        if ($(RegisterConstants.elementIDConstant.ui_txt_password).val() !== $(RegisterConstants.elementIDConstant.ui_txt_confirmPassword).val()) {
            popupNotification.show("Confirm Password is not matched with Password! ", "error");
            IsPasswordMatch = false;
            $("#btnNext").attr("disabled", true);
        }
        else {
            IsPasswordMatch = true;
            $('#btnNext').attr("disabled", false); 
        }
    });


    $.ajax
        ({
            type: "POST",
            url: "/Login/GetPwdPolicydetails",
            success: function (results) {
                $.each(results, function (index, item) {
                    if (item.GlobalKey.toUpperCase() === "EnforcePasswordLength".toUpperCase() && parseInt(item.GlobalValue) > 0) {
                        isCheckPasswordLength = true;
                        pwdLength = item.GlobalValue;
                    }
                    if (item.GlobalKey.toUpperCase() === "EnforceOneUpperandOneLowerCaseCharacter".toUpperCase() && item.GlobalValue === "True") {
                        isIncUpperandLowerCase = true;
                        pwdIncUpperandLowerCase = true;

                    }
                    if (item.GlobalKey.toUpperCase() === "EnforceOneNumber".toUpperCase() && item.GlobalValue === "True") {
                        isEnforceOneNumber = true;
                        pwdEnforceOneNumber = true;
                    }
                    if (item.GlobalKey.toUpperCase() === "EnforceSpecialChar".toUpperCase() && item.GlobalValue === "True") {
                        isSpecialChar = true;
                        pwdSpecialChar = true;
                    }

                });

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
            }
        });

    $('#ui_txt_password').one('focus', function () {
        if (parseInt(pwdLength) > 0) {
            $("#passwordHeader").append(" Your Password Needs To:");
            $("#passwordLength").append("Be At least " + pwdLength + " Characters Long.");
        }
        if (pwdIncUpperandLowerCase === true) {
            $("#upperLowerCase").append("Include At least 1 Upper Case And 1 Lower Case Character.");
        }
        else
            $('#upperLowerCase').hide();
        if (pwdEnforceOneNumber === true) {
            $("#number").append("Include At least 1 Number.");
        }
        else
            $('#number').hide();
        if (pwdSpecialChar === true) {
            $("#specialCharacter").append("Include At least 1 Special Character.");
        }
        else
            $('#specialCharacter').hide();
    });

    $('#ui_txt_password').keyup(function () {
        var policyParamCount = 0;
        var pswd = $(this).val();
        $("#errorMsg").empty();
        if (isCheckPasswordLength) {

            if (parseInt(pswd.length) >= pwdLength) {
                $('#passwordLengthImg').attr('src', '/Images/CheckGreen.jpg');
                policyParamCount += 1;
            } else {
                $('#passwordLengthImg').attr('src', '/Images/Warning.jpg');
                policyParamCount -= 1;
            }
        }
        if (isIncUpperandLowerCase) {
            if (pswd.match(/[A-Z]/) && pswd.match(/[a-z]/)) {
                $('#upperLowerCaseImg').attr('src', '/Images/CheckGreen.jpg');
                policyParamCount += 1;
            } else {
                $('#upperLowerCaseImg').attr('src', '/Images/Warning.jpg');
                policyParamCount -= 1;
            }
        }
        if (isEnforceOneNumber) {
            if (pswd.match(/\d/)) {
                $('#numberImg').attr('src', '/Images/CheckGreen.jpg');
                policyParamCount += 1;
            } else {
                $('#numberImg').attr('src', '/Images/Warning.jpg');
                policyParamCount -= 1;
            }
        }
        if (isSpecialChar) {
            if (pswd.match(/[!"#$%&'()*+,-./:;<=>?@@[\]^_`{|}~]/)) {
                $('#specialCharacterImg').attr('src', '/Images/CheckGreen.jpg');
                policyParamCount += 1;
            } else {
                $('#specialCharacterImg').attr('src', '/Images/Warning.jpg');
                policyParamCount -= 1;
            }
        }
    });

    if (EmailvalidationCheck === true && UserNameValidationCheck === true && IsPasswordMatch === true) {        
        $("#btnNext").attr("disabled", false);
    }
    else {
        $("#btnNext").attr("disabled", true);
    }

    $(RegisterConstants.elementIDConstant.btnNext).click(function () {        
        ValidateMandatoryFields();
        ShowUserDetails();      
    });

    function ValidateMandatoryFields() {
        $('.error').remove();
        retVal = true;

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
        if ($('#ui_txt_organizationName').val().length <= 0) {
            $('#organizationName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Organization Name is required</div>');
            retVal = false;
        }
        if ($('#ui_txt_department').val().length <= 0) {
            $('#department').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Department is required</div>');
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
        if ($('#ui_txt_primaryEmailAddress').val().length <= 0) {
            $('#primaryEmailAddress').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Primary Email Address is required</div>');
            retVal = false;
        }
        if ($('#ui_txt_userName').val().length <= 0) {
            $('#userName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>User Name is required</div>');
            retVal = false;
        }
        if ($('#ui_txt_password').val().length <= 0) {
            $('#password').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Password is required</div>');
            retVal = false;
        }
        if ($('#ui_txt_confirmPassword').val().length <= 0) {
            $('#confirmPassword').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Confirm Password is required</div>');
            retVal = false;
        }
        if (EmailvalidationCheck === false) {
            popupNotification.show("Email should be unique.", "error");
            retVal = false;
        }
        if (UserNameValidationCheck === false) {
            popupNotification.show("UserName should be unique.", "error");
            retVal = false;
        }
        if (PasswordvalidationCheck === false) {
            popupNotification.show("Invalid Password", "error");
            retVal = false;
        }
    }
    
    $('#ui_ddl_salutation').on("change", function () {
        $('#salutation').next("div.error").remove();
    });
    $('#ui_txt_firstName').on("keyup", function () {
        $('#firstName').next("div.error").remove();
    });
    $('#ui_txt_lastName').on("keyup", function () {
        $('#lastName').next("div.error").remove();
    });
    $('#ui_multiselect_credentials').on("change", function () {
        $('#multiselectCredentials').next("div.error").remove();
    });
    $('#ui_txt_organizationName').on("keyup", function () {
        $('#organizationName').next("div.error").remove();
    });
    $('#ui_txt_department').on("keyup", function () {
        $('#department').next("div.error").remove();
    });
    $('#ui_txt_addressLine1').on("keyup", function () {
        $('#addressLine1').next("div.error").remove();
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
    $('#ui_txt_zip').on("keyup", function () {
        $('#zipPostalCode').next("div.error").remove();
    });
    $('#ui_txt_phone').on("keyup", function () {
        $('#phone').next("div.error").remove();
    });
    $('#ui_txt_primaryEmailAddress').on("keyup", function () {
        $('#primaryEmailAddress').next("div.error").remove();
    });
    $('#ui_txt_userName').on("keyup", function () {
        $('#userName').next("div.error").remove();
    });
    $('#ui_txt_password').on("keyup", function () {
        $('#password').next("div.error").remove();
    });
    $('#ui_txt_confirmPassword').on("keyup", function () {
        $('#confirmPassword').next("div.error").remove();
    });


    function ShowUserDetails() {
        if (retVal === true) {
            $('#formdetails').hide();
            var credetials = $(RegisterConstants.elementIDConstant.multiselect_credentials).val();
            if ($(RegisterConstants.elementIDConstant.ui_txt_password).val() !== $(RegisterConstants.elementIDConstant.ui_txt_confirmPassword).val()) {
                $("#errorMsg").append("Confirm Password is not matched with Password! ");
            }
            objUsers = new Object();
            objUsers.Salutation = $(RegisterConstants.elementIDConstant.ui_ddl_salutation).val();
            objUsers.FirstName = $(RegisterConstants.elementIDConstant.ui_txt_firstName).val();
            objUsers.LastName = $(RegisterConstants.elementIDConstant.ui_txt_lastName).val();
            objUsers.Title = $(RegisterConstants.elementIDConstant.ui_txt_title).val();
            objUsers.OrganizationName = $(RegisterConstants.elementIDConstant.ui_txt_organizationName).val();
            objUsers.Department = $(RegisterConstants.elementIDConstant.ui_txt_department).val();
            objUsers.Address1 = $(RegisterConstants.elementIDConstant.ui_txt_addressLine1).val();
            objUsers.Address2 = $(RegisterConstants.elementIDConstant.ui_txt_addressLine2).val();
            objUsers.CountryId = $(RegisterConstants.elementIDConstant.ui_ddl_country).val();
            objUsers.CountryName = $(RegisterConstants.elementIDConstant.ui_ddl_country).data("kendoDropDownList").text();
            objUsers.StateName = $(RegisterConstants.elementIDConstant.ui_ddl_state).data("kendoDropDownList").text();
            objUsers.CityName = $(RegisterConstants.elementIDConstant.ui_ddl_city).data("kendoDropDownList").text();
            objUsers.Suffix = $(RegisterConstants.elementIDConstant.ui_ddl_suffix).data("kendoDropDownList").text();
            //var selectedcredentials = $('#ui_multiselect_credentials').data("kendoMultiSelect").text().toString();
            //objUsers.CredentialNames = selectedcredentials.replace(/,/g, ', ');
            objUsers.StateId = $(RegisterConstants.elementIDConstant.ui_ddl_state).val();
            objUsers.CityId = $(RegisterConstants.elementIDConstant.ui_ddl_city).val();
            objUsers.Zip = $(RegisterConstants.elementIDConstant.ui_txt_zip).val();
            objUsers.MobileNumber = $(RegisterConstants.elementIDConstant.ui_txt_phone).val();
            objUsers.Fax = $(RegisterConstants.elementIDConstant.ui_txt_fax).val();
            objUsers.PrimaryEmailId = $(RegisterConstants.elementIDConstant.ui_txt_primaryEmailAddress).val();
            objUsers.UserName = $(RegisterConstants.elementIDConstant.ui_txt_userName).val();
            objUsers.Password = $(RegisterConstants.elementIDConstant.ui_txt_password).val();
            $('#summarydetails').empty();
            $.ajax({
                async: false,
                type: "POST",
                url: '/Register/RegistrationSummary',
                data: { "objUsers": objUsers },
                success: function (result) {
                    $('#summarydetails').append(result);
                    $('#summarydetails').show();
                    $('#PrimaryEmailId').removeAttr('disabled').removeClass('k-state-disabled').focus();
                    $('#PrimaryEmailId').attr('disabled', 'disabled').addClass('k-state-disabled');
                }
            });
        }
        else {
            $('#formdetails').show();
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    }

    //disable cut, copy and paste for password and confirm password
    $('#ui_txt_password').bind("cut copy paste", function (e) {
        e.preventDefault();
    });

    $('#ui_txt_confirmPassword').bind("cut copy paste", function (e) {
        e.preventDefault();
    });
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
function onCancel() {
    window.location.href = "/";
}