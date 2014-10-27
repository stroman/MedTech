homeModule.factory('accountRepository', function ($http, $q) {
    return {
        post: function (data) {
            var deferred = $q.defer();
            $http.post('/api/Account', data).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});