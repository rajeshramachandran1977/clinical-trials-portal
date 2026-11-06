//#region Template declarations
var invoicestemplate = kendo.template($("#invoicestemplate").html());
//#endregion

//#region delete row functions in grids
function deleteInvoicedetails(e) {
    e.preventDefault ? e.preventDefault() : e.returnValue = false;
    $(document).ready(function () {
        wnd = $("#modalWindow").kendoWindow({
            title: deleteMsg,
            modal: true,
            visible: false,
            resizable: false,
            width: 400
        }).data("kendoWindow");
    });
    var grid = $("#ui_dtg_Invoices").data("kendoGrid"); //Get the grid from which the pop-up is coming
    var tr = $(e.target).closest("tr"); //get the row for deletion
    var data = this.dataItem(tr);
    wnd.center().open();

    $("#ui_btn_yes").click(function () {
        grid.dataSource.remove(data);
        grid.dataSource.sync();
        wnd.close();
    });
    $("#ui_btn_no").click(function () {
        wnd.close();
    });
}
//#endregion

function addInvoicedetails() {
    var wnd = $("#Invoices").data("kendoWindow");
    wnd.content(invoicestemplate(kendo.template($("#invoicestemplate").html())));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadInvoicesAttributes();

    CheckcharacterLength();

    $(document).ready(function () {
        $(".floatNumberField").change(function () {
            $(this).val(parseFloat($(this).val()).toFixed(2));
        });
    });

    $('#budgetsource,#invoicedate,#organizationtype,#natureofexpenditure,#purposeofexpenditure,#settingofactivity,#currency').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    $("#descriptionofpayment,#invoicenumber,#ponumber,#paymentamount,#lineitem,#generalledgernumber, \
          #departmentcode,#personnel,#procedural,#IRBFees,#IRBAnnualFees,#administrative,#pharmacy, \
          #startup,#correlative,#other").on("keyup", function (e) {
        $(this).nextAll("div.error").remove();
    })

    isvalidRegexfordescriptionofpayment = isvalidRegexforinvoicenumber = isvalidRegexforlineitem =
        isvalidRegexforgeneralledgernumber = isvalidRegexfordepartmentcode = true;

    //#region Validate RegEx values for Invoices fields(Add mode)
    $("#ui_txtarea_descriptionofpayment").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_descriptionofpayment").val().trim();
        if (str != "")
            if ($("#regexexprfordescriptionofpayment").val() != "") {
                var expr = new RegExp($("#regexexprfordescriptionofpayment").val());
                var str = $("#ui_txtarea_descriptionofpayment").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_descriptionofpayment').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordescriptionofpayment").val() + '</span>');
                    isvalidRegexfordescriptionofpayment = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordescriptionofpayment = true;
                    return true;
                }
            }
    });
    $("#ui_txt_descriptionofpayment").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_descriptionofpayment").val().trim();
        if (str != "")
            if ($("#regexexprfordescriptionofpayment").val() != "") {
                var expr = new RegExp($("#regexexprfordescriptionofpayment").val());
                var str = $("#ui_txt_descriptionofpayment").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_descriptionofpayment').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordescriptionofpayment").val() + '</span>');
                    isvalidRegexfordescriptionofpayment = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordescriptionofpayment = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_invoicenumber").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_invoicenumber").val().trim();
        if (str != "")
            if ($("#regexexprforinvoicenumber").val() != "") {
                var expr = new RegExp($("#regexexprforinvoicenumber").val());
                var str = $("#ui_txtarea_invoicenumber").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_invoicenumber').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforinvoicenumber").val() + '</span>');
                    isvalidRegexforinvoicenumber = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforinvoicenumber = true;
                    return true;
                }
            }
    });
    $("#ui_txt_invoicenumber").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_invoicenumber").val().trim();
        if (str != "")
            if ($("#regexexprforinvoicenumber").val() != "") {
                var expr = new RegExp($("#regexexprforinvoicenumber").val());
                var str = $("#ui_txt_invoicenumber").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_invoicenumber').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforinvoicenumber").val() + '</span>');
                    isvalidRegexforinvoicenumber = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforinvoicenumber = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_ponumber").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_ponumber").val().trim();
        if (str != "")
            if ($("#regexexprforponumber").val() != "") {
                var expr = new RegExp($("#regexexprforponumber").val());
                var str = $("#ui_txtarea_ponumber").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_ponumber').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforponumber").val() + '</span>');
                    isvalidRegexforponumber = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforponumber = true;
                    return true;
                }
            }
    });
    $("#ui_txt_ponumber").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_ponumber").val().trim();
        if (str != "")
            if ($("#regexexprforponumber").val() != "") {
                var expr = new RegExp($("#regexexprforponumber").val());
                var str = $("#ui_txt_ponumber").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_ponumber').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforponumber").val() + '</span>');
                    isvalidRegexforponumber = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforponumber = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_lineitem").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_lineitem").val().trim();
        if (str != "")
            if ($("#regexexprforlineitem").val() != "") {
                var expr = new RegExp($("#regexexprforlineitem").val());
                var str = $("#ui_txtarea_lineitem").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_lineitem').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforlineitem").val() + '</span>');
                    isvalidRegexforlineitem = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforlineitem = true;
                    return true;
                }
            }
    });
    $("#ui_txt_lineitem").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_lineitem").val().trim();
        if (str != "")
            if ($("#regexexprforlineitem").val() != "") {
                var expr = new RegExp($("#regexexprforlineitem").val());
                var str = $("#ui_txt_lineitem").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_lineitem').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforlineitem").val() + '</span>');
                    isvalidRegexforlineitem = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforlineitem = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_generalledgernumber").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_generalledgernumber").val().trim();
        if (str != "")
            if ($("#regexexprforgeneralledgernumber").val() != "") {
                var expr = new RegExp($("#regexexprforgeneralledgernumber").val());
                var str = $("#ui_txtarea_generalledgernumber").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_generalledgernumber').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforgeneralledgernumber").val() + '</span>');
                    isvalidRegexforgeneralledgernumber = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforgeneralledgernumber = true;
                    return true;
                }
            }
    });
    $("#ui_txt_generalledgernumber").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_generalledgernumber").val().trim();
        if (str != "")
            if ($("#regexexprforgeneralledgernumber").val() != "") {
                var expr = new RegExp($("#regexexprforgeneralledgernumber").val());
                var str = $("#ui_txt_generalledgernumber").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_generalledgernumber').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforgeneralledgernumber").val() + '</span>');
                    isvalidRegexforgeneralledgernumber = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforgeneralledgernumber = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_departmentcode").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_departmentcode").val().trim();
        if (str != "")
            if ($("#regexexprfordepartmentcode").val() != "") {
                var expr = new RegExp($("#regexexprfordepartmentcode").val());
                var str = $("#ui_txtarea_departmentcode").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_departmentcode').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordepartmentcode").val() + '</span>');
                    isvalidRegexfordepartmentcode = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordepartmentcode = true;
                    return true;
                }
            }
    });
    $("#ui_txt_departmentcode").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_departmentcode").val().trim();
        if (str != "")
            if ($("#regexexprfordepartmentcode").val() != "") {
                var expr = new RegExp($("#regexexprfordepartmentcode").val());
                var str = $("#ui_txt_departmentcode").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_departmentcode').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordepartmentcode").val() + '</span>');
                    isvalidRegexfordepartmentcode = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordepartmentcode = true;
                    return true;
                }
            }
    });

    //#endregion ValidateContactsFields

    //#region Save Invoices(Add mode)
    $("#ui_btnSaveinvoices").click(function (e) {
        SaveInvoices("Create");
    });
    //#endregion

}

