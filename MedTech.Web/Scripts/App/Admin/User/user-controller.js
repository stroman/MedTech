adminModule.controller('UserController',
    function ($scope, userRepository) {        
        userRepository.get().then(function (data) {            
            $scope.users = data;
        });
    });