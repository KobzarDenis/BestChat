function SignUpOnServer(name, login, password)
{
    client.send("{'Action': 'SignUP', 'Name':'"+name+"', 'Login':'" + login + "' , 'Password':'" + password + "', 'Role': 'User', 'NameDialog':'*', 'Message': '*'}");
}

function InviteToDialog(nameUsers, dialog)
{
    client.send("{'Action': 'Invite', 'Name':'*', 'Login':'" + nameUsers + "' , 'Password':'*', 'Role': 'User', 'NameDialog':'" + dialog + "', 'Message': '*'}");
}

function SendPrivateMessage(login, takerLogin, sms)
{
    client.send("{'Action': 'PrivatMessage', 'Name':'*', 'Login':'" + login + "' , 'Password':'*', 'Role': 'User', 'NameDialog':'" + takerLogin + "', 'Message': '"+sms+"'}");
}

function SendMessageToDialog( dialog, login, sms)
{
    if(!Status)
        client.send("{'Action': 'SendMessage', 'Name':'*', 'Login':'" + login + "' , 'Password':'*', 'Role': 'User', 'NameDialog':'" + dialog + "', 'Message': '"+sms+"'}");
    else
        alert("You are banned from this server =(");
}

function CloseDialog(dialog, login)
{
    client.send("{'Action': 'CloseDialog', 'Name':'*', 'Login':'" + login + "' , 'Password':'*', 'Role': 'User', 'NameDialog':'" + dialog + "', 'Message': '*'}");
}

function  ToComeIn_TheDialog(dialog, login)
{
    client.send("{'Action': 'ToComeIn', 'Name':'*', 'Login':'" + login + "' , 'Password':'*', 'Role': 'User', 'NameDialog':'" + dialog + "', 'Message': '*'}");
}

function ShowAllDialogs(login)
{
    client.send("{'Action': 'ShowAllDialogs', 'Name':'*', 'Login':'" + login + "' , 'Password':'*', 'Role': 'User', 'NameDialog':'*', 'Message': '*'}");
}

function ShowOnlineUsers(login)
{
    client.send("{'Action': 'ShowOnlineUsers', 'Name':'*', 'Login':'" + login + "' , 'Password':'*', 'Role': 'User', 'NameDialog':'*', 'Message': '*'}");
}

function CreateDialogServer(login, nameDialod)
{
    client.send("{'Action': 'CreateDialog', 'Name':'*', 'Login':'" + login + "' , 'Password':'*', 'Role': 'User', 'NameDialog':'" + nameDialod + "', 'Message': '*'}");
}

function LogOut(login)
{
    client.send("{'Action': 'LogOut', 'Name':'*', 'Login':'" + login + "' , 'Password':'*', 'Role': 'User', 'NameDialog':'*', 'Message': '*'}");
}

function ForgotPassword(login, email)
{
    client.send("{'Action': 'ForgotPassword', 'Name':'*', 'Login':'" + login + "' , 'Password':'*', 'Role': 'User', 'NameDialog':'*', 'Message': '"+email+"'}");
}

function ChangePassword(login ,newPass)
{
    client.send("{'Action': 'ChangePassword', 'Name':'*', 'Login':'" + login + "' , 'Password':'"+newPass+"', 'Role': 'User', 'NameDialog':'*', 'Message': '*'}");
}