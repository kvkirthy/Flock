
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
        quack.id = 11;
        quack.userId = 12;
        quackService.saveQuack(quack);
    };
    
});