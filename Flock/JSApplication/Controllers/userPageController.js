
'use strict';

flockApp.controller('userPageController', function ($scope, userService, quackService) {

    
    $scope.userName = "";
    
    $scope.maxCharacters = 200;
    $scope.user = {};
    $scope.userPreferences = "User Preferences";
    $scope.userProfilePicUrl = "";
   

   

    userService.getUser().then(function (user) {
        
        $scope.user = user;
        $scope.userName = user.FirstName;
        $("#userCoverPic").attr("src", "data:image/jpeg;base64," + user.CoverImage);
        $scope.userProfilePicUrl = "data:image/jpeg;base64,"+user.ProfileImage;
        $scope.imageUrl = "data:image/jpeg;base64," + user.CoverImage;
        $scope.profilePicimageUrl = $scope.userProfilePicUrl;
        
        
    });

    $scope.saveQuack = function () {
        var quack = {};
        quack.userId = $scope.user.ID;
        quack.parentQuackId = null;
        quack.quackTypeId = 1;
        quack.quackContent = {};
        quack.quackContent.messageText = $('#quackText').val();
        quackService.saveQuack(quack);

        console.log(quack);
    };
    
});