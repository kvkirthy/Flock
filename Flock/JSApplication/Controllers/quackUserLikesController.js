'use strict';

flockApp.controller('quackUserLikesController', function ($scope, userService) {
    $scope.userLikes ={};

    $scope.$on('quackUserLikesController.showUserLikes', function () {
        userService.getUserLikesInfo($scope.userLikeQuackId).then(function (data) {
            if (data.length == 0) {
                $("#quackUserLikes").hide();
            }

            else {
                for (var i = 0; i < data.length; i++) {
                    if (!(data[i].UserPic) || data[i].UserPic == "") {
                        data[i].UserPic = "/Content/images/profilepic.png";
                    }
                    else {
                        data[i].UserPic = "data:image/jpeg;base64," + data[i].UserPic;
                    }
                }
                $scope.userLikes = data;
            }


        });
    });
   

});