//kendo pop up notification
var popupNotification = $("#popupNotification").kendoNotification({
    position: {
        pinned: true,
        top: 30,
        right: 30
    },
    autoHideAfter: 4000,
    stacking: "down",
}).data("kendoNotification");

//maxlength validation
$("textarea[maxlength]").keyup(function () {
    var charLength = $(this).val().length;
    var charLimit = $(this).attr("maxlength");
    $(this).nextAll("span.count").html(charLimit - charLength + " Characters left to enter");
});

//email validation
function IsEmail(email) {
    var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!regex.test(email)) {
        return false;
    } else {
        return true;
    }
}

function noOfCharactersLeft(data, id) {
    if (data !== null) {
        var charlimit = $("#" + id).attr('maxlength');
        var charlength = $('#' + id).val().length;
        $("#" + id + "_span").html(charlimit - charlength + " Characters left to enter");
    }
}

$(document).ready(function () {
    $(".floatNumberField").change(function () {
        $(this).val(parseFloat($(this).val()).toFixed(2));
    });
});

function InputBoxTextdetails(response, section, label, image, sessionstorageid, textid, charsleft, regexval, validationmsg, mode) {
        if (response[i].IsViewable == '' || response[i].IsViewable == null)
            $('#' + section).hide();
        else {
            if (response[i].RestrictViewUser != null) {
                var restrictViewUserArray = response[i].RestrictViewUser.split(',');
                for (var j = 0; j < restrictViewUserArray.length; j++) {
                    if (restrictViewUserArray[j] == $('#UserType').val()) {
                        $('#' + section).hide();
                        return false;
                    }
                }
            }

            if (response[i].RestrictCreateUser != null) {
                var restrictCreateUserArray = response[i].RestrictCreateUser.split(',');
                for (var j = 0; j < restrictCreateUserArray.length; j++) {
                    if (restrictCreateUserArray[j] == $('#UserType').val())
                        if (mode == "Create") {
                            $('#' + section).hide();
                            return false;
                        }
                }
            }

            $('#' + section).show();
            if (response[i].DisplayOrder != null)
                document.getElementById(section).style.order = response[i].DisplayOrder;
            $('#' + label).html(response[i].Name);
            if (image != "")
                if (response[i].HelpText == '' || response[i].HelpText == null)
                    $('#' + image).hide();
                else
                    $('#' + image).show().attr('title', response[i].HelpText);
            if (response[i].Size == 'Small')
                $('#' + textid).show().attr('maxlength', response[i].ColumnWidth);
            else
                $('#' + textid).hide();

            if (response[i].RestrictEditUser != null) {
                    var restrictEditUserArray = response[i].RestrictEditUser.split(',');
                    for (var j = 0; j < restrictEditUserArray.length; j++)
                        if (restrictEditUserArray[j] == $('#UserType').val())
                            $('#' + section).css({ pointerEvents: 'none' });
            }
            else {
                if (response[i].IsMandatory == '' || response[i].IsMandatory == null) {
                    $('#' + label).removeClass("mandatory");
                    sessionStorage.setItem(sessionstorageid, false);
                } else {
                    $('#' + label).addClass("mandatory");
                    sessionStorage.setItem(sessionstorageid, true);
                }
                $('#' + regexval).val(response[i].RegexExpression);
                $('#' + validationmsg).val(response[i].ValidationMessage);
            }

            if (response[i].RestrictDeleteUser != null) {
                var restrictDeleteUserArray = response[i].RestrictDeleteUser.split(',');
                for (var j = 0; j < restrictDeleteUserArray.length; j++)
                    if (restrictDeleteUserArray[j] == $('#UserType').val())
                        if (mode == "Edit")
                            $('#' + section).css({ pointerEvents: 'none' });
            }

            $('#' + charsleft).html(response[i].ColumnWidth + characterslefttoenter);
        }
}
           
