
flockApp.directive('highlightTags', function ($compile, $rootScope) {
    return {
        controller: function ($scope) {            
            $scope.onLinkClick = function (firstName, lastName) {                
                $rootScope.$broadcast('userTagSelected', { lastName: lastName, firstName: firstName });
            };
        },
        require: 'ngModel',
        scope: {
            ngModel: '='
        },
        link: function (scope, element, attrs) {
            var createTags = function (message, callbackFunctionName) {
                var self = this;

                if (message) {
                    self.targetMessage = message;

                    var urlReg = new RegExp(/[\w]+:\/\/[\S]+/);
                    var urlTextArray = message.match(urlReg);

                    if (urlTextArray && _.isArray(urlTextArray)) {
                        _.each(urlTextArray, function (urlText) {
                            var urlLink = "<a target='_blank' href='" + urlText + "'>" + urlText + "</a>";
                            self.targetMessage = self.targetMessage.replace(urlText, urlLink);
                        });
                    }

                    if (self.targetMessage.indexOf('@') >= 0) {
                        //var allMatches = new RegExp(/@*.+:/).exec(message);
                        var allMatches = self.targetMessage.split(/@*:/);
                        _.each(allMatches, function (match) {
                            match = match.trim();
                            if (match.substring(0, 1) == "@") {
                                var names = match.split(" ");

                                var formattedWord = "<a href='' ng-click=onLinkClick('"+ names[0] +"','" + names[1] + "') style='color:steelblue; font-weight: bold'>" + match + "</a>";
                                self.targetMessage = self.targetMessage.replace(match, formattedWord);
                            }
                        });
                    }
                }
                return angular.element("<span>" + self.targetMessage + "</span>");
            }            

            var newElement = createTags(scope.ngModel, attrs.callbackFn);
            $compile(newElement)(scope);
           element.before(newElement);
            
           
        }
    };
});