flockApp.service('quackService', function ($http, $q) {

    var self = this;
    this.saveQuack = function (quack) {
        self.deferred = $q.defer();
        $http.post("/api/quack/save", quack)
        .success(function (data) {
            self.deferred.resolve(data);
        }).
        error(function (error) {
            throw Error(error);
        });
        return self.deferred.promise;
    };

    this.getAllQuacks = function () {
        self.deferred = $q.defer();
        $http.get("/api/quack")
        .success(function (data) {
            self.deferred.resolve(data);
        });

        return self.deferred.promise;
    };
    
});


