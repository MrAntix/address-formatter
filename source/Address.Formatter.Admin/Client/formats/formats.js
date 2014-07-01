'use strict';

angular.module('formatsModule', [
    'formatsServiceModule',
    'formatsListDirectiveModule',
    'formatsEditDirectiveModule',
    'formatsPreviewDirectiveModule',
    'formatsCountriesServiceModule'
])
    .directive(
        'formats',
        [
            function() {

                return {
                    restrict: 'A',
                    replace: false,
                    templateUrl: '/Client/formats/formats.cshtml',
                    controller: 'FormatsController'
                };
            }
        ])
    .controller(
        'FormatsController',
        [
            '$log', '$scope', '$timeout', '$filter',
            'FormatsService', 'FormatsCountriesService',
            function(
                $log, $scope, $timeout, $filter,
                FormatsService, FormatsCountriesService) {

                var timeoutId;

                $scope.select = function(format) {
                    $log.debug('FormatsController.select ' + format.id);

                    $scope.show = false;
                    $scope.selected = format;
                    $scope.show = true;

                    $scope.selectElement(null);
                };

                $scope.selectElement = function(element) {
                    $log.debug('FormatsController.selectElement');

                    if ($scope.selectedElement == element)
                        element = null;

                    if ($scope.selectedElement)
                        $scope.selectedElement.isSelected = false;

                    $scope.selectedElement = element;
                    if ($scope.selectedElement)
                        $scope.selectedElement.isSelected = true;
                };

                $scope.add = function() {
                    $log.debug('FormatsController.add');
                    var self = this;

                    var newItem = findById(0);

                    if (newItem) self.select(newItem);
                    else {
                        FormatsService.get({ id: 0 },
                            function(data) {
                                data.display = "(new)";

                                $scope.formats.push(data);
                                $scope.formats.sort();
                                self.select(data);
                            });
                    }
                };

                $scope.delete = function(format) {
                    $log.debug('FormatsController.delete ' + format.id);

                    FormatsService.delete({ id: format.id }, function() {

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

                $scope.drop = function(element, line, before) {
                    $log.debug('FormatsController.drop');

                    var list = line.elements = line.elements || [];

                    if (before) {
                        list.splice(list.indexOf(before), 0, element);
                    } else {
                        list.push(element);
                    }

                    $scope.save($scope.selected);
                };

                $scope.removeFrom = function(element, list) {
                    $log.debug('FormatsController.remove');

                    list.splice(list.indexOf(element), 1);

                    $scope.save($scope.selected);
                };

                $scope.selectCountry = function(country) {
                    $scope.selected.countries.push(country);
                    $scope.removeFrom(country, $scope.countries);
                };

                $scope.deselectCountry = function(country) {
                    $scope.countries.push(country);
                    $scope.removeFrom(country, $scope.selected.countries);
                };

                $scope.clearElement = function(element, list) {
                    $log.debug('FormatsController.clearElement');

                    $scope.removeFrom(element, list);
                    $scope.selected.allElements.push(element);

                    $scope.save($scope.selected);
                };

                $scope.save = function(format) {
                    $log.debug('FormatsController.save ' + format.id);

                    if (timeoutId) {
                        $timeout.cancel(timeoutId);
                    }

                    timeoutId = $timeout(function() {
                        FormatsService.save(format, function(data) {
                            format.id = data.id;

                            $scope.$broadcast('FormatSavedEvent');
                        });
                    }, 500);
                };

                var findById = function(id) {
                    var results = $filter('filter')($scope.formats, function(item) { return item.id == id; });
                    return results.length ? results[0] : null;
                };

                FormatsService.query(function(data) {
                    $scope.formats = data;
                    if ($scope.formats.length > 0) {
                        $scope.select($scope.formats[0]);
                    }
                });

                $scope.countries = FormatsCountriesService.query({ availableOnly: true });
                $scope.selectCountries = false;
            }
        ])
    .filter('formatDisplay', function() {
        return function(item) {
            return item.countries
                .map(function(c) { return c.name; })
                .join(', ')
                || "(default)";
        };
    })
    .filter('html', ['$sce', function($sce) {
        return function(item) {
            return item
                ? $sce.trustAsHtml(item.replace('\n', '<br/>').replace(/\s/g, '&nbsp;'))
                : null;
        };
    }])
    .filter('formatAddress', ['$sce', function($sce) {
        return function (address, format) {
            var e = function (v) { return v ? v : ''; };

            var output =
                format.lines.map(function (line) {
                    if (line.elements.length == 0) return ' ';

                    var text = e(line.prefix).concat(
                        line.elements.map(function(element) {
                            var value = e(address[element.name]);
                            if (value.trim().length == 0) return '';

                            return e(element.prefix).concat(
                                e(address[element.name]),
                                e(element.suffix)
                            );
                        }).join(e(line.elementSeparator)),
                        e(line.suffix)
                    );
                    
                    return text.trim();
                })
                    .filter(function(v) {
                        return v && v.length;
                    }).join('\n').trim();

            return $sce.trustAsHtml(
                output.replace(/\n/g, '<br/>')
                    .replace(/\s/g, '&nbsp;')
            );
        };
    }]);