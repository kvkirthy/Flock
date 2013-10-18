'use strict';

flockApp.service('userService', function ($http, $q) {

    var self = this;
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

});