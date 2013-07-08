//pluralize.min.js
if(typeof owl==="undefined"){owl={};}owl.pluralize=(function(){var c={};function f(i,h){if(h.match(/^[A-Z]/)){return i.charAt(0).toUpperCase()+i.slice(1);}else{return i;}}function e(l){l=l.split(",");var j=l.length;var k={};for(var h=0;h<j;h++){k[l[h]]=1;}return k;}var g=e("aircraft,advice,blues,corn,molasses,equipment,gold,information,cotton,jewelry,kin,legislation,luck,luggage,moose,music,offspring,rice,silver,trousers,wheat,bison,bream,breeches,britches,carp,chassis,clippers,cod,contretemps,corps,debris,diabetes,djinn,eland,elk,flounder,gallows,graffiti,headquarters,herpes,high,homework,innings,jackanapes,mackerel,measles,mews,mumps,news,pincers,pliers,proceedings,rabies,salmon,scissors,sea,series,shears,species,swine,trout,tuna,whiting,wildebeest,pike,oats,tongs,dregs,snuffers,victuals,tweezers,vespers,pinchers,bellows,cattle");var a={I:"we",you:"you",he:"they",it:"they",me:"us",you:"you",him:"them",them:"them",myself:"ourselves",yourself:"yourselves",himself:"themselves",herself:"themselves",itself:"themselves",themself:"themselves",oneself:"oneselves",child:"children",dwarf:"dwarfs",mongoose:"mongooses",mythos:"mythoi",ox:"oxen",soliloquy:"soliloquies",trilby:"trilbys",person:"people",forum:"forums",syllabus:"syllabi",alumnus:"alumni",genus:"genera",viscus:"viscera",stigma:"stigmata"};var b=[[/man$/i,"men"],[/([lm])ouse$/i,"$1ice"],[/tooth$/i,"teeth"],[/goose$/i,"geese"],[/foot$/i,"feet"],[/zoon$/i,"zoa"],[/([tcsx])is$/i,"$1es"],[/ix$/i,"ices"],[/^(cod|mur|sil|vert)ex$/i,"$1ices"],[/^(agend|addend|memorand|millenni|dat|extrem|bacteri|desiderat|strat|candelabr|errat|ov|symposi)um$/i,"$1a"],[/^(apheli|hyperbat|periheli|asyndet|noumen|phenomen|criteri|organ|prolegomen|\w+hedr)on$/i,"$1a"],[/^(alumn|alg|vertebr)a$/i,"$1ae"],[/([cs]h|ss|x)$/i,"$1es"],[/([aeo]l|[^d]ea|ar)f$/i,"$1ves"],[/([nlw]i)fe$/i,"$1ves"],[/([aeiou])y$/i,"$1ys"],[/(^[A-Z][a-z]*)y$/,"$1ys"],[/y$/i,"ies"],[/([aeiou])o$/i,"$1os"],[/^(pian|portic|albin|generalissim|manifest|archipelag|ghett|medic|armadill|guan|octav|command|infern|phot|ditt|jumb|pr|dynam|ling|quart|embry|lumbag|rhin|fiasc|magnet|styl|alt|contralt|sopran|bass|crescend|temp|cant|sol|kimon)o$/i,"$1os"],[/o$/i,"oes"],[/s$/i,"ses"]];function d(n,k,h){if(n===""){return"";}if(k===1){return n;}if(typeof h==="string"){return h;}var l=n.toLowerCase();if(l in c){return f(c[l],n);}if(n.match(/^[A-Z]$/)){return n+"'s";}if(n.match(/fish$|ois$|sheep$|deer$|pox$|itis$/i)){return n;}if(n.match(/^[A-Z][a-z]*ese$/)){return n;}if(l in g){return n;}if(l in a){return f(a[l],n);}var o=b.length;for(var j=0;j<o;j++){var m=b[j];if(n.match(m[0])){return n.replace(m[0],m[1]);}}return n+"s";}d.define=function(i,h){c[i.toLowerCase()]=h;};return d;})();

var app = angular.module('northwindApp', ['$strap.directives'])
	.controller('AppCtrl', function($scope,$location,$route,$routeParams) {
		$scope.name = 'AppScope';
		$scope.location = $location;
		$scope.route = $route;
		$scope.routeParams = $routeParams;
		$scope.theme = 'spa';
		$scope.blogUrl = 'http://www.mattjcowan.com/funcoding/2013/03/10/rest-api-with-llblgen-and-servicestack/';

		//**********************************
		//app scoped functions
		//**********************************
		$scope.capitalize = function(str){return str.replace(/^./, function (char) {return char.toUpperCase();});};
		//pluralize/singularize (first setup edge cases)
		owl.pluralize.define("demo", "demos");
		owl.pluralize.define("category", "categories");
		owl.pluralize.define("territory", "territories");
		$scope.pluralize = function(str){if(!str){return '';} return owl.pluralize(str);}
		$scope.singularize = function(str){if(!str){return '';} return owl.pluralize(str,1);}
		//string functions
		$scope.removeSpaces = function(str){if(!str){return '';} return str.split(' ').join('');};
		$scope.splitTitleCase = function(str){ if(!str){return '';} return str.replace(/([a-z])([A-Z]|[0-9])/g, '$1 $2'); };
		$scope.splitTitleCaseAndPluralize = function(str){if(!str){return '';} var tc = $scope.splitTitleCase(str).split(' '); tc[tc.length-1]=$scope.pluralize(tc[tc.length-1]); return tc.join(' '); };
		//toTitleCase: https://github.com/gouch/to-title-case/blob/master/to-title-case.js (minified with yui)
		$scope.toTitleCase = function(str){if(!str){return '';} var a=/^(a|an|and|as|at|but|by|en|for|if|in|of|on|or|the|to|vs?\.?|via)$/i;var str2 = str.replace(/([^\W_]+[^\s-]*) */g,function(c,e,b,d){if(b>0&&b+e.length!==d.length&&e.search(a)>-1&&d.charAt(b-2)!==":"&&d.charAt(b-1).search(/[^\s-]/)<0){return c.toLowerCase();}if(e.substr(1).search(/[A-Z]|\../)>-1){return c;}return c.charAt(0).toUpperCase()+c.substr(1);}); return $scope.capitalize(str2);};
		$scope.toSplitTitleCase = function(str){if(!str){return '';} return $scope.splitTitleCase($scope.toTitleCase(str));};
		//switch themes
		$scope.changeTheme = function(theme){if(!theme){return;} $.cookie('Theme', theme); window.location = '/'; };
		//path functions
		$scope.isPath = function (path) {return (path && $location.path().substr(0, path.length) == path);};
	});

//routes
app.config(function ($routeProvider) {
    $routeProvider
        .when('/', { templateUrl: '/app/partials/home.tpl.html' })
        .when('/:typeCollectionSlug',
        	{
				controller: 'TypeCollectionController',
				templateUrl: '/app/partials/types.tpl.html'
			})
        .when('/:typeCollectionSlug/:typeSlug',
            {
                controller: 'TypeController',
                templateUrl: '/app/partials/type.tpl.html'
            })
        .otherwise({ redirectTo: '/' });
});
