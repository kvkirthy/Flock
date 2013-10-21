'use strict';

flockApp.controller('uploadProfileImageController', function ($scope, userService, quackService, $timeout) {
    $scope.showPictureModalErrorMessage = false;
    $scope.showPictureSave = false;
    $scope.profilePicImageSource = "";

    $timeout(function () {
        $scope.profilePicImageSource = $scope.profilePicimageUrl;
    }, 2000);


    var readUrl = function (input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                var userImage = {};
                userImage.sourceUrl = e.target.result;
                userImage.action = "VerifyProfilePic";
                userService.uploadImage(userImage).then(function (data) {

                    if (data.Message == "true") {
                        $scope.showPictureModalErrorMessage = false;
                        $('#uplodedProfilePic').attr('src', e.target.result);
                        $scope.profilePicImageSource = e.target.result;
                        $scope.showPictureSave = true;
                    }
                    else {
                        $scope.showPictureModalErrorMessage = true;
                        $timeout(function () {
                            $scope.showPictureModalErrorMessage = false;
                        }, 4000);
                    }
                });
            };
            reader.readAsDataURL(input.files[0]);
        }
    };

    $("#imgUploadProfilePic").change(function () {
        readUrl(this);
    });


    $scope.saveProfileImage = function () {
        var userImage = {};
        userImage.sourceUrl = $scope.profilePicImageSource;
        userImage.action = "SaveProfilePic";
        userImage.userId = $scope.user.ID;
        $scope.userProfilePicUrl = $scope.profilePicImageSource;
        $("#userProfilePic").attr("src", $scope.profilePicImageSource);
        userService.uploadImage(userImage).then(function () {
            $scope.replyMode = false;
            $scope.refreshQuacks();
        });
    };
   
});