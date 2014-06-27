'use strict';

angular.module('formatsListDirectiveModule', [
])
    .directive(
        'formatsList',
        [
            '$log',
            function ($log) {

                return {
                    restrict: 'A',
                    replace: false,
                    templateUrl: '/Client/formats/formats-list.html',
                    controller: 'FormatsListController',
                    link: function (scope, element) {

                        scope.select = function(item) {
                            $log.debug('select ' + JSON.stringify(item));
                            scope.$parent.selected = item;
                        };

                    }
                };
            }
        ])
    .controller(
        'FormatsListController',
        [
            '$scope', 'FormatsService',
            function ($scope, FormatsService) {

                $scope.items = FormatsService.query();

            }]);