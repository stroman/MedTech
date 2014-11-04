adminModule.controller('UserController',
    function ($scope, userRepository, ngTableParams) {
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

    });