'use strict';

flockApp.controller('userPageController', function ($scope , userService, quackService) {
    $scope.user = {};

    $scope.quacks = [];

    quackService.getAllQuacks().then(function (data) {
        if (data && _.isArray(data)) {
            $scope.quacks = data;
            console.log($scope.quacks);
        }
    });

    userService.getUser().then(function (user) {
        $scope.user = user;
    });

    $scope.saveQuack = function () {
        var quack = {};
        quack.id = 11;
        quack.userId = 12;
        quackService.saveQuack(quack);
    };
    
});