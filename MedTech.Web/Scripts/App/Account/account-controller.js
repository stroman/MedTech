homeModule.controller('AccountController',
    function ($scope, accountRepository, $location) {
        $scope.loginClick = function (login, loginForm) {
            if (loginForm.$valid) {
                accountRepository.login(login).then(function (data) {                    
                    if (data) {
                        accountRepository.setStatusLogin(login.email);
                    }
                    else {
                        $scope.message = "Неверное имя пользователя или пароль";
                        $(".message").show();
                    }                   
                });
            }
        };
        $scope.logoutClick = function () {            
            accountRepository.logout();
            accountRepository.setSatusLogout();
        };
    });

//// When the app loads
//homeModule.run(function ($location, accountRepository) {
//    if (!accountRepository.isLoggedIn()) {
//        accountRepository.saveAttemptUrl();
//        $location.path('/Login');
//    }
//});