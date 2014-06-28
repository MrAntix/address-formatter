'use strict';

angular.module('formatsModule', [
    'formatsServiceModule',
    'formatsListDirectiveModule',
    'formatsEditDirectiveModule',
    'formatsCountriesServiceModule'
])
    .controller(
        'FormatsController',
        [
            '$log', '$scope', '$timeout', '$filter',
            'FormatsService', 'FormatsCountriesService',
            function (
                $log, $scope, $timeout, $filter,
                FormatsService, FormatsCountriesService) {

                var timeoutId;

                $scope.select = function (format) {
                    $log.debug('FormatsController.select ' + format.id);

                    $scope.show = false;
                    $scope.selected = format;
                    $scope.show = true;
                };

                $scope.add = function () {
                    $log.debug('FormatsController.add');
                    var self = this;

                    var newItem = findById(0);

                    if (newItem) self.select(newItem);
                    else {
                        FormatsService.get({ id: 0 },
                            function (data) {
                                data.display = "(new)";

                                $scope.formats.push(data);
                                self.select(data);
                            });
                    }
                };

                $scope.delete = function (format) {
                    $log.debug('FormatsController.delete ' + format.id);

                    FormatsService.delete({ id: format.id }, function () {

                        var index = $scope.formats.indexOf(format);
                        if (index > -1) {
                            $scope.formats.splice(index, 1);

                            if ($scope.formats.length > index)
                                index--;

                            $scope.selected = $scope.formats[index];
                        }

                        $scope.$broadcast('FormatDeletedEvent', format);
                    });
                };

                $scope.drop = function (element, line, before) {
                    $log.debug('drop');

                    var list = line.elements = line.elements || [];

                    if (before) {
                        list.splice(list.indexOf(before), 0, element);
                    } else {
                        list.push(element);
                    }

                    $scope.save($scope.selected);
                };

                $scope.removeFrom = function (element, list) {
                    $log.debug('remove');

                    list.splice(list.indexOf(element), 1);

                    $scope.save($scope.selected);
                };

                $scope.clearElement = function (element, list) {
                    $log.debug('clear');

                    $scope.removeFrom(element, list);
                    $scope.selected.allElements.push(element);

                    $scope.save($scope.selected);
                };


                $scope.save = function (format) {
                    $log.debug('FormatsController.save ' + format.id);

                    if (timeoutId) {
                        $timeout.cancel(timeoutId);
                    }

                    timeoutId = $timeout(function () {
                        FormatsService.save(format, function (data) {
                            format.id = data.id;

                            $scope.$broadcast('FormatSavedEvent');
                        });
                    }, 500);
                };

                var findById = function (id) {
                    var results = $filter('filter')($scope.formats, function (item) { return item.id == id; });
                    return results.length ? results[0] : null;
                };

                FormatsService.query(function(data) {
                    $scope.formats = data;
                    if ($scope.formats.length > 0) {
                        $scope.select($scope.formats[0]);
                    }
                });
                
                $scope.countries = FormatsCountriesService.query({ availableOnly: true });
            }
        ]);