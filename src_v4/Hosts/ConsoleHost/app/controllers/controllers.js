app.controller('TypeCollectionController', function ($scope, $routeParams, metaService, utilService) {
    $scope.name = 'TypeCollectionScope';
    $scope.types = []; $scope.typesLoaded = false;
    $scope.typeCollectionSlug = $routeParams.typeCollectionSlug.toLowerCase();
    $scope.typeNameTCS = $scope.typeCollectionSlug == 'entities' ? 'Entity' : ($scope.typeCollectionSlug == 'lists' ? 'Typed List' : 'Typed View');
    $scope.typeNameTCP = $scope.typeCollectionSlug == 'entities' ? 'Entities' : ($scope.typeCollectionSlug == 'lists' ? 'Typed Lists' : 'Typed Views');
    $scope.getBrowseName = function (item) { return $scope.typeCollectionSlug == 'entities' ? utilService.splitTitleCaseAndPluralize(item.name) : utilService.splitTitleCase(item.name); };

    init();
    function init() {
        metaService
            .getTypeCollection($routeParams.typeCollectionSlug.toLowerCase())
            .then(function (data) { $scope.types = data; $scope.typesLoaded = true; }, function (errorMessage) { $scope.error = errorMessage; });
    };
});

app.controller('TypeController', function ($scope, $location, $routeParams, metaService, typeService, utilService) {
    $scope.error = null;
    $scope.name = 'TypeScope';
    $scope.types = []; $scope.typesLoaded = false;
    $scope.currentType = {}; $scope.currentTypeLoaded = false;
    $scope.currentTypeGridFields = [];
    $scope.typeCollectionSlug = $routeParams.typeCollectionSlug.toLowerCase();
    $scope.typeSlug = $routeParams.typeSlug.toLowerCase();
    $scope.typeNameTCS = $scope.typeCollectionSlug == 'entities' ? 'Entity' : ($scope.typeCollectionSlug == 'lists' ? 'Typed List' : 'Typed View');
    $scope.typeNameTCP = $scope.typeCollectionSlug == 'entities' ? 'Entities' : ($scope.typeCollectionSlug == 'lists' ? 'Typed Lists' : 'Typed Views');
    $scope.filter = $location.search().filter || '';
    $scope.includes = $location.search().include || '';
    $scope.includesAvailable = [];
    $scope.filterInput = ($location.search().filter && $location.search().filter.length > 0) ? ('filter=' + $location.search().filter) : '';
    $scope.showingRelatedCount = $location.search().include && $location.search().include.length > 0;
    $scope.showingRelatedCountText = ($location.search().include && $location.search().include.length > 0) ? 'Hide' : 'Show';
    $scope.getBrowseName = function (item) { return $scope.typeCollectionSlug == 'entities' ? utilService.splitTitleCaseAndPluralize(item.name) : utilService.splitTitleCase(item.name); };
    //$scope.toSplitTitleCase = function(a){ return 'abc'; }
    $scope.editEnabled = false;
    $scope.deleteEnabled = false;
    $scope.selectedEntity = null;

    //jQuery DataTable Variables
    $scope.dtSelectedRowData = null;
    $scope.dtFirstLoad = true;
    $scope.dtReadyForInit = 0;
    $scope.dtAjaxColumns = [];
    $scope.dtAjaxUrl = ($scope.typeCollectionSlug == 'entities' ? '/' : ('/' + $scope.typeCollectionSlug + '/')) + $scope.typeSlug + '/datatable';
    $scope.dtBuildAjaxUrl = function () {
        var baseUrl = $scope.dtAjaxUrl;
        if ($scope.filter.length > 0) baseUrl += '?filter=' + $scope.filter;
        if ($scope.includes.length > 0) baseUrl += ($scope.filter.length > 0 ? '&' : '?') + 'include=' + $scope.includes;
        return baseUrl;
    };
    $scope.dtDeletedEntity = null;
    $scope.dtRedraw = 0;
    $scope.dtRedrawAddEdit = 0;

    //    $scope.fieldIsSortableSearchableVisible = function(field){ return metaService.fieldIsSortableSearchableVisible(field); };
    //    $scope.uiBaseUrl = '/#/'+$routeParams.entityType.toLowerCase();
    //    $scope.ajaxBaseUrl = '/'+$routeParams.entityType.toLowerCase();
    //    $scope.applyFilter = function(){ var f = $('#filterText').val(); if(f) window.location = '/#/entities/' + $scope.currentType.metaLink.id + '?' + f; };

    init();
    function init() {
        metaService
            .getTypeCollection($routeParams.typeCollectionSlug.toLowerCase())
            .then(function (data) { $scope.types = data; $scope.typesLoaded = true; initType(); }, function (errorMessage) { $scope.error = errorMessage; });
    };
    function initType() {
        metaService
            .getType($routeParams.typeCollectionSlug.toLowerCase(), $routeParams.typeSlug.toLowerCase())
            .then(function (data) {
                for (var t = 0; t < $scope.types.length; t++) {
                    var ctype = $scope.types[t];
                    if (ctype.metaLink.id.toLowerCase() == $scope.typeSlug) {
                        $scope.currentType = ctype;
                        $scope.currentType.meta = data;
                        break;
                    }
                }
                if ($scope.currentType.meta.includes) {
                    for (var ic = 0; ic < $scope.currentType.meta.includes.length; ic++) {
                        $scope.includesAvailable.push($scope.currentType.meta.includes[ic].id);
                    }
                }
                var dtColumns = [];
                for (var fi = 0; fi < $scope.currentType.meta.fields.length; fi++) {
                    var field = $scope.currentType.meta.fields[fi];
                    if (field.properties.relation) continue;
                    var finfo = metaService.fieldIsSortableSearchableVisible(field);
                    field.isVisible = finfo[2];
                    field.displayName = utilService.toSplitTitleCase(field.id);
                    $scope.currentTypeGridFields.push(field);
                    dtColumns.push({ "bSortable": finfo[0], "bSearchable": finfo[1], "bVisible": finfo[2] });
                }
                if ($scope.typeCollectionSlug == "entities")
                    dtColumns.push({ "bSortable": false, "bSearchable": false });
                $scope.dtAjaxColumns = dtColumns;
                $scope.currentTypeLoaded = true;
                $scope.dtReadyForInit = $scope.dtReadyForInit + 1;
            }, function (errorMessage) { $scope.error = errorMessage; });
    };

    //Show / Hide a Column (call this from within template)
    $scope.dtToggleColumnIndex = ""; //bind this to datatable directive attribute for immediate datagrid refresh
    $scope.showHideColumn = function ($event, iColIdx) {
        var checkbox = $event.target;
        var action = (checkbox.checked ? 'add' : 'remove');
        $scope.dtToggleColumnIndex = iColIdx + "," + action;
    };
    //Determine if a column is visible (call this from within template)
    $scope.fieldIsVisible = function (field) { return metaService.fieldIsSortableSearchableVisible(field)[2]; };

    $scope.showRelatedCount = function () {
        var s = {};
        if ($scope.filter.length > 0) s.filter = $scope.filter;
        if (!$scope.showingRelatedCount) {
            if ($scope.includesAvailable.length > 0) s.include = $scope.includesAvailable;
        }
        $location.search(s).path('/' + $scope.typeCollectionSlug + '/' + $scope.typeSlug);
    };

    //jQuery DataTable Related Methods
    $scope.dtAddEditItem = function (ae) {
        $scope.error = null;
        $scope.modalError = null;
        $scope.modalTitle = ae + ' ' + $scope.splitTitleCase($scope.currentType.name);
        $scope.modalAction = '/' + $scope.typeSlug;
        if ($scope.dtSelectedRowData != null && ae == 'Edit') {
            $scope.modalAction += '/' + typeService.buildPkString($scope.dtSelectedRowData, $scope.currentType.meta.fields) + '/update';
            //populate form with actual data from db (row data may not be fully populated)
            typeService
                .fetchItem($scope.dtSelectedRowData, $scope.typeSlug, $scope.currentType.meta.fields)
                .then(
                    function (data) { $scope.dtShowAddEditItemModal(data); },
                    function (error) { $scope.error = error; });
        } else {
            $scope.dtShowAddEditItemModal(null);
        }
    };
    $scope.dtShowAddEditItemModal = function (data) {
        $scope.selectedEntity = data;
        $scope.dtRedrawAddEdit = $scope.dtRedrawAddEdit + 1; //forces refresh of form fields
        $("#addEditItemModal").modal('show');
        $("#btnSubmitAddEditForm").click(function () {/*event.preventDefault();*/ $scope.dtDoAddEditItem(); return false; });
    };
    $scope.dtDoAddEditItem = function () {
        // Use the form plugin
        var $form = $('#addEditItemForm');
        var $target = $($form.attr('data-target'));
        var options = {
            // ajax options
            type: $form.attr('method'),
            url: $scope.modalAction /*prevent default submit behavior in angular by omitting the action attribute: $form.attr('action')*/,
            dataType: 'json',
            target: $target,
            timeout: 600000,
            success: function (data) {
                $target.modal('hide');
                $scope.$apply(function () {
                    $scope.dtRedraw = $scope.dtRedraw + 1;
                });
            },
            error: function (xhr, desc, exceptionobj) {
                var errors = utilService.errorMessages(xhr, desc, exceptionobj);
                $scope.$apply(function () {
                    $scope.modalError = '<ul><li>' + errors.join('</li><li>') + '</li></ul>';
                });
            }
        };
        $form.ajaxSubmit(options);
    }
    $scope.dtDeleteItem = function () {
        $scope.error = null;
        typeService.deleteItem($scope.dtSelectedRowData, $scope.typeSlug, $scope.currentType.meta.fields).then(function () {
            $scope.dtDeletedEntity = $scope.dtSelectedRowData;
            $scope.dtSelectedRowData = null;
            $scope.selectedEntity = null;
        },
        function (errorMessage) { $scope.error = errorMessage; });
    };

    // DataTable Directive Variables
    $scope.dtInitComplete = function (settings) {
        settings.oLanguage.sZeroRecords = "No matching records found";
        return settings;
    };
    $scope.dtDrawCallback = function (settings) {
        $("#entity-grid").width("100%");
        return settings;
    };
    $scope.dtRowCallback = function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
        // rewrite href to match angular spa format
        $('td:last a', nRow).each(function () {
            var href = $(this).attr("href");
            if (href && href.length > 0) {
                $(this).attr("href", '/#/entities' + href);
            };
        });

        $(nRow).bind('click', function () {
            $scope.$apply(function () {
                var r = $(nRow);
                var isSelected = r.hasClass('entity-selected');
                if (isSelected) {
                    $scope.editEnabled = false;
                    $scope.deleteEnabled = false;
                    r.removeClass('entity-selected');
                    $scope.dtSelectedRowData = null;
                }
                else {
                    r.parent().find('tr.entity-selected').removeClass('entity-selected');
                    $scope.editEnabled = true;
                    $scope.deleteEnabled = true;
                    r.addClass('entity-selected');
                    $scope.dtSelectedRowData = aData;
                }
            });
        });
        return nRow;
    };
    $scope.dtServerParams = function (aoData) {
        var iSelectColumns = [];
        if ($scope.dtFirstLoad) {
            //on first load, use grid fields to initialize datatable
            for (var i = 0; i < $scope.currentTypeGridFields.length; i++) {
                var f = $scope.currentTypeGridFields[i];
                if (f.isVisible) {
                    iSelectColumns.push(f.properties.index);
                }
            }
            $scope.dtFirstLoad = false;
        } else {
            $("#dt_d_nav li:not(:last-child) input:checked").each(function () {
                iSelectColumns.push($(this).attr("value"));
            });
        }
        aoData.push({ "name": "iSelectColumns", "value": iSelectColumns });
    };
    $scope.dtOverrideOptions = {
        "sDom": "<'row'<'span6'l><'span6'f>r>t<'row'<'span6'i><'span6'p>>",
        "sPaginationType": "bootstrap",
        "oLanguage": { "sZeroRecord": "Please wait - fetching data", "sLengthMenu": "_MENU_ records per page" },
        "sAjaxSource": $scope.dtBuildAjaxUrl(),
        "bProcessing": false,
        "bServerSide": true,
        "bAutoWidth": true,
        "sServerMethod": "POST"
    };
});
