
'use strict';

flockApp.controller('userInfoController', function ($scope, userService, quackService) {
    $scope.userProject = "";
    $scope.userInterest = "";

    $scope.$on('userInfoController.showUserInformation', function () {
        $scope.userPreferences = angular.copy($scope.user);
        if($scope.userProject=="" )
            $scope.userProject = $scope.userPreferences.Project;
        if($scope.userInterest=="" )
         $scope.userInterest = $scope.userPreferences.Interests;
    });

    $scope.userPreferences = {};
    $scope.savePreferences = function () {
        $scope.userPreferences.Project = $scope.userProject;
        $scope.userPreferences.Interests = $scope.userInterest;

        userService.updateUserPreferences($scope.userPreferences).then(function () {
            $scope.userPreferences.Project = $scope.userProject;
            $scope.userPreferences.Interests = $scope.userInterest;
        });
    };

});