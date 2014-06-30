'use strict';

angular.module('formatsPreviewDirectiveModule', [
])
    .directive(
        'formatsPreview',
        [
            function() {

                return {
                    restrict: 'A',
                    replace: false,
                    templateUrl: '/Client/formats/formats-preview.cshtml',
                    scope: {
                        format: '=formatsPreview'
                    },
                    link: function(scope) {
                        scope.address = {
                            PersonName: 'Mr Henry Chap',
                            CompanyName: 'Grenwald and Featherby',
                            Line1: 'The Street',
                            City: 'Basildon',
                            State: 'Essex',
                            PostalCode: 'AB1 1AB',
                            CountryName: 'United Kingdom',
                            CountryCode: 'GB'
                        };
                    }
                };
            }
        ]);