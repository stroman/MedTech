adminModule.factory('textResourceRepository', function ($http, $q) {
    return {
        getList: function (filter) {            
            var deferred = $q.defer();
            $http.put('/api/TextResource', filter).success(deferred.resolve).error(deferred.reject);            
            return deferred.promise;
        },
        update: function (data)
        {
            var deferred = $q.defer();
            $http.post('/api/TextResource/' + data.id, data).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;;
        },
        create: function(data)
        {
            var deferred = $q.defer();
            $http.post('/api/TextResource/0', data).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        remove: function (id) {
            var deferred = $q.defer();
            $http.delete('/api/TextResource/' + id).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});