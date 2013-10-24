
'use strict';

flockApp.controller('userInfoController', function ($scope, userService, quackService) {

    $scope.userPreferences = {};

    $scope.savePreferences = function () {
        console.log($scope.userPreferences);
        userService.saveUserDetails($scope.userPreferences).then(function () {
        });
    };

});