
'use strict';

flockApp.controller('userPageController', function ($scope, userService, quackService) {


    $scope.userName = "";
    $scope.showConversations = false;
    $scope.expandOrCollapse = "Expand";
    $scope.maxCharacters = 200;
    $scope.user = {};
    $scope.userPreferences = "User Preferences";
    $scope.userProfilePicUrl = "";
    $scope.quacks = [];
    $scope.replyMode = false;

    var getQuacks = function () {
        refreshQuacks();
    };

    userService.getUser().then(function (user) {
        $scope.user = user;
        $scope.userName = user.FirstName;
        $("#userCoverPic").attr("src", "data:image/jpeg;base64," + user.CoverImage);
        $scope.userProfilePicUrl = "data:image/jpeg;base64," + user.ProfileImage;
        $scope.imageUrl = "data:image/jpeg;base64," + user.CoverImage;
        $scope.profilePicimageUrl = $scope.userProfilePicUrl;
        getQuacks();

    });

    $scope.saveQuack = function () {
        var quack = {};
        quack.userId = $scope.user.ID;
        quack.parentQuackId = null;
        quack.quackTypeId = 1;
        quack.quackContent = {};
        quack.quackContent.messageText = $scope.messageContent;
        if (quack.quackContent.messageText != "") {
            quackService.saveQuack(quack).then(function () {
                refreshQuacks();
            });
        }
        $scope.messageContent = "";
    };
    

    $scope.saveReply = function (quackId) {
        var quack = {};
        quack.userId = $scope.user.ID;
        quack.parentQuackId = null;
        quack.quackTypeId = 2;
        quack.quackContent = {};
        quack.conversationId = quackId;
        quack.quackContent.messageText = $('#replyContent').val();
        if (quack.quackContent.replyContent != "") {
            quackService.saveQuack(quack).then(function () {
                $scope.replyMode = false;
                refreshQuacks();
            });
        }
        $('#replyContent').val('');
    };

    var refreshQuacks = function () {
        if(!($scope.replyMode )){
            quackService.getAllQuacks().then(function(data) {
                for (var i = 0; i < data.length; i++) {
                    data[i].UserImage = "data:image/jpeg;base64," + data[i].UserImage;
                    data[i].ShowConversation = false;
                    data[i].ExpandOrCollapse = "Expand";
                    if ($scope.user.ID == data[i].UserId) {
                        data[i].ShowDelete = true;
                    } else {
                        data[i].ShowDelete = false;
                    }
                }
                console.log(data);
                $scope.quacks = data;
            });
        }
    };

    //setInterval(function () {
    //    refreshQuacks();
    //}, 10000);

    $scope.expandClick = function (quack) {
        quack.ShowConversation = !quack.ShowConversation;
        quack.ExpandOrCollapse = quack.ExpandOrCollapse == "Expand" ? "Collapse" : "Expand";
        
        if(quack.ExpandOrCollapse == "Expand") {
            $scope.replyMode = false;
        }
        else {
            $scope.replyMode = true;
        }
    };

    $scope.deleteQuack = function (quackId) {
        quackService.deleteQuack(quackId).then(function () {
            refreshQuacks();
        });
    };

    $scope.likeOrUnlikeQuack = function(quack) {
        quackService.likeOrUnlikeQuack(quack.Id, quack.UserId,
            quack.LikeOrUnlike == "Like" ? true : false).then(function () {
            refreshQuacks();
        } );
    };
});