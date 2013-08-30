flockApp.directive('setTitle', function () {
    return function (scope, element) {
        var users = JSON.stringify(scope.message.usersLiked).replace("[", "");
        users = users.replace("]", "");
        $(element).attr("title", users + " like this ");
    };
});