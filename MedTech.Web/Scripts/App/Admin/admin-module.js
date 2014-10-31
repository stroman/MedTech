var adminModule = angular.module('adminModule', ['ngRoute', 'ngTable']);

adminModule.config(function ($routeProvider) {    
    $routeProvider.when('/Users', {
        templateUrl: '/Admin/Users',
        controller: 'UserController'
    });
});

adminModule.config(function ($routeProvider) {
    $routeProvider.when('/TextResources', {
        templateUrl: '/Admin/TextResources',
        controller: 'TextResourceController'
    });
});