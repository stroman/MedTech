adminModule.controller('AdminCompanyInfoController',
    function ($scope, adminCompanyInfoRepository) {

        var maxId = 0;

        adminCompanyInfoRepository.get().then(function (data) {            
            $scope.companyInfo = data;
            maxId = Math.max(data['id']);            

            $scope.addContactClick = function (data) {
                maxId++;
                alert(maxId);
                data[data.length] = {id: maxId, contactType: 1, value: "" };               

            };

            $scope.saveClick = function (data, dataForm) {
                if(dataForm.$valid)
                {
                    alert(data.contacts.length)
                }
            };

            $scope.cancelClick = function () {
                $scope.companyInfo = '';
            };
        });
    });