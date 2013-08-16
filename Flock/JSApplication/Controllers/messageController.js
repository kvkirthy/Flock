flockApp.controller('messageController', function ($scope, messageService) {
    
    $scope.messages = [];
    $scope.messages = messageService.getAllMessages();
});