function showInvoicedetails(e) {
    var grid = $("#ui_dtg_Invoices").getKendoGrid();
    var wnd = $("#Invoices").data("kendoWindow");
    var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(invoicestemplate(dataItem));
    wnd.center().open();
    $(".k-window").addClass("customWidth");

    LoadInvoicesAttributes();

    CheckcharacterLength();

    $(document).ready(function () {
        $(".floatNumberField").change(function () {
            $(this).val(parseFloat($(this).val()).toFixed(2));
        });
    });

    $('#budgetsource,#invoicedate,#organizationtype,#natureofexpenditure,#purposeofexpenditure,#settingofactivity,#currency').change(function () {
        $(this).nextAll("div.error").remove();
    }).change();

    $("#descriptionofpayment,#invoicenumber,#ponumber,#paymentamount,#lineitem,#generalledgernumber, \
          #departmentcode,#personnel,#procedural,#IRBFees,#IRBAnnualFees,#administrative,#pharmacy, \
          #startup,#correlative,#other").on("keyup", function (e) {
        $(this).nextAll("div.error").remove();
    })

    isvalidRegexfordescriptionofpayment = isvalidRegexforinvoicenumber = isvalidRegexforlineitem =
        isvalidRegexforgeneralledgernumber = isvalidRegexfordepartmentcode = true;

    //#region Validate RegEx values for Invoices fields(Add mode)
    $("#ui_txtarea_descriptionofpayment").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_descriptionofpayment").val().trim();
        if (str != "")
            if ($("#regexexprfordescriptionofpayment").val() != "") {
                var expr = new RegExp($("#regexexprfordescriptionofpayment").val());
                var str = $("#ui_txtarea_descriptionofpayment").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_descriptionofpayment').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordescriptionofpayment").val() + '</span>');
                    isvalidRegexfordescriptionofpayment = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordescriptionofpayment = true;
                    return true;
                }
            }
    });
    $("#ui_txt_descriptionofpayment").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_descriptionofpayment").val().trim();
        if (str != "")
            if ($("#regexexprfordescriptionofpayment").val() != "") {
                var expr = new RegExp($("#regexexprfordescriptionofpayment").val());
                var str = $("#ui_txt_descriptionofpayment").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_descriptionofpayment').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordescriptionofpayment").val() + '</span>');
                    isvalidRegexfordescriptionofpayment = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordescriptionofpayment = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_invoicenumber").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_invoicenumber").val().trim();
        if (str != "")
            if ($("#regexexprforinvoicenumber").val() != "") {
                var expr = new RegExp($("#regexexprforinvoicenumber").val());
                var str = $("#ui_txtarea_invoicenumber").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_invoicenumber').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforinvoicenumber").val() + '</span>');
                    isvalidRegexforinvoicenumber = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforinvoicenumber = true;
                    return true;
                }
            }
    });
    $("#ui_txt_invoicenumber").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_invoicenumber").val().trim();
        if (str != "")
            if ($("#regexexprforinvoicenumber").val() != "") {
                var expr = new RegExp($("#regexexprforinvoicenumber").val());
                var str = $("#ui_txt_invoicenumber").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_invoicenumber').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforinvoicenumber").val() + '</span>');
                    isvalidRegexforinvoicenumber = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforinvoicenumber = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_ponumber").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_ponumber").val().trim();
        if (str != "")
            if ($("#regexexprforponumber").val() != "") {
                var expr = new RegExp($("#regexexprforponumber").val());
                var str = $("#ui_txtarea_ponumber").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_ponumber').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforponumber").val() + '</span>');
                    isvalidRegexforponumber = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforponumber = true;
                    return true;
                }
            }
    });
    $("#ui_txt_ponumber").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_ponumber").val().trim();
        if (str != "")
            if ($("#regexexprforponumber").val() != "") {
                var expr = new RegExp($("#regexexprforponumber").val());
                var str = $("#ui_txt_ponumber").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_ponumber').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforponumber").val() + '</span>');
                    isvalidRegexforponumber = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforponumber = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_lineitem").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_lineitem").val().trim();
        if (str != "")
            if ($("#regexexprforlineitem").val() != "") {
                var expr = new RegExp($("#regexexprforlineitem").val());
                var str = $("#ui_txtarea_lineitem").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_lineitem').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforlineitem").val() + '</span>');
                    isvalidRegexforlineitem = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforlineitem = true;
                    return true;
                }
            }
    });
    $("#ui_txt_lineitem").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_lineitem").val().trim();
        if (str != "")
            if ($("#regexexprforlineitem").val() != "") {
                var expr = new RegExp($("#regexexprforlineitem").val());
                var str = $("#ui_txt_lineitem").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_lineitem').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforlineitem").val() + '</span>');
                    isvalidRegexforlineitem = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforlineitem = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_generalledgernumber").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_generalledgernumber").val().trim();
        if (str != "")
            if ($("#regexexprforgeneralledgernumber").val() != "") {
                var expr = new RegExp($("#regexexprforgeneralledgernumber").val());
                var str = $("#ui_txtarea_generalledgernumber").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_generalledgernumber').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforgeneralledgernumber").val() + '</span>');
                    isvalidRegexforgeneralledgernumber = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforgeneralledgernumber = true;
                    return true;
                }
            }
    });
    $("#ui_txt_generalledgernumber").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_generalledgernumber").val().trim();
        if (str != "")
            if ($("#regexexprforgeneralledgernumber").val() != "") {
                var expr = new RegExp($("#regexexprforgeneralledgernumber").val());
                var str = $("#ui_txt_generalledgernumber").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_generalledgernumber').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgforgeneralledgernumber").val() + '</span>');
                    isvalidRegexforgeneralledgernumber = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexforgeneralledgernumber = true;
                    return true;
                }
            }
    });

    $("#ui_txtarea_departmentcode").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txtarea_departmentcode").val().trim();
        if (str != "")
            if ($("#regexexprfordepartmentcode").val() != "") {
                var expr = new RegExp($("#regexexprfordepartmentcode").val());
                var str = $("#ui_txtarea_departmentcode").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txtarea_departmentcode').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordepartmentcode").val() + '</span>');
                    isvalidRegexfordepartmentcode = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordepartmentcode = true;
                    return true;
                }
            }
    });
    $("#ui_txt_departmentcode").blur(function () {
        $(this).nextAll("div.error").remove();
        var str = $("#ui_txt_departmentcode").val().trim();
        if (str != "")
            if ($("#regexexprfordepartmentcode").val() != "") {
                var expr = new RegExp($("#regexexprfordepartmentcode").val());
                var str = $("#ui_txt_departmentcode").val();
                if (str != "" && !expr.test(str)) {
                    $('#ui_txt_departmentcode').after('<span class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $("#validationmsgfordepartmentcode").val() + '</span>');
                    isvalidRegexfordepartmentcode = false;
                    return false;
                } else {
                    $(this).nextAll("div.error").remove();
                    isvalidRegexfordepartmentcode = true;
                    return true;
                }
            }
    });

    //#endregion 

    //#region Get existing Invoices
    $("#ui_num_invoicedetailsid").val(dataItem.InvoicesdetailsId);
    $("#ui_dt_checksenttosite").data("kendoDatePicker").value(dataItem.Checksenttosite);
    $("#ui_txt_descriptionofpayment,#ui_txtarea_descriptionofpayment").val(dataItem.Descriptionofpayment);
    $("#ui_dt_invoicedate").data("kendoDatePicker").value(dataItem.Invoicedate);
    $("#ui_txt_invoicenumber,#ui_txtarea_invoicenumber").val(dataItem.Invoicenumber);
    $("#ui_ddl_currency").data('kendoDropDownList').value(dataItem.Currency);
    $("#ui_txt_ponumber,#ui_txtarea_ponumber").val(dataItem.Ponumber);
    $("#ui_num_paymentamount").val(dataItem.Paymentamount);
    $("#ui_txt_lineitem,#ui_txtarea_lineitem").val(dataItem.Lineitem);
    $("#ui_txt_generalledgernumber,#ui_txtarea_generalledgernumber").val(dataItem.Generalledgernumber);
    $("#ui_txt_departmentcode,#ui_txtarea_departmentcode").val(dataItem.Departmentcode);
    $("#ui_ddl_budgetsource").data('kendoDropDownList').value(dataItem.Budgetsource);
    $("#ui_num_personnel").val(dataItem.Personnel);
    $("#ui_num_irbfees").val(dataItem.Irbfees);
    $("#ui_num_procedural").val(dataItem.Procedural);
    $("#ui_num_irbannualfees").val(dataItem.Irbannualfees);
    $("#ui_num_administrative").val(dataItem.Administrative);
    $("#ui_num_pharmacy").val(dataItem.Pharmacy);
    $("#ui_num_startup").val(dataItem.Startup);
    $("#ui_num_correlative").val(dataItem.Correlative);
    $("#ui_num_other").val(dataItem.Other);
    $("#ui_ddl_organizationtype").data('kendoDropDownList').value(dataItem.Organizationtype);
    $("#ui_ddl_natureofexpenditure").data('kendoDropDownList').value(dataItem.Natureofexpenditure);
    $("#ui_ddl_purposeofexpenditure").data('kendoDropDownList').value(dataItem.Purposeofexpenditure);
    $("#ui_ddl_settingofactivity").data('kendoDropDownList').value(dataItem.Settingofactivity);
    //#endregion

    //#region Save Invoices(Add mode)
    $("#ui_btnSaveinvoices").click(function (e) {
        SaveInvoices("Create");
    });
    //#endregion

}

