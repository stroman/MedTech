adminModule.controller('TextResourceController',
    function ($scope, textResourceRepository, ngTableParams) {
        $scope.tableParams = new ngTableParams({
            page: 1,       // show first page      
            count: 10,     // count per page   
            sorting: { key: 'asc' }
        }, {
            total: 0,     // length of data
            counts: [10, 20, 50, 100],
            getData: function ($defer, params) {
                // ajax request to api
                textResourceRepository.getList(params.$params).then(function (data) {                   
                    // update table params                   
                    params.total(data.totalCount);
                    // set new data
                    $defer.resolve(data.rows);                    
                });
            }
        });

        $scope.updateClick = function (data) {
            textResourceRepository.update(data);
        };

        $scope.createClick = function (data) {
            textResourceRepository.create(data).then(function () {
                $scope.newtresource = '';
                $scope.tableParams.reload();
            });
        };
        $scope.deleteClick = function (id) {
            textResourceRepository.remove(id).then(function () {
                $scope.tableParams.reload();
            });
        }
    });