function Textdetails(response, section, label, image, sessionstorageid, textid, textareaid, charsleft, regexval, validationmsg,mode)
{
    if (response[i].IsViewable == '' || response[i].IsViewable == null)
        $('#'+section).hide();
    else {      
        if (response[i].RestrictViewUser != null) {
            var restrictViewUserArray = response[i].RestrictViewUser.split(',');
            for (var j = 0; j < restrictViewUserArray.length; j++) {
                if (restrictViewUserArray[j] == $('#UserType').val()) {
                    $('#' + section).hide();
                    return false;
                }
            }
        }

        if (response[i].RestrictCreateUser != null) {
            var restrictCreateUserArray = response[i].RestrictCreateUser.split(',');
            for (var j = 0; j < restrictCreateUserArray.length; j++) {
                if (restrictCreateUserArray[j] == $('#UserType').val())
                    if (mode == "Create") {
                        $('#' + section).hide();
                        return false;
                    }                 
            }
        }
            
        $('#' + section).show();
        if (response[i].DisplayOrder != null)
            document.getElementById(section).style.order = response[i].DisplayOrder;
        $('#' + label).html(response[i].Name);
        if (image != "")
            if (response[i].HelpText == '' || response[i].HelpText == null)
                $('#' + image).hide();
            else
                $('#' + image).show().attr('title', response[i].HelpText);
        if (response[i].Size == 'Small') {
            $('#' + textid).show().attr('maxlength', response[i].ColumnWidth);
            $('#' + textareaid).hide();
        } else {
            $('#' + textid).hide();
            $('#' + textareaid).show().attr('maxlength', response[i].ColumnWidth);
        }
            
        if (response[i].RestrictEditUser != null) {
            var restrictEditUserArray = response[i].RestrictEditUser.split(',');
            for (var j = 0; j < restrictEditUserArray.length; j++) 
                if (restrictEditUserArray[j] == $('#UserType').val()) 
                    $('#' + section).css({ pointerEvents: 'none' });
        }
        else {
            if (response[i].IsMandatory == '' || response[i].IsMandatory == null) {
                $('#' + label).removeClass("mandatory");
                sessionStorage.setItem(sessionstorageid, false);
            } else {
                $('#' + label).addClass("mandatory");
                sessionStorage.setItem(sessionstorageid, true);
            }
            $('#' + regexval).val(response[i].RegexExpression);
            $('#' + validationmsg).val(response[i].ValidationMessage);
        }

        if (response[i].RestrictDeleteUser != null) {
            var restrictDeleteUserArray = response[i].RestrictDeleteUser.split(',');
            for (var j = 0; j < restrictDeleteUserArray.length; j++)
                if (restrictDeleteUserArray[j] == $('#UserType').val())
                    if (mode == "Edit")
                        $('#' + section).css({ pointerEvents: 'none' });
        }

        $('#' + charsleft).html(response[i].ColumnWidth + characterslefttoenter);
    }
}

function NumberFielddetails(response, section, label, image, sessionstorageid, textid, mode)
{
    if (response[i].IsViewable == '' || response[i].IsViewable == null)
        $('#'+section).hide();
    else {
        if (response[i].RestrictViewUser != null) {
            var restrictViewUserArray = response[i].RestrictViewUser.split(',');
            for (var j = 0; j < restrictViewUserArray.length; j++) {
                if (restrictViewUserArray[j] == $('#UserType').val()) {
                    $('#' + section).hide();
                    return false;
                }
            }
        }

        if (response[i].RestrictCreateUser != null) {
            var restrictCreateUserArray = response[i].RestrictCreateUser.split(',');
            for (var j = 0; j < restrictCreateUserArray.length; j++) {
                if (restrictCreateUserArray[j] == $('#UserType').val())
                    if (mode == "Create") {
                        $('#' + section).hide();
                        return false;
                    }
            }
        }              
        $('#' + section).show();
        if(response[i].DisplayOrder != null && document.getElementById(section) != null)
            document.getElementById(section).style.order = response[i].DisplayOrder;
        $('#' + label).html(response[i].Name);
        if (image != "")
            if (response[i].HelpText == '' || response[i].HelpText == null)
                $('#' + image).hide();
            else
                $('#' + image).show().attr('title', response[i].HelpText);
        if (response[i].Size == 'Small')
            $('#' + textid).show().attr('maxlength', response[i].ColumnWidth);
            else
            $('#' + textid).hide();
        if (response[i].RestrictEditUser != null) {
            var restrictEditUserArray = response[i].RestrictEditUser.split(',');
            for (var j = 0; j < restrictEditUserArray.length; j++)
                if (restrictEditUserArray[j] == $('#UserType').val())
                    $('#' + section).css({ pointerEvents: 'none' });
        }
        else
        {
            if (response[i].IsMandatory == '' || response[i].IsMandatory == null) {
                $('#' + label).removeClass("mandatory");
                sessionStorage.setItem(sessionstorageid, false);
            } else {
                $('#' + label).addClass("mandatory");
                sessionStorage.setItem(sessionstorageid, true);
            }
        }

        if (response[i].RestrictDeleteUser != null) {
            var restrictDeleteUserArray = response[i].RestrictDeleteUser.split(',');
            for (var j = 0; j < restrictDeleteUserArray.length; j++)
                if (restrictDeleteUserArray[j] == $('#UserType').val())
                    if (mode == "Edit")
                        $('#' + section).css({ pointerEvents: 'none' });
        }
    }       
}

