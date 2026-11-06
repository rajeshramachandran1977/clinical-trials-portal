$(document).ready(function () {
    var retVal = true;
    var validator = $("#ui_formInternalNewUser").kendoValidator().data("kendoValidator");
    var EmailvalidationCheck = true;
    var IsEmailUnique = true;
    var UserNameValidationCheck = true;
    var PasswordvalidationCheck = true;
    var IsPasswordMatch = true;


    $('.show_hide_email_icon').hide();
    $('.show_hide_userName_icon').hide();

    $('#ui_txt_userName').attr("autocomplete", "off");
    setTimeout('$("#ui_txt_userName").val("");', 2000);

    $('#ui_txt_password').attr("autocomplete", "off");
    setTimeout('$("#ui_txt_password").val("");', 2000);


    var RegisterConstants = {
        elementIDConstant: {
            ui_ddl_userType: "#ui_ddl_userType",
            ui_ddl_department: "#ui_ddl_department",
            ui_ddl_userStatus: "#ui_ddl_userStatus",
            ui_txt_primaryEmailAddress: "#ui_txt_primaryEmailAddress",
            ui_txt_userName: "#ui_txt_userName",
            ui_txt_password: "#ui_txt_password",
            ui_txt_confirmPassword: "#ui_txt_confirmPassword",
            ui_ddl_salutation: "#ui_ddl_salutation",
            ui_txt_firstName: "#ui_txt_firstName",
            ui_txt_lastName: "#ui_txt_lastName",
            ui_ddl_suffix: "#ui_ddl_suffix",
            ui_txt_title: "#ui_txt_title",
            ui_txt_addressLine1: "#ui_txt_addressLine1",
            ui_txt_addressLine2: "#ui_txt_addressLine2",
            ui_ddl_country: "#ui_ddl_country",
            ui_ddl_state: "#ui_ddl_state",
            ui_ddl_city: "#ui_ddl_city",
            ui_txt_zip: "#ui_txt_zip",
            ui_txt_phone: "#ui_txt_phone",
            ui_txt_fax: "#ui_txt_fax",
            btnAddUser: "#btnAddUser",
            btnResetForm: "#btnResetForm",
            multiselect_credentials: "#ui_multiselect_credentials"
        }
    };
    $("#tabstrip-left").kendoTabStrip({
        tabPosition: "left",
        animation: { open: { effects: "fadeIn" } }
    });
    $("#tabstrip").kendoTabStrip({
        animation: {
            open: {
                effects: "fadeIn"
            }
        }
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
                        $('.show_hide_userName_icon').show();
                        UserNameValidationCheck = true;
                        if (EmailvalidationCheck === true && UserNameValidationCheck === true) {
                            $('#btnAddUser').attr("disabled", false);
                        }
                    }
                    else {
                        $('.show_hide_userName_icon').hide();
                        popupNotification.show("UserName should be unique.", "error");
                        UserNameValidationCheck = false;
                        $("#btnAddUser").attr("disabled", true);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        }
        else
            $('.show_hide_userName_icon').hide();
    });

    // show and hide checkicon when Email is filled
    $(RegisterConstants.elementIDConstant.ui_txt_primaryEmailAddress).blur(function () {
        if ($(this).val().length > 0) {
            var expr = (/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);
            var EmailId = $(this).val();
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
                            EmailvalidationCheck = true;
                            if (EmailvalidationCheck === true && UserNameValidationCheck === true) {
                                $('#btnAddUser').attr("disabled", false);
                            }
                        }
                        else {
                            $('.show_hide_email_icon').hide();
                            IsEmailUnique = false;
                            popupNotification.show("Email should be unique.", "error");
                            $('.show_hide_email_icon').hide();
                            EmailvalidationCheck = false;
                            $("#btnAddUser").attr("disabled", true);
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

    // show and hide password notification
    $(RegisterConstants.elementIDConstant.ui_txt_password).keyup(function () {
        $(this).val().length === 0 ? $('.show_hide_notification').hide() : $('.show_hide_notification').show();
    }).keyup();

    //$("#ui_txt_password").blur(function () {
    //    var expr = (/^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[ !"#$%&'()*+,-./: ;<=>?@@[\]^ _`{|}~])[A-Za-z\d !"#$%&'()*+,-./:;<=>?@@[\]^_`{|}~]{6,}$/);
    //    var password = $(RegisterConstants.elementIDConstant.ui_txt_password).val();

    //    if (password.match(expr)) {
    //        PasswordvalidationCheck = true;
    //        if (EmailvalidationCheck === true && UserNameValidationCheck === true && PasswordvalidationCheck === true)
    //            $('#btnAddUser').attr("disabled", false);
    //    }
    //    else {
    //        PasswordvalidationCheck = false;
    //        $("#btnAddUser").attr("disabled", true);

    //    }
    //});

    var pwdLength;
    var pwdIncUpperandLowerCase;
    var pwdEnforceOneNumber;
    var pwdSpecialChar;
    var isCheckPasswordLength = false;
    var isIncUpperandLowerCase = false;
    var isEnforceOneNumber = false;
    var isSpecialChar = false;

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

        if (PasswordvalidationCheck === true && isEnforceOneNumber === true) {
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
            $('#btnAddUser').attr("disabled", false);
        else {
            PasswordvalidationCheck = false;
            $("#btnAddUser").attr("disabled", true);
        }

    });

    $("#ui_txt_confirmPassword").blur(function () {
        if ($(RegisterConstants.elementIDConstant.ui_txt_password).val() !== $(RegisterConstants.elementIDConstant.ui_txt_confirmPassword).val()) {
            popupNotification.show("Confirm Password is not matched with Password! ", "error");
            IsPasswordMatch = false;
            $("#btnAddUser").attr("disabled", true);
        }
        else {
            IsPasswordMatch = true;
            $('#btnAddUser').attr("disabled", false);
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


    $.ajax({
        async: true,
        type: "POST",
        url: '/Administration/GetSysCodeValues',
        success: function (result) {
            if (result != null) {
                var ddlUserStatusFlag = false;
                var ddlDepartmentFlag = false;
                var ddlUserTypeFlag = false;
                var ddlSalutationFlag = false;
                var ddlSuffixFlag = false;

                var ddlStatus = $('#ui_ddl_userStatus').data("kendoDropDownList");
                var ddlDepartment = $('#ui_ddl_department').data("kendoDropDownList");
                var ddlUserType = $('#ui_ddl_userType').data("kendoDropDownList");
                var ddlSalutation = $('#ui_ddl_salutation').data("kendoDropDownList");
                var ddlSuffix = $('#ui_ddl_suffix').data("kendoDropDownList");
                for (var i = 0; i < result.Total; i++) {
                    if (result.Data[i].ColumnName === "UserStatus" && result.Data[i].IsDefault === true) {
                        if (ddlStatus != null) {
                            ddlStatus.setOptions({ optionLabel: "" });
                            ddlStatus.select(0);
                            ddlUserStatusFlag = true;
                        }
                    } else if (ddlUserStatusFlag === false && result.Data[i].ColumnName === "UserStatus" && (result.Data[i].IsDefault === false || result.Data[i].IsDefault === null)) {
                        if (ddlStatus != null) {
                            ddlStatus.setOptions({ optionLabel: "Select" });
                            ddlStatus.select(0);
                        }
                    }
                    if (result.Data[i].ColumnName === "Department" && result.Data[i].IsDefault === true) {
                        if (ddlDepartment != null) {
                            ddlDepartment.setOptions({ optionLabel: "" });
                            ddlDepartmentFlag = true;
                            ddlDepartment.select(0);
                        }
                    } else if (ddlDepartmentFlag === false && result.Data[i].ColumnName === "Department" && (result.Data[i].IsDefault === false || result.Data[i].IsDefault === null)) {
                        if (ddlDepartment != null) {
                            ddlDepartment.setOptions({ optionLabel: "Select" });
                            ddlDepartment.select(0);
                        }
                    }
                    if (result.Data[i].ColumnName === "UserType" && result.Data[i].IsDefault === true) {
                        if (ddlUserType != null) {
                            ddlUserType.setOptions({ optionLabel: "" });
                            ddlUserTypeFlag = true;
                            ddlUserType.select(0);
                        }
                    } else if (ddlUserTypeFlag === false && result.Data[i].ColumnName === "UserType" && (result.Data[i].IsDefault === false || result.Data[i].IsDefault === null)) {
                        if (ddlUserType != null) {
                            ddlUserType.setOptions({ optionLabel: "Select" });
                            ddlUserType.select(0);
                        }
                    }
                    if (result.Data[i].ColumnName === "Salutation" && result.Data[i].IsDefault === true) {
                        if (ddlSalutation != null) {
                            ddlSalutation.setOptions({ optionLabel: "" });
                            ddlSalutationFlag = true;
                            ddlSalutation.select(0);
                        }
                    } else if (ddlSalutationFlag === false && result.Data[i].ColumnName === "Salutation" && (result.Data[i].IsDefault === false || result.Data[i].IsDefault === null)) {
                        if (ddlSalutation != null) {
                            ddlSalutation.setOptions({ optionLabel: "Select" });
                            ddlSalutation.select(0);
                        }
                    }
                    if (result.Data[i].ColumnName === "Suffix" && result.Data[i].IsDefault === true) {
                        if (ddlSuffix != null) {
                            ddlSuffix.setOptions({ optionLabel: "" });
                            ddlSuffixFlag = true;
                            ddlSuffix.select(0);
                        }
                    } else if (ddlSuffixFlag === false && result.Data[i].ColumnName === "Suffix" && (result.Data[i].IsDefault === false || result.Data[i].IsDefault === null)) {
                        if (ddlSuffix != null) {
                            ddlSuffix.setOptions({ optionLabel: "Select" });
                            ddlSuffix.select(0);
                        }
                    }
                }
            }
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
        var pswd = $(this).val();
        $("#errorMsg").empty();
        if (isCheckPasswordLength) {

            if (parseInt(pswd.length) >= pwdLength) {
                $('#passwordLengthImg').attr('src', '/Images/CheckGreen.jpg');

            } else {
                $('#passwordLengthImg').attr('src', '/Images/Warning.jpg');
            }
        }
        if (isIncUpperandLowerCase) {
            if (pswd.match(/[A-Z]/) && pswd.match(/[a-z]/)) {
                $('#upperLowerCaseImg').attr('src', '/Images/CheckGreen.jpg');
            } else {
                $('#upperLowerCaseImg').attr('src', '/Images/Warning.jpg');
            }
        }
        if (isEnforceOneNumber) {
            if (pswd.match(/\d/)) {
                $('#numberImg').attr('src', '/Images/CheckGreen.jpg');
            } else {
                $('#numberImg').attr('src', '/Images/Warning.jpg');
            }
        }
        if (isSpecialChar) {
            if (pswd.match(/[!"#$%&'()*+,-./:;<=>?@@[\]^_`{|}~]/)) {
                $('#specialCharacterImg').attr('src', '/Images/CheckGreen.jpg');

            } else {
                $('#specialCharacterImg').attr('src', '/Images/Warning.jpg');
            }
        }
    });

    if (EmailvalidationCheck === true && UserNameValidationCheck === true && IsPasswordMatch === true && IsEmailUnique === true) {
        $("#btnAddUser").attr("disabled", false);
    }
    else {
        $("#btnAddUser").attr("disabled", true);
    }

    $(RegisterConstants.elementIDConstant.btnAddUser).click(function () {
        ValidateMandatoryFields();
        SaveNewUserDetails();
    });
    function ValidateMandatoryFields() {
        retVal = true;
        $('.error').remove();

        if (($('#ui_ddl_userStatus').val() === "Select") || ($('#ui_ddl_salutation').val() === "")) {
            $('#userStatus').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>User Status is required</div>');
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
    }

    $('#ui_ddl_userStatus').on("change", function () {
        $('#userStatus').next("div.error").remove();
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


    $(RegisterConstants.elementIDConstant.btnResetForm).click(function () {
        $('#ui_formInternalNewUser')[0].reset();
    });

    function resetForm() {
        $('#ui_formInternalNewUser').trigger('reset');
    }

    //reset the form on click of reset
    $('#btnResetForm').click(function () {
        $('#ui_formInternalNewUser')[0].reset();
    });

    function SaveNewUserDetails() {
        if (validator.validate() && retVal === true) {

            var credetials = $(RegisterConstants.elementIDConstant.multiselect_credentials).val();
            if ($(RegisterConstants.elementIDConstant.ui_txt_password).val() !== $(RegisterConstants.elementIDConstant.ui_txt_confirmPassword).val()) {
                $("#errorMsg").append("Confirm Password is not matched with Password! ");
            }
            objUsers = new Object();
            objUsers.UserType = $(RegisterConstants.elementIDConstant.ui_ddl_userType).val();
            objUsers.Department = $(RegisterConstants.elementIDConstant.ui_ddl_department).val();
            objUsers.UserStatus = $(RegisterConstants.elementIDConstant.ui_ddl_userStatus).val();
            objUsers.Suffix = $(RegisterConstants.elementIDConstant.ui_ddl_suffix).val();
            objUsers.PrimaryEmailId = $(RegisterConstants.elementIDConstant.ui_txt_primaryEmailAddress).val();
            objUsers.UserName = $(RegisterConstants.elementIDConstant.ui_txt_userName).val();
            objUsers.Password = $(RegisterConstants.elementIDConstant.ui_txt_password).val();
            objUsers.Salutation = $(RegisterConstants.elementIDConstant.ui_ddl_salutation).val();
            objUsers.FirstName = $(RegisterConstants.elementIDConstant.ui_txt_firstName).val();
            objUsers.LastName = $(RegisterConstants.elementIDConstant.ui_txt_lastName).val();
            objUsers.Title = $(RegisterConstants.elementIDConstant.ui_txt_title).val();
            objUsers.Address1 = $(RegisterConstants.elementIDConstant.ui_txt_addressLine1).val();
            objUsers.Address2 = $(RegisterConstants.elementIDConstant.ui_txt_addressLine2).val();
            objUsers.CountryId = $(RegisterConstants.elementIDConstant.ui_ddl_country).val();
            objUsers.StateId = $(RegisterConstants.elementIDConstant.ui_ddl_state).val();
            objUsers.CityId = $(RegisterConstants.elementIDConstant.ui_ddl_city).val();
            objUsers.Zip = $(RegisterConstants.elementIDConstant.ui_txt_zip).val();
            objUsers.MobileNumber = $(RegisterConstants.elementIDConstant.ui_txt_phone).val();
            objUsers.Fax = $(RegisterConstants.elementIDConstant.ui_txt_fax).val();
            objUsers.EndUserType = "InternalUser";

            $.ajax({
                async: false,
                type: "POST",
                url: "../Register/SaveUserDetails",
                data: { "objUsers": objUsers, "credetials": credetials },
                success: function (results) {
                    if (results.msgType === "Success") {
                        popupNotification.show(results.data, "info");
                        $("#ui_formInternalNewUser")[0].reset();
                        $('.show_hide_email_icon').hide();
                        $('.show_hide_userName_icon').hide();
                        $('.show_hide_notification').hide();
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

    //disable cut, copy and paste for password and confirm password
    $('#ui_txt_password').bind("cut copy paste", function (e) {
        e.preventDefault();
    });

    $('#ui_txt_confirmPassword').bind("cut copy paste", function (e) {
        e.preventDefault();
    });

    $('.toggle-password').on('click', function () {
        $(this).toggleClass("fa-eye fa-eye-slash");
        var input = $('#ui_txt_password');
        input.attr('type') === 'password' ? input.attr('type', 'text') : input.attr('type', 'password');
    });
});