$(document).ready(function () {

    var strfilter = "";
    function addRow() {
        var totalRowCount = $("#attributetable tr").length;
        if (totalRowCount >= 32) {
            popupNotification.show("Sorry, At the maximum only 8 attributes could be added");
            $('#addAttribute').attr("disabled", true);
        }
        var count = totalRowCount / 4 + 1;
        var attributeId = "attribute" + count;
        var attributeValue = "attributevalue" + count;
        var html = '<tr>' +
            '<td><span class="ui_label pl-md-2">Attribute</span></td>' +

            '</tr>' +
            '<tr>' +
            '<td><input id=' + attributeId + ' class = "wid_100"  /></td>' +

            '</tr>' +
            '<tr>' +
            '<td><span class="ui_label pl-md-2">Value</span></td>' +

            '</tr>' +
            '<tr>' +
            '<td><input type="text" class="form-control wid_99" id=' + attributeValue + '></td>' +

            '</tr>'


        $(html).appendTo($("#attributetable"));

        $("#attribute" + count).kendoDropDownList({
            autoBind: false,
            optionLabel: "Select",
            dataTextField: "Name",
            dataValueField: "Name",
            dataSource: {
                transport: {
                    read: {
                        dataType: "json",
                        url: "/Search/GetAttribute",
                    }
                }
            }
        });

    };

    $("#addAttribute").click(addRow);
    $("#colToolbar").hide();
    $("#advancedserch").click(searchResult);
    $("#attributeshow").click(showAttribute);
    $("#searching").hide();
    $("#quickdserch").click(quickSearchResult);

    $('#resetQuickSearchButton,#resetSearchBuilderButton').on('click', function () {
        $('#ui_frmQuickSearch')[0].reset();
        $('#ui_frmAdvanceSearch')[0].reset();
        $(".searchData").empty();
        $("#noResult").show();
        $("#colToolbar").hide();
    })
    function searchResult() {
        var strresult = "";
        $("#searching").show();
        $("#searchResults").hide();
        $("#searchlist").empty();
        $(".searchData").empty();
        var resultcount = 0;        
        var lsAttributesearch = new Array();
        var searchTable = document.getElementById('attributetable');
        var numberofAttribute = searchTable.rows.length / 4;//Number of attribute 
        var matchcriteria = $("input[name='trialType']:checked").val();
        for (i = 1; i <= numberofAttribute; i++) {

            var AttributeSearch = {};
            var AttributeName = $("#attribute" + i).val();
            AttributeSearch.AttributeName = AttributeName;
            var AttributeValue = $("#attributevalue" + i).val();
            if (AttributeValue !== "" && AttributeName !== "") {
                AttributeSearch.AttributeValue = AttributeValue;
                lsAttributesearch.push(AttributeSearch);
            }

        }
        $.ajax({
            async: false,
            type: "POST",
            url: "/Search/GetsearchResult/",
            cache: false,
            data: { "lsAttributeSearch": lsAttributesearch, "matchCriteria": matchcriteria },
            dataType: "json",
            success: function (result) {
                $("#searching").hide();
                $("#searchResults").show();               
                if (result !== null) {
                    $.each(result.Data, function (index, item) {
                        resultcount += 1;
                        strresult += '<div class="resultmatched col-md-12 ui_label">';
                        strresult += '<div><a href="#" onclick="EditStudy(' + result.Data[index].StudyID +')">' + 'StudyID ' + result.Data[index].StudyID + '</a></div>';
                        strresult += '<div class="matchedid"><b>Matches:</b> ' + result.Data[index].Description + '</div></div>';
                    });
                    $("#searchlist").append(strresult);
                    if (resultcount > 0) {
                        getAttributeList();
                        $("#noResult").hide();
                        $("#colToolbar").show();
                    }

                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                popupNotification.show('Error', "error");
            }
        });


    };

    function quickSearchResult() {
        var searchelement = $("#searchText").val();
        var resultcount = 0;
        var strresult = "";
        var attributename = "";
        if (searchelement.length < 3)
            popupNotification.show("Please add minimum three characters","error");
        else {
            strfilter = '<ul id="searchAttribute" class="searchData ui_label">';
            $.ajax({
                async: false,
                type: "POST",
                url: "/Search/GetQuickSearchResult/",
                cache: false,
                data: { "matchCriteria": searchelement },
                dataType: "json",
                success: function (result) {
                    $("#searchlist").empty();
                    if (result !== null) {
                        $.each(result.Data, function (index, item) {
                            resultcount += 1;
                            strresult += '<div class="resultmatched col-md-12 ui_label">';
                            strresult += '<div><a href="#" onclick="EditStudy(' + result.Data[index].StudyID + ')">' + 'StudyID ' + result.Data[index].StudyID + '</a></div>';
                            strresult += '<div class="matchedid"><b>Matches:</b> ' + result.Data[index].Description + '</div></div>';
                            attributename = result.Data[index].AttributeName;

                        });
                        var resultsearch = attributename.split(",")
                        resultsearch.forEach(searchAttribute);

                        strfilter += '<li><a href="#">' + 'Clear Search' + '</a></li>';
                        strfilter += '</ul>';
                        document.getElementById("attributelist").innerHTML = strfilter;
                        $("#searchlist").append(strresult);
                        if (resultcount > 0) {
                            $("#noResult").hide();
                            $("#colToolbar").show();
                        }

                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    popupNotification.show('Error', "error");
                }
            });
        }
    };

    $(document).on('click', 'ul li a', function (e) {
        var filtertext = $(this).text().toLowerCase();
        if (filtertext === "clear search") {
            $('#searchlist > div').map(function () {
                $(this).show();
            });

        }
        else {
            $('#searchlist > div').map(function () {
                var text = $(this).find('.matchedid').text().toLowerCase();
                if (text.indexOf(filtertext) >= 0) { $(this).show(); }
                else { $(this).hide(); }
            });
        }
    });

    function getAttributeList() {
        var searchTable = document.getElementById('attributetable');
        var numberofAttribute = searchTable.rows.length / 4;//Number of attribute  
        var strattribute = '<ul id="searchAttribute" class="searchData ui_label">';
        for (i = 1; i <= numberofAttribute; i++) {
            var AttributeName = $("#attribute" + i).val();
            strattribute += '<li><a href="#">' + AttributeName + '</a></li>';
        }
        strattribute += '<li><a href="#">' + 'Clear Search' + '</a></li>';
        strattribute += '</ul>';
        document.getElementById("attributelist").innerHTML = strattribute;
    };

    function searchAttribute(item, index) {
        strfilter += '<li><a href="#">' + item + '</a></li>';
    }

    function showAttribute() {
        $("#attributelist").fadeToggle();
    }
});

function EditStudy(id) {
    var w = 1020;
    var h = 600;
    var left = Number((screen.width / 2) - (w / 2));
    var top = Number((screen.height / 2) - (h / 2));
    
    obj = new Object();
    obj.StudyId = id;    
    obj.mode = "Update"
    $.ajax({
        async: true,
        type: "POST",
        url: "/Login/OpenNewWindow",
        data: { "obj": obj },
        success: function (results) {
            if (results.data === "Success") {
                window.open('../NewStudy/EditStudy', 'MsgWindow', 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + '');
            }
            else {
                alert("Error");
            }
        }
    });
}