function DropDowndetails(response, section, label, image, sessionstorageid, mode)
{        
    if (response[i].IsViewable == '' || response[i].IsViewable == null)
        $('#'+section).hide();
    else {
        if (response[i].RestrictViewUser != null) {
            var restrictViewUserArray = response[i].RestrictViewUser.split(',');
            for (var j = 0; j < restrictViewUserArray.length; j++) {
                if (restrictViewUserArray[j] == $('#UserType').val()) {
                    $('#' + section).hide();
                    return false;
                }
            }
        }

        if (response[i].RestrictCreateUser != null) {
            var restrictCreateUserArray = response[i].RestrictCreateUser.split(',');
            for (var j = 0; j < restrictCreateUserArray.length; j++) {
                if (restrictCreateUserArray[j] == $('#UserType').val())
                    if (mode == "Create") {
                        $('#' + section).hide();
                        return false;
                    }
            }
        }

        $('#' + section).show();
        if(response[i].DisplayOrder != null && document.getElementById(section) != null)
            document.getElementById(section).style.order = response[i].DisplayOrder;
        $('#' + label).html(response[i].Name);
        if (image != "")
            if (response[i].HelpText == '' || response[i].HelpText == null)            
                    $('#' + image).hide();
            else
                $('#' + image).show().attr('title', response[i].HelpText);

        if (response[i].RestrictEditUser != null) {
            var restrictEditUserArray = response[i].RestrictEditUser.split(',');
            for (var j = 0; j < restrictEditUserArray.length; j++)
                if (restrictEditUserArray[j] == $('#UserType').val())
                    $('#' + section).css({ pointerEvents: 'none' });
        }
        else
        {
            if (response[i].IsMandatory == '' || response[i].IsMandatory == null) {
                $('#' + label).removeClass("mandatory");
                sessionStorage.setItem(sessionstorageid, false);
            } else {
                $('#' + label).addClass("mandatory");
                sessionStorage.setItem(sessionstorageid, true);
            }
        }

        if (response[i].RestrictDeleteUser != null) {
            var restrictDeleteUserArray = response[i].RestrictDeleteUser.split(',');
            for (var j = 0; j < restrictDeleteUserArray.length; j++)
                if (restrictDeleteUserArray[j] == $('#UserType').val())
                    if (mode == "Edit")
                        $('#' + section).css({ pointerEvents: 'none' });
        }
    }
}

