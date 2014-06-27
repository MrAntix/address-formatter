'use strict';

angular.module('formatsModule', [
    'formatsServiceModule',
    'formatsListDirectiveModule',
    'formatsEditDirectiveModule'
])
    .controller(
        'formatsController',
        [
            '$scope',
            function($scope) {

            }
        ]);