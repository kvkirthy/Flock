'use strict';

flockApp.controller('userPageController', function ($scope , userService, quackService) {
    $scope.user = {};

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