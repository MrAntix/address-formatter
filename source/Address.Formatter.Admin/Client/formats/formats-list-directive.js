'use strict';

angular.module('formatsListDirectiveModule', [
])
    .directive(
        'formatsList',
        [
            function() {

                return {
                    restrict: 'A',
                    replace: false,
                    templateUrl: '/Client/formats/formats-list.html',
                    controller: 'FormatsListController',
                    link: function(scope, element, attrs, controller) {

                        scope.select = function(item) {
                            controller.select(item);
                        };

                        scope.add = function() {
                            controller.add();
                        };
                    }
                };
            }
        ])
    .controller(
        'FormatsListController',
        [
            '$log', '$scope', '$timeout', '$filter', 'FormatsService',
            function($log, $scope, $timeout, $filter, FormatsService) {

                $scope.items = FormatsService.query();

                this.select = function(item) {
                    $log.debug('FormatsListController.select ' + item.id);

                    $scope.$parent.selected = null;

                    $timeout(function() {
                        $scope.$parent.selected = item;
                    }, 250);
                };

                this.add = function () {
                    var self = this;

                    var newItem = findById(0);

                    if (newItem) self.select(newItem);
                    else {
                        FormatsService.get({ id: 0 },
                            function(data) {
                                data.display = "(new)";

                                $scope.items.push(data);
                                self.select(data);
                            });
                    }
                };

                var findById = function(id) {
                    var results = $filter('filter')($scope.items, function (item) { return item.id == id; });
                    return results.length ? results[0] : null;
                };

                $scope.$on('FormatDeletedEvent', function(e, format) {
                    $log.debug('FormatsListController.FormatDeletedEvent ' + format.id);

                    var index = $scope.items.indexOf(format);
                    if (index > -1) {
                        $scope.items.splice(index, 1);
                        $scope.$parent.selected = $scope.items[index];
                    }
                });

            }]);