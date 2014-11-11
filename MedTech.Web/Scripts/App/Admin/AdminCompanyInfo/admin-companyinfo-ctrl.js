adminModule.controller('AdminCompanyInfoController',
    function ($scope, adminCompanyInfoRepository) {
        adminCompanyInfoRepository.get().then(function (data) {            
            $scope.companyInfo = data;

            $scope.addContactClick = function (data) {                
                data[data.length] = { contactType: 1, value: "" };               

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