'use strict';

angular.module('formatsEditDirectiveModule', [
    'ngDragDrop'
])
    .directive(
        'formatsEdit',
        [
            '$log',
            function ($log) {

                return {
                    restrict: 'A',
                    replace: false,
                    templateUrl: '/Client/formats/formats-edit.cshtml',
                    controller: 'FormatsEditController',
                    link: function (scope) {

                        scope.drop = function (element, line) {
                            $log.debug('drop ' + JSON.stringify(element));

                            line.elements = line.elements || [];
                            line.elements.push(element);
                        };

                        scope.remove = function (element, list) {
                            list.splice(list.indexOf(element), 1);
                        };
                        scope.clear = function (element, list) {
                            scope.remove(element, list);
                            scope.$parent.selected.allElements.push(element);
                        };
                    }
                };
            }
        ])
    .controller(
        'FormatsEditController',
        [
            '$scope', 'FormatsService',
            function ($scope, FormatsService) {

               // $scope.items = FormatsService.query();

            }]);