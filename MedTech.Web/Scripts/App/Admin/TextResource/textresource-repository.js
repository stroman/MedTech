adminModule.factory('textResourceRepository', function ($http, $q) {
    return {
        getList: function (filter) {            
            var deferred = $q.defer();
            $http.put('/api/TextResource', filter).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});