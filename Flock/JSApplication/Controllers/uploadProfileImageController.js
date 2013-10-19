'use strict';

flockApp.controller('uploadProfileImageController', function ($scope, userService, quackService, $timeout) {
    $scope.showErrorMessage = false;
    $scope.showPreview = true;
    $scope.showSave = false;
    $scope.imageSource = "";
    $scope.coverPicImageSource = "";

    $timeout(function () {
        $scope.coverPicImageSource = $scope.imageUrl;
    }, 2000);

    $scope.imageSourceOriginal = "";


    var readUrl = function (input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {

                var userImage = {};
                userImage.sourceUrl = e.target.result;
                userImage.action = "VerifyCoverPic";
                userService.uploadImage(userImage).then(function (data) {

                    if (data.Message == "true") {
                        $scope.showErrorMessage = false;
                        $scope.imageSource = e.target.result;
                        $scope.imageSourceOriginal = e.target.result;
                        $('#uplodedPic').attr('src', e.target.result);
                        $scope.showPreview = true;
                        $scope.showSave = false;
                    } else {
                        $scope.showErrorMessage = true;

                        $timeout(function () {
                            $scope.showErrorMessage = false;
                        }, 3000);
                    }
                });
            };
            reader.readAsDataURL(input.files[0]);
        }
    };

    $('#uploadedPic').focusout(function () {
        $('#uplodedPic').imgAreaSelect({
            hide: true
        });
    });


    $("#imgProfilePic").change(function () {
        readUrl(this);
    });

    $scope.imagePreview = function () {
        var userImage = {};
        userImage.sourceUrl = $scope.imageSource;
        userImage.x = $("#X").val();
        userImage.y = $("#Y").val();
        userImage.width = $("#width").val();
        userImage.height = $("#height").val();

        //if (!(userImage.x == "" || userImage.y == "")) {
        userImage.action = "PreviewCoverPic";
        userService.uploadImage(userImage).then(function (data) {
            $("#uplodedPic").attr("src", "data:image/jpeg;base64," + data.Message);
            $scope.imageSource = "data:image/jpeg;base64," + data.Message;
            $scope.showPreview = false;
            $scope.showSave = true;
        });
        //}
    };

    $scope.saveImage = function () {
        var userImage = {};
        userImage.sourceUrl = $scope.imageSource;
        userImage.action = "SaveCoverPic";
        console.log($scope.user);
        userImage.userId = $scope.user.ID;
        $scope.imageUrl = $scope.imageSource;
        $("#userCoverPic").attr("src", $scope.imageUrl);
        userService.uploadImage(userImage).then(function (data) {
            $scope.showPreview = false;
            $scope.showSave = true;
            $scope.imageUrl = data.Message;
            $("#X").val(0);
            $("#Y").val(0);

        });
    };

    $scope.reset = function () {
        $("#uplodedPic").attr("src", $scope.imageSourceOriginal);
        $scope.imageSource = angular.copy($scope.imageSourceOriginal);
        $scope.showPreview = true;
        $scope.showSave = false;
        $("#X").val(0);
        $("#Y").val(0);
    };
});