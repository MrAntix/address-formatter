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
                    link: function(scope, element) {
                        
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