homeModule.controller('CompanyInfoController',
    function ($scope, companyInfoRepository) {
        companyInfoRepository.get().then(function (data) {
            $scope.companyInfo = data;            
    });
});