homeModule.controller('AccountController',
    function ($scope, accountRepository) {
        $scope.loginClick = function (login, loginForm) {
            if (loginForm.$valid) {
                accountRepository.login(login).then(function (data) {
                    alert(data);
                });
            }
        };
        $scope.logoutClick = function () {
            accountRepository.logout();
        };
    });