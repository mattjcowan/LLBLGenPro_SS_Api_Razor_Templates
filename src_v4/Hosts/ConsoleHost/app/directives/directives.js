/* START LAZYSTYLE DIRECTIVE */
app.directive('lazyStyle', function() {
    var loadedStyles = {};
    return {
      restrict: 'E',
      link: function (scope, element, attrs) {

        attrs.$observe('href', function (value) {

          var stylePath = value;

          if (stylePath in loadedStyles) {
            return;
          }

          if (document.createStyleSheet) {
            document.createStyleSheet(stylePath); //IE
          } else {
            var link = document.createElement("link");
            link.type = "text/css";
            link.rel = "stylesheet";
            link.href = stylePath;
            document.getElementsByTagName("head")[0].appendChild(link);
          }

          loadedStyles[stylePath] = true;

        });
      }
    };
});

app.directive('rowSelected', function() {
    return {
      restrict: 'A',
      link: function (scope, element, attrs) {

        attrs.$observe('rowSelected', function (value) {

          if(!value || value == null) {
              if(!element.attr("disabled")) element.attr("disabled", "disabled");
              if(!element.hasClass("disabled")) element.addClass("disabled");
          } else {
              if(element.attr("disabled")) element.removeAttr("disabled", "disabled");
              if(element.hasClass("disabled")) element.removeClass("disabled");
          }

        });
      }
    };
});

app.directive('formData', function() {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {

            attrs.$observe('formDrawCount', function (value) {
                if(value == 0) return;

                var entityValue = attrs.formData && attrs.formData.length > 0 ? JSON.parse(attrs.formData): null;
                var entity = entityValue || null;
                var blank = !entity;

                var fields = JSON.parse(attrs.formFields);
    
                //populate control fields with the values from the entity
                element.find('.input-file').each(function(){
                    $(this).wrap('<form>').closest('form').get(0).reset();
                    $(this).unwrap();
                });
                element.find('.clear-on-addedit').val('');
                for(var i=0;i<fields.length;i++){
                    var field = fields[i];
                    element.find('.f-' + field.id).val(blank ? '': entity[field.id]);
                }
            });
        }
    }
});

app.directive('formControl', function() {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {

            attrs.$observe('formControl', function (value) {

                var field = (value.constructor === String) ? JSON.parse(value): value;
                if(!field || field == null)
                    return;

                //var fieldLabel = attrs.fieldLabel === undefined ? field.id: attrs.fieldLabel;
                element.parent().addClass('control-group');
                var label = $('<label></label>').addClass('control-label').attr('for', field.id);
                label.text(field.displayName);
                label.insertBefore(element);
                element.addClass('controls');

                if(field.type == 'String' && field.properties.maxLength > 128) {
                //textarea control
                /*
                  <div class="control-group">
                      <label class="control-label" for="description">Description</label>
                      <div class="controls">
                          <div class="textarea">
                              <textarea id="description" name="description" type="" class="input-xlarge" maxlength="1073741823"></textarea>
                          </div>
                      </div>
                  </div>                
                 */
                    var dt = $('<div/>').addClass('textarea');
                    var textarea = $('<textarea></textarea>').attr('id', field.id).attr('name', field.id).addClass('input-xlarge').attr('maxlength', field.properties.maxLength)
                                                             .addClass('f-'+field.id);
                    textarea.appendTo(dt);
                    dt.appendTo(element);
                } 
                else if (/*field.properties.isPrimaryKey && */ field.properties.isReadOnly) {
                //primarykey and readonly control
                //readonly fields require hidden fields because disabled fields do not send their data in form posts
                /*
                  <div class="control-group">
                      <label class="control-label" for="discategoryid">Category Id</label>
                      <div class="controls">
                          <input type="text" id="discategoryid" name="discategoryid" placeholder="&lt; read only &gt;" disabled="disabled" class="input-xlarge disabled">
                          <input type="hidden" id="categoryid" name="categoryid" />
                          <p class="help-block"></p>
                      </div>
                  </div>
                 */
                    var input = $('<input />').attr('type','text').attr('id', 'dis'+field.id).attr('name', 'dis'+field.id).attr('placeholder','-- read only --').attr('disabled','disabled')
                                              .addClass('input-xlarge').addClass('disabled')
                                              .addClass('f-'+field.id);
                    var input2 = $('<input />').attr('type','hidden').attr('id', field.id+'srcpath').attr('name', field.id+'srcpath')
                                               .addClass('f-'+field.id);
                    input.appendTo(element);
                    input2.appendTo(element);
                } 
                else if (field.type == 'Byte[]') {
                //byte[] control (file input)
                /*
                  <div class="control-group">
                      <label class="control-label" for="picture">Picture</label>
                      <div class="controls">
                          <input type="file" id="picture" name="picture" class="input-file" onchange="$('#picturesrcpath').val($(this).val());">
                          <input type="hidden" id="picturesrcpath" name="picturesrcpath" />
                          <p class="help-block"></p>
                      </div>
                  </div>
                 */                  
                    var input = $('<input />').attr('type','file').attr('id', field.id).attr('name', field.id).addClass('input-file');
                    var input2 = $('<input />').attr('type','hidden').attr('id', field.id+'srcpath').attr('name', field.id+'srcpath').addClass('clear-on-addedit');
                    input.appendTo(element);
                    input2.appendTo(element);
                    input.change(function() { input2.val($(this).val()); });
                } 
                else {
                //input control
                /*
                  <div class="control-group">
                      <label class="control-label" for="categoryname">Category Name</label>
                      <div class="controls">
                          <div class="textarea">
                              <input type="text" id="categoryname" name="categoryname" placeholder="" class="input-xlarge" maxlength="15">
                          </div>
                      </div>
                  </div>
                 */
                    var dt = $('<div/>').addClass('textarea');                    
                    var input = $('<input />').attr('type','text').attr('id', field.id).attr('name', field.id).addClass('input-xlarge').attr('maxlength', field.properties.maxLength)
                                              .addClass('f-'+field.id);
                    input.appendTo(dt);
                    dt.appendTo(element);
                }
            });
        }
    };
});

