homeModule.controller('AccountController',
    function ($scope, accountRepository) {
        $scope.loginClick = function (login, loginForm) {
            if (loginForm.$valid) {
                accountRepository.post(login).then(function (data) {
                    alert(data);
                });
            }
        };
    });