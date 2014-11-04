homeModule.controller('AccountController',
    function ($scope, accountRepository, $location) {
        accountRepository.getLoggedStatus().then(function (data) {
            accountRepository.setAccountInfo(data);
            $scope.accountInfo = data;
        });

        $scope.loginClick = function (login, loginForm) {
            $scope.error = false;
            if (loginForm.$valid) {
                accountRepository.login(login).then(function (data) {                    
                    if (data) {
                        accountRepository.setStatusLogin(login.email);
                    }
                    else {
                        $scope.error = true;                       
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