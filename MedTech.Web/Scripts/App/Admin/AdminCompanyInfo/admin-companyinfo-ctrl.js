﻿adminModule.controller('AdminCompanyInfoController',
    function ($scope, adminCompanyInfoRepository) {

        var maxId = 0;
        var oldCompanyInfo = "";
        adminCompanyInfoRepository.get().then(function (data) {            
            oldCompanyInfo = clone(data);           
            $scope.companyInfo = data;            
            for (var i=0; i<data.contacts.length; i++){                
                if (data.contacts[i].id > maxId){
                    maxId = data.contacts[i].id;
                }
            }            

            $scope.addContactClick = function (data) {
                maxId++;                
                data[data.length] = {id: maxId, contactType: 1, companyId: oldCompanyInfo.id, value: "" };               

            };

            $scope.deleteContactClick = function (data) {
                var arr = $scope.companyInfo.contacts
                for (var i = 0; i < arr.length; i++)
                {
                    if(data.id == arr[i].id)
                    {
                        arr.splice(i, 1);
                    }
                }
                console.log(arr);
            };

            $scope.saveClick = function (data, dataForm) {
                if(dataForm.$valid)
                {
                    adminCompanyInfoRepository.update(data).then(function (flag) {
                           oldCompanyInfo = clone(data);
                    });
                }
            };

            

            $scope.cancelClick = function () {                
                $scope.companyInfo = clone(oldCompanyInfo);
            };
        });
    });

function clone(o) {    
    return eval("(" + JSON.stringify(o) + ")");
}

