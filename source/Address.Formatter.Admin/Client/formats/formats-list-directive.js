'use strict';

angular.module('formatsListDirectiveModule', [
])
    .directive(
        'formatsList',
        [
            '$log', '$timeout',
            function ($log, $timeout) {

                return {
                    restrict: 'A',
                    replace: false,
                    templateUrl: '/Client/formats/formats-list.html',
                    controller: 'FormatsListController',
                    link: function (scope) {

                        scope.select = function (item) {
                            $log.debug('select ' + JSON.stringify(item));

                            scope.$parent.selected = null;

                            $timeout(function() {
                                scope.$parent.selected = item;
                            },250);
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