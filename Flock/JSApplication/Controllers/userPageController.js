'use strict';

flockApp.controller('userPageController', function ($scope , userService) {
    $scope.user = {};

    userService.getUser().then(function (user) {
        $scope.user = user;
        console.log($scope.user.FirstName);
    });
    
});