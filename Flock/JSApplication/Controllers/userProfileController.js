'use strict';

flockApp.controller('userProfileController', function ($scope, $location, userService, quackService) {    

    var self = this;

    self.location = $location.absUrl();
    $scope.userName = self.location.substr(self.location.indexOf("=") + 1, self.location.length)

    initialize();   
    function initialize() {
        userService.getUserByUserName($scope.userName).then(function (userDto) {
            var user = {};
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.EmailId = userDto.EmailId;
            user.Project = userDto.Project;
            user.Interests = userDto.Interests;
            user.CoverImage = "data:image/jpeg;base64," + userDto.CoverImage;
            user.ProfileImage = "data:image/jpeg;base64," + userDto.ProfileImage;
            $scope.userProfile = user;

        }, function(errorInfo){
            console.log(errorInfo);
            throw new Error(errorInfo);
        })};    
});