homeModule.controller('LoginController',
    function ($scope) {        
        $scope.logon = function (login, loginForm) {
            if (loginForm.$valid) {
                alert(login.email);
            }
        };
    });