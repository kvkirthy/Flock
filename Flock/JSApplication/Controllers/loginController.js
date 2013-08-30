flockApp.controller('loginController', function($scope, loginService, $window) {
    loginService.isExistingUser().then(function (data) {
        // when project is successfull
        $window.location='/home/index';
    }, function (data) {
        // when promise was rejected
        $window.location = '/home/register';
    });
});