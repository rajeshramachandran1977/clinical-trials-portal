var treeview;
$("#testDrpDown").kendoDropDownList();
var dropdownCreate = $("#ui_ddl_restrictCreate").data("kendoDropDownList");
var dropdownView = $("#ui_ddl_restrictView").data("kendoDropDownList");
var dropdownEdit = $("#ui_ddl_restrictEdit").data("kendoDropDownList");
var dropdownDelete = $("#ui_ddl_restrictDelete").data("kendoDropDownList");
var dropdownTextSize = $("#ui_ddl_textsize").data("kendoDropDownList");
var dropdownType = $("#ui_ddl_type").data("kendoDropDownList");
var checkBoxMandatory = $("#ui_chk_box_mandatory").data("KendoCheckBox");

var listBox12 = $("#ui_lstBox_restrictDelete").data("kendoListBox");
var max, min = 1;
var parentId, childId, subChildId, GrandChildId, addGrandChild = false, addChild = false, addSubChild = false;
var treeview = $("#treeview").data("kendoTreeView");
treeview.bind("select", tree_select);


//select integers only
var intRegex = "[0-9 -()+]+$";
//match any ip address
var ipRegex = "bd{1,3}.d{1,3}.d{1,3}.d{1,3}b";
//match ints and floats/decimals
var floatRegex = "[-+]?([0-9]*.[0-9]+|[0-9]+)";
//match email address
//var emailRegex = "^[A-Z0-9._%+-]+@@[A-Z0-9.-]+.[A-Z]{2,4}$";
var emailRegex = "^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}$";
//match credit card numbers
var creditCardRegex = "^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35d{3})d{11})$";
//match username
var usernameRegex = "^[a-z0-9_-]{3,16}$";
//match elements that could contain a phone number
var phoneNumber = "[0-9-()+]{3,20}";
//match a url
var urlRegex = "^(https?://)?([da-z.-]+).([a-z.]{2,6})([/w .-]*)*/?$";
//match a url slug (letters/numbers/hypens)
var urlslugRegex = "'/^[a-z0-9-]+$/'";
//MatchDate (e.g. 21/3/2006)
var dateRegex = "(d{1,2}/d{1,2}/d{4})";
//match date in format MM/DD/YYYY
var dateMMDDYYYRegex = "'^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)dd$'";
//match date in format DD/MM/YYYY
var dateDDMMYYYRegex = "'^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)dd$'";
//match date in format DD/MM/YYYY
var timeRegex = "^([01]?[0-9]|2[0-3]):[0-5][0-9]$";
var num = 1; 

var regexFlag = true;
var colFlag = true;
var valFlag = true;
var parentId = 0;
var childId = 0;
var subChildId = 0;
var grandChildId = 0;


$("#btn_add_attribute").hide();
$("#attribute_display").hide();
$("#messageValidate").hide();
$("#validateText").hide();
$("#uiTypeDropdown").hide();

