homeModule.factory('accountRepository', function ($http, $q, $location, redirectToUrlAfterLogin) {
    var account = {
        isLogged: false,
        email : '',
    };    
    
    return {
        login: function (data) {
            var deferred = $q.defer();
            $http.post('/api/Account', data).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        logout: function () {                        
            $http.delete('/api/Account');            
        },
        account: account,
        setStatusLogin: function(email){
            account.isLogged = true;
            account.email = email;
            redirectToDefaultUrl();
        },
        setSatusLogout: function () {
            account.isLogged = false;
            account.email = '';
            redirectToDefaultUrl();
        },        
    }

    function redirectToDefaultUrl() {
        //$location.path('/');
        window.location.replace('/');        
    }
});


