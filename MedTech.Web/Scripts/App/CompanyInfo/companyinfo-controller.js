homeModule.controller('CompanyInfoController',
    function ($scope, companyInfoRepository) {
        companyInfoRepository.get().then(function (data) {
            $scope.companyInfo = data;           
            $("#map-col").append($scope.companyInfo.urlAddress);
            for(var i=0; i<data.contacts.length; i++)
            {                
                switch(data.contacts[i].contactType)
                {
                    case 1:
                        $scope.phone = true;                        
                        break;
                    case 2:
                        $scope.fax = true;
                        break;
                    case 3:
                        $scope.mail = true;                        
                        break;                    
                    case 4:
                        $scope.website = true;
                        break;
                }
            }
    });
});