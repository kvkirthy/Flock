'use strict';

flockApp.controller('userProfileController', function ($scope, $location, $window, userService, quackService, sessionFactory) {    

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

    $scope.setQuackId = function (quackId, likes) {
        $scope.userLikeQuackId = quackId;
        $scope.$broadcast('quackUserLikesController.showUserLikes');
    };

    initialize();   
    function initialize() {
        userService.getUserByUserName(self.lastName, self.firstName).then(function (userDto) {
            var user = {};
            if (userDto && userDto != "null") {
                
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.EmailId = userDto.EmailId;
                user.Project = userDto.Project || 'Project information unavailable';
                user.Interests = userDto.Interests || 'Interests information unavailable';
                if (userDto.CoverImage) {
                    user.CoverImage = "data:image/jpeg;base64," + userDto.CoverImage;
                }
                else {
                    user.CoverImage = "/Content/images/defaultCoverPic.png";
                }

                if (userDto.ProfileImage) {
                    user.ProfileImage = "data:image/jpeg;base64," + userDto.ProfileImage;
                }
                else {
                    user.ProfileImage = "/Content/images/profilepic.png";
                }
            } else {
                $scope.errorMessage = "Apologies, no user found with given information. (" + self.firstName  + " " + self.lastName + ")" ;                
            }

            $scope.userProfile = user;

        }, function (errorInfo) {
            throw new Error(errorInfo);
        });

        quackService.getQuacksByFirstNameAndLastName(self.firstName, self.lastName).then(function (quacks) {
            $scope.quacks = quacks
        }, function (errorInfo) {
            throw new Error(errorInfo);
        });

    }

    $scope.$on('userTagSelected', function (event, data) {
        data.firstName = (data.firstName || "").split("@")[1]; // purpose: remove @ from first name
        sessionFactory.user = data;
        $window.open('/UserView/index?firstName=' + data.firstName + "&lastName=" + data.lastName, lastName + firstName)
    });

    
});