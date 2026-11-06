$(document).ready(function () {
    $("#termsAndConditions").click(function (e) {
        $.ajax({
            async: false,
            type: "GET",
            url: "/Administration/GetGlobalSettingByKey",
            data: { "globalKey": usageTermsUrl },
            success: function (results) {
                if (results.Data.length > 0) {
                    var termsConditions = results.Data[0].GlobalValue;
                     if (!termsConditions.match(/^[a-zA-Z]+:\/\//)) {
                        termsConditions = 'http://' + termsConditions;
                    }
                    $('#termsAndConditions').attr("href", termsConditions);
                }
            }
        });
    });

    $("#privacyPolicy").click(function (e) {
        $.ajax({
            async: false,
            type: "GET",
            url: "/Administration/GetGlobalSettingByKey",
            data: { "globalKey": privacyPolicyUrl },
            success: function (results) {
                if (results. Data.length > 0) {
                    var privacyPolicyLink = results.Data[0].GlobalValue;
                    if (!privacyPolicyLink.match(/^[a-zA-Z]+:\/\//)) {
                        privacyPolicyLink = 'http://' + privacyPolicyLink;
                    }
                    $('#privacyPolicy').attr("href", privacyPolicyLink);
                }
            }
        });
    });
    $.ajax({
        type: "GET",
        url: "/Dashboard/GetBannerList",
        data: {},
        success: function (results) {
            if (results.Status !== "Failed") {
                if (results.Data.length > 0) {
                    $('#bannerImage').attr('src', "/BannerUpload/" + results.Data[0].DocumentName);
                }
                else $('#bannerImage').attr('src', "/Images/AnjuHeader.jpg");
            }
            else $('#bannerImage').attr('src', "/Images/AnjuHeader.jpg");
        }
    });

    var emailAddress;
    $('#helpLink').click(function () {
        $.ajax({
            type: "GET",
            url: "/Common/GetHelpEmailAddress",
            data: {},
            success: function (results) {
                emailAddress = results;
                $('#helpEmail').attr("href", emailAddress);
                $('#helpEmail').text(emailAddress);
            }
        });
    });

});