flockApp.controller('messageController', function ($scope, messageService) {

    $scope.messages = [];
    $scope.selectedUser = "BruceLee";
    $scope.isUserNotSelected = true;
    $scope.originalAuthorSays = "";
    $scope.modifiedMessage = {};
    $scope.showCommentTexbox = false;


    $scope.sampleUsers = [
        { id: "1", name: "Sachin" },
        { id: "2", name: "MJ" },
        { id: "3", name: "BruceLee" },
        { id: "4", name: "Federer" },
        { id: "5", name: "Rehman" }
    ];

    messageService.getAllMessages().then(function (data) {
        $scope.messages = data;

    });

    $scope.refresh = function () {
        messageService.getAllMessages().then(function (data) {
            $scope.messages = data;
        });
    };


    $scope.toggleLike = function (message) {
        message.isLiked = (message.isLiked) ? false : true;
    };

    $scope.enterFlock = function () {
        $scope.isUserNotSelected = false;

    };

    $scope.saveMessage = function () {
        var message = {};
        message.content = $scope.messageContent;
        message.user = $scope.selectedUser;
        message.createDatetime = "";
        message.comments = [];
        message.usersLiked = [];
        message.lastUpdated = "Few seconds ago";
        messageService.saveMessage(message).then(function (data) {
            $scope.messages.unshift(data);
        });
        $scope.messageContent = "";

    };


    $scope.shareMessage = function () {
        $scope.modifiedMessage.user = $scope.selectedUser;
        $scope.modifiedMessage.content = $scope.originalAuthorSays;
        $scope.modifiedMessage.usersLiked = [];
        $scope.modifiedMessage.id = null;
        messageService.saveMessage($scope.modifiedMessage).then(function (data) {
            $scope.messages.unshift(data);
        });
        $scope.modifiedMessage = {};
        return;
    };

    $scope.shoutOutLoud = function (message) {
        $scope.modifiedMessage = angular.copy(message);
        $scope.originalAuthorSays = " '" + message.user + "' says " + message.content;
    };


    $scope.likeMessage = function (message) {
        if (!message.usersLiked) {
            message.usersLiked = [];
        }

        for (var i = 0 ; i < message.usersLiked.length; i++) {
            if ($scope.selectedUser == message.usersLiked[i]) {
                return;
            }
        }
        message.usersLiked.push($scope.selectedUser);
        messageService.updateMessage(message).then(function (data) {
            $scope.refresh();
        });
    };

    $scope.checkLikeStatus = function (message) {
        if (message.usersLiked) {
            for (var i = 0 ; i < message.usersLiked.length; i++) {
                if ($scope.selectedUser == message.usersLiked[i]) {
                    return true;
                }
            }
        }
        return false;
    };

    $scope.unlikeMessage = function (message) {
        for (var i = 0 ; i < message.usersLiked.length; i++) {
            if ($scope.selectedUser == message.usersLiked[i]) {
                message.usersLiked.splice(i, 1);
            }
        }
        messageService.updateMessage(message).then(function (data) {
            $scope.refresh();
        });
    };

    $scope.saveComments = function (message) {
        if (!message.comments) {
            message.comments = [];
        }
        message.comments.push($scope.selectedUser +" says :" +message.userComment);
        messageService.updateMessage(message).then(function (data) {
            $scope.refresh();
        });
    };

    $scope.showCommentsText = function() {
        $scope.showCommentTexbox = !$scope.showCommentTexbox;
    };

});