flockApp.service('messageService', function () {

    this.getAllMessages = function () {
        return [{
            message: "Sample message1 returned from the service",
            createDateTime: "Sample Date Time",
            createUserId: "sample User Id"
        }, {
            message: "Sample message1 returned from the service",
            createDateTime: "Sample Date Time",
            createUserId: "sample User Id"
        }, {
            message: "Sample message1 returned from the service",
            createDateTime: "Sample Date Time",
            createUserId: "sample User Id"
        }, {
            message: "Sample message1 returned from the service",
            createDateTime: "Sample Date Time",
            createUserId: "sample User Id"
        }
        ];
    };
});