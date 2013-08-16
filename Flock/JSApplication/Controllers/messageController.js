flockApp.controller('messageController', function ($scope, messageService) {
    
    $scope.messages = [];
     messageService.getAllMessages().then(function (data) {
         $scope.messages = data;
    });
});