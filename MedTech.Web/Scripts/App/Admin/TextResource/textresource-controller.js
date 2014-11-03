adminModule.controller('TextResourceController',
    function ($scope, textResourceRepository, ngTableParams) {
        $scope.tableParams = new ngTableParams({
            page: 1,       // show first page      
            count: 5,     // count per page   
            sorting: { key: 'asc' }
        }, {
            total: 0,     // length of data
            counts: [5, 10, 20, 50],
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
            textResourceRepository.edit(data);
        };

        $scope.createClick = function (data) {
            textResourceRepository.create(data);            
            $scope.newtresource = '';
        };
        $scope.deleteClick = function (id) {
            textResourceRepository.remove(id);
        }
    });