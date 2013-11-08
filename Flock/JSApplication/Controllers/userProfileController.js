'use strict';

flockApp.controller('userProfileController', function ($scope, $location, userService, quackService, sessionFactory) {    

    var self = this;

    /*if (sessionFactory.user) {
        self.lastName = sessionFactory.user.lastName;
        self.firstName = sessionFactory.user.firstName;
    }*/

    //TODO: Bad code need to use factory for sharing data between controllers
    self.location = $location.absUrl();

    var getParamLength = function (param, paramValue) {
        if (param.indexOf("&", param.indexOf(paramValue)) >= 0) {
            return (param.indexOf("&", param.indexOf(paramValue))-(param.indexOf(paramValue)+paramValue.length));
        } else {
            param.length;
        }
    };

    self.firstName = self.location.substr(self.location.indexOf("firstName=") + ("firstName=".length), getParamLength(self.location, "firstName="));
    self.lastName = self.location.substr(self.location.indexOf("lastName=") + ("lastName=".length), getParamLength(self.location, "lastName="));

    initialize();   
    function initialize() {
        userService.getUserByUserName(self.lastName, self.firstName).then(function (userDto) {
            var user = {};
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.EmailId = userDto.EmailId;
            user.Project = userDto.Project;
            user.Interests = userDto.Interests;
            user.CoverImage = "data:image/jpeg;base64," + userDto.CoverImage;
            user.ProfileImage = "data:image/jpeg;base64," + userDto.ProfileImage;
            $scope.userProfile = user;

        }, function (errorInfo) {
            throw new Error(errorInfo);
        });
    }

    
});