flockApp.service('messageService', function ($http, $q) {

    var self = this;
    this.getAllMessages = function () {
        self.deferred = $q.defer();
        $http.get("/api/flockMessage/messages?json=true")
        .success(function(data) {
            self.deferred.resolve(data);
        }).
        error(function(error) {
            throw Error(error);
        });
        return self.deferred.promise;
    };
    
    this.saveMessage = function (message) {
        self.deferred = $q.defer();
        $http.post("/api/flockMessage/message", message)
        .success(function (data) {
            self.deferred.resolve(data);
        }).
        error(function (error) {
            throw Error(error);
        });
        return self.deferred.promise;
    };
    
    this.updateMessage = function (message) {
        self.deferred = $q.defer();
        $http.put("/api/flockMessage/message", message)
        .success(function (data) {
            self.deferred.resolve(data);
        }).
        error(function (error) {
            throw Error(error);
        });
        return self.deferred.promise;
    };
    
});