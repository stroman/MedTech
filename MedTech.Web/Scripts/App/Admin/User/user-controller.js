﻿adminModule.controller('UserController',
    function ($scope, userRepository, ngTableParams) {
        $scope.tableParams = new ngTableParams({
            page: 1,       // show first page      
            count: 10,     // count per page   
            sorting: { name: 'asc' }
            },{
            total: 0,     // length of data
            getData: function ($defer, params) {
                // ajax request to api
                userRepository.get().then(function (data) {
                    // update table params
                    params.total(data.lenght);
                    // set new data
                    $defer.resolve(data);
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