adminModule.factory('textResourceRepository', function ($http, $q) {
    return {
        getList: function (filter) {            
            var deferred = $q.defer();
            $http.put('/api/TextResource', filter).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        update: function (data)
        {            
            $http.post('/api/TextResource', data);
        },
        create: function(data)
        {           
            $http.post('/api/TextResource/0', data);
        },
        remove: function (id) {
            $http.delete('/api/TextResource/' + id);            
        }
    }
});