var adminModule = angular.module('adminModule', ['ngRoute', 'ngTable', 'ngMessages']);

adminModule.config(function ($routeProvider) {    
    $routeProvider.when('/Users', {
        templateUrl: '/Admin/Users',
        controller: 'UserController'
    });

    $routeProvider.when('/CreateUser', {
        templateUrl: '/Admin/CreateUser',
        controller: 'UserController'
    });

    $routeProvider.when('/TextResources', {
        templateUrl: '/Admin/TextResources',
        controller: 'TextResourceController'
    });

    $routeProvider.when('/EditCompanyInfo', {
        templateUrl: '/Admin/EditCompanyInfo',
        controller: 'AdminCompanyInfoController'
    });

    //$routeProvider.otherwise({ redirectTo: '/' });
});