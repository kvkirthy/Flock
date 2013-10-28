flockApp.service('searchService', function ($http, $q) {

    var self = this;
    self.getAllUserTags = function () {
        self.defered = $q.defer();

        $http.get("/api/search/userTags")
        .success(function (data) {
            return self.defered.resolve(data);
        })
        .error(function (data) {
            return self.defered.reject(data);
        })

        return self.defered.promise;
    }
});