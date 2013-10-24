'use strict';

flockApp.controller('userProfileController', function ($scope, userService, quackService) {
    $scope.userProfile = {};
    $scope.userProfile.FirstName = "User First Name";
    $scope.userProfile.LastName = "User Last Name";
    $scope.userProfile.EmailId = "User EmailId";
    $scope.userProfile.Project = "User Project";
    $scope.userProfile.Interests = "User Interests";

    $scope.viewUserProfile = function ($scope, userService, quackService) {
        alert("Iam in view profile function");

    };
});