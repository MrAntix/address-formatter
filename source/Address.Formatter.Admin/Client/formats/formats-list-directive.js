'use strict';

angular.module('formatsListDirectiveModule', [
])
    .directive(
        'formatsList',
        [
            function () {

                return {
                    restrict: 'A',
                    replace: false,
                    templateUrl: '/Client/formats/formats-list.cshtml'
                };
            }
        ]);

