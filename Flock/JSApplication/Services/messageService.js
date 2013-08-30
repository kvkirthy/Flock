flockApp.service('messageService', function ($http, $q) {

    var self = this;
    self.deferred = $q.defer();
    this.getAllMessages = function () {
       
        $http.get("/api/flockMessage?json=true")
        .success(function(data) {
            self.deferred.resolve(data);
        }).
        error(function(error) {
            throw Error(error);
        });

        return self.deferred.promise;

    };
});