function Label(response, section, label, image, sessionstorageid,mode)
{
    if (response[i].IsViewable == '' || response[i].IsViewable == null)
        $('#'+section).hide();
    else {
        if (response[i].RestrictViewUser != null) {
            var restrictViewUserArray = response[i].RestrictViewUser.split(',');
            for (var j = 0; j < restrictViewUserArray.length; j++) {
                if (restrictViewUserArray[j] == $('#UserType').val()) {
                    $('#' + section).hide();
                    return false;
                }
            }
        }

        if (response[i].RestrictCreateUser != null) {
            var restrictCreateUserArray = response[i].RestrictCreateUser.split(',');
            for (var j = 0; j < restrictCreateUserArray.length; j++) {
                if (restrictCreateUserArray[j] == $('#UserType').val())
                    if (mode == "Create") {
                        $('#' + section).hide();
                        return false;
                    }
            }
        }
          
        $('#' + section).show();
        if(response[i].DisplayOrder != null)
            document.getElementById(section).style.order = response[i].DisplayOrder;
        $('#' + label).html(response[i].Name);
        if (image != "")
            if (response[i].HelpText == '' || response[i].HelpText == null)
                $('#' + image).hide();
            else
                $('#' + image).show().attr('title', response[i].HelpText);     
        
        if (response[i].RestrictEditUser != null) {
            var restrictEditUserArray = response[i].RestrictEditUser.split(',');
            for (var j = 0; j < restrictEditUserArray.length; j++)
                if (restrictEditUserArray[j] == $('#UserType').val())
                    $('#' + section).css({ pointerEvents: 'none' });
        }
        else
        {
            if (response[i].IsMandatory == '' || response[i].IsMandatory == null) {
                $('#' + label).removeClass("mandatory");
                sessionStorage.setItem(sessionstorageid, false);
            } else {
                $('#' + label).addClass("mandatory");
                sessionStorage.setItem(sessionstorageid, true);
            }                        
        }                    
        if (response[i].RestrictDeleteUser != null) {
            var restrictDeleteUserArray = response[i].RestrictDeleteUser.split(',');
            for (var j = 0; j < restrictDeleteUserArray.length; j++)
                if (restrictDeleteUserArray[j] == $('#UserType').val())
                    if (mode == "Edit")
                        $('#' + section).css({ pointerEvents: 'none' });
        }
    }   
}

function CheckBoxdetails(response, section, label, image, sessionstorageid,mode)
{        
    if (response[i].IsViewable == '' || response[i].IsViewable == null)
        $('#'+section).hide();
    else {
        if (response[i].RestrictViewUser != null) {
            var restrictViewUserArray = response[i].RestrictViewUser.split(',');
            for (var j = 0; j < restrictViewUserArray.length; j++) {
                if (restrictViewUserArray[j] == $('#UserType').val()) {
                    $('#' + section).hide();
                    return false;
                }
            }
        }

        if (response[i].RestrictCreateUser != null) {
            var restrictCreateUserArray = response[i].RestrictCreateUser.split(',');
            for (var j = 0; j < restrictCreateUserArray.length; j++) {
                if (restrictCreateUserArray[j] == $('#UserType').val())
                    if (mode == "Create") {
                        $('#' + section).hide();
                        return false;
                    }
            }
        }
         
        $('#' + section).show();
        if(response[i].DisplayOrder != null)
            document.getElementById(section).style.order = response[i].DisplayOrder;
        $('#' + label).html(response[i].Name);
        if (image != "")
            if (response[i].HelpText == '' || response[i].HelpText == null)
                $('#' + image).hide();
            else
                $('#' + image).show().attr('title', response[i].HelpText);

        if (response[i].RestrictEditUser != null) {
            var restrictEditUserArray = response[i].RestrictEditUser.split(',');
            for (var j = 0; j < restrictEditUserArray.length; j++)
                if (restrictEditUserArray[j] == $('#UserType').val())
                    $('#' + section).css({ pointerEvents: 'none' });
        }
        else
        {
            if (response[i].IsMandatory == '' || response[i].IsMandatory == null) {
                $('#' + label).removeClass("mandatory");
                sessionStorage.setItem(sessionstorageid, false);
            } else {
                $('#' + label).addClass("mandatory");
                sessionStorage.setItem(sessionstorageid, true);
            }
        }

        if (response[i].RestrictDeleteUser != null) {
            var restrictDeleteUserArray = response[i].RestrictDeleteUser.split(',');
            for (var j = 0; j < restrictDeleteUserArray.length; j++)
                if (restrictDeleteUserArray[j] == $('#UserType').val())
                    if (mode == "Edit")
                        $('#' + section).css({ pointerEvents: 'none' });
        }
    }
}
