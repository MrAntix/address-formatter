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
                    link: function (scope, el, a, controller) {

                        scope.drop = function (element, line, before) {
                            $log.debug('drop');

                            var list = line.elements = line.elements || [];

                            if (before) {
                                list.splice(list.indexOf(before), 0, element);
                            } else {
                                list.push(element);
                            }

                            controller.raiseEdit(scope.$parent.selected);
                        };

                        scope.remove = function (element, list) {
                            $log.debug('remove');

                            list.splice(list.indexOf(element), 1);

                            controller.raiseEdit(scope.$parent.selected);
                        };

                        scope.clear = function (element, list) {
                            $log.debug('clear');

                            scope.remove(element, list);
                            scope.$parent.selected.allElements.push(element);

                            controller.raiseEdit(scope.$parent.selected);
                        };

                        scope.delete = function () {
                            controller.raiseDelete(scope.$parent.selected);
                        };
                    }
                };
            }
        ])
    .controller(
        'FormatsEditController',
        [
            '$log', '$scope',
            function ($log, $scope) {

                this.raiseEdit = function (format) {
                    $log.debug('FormatsEditController.raiseEdit');

                    $scope.$emit(
                        'FormatEditEvent', format
                    );
                };

                this.raiseDelete = function (format) {
                    $log.debug('FormatsEditController.raiseDelete');

                    $scope.$emit(
                        'FormatDeleteEvent', format
                    );
                };

                $scope.$on('FormatDeletedEvent', function (e, format) {
                    $log.debug('FormatsEditController.FormatDeletedEvent ' + format.id);

                    if ($scope.$parent.selected == format)
                        $scope.$parent.selected = null;
                });

            }]);