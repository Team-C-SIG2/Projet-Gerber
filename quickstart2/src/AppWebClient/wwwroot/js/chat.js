"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message, date) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " dit : " + msg + " à " + date;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").textContent;
    var message = document.getElementById("messageInput");
    if (message.value.length == 0) {
        document.getElementById("messageInput")[0].placeholder = 'no content';
        //message.value = "Veuillez remplir le champ";
    }
    else {
        message = document.getElementById("messageInput").value;
    }
    var date = document.getElementById("dateInput").value;
    connection.invoke("SendMessage", user, message, date).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});