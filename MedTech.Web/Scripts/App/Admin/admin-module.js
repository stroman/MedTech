var adminModule = angular.module('adminModule', ['ngRoute']);

adminModule.config(function ($routeProvider) {    
    $routeProvider.when('/Users', {
        templateUrl: '/Admin/Users',
        controller: 'UserController'
    });
});