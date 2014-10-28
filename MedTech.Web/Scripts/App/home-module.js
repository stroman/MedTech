
var homeModule = angular.module('homeModule', ['ngRoute']);

homeModule.config(function ($routeProvider) {
    $routeProvider.when('/CompanyInfo', {
        templateUrl: '/Home/CompanyInfo',
        controller: 'CompanyInfoController'
    });

    $routeProvider.when('/Login', {
        templateUrl: '/Home/Login',
        controller: 'AccountController'
    });

    //$routeProvider.otherwise({ redirectTo: '/'});
});