homeModule.factory('accountRepository', function ($http, $q, $location, redirectToUrlAfterLogin) {
    var accountInfo = {
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
        getLoggedStatus: function (){
            var deferred = $q.defer();
            $http.get('/api/Account').success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        getAccountInfo: function () {
            return accountInfo;
        },
        setAccountInfo: function (data) {
            accountInfo = data;
        },
        setStatusLogin: function(email){
            accountInfo.isLogged = true;
            accountInfo.email = email;
            redirectToDefaultUrl();
        },
        setSatusLogout: function () {
            accountInfo.isLogged = false;
            accountInfo.email = '';
            redirectToDefaultUrl();
        },        
    }

    function redirectToDefaultUrl() {
        //$location.path('/');
        window.location.replace('/');        
    }
});


