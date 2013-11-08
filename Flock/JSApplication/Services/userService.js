'use strict';

flockApp.service('userService', function ($http, $q) {

    var self = this;

    this.getUserByUserName = function (lastName, firstName) {
        self.deferred = $q.defer();
        $http.get("/api/user/getUserByUserName?lastName="+ lastName +"&firstName="+firstName)
        .success(function (data) {
            self.deferred.resolve(data);
        }).
        error(function (error) {
            self.deferred.reject(error);
        });
        return self.deferred.promise;
    };

    this.getUser = function () {
        self.deferred = $q.defer();
        $http.get("/api/user/getUser?json=true")
        .success(function (data) {
            self.deferred.resolve(data);
        }).
        error(function (error) {
            throw Error(error);
        });
        return self.deferred.promise;
    };

    this.uploadImage = function (image) {
        self.deferred = $q.defer();
        $http.post("/api/user/uploadImage", image)
        .success(function (data) {
            self.deferred.resolve(data);
        }).
        error(function (error) {
            throw Error(error);
        });
        return self.deferred.promise;
    };
    
    this.getUserLikesInfo = function(quackId) {
        self.deferred = $q.defer();
        $http.get("/api/user/getUserLikesInfo?quackId="+quackId )
        .success(function (data) {
            self.deferred.resolve(data);
        }).
        error(function (error) {
            throw Error(error);
        });
        return self.deferred.promise;
    };
    
    this.updateUserPreferences = function (userDetails) {
        self.deffered = $q.defer();
        $http.put("/api/user/updateUserPreferences", userDetails)
            .success(function (data) {
                 self.deffered.resolve(data);
            })
            .error(function (error) {
                 throw Error(error);
            });

        return self.deffered.promise;

    };

});