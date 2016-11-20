/// <reference path="jquery-3.1.1.js" />
function chatService(baseUrl) {
    
    this.refreshMessages = function (id, sinceDateTimeValue, successCallback) {

        $.ajax({
            url: baseUrl + "messages/newMessages/" + id,
            data: {
                sinceDate: sinceDateTimeValue
            },
            type: "GET",
            dataType:"html"
        }).done(function (htmlData) {
            successCallback(htmlData);
        }).fail(function (statusCode, xhr, error) {
            console.log(error);
        });
    }

    this.saveMessage = function (id, username, message, successCallback) {
        $.ajax({
            url: baseUrl + "api/messages/",
            data: {
                RoomId: id,
                Username: username,
                Message: message
            },
            type: "POST",
            dataType: "json"
        }).done(function (jsonData) {
            successCallback(jsonData);
        }).fail(function (statusCode, xhr, error) {
            console.log(error);
        });
    }


}