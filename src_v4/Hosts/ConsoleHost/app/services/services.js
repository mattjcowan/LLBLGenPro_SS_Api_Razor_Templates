app.factory('metaService', function($http, $q){
    return {
        getTypeCollection: function(typeCollectionSlug){
            var deferred = $q.defer();
            var metaUrl = '/' + typeCollectionSlug;
            $http
                .get(metaUrl)
                .success(function(data){deferred.resolve(data.result);})
                .error(function(){deferred.reject("An error occured while fetching " + metaUrl);});
            return deferred.promise;
        },
        getType: function(typeCollectionSlug, typeSlug){
            var deferred = $q.defer();
            var metaUrl = (typeCollectionSlug == 'entities' ? '': ('/' + typeCollectionSlug)) + '/' + typeSlug + '/meta';
            $http
                .get(metaUrl)
                .success(function(data){deferred.resolve(data);})
                .error(function(){deferred.reject("An error occured while fetching metadata for " + metaUrl);});
            return deferred.promise;
        },
        //returns array: [sortable, searchable, visible]
        fieldIsSortableSearchableVisible:  function(field){
            if(field.type == 'String') { var ml=parseInt(field.properties.maxLength); return [ml<255, ml<1000, ml<128 && !field.properties.isNullable]; }
            else if(field.type == 'Int32') { return [true, true, !field.properties.isNullable]; }
            else { return [false, false, false]; }
        }
    };
});

app.factory('typeService', function($http, $q){
    return {
        fetchItem: function(rowData, typeSlug, fields){
            var pkUrl = this.buildPkString(rowData, fields);
            var deferred = $q.defer();
            $http
                .get('/'+typeSlug+'/'+pkUrl)
                .success(function(data){deferred.resolve(data.result);})
                .error(function(e,s,d){
                    var message = 'Unable to fetch item at ' + '/'+ typeSlug + '/' +pkUrl;
                    deferred.reject(message)});
            return deferred.promise;
        },
        deleteItem: function(rowData, typeSlug, fields){
            var pkUrl = this.buildPkString(rowData, fields);
            var deferred = $q.defer();
            $http
                .post('/'+typeSlug+'/'+pkUrl+'/delete')
                .success(function(data){deferred.resolve(data);})
                .error(function(e,s,d){
                    var message = (e && e.length>0) ? e: (s == 401 ? "Sorry, you're not authorized to delete items.": "An error occured while attempting to delete this item");
                    deferred.reject(message)});
            return deferred.promise;
        },
        buildPkString: function(rowData, fields){
            var pks = [];
            for(var fi=0;fi<fields.length;fi++){
              var f = fields[fi];
              var fp = f.properties;
              if(fp.isPrimaryKey){
                var fpidx = fp['index'];
                pks.push(rowData[fpidx]);
              }
            }
            return pks.join('/');
        }
    };
});

app.factory('utilService', function($http, $q){

    //pluralize/singularize (first setup edge cases)
    owl.pluralize.define("demo", "demos");
    owl.pluralize.define("category", "categories");
    owl.pluralize.define("territory", "territories");

    return {
        //StringService(s)
        capitalize: function(str){return str.replace(/^./, function (char) {return char.toUpperCase();});},
        pluralize: function(str){if(!str){return '';} return owl.pluralize(str);},
        singularize: function(str){if(!str){return '';} return owl.pluralize(str,1);},
        //string functions
        removeSpaces: function(str){if(!str){return '';} return str.split(' ').join('');},
        splitTitleCase: function(str){ if(!str){return '';} return str.replace(/([a-z])([A-Z]|[0-9])/g, '$1 $2'); },
        splitTitleCaseAndPluralize: function(str){if(!str){return '';} var tc = this.splitTitleCase(str).split(' '); tc[tc.length-1]=this.pluralize(tc[tc.length-1]); return tc.join(' '); },
        //toTitleCase: https://github.com/gouch/to-title-case/blob/master/to-title-case.js (minified with yui)
        toTitleCase: function(str){if(!str){return '';} var a=/^(a|an|and|as|at|but|by|en|for|if|in|of|on|or|the|to|vs?\.?|via)$/i;var str2 = str.replace(/([^\W_]+[^\s-]*) */g,function(c,e,b,d){if(b>0&&b+e.length!==d.length&&e.search(a)>-1&&d.charAt(b-2)!==":"&&d.charAt(b-1).search(/[^\s-]/)<0){return c.toLowerCase();}if(e.substr(1).search(/[A-Z]|\../)>-1){return c;}return c.charAt(0).toUpperCase()+c.substr(1);}); return this.capitalize(str2);},
        toSplitTitleCase: function(str){if(!str){return '';} return this.splitTitleCase(this.toTitleCase(str));},
        //switch themes
        changeTheme: function(theme){if(!theme){return;} $.cookie('Theme', theme); window.location = '/'; },

        //ServiceStack Utility Service Calls
        //From: https://github.com/ServiceStack/ServiceStack/blob/master/release/latest/js/JsonServiceClient.js
        errorMessages: function(xhr, desc, exceptionobj) {
            var errors = [];
            try{
                var response = this.parseJSON(xhr.responseText);
                var status = this.parseResponseStatus(response);
                if(status.message && status.message.length>0){
                    errors.push(status.message);
                }
                if(status.fieldErrors && status.fieldErrors.length>0){
                    for (var i = 0, len = status.fieldErrors.length; i < len; i++) {
                        var errMessage = status.fieldErrors[i].errMessage;
                        errors.push(errMessage);
                    }
                }
            }
            catch(e){}
            if(errors.length==0){
                errors.push(xhr.responseText ? xhr.responseText: (desc ? desc: 'Unknown error'));
            }
            return errors;
        },
        parseJSON: function(json) {
            if (typeof (JSON) == 'object' && JSON.parse)
                return JSON.parse(json);
            if ($ && $.parseJSON)
                return $.parseJSON(json);
            if (goog && goog.json)
                return goog.json.parse(json);
            throw "no json parser found";
        },
        parseResponseStatus: function(status) {

            //ResponseStatus class
            //https://github.com/ServiceStack/ServiceStack/blob/master/src/ServiceStack.Interfaces/ServiceInterface.ServiceModel/ResponseStatus.cs

            if (!status) return { isSuccess: true };

            var result =
            {
                isSuccess: status.errorCode === undefined || status.errorCode === null,
                errorCode: status.errorCode,
                message: status.message,
                errorMessage: status.errorMessage,
                stackTrace: status.stackTrace,
                fieldErrors: [],
                fieldErrorMap: {}
            };

            if (status.errors) {
                for (var i = 0, len = status.errors.length; i < len; i++) {

                    //ResponseError class
                    //https://github.com/ServiceStack/ServiceStack/blob/master/src/ServiceStack.Interfaces/ServiceInterface.ServiceModel/ResponseError.cs

                    var err = status.errors[i];
                    var error = { errorCode: err.errorCode, fieldName: err.fieldName, errorMessage: err.message || '' };
                    result.fieldErrors.push(error);

                    if (error.fieldName) {
                        result.fieldErrorMap[error.fieldName] = error;
                    }
                }
            }

            return result;
        }
    };
});