function CheckcharacterLength() {
    $("textarea[maxlength]").keyup(function () {
        var charLength = $(this).val().length;
        var charLimit = $(this).attr("maxlength");
        $(this).nextAll("span.count").html(charLimit - charLength + " Characters left to enter");
    });
    $("input[maxlength]").keyup(function () {
        var charLength = $(this).val().length;
        var charLimit = $(this).attr("maxlength");
        $(this).nextAll("span.count").html(charLimit - charLength + " Characters left to enter");
    });
}

//#region Invoices fields
function ValidateInvoicesFields() {
    $(".error").remove();
    retval = true;
    objInvoices = new Object();
    objInvoices.StudyId = $('#StudyId').val();
    objInvoices.InvoicesdetailsId = $('#ui_num_invoicedetailsid').val();

    if ($('#displayChecksenttosite').is(':visible'))
        if (sessionStorage.getItem("ischecksenttosite") == "true") {
            if ($('#ui_dt_checksenttosite').val() == "month day, year") {
                $('#checksenttosite').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_checksenttosite').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_dt_checksenttosite').val() == "month day, year")
                    objInvoices.Checksenttosite = null;
                else
                    objInvoices.Checksenttosite = $('#ui_dt_checksenttosite').val();
            }
        }
        else {
            if ($('#ui_dt_checksenttosite').val() == "month day, year")
                objInvoices.Checksenttosite = null;
            else
                objInvoices.Checksenttosite = $('#ui_dt_checksenttosite').val();
        }

    if ($('#displayDescriptionofpayment').is(':visible'))
        if (sessionStorage.getItem("isdescriptionofpayment") == "true") {
            if ($('#ui_txt_descriptionofpayment').is(':visible')) {
                if ($('#ui_txt_descriptionofpayment').val() == "") {
                    $('#descriptionofpayment').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_descriptionofpayment').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_descriptionofpayment').is(':visible')) {
                if ($('#ui_txtarea_descriptionofpayment').val() == "") {
                    $('#descriptionofpayment').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_descriptionofpayment').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_descriptionofpayment').is(':visible'))
                objInvoices.Descriptionofpayment = $('#ui_txt_descriptionofpayment').val().trim();
            if ($('#ui_txtarea_descriptionofpayment').is(':visible'))
                objInvoices.Descriptionofpayment = $('#ui_txtarea_descriptionofpayment').val().trim();
        }
        else {
            if ($('#ui_txt_descriptionofpayment').is(':visible'))
                objInvoices.Descriptionofpayment = $('#ui_txt_descriptionofpayment').val().trim();
            if ($('#ui_txtarea_descriptionofpayment').is(':visible'))
                objInvoices.Descriptionofpayment = $('#ui_txtarea_descriptionofpayment').val().trim();
        }

    if ($('#displayInvoicedate').is(':visible'))
        if (sessionStorage.getItem("isinvoicedate") == "true") {
            if ($('#ui_dt_invoicedate').val() == "month day, year") {
                $('#isinvoicedate').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_invoicedate').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_dt_invoicedate').val() == "month day, year")
                    objInvoices.Invoicedate = null;
                else
                    objInvoices.Invoicedate = $('#ui_dt_invoicedate').val();
            }
        }
        else {
            if ($('#ui_dt_invoicedate').val() == "month day, year")
                objInvoices.Invoicedate = null;
            else
                objInvoices.Invoicedate = $('#ui_dt_invoicedate').val();
        }

    if ($('#displayInvoicenumber').is(':visible'))
        if (sessionStorage.getItem("isinvoicenumber") == "true") {
            if ($('#ui_txt_invoicenumber').is(':visible')) {
                if ($('#ui_txt_invoicenumber').val() == "") {
                    $('#invoicenumber').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_invoicenumber').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_invoicenumber').is(':visible')) {
                if ($('#ui_txtarea_invoicenumber').val() == "") {
                    $('#invoicenumber').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_invoicenumber').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_invoicenumber').is(':visible'))
                objInvoices.Invoicenumber = $('#ui_txt_invoicenumber').val().trim();
            if ($('#ui_txtarea_invoicenumber').is(':visible'))
                objInvoices.Invoicenumber = $('#ui_txtarea_invoicenumber').val().trim();
        }
        else {
            if ($('#ui_txt_invoicenumber').is(':visible'))
                objInvoices.Invoicenumber = $('#ui_txt_invoicenumber').val().trim();
            if ($('#ui_txtarea_invoicenumber').is(':visible'))
                objInvoices.Invoicenumber = $('#ui_txtarea_invoicenumber').val().trim();
        }

    if ($('#displayCurrency').is(':visible'))
        if (sessionStorage.getItem("iscurrency") == "true") {
            if ($('#ui_ddl_currency').val() == "") {
                $('#currency').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_currency').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_currency').val() == "month day, year")
                    objInvoices.Currency = null;
                else
                    objInvoices.Currency = $('#ui_ddl_currency').val();
            }
        }
        else {
            if ($('#ui_ddl_currency').val() == "month day, year")
                objInvoices.Currency = null;
            else
                objInvoices.Currency = $('#ui_ddl_currency').val();
        }

    if ($('#displayPONumber').is(':visible'))
        if (sessionStorage.getItem("isponumber") == "true") {
            if ($('#ui_txt_ponumber').is(':visible')) {
                if ($('#ui_txt_ponumber').val() == "") {
                    $('#ponumber').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_ponumber').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_ponumber').is(':visible')) {
                if ($('#ui_txtarea_ponumber').val() == "") {
                    $('#ponumber').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_ponumber').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_ponumber').is(':visible'))
                objInvoices.Ponumber = $('#ui_txt_ponumber').val().trim();
            if ($('#ui_txtarea_ponumber').is(':visible'))
                objInvoices.Ponumber = $('#ui_txtarea_ponumber').val().trim();
        }
        else {
            if ($('#ui_txt_ponumber').is(':visible'))
                objInvoices.Ponumber = $('#ui_txt_ponumber').val().trim();
            if ($('#ui_txtarea_ponumber').is(':visible'))
                objInvoices.Ponumber = $('#ui_txtarea_ponumber').val().trim();
        }

    if ($('#displayPaymentamount').is(':visible'))
        if (sessionStorage.getItem("ispaymentamount") == "true") {
            if ($('#ui_num_paymentamount').is(':visible')) {
                if ($('#ui_num_paymentamount').val() == "") {
                    $('#paymentamount').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_paymentamount').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_num_paymentamount').is(':visible'))
                objInvoices.Paymentamount = $('#ui_num_paymentamount').val().trim();
        }
        else {
            if ($('#ui_num_paymentamount').is(':visible'))
                objInvoices.Paymentamount = $('#ui_num_paymentamount').val().trim();
        }

    if ($('#displayLineitem').is(':visible'))
        if (sessionStorage.getItem("islineitem") == "true") {
            if ($('#ui_txt_lineitem').is(':visible')) {
                if ($('#ui_txt_lineitem').val() == "") {
                    $('#lineitem').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_lineitem').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_lineitem').is(':visible')) {
                if ($('#ui_txtarea_lineitem').val() == "") {
                    $('#lineitem').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_lineitem').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_lineitem').is(':visible'))
                objInvoices.Lineitem = $('#ui_txt_lineitem').val().trim();
            if ($('#ui_txtarea_lineitem').is(':visible'))
                objInvoices.Lineitem = $('#ui_txtarea_lineitem').val().trim();
        }
        else {
            if ($('#ui_txt_lineitem').is(':visible'))
                objInvoices.Lineitem = $('#ui_txt_lineitem').val().trim();
            if ($('#ui_txtarea_lineitem').is(':visible'))
                objInvoices.Lineitem = $('#ui_txtarea_lineitem').val().trim();
        }

    if ($('#displayGeneralledgernumber').is(':visible'))
        if (sessionStorage.getItem("isgeneralledgernumber") == "true") {
            if ($('#ui_txt_generalledgernumber').is(':visible')) {
                if ($('#ui_txt_generalledgernumber').val() == "") {
                    $('#generalledgernumber').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_generalledgernumber').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_generalledgernumber').is(':visible')) {
                if ($('#ui_txtarea_generalledgernumber').val() == "") {
                    $('#generalledgernumber').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_generalledgernumber').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_generalledgernumber').is(':visible'))
                objInvoices.Generalledgernumber = $('#ui_txt_generalledgernumber').val().trim();
            if ($('#ui_txtarea_generalledgernumber').is(':visible'))
                objInvoices.Generalledgernumber = $('#ui_txtarea_generalledgernumber').val().trim();
        }
        else {
            if ($('#ui_txt_generalledgernumber').is(':visible'))
                objInvoices.Generalledgernumber = $('#ui_txt_generalledgernumber').val().trim();
            if ($('#ui_txtarea_generalledgernumber').is(':visible'))
                objInvoices.Generalledgernumber = $('#ui_txtarea_generalledgernumber').val().trim();
        }

    if ($('#displayDepartmentcode').is(':visible'))
        if (sessionStorage.getItem("isdepartmentcode") == "true") {
            if ($('#ui_txt_departmentcode').is(':visible')) {
                if ($('#ui_txt_departmentcode').val() == "") {
                    $('#departmentcode').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_departmentcode').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txtarea_departmentcode').is(':visible')) {
                if ($('#ui_txtarea_departmentcode').val() == "") {
                    $('#departmentcode').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_departmentcode').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_txt_departmentcode').is(':visible'))
                objInvoices.Departmentcode = $('#ui_txt_departmentcode').val().trim();
            if ($('#ui_txtarea_departmentcode').is(':visible'))
                objInvoices.Departmentcode = $('#ui_txtarea_departmentcode').val().trim();
        }
        else {
            if ($('#ui_txt_departmentcode').is(':visible'))
                objInvoices.Departmentcode = $('#ui_txt_departmentcode').val().trim();
            if ($('#ui_txtarea_departmentcode').is(':visible'))
                objInvoices.Departmentcode = $('#ui_txtarea_departmentcode').val().trim();
        }

    if ($('#displayBudgetsource').is(':visible'))
        if (sessionStorage.getItem("isbudgetsource") == "true") {
            if ($('#ui_ddl_budgetsource').val() == "") {
                $('#budgetsource').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_budgetsource').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_budgetsource').val() == "month day, year")
                    objInvoices.Budgetsource = null;
                else
                    objInvoices.Budgetsource = $('#ui_ddl_budgetsource').val();
            }
        }
        else {
            if ($('#ui_ddl_budgetsource').val() == "month day, year")
                objInvoices.Budgetsource = null;
            else
                objInvoices.Budgetsource = $('#ui_ddl_budgetsource').val();
        }

    if ($('#displayPersonnel').is(':visible'))
        if (sessionStorage.getItem("ispersonnel") == "true") {
            if ($('#ui_num_personnel').is(':visible')) {
                if ($('#ui_num_personnel').val() == "") {
                    $('#personnel').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_personnel').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_num_personnel').is(':visible'))
                objInvoices.Personnel = $('#ui_num_personnel').val().trim();
        }
        else {
            if ($('#ui_num_personnel').is(':visible'))
                objInvoices.Personnel = $('#ui_num_personnel').val().trim();
        }

    if ($('#displayIRBFees').is(':visible'))
        if (sessionStorage.getItem("isirbfees") == "true") {
            if ($('#ui_num_irbfees').is(':visible')) {
                if ($('#ui_num_irbfees').val() == "") {
                    $('#IRBFees').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_irbfees').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_num_irbfees').is(':visible'))
                objInvoices.Irbfees = $('#ui_num_irbfees').val().trim();
        }
        else {
            if ($('#ui_num_irbfees').is(':visible'))
                objInvoices.Irbfees = $('#ui_num_irbfees').val().trim();
        }

    if ($('#displayProcedural').is(':visible'))
        if (sessionStorage.getItem("isprocedural") == "true") {
            if ($('#ui_num_procedural').is(':visible')) {
                if ($('#ui_num_procedural').val() == "") {
                    $('#procedural').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_procedural').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_num_procedural').is(':visible'))
                objInvoices.Procedural = $('#ui_num_procedural').val().trim();
        }
        else {
            if ($('#ui_num_procedural').is(':visible'))
                objInvoices.Procedural = $('#ui_num_procedural').val().trim();
        }

    if ($('#displayIRBAnnualfees').is(':visible'))
        if (sessionStorage.getItem("isirbannualfees") == "true") {
            if ($('#ui_num_irbannualfees').is(':visible')) {
                if ($('#ui_num_irbannualfees').val() == "") {
                    $('#IRBAnnualFees').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_irbannualfees').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_num_irbannualfees').is(':visible'))
                objInvoices.Irbannualfees = $('#ui_num_irbannualfees').val().trim();
        }
        else {
            if ($('#ui_num_irbannualfees').is(':visible'))
                objInvoices.Irbannualfees = $('#ui_num_irbannualfees').val().trim();
        }

    if ($('#displayAdministrative').is(':visible'))
        if (sessionStorage.getItem("isadministrative") == "true") {
            if ($('#ui_num_administrative').is(':visible')) {
                if ($('#ui_num_administrative').val() == "") {
                    $('#administrative').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_administrative').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_num_administrative').is(':visible'))
                objInvoices.Administrative = $('#ui_num_administrative').val().trim();
        }
        else {
            if ($('#ui_num_administrative').is(':visible'))
                objInvoices.Administrative = $('#ui_num_administrative').val().trim();
        }

    if ($('#displayPharmacy').is(':visible'))
        if (sessionStorage.getItem("ispharmacy") == "true") {
            if ($('#ui_num_pharmacy').is(':visible')) {
                if ($('#ui_num_pharmacy').val() == "") {
                    $('#pharmacy').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_pharmacy').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_num_pharmacy').is(':visible'))
                objInvoices.Pharmacy = $('#ui_num_pharmacy').val().trim();
        }
        else {
            if ($('#ui_num_pharmacy').is(':visible'))
                objInvoices.Pharmacy = $('#ui_num_pharmacy').val().trim();
        }

    if ($('#displayStartup').is(':visible'))
        if (sessionStorage.getItem("isstartup") == "true") {
            if ($('#ui_num_startup').is(':visible')) {
                if ($('#ui_num_startup').val() == "") {
                    $('#startup').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_startup').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_num_startup').is(':visible'))
                objInvoices.Startup = $('#ui_num_startup').val().trim();
        }
        else {
            if ($('#ui_num_startup').is(':visible'))
                objInvoices.Startup = $('#ui_num_startup').val().trim();
        }

    if ($('#displayCorrelative').is(':visible'))
        if (sessionStorage.getItem("iscorrelative") == "true") {
            if ($('#ui_num_correlative').is(':visible')) {
                if ($('#ui_num_correlative').val() == "") {
                    $('#correlative').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_correlative').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_num_correlative').is(':visible'))
                objInvoices.Correlative = $('#ui_num_correlative').val().trim();
        }
        else {
            if ($('#ui_num_correlative').is(':visible'))
                objInvoices.Correlative = $('#ui_num_correlative').val().trim();
        }

    if ($('#displayOther').is(':visible'))
        if (sessionStorage.getItem("isother") == "true") {
            if ($('#ui_num_other').is(':visible')) {
                if ($('#ui_num_other').val() == "") {
                    $('#other').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_other').html() + ' is required</div>');
                    retval = false;
                }
            }
            if ($('#ui_num_other').is(':visible'))
                objInvoices.Other = $('#ui_num_other').val().trim();
        }
        else {
            if ($('#ui_num_other').is(':visible'))
                objInvoices.Other = $('#ui_num_other').val().trim();
        }

    if ($('#displayOrganizationtype').is(':visible'))
        if (sessionStorage.getItem("isorganizationtype") == "true") {
            if ($('#ui_ddl_organizationtype').val() == "") {
                $('#organizationtype').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_organizationtype').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_organizationtype').val() == "")
                    objInvoices.Organizationtype = null;
                else
                    objInvoices.Organizationtype = $('#ui_ddl_organizationtype').val();
            }
        }
        else {
            if ($('#ui_ddl_organizationtype').val() == "")
                objInvoices.Organizationtype = null;
            else
                objInvoices.Organizationtype = $('#ui_ddl_organizationtype').val();
        }

    if ($('#displayNatureofexpenditure').is(':visible'))
        if (sessionStorage.getItem("isnatureofexpenditure") == "true") {
            if ($('#ui_ddl_natureofexpenditure').val() == "") {
                $('#natureofexpenditure').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_natureofexpenditure').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_natureofexpenditure').val() == "")
                    objInvoices.Natureofexpenditure = null;
                else
                    objInvoices.Natureofexpenditure = $('#ui_ddl_natureofexpenditure').val();
            }
        }
        else {
            if ($('#ui_ddl_natureofexpenditure').val() == "")
                objInvoices.Natureofexpenditure = null;
            else
                objInvoices.Natureofexpenditure = $('#ui_ddl_natureofexpenditure').val();
        }

    if ($('#displayPurposeofexpenditure').is(':visible'))
        if (sessionStorage.getItem("ispurposeofexpenditure") == "true") {
            if ($('#ui_ddl_purposeofexpenditure').val() == "") {
                $('#purposeofexpenditure').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_purposeofexpenditure').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_purposeofexpenditure').val() == "")
                    objInvoices.Purposeofexpenditure = null;
                else
                    objInvoices.Purposeofexpenditure = $('#ui_ddl_purposeofexpenditure').val();
            }
        }
        else {
            if ($('#ui_ddl_purposeofexpenditure').val() == "")
                objInvoices.Purposeofexpenditure = null;
            else
                objInvoices.Purposeofexpenditure = $('#ui_ddl_purposeofexpenditure').val();
        }

    if ($('#displaySettingofactivity').is(':visible'))
        if (sessionStorage.getItem("issettingofactivity") == "true") {
            if ($('#ui_ddl_settingofactivity').val() == "") {
                $('#settingofactivity').after('<div class="error errorBackground"><span class="k-icon k-i-warning"></span>' + $('#ui_lbl_settingofactivity').html() + ' is required</div>');
                retval = false;
            } else {
                if ($('#ui_ddl_settingofactivity').val() == "")
                    objInvoices.Settingofactivity = null;
                else
                    objInvoices.Settingofactivity = $('#ui_ddl_settingofactivity').val();
            }
        }
        else {
            if ($('#ui_ddl_settingofactivity').val() == "")
                objInvoices.Settingofactivity = null;
            else
                objInvoices.Settingofactivity = $('#ui_ddl_settingofactivity').val();
        }
}
//#endregion

function SaveInvoices(mode) {
    var validator = $("#ui_dtg_Invoices").kendoValidator().data("kendoValidator");
    ValidateInvoicesFields();
    if ($('#ui_dt_checksenttosite').val() == "month day, year" && $('#ui_txt_descriptionofpayment').val() == "" &&
        $('#ui_txtarea_descriptionofpayment').val() == "" && $('#ui_dt_invoicedate').val() == "month day, year" &&
        $('#ui_txtarea_invoicenumber').val() == "" && $('#ui_txt_invoicenumber').val() == "" && $('#ui_ddl_currency').val() == "month day, year" &&
        $('#ui_txtarea_ponumber').val() == "" && $('#ui_txt_ponumber').val() == "" &&
        $('#ui_num_paymentamount').val() == "" && $('#ui_txtarea_lineitem').val() == "" &&
        $('#ui_txt_lineitem').val() == "" && $('#ui_txtarea_generalledgernumber').val() == "" &&
        $('#ui_txt_generalledgernumber').val() == "" && $('#ui_txt_departmentcode').val() == "" && $('#ui_txtarea_departmentcode').val() == "" &&
        $('#ui_ddl_budgetsource').val() == "month day, year" && $('#ui_num_personnel').val() == "" &&
        $('#ui_num_irbfees').val() == "" && $('#ui_num_procedural').val() == "" &&
        $('#ui_num_irbannualfees').val() == "" && $('#ui_num_administrative').val() == "" &&
        $('#ui_num_pharmacy').val() == "" && $('#ui_num_startup').val() == "" &&
        $('#ui_num_correlative').val() == "" && $('#ui_num_other').val() == "" &&
        $('#ui_ddl_organizationtype').val() == "" && $('#ui_ddl_natureofexpenditure').val() == "" &&
        $('#ui_ddl_purposeofexpenditure').val() == "" && $('#ui_ddl_settingofactivity').val() == "") {
        popupNotification.show("Empty record detected,please enter some values.", "info");
        return false;
    } else {
        if (validator.validate() && retval === true &&
            (isvalidRegexfordescriptionofpayment === true && isvalidRegexforinvoicenumber === true &&
                isvalidRegexforlineitem === true && isvalidRegexforgeneralledgernumber === true &&
                isvalidRegexfordepartmentcode === true))
            Savedetails(type = 25, objEditstudy = objInvoices);
        else
            popupNotification.show(errorsinthepage, "error");
        return false;
    }
}

function LoadInvoicesAttributes() {
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/GetAttributeValues/",
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    //Control Titles,Display Help Text,Mandate Fields,Viewable or not
                    switch (response[i].FieldType) {
                        case checksenttosite:
                            DropDowndetails(response, "displayChecksenttosite", "ui_lbl_checksenttosite", "ui_img_helpTextforchecksenttosite", "ischecksenttosite");
                            break;
                        case descriptionofpayment:
                            Textdetails(response, "displayDescriptionofpayment", "ui_lbl_descriptionofpayment", "ui_img_helpTextfordescriptionofpayment", "isdescriptionofpayment", "ui_txt_descriptionofpayment", "ui_txtarea_descriptionofpayment", "ui_lbl_charsleftfordescriptionofpayment", "regexexprfordescriptionofpayment", "validationmsgfordescriptionofpayment");
                            break;
                        case invoicedate:
                            DropDowndetails(response, "displayInvoicedate", "ui_lbl_invoicedate", "ui_img_helpTextforinvoicedate", "isinvoicedate");
                            break;
                        case invoicenumber:
                            Textdetails(response, "displayInvoicenumber", "ui_lbl_invoicenumber", "ui_img_helpTextforinvoicenumber", "isinvoicenumber", "ui_txt_invoicenumber", "ui_txtarea_invoicenumber", "ui_lbl_charsleftforinvoicenumber", "regexexprforinvoicenumber", "validationmsgforinvoicenumber");
                            break;
                        case ponumber:
                            Textdetails(response, "displayPONumber", "ui_lbl_ponumber", "ui_img_helpTextforponumber", "isponumber", "ui_txt_ponumber", "ui_txtarea_ponumber", "ui_lbl_charsleftforponumber", "regexexprforponumber", "validationmsgforponumber");
                            break;
                        case currency:
                            DropDowndetails(response, "displayCurrency", "ui_lbl_currency", "ui_img_helpTextforcurrency", "iscurrency");
                            break;
                        case paymentamount:
                            NumberFielddetails(response, "displayPaymentamount", "ui_lbl_paymentamount", "ui_img_helpTextforpaymentamount", "ispaymentamount", "ui_num_paymentamount");
                            break;
                        case lineitem:
                            Textdetails(response, "displayLineitem", "ui_lbl_lineitem", "ui_img_helpTextforlineitem", "islineitem", "ui_txt_lineitem", "ui_txtarea_lineitem", "ui_lbl_charsleftforlineitem", "regexexprforlineitem", "validationmsgforlineitem");
                            break;
                        case generalledgernumber:
                            Textdetails(response, "displayGeneralledgernumber", "ui_lbl_generalledgernumber", "ui_img_helpTextforgeneralledgernumber", "isgeneralledgernumber", "ui_txt_generalledgernumber", "ui_txtarea_generalledgernumber", "ui_lbl_charsleftforgeneralledgernumber", "regexexprforgeneralledgernumber", "validationmsgforgeneralledgernumber");
                            break;
                        case departmentcode:
                            Textdetails(response, "displayDepartmentcode", "ui_lbl_departmentcode", "ui_img_helpTextfordepartmentcode", "isdepartmentcode", "ui_txt_departmentcode", "ui_txtarea_departmentcode", "ui_lbl_charsleftfordepartmentcode", "regexexprfordepartmentcode", "validationmsgfordepartmentcode");
                            break;
                        case budgetsource:
                            DropDowndetails(response, "displayBudgetsource", "ui_lbl_budgetsource", "ui_img_helpTextforbudgetsource", "isbudgetsource");
                            break;
                        case personnelspend:
                            NumberFielddetails(response, "displayPersonnel", "ui_lbl_personnel", "ui_img_helpTextforpersonnel", "ispersonnel", "ui_num_personnel");
                            break;
                        case procedural:
                            NumberFielddetails(response, "displayProcedural", "ui_lbl_procedural", "ui_img_helpTextforprocedural", "isprocedural", "ui_num_procedural");
                            break;
                        case irbfees:
                            NumberFielddetails(response, "displayIRBFees", "ui_lbl_irbfees", "ui_img_helpTextforirbfees", "isirbfees", "ui_num_irbfees");
                            break;
                        case irbannualfees:
                            NumberFielddetails(response, "displayIRBAnnualfees", "ui_lbl_irbannualfees", "ui_img_helpTextforirbannualfees", "isirbannualfees", "ui_num_irbfees");
                            break;
                        case administrativeportionofthepayment:
                            NumberFielddetails(response, "displayAdministrative", "ui_lbl_administrative", "ui_img_helpTextforadministrative", "isadministrative", "ui_num_administrative");
                            break;
                        case pharmacyportionofthepayment:
                            NumberFielddetails(response, "displayPharmacy", "ui_lbl_pharmacy", "ui_img_helpTextforpharmacy", "ispharmacy", "ui_num_pharmacy");
                            break;
                        case startup:
                            NumberFielddetails(response, "displayStartup", "ui_lbl_startup", "ui_img_helpTextforstartup", "isstartup", "ui_num_startup");
                            break;
                        case correlative:
                            NumberFielddetails(response, "displayCorrelative", "ui_lbl_correlative", "ui_img_helpTextforcorrelative", "iscorrelative", "ui_num_correlative");
                            break;
                        case other:
                            NumberFielddetails(response, "displayOther", "ui_lbl_other", "ui_img_helpTextforother", "isother", "ui_num_other");
                            break;
                        case organizationtype:
                            DropDowndetails(response, "displayOrganizationtype", "ui_lbl_organizationtype", "ui_img_helpTextfororganizationtype", "isorganizationtype");
                            break;
                        case natureofexpenditure:
                            DropDowndetails(response, "displayNatureofexpenditure", "ui_lbl_natureofexpenditure", "ui_img_helpTextfornatureofexpenditure", "isnatureofexpenditure");
                            break;
                        case purposeofexpenditure:
                            DropDowndetails(response, "displayPurposeofexpenditure", "ui_lbl_purposeofexpenditure", "ui_img_helpTextforpurposeofexpenditure", "ispurposeofexpenditure");
                            break;
                        case settingofactivity:
                            DropDowndetails(response, "displaySettingofactivity", "ui_lbl_settingofactivity", "ui_img_helpTextforsettingofactivity", "issettingofactivity");
                            break;
                        default:
                            break;
                    }
                }
            }
        },
        failure: function (response) {
            popupNotification.show(errorsinthepage, "error");
        }
    });
}

$("#invoices").on("click", function () {
    $('#invoicedetails').removeClass('invoicedetails');
});

$(document).ready(function () {
    $.ajax({
        async: true,
        type: "POST",
        url: "/NewStudy/GetAttributeValues/",
        cache: false,
        dataType: "json",
        success: function (response) {
            if (response.Data == '') {
                popupNotification.show(errorsinthepage, "error");
            } else {
                for (i = 0; i < response.length; i++) {
                    switch (response[i].FieldType) {
                        case checksenttosite:
                            $("#ui_dtg_Invoices th[data-field=Checksenttosite]").html(response[i].Name);
                            break;
                        case descriptionofpayment:
                            $("#ui_dtg_Invoices th[data-field=Descriptionofpayment]").html(response[i].Name);
                            break;
                        case invoicedate:
                            $("#ui_dtg_Invoices th[data-field=Invoicedate]").html(response[i].Name);
                            break;
                        case invoicenumber:
                            $("#ui_dtg_Invoices th[data-field=Invoicenumber]").html(response[i].Name);
                            break;
                        case ponumber:
                            $("#ui_dtg_Invoices th[data-field=Ponumber]").html(response[i].Name);
                            break;
                        case currency:
                            $("#ui_dtg_Invoices th[data-field=Currency]").html(response[i].Name);
                            break;
                        case paymentamount:
                            $("#ui_dtg_Invoices th[data-field=Paymentamount]").html(response[i].Name);
                            break;
                        case lineitem:
                            $("#ui_dtg_Invoices th[data-field=Lineitem]").html(response[i].Name);
                            break;
                        case generalledgernumber:
                            $("#ui_dtg_Invoices th[data-field=Generalledgernumber]").html(response[i].Name);
                            break;
                        case departmentcode:
                            $("#ui_dtg_Invoices th[data-field=Departmentcode]").html(response[i].Name);
                            break;
                        case budgetsource:
                            $("#ui_dtg_Invoices th[data-field=Budgetsource]").html(response[i].Name);
                            break;
                        case personnelspend:
                            $("#ui_dtg_Invoices th[data-field=Personnel]").html(response[i].Name);
                            break;
                        case procedural:
                            $("#ui_dtg_Invoices th[data-field=Procedural]").html(response[i].Name);
                            break;
                        case irbfees:
                            $("#ui_dtg_Invoices th[data-field=Irbfees]").html(response[i].Name);
                            break;
                        case irbannualfees:
                            $("#ui_dtg_Invoices th[data-field=Irbannualfees]").html(response[i].Name);
                            break;
                        case administrativeportionofthepayment:
                            $("#ui_dtg_Invoices th[data-field=Administrative]").html(response[i].Name);
                            break;
                        case pharmacyportionofthepayment:
                            $("#ui_dtg_Invoices th[data-field=Pharmacy]").html(response[i].Name);
                            break;
                        case startup:
                            $("#ui_dtg_Invoices th[data-field=Startup]").html(response[i].Name);
                            break;
                        case correlative:
                            $("#ui_dtg_Invoices th[data-field=Correlative]").html(response[i].Name);
                            break;
                        case other:
                            $("#ui_dtg_Invoices th[data-field=Other]").html(response[i].Name);
                            break;
                        case organizationtype:
                            $("#ui_dtg_Invoices th[data-field=Organizationtype]").html(response[i].Name);
                            break;
                        case natureofexpenditure:
                            $("#ui_dtg_Invoices th[data-field=Natureofexpenditure]").html(response[i].Name);
                            break;
                        case purposeofexpenditure:
                            $("#ui_dtg_Invoices th[data-field=Purposeofexpenditure]").html(response[i].Name);
                            break;
                        case settingofactivity:
                            $("#ui_dtg_Invoices th[data-field=Settingofactivity]").html(response[i].Name);
                            break;
                        default:
                            break;
                    }
                }
            }
        },
        failure: function (response) {
            popupNotification.show(errorsinthepage, "error");
        }
    });
});