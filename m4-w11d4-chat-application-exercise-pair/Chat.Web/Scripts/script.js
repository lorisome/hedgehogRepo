/// <reference path="jquery-3.1.1.js" />
/// <reference path="chatService.js" />

$(document).ready(function () {

    //1. Write Javascript that will use AJAX to GET new messages without refreshing the entire page
    ///  GET api/rooms/{id}?sinceDate={sinceDate}    
    setInterval(function () {
        var id = $("#RoomId").val();
        var lastDate = $(".message").last().attr("data-date-time");
        //        var sinceDate = getLongJsonDate(lastDate);
        var service = new chatService(websiteUrl);
        service.refreshMessages(id, lastDate, updateMessages)
    }, 5000);



    //2. Write Javascript that will use AJAX to POST a new message without refreshing the entire page
    ///  POST api/messages/
    ///  data: {
    ///     RoomId: #,
    ///     Username: string,
    ///     Message: string
    ///  }

    $("#newMessageButton").on("click", function (event) {
        event.preventDefault();
        var message = $("#Message").val();
        var id = $("#RoomId").val();
        var username = $("#Username").val();

        $("#Message").val("");

        var service = new chatService(websiteUrl);
        service.saveMessage(id, username, message, function (data) {

        });

    });
});

    function updateMessages(htmlData) {
        $("#messages").append(htmlData);

        //console.log(jsonData);
        //for (var i = 0; i < jsonData.Messages.length; i++) {

        //    var singleChat = $("<p>").text(jsonData.Messages[i].Username +
        //        " " + jsonData.Messages[i].SentDate + ": " + jsonData.Messages[i].Message);
        //    singleChat.addClass("message");
        //    singleChat.attr(data - date - time, jsonData.Messages[i].SentDate);
             
        //    $("#messages").append(singleChat);
        //}
    }




    /* KEEP THESE AND SHARE WITH STUDENTS */
    function getShortJsonDate(date) {
        var dateObj = new Date(parseInt(date.substring(6)));      
        return dateObj.toLocaleDateString() + " " + dateObj.toLocaleTimeString();
    }

    function getLongJsonDate(date) {
        var dateObj = new Date(parseInt(date.substring(6)));

        return dateObj.getMonth()+1 + "/" + 
            dateObj.getDate() + "/" +
            dateObj.getFullYear() + " " +
            dateObj.getHours() + ":" +
            dateObj.getMinutes() + ":" +
            dateObj.getSeconds() + "." +
            dateObj.getMilliseconds();
    }
