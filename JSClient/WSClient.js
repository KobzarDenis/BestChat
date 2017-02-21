var socketUrl = "ws://localhost:62935/Server.ashx";
var client;
var Imya;

window.addEventListener("load", function () {
    client = new WebSocket(socketUrl);
    client.onopen = onClientOpened;
    client.onmessage = onClientMessage;
    var btnSendMessage = document.getElementById("btnSendMessage");
    var btnLogin = document.getElementById("btnLogIn");
    var btnSignUp = document.getElementById("btnSignUp");
    var list = document.getElementById("listOfMessages");

    btnLogin.addEventListener("click", function () {
        var txtLogin = document.getElementById("txtLogin");
        var txtPassword = document.getElementById("txtPassword");

        client.send("{'Action': 'Authorization', 'Login':'" + txtLogin.value + "' , 'Role': 'User', 'NameDialog':'"+ txtPassword.value+"', 'Message': '*'}");
    });
    

    btnSendMessage.addEventListener("click", function () {
        var input = document.getElementById("txtMessage");
        list.options[list.options.length] = new Option("[" + Imya + "] :" + input.value, "значение");
        client.send("{'Action': 'PrivatMessage', 'Login':'" + Imya + "' , 'Role': 'User', 'NameDialog':'" + 'Антон' + "', 'Message': '" + input.value + "'}");
        input.value = "";
        create();
    });
});

function onClientOpened(){
    writeToDiv("JS Client Opened!!!");
}

function onClientMessage(event) {
    var content = JSON.parse(event.data);
    var Authorization = document.getElementById("Authorization");
    var Chat = document.getElementById("Chat");
    var Dialogs = document.getElementById("tableDialogs");
    if (content.Action == "Authorization")
    {
        if (content.Login != "Not registred")
        {
            Imya = content.NameDialog;
            var name = document.getElementById("name");
            Authorization.style.display = 'none';
            Chat.style.display = 'block';
        }
    }
    if (content.Action == "PrivatMessage")
    {
        TakeMessage(content.Login, content.Message);
    }
}

function TakeMessage(login, message)
{
    var list = document.getElementById("listOfMessages");
    list.options[list.options.length] = new Option("["+login+"]:"+message, "значение");
}

function writeToDiv(text) {
    alert(text);
}

function create() {

    document.getElementById("Chat").childNodes.style += "<p  >PIDOR</p>";

}

function SignUp(name, login, password)
{
    client.send("{'Action': 'SignUP', 'Login':'" + name + "' , 'Role': 'User', 'NameDialog':'" + login + "', 'Message': '" + password + "'}");
}

function InviteToDialog(nameUsers, dialog)
{
    client.send("{'Action': 'Invite', 'Login':'" + nameUsers + "' , 'Role': 'User', 'NameDialog':'" + dialog + "', 'Message': '*'}");
}

function SendMessage( dialog, login, sms)
{
    client.send("{'Action': 'SendMessage', 'Login':'" + login + "' , 'Role': 'User', 'NameDialog':'" + dialog + "', 'Message': '"+sms+"'}");
}

function CloseDialog(dialog, login)
{
    client.send("{'Action': 'CloseDialog', 'Login':'" + login + "' , 'Role': 'User', 'NameDialog':'" + dialog + "', 'Message': '*'}");
}

function  ToComeIn_TheDialog(dialog, login)
{
    client.send("{'Action': 'ToComeIn', 'Login':'" + login + "' , 'Role': 'User', 'NameDialog':'" + dialog + "', 'Message': '*'}");
}

function ShowAllDialogs(login)
{
    client.send("{'Action': 'ShowAllDialogs', 'Login':'" + login + "' , 'Role': 'User', 'NameDialog':'*', 'Message': '*'}");
}

function ShowOnlineUsers(login)
{
    client.send("{'Action': 'ShowOnlineUsers', 'Login':'" + login + "' , 'Role': 'User', 'NameDialog':'*', 'Message': '*'}");
}

function CreateDialog(login, nameDialod)
{
    client.send("{'Action': 'CreateDialog', 'Login':'" + login + "' , 'Role': 'User', 'NameDialog':'" + nameDialod + "', 'Message': '*'}");
}

function LogOut(login)
{
    client.send("{'Action': 'LogOut', 'Login':'" + login + "' , 'Role': 'User', 'NameDialog':'*', 'Message': '*'}");
}