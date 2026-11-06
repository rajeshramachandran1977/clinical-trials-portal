function OnDeleteOfRecord(e) {
    var grid = null;
    switch (e.type) {     
        case "destroy":
            grid = $("#Usergrid").data("kendoGrid");
            grid.dataSource.read();
            $('.showFormOnUserNameClick').hide();
            break;
    }
}

$(document).ready(function () {
    $('.show_hide_edit_notification').hide()

    $.ajax({
        async: true,
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
            if (parseInt(pwdLength) > 0) {
                $("#passwordLengthChangePwd").append("At least " + pwdLength + " characters in length");
            }
            if (pwdIncUpperandLowerCase === true) {
                $("#passwordUpperLowerCase").append("At least one upper and lower case character");
            }
            if (pwdEnforceOneNumber === true) {
                $("#passwordNumberic").append("At least one numeric character");
            }
            if (pwdSpecialChar === true) {
                $("#passwordSpecial").append("At least one special character");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
    //$('#ui_txt_passwordEdit').one('focus', function () {
    $('#ui_txt_passwordEdit').one('focus', function () {
        if (parseInt(pwdLength) > 0) {
            $("#passwordEditHeader").append(" Your Password Needs To:");
            $("#passwordEditLength").append("Be At least " + pwdLength + " Characters Long.");
        }
        if (pwdIncUpperandLowerCase === true) {
            $("#upperLowerCaseEdit").append("Include At least 1 Upper Case And 1 Lower Case Character.");
        }
        else
            $('#upperLowerCaseEdit').hide();
        if (pwdEnforceOneNumber === true) {
            $("#numberEdit").append("Include At least 1 Number.");
        }
        else
            $('#numberEdit').hide();
        if (pwdSpecialChar === true) {
            $("#specialCharacterEdit").append("Include At least 1 Special Character.");
        }
        else
            $('#specialCharacterEdit').hide();
    });
    $("#ui_txt_passwordEdit").blur(function () {
        var password = $("#ui_txt_passwordEdit").val();
        if (isCheckPasswordLength) {
            if (parseInt(password.length) >= pwdLength)
                PasswordvalidationCheckEdit = true;
            else
                PasswordvalidationCheckEdit = false;
        }
        if (PasswordvalidationCheckEdit === true && isIncUpperandLowerCase === true) {
            if (password.match(/[A-Z]/) && password.match(/[a-z]/)) {
                PasswordvalidationCheckEdit = true;
            }
            else
                PasswordvalidationCheckEdit = false;
        }
        else
            PasswordvalidationCheckEdit = false;

        if (PasswordvalidationCheckEdit === true && isEnforceOneNumber === true) {
            if (password.match(/\d/)) {
                PasswordvalidationCheckEdit = true;
            } else {
                PasswordvalidationCheckEdit = false;
            }
        }
        else
            PasswordvalidationCheckEdit = false;

        if (PasswordvalidationCheckEdit === true && isSpecialChar === true) {
            if (password.match(/[!"#$%&'()*+,-./:;<=>?@@[\]^_`{|}~]/)) {
                PasswordvalidationCheckEdit = true;
            } else {
                PasswordvalidationCheckEdit = false;
            }
        }
        else
            PasswordvalidationCheckEdit = false;


    });
    $(RegisterConstants.elementIDConstant.ui_txt_password).keyup(function () {
        $(this).val().length === 0 ? $('.show_hide_edit_notification').hide() : $('.show_hide_edit_notification').show();
    }).keyup();

    $('#ui_txt_passwordEdit').keyup(function () {

        var pswd = $('#ui_txt_passwordEdit').val();
        $("#errorMsg").empty();
        if (isCheckPasswordLength) {

            if (parseInt(pswd.length) >= pwdLength) {
                $('#passwordLengthImgEdit').attr('src', '/Images/CheckGreen.jpg');

            } else {
                $('#passwordLengthImgEdit').attr('src', '/Images/Warning.jpg');
            }
        }
        if (isIncUpperandLowerCase) {
            if (pswd.match(/[A-Z]/) && pswd.match(/[a-z]/)) {
                $('#upperLowerCaseImgEdit').attr('src', '/Images/CheckGreen.jpg');
            } else {
                $('#upperLowerCaseImgEdit').attr('src', '/Images/Warning.jpg');
            }
        }
        if (isEnforceOneNumber) {
            if (pswd.match(/\d/)) {
                $('#numberImgEdit').attr('src', '/Images/CheckGreen.jpg');
            } else {
                $('#numberImgEdit').attr('src', '/Images/Warning.jpg');
            }
        }
        if (isSpecialChar) {
            if (pswd.match(/[!"#$%&'()*+,-./:;<=>?@@[\]^_`{|}~]/)) {
                $('#specialCharacterImgEdit').attr('src', '/Images/CheckGreen.jpg');

            } else {
                $('#specialCharacterImgEdit').attr('src', '/Images/Warning.jpg');
            }
        }
    });
    $("#ui_txt_passwordConfirm").blur(function () {

        if ($(RegisterConstants.elementIDConstant.ui_txt_password).val() !== $(RegisterConstants.elementIDConstant.ui_txt_confirmPassword).val()) {
            popupNotification.show("Confirm Password is not matched with Password! ", "error");
            IsPasswordMatch = false;
        }
        else {
            IsPasswordMatch = true;
        }
    });


    //disable Setting Name
    $("#ui_txt_settingName").prop("disabled", true).addClass("k - state - disabled").css('background-color', '#DEDEDE');
    //hidng form and delete button on page load
    $(".showFormOnUserNameClick").hide();
    $('#ui_btn_save').click(function () {
        ValidatePasswordFields();
        SavePasswordDetails();
    });

    var retVal = true;
    var PasswordvalidationCheck = true;
    var PasswordvalidationCheckEdit = true;
    $('.greenColor,.redColor').remove();
    function ValidatePasswordFields() {
        $('.error').remove();
        retVal = true;
        if ($('#ui_txt_currentPassword').val() === "" || $('#ui_txt_currentPassword').val() === null) {
            $('#currentPassword').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please enter Current Password.</div>');
            retVal = false;
        }
        if ($('#ui_txt_enterNewPassword').val() === "" || $('#ui_txt_enterNewPassword').val() === null) {
            $('#enterNewPassword').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please enter New Password.</div>');
            retVal = false;
        }
        if ($('#ui_txt_confirmNewPassword').val() === "" || $('#ui_txt_confirmNewPassword').val() === null) {
            $('#confirmNewPassword').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please enter Confirm New Password.</div>');
            retVal = false;
        }
        if ($('#ui_txt_confirmNewPassword').val() !== "" || $('#ui_txt_confirmNewPassword').val() !== null) {
            if ($('#ui_txt_enterNewPassword').val() !== $('#ui_txt_confirmNewPassword').val()) {
                $('#confirmNewPassword').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Passwords do not match.</div>');
                retVal = false;
            }
        }

        if ($('#ui_txt_currentPassword').val() === $('#ui_txt_enterNewPassword').val() && $('#ui_txt_currentPassword').val().length > 0 && $('#ui_txt_enterNewPassword').val().length > 0) {
            $('#confirmNewPassword').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Current Password and New Password cannot be same.</div>');
            retVal = false;
        }

    }

    $("#ui_txt_enterNewPassword").blur(function () {
        $('.greenColor,.redColor').remove();
        var password = $("#ui_txt_enterNewPassword").val();
        if (isCheckPasswordLength) {
            if (parseInt(password.length) >= pwdLength)
                PasswordvalidationCheck = true;
            else
                PasswordvalidationCheck = false;
        }
        if (PasswordvalidationCheck === true && pwdIncUpperandLowerCase === true) {
            if (password.match(/[A-Z]/) && password.match(/[a-z]/)) {
                PasswordvalidationCheck = true;
            }
            else
                PasswordvalidationCheck = false;
        }

        if (PasswordvalidationCheck === true && pwdEnforceOneNumber === true) {
            if (password.match(/\d/)) {
                PasswordvalidationCheck = true;
            } else {
                PasswordvalidationCheck = false;
            }
        }


        if (PasswordvalidationCheck === true && pwdSpecialChar === true) {
            if (password.match(/[!"#$%&'()*+,-./:;<=>?@@[\]^_`{|}~]/)) {
                PasswordvalidationCheck = true;
            } else {
                PasswordvalidationCheck = false;
            }
        }


        if (PasswordvalidationCheck === false && parseInt(password.length) > 0) {
            PasswordvalidationCheck = false;
            $('#confirmNewPassword').after('<div class="redColor font_12">The provided password does not meet system requirements.</div>');
        }

    });
    $("#ui_txt_confirmNewPassword").blur(function () {
        $('.greenColor,.redColor').remove();
        var password = $("#ui_txt_enterNewPassword").val();
        if (isCheckPasswordLength) {
            if (parseInt(password.length) >= pwdLength)
                PasswordvalidationCheck = true;
            else
                PasswordvalidationCheck = false;
        }
        if (PasswordvalidationCheck === true && pwdIncUpperandLowerCase === true) {
            if (password.match(/[A-Z]/) && password.match(/[a-z]/)) {
                PasswordvalidationCheck = true;
            }
            else
                PasswordvalidationCheck = false;
        }

        if (PasswordvalidationCheck === true && pwdEnforceOneNumber === true) {
            if (password.match(/\d/)) {
                PasswordvalidationCheck = true;
            } else {
                PasswordvalidationCheck = false;
            }
        }


        if (PasswordvalidationCheck === true && pwdSpecialChar === true) {
            if (password.match(/[!"#$%&'()*+,-./:;<=>?@@[\]^_`{|}~]/)) {
                PasswordvalidationCheck = true;
            } else {
                PasswordvalidationCheck = false;
            }
        }


        if (PasswordvalidationCheck === false && parseInt(password.length) > 0) {
            PasswordvalidationCheck = false;
            $('#confirmNewPassword').after('<div class="redColor font_12">The provided password does not meet system requirements.</div>');
        }

    });
    //$('#ui_txt_passwordEdit').on('input', function () {
    //    $(this).text().remove();
    //});
    $('#ui_txt_currentPassword').on('keyup', function () {
        $('#currentPassword').next("div.error").remove();
    });
    $('#ui_txt_enterNewPassword').on('keyup', function () {
        $('#enterNewPassword').next("div.error").remove();
    });
    $('#ui_txt_confirmNewPassword').on('keyup', function () {
        $('#confirmNewPassword').next("div.error").remove();
    });
    $('#ui_txt_enterNewPassword').on('keyup', function () {
        $('#confirmNewPassword').next("div.error").remove();
    });

    $('.changePasswordModal').on('hidden.bs.modal', function () {
        $('#ui_txt_currentPassword,#ui_txt_enterNewPassword,#ui_txt_confirmNewPassword').val('');
        $('.greenColor,.redColor').remove();
    })

    function SavePasswordDetails() {
        $('.greenColor,.redColor').remove();
        if (retVal && PasswordvalidationCheck) {
            $.ajax({
                async: true,
                type: "POST",
                url: "/Login/ChangePassword",
                data: { urlString: "", password: $('#ui_txt_confirmNewPassword').val(), oldPassword: $('#ui_txt_currentPassword').val() },
                success: function (results) {
                    if (results.msgType === "Success") {
                        $('#ui_txt_currentPassword').val('');
                        $('#ui_txt_enterNewPassword').val('');
                        $('#ui_txt_confirmNewPassword').val('');
                        $('#confirmNewPassword').after('<div class="greenColor font_12">Password has changed successfully</div>');
                        setTimeout(function () {
                            $('.changePasswordModal').modal('hide');
                        }, 3000)
                    }
                    else
                        $('#confirmNewPassword').after('<div class="redColor font_12">' + results.data + '</div>');
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        }
        else {
            $('#confirmNewPassword').after('<div class="redColor font_12">The provided password does not meet system requirements.</div>');
        }
    }

    $(document).on('click', '#toggleCurrentPassword', function () {
        $(this).toggleClass("fa-eye fa-eye-slash");
        var input = $('#ui_txt_currentPassword');
        input.attr('type') === 'password' ? input.attr('type', 'text') : input.attr('type', 'password');
    });

    $(document).on('click', '#toggleNewPassword', function () {
        $(this).toggleClass("fa-eye fa-eye-slash");
        var input = $('#ui_txt_enterNewPassword');
        input.attr('type') === 'password' ? input.attr('type', 'text') : input.attr('type', 'password');
    });

    $(document).on('click', '#toggleConfirmPassword', function () {
        $(this).toggleClass("fa-eye fa-eye-slash");
        var input = $('#ui_txt_confirmNewPassword');
        input.attr('type') === 'password' ? input.attr('type', 'text') : input.attr('type', 'password');
    });
});

var userId = 0;
var pwdLength;
var pwdIncUpperandLowerCase;
var pwdEnforceOneNumber;
var pwdSpecialChar;
var isCheckPasswordLength;
var EmailvalidationCheck = true;
var IsEmailUnique = true;
var UserNameValidationCheck = true;
var PasswordvalidationCheck = true;
var IsPasswordMatch = true;
var isIncUpperandLowerCase = false;
var isEnforceOneNumber = false;
var isSpecialChar = false;
var recievedUserName;

var RegisterConstants = {
    elementIDConstant: {
        ui_txt_password: "#ui_txt_passwordEdit",
        ui_txt_confirmPassword: "#ui_txt_passwordConfirm"
    }
};

$("#ui_txt_passwordEdit").on('click', function () {
    $(this).val('');
})
$('#ui_ddl_userStatusEdit').on("change", function () {
    $('#userStatusEdit').next("div.error").remove();
});
$('#ui_txt_primaryEmailAddressEdit').on("keyup", function () {
    $('#primaryEmailAddressEdit').next("div.error").remove();
});
$('#ui_txt_userNameEdit').on("keyup", function () {
    $('#userNameEdit').next("div.error").remove();
});
$('#ui_txt_passwordEdit').on("keyup", function () {
    $('#passwordEdit').next("div.error").remove();
});
$('#ui_ddl_salutationEdit').on("change", function () {
    $('#salutationEdit').next("div.error").remove();
});
$('#ui_txt_firstNameEdit').on("keyup", function () {
    $('#firstNameEdit').next("div.error").remove();
});
$('#ui_txt_lastNameEdit').on("keyup", function () {
    $('#lastNameEdit').next("div.error").remove();
});
$('#ui_multiselect_credentialsEdit').on("change", function () {
    $('#multiselectCredentialsEdit').next("div.error").remove();
});
$('#ui_txt_addressLine1Edit').on("keyup", function () {
    $('#addressLine1Edit').next("div.error").remove();
});
$("#ui_ddl_countryEdit").change(function () {
    $('#countryEdit').next("div.error").remove();
});
$("#ui_ddl_stateEdit").change(function () {
    $('#stateEdit').next("div.error").remove();
});
$("#ui_ddl_cityEdit").change(function () {
    $('#cityEdit').next("div.error").remove();
});
$('#ui_txt_zipEdit').on("keyup", function () {
    $('#zipEdit').next("div.error").remove();
});
$('#ui_txt_phoneEdit').on("keyup", function () {
    $('#phoneEdit').next("div.error").remove();
});

$('#btnCancelEdit').click(function () {
    $(".showFormOnUserNameClick").hide();
});

function ValidatePasswordEditFields() {
    $('.error').remove();
    retVal = true;
    if ($('#ui_txt_passwordEdit').val() === "" || $('#ui_txt_passwordEdit').val() === null) {
        $('#ui_txt_passwordEdit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please enter New Password.</div>');
        retVal = false;
    }

    if ($('#ui_txt_passwordConfirm').val() === "" || $('#ui_txt_passwordConfirm').val() === null) {
        $('#confirmNewPassword').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Please enter Confirm New Password.</div>');
        retVal = false;
    }
    if ($('#ui_txt_passwordConfirm').val() !== "" || $('#ui_txt_passwordConfirm').val() !== null) {
        if ($('#ui_txt_passwordEdit').val() !== $('#ui_txt_passwordConfirm').val()) {
            $('#ui_txt_passwordConfirm').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Passwords do not match.</div>');
            retVal = false;
        }
    }
}

function Show(e) {
    $(".showFormOnUserNameClick").show();
    var gridRowData = $("#Usergrid").data("kendoGrid");
    if (gridRowData) {
        var data = gridRowData.dataItem($(e).closest("tr"));
        userId = data.UserId;
        $.ajax({
            async: false,
            type: "POST",
            url: '/Register/GetUserDetailsByUserId',
            data: { "userId": data.UserId },
            success: function (result) {
                if (result !== null) {
                    $("#ui_ddl_userTypeEdit").data('kendoDropDownList').value(result.Data[0].UserType);
                    $('#ui_ddl_departmentEdit').data('kendoDropDownList').value(result.Data[0].Department);
                    $('#ui_ddl_userStatusEdit').data('kendoDropDownList').value($.trim(result.Data[0].UserStatus));
                    $('#ui_txt_primaryEmailAddressEdit').val(result.Data[0].PrimaryEmailId);
                    $('#ui_txt_userNameEdit').val(result.Data[0].UserName);
                    $('#ui_txt_passwordEdit').val(result.Data[0].Password);
                    $('#ui_txt_passwordConfirm').val(result.Data[0].Password);
                    $('#ui_ddl_salutationEdit').data('kendoDropDownList').value(result.Data[0].Salutation);
                    $('#ui_txt_firstNameEdit').val(result.Data[0].FirstName);
                    $('#ui_txt_lastNameEdit').val(result.Data[0].LastName);
                    $('#ui_ddl_suffixEdit').data('kendoDropDownList').value($.trim(result.Data[0].Suffix));
                    $('#ui_txt_titleEdit').val(result.Data[0].Title);
                    $('#ui_txt_addressLine1Edit').val(result.Data[0].Address1);
                    $('#ui_txt_addressLine2Edit').val(result.Data[0].Address2);
                    $('#ui_ddl_countryEdit').data('kendoDropDownList').value(result.Data[0].CountryId);
                    $('#ui_ddl_stateEdit').data('kendoDropDownList').value(result.Data[0].StateId);
                    $('#ui_ddl_cityEdit').data('kendoDropDownList').value(result.Data[0].CityId);
                    $('#ui_txt_zipEdit').val(result.Data[0].Zip);
                    $('#ui_txt_phoneEdit').val(result.Data[0].MobileNumber);
                    $('#ui_txt_faxEdit').val(result.Data[0].Fax);
                    recievedUserName = result.Data[0].UserName;
                }
            }
        });

        $.ajax({
            async: false,
            type: "POST",
            url: '/Register/GetUserCredentialsByUserId',
            data: { "userId": data.UserId },
            success: function (result) {
                if (result !== null) {
                    var credential = [];
                    $.each(result.Data, function (index, item) {
                        credential.push(result.Data[index].CredentialId);
                    });
                    $("#ui_multiselect_credentialsEdit").getKendoMultiSelect().value(credential);
                }
            }
        });
        //$.ajax({
        //    async: true,
        //    type: "POST",
        //    url: "/Login/GetPwdPolicydetails",
        //    success: function (results) {
        //        $.each(results, function (index, item) {
        //            if (item.GlobalKey.toUpperCase() === "EnforcePasswordLength".toUpperCase() && parseInt(item.GlobalValue) > 0) {
        //                isCheckPasswordLength = true;
        //                pwdLength = item.GlobalValue;
        //            }
        //            if (item.GlobalKey.toUpperCase() === "EnforceOneUpperandOneLowerCaseCharacter".toUpperCase() && item.GlobalValue === "True") {
        //                isIncUpperandLowerCase = true;
        //                pwdIncUpperandLowerCase = true;
        //            }
        //            if (item.GlobalKey.toUpperCase() === "EnforceOneNumber".toUpperCase() && item.GlobalValue === "True") {
        //                isEnforceOneNumber = true;
        //                pwdEnforceOneNumber = true;
        //            }
        //            if (item.GlobalKey.toUpperCase() === "EnforceSpecialChar".toUpperCase() && item.GlobalValue === "True") {
        //                isSpecialChar = true;
        //                pwdSpecialChar = true;
        //            }
        //        });
      //        //if (parseInt(pwdLength) > 0) {
        //        //    $("#passwordLength").append("At least " + pwdLength + " characters in length");
        //        //}
        //        //if (pwdIncUpperandLowerCase === true) {
        //        //    $("#upperLowerCase").append("At least one upper and lower case character");
        //        //}
        //        //if (pwdEnforceOneNumber === true) {
        //        //    $("#number").append("At least one numeric character");
        //        //}
        //        //if (pwdSpecialChar === true) {
        //        //    $("#specialCharacter").append("At least one special character");
        //        //}
        //    },
        //    error: function (XMLHttpRequest, textStatus, errorThrown) {
        //    }
        //});
    }
}

$('#btnUpdate').click(function () {
    ValidateMandatoryFields();
    ValidatePasswordEditFields();
    UpdateNewUserDetails(userId);
});

function ValidateMandatoryFields() {
    retVal = true;
    $('.error').remove();

    if ($('#ui_ddl_userStatusEdit').val() === "Select" || $('#ui_ddl_userStatusEdit').val() === "") {
        $('#userStatusEdit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>User Status is required</div>');
        retVal = false;
    }
    if ($('#ui_txt_primaryEmailAddressEdit').val().length <= 0) {
        $('#primaryEmailAddressEdit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Primary Email Address is required</div>');
        retVal = false;
    }
    if ($('#ui_txt_userNameEdit').val().length <= 0) {
        $('#userNameEdit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>User Name is required</div>');
        retVal = false;
    }
    if ($('#ui_txt_passwordEdit').val().length <= 0) {
        $('#passwordEdit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Password is required</div>');
        retVal = false;
    }
    if (($('#ui_ddl_salutationEdit').val() === "Select") || ($('#ui_ddl_salutationEdit').val() === "")) {
        $('#salutationEdit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Salutation is required</div>');
        retVal = false;
    }
    if ($('#ui_txt_firstNameEdit').val().length <= 0) {
        $('#firstNameEdit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>First Name is required</div>');
        retVal = false;
    }
    if ($('#ui_txt_lastNameEdit').val().length <= 0) {
        $('#lastNameEdit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Last Name is required</div>');
        retVal = false;
    }
    if ($("#ui_multiselect_credentialsEdit").data("kendoMultiSelect").value().length <= 0) {
        $('#multiselectCredentialsEdit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Credentials is required</div>');
        retVal = false;
    }
    if ($('#ui_txt_addressLine1Edit').val().length <= 0) {
        $('#addressLine1Edit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Address Line 1 is required</div>');
        retVal = false;
    }
    if ($('#ui_ddl_countryEdit').val() === 'Select' || $('#ui_ddl_countryEdit').val() === "") {
        $('#countryEdit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Country is required</div>');
        retVal = false;
    }
    if ($('#ui_ddl_countryEdit').val() !== 'Select' || $('#ui_ddl_countryEdit').val() !== "") {
        if ($('#ui_ddl_stateEdit').val() === 'Select' || $('#ui_ddl_stateEdit').val() === "") {
            $('#stateEdit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>State/Region is required</div>');
            retVal = false;
        }
    }
    if ($('#ui_ddl_stateEdit').val() !== 'Select' || $('#ui_ddl_stateEdit').val() !== "") {
        if ($('#ui_ddl_cityEdit').val() === 'Select' || $('#ui_ddl_cityEdit').val() === "") {
            $('#cityEdit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>City is required</div>');
            retVal = false;
        }
    }
    if ($('#ui_txt_zipEdit').val().length <= 0) {
        $('#zipEdit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Zip/Postal Code is required</div>');
        retVal = false;
    }
    if ($('#ui_txt_phoneEdit').val().length <= 0) {
        $('#phoneEdit').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>Phone is required</div>');
        retVal = false;
    }
}


function UpdateNewUserDetails(userID) {
    if (retVal === true) {
        var credetials = $("#ui_multiselect_credentialsEdit").val();
        objUsers = new Object();
        objUsers.UserId = userID;
        objUsers.UserType = $("#ui_ddl_userTypeEdit").val();
        objUsers.Department = $("#ui_ddl_departmentEdit").val();
        objUsers.UserStatus = $("#ui_ddl_userStatusEdit").val();
        objUsers.Suffix = $("#ui_ddl_suffixEdit").val();
        objUsers.PrimaryEmailId = $("#ui_txt_primaryEmailAddressEdit").val();
        objUsers.UserName = $("#ui_txt_userNameEdit").val();
        objUsers.Password = $(RegisterConstants.elementIDConstant.ui_txt_password).val();
        objUsers.Salutation = $("#ui_ddl_salutationEdit").val();
        objUsers.FirstName = $("#ui_txt_firstNameEdit").val();
        objUsers.LastName = $("#ui_txt_lastNameEdit").val();
        objUsers.Title = $("#ui_txt_titleEdit").val();
        objUsers.Address1 = $("#ui_txt_addressLine1Edit").val();
        objUsers.Address2 = $("#ui_txt_addressLine2Edit").val();
        objUsers.CountryId = $("#ui_ddl_countryEdit").val();
        objUsers.StateId = $("#ui_ddl_stateEdit").val();
        objUsers.CityId = $("#ui_ddl_cityEdit").val();
        objUsers.Zip = $("#ui_txt_zipEdit").val();
        objUsers.MobileNumber = $("#ui_txt_phoneEdit").val();
        objUsers.Fax = $("#ui_txt_faxEdit").val();
        objUsers.IsActive = true;
        objUsers.IsDeleted = false;
        objUsers.IsAccountLocked = false;
        $.ajax({
            async: false,
            type: "POST",
            url: "../Register/UpdateUserDetails",
            data: { "objUsers": objUsers, "credetials": credetials },
            success: function (results) {
                if (results.msgType === "Success") {
                    popupNotification.show(results.data, "info");
                    $(".showFormOnUserNameClick").hide();
                    $("#Usergrid").data("kendoGrid").dataSource.read();
                    $("#Usergrid").data("kendoGrid").refresh();
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
    else {

        popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
    }
}