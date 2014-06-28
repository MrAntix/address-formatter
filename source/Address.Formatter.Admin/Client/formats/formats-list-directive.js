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
                    templateUrl: '/Client/formats/formats-list.html'
                };
            }
        ])

    .filter('formatDisplay', function () {
        return function (item) {
            return item.countries
                .map(function (c) { return c.name; })
                .join(', ')
                || "(default)";
        };
    });