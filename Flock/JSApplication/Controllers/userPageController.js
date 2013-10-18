
'use strict';

flockApp.controller('userPageController', function ($scope, userService, quackService,$timeout) {
    $scope.userName = "";
    $scope.imageUrl = "../../Content/images/profilepic.png";
    console.log($scope.imageUrl);
    $scope.user = {};
    $scope.userPreferences = "User Preferences";
    $scope.image = "x";
    

    $scope.user = {};

    $scope.quacks = [];

    quackService.getAllQuacks().then(function (data) {
        if (data && _.isArray(data)) {
            $scope.quacks = data;
        }
    });
    

    $scope.quacks = [];

    quackService.getAllQuacks().then(function (data) {
        if (data && _.isArray(data)) {
            $scope.quacks = data;            
        }
    });

    $scope.quacks = [];

    quackService.getAllQuacks().then(function (data) {
        if (data && _.isArray(data)) {
            $scope.quacks = data;            
        }
    });

    $scope.quacks = [];

    quackService.getAllQuacks().then(function (data) {
        if (data && _.isArray(data)) {
            $scope.quacks = data;            
        }
    });

    $scope.quacks = [];

    quackService.getAllQuacks().then(function (data) {
        if (data && _.isArray(data)) {
            $scope.quacks = data;            
        }
    });

    $scope.quacks = [];

    quackService.getAllQuacks().then(function (data) {
        if (data && _.isArray(data)) {
            $scope.quacks = data;            
        }
    });

    userService.getUser().then(function (user) {
        console.log(user);
        $scope.user = user;
        $scope.userName = user.FirstName;
        
        document.getElementById("mncss").setAttribute("src", "data:image/jpeg;base64," + user.CoverImage);
        
        console.log($scope.imageUrl);
        
    });

    $scope.saveQuack = function () {
        var quack = {};
        quack.id = 11;
        quack.userId = 12;
        quackService.saveQuack(quack);
    };
    
});