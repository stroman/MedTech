homeModule.factory('accountRepository', function ($http, $q, $cookies, $location, redirectToUrlAfterLogin) {
    return {
        login: function (data) {
            var deferred = $q.defer();
            $http.post('/api/Account', data).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        logout: function () {                        
            $http.delete('/api/Account');            
        },
        isLoggedIn: function()
        {
            //convert value to bool
            return $cookies;
        },
        saveAttemptUrl: function () {
            if ($location.path().toLowerCase() != '/login') {
                redirectToUrlAfterLogin.url = $location.path();
            }
            else
                redirectToUrlAfterLogin.url = '/';
        },
        redirectToAttemptedUrl: function () {
            $location.path(redirectToUrlAfterLogin.url);
        }
    }
});