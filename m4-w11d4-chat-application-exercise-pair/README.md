# Chat Application

## Prerequisites

Run the SQL script in the etc folder. Create a database called `chatroom` using your local SQL Server.

## Part 1 - Support AJAX Message Refresh

When the room view first loads, it shows all of the existing chat room messages. If another chat message is submitted while the view is up on your screen it will not be visible until
you reload the page.

**Implement asynchronous functionality that checks for new messages and refreshes the chat messages panel.**

You will need to call the REST endpoint http://domain.com/api/rooms/{id}?sinceDate={dateToCompareAgainst} 

This request will need to be passed two parameters
- `id` indicating which room you are getting the status for
- `sinceDate` indicating which datetime you want to use when checking for new messages

## Part 2 - Support AJAX POST

When the user submits a new chat message the form is submitted and the server processes the data using the post-redirect-get pattern causing the user to experience a full page 
reload. 

**Implement the ability to leverage AJAX and POST the new message without reloading the page.**

You will need to call the REST endpoint via POST http://domain.com/api/messages

This request will need to be passed three parameters
- `RoomId` indicating which room the new message is for
- `Username` indicating which user is posting the messaage
- `Message` indicating the body of the message

