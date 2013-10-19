
'use strict';

flockApp.controller('userPageController', function ($scope, userService, quackService) {

    
    $scope.userName = "";
    $scope.imageUrl = "";

    $scope.user = {};
    $scope.userPreferences = "User Preferences";
    
    //quackService.getAllQuacks().then(function (data) {
    //    if (data && _.isArray(data)) {
    //        $scope.quacks = data;            
    //    }
    //});

    userService.getUser().then(function (user) {
        $scope.user = user;
        $scope.userName = user.FirstName;
        $("#userCoverPic").attr("src", "data:image/jpeg;base64," + user.CoverImage);
        $scope.imageUrl = "data:image/jpeg;base64," + user.CoverImage;
        
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