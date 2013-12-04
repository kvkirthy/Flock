'use strict';

flockApp.controller('postImageQuackController', function ($scope, userService, quackService, $timeout) {
    
    $scope.quackPicImageSource = "";
    $scope.showQuackPictureModalErrorMessage = false;
    //$timeout(function () {
    //    $scope.profilePicImageSource = $scope.profilePicimageUrl;
    //}, 2000);


    var readUrl = function (input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                //var userImage = {};
                //userImage.sourceUrl = e.target.result;
                //userImage.action = "postImageQuack";
                //userService.uploadImage(userImage).then(function (data) {

                    //if (data.Message == "true") {
                        $scope.showPictureModalErrorMessage = false;
                        $('#uplodedQuackPicture').attr('src', e.target.result);
                        $scope.quackPicImageSource = e.target.result;
                       
                    //}
                    //else {
                    //    $scope.showPictureModalErrorMessage = true;
                    //    $timeout(function () {
                    //        $scope.showPictureModalErrorMessage = false;
                    //    }, 4000);
                    //}
                //});
            };
            reader.readAsDataURL(input.files[0]);
        }
    };

    $("#UploadQuackPic").change(function () {
     
        readUrl(this);
    });


    $scope.saveImageQuack = function () {
        
        $scope.disableQuackImageMessage = true;
        var quack = {};
        quack.userId = $scope.user.ID;
        quack.parentQuackId = null;
        quack.quackTypeId = 1;
        quack.quackContent = {};
        quack.quackContent.messageText = $scope.imageQuackMessageContent;
        quack.quackContent.imageUrl = $scope.quackPicImageSource;
        
        if ($scope.imageQuackMessageContent && $scope.imageQuackMessageContent!= "") {
            quackService.saveQuack(quack).then(function () {
                $scope.replyMode = false;
                $scope.refreshQuacks();
                $scope.imageQuackMessageContent = "";
                $scope.disableQuackImageMessage = false;
                $('#postImageQuack').hide();
            });
    
        }
        else {
            $scope.disableQuackImageMessage = false;
            $scope.showQuackPictureModalErrorMessage = true;
            $timeout(function () {
                $scope.showQuackPictureModalErrorMessage = false;
            }, 4000);
            return false;
        }
        
    };

});