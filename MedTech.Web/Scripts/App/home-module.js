var homeModule = angular.module('homeModule', ['ngRoute', 'adminModule', 'ngMessages']);

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
    //$locationProvider.html5Mode(true);
    //$routeProvider.otherwise({ redirectTo: '/'});
});
