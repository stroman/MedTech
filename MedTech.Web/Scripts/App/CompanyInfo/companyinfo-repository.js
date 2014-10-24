homeModule.factory('companyInfoRepository', function ($http, $q) {
    return {
        get: function () {
            var deferred = $q.defer();
            $http.get('/api/CompanyInfo').success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }    
});