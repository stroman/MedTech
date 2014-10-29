var homeModule = angular.module('homeModule', ['ngRoute', 'ngCookies']);

homeModule.value('redirectToUrlAfterLogin', { url: '/' });

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