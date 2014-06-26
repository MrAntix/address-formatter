'use strict';

var app = angular.module('app', [
    'ngTouch',
    'ngAnimate',
    'ui.bootstrap',
    'ui.router',
    'home',
    'formatsModule'
]);

app
    .config([
        '$stateProvider', '$urlRouterProvider',
        function ($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise("/");

            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: 'Client/home/views/index.cshtml',
                    controller: 'HomeController'
                });
        }
    ]);