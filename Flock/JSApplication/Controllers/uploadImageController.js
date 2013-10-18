'use strict';

flockApp.controller('uploadImageController', function ($scope, userService, quackService, $timeout) {
    $scope.showErrorMessage = false;
    $scope.showPreview = true;
    $scope.showSave = false;
    $scope.imageSource = "";
    

    var readUrl = function (input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {

                var userImage = {};
                userImage.sourceUrl = e.target.result;
                userImage.action = 0;
                userService.uploadImage(userImage).then(function (data) {
                    if (data == "true") {
                        $scope.showErrorMessage = false;
                        $scope.imageSource = e.target.result;
                        $('#uplodedPic').attr('src', e.target.result);
                        $('#url').val(e.target.result);
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

    $scope.user = {};
    $scope.userPreferences = "User Preferences";
    $scope.image = "x";


    $scope.imagePreview = function () {
        var userImage = {};
        userImage.sourceUrl = $scope.imageSource;
        userImage.x = document.getElementById("X").value;
        userImage.y = document.getElementById("Y").value;
        userImage.width = document.getElementById("width").value;
        userImage.height = document.getElementById("height").value;
        userImage.action = 1;
        
        userService.uploadImage(userImage).then(function (data) {
            document.getElementById("uplodedPic").setAttribute("src", "data:image/jpeg;base64," + data.Message);
            $scope.imageSource = "data:image/jpeg;base64," + data.Message;
            $scope.showPreview = false;
            $scope.showSave = true;
        });
    };
    
    $scope.saveImage = function () {
        var userImage = {};
        userImage.sourceUrl = $scope.imageSource;
        userImage.action = 2;
        $scope.imageUrl = $scope.imageSource;
        document.getElementById("mncss").setAttribute("src", $scope.imageUrl);
        console.log($scope.imageUrl);
        userService.uploadImage(userImage).then(function (data) {
            $scope.showPreview = false;
            $scope.showSave = true;
            $scope.imageUrl = data.Message;
            console.log(data);
        });
    };

});