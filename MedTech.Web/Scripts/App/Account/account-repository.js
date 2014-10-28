homeModule.factory('accountRepository', function ($http, $q) {
    return {
        login: function (data) {
            var deferred = $q.defer();
            $http.post('/api/Account', data).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        logout: function () {
            alert("GO");            
            $http.delete('/api/Account/1');            
        }
    }
});