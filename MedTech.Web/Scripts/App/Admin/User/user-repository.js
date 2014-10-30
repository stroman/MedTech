adminModule.factory('userRepository', function ($http, $q) {
    return {
        get: function () {
            var deferred = $q.defer();
            $http.get('/api/User').success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});