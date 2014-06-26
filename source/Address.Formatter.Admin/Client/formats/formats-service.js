'use strict';

angular.module('formatsServiceModule', [
    'ngResource'
])
    .factory(
        'FormatsService',
        [
            '$resource',
            function ($resource) {

                return $resource('/services/formats/', {}, {
                    query: {
                        method: 'GET',
                        isArray: true
                    },
                    get: {
                        requiresAuthorization: true,
                        method: 'GET'
                    },
                    save: {
                        requiresAuthorization: true,
                        method: 'POST'
                    },
                    delete: {
                        requiresAuthorization: true,
                        method: 'DELETE'
                    }
                });
            }
        ]);