function tree_select(e) {
    $(".error").remove();   
    var dataItem = this.dataItem(e.node);
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/GetAttributes/",
        cache: false,
        dataType: "json",
        data: { "Name": treeview.text(e.node), "CheckId": dataItem.id },
        success: function (response) {            
            if (response.Data == '') {
                popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
                $("#attribute_display").hide();
                $("#ui_txt_name").val("");
                $("#ui_txt_description").val("");
                $("#ui_txtArea_help_txt").val("");
                $("#ui_chk_box_mandatory").prop('checked', false);
                $("#ui_chk_box_viewable").prop('checked', false);
                $("#ui_chk_box_searchable").prop('checked', false);
            } else {                
                addChild = false;
                addSubChild = false;
                addGrandChild = false;
                if (response[0].Name == null || response[0].Name == "") {
                    data = [
                        { "text": "Number", id: 1 },
                        { "text": "Currency", id: 2 },
                        { "text": "Dropdown", id: 3 },
                        { "text": "Text Area (Rich)", id: 4 },
                        { "text": "Text", id: 5 },
                        { "text": "Yes/No", id: 6 },
                        { "text": "Multi-Select", id: 7 },
                        { "text": "Binary", id: 8 },
                        { "text": "Date", id: 9 },
                    ];
                }
                else {                     
                    $("#uiTypeDropdown").hide();
                    $("#ui_txt_type").show();
                    $("#mandatoryLabel").show();
                    $("#mandatoryCheckBox").show();
                    $("#restrictCreateLabel").show();
                    $("#restrictCreateListboxes").show();
                    $("#restrictEditLabel").show();
                    $("#restrictEditListbox").show();
                    $("#ui_txt_type").prop("disabled", true);
                    $("#ui_txt_fieldType").prop("disabled", true);
                    $("#messageValidate").hide();
                    $("#validateText").hide();
                    if (response[0].Type == null || response[0].Type == "") {
                        data = [
                            { "text": "", id: 1 },
                        ];
                    } else {
                        data = [
                            { "text": response[0].Type, id: 1 },
                        ];
                    }
                }               
                parentId = response[0].ParentID;
                childId = response[0].ChildId;
                subChildId = response[0].SubChildID;
                grandChildId = response[0].GrandChildId;
                if (response[0].Size == "small" || response[0].Size == "Small") {
                    $("#ui_ddl_textsize").data('kendoDropDownList').value(1);
                    max = 50;

                } else {
                    $("#ui_ddl_textsize").data('kendoDropDownList').value(2);
                    max = 4000;

                }



                $("#attribute_display").show();
                $("#editStudyId").val(response[0].EditstudyattributeId);
                $("#ui_txt_name").val(response[0].Name);
                $("#ui_txt_fieldType").val(response[0].FieldType);
                $("#ui_txt_description").val(response[0].Description);
                $("#ui_txtArea_help_txt").val(response[0].HelpText);
                $("#ui_txt_type").val(response[0].Type);


                if (response[0].IsMandatory == true) {
                    $("#ui_chk_box_mandatory").prop('checked', true);
                } else {
                    $("#ui_chk_box_mandatory").prop('checked', false);
                }

                if (response[0].IsViewable == true) {
                    $("#ui_chk_box_viewable").prop('checked', true);
                } else {
                    $("#ui_chk_box_viewable").prop('checked', false);
                }

                if (response[0].IsSearchable == true) {
                    $("#ui_chk_box_searchable").prop('checked', true);
                } else {
                    $("#ui_chk_box_searchable").prop('checked', false);
                }

                $("#ui_num_txt_display_order").val(response[0].DisplayOrder);

                if (response[0].ColumnWidth == null || response[0].ColumnWidth < 1) {
                    $('#ui_num_txt_column_width').val(1);
                } else {
                    $('#ui_num_txt_column_width').val(response[0].ColumnWidth);
                }

                $("#ui_txt_regex_exp").val(response[0].RegexExpression);
                $("#ui_txt_validation_message").val(response[0].ValidationMessage);


                if (response[0].RegexExpression != "") {
                    if (response[0].RegexExpression != null) {
                        $("#messageValidate").show();
                        $("#validateText").show();
                    }

                } else {
                    $("#messageValidate").hide();
                    $("#validateText").hide();
                }
                if (response[0].Type == "Tab" || response[0].Type == "GrandParent Tab" || response[0].Type == "Parent Tab") {
                    $("#btn_add_attribute").show();
                    $("#btn_delete_attribute").hide();
                } else {
                    $("#btn_delete_attribute").show();
                    $("#btn_add_attribute").hide();
                }

                if (response[0].Type == "Text" || response[0].Type == "Text Area (Rich)") {
                    $("#ui_textsize").show();
                    $("#ui_lbl_textsize").show();
                    $("#regex_validation").show();                   
                    $("#div_Col_Width").show();
                } else {
                    $("#ui_textsize").hide();
                    $("#ui_lbl_textsize").hide();
                    $("#regex_validation").hide();                   
                    $("#div_Col_Width").hide();
                    if (response[0].Type == "Label") {
                        $("#mandatoryLabel").hide();
                        $("#mandatoryCheckBox").hide();
                        $("#restrictCreateLabel").hide();
                        $("#restrictCreateListboxes").hide();
                        $("#restrictEditLabel").hide();
                        $("#restrictEditListbox").hide();
                    }
                }
                if (response[0].Name == "IIS" && response[0].Type == "Tab") {
                    $("#groupPermissionDiv").hide();
                    $("#displayOptionDiv").hide();
                    $("#helpDiv").hide();
                } else {
                    $("#groupPermissionDiv").show();
                    $("#displayOptionDiv").show();
                    $("#helpDiv").show();                   
                }
                if (response[0].RestrictCreateUser != null) {
                    var restrictCreateUserArray = response[0].RestrictCreateUser.split(',');
                    $("#ui_lstBox_addCreate").data("kendoListBox").dataSource.data(restrictCreateUserArray);
                    var listBox = $("#ui_lstBox_provideCreate").data("kendoListBox").dataSource;
                    var items = $("#ui_lstBox_provideCreate").data("kendoListBox").items();
                    for (var i = 0; i < listBox._total; i++) {
                        for (var j = 0; j < restrictCreateUserArray.length; j++) {
                            if (listBox._data[i] == restrictCreateUserArray[j]) {
                                $("#ui_lstBox_provideCreate").data("kendoListBox").remove(items[i]);
                            }
                        }
                    }
                } else {
                    $("#ui_lstBox_addCreate").data("kendoListBox").dataSource.data("");
                    $.ajax({
                        async: true,
                        type: "POST",
                        url: "/MetaData/GetSysCodeValues/",
                        cache: false,
                        dataType: "json",
                        data: { "type": "UserType" },
                        success: function (result) {
                            searchResults = result;
                        }
                    }).done(function () {
                        var dataSource = new kendo.data.DataSource({ data: searchResults });
                        var grid = $('#ui_lstBox_provideCreate').data("kendoListBox");
                        dataSource.read();
                        grid.setDataSource(dataSource);
                    }); 
                }
                if (response[0].RestrictViewUser != null) {
                    var restrictViewUserArray = response[0].RestrictViewUser.split(',');
                    $("#ui_lstBox_addView").data("kendoListBox").dataSource.data(restrictViewUserArray);
                    var listBox = $("#ui_lstBox_provideView").data("kendoListBox").dataSource;
                    var items = $("#ui_lstBox_provideView").data("kendoListBox").items();
                    for (var i = 0; i < listBox._total; i++) {
                        for (var j = 0; j < restrictViewUserArray.length; j++) {
                            if (listBox._data[i] == restrictViewUserArray[j]) {
                                $("#ui_lstBox_provideView").data("kendoListBox").remove(items[i]);
                            }
                        }
                    }
                } else {
                    $("#ui_lstBox_addView").data("kendoListBox").dataSource.data("");
                    $.ajax({
                        async: true,
                        type: "POST",
                        url: "/MetaData/GetSysCodeValues/",
                        cache: false,
                        dataType: "json",
                        data: { "type": "UserType" },
                        success: function (result) {
                            searchResults = result;
                        }
                    }).done(function () {
                        var dataSource = new kendo.data.DataSource({ data: searchResults });
                        var grid = $('#ui_lstBox_provideView').data("kendoListBox");
                        dataSource.read();
                        grid.setDataSource(dataSource);
                    });  
                }
                if (response[0].RestrictEditUser != null) {
                    var restrictEditUserArray = response[0].RestrictEditUser.split(',');
                    $("#ui_lstBox_addEdit").data("kendoListBox").dataSource.data(restrictEditUserArray);
                    var listBox = $("#ui_lstBox_provideEdit").data("kendoListBox").dataSource;
                    var items = $("#ui_lstBox_provideEdit").data("kendoListBox").items();
                    for (var i = 0; i < listBox._total; i++) {
                        for (var j = 0; j < restrictEditUserArray.length; j++) {
                            if (listBox._data[i] == restrictEditUserArray[j]) {
                                $("#ui_lstBox_provideEdit").data("kendoListBox").remove(items[i]);
                            }
                        }
                    }
                } else {
                    $("#ui_lstBox_addEdit").data("kendoListBox").dataSource.data("");
                    $.ajax({
                        async: true,
                        type: "POST",
                        url: "/MetaData/GetSysCodeValues/",
                        cache: false,
                        dataType: "json",
                        data: { "type": "UserType" },
                        success: function (result) {
                            searchResults = result;
                        }
                    }).done(function () {
                        var dataSource = new kendo.data.DataSource({ data: searchResults });
                        var grid = $('#ui_lstBox_provideEdit').data("kendoListBox");
                        dataSource.read();
                        grid.setDataSource(dataSource);
                    });  
                   
                }

                if (response[0].RestrictDeleteUser != null) {                    
                    var restrictDeleteUserArray = response[0].RestrictDeleteUser.split(',');
                    $("#ui_lstBox_addDelete").data("kendoListBox").dataSource.data(restrictDeleteUserArray);
                    var listBox = $("#ui_lstBox_provideDelete").data("kendoListBox").dataSource;
                    var items = $("#ui_lstBox_provideDelete").data("kendoListBox").items();
                    for (var i = 0; i < listBox._total; i++) {
                        for (var j = 0; j < restrictDeleteUserArray.length; j++) {
                            if (listBox._data[i] == restrictDeleteUserArray[j]) {
                                $("#ui_lstBox_provideDelete").data("kendoListBox").remove(items[i]);
                            }
                        }
                    }
                } else {                    
                    $("#ui_lstBox_addDelete").data("kendoListBox").dataSource.data("");
                    $.ajax({
                        async: true,
                        type: "POST",
                        url: "/MetaData/GetSysCodeValues/",
                        cache: false,
                        dataType: "json",
                        data: { "type": "UserType" },
                        success: function (result) {
                            searchResults = result;
                        }
                    }).done(function () {
                        var dataSource = new kendo.data.DataSource({ data: searchResults });
                        var grid = $('#ui_lstBox_provideDelete').data("kendoListBox");
                        dataSource.read();
                        grid.setDataSource(dataSource);
                    });                    
                } 
            }
        },
        failure: function (response) {
            popupNotification.show("There are errors on the page. Please correct them to continue.", "error");
        }
    });
}

