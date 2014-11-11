adminModule.factory('adminCompanyInfoRepository', function ($http, $q) {
    return {
        get: function () {
            var deferred = $q.defer();
            $http.get('/api/CompanyInfo').success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },       
        update: function (data) {
            var deferred = $q.defer();
            $http.post('/api/CompanyInfo', data).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;;
        },
    }
});