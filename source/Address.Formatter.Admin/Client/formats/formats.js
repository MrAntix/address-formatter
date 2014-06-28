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
                        $log.debug('formatsController.FormatEditEvent ' + format.id);

                        if (timeoutId) {
                            $timeout.cancel(timeoutId);
                        }

                        timeoutId = $timeout(function () {
                            FormatsService.save(format, function (data) {
                                format.id = data.id;
                                
                                $scope.$broadcast('FormatSavedEvent');
                            });
                        }, 500);
                    });

                $scope.$on('FormatDeleteEvent',
                    function(e, format) {
                        $log.debug('formatsController.FormatDeleteEvent '+format.id);

                        FormatsService.delete({ id: format.id }, function() {
                            
                            $scope.$broadcast('FormatDeletedEvent', format);
                        });
                    });
            }
        ]);