
'use strict';

flockApp.controller('userInfoController', function ($scope, userService, quackService) {
    $scope.userPreferences = {};
    $scope.savePreferences = function () {
        userService.saveUserDetails($scope.userPreferences).then(function () {
           
        });
    };

});