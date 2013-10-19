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
        $http.get("/api/quack/activeQuacks")
        .success(function (data) {
            self.deferred.resolve(data);
        });

        return self.deferred.promise;
    };

    this.deleteQuack = function(quackId) {
        self.deferred = $q.defer();
        $http.put("/api/quack/deleteQuack?quackId="+quackId)
        .success(function (data) {
            self.deferred.resolve(data);
        });

        return self.deferred.promise;
    };
    
    this.likeOrUnlikeQuack = function (quackId, userId, isLike) {
        self.deferred = $q.defer();
        $http.post("/api/quack/likeOrUnlikeQuack?quackId=" + quackId+"&userId="+userId+"&isLike="+isLike)
        .success(function (data) {
            self.deferred.resolve(data);
        });

        return self.deferred.promise;
    };
    
});


