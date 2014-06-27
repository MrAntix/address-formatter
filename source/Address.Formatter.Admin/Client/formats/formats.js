'use strict';

angular.module('formatsModule', [
    'formatsServiceModule',
    'formatsListDirectiveModule',
    'formatsEditDirectiveModule'
])
    .controller(
        'FormatsController', 
        [
            '$log', '$scope', '$timeout', 'FormatsService',
            function ($log, $scope, $timeout, FormatsService) {

                var timeoutId;

                $scope.$on('FormatEditEvent',
                    function (e, format) {
                        $log.debug('formatsController.FormatEditEvent' + JSON.stringify(format));

                        if (timeoutId) {
                            $timeout.cancel(timeoutId);
                        }

                        timeoutId = $timeout(function () {
                            FormatsService.save(format);
                        }, 500);
                    });

                $scope.$on('FormatDeleteEvent',
                    function(e, format) {
                        $log.debug('formatsController.FormatDeleteEvent' + JSON.stringify(format));

                        FormatsService.delete({ id: format.id });
                    });
            }
        ]);