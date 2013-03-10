/*
 * Specific customizations for the datatables and forms plugins
 */
var oTable;
/* Table initialisation */
$(document).ready(function () {
    function fnET() {
        if (!oTable || oTable == 'undefined')
            oTable = $('#entity-grid').dataTable();
    }
    // custom datable functions
    function fnGetSelected() {
        fnET();
        return oTable.$('tr.entity-selected');
    }
    function fnShowHide(iCol) {
        fnET();
        var bVis = oTable.fnSettings().aoColumns[iCol].bVisible;
        oTable.fnSetColumnVis(iCol, bVis ? false : true);
    }
    function fnAddItem() {
        fnET();
        if (fnDoAddItemInit)
            fnDoAddItemInit();
        fnSetupModalSubmit();
    }
    function fnEditSelected(row) {
        fnET();
        var aData = oTable.fnGetData(row);
        if (fnDoEditItemInit)
            fnDoEditItemInit(aData);
        fnSetupModalSubmit();
    }
    var fnDoDeleteItem = function (data, errorFunc, successFunc) {
        //do delete
        $.ajax({
            type: "POST", // or DELETE without /delete trailer in url
            url: dtItemUrl(data) + '/delete',
            dataType: 'json',
            data: '',
            timeout: 700000,
            error: errorFunc,
            success: successFunc,
        });
        return false;
    };
    function fnDeleteSelected(row) {
        fnET();
        var aData = oTable.fnGetData(row);
        // do delete
        if (fnDoDeleteItem) {
            fnDoDeleteItem(aData, submitError,
            function () {
                $("#modalErrorBlock").hide();
                $("#modalErrorText").text('');
                oTable.fnDeleteRow();
                fnClearSelections();
            });
        }
    };
    function fnClearSelections() {
        fnET();
        oTable.$('tr.entity-selected').removeClass('entity-selected');
        $("#btnEditItem").attr("disabled", "disabled").addClass("disabled");
        $("#btnDeleteItem").attr("disabled", "disabled").addClass("disabled");
    }
    // modal form setup
    // files uploaded with http://malsup.com/jquery/form/#ajaxSubmit
    function fnSetupModalSubmit() {
        // pass options to ajaxForm 
        $('#btnCommitAddUpdate').click(function (event) {

            // Use the form plugin
            // prepare Options Object 
            var $form = $('#addEditItemForm');
            var $target = $($form.attr('data-target'));
            var options = {
                // ajax options
                type: $form.attr('method'),
                url: $form.attr('action'),
                dataType: 'json',
                target: $target,
                timeout: 600000,

                // upload progress
                //beforeSubmit: showRequest,  // pre-submit callback 
                success: submitSuccess,  // post-submit success callback 
                error: submitError, // post-submit error callback
            };

            $form.ajaxSubmit(options);
            event.preventDefault();
            return false;
        });
    }
    // pre-submit callback 
    function showRequest(formData, jqForm, options) {
        // formData is an array; here we use $.param to convert it to a string to display it 
        // but the form plugin does this for you automatically when it submits the data 
        var queryString = $.param(formData);

        // jqForm is a jQuery object encapsulating the form element.  To access the 
        // DOM element for the form do this: 
        // var formElement = jqForm[0]; 

        alert('About to submit: \n\n' + queryString);

        // here we could return false to prevent the form from being submitted; 
        // returning anything other than false will allow the form submit to continue 
        return true;
    }
    // post-submit callback 
    function submitError(xhr, error, thrownException, $form) {
        $("#modalErrorBlock").show();
        var message = '';
        if (xhr.responseText != null) {
            message = xhr.responseText;
        } else {
            message = 'Unable to process submission' + (error ? ' (' + error + ')' : '');
        }
        $("#modalErrorText").text(message);
        //$("#modalErrorText").text(xhr.status + (error ? '(' + error + ')' : '') + ': ' + xhr.responseText);
    }
    function submitSuccess(responseText, statusText, xhr, $form) {
        // for normal html responses, the first argument to the success callback 
        // is the XMLHttpRequest object's responseText property 

        // if the ajaxForm method was passed an Options Object with the dataType 
        // property set to 'xml' then the first argument to the success callback 
        // is the XMLHttpRequest object's responseXML property 

        // if the ajaxForm method was passed an Options Object with the dataType 
        // property set to 'json' then the first argument to the success callback 
        // is the json data object returned by the server 

        //alert('status: ' + statusText + '\n\nresponseText: \n' + responseText +
        //    '\n\nThe output div should have already been updated with the responseText.');

        // weird behavior in IE
        if (xhr.responseText && xhr.responseText != '') {
            var responseObj = JSON.parse(xhr.responseText);
            if (responseObj.responseStatus && responseObj.responseStatus.errorCode) {
                $("#modalErrorBlock").show();
                var message = '';
                if (responseObj.responseStatus.errorCode.length > 0) message = responseObj.responseStatus.errorCode + " - ";
                if (responseObj.responseStatus.message.length > 0) message += responseObj.responseStatus.message;
                $("#modalErrorText").text(message);
                return;
            }
        }

        $("#modalErrorBlock").hide();
        $("#modalErrorText").text('');
        $('#addEditItemModal').modal('hide');
        fnET();
        oTable.fnDraw(false);
        fnClearSelections();
    }
    // custom datatable init
    $('#entity-grid').dataTable({
        "sDom": "<'row'<'span6'l><'span6'f>r>t<'row'<'span6'i><'span6'p>>",
        "sPaginationType": "bootstrap",
        "oLanguage": {
            "sZeroRecord": "Please wait - fetching data",
            "sLengthMenu": "_MENU_ records per page"
        },
        "fnInitComplete": function (oSettings) {
            oSettings.oLanguage.sZeroRecords = "No matching records found";
        },
        "fnDrawCallback": function (oSettings) {
            $("#entity-grid").width("100%");
            $("#entity-grid tbody tr").click(function (e) {
                fnET();
                var isSelected = $(this).hasClass('entity-selected');
                if (isSelected) {
                    $("#btnEditItem").attr("disabled", "disabled").addClass("disabled");;
                    $("#btnDeleteItem").attr("disabled", "disabled").addClass("disabled");
                    $(this).removeClass('entity-selected');
                }
                else {
                    // preventative - remove any existing selections
                    oTable.$('tr.entity-selected').removeClass('entity-selected');
                    $(this).addClass('entity-selected');
                    $("#btnEditItem").removeAttr("disabled").removeClass("disabled");
                    $("#btnDeleteItem").removeAttr("disabled").removeClass("disabled");
                }
            });
        },
        "aoColumns": window.dtAjaxColumns,
        "bProcessing": false,
        "bServerSide": true,
        "bAutoWidth": true,
        "sAjaxSource": window.dtAjaxUrl,
        "sServerMethod": "POST",
    });
    // custom datatable related ui events
    $('#dt_d_nav').on('click', 'li input', function () {
        fnShowHide($(this).val());
    });
    $('#btnAddItem').click(function () {
        fnAddItem();
        $("#addEditItemModal").modal('show');
    });
    $('#btnEditItem').click(function () {
        var anSelected = fnGetSelected();
        if (anSelected.length !== 0) {
            fnEditSelected(anSelected[0]);
            $("#addEditItemModal").modal('show');
        }
    });
    $('#btnDeleteItem').click(function () {
        var anSelected = fnGetSelected();
        if (anSelected.length !== 0) {
            if (confirm('Please confirm you are trying to delete this record!')) {
                fnDeleteSelected(anSelected[0]);
            }
        }
    });
    $('#showCountHref').click(function() {
        var qs = $.queryString();
        var filter = (qs['filter'] && qs['filter'].length > 0) ? qs['filter'] : '';
        var include = (qs['include'] && qs['include'].length > 0) ? qs['include'] : '';
        var redirectUrl = '';
        if (include.length == 0) {
            var sep = filter.length > 0 && window.dtAllIncludes.length > 0 ? '&' : '';
            var filters = (filter.length > 0 ? 'filter=' + filter : '');
            var includes = (window.dtAllIncludes.length > 0 ? 'include=' + window.dtAllIncludes : '');
            redirectUrl = window.dtBaseUrl + '?' + filters + sep + includes;
        } else {
            redirectUrl = window.dtBaseUrl + (filter.length > 0 ? '?filter=' + filter : '');
        }
        window.location = redirectUrl;
    });
});
