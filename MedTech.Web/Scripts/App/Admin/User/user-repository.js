adminModule.factory('userRepository', function ($http, $q) {
    return {
        getList: function (filter) {
            var deferred = $q.defer();
            $http.put('/api/User', filter).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        update: function (data) {
            var deferred = $q.defer();
            $http.post('/api/User/' + data.id, data).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;;
        },
        create: function (data) {
            var deferred = $q.defer();
            $http.post('/api/User/0', data).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        remove: function (id) {
            var deferred = $q.defer();
            $http.delete('/api/User/' + id).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});