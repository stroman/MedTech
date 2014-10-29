homeModule.controller('AccountController',
    function ($scope, accountRepository, $location) {
        $scope.loginClick = function (login, loginForm) {
            if (loginForm.$valid) {
                accountRepository.login(login).then(function (data) {                    
                    if (data) {
                        
                    }
                    else {
                        $scope.message = "Неверное имя пользователя или пароль";
                        $(".message").show();
                    }
                    alert(accountRepository.isLoggedIn());
                });
            }
        };
        $scope.logoutClick = function () {
            alert(accountRepository.isLoggedIn());
            accountRepository.logout();
            
        };
    });

//// When the app loads
//homeModule.run(function ($location, accountRepository) {
//    if (!accountRepository.isLoggedIn()) {
//        accountRepository.saveAttemptUrl();
//        $location.path('/Login');
//    }
//});