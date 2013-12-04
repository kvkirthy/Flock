
'use strict';

flockApp.controller('userPageController', function ($scope, $window, userService, quackService, sessionFactory) {
    
    $scope.displayName = "";
    $scope.showConversations = false;
    $scope.expandOrCollapse = "Expand";
    $scope.maxCharacters = 300;
    $scope.user = {};
    $scope.userPreferences = "User Preferences";
    $scope.userProfilePicUrl = "";
    $scope.quacks = [];
    $scope.replyMode = false;
    $scope.userLikeQuackId = "";
    $scope.disableQuackMessage = false;
    $scope.disableReplyAction = false;
    var isValidUser = false;
    
    
    $scope.setQuackId = function(quackId, likes) {
            $scope.userLikeQuackId = quackId;
            $scope.$broadcast('quackUserLikesController.showUserLikes');
    };

    $scope.showUserDetails = function() {
        $scope.$broadcast('userInfoController.showUserInformation');
    };

    var getQuacks = function () {
        $scope.refreshQuacks();
    };

    userService.getUser().then(function (user) {
        
        if (user == "null") {
           
            window.location.replace("/JSApplication/Templates/Guest.html");
            return;
        }

        isValidUser = true;
        $scope.user = user;
        $scope.displayName = user.FirstName + " " + user.LastName;
        
        if (user.CoverImage == "") {
            $("#userCoverPic").attr("src", "/Content/images/defaultCoverPic.png");
            $scope.imageUrl = "/Content/images/defaultCoverPic.png";
        }
        else {
            $("#userCoverPic").attr("src", "data:image/jpeg;base64," + user.CoverImage);
            $scope.imageUrl = "data:image/jpeg;base64," + user.CoverImage;
        }

        if(user.ProfileImage =="") {
            $scope.userProfilePicUrl = "/Content/images/profilepic.png";
            $scope.profilePicimageUrl = $scope.userProfilePicUrl;
        }
        else {
            $scope.userProfilePicUrl = "data:image/jpeg;base64," + user.ProfileImage;
            $scope.profilePicimageUrl = $scope.userProfilePicUrl;
        }
        getQuacks();



    });

    $scope.saveQuack = function () {
        
        if(!isValidUser ) {
            return;
        }
        
        $scope.disableQuackMessage = true;
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
                $scope.disableQuackMessage = false;
                
            });
        }
        else {
            $scope.disableQuackMessage = false;
        }
        

        
    };
    

    $scope.saveReply = function (quackId, element, isNew, conversationId) {
        $scope.disableReplyAction = true;
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
                $scope.disableReplyAction = false;
            });
        }
        else {
            $scope.disableReplyAction = false;
        }
        
    };

    $scope.refreshQuacks = function () {
        if (!($scope.replyMode)) {
        
            quackService.getAllQuacks().then(function (data) {
                
                for (var i = 0; i < data.length; i++) {
                    

                    if (!(data[i].QuackImage) || data[i].QuackImage == "") {
                        data[i].showQuackImage =false;
                    }
                    else {
                        data[i].QuackImage = "data:image/jpeg;base64," + data[i].QuackImage;
                        data[i].showQuackImage = true;
                    }
                    
                    if (!(data[i].UserImage) || data[i].UserImage == "") {
                        data[i].UserImage = "/Content/images/profilepic.png";
                    }
                    else {
                        data[i].UserImage = "data:image/jpeg;base64," + data[i].UserImage;
                    }
                    
                    if (data[i].Replies != 0) {
                        data[i].showLatestReply = true;
                        if (!(data[i].LatestReply.UserImage) || data[i].LatestReply.UserImage == "") {
                            data[i].LatestReply.UserImage = "/Content/images/profilepic.png";
                        }
                        else {
                            data[i].LatestReply.UserImage = "data:image/jpeg;base64," + data[i].LatestReply.UserImage;
                        }
                        
                        if ($scope.user.ID == data[i].LatestReply.UserId) {
                            data[i].LatestReply.ShowDelete = true;
                        } else {
                            data[i].LatestReply.ShowDelete = false;
                        }
                    }
                    else {
                        data[i].showLatestReply = false;
                    }
                    
                   
                    
                    
                    data[i].ShowConversation = false;
                    data[i].ExpandOrCollapse = "Expand";
                    if ($scope.user.ID == data[i].UserId) {
                        data[i].ShowDelete = true;
                    } else {
                        data[i].ShowDelete = false;
                    }
                    
                    
                    

                    for (var j = 0; j < data[i].QuackReplies.length ; j++) {
                        
                        if (!(data[i].QuackReplies[j].UserImage) || data[i].QuackReplies[j].UserImage=="") {
                            data[i].QuackReplies[j].UserImage = "/Content/images/profilepic.png";
                        }
                        else {
                            data[i].QuackReplies[j].UserImage = "data:image/jpeg;base64," + data[i].QuackReplies[j].UserImage;
                        }
                        
                    }
                }
                $scope.quacks = data;
                
            });
        }
    };



    setInterval(function () {
        if (isValidUser)
        $scope.refreshQuacks();
    }, 45000);

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
        
       if (quack.ExpandOrCollapse == "Collapse") {
           quackService.getQuackInformation(quack.Id).then(function(data)
           {
               for (var f = 0; f < data.length ; f++) {
                   if (!(data[f].UserImage) || data[f].UserImage == "") {
                       data[f].UserImage = "/Content/images/profilepic.png";
                   }
                   else {
                       data[f].UserImage = "data:image/jpeg;base64," + data[f].UserImage;
                   }
                   
                   if ($scope.user.ID == data[f].UserId) {
                       data[f].ShowDelete = true;
                   } else {
                       data[f].ShowDelete = false;
                   }
                   

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

    $scope.likeOrUnlikeQuack = function (quack) {
        quackService.likeOrUnlikeQuack(quack.Id, $scope.user.ID,
            quack.LikeOrUnlike == "Like" ? true : false).then(function () {
                $scope.replyMode = false;
            $scope.refreshQuacks();
        } );
    };

    $scope.$on('userTagSelected', function (event, data) {       
        data.firstName = (data.firstName || "").split("@")[1]; // purpose: remove @ from first name
        //sessionFactory.user = data;
        openProfilePage(data.firstName, data.lastName);
    });

    $scope.openProfilePageByGivenName = function (data) {
        var names = data.split(" ");
        openProfilePage(names[0], names[1]);
    };

    var openProfilePage = function (firstName, lastName) {
        $window.open('/UserView/index?firstName=' + firstName + "&lastName=" + lastName, lastName + firstName);
    }
});