/* START DATATABLE DIRECTIVE */
app.directive('jsDatatable', function() {

    return function(scope, element, attrs) {

        // apply the plugin
        var dataTable;

        // watch for any changes to our data, rebuild the DataTable
        scope.$watch(attrs.dtReadyForInit, function(value) {

            var val = value || null;
            if (!val) return;

            // apply DataTable options, use defaults if none specified by user
            var options = {};
            if (attrs.jsDatatable.length > 0) {
                options = scope.$eval(attrs.jsDatatable);
            } else {
                options = {
                    "bStateSave": true,
                    "iCookieDuration": 2419200, /* 1 month */
                    "bJQueryUI": true,
                    "bPaginate": false,
                    "bLengthChange": false,
                    "bFilter": false,
                    "bInfo": false,
                    "bDestroy": true
                };
            }

            // Tell the dataTables plugin what columns to use
            if (attrs.aoColumns) {
                if(scope.$eval(attrs.aoColumns).length > 0)
                    options["aoColumns"] = scope.$eval(attrs.aoColumns);
                else
                    return value;
            } else {
                var explicitColumns = [];
                element.find('th').each(function(index, elem) {
                    explicitColumns.push($(elem).text());
                });
                if (explicitColumns.length > 0) {
                    options["aoColumns"] = explicitColumns;
                }
            }

            if (attrs.aoColumnDefs) {
                options["aoColumnDefs"] = scope.$eval(attrs.aoColumnDefs);
            }

            if (attrs.fnInitComplete) {
                options["fnInitComplete"] = scope.$eval(attrs.fnInitComplete);
            }

            if (attrs.fnDrawCallback) {
                options["fnDrawCallback"] = scope.$eval(attrs.fnDrawCallback);
            }

            if (attrs.fnRowCallback) {
                options["fnRowCallback"] = scope.$eval(attrs.fnRowCallback);
            }

            if (attrs.fnServerParams) {
                options["fnServerParams"] = scope.$eval(attrs.fnServerParams);
            }

            dataTable = (!dataTable || dataTable == null) ? element.dataTable(options): dataTable;
            if(attrs.aaData) {
                var d = scope.$eval(attrs.aaData);
                if(d.length > 0) {
                    dataTable.fnClearTable();
                    dataTable.fnAddData(d);
                }
            }

        });

        scope.$watch(attrs.fnToggleCol, function(value){
            var val = value || null;
            if (!val || val == '' || (!dataTable || dataTable == null)) return;
            var val2 = val.split(",");
            var bVis = dataTable.fnSettings().aoColumns[val2[0]].bVisible;
            dataTable.fnSetColumnVis(val2[0], bVis ? false : true);
        });

        scope.$watch(attrs.fnDeleteRow, function(value){
            var val = value || null;
            if (!val || val == '' || (!dataTable || dataTable == null)) return;
            dataTable.fnDeleteRow();
        });

        scope.$watch(attrs.dtDrawCount, function(value){
            var val = value || null;
            if (!val || val == 0 || val == '0') return;
            if(dataTable){
                dataTable.fnDraw(false);
            }
        });
    };
});