function OnUserRolessaveChanges(e) {
    var grid = null;
    switch (e.type) {
        case "create":
            grid = $("#UserRolesgridId").data("kendoGrid");
            grid.dataSource.read();
            break;
        case "update":
            grid = $("#UserRolesgridId").data("kendoGrid");
            grid.dataSource.read();
            break;
        case "destroy":
            grid = $("#UserRolesgridId").data("kendoGrid");
            grid.dataSource.read();
            break;
    }
}

function OnSysCodesaveChanges(e) {
    var grid = null;
    switch (e.type) {
        case "create":
            grid = $("#SysCodegrid").data("kendoGrid");
            grid.dataSource.read();
            break;
        case "update":
            grid = $("#SysCodegrid").data("kendoGrid");
            grid.dataSource.read();
            onChange(e);
            break;
        case "destroy":
            grid = $("#SysCodegrid").data("kendoGrid");
            grid.dataSource.read();
            break;
    }
}

function OnCountrysaveChanges(e) {
    var grid = null;
    switch (e.type) {
        case "create":
            grid = $("#Countrygrid").data("kendoGrid");
            grid.dataSource.read();
            break;
        case "update":
            grid = $("#Countrygrid").data("kendoGrid");
            grid.dataSource.read();
            break;
        case "destroy":
            grid = $("#Countrygrid").data("kendoGrid");
            grid.dataSource.read();
            break;
    }
}

function onChange(e) {
    var sortOrder = new Array();
    var grid = $("#SysCodegrid").data("kendoGrid"),
        skip = grid.dataSource.skip(),
        oldIndex = e.oldIndex + skip,
        newIndex = e.newIndex + skip,
        data = grid.dataSource.data(),
        dataItem = grid.dataSource.getByUid(e.item.data("uid"));
    for (var i = 0; i < data.length; i++) {
        sortOrder[i] = data[i].SortOrder;
    }
    grid.dataSource.remove(dataItem);
    grid.dataSource.insert(newIndex, dataItem);

    for (var i = 0; i < data.length; i++) {
        $.ajax({
            async: false,
            type: "POST",
            url: '/Administration/UpdateSysCodeSortOrder',
            data: { "sortOrder": sortOrder[i], "codeName": data[i].Code },
            success: function (result) {
                grid.refresh();
            }
        });
    }
}

function OnStatesaveChanges(e) {
    var grid = null;
    switch (e.type) {
        case "create":
            grid = $("#Stategrid").data("kendoGrid");
            grid.dataSource.read();
            break;
        case "update":
            grid = $("#Stategrid").data("kendoGrid");
            grid.dataSource.read();
            break;
        case "destroy":
            grid = $("#Stategrid").data("kendoGrid");
            grid.dataSource.read();
            break;
    }
}
function OnCitysaveChanges(e) {
    var grid = null;
    switch (e.type) {
        case "create":
            grid = $("#Citygrid").data("kendoGrid");
            grid.dataSource.read();
            break;
        case "update":
            grid = $("#Citygrid").data("kendoGrid");
            grid.dataSource.read();
            break;
        case "destroy":
            grid = $("#Citygrid").data("kendoGrid");
            grid.dataSource.read();
            break;
    }
}

function sysCodeColumnFilter(element) {
    var array2 = new Array();
    $.ajax({
        async: true,
        type: "POST",
        url: "/Administration/GetSysCodeColumnValues/",
        cache: false,
        dataType: "json",
        success: function (response) {

            for (var i = 0; i < response.Data.length; i++) {
                array2[i] = response.Data[i].ColumnName;
            }

            element.kendoDropDownList({
                dataSource: {
                    data: array2
                },
                optionLabel: "--Select Value--"
            });
        },
        failure: function (response) {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });
}

$("#clickDescription").click(function (e) {
    sortSysCodesColumnName(e);
});

$("#clickCode").click(function (e) {
    sortSysCodesColumnName(e);
});

var sortFlag = false;
function sortSysCodesColumnName(e) {
    var grid = $("#SysCodegrid").data("kendoGrid");
    grid.dataSource.read();
    $('#SysCodegrid').data('kendoGrid').refresh();
    var result;

    $.ajax({
        async: false,
        type: "POST",
        url: "/Administration/GetSysCodeColumnValuesbyName/",
        cache: false,
        data: { "columnName": values },
        dataType: "json",
        success: function (response) {
            resultArray = response.Data;
            var tempData;
            if (sortFlag == false) {
                for (var m = 0; m < resultArray.length - 1; m++) {
                    for (var n = 0; n < resultArray.length - m - 1; n++) {
                        if (resultArray[n].Code > resultArray[n + 1].Code) {
                            tempData = resultArray[n].Code;
                            resultArray[n].Code = resultArray[n + 1].Code;
                            resultArray[n + 1].Code = tempData;
                        }
                    }
                }
                sortFlag = true;
            } else {
                for (var m = 0; m < resultArray.length - 1; m++) {
                    for (var n = 0; n < resultArray.length - m - 1; n++) {
                        if (resultArray[n].Code < resultArray[n + 1].Code) {
                            tempData = resultArray[n].Code;
                            resultArray[n].Code = resultArray[n + 1].Code;
                            resultArray[n + 1].Code = tempData;
                        }
                    }
                }
                sortFlag = false;
            }
            var datas = grid.dataSource.data();

            for (var i = 0; i < resultArray.length; i++) {
                $.ajax({
                    async: false,
                    type: "POST",
                    url: '/Administration/UpdateSysCodeSortOrder',
                    data: { "sortOrder": i + 1, "codeName": resultArray[i].Code },
                    success: function (result) {

                    }
                });
            }

        },
        failure: function (response) {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });


}
$('#div_userRoles').hide();
$('#div_sysCodeValues').hide();
$('#div_country').hide();
$('#div_State').hide();
$('#div_city').hide();

var treeview_userRoles = $("#treeview_userRoles").data("kendoTreeView");
var treeview_sysCodeValues;
var treeview_country = $("#treeview_country").data("kendoTreeView");
var treeview_state = $("#treeview_state").data("kendoTreeView");
var treeview_city = $("#treeview_city").data("kendoTreeView");
var values;

function tree_select_userRoles(e) {
    $('#div_userRoles').show();
    $('#div_sysCodeValues').hide();
    $('#div_country').hide();
    $('#div_State').hide();
    $('#div_city').hide();
    treeview_sysCodeValues.select($());
    treeview_country.select($());
    treeview_state.select($());
    treeview_city.select($());
}

function tree_select_sysCodeValues(e) {
    $('#SysCodegrid').data('kendoGrid').dataSource.sort({});
    $('#div_userRoles').hide();
    $('#div_sysCodeValues').show();
    $('#div_country').hide();
    $('#div_State').hide();
    $('#div_city').hide();
    treeview_userRoles.select($());
    treeview_country.select($());
    treeview_state.select($());
    treeview_city.select($());
    selectedNode = treeview_sysCodeValues.select();
    var gridOptions = $('#SysCodegrid').data('kendoGrid');
    if (treeview_sysCodeValues.text(e.node) != "Sys Code Values") {
        gridOptions.dataSource.filter([{
            field: 'ColumnName',
            operator: 'eq',
            value: treeview_sysCodeValues.text(e.node)
        }]);
        values = treeview_sysCodeValues.text(e.node);
        gridOptions.hideColumn(1);
        gridOptions.hideColumn(2);
        gridOptions.hideColumn(6);

    } else {
        gridOptions.showColumn(1);
        gridOptions.showColumn(2);
        gridOptions.hideColumn(6);
        var filter = {};
        gridOptions.dataSource.filter(filter);

    }
    gridOptions.dataSource.read();
}

function tree_select_country(e) {
    $('#div_userRoles').hide();
    $('#div_sysCodeValues').hide();
    $('#div_country').show();
    $('#div_State').hide();
    $('#div_city').hide();
    treeview_userRoles.select($());
    treeview_sysCodeValues.select($());
    treeview_state.select($());
    treeview_city.select($());
}

function tree_select_state(e) {
    $('#div_userRoles').hide();
    $('#div_sysCodeValues').hide();
    $('#div_country').hide();
    $('#div_State').show();
    $('#div_city').hide();
    treeview_userRoles.select($());
    treeview_sysCodeValues.select($());
    treeview_country.select($());
    treeview_city.select($());
}

function tree_select_city(e) {
    $('#div_userRoles').hide();
    $('#div_sysCodeValues').hide();
    $('#div_country').hide();
    $('#div_State').hide();
    $('#div_city').show();
    treeview_userRoles.select($());
    treeview_sysCodeValues.select($());
    treeview_country.select($());
    treeview_state.select($());
}


var tableNames;
function filterDocumentMACSSubType() {
    $.ajax({
        async: true,
        type: "POST",
        url: "/Administration/GetSysCodeColumnValuesbyName/",
        cache: false,
        data: { "columnName": values },
        dataType: "json",
        success: function (response) {
            tableNames = response.Data[0].TableName;
        },
        failure: function (response) {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });

    return {
        value: values,
        tableName: tableNames
    };
}


$(document).ready(function () {

    treeview_sysCodeValues = $("#treeview_sysCodeValues").data("kendoTreeView");
    if (treeview_sysCodeValues != null) {
        $.ajax({
            async: true,
            type: "POST",
            url: "/Administration/GetSysCodeColumnValues/",
            cache: false,
            dataType: "json",
            success: function (response) {
                var added = [];
                for (var i = 0; i < response.Data.length; i++) {
                    added.push({ text: response.Data[i].ColumnName });
                }
                var parent = treeview_sysCodeValues.findByText("Sys Code Values")
                treeview_sysCodeValues.append(added, parent);
                treeview_sysCodeValues.collapse(".k-item");

            },
            failure: function (response) {
                popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
            }
        });
    }

    $(function () {
        $('#UserRolesgridId').on('click', '.chkbxInactive', function () {
            var checked = $(this).is(':checked');
            var grid = $('#UserRolesgridId').data().kendoGrid;
            var dataItem = grid.dataItem($(this).closest('tr'));
            dataItem.set('IsActive', checked);
        });
    });
});

function index(dataItem) {
    var data = $("#SysCodegrid").data("kendoGrid").dataSource.data();
    return data.indexOf(dataItem);
}