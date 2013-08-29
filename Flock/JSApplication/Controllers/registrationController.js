flockApp.controller("registrationController", ['$scope', 'registrationService', function ($scope, registrationService) {
    $scope.profile = {
        firstName: { label: 'First Name', value: null },
        lastName: { label: 'Last Name', value: null },
        project: { label: 'Project', value: null },
        interests: { label: 'Interests', value: null }
    };
    $scope.statusMessages = [];

    $scope.register = function () {
        $scope.statusMessages = [];
        for (var prop in $scope.profile) {
            if ($scope.profile.hasOwnProperty(prop)) {

                if (!$scope.profile[prop].value) {
                    $scope.statusMessages.push($scope.profile[prop].label + ' is required.\n');
                }
            }
        }
        if ($scope.statusMessages.length === 0) {
            registrationService.registerUser($scope.profile.firstName.value,
                $scope.profile.lastName.value,
                $scope.profile.project.value,
                $scope.profile.interests.value).then(function () {
                    $scope.statusMessages.push('Registered');
                }, function (error) {
                    $scope.statusMessages.push('Registration failed. ' + error.Message);
                });
        }
    };
}]);