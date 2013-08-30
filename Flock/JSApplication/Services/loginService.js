flockApp.service('loginService', function ($http, $q) {

        this.isExistingUser = function()
        {
            var deffered = $q.defer();
            $http.get('flockApi/users/user').
            success(function (data) {
                deffered.resolve(data);
            }).
            error(function (status) {
                deffered.reject(status);
            })

            return deffered.promise;

        };
}


);