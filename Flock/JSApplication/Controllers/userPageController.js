
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
    $scope.userLikeQuackId = "";

    $scope.setQuackId = function(quackId, likes) {
            $scope.userLikeQuackId = quackId;
            $scope.$broadcast('quackUserLikesController.showUserLikes');
    };

    var getQuacks = function () {
        $scope.refreshQuacks();
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
                $scope.replyMode = false;
                $scope.refreshQuacks();
                $scope.messageContent = "";
            });
        }
        
    };
    

    $scope.saveReply = function (quackId, element, isNew, conversationId) {
        var quack = {};
        quack.userId = $scope.user.ID;
        quack.parentQuackId = null;
        quack.quackTypeId = 2;
        quack.quackContent = {};
        
        if (isNew) {
            quack.conversationId = quackId;
        }
        else {
            quack.conversationId = conversationId;
        }


        quack.quackContent.messageText = $('#'+element).val();
        if (quack.quackContent.messageText != "") {
            quackService.saveQuack(quack).then(function () {
                $scope.replyMode = false;
                $scope.refreshQuacks();
                $scope.replyContent = "";
            });
        }
        
    };

    $scope.refreshQuacks = function () {
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
                    for (var j = 0; j < data[i].QuackReplies.length ; j++) {
                        data[i].QuackReplies[j].UserImage = "data:image/jpeg;base64," + data[i].QuackReplies[j].UserImage;
                    }
                }
                $scope.quacks = data;
            });
        }
    };



    setInterval(function () {
        $scope.refreshQuacks();
    }, 10000);

    $scope.expandClick = function (quack) {
        
        quack.ShowConversation = !quack.ShowConversation;
        quack.ExpandOrCollapse = quack.ExpandOrCollapse == "Expand" ? "Collapse" : "Expand";
        
        if(quack.ExpandOrCollapse == "Expand") {
            $scope.replyMode = false;
        }
        else {
            $scope.replyMode = true;
        }

       for(var i=0; i<$scope.quacks.length  ; i++) {
            if(quack.Id == $scope.quacks[i].Id ) {
                
            }
            else {
                $scope.quacks[i].ExpandOrCollapse = "Expand";
                $scope.quacks[i].ShowConversation = false;
            }
        }
        
       if (!(quack.IsNew) && quack.ExpandOrCollapse == "Collapse") {
           quackService.getQuackInformation(quack.ConversationId).then(function(data)
           {
               for (var f = 0;  f< data.length ; f++) {
                   data[f].UserImage = "data:image/jpeg;base64," + data[f].UserImage;
               }
               quack.QuackReplies = data;
           });
       }


    };

    $scope.deleteQuack = function (quackId) {
        quackService.deleteQuack(quackId).then(function () {
            $scope.replyMode = false;
            $scope.refreshQuacks();
        });
    };

    $scope.likeOrUnlikeQuack = function(quack) {
        quackService.likeOrUnlikeQuack(quack.Id, quack.UserId,
            quack.LikeOrUnlike == "Like" ? true : false).then(function () {
                $scope.replyMode = false;
            $scope.refreshQuacks();
        } );
    };
});