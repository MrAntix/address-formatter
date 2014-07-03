'use strict';

angular.module('confirm', ['ui.bootstrap'])
    .directive(
        'confirm', [
            '$http', '$modal', 
            function ($http, $modal) {

                var modelContent;
                $http.get('/Client/confirm/templates/dialog.html')
                    .success(function(html) {
                        modelContent = html;
                    });

                return {
                    restrict: 'A',
                    replace: false,
                    scope: { confirm: '&', title: '@', message: '@' },
                    link: function (scope, element, attrs) {

                        element.bind('click', function () {
                            scope.message = attrs.confirmMessage
                                || "Are you sure?";

                            var modal = $modal.open({
                                template: modelContent,
                                scope:scope
                            });

                            scope.ok = function() {
                                scope.confirm();
                                modal.close();
                            };

                            scope.cancel = function() {
                                modal.dismiss('cancel');
                            };
                        });

                    }
                };
            }
        ]);

