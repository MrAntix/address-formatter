'use strict';

angular.module('formatsCountriesServiceModule', [
    'ngResource'
])
    .factory(
        'FormatsCountriesService',
        [
            '$resource',
            function ($resource) {

                return $resource('/services/formats/countries/', {}, {
                    query: {
                        method: 'GET',
                        isArray: true
                    }
                });
            }
        ]);