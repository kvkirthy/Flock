//TODO: This controller should be in real controllers folder?
flockApp.controller('autoUpdateUserTagsController', function ($scope, searchService) {

    //TODO: enter should support server search.
    searchService.getAllUserTags()
        .then(function (result) {
            $scope.users = result;
        },function (result) {
        throw new Error(result);
    });

    $scope.users = []; 
    $scope.quackText = "";

    $scope.$on('userSelectedForTag', function (event, textInQuestion, selectedTag) {        
        if (textInQuestion && selectedTag) {
            $scope.quackText = $scope.quackText.replace(textInQuestion, '@' + selectedTag);
        }
    });

    $scope.$watch('quackText', function (param) {
        $scope.$emit('quackTextChanged', $scope.quackText);
    });
});

flockApp.directive('autoUpdateUserTags', function () {
    return {
        restrict: 'A',
        require: '^autoUpdateUserTagsController',
        templateUrl: '/JSApplication/Templates/autoUpdateUserTagsDirectiveTemplate.html',
        scope: {
            listOfUsers: '='            
        }, 
        controller: function ($rootScope, $scope) {
            var self = this;            
            self.scope = $scope;
            $scope.isNewUserTagAttempted = false;
            self.textInQuestionForTag = "";

            $scope.selectUser = function (user) {
                $scope.$emit('userSelectedForTag', self.textInQuestionForTag, user);
            };

            $rootScope.$on('quackTextChanged', function (event, quackText) {
                $scope.filteredUsers = [];                
                if (quackText && quackText.indexOf('@') >= 0) {

                    if (quackText.lastIndexOf('@') === (quackText.length - 1)) {
                        self.scope.isNewUserTagAttempted = true;
                    }

                    if (self.scope.isNewUserTagAttempted && (quackText.lastIndexOf('@') !== (quackText.length - 1)) && quackText.lastIndexOf(' ') === (quackText.length - 2)) {
                        self.scope.isNewUserTagAttempted = false;
                    }
                    
                    if (self.scope.isNewUserTagAttempted) {
                        self.textInQuestionForTag = quackText.substring(quackText.lastIndexOf('@'), quackText.length);
                    }

                    var textFieldValue = self.textInQuestionForTag.slice(1);
                    if (textFieldValue) {
                        //TODO: implement "more" option to show all tags?
                        _.find(_.last(self.scope.listOfUsers, 10), function (aUser) {
                            if (aUser.toLowerCase().indexOf(textFieldValue.toLowerCase()) === 0) {
                                self.scope.filteredUsers.push(aUser);
                            }
                        });
                    }
                }
            });
        }        
    };
});