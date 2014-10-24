
var homeModule = angular.module('homeModule', ['ngRoute']);

homeModule.config(function ($routeProvider) {
    $routeProvider.when('/CompanyInfo', {
        templateUrl: '/Templates/Home/CompanyInfo.html',
        controller: 'CompanyInfoController'
    });

    $routeProvider.when('/Login', {
        templateUrl: '/Account/Login',
        controller: 'LoginController'
    });
});