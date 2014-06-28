'use strict';

angular.module('formatsEditDirectiveModule', [
    'ngDragDrop'
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