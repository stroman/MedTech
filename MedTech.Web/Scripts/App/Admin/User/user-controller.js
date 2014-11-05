adminModule.controller('UserController',
    function ($scope, userRepository, ngTableParams, $location) {
        $scope.tableParams = new ngTableParams({
            page: 1,       // show first page      
            count: 10,     // count per page   
            sorting: { firstName: 'asc' }
        },{
            total: 0,     // length of data
            counts: [10, 20, 50, 100],
            getData: function ($defer, params) {
                // ajax request to api
                userRepository.getList(params.$params).then(function (data) {
                    // update table params                   
                    params.total(data.totalCount);
                    // set new data
                    $defer.resolve(data.rows);
                });                
            }
        });

        $scope.updateClick = function (data) {
            userRepository.update(data);
        };

        $scope.createClick = function (data, dataForm) {
            if (dataForm.$valid) {
                $scope.confirmPasswordError = false;
                if (data.password == data.confirmPassword) {
                    userRepository.create(data).then(function () {
                        $location.path("/Users");
                    });                    
                }
                else {
                    $scope.confirmPasswordError = true;
                }
            }            
        };
        $scope.deleteClick = function (id) {
            if (confirm("Jopa2")) {
                userRepository.remove(id).then(function () {
                    $scope.tableParams.reload();

                });
            }
        };       

    });