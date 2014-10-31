adminModule.controller('TextResourceController',
    function ($scope, textResourceRepository, ngTableParams) {
        $scope.tableParams = new ngTableParams({
            page: 1,       // show first page      
            count: 5,     // count per page   
            sorting: { key: 'asc' }
        }, {
            total: 0,     // length of data
            counts: [5,10,20,50],
            getData: function ($defer, params) {
                // ajax request to api
                textResourceRepository.getList(params.$params).then(function (data) {
                    // update table params                   
                    params.total(data.totalCount);
                    // set new data
                    $defer.resolve(data.rows);
                });

                //Api.get(params.url(), function (data) {
                //    $timeout(function () {
                //        // update table params
                //        params.total(data.total);
                //        // set new data
                //        $defer.resolve(data.result);
                //    }, 500);
                //});
            }
        });



    });