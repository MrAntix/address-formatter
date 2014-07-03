'use strict';

angular.module('formatsEditDirectiveModule', [
    'ngDragDrop',
    'confirm'
])
    .directive(
        'formatsEdit',
        [
            function () {

                return {
                    restrict: 'A',
                    replace: false,
                    templateUrl: '/Client/formats/formats-edit.cshtml'
                };
            }
        ]);