$(document).ready(function () {
    $("#ui_txt_type").prop("disabled", true);
    $("#ui_txt_fieldType").prop("disabled", true);
});

$("#btn_add_attribute").click(function (e) {
    var treeNode = treeview.dataItem(treeview.select());
    $('#frmMetaData')[0].reset();
    $("#btn_add_attribute").hide();
    $("#ui_txt_name").focus();
    $("#ui_txt_type").prop("disabled", false);
    $("#ui_txt_fieldType").prop("disabled", false);
    if (treeNode.id == 1) {
        addChild = true;
        $("#ui_txt_type").prop("disabled", true);
        $("#ui_txt_type").val("ParentTab");
    } else if (treeNode.id > 100 && treeNode.id < 1000) {
        addSubChild = true;        
        $("#ui_txt_type").prop("disabled", true);
        $("#ui_txt_type").val("Tab");
    } else if (treeNode.id > 10000 && treeNode.id < 100000) {
        addGrandChild = true;        
        $("#uiTypeDropdown").show();
        $("#ui_txt_type").hide();
    }
});

$(btn_save_attribute).click(function () {
    $(".error").remove();
    if ($("#ui_txt_name").val().trim() == "" || $("#ui_txt_name").val().trim() == null) {
        $('#div_Name').next("div.error").remove();        
        $('#div_Name').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + "Please fill this field" + '</div>');
        return false;
    }
    if ($("#ui_txt_fieldType").val().trim() == "" || $("#ui_txt_fieldType").val().trim() == null) {
        $('#div_FieldName').next("div.error").remove();
        $('#div_FieldName').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + "Please fill this field" + '</div>');
        return false;
    }
    if ($("#ui_txt_description").val().trim() == "" || $("#ui_txt_description").val().trim() == null) {
        $('#div_Description').next("div.error").remove();       
        $('#div_Description').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + "Please fill this field" + '</div>');
        return false;
    } else if (colFlag == false) {
        $("#ui_num_txt_column_width").focus();
    } else if (regexFlag == false) {
        $("#ui_txt_regex_exp").focus();
    } else if (valFlag == false) {
        $("#ui_txt_validation_message").focus();
    } else {
        if (addChild) {
            var treeNode = treeview.dataItem(treeview.select());
            objEditStudy = new Object();
            objEditStudy.Name = $("#ui_txt_name").val().trim();
            objEditStudy.ParentId = treeNode.id;
            objEditStudy.ParentName = treeNode.Name;
            objEditStudy.ChildName = $("#ui_txt_name").val().trim();
            objEditStudy.SubChildName = $("#ui_txt_name").val().trim();
            objEditStudy.GrandChildName = $("#ui_txt_name").val().trim();
            objEditStudy.Description = $("#ui_txt_description").val().trim();           
            objEditStudy.Type = "Tab";
            objEditStudy.FieldType = $("#ui_txt_fieldType").val().trim();           
            objEditStudy.IsActive = true;
            objEditStudy.IsDeleted = false;
            $.ajax({
                async: false,
                type: "POST",
                url: '/NewStudy/CreateUpdateEditStudyAttribute',
                data: { "editstudyattributes": objEditStudy },
                success: function (result) {
                    treeview.dataSource.read();
                    $("#attribute_display").hide();
                    popupNotification.show("Attributed added successfully.", "success");
                }
            });

        } else if (addSubChild) {
            var treeNode = treeview.dataItem(treeview.select());
            var parentNode = treeview.dataItem(treeview.select().parent());
            objEditStudy = new Object();
            objEditStudy.EditstudyattributeId = null;
            objEditStudy.Name = $("#ui_txt_name").val().trim();
            objEditStudy.SubChildName = $("#ui_txt_name").val().trim();
            objEditStudy.ParentId = parentNode.id;
            objEditStudy.ParentName = parentNode.Name;
            objEditStudy.ChildName = treeNode.Name;
            objEditStudy.ChildId = treeNode.id;
            objEditStudy.GrandChildName = $("#ui_txt_name").val().trim();
            objEditStudy.Description = $("#ui_txt_description").val().trim();
            objEditStudy.FieldType = $("#ui_txt_fieldType").val().trim();
            objEditStudy.HelpText = $("#ui_txtArea_help_txt").val().trim();
            objEditStudy.Type = $("#ui_txt_type").val().trim();
            objEditStudy.Size = dropdownTextSize.text();
            objEditStudy.IsMandatory = $('#ui_chk_box_mandatory').prop("checked");
            objEditStudy.IsViewable = $('#ui_chk_box_viewable').prop("checked");
            objEditStudy.IsSearchable = $('#ui_chk_box_searchable').prop("checked");
            objEditStudy.DisplayOrder = $("#ui_num_txt_display_order").val().trim();
            if ($("#ui_num_txt_column_width").val() == "") {
                objEditStudy.ColumnWidth = 1;
            } else {
                objEditStudy.ColumnWidth = $("#ui_num_txt_column_width").val();
            }            
            objEditStudy.RegexExpression = $("#ui_txt_regex_exp").val().trim();
            objEditStudy.ValidationMessage = $("#ui_txt_validation_message").val().trim();
            if ($("#ui_lstBox_addCreate").val().toString() == "") {
                objEditStudy.RestrictCreateUser = null;
            } else {
                objEditStudy.RestrictCreateUser = $("#ui_lstBox_addCreate").val().toString();
            }
            if ($("#ui_lstBox_addView").val().toString() == "") {
                objEditStudy.RestrictViewUser = null;
            } else {
                objEditStudy.RestrictViewUser = $("#ui_lstBox_addView").val().toString();
            }
            if ($("#ui_lstBox_addEdit").val().toString() == "") {
                objEditStudy.RestrictEditUser = null;
            } else {
                objEditStudy.RestrictEditUser = $("#ui_lstBox_addEdit").val().toString();
            }
            if ($("#ui_lstBox_addDelete").val().toString() == "") {
                objEditStudy.RestrictDeleteUser = null;
            } else {
                objEditStudy.RestrictDeleteUser = $("#ui_lstBox_addDelete").val().toString();
            }             
            objEditStudy.IsActive = true;
            objEditStudy.IsDeleted = false;

            $.ajax({
                async: false,
                type: "POST",
                url: '/NewStudy/CreateUpdateEditStudyAttribute',
                data: { "editstudyattributes": objEditStudy },
                success: function (result) {
                    treeview.dataSource.read();
                    popupNotification.show("Attributed added successfully.", "success");
                    $("#attribute_display").hide();
                }
            });

        } else if (addGrandChild) {
            var treeNode = treeview.dataItem(treeview.select());
            var parentNode = treeview.dataItem(treeview.select().parent());
            var parent = treeview.parent(treeview.select());
            var grandparent = treeview.parent(parent);
            var grandParentNode = treeview.dataItem(grandparent);
            objEditStudy = new Object();
            objEditStudy.EditstudyattributeId = null;
            objEditStudy.Name = $("#ui_txt_name").val().trim();
            objEditStudy.ParentId = grandParentNode.id;
            objEditStudy.ParentName = grandParentNode.Name;
            objEditStudy.ChildName = parentNode.Name;
            objEditStudy.ChildId = parentNode.id;
            objEditStudy.SubChildId = treeNode.id;
            objEditStudy.SubChildName = treeNode.Name;
            objEditStudy.GrandChildName = $("#ui_txt_name").val().trim();
            objEditStudy.Description = $("#ui_txt_description").val().trim();
            objEditStudy.FieldType = $("#ui_txt_fieldType").val().trim();
            objEditStudy.HelpText = $("#ui_txtArea_help_txt").val().trim();
            objEditStudy.Type = dropdownType.text();
            objEditStudy.Size = dropdownTextSize.text();
            objEditStudy.IsMandatory = $('#ui_chk_box_mandatory').prop("checked");
            objEditStudy.IsViewable = $('#ui_chk_box_viewable').prop("checked");
            objEditStudy.IsSearchable = $('#ui_chk_box_searchable').prop("checked");
            objEditStudy.DisplayOrder = $("#ui_num_txt_display_order").val().trim();
            if ($("#ui_num_txt_column_width").val() == "") {
                objEditStudy.ColumnWidth = 1;
            } else {
                objEditStudy.ColumnWidth = $("#ui_num_txt_column_width").val();
            }
            objEditStudy.RegexExpression = $("#ui_txt_regex_exp").val().trim();
            objEditStudy.ValidationMessage = $("#ui_txt_validation_message").val().trim();
            if ($("#ui_lstBox_addCreate").val().toString() == "") {
                objEditStudy.RestrictCreateUser = null;
            } else {
                objEditStudy.RestrictCreateUser = $("#ui_lstBox_addCreate").val().toString();
            }
            if ($("#ui_lstBox_addView").val().toString() == "") {
                objEditStudy.RestrictViewUser = null;
            } else {
                objEditStudy.RestrictViewUser = $("#ui_lstBox_addView").val().toString();
            }
            if ($("#ui_lstBox_addEdit").val().toString() == "") {
                objEditStudy.RestrictEditUser = null;
            } else {
                objEditStudy.RestrictEditUser = $("#ui_lstBox_addEdit").val().toString();
            }
            if ($("#ui_lstBox_addDelete").val().toString() == "") {
                objEditStudy.RestrictDeleteUser = null;
            } else {
                objEditStudy.RestrictDeleteUser = $("#ui_lstBox_addDelete").val().toString();
            }            
            objEditStudy.IsActive = true;
            objEditStudy.IsDeleted = false;

            $.ajax({
                async: false,
                type: "POST",
                url: '/NewStudy/CreateUpdateEditStudyAttribute',
                data: { "editstudyattributes": objEditStudy },
                success: function (result) {
                    treeview.dataSource.read();
                    popupNotification.show("Attributed added successfully.", "success");
                    $("#attribute_display").hide();
                }
            });

        } else {  
            var treeNode = treeview.dataItem(treeview.select());
            var parentNode, parent, grandparent, greatGrandParent, grandParentNode = treeview.dataItem(treeview.select().parent());

            objEditStudy = new Object();
            objEditStudy.EditstudyattributeId = $("#editStudyId").val();
            objEditStudy.Name = $("#ui_txt_name").val().trim();
            if (treeNode.id == 1) {
                objEditStudy.ParentName = $("#ui_txt_name").val().trim();
                objEditStudy.ChildName = $("#ui_txt_name").val().trim();
                objEditStudy.SubChildName = $("#ui_txt_name").val().trim();
                objEditStudy.GrandChildName = $("#ui_txt_name").val().trim();
            } else if (treeNode.id > 100 && treeNode.id < 1000) {
                parentNode = treeview.dataItem(treeview.select().parent());
                objEditStudy.ParentName = parentNode.Name;
                objEditStudy.ChildName = $("#ui_txt_name").val().trim();
                objEditStudy.SubChildName = $("#ui_txt_name").val().trim();
                objEditStudy.GrandChildName = $("#ui_txt_name").val().trim();
            } else if (treeNode.id > 10000 && treeNode.id < 100000) {
                parentNode = treeview.dataItem(treeview.select().parent());
                parent = treeview.parent(treeview.select());
                grandparent = treeview.parent(parent);
                grandParentNode = treeview.dataItem(grandparent);
                objEditStudy.ParentName = grandParentNode.Name;
                objEditStudy.ChildName = parentNode.Name;
                objEditStudy.SubChildName = $("#ui_txt_name").val().trim();
                objEditStudy.GrandChildName = $("#ui_txt_name").val().trim();
            } else if (treeNode.id >= 1010000) {
                parentNode = treeview.dataItem(treeview.select().parent());
                parent = treeview.parent(treeview.select());
                grandparent = treeview.parent(parent);
                greatGrandParent = treeview.parent(grandparent)
                grandParentNode = treeview.dataItem(grandparent);
                greatGrandParentNode = treeview.dataItem(greatGrandParent);
                objEditStudy.ParentName = greatGrandParentNode.Name;
                objEditStudy.ChildName = grandParentNode.Name;
                objEditStudy.SubChildName = parentNode.Name;
                objEditStudy.GrandChildName = $("#ui_txt_name").val().trim();
            }
            objEditStudy.Description = $("#ui_txt_description").val().trim();
            objEditStudy.FieldType = $("#ui_txt_fieldType").val().trim();
            objEditStudy.HelpText = $("#ui_txtArea_help_txt").val().trim();
            objEditStudy.Type = $("#ui_txt_type").val().trim();
            objEditStudy.Size = dropdownTextSize.text();
            objEditStudy.IsMandatory = $('#ui_chk_box_mandatory').prop("checked");
            objEditStudy.IsViewable = $('#ui_chk_box_viewable').prop("checked");
            objEditStudy.IsSearchable = $('#ui_chk_box_searchable').prop("checked");
            objEditStudy.DisplayOrder = $("#ui_num_txt_display_order").val().trim();
            if ($("#ui_num_txt_column_width").val() == "") {
                objEditStudy.ColumnWidth = 1;
            } else {
                objEditStudy.ColumnWidth = $("#ui_num_txt_column_width").val();
            }
            objEditStudy.RegexExpression = $("#ui_txt_regex_exp").val().trim();
            objEditStudy.ValidationMessage = $("#ui_txt_validation_message").val().trim();
            if ($("#ui_lstBox_addCreate").val() == null) {
                objEditStudy.RestrictCreateUser = null;
            } else {
                objEditStudy.RestrictCreateUser = $("#ui_lstBox_addCreate").val().toString();
            }
            if ($("#ui_lstBox_addView").val() == null) {
                objEditStudy.RestrictViewUser = null;
            } else {
                objEditStudy.RestrictViewUser = $("#ui_lstBox_addView").val().toString();
            }
            if ($("#ui_lstBox_addEdit").val() == null) {               
                objEditStudy.RestrictEditUser = null;
            } else {
                objEditStudy.RestrictEditUser = $("#ui_lstBox_addEdit").val().toString();
            }
            if ($("#ui_lstBox_addDelete").val() == null) {
                objEditStudy.RestrictDeleteUser = null;
            } else {
                objEditStudy.RestrictDeleteUser = $("#ui_lstBox_addDelete").val().toString();
            }            
            objEditStudy.ParentId = parentId;
            objEditStudy.ChildId = childId;
            objEditStudy.SubChildId = subChildId;
            objEditStudy.GrandChildId = grandChildId;
            objEditStudy.IsActive = true;
            objEditStudy.IsDeleted = false;

            $.ajax({
                async: false,
                type: "POST",
                url: '/NewStudy/CreateUpdateEditStudyAttribute',
                data: { "editstudyattributes": objEditStudy },
                success: function (result) {
                    var treeNode = treeview.dataItem(treeview.select());                    
                    treeNode.set("Name", $("#ui_txt_name").val().trim());                    
                    popupNotification.show("Attributed updated successfully.", "success");
                }
            });
        }
    }


});

$("#btn_delete_attribute").click(function (e) {
    $("#attribute_display").hide();
    objEditStudy = new Object();
    objEditStudy.EditstudyattributeId = $("#editStudyId").val()
    objEditStudy.Name = $("#ui_txt_name").val().trim();
    objEditStudy.Description = $("#ui_txt_description").val().trim();
    objEditStudy.FieldType = $("#ui_txt_fieldType").val().trim();
    objEditStudy.HelpText = $("#ui_txtArea_help_txt").val().trim();
    objEditStudy.Type = $("#ui_txt_type").val().trim();
    objEditStudy.Size = dropdownTextSize.text();
    objEditStudy.IsMandatory = $('#ui_chk_box_mandatory').prop("checked");
    objEditStudy.IsViewable = $('#ui_chk_box_viewable').prop("checked");
    objEditStudy.IsSearchable = $('#ui_chk_box_searchable').prop("checked");
    objEditStudy.DisplayOrder = $("#ui_num_txt_display_order").val().trim();
    objEditStudy.ColumnWidth = $("#ui_num_txt_column_width").val().trim();
    objEditStudy.RegexExpression = $("#ui_txt_regex_exp").val().trim();
    objEditStudy.ValidationMessage = $("#ui_txt_validation_message").val().trim();
    if ($("#ui_lstBox_addCreate").val().toString() == "") {
        objEditStudy.RestrictCreateUser = null;
    } else {
        objEditStudy.RestrictCreateUser = $("#ui_lstBox_addCreate").val().toString();
    }
    if ($("#ui_lstBox_addView").val().toString() == "") {
        objEditStudy.RestrictViewUser = null;
    } else {
        objEditStudy.RestrictViewUser = $("#ui_lstBox_addView").val().toString();
    }
    if ($("#ui_lstBox_addEdit").val().toString() == "") {
        objEditStudy.RestrictEditUser = null;
    } else {
        objEditStudy.RestrictEditUser = $("#ui_lstBox_addEdit").val().toString();
    }
    if ($("#ui_lstBox_addDelete").val().toString() == "") {
        objEditStudy.RestrictDeleteUser = null;
    } else {
        objEditStudy.RestrictDeleteUser = $("#ui_lstBox_addDelete").val().toString();
    } 
    objEditStudy.IsActive = false;
    objEditStudy.IsDeleted = true;

    $.ajax({
        async: false,
        type: "POST",
        url: '/NewStudy/CreateUpdateEditStudyAttribute',
        data: { "editstudyattributes": objEditStudy },
        success: function (result) {
            var selectedNode = treeview.select();
            treeview.remove(selectedNode);
            popupNotification.show("Attributed deleted successfully.", "success");
        }
    });
});

$("#ui_ddl_textsize").change(function (e) {

    if (dropdownTextSize.text() == "Small") {
        max = 50;
        $('#div_Col_Width').next("div.error").remove();
        $("#ui_num_txt_column_width").val(null);
        $("#ui_num_txt_column_width").focus();
        $('#div_Col_Width').after('<div class="error errorBackground"><span class="k-icon k-i-info"></span>' + "Max limit : 50" + '</div>');
        return false;
    }
    else {
        max = 4000;
        $('#div_Col_Width').next("div.error").remove();
        $("#ui_num_txt_column_width").val(null);
        $("#ui_num_txt_column_width").focus();
        $('#div_Col_Width').after('<div class="error errorBackground"><span class="k-icon k-i-info"></span>' + "Max limit : 4000" + '</div>');
        return false;
    }

});
$("#ui_txt_fieldType").blur(function (e) {    
    $(this).next("div.error").remove();
});

$("#ui_txt_regex_exp").on('keyup', function () {
    valFlag = true;
    $('#div_validation_message').nextAll("div.error").remove();
    if ($("#ui_txt_regex_exp").val() == intRegex || $("#ui_txt_regex_exp").val() == ipRegex || $("#ui_txt_regex_exp").val() == floatRegex || $("#ui_txt_regex_exp").val() == emailRegex ||
        $("#ui_txt_regex_exp").val() == creditCardRegex || $("#ui_txt_regex_exp").val() == usernameRegex || $("#ui_txt_regex_exp").val() == phoneNumber ||
        $("#ui_txt_regex_exp").val() == urlslugRegex || $("#ui_txt_regex_exp").val() == urlRegex || $("#ui_txt_regex_exp").val() == dateRegex || $("#ui_txt_regex_exp").val() == dateMMDDYYYRegex ||
        $("#ui_txt_regex_exp").val() == dateDDMMYYYRegex || $("#ui_txt_regex_exp").val() == timeRegex) {
        regexFlag = true;
        $("#messageValidate").show();
        $("#validateText").show();
        $("#validateText").focus();
        $(this).next("div.error").remove();
        $('#div_validation_message').next("div.error").remove();
        return true;
    } else {
        regexFlag = true;
        $("#ui_txt_validation_message").val("")
        $("#messageValidate").hide();
        $("#validateText").hide();
        if ($("#ui_txt_regex_exp").val().trim() !== "") {
            $(this).next("div.error").remove();
            regexFlag = false;
            $('#div_validation_message').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + "Invalid Regex expression" + '</div>');
            return false;
        }

    }

});

$("#ui_txt_name").blur(function () {
    $(this).next("div.error").remove();
    return true;
})

$("#ui_txt_description").blur(function () {
    $(this).next("div.error").remove();
    return true;
})

$("#ui_txt_validation_message").change(function () {
    $(this).next("div.error").remove();
    valFlag = true;
    if ($("#ui_txt_validation_message").val() == "") {
        valFlag = false;
        $(this).next("div.error").remove();
        $('#ui_txt_validation_message').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + "Invalid Validation message" + '</div>');
        return false;
    } else {
        $(this).next("div.error").remove();
        return true;
    }
})

$("#ui_ddl_type").change(function () {
    $('#div_Col_Width').next("div.error").remove();   
    if (dropdownType.text() == "Text Area (Rich)" || dropdownType.text() == "Text") {
        $("#ui_textsize").show();
        $("#ui_lbl_textsize").show();
        $("#regex_validation").show();        
        $("#div_Col_Width").show();
        $("#div_validation_message").show();
        $("#mandatoryLabel").show();
        $("#mandatoryCheckBox").show();
        $("#restrictCreateLabel").show();
        $("#restrictCreateListboxes").show();
        $("#restrictEditLabel").show();
        $("#restrictEditListbox").show();
        if (dropdownType.text() == "Text") {
            $("#ui_num_txt_column_width").val(50);
            dropdownTextSize.text("Small")
        }
        if (dropdownType.text() == "Text Area (Rich)") {
            $("#ui_num_txt_column_width").val(4000);
            dropdownTextSize.text("Large")
        }
    } else {
        $("#ui_textsize").hide();
        $("#ui_lbl_textsize").hide();
        $("#regex_validation").hide();        
        $("#div_Col_Width").hide();
        $("#messageValidate").hide();
        $("#div_validation_message").hide();
        if (dropdownType.text() == "Label") {
            $("#mandatoryLabel").hide();
            $("#mandatoryCheckBox").hide();
            $("#restrictCreateLabel").hide();
            $("#restrictCreateListboxes").hide();
            $("#restrictEditLabel").hide();
            $("#restrictEditListbox").hide();
        } else {
            $("#mandatoryLabel").show();
            $("#mandatoryCheckBox").show();
            $("#restrictCreateLabel").show();
            $("#restrictCreateListboxes").show();
            $("#restrictEditLabel").show();
            $("#restrictEditListbox").show();
        }
    }
})

$("#ui_num_txt_column_width").keyup(function () {
    $(div_Col_Width).nextall("div.error").remove();
    if ($("#ui_num_txt_column_width").val() < min) {
        $(this).next("div.error").remove();
        colFlag = false;
        $('#div_Col_Width').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + "Cannot be less than one" + '</div>');
        return false;
    } else if ($("#ui_num_txt_column_width").val() > max) {
        $(this).next("div.error").remove();
        $('#ui_num_txt_column_width').val(max);
    } else {
        $(this).next("div.error").remove();
    }
    
})