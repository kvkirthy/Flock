flockApp.service('registrationService', ['$http', '$q', function ($http, $q) {

    var self = this;
    this.getUser = function (firstName, lastName) {
        self.deferred = $q.defer();
        $http.get("/api/userProfile/profile?json=true")
        .success(function (data) {
            self.deferred.resolve(data);
        }).
        error(function (error) {
            throw Error(error);
        });
        return self.deferred.promise;
    };

    this.registerUser = function (userFirstName, userLastName, userProject, userInterests) {
        self.deferred = $q.defer();
        var profileInfo = {
            firstName: userFirstName, lastName: userLastName, project:userProject, interests: userInterests
        };
        $http.post("/api/userProfile/profile", profileInfo)
        .success(function (data) {
            self.deferred.resolve(data);
        }).
        error(function (error) {
            self.deferred.reject(error);
        });
        return self.deferred.promise;
    };
}]);