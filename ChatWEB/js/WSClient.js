var socketUrl = "ws://localhost:62935/Server.ashx";
var client;
var Imya;
var Status;
var ActiveDialog = "nothin";
var DialogToSend = "nothin";
        var div_autoriz ;
        var div_bestchat ;
        var div_chat ;
        var div_singup ;
        var div_forgotpassword;
        var div_login ;
        var div_Users;
        var div_AllDialogs;
        var div_MyDialogs;
        var div_CreateDialog;
        var div_ChangePass;

        var menuOnlineUsers;
        var menuCreateDialog;
        var menuAllDialogs;
        var menuMyDialogs;
        var menuLogOut;
        var menuChangePassword;

        var listOfUsers;
        var listOfDialogs;
        var listOfMyDialogs;

        var btnInvite;
        var btnCreateDialog;
        var btnShow_Dialog;
        var btn_ToComeIn;
        var btn_Private;
        var btn_SendEmailPass;
        var btn_SignUp;
        var btn_DeleteDialog;
        var btn_ChangePass;

        var t_ForgotPass;
        var t_LogIn;
        var t_SignUp;

window.addEventListener("load", function () {

        div_autoriz = document.getElementById("Authoriz");
        div_bestchat = document.getElementById("BestChat");
        div_chat = document.getElementById("divChat");
        div_singup = document.getElementById("divSignUp");
        div_forgotpassword = document.getElementById("divForgotPass");
        div_login = document.getElementById("divLogIn");
        div_AllDialogs = document.getElementById("divAllDialogs");
        div_MyDialogs = document.getElementById("divMyDialogs");
        div_Users = document.getElementById("divUsers");
        div_CreateDialog = document.getElementById("divCreateDialog");
        div_ChangePass = document.getElementById("divChangePass");


        menuOnlineUsers = document.getElementById("menuOnlineUsers");
        menuCreateDialog = document.getElementById("menuCreateDialog");
        menuAllDialogs = document.getElementById("menuAllDialogs");
        menuMyDialogs = document.getElementById("menuMyDialogs");
        menuLogOut = document.getElementById("menuLogOut");
        menuChangePassword = document.getElementById("menuChangePassword");

        listOfUsers = document.getElementById("listOfUsers");
        listOfDialogs = document.getElementById("listOfDialogs");
        listOfMyDialogs = document.getElementById("listOfMyDialogs");

        btnInvite = document.getElementById("btnInvite");
        btnCreateDialog = document.getElementById("btnCreateDialog");
        btnShow_Dialog = document.getElementById("btnShow_Dialog");
        btn_ToComeIn = document.getElementById("btnToComeIn");
        btn_Private = document.getElementById("btnPrivate");
        btn_SendEmailPass = document.getElementById("btnSendEmailPass");
        btn_SignUp = document.getElementById("btnSignUp");
        btn_DeleteDialog = document.getElementById("btnExit_Dialog");
        btn_ChangePass = document.getElementById("btnChangePass");

        t_ForgotPass = document.getElementById("tForgotPass");
        t_LogIn = document.getElementById("tLogIn");
        t_SignUp = document.getElementById("tSignUp");

    client = new WebSocket(socketUrl);
    client.onopen = onClientOpened;
    client.onmessage = onClientMessage;
    var btnSendMessage = document.getElementById("btnSendMessage");
    var btnLogin = document.getElementById("btnLogIn");
    var btnSignUp = document.getElementById("btnSignUp");

    btnLogin.addEventListener("click", function () {
        var txtLogin = document.getElementById("txtLI_login");
        var txtPassword = document.getElementById("txtLI_pass");
        client.send("{'Action': 'Authorization', 'Login':'" + txtLogin.value + "' , 'Role': 'User', 'NameDialog':'"+ txtPassword.value+"', 'Message': '*'}");
    });
    


    btnSignUp.addEventListener("click", function () {
        ddd.create();
    });

    btnInvite.addEventListener("click", function(){
        InviteInDialog();
    });

    menuMyDialogs.addEventListener("click", function(){
        Show_My_Dialogs();
    });

    menuOnlineUsers.addEventListener("click", function(){
        document.getElementById("listOfUsers").options.length = 0;
        ShowOnlineUsers(Imya);
        Show_Online();
    });

    menuAllDialogs.addEventListener("click", function(){
        document.getElementById("listOfDialogs").options.length = 0;
        ShowAllDialogs(Imya);
        Show_All_Dialog();
    });

    menuCreateDialog.addEventListener("click", function(){
        Show_Create();
    });

    menuLogOut.addEventListener("click", function(){
        LogOut(Imya);
        ReturnToMainPage();
        client = new WebSocket(socketUrl);
        client.onopen = onClientOpened;
        client.onmessage = onClientMessage;
        LogOut_DeleteAll();
    });

    menuChangePassword.addEventListener("click", function(){
        div_ChangePass.style.display = 'block';
    });

    btnCreateDialog.addEventListener("click", function(){
        if(!Status)
        {
            var txt = document.getElementById("txtNameOfDialogCreated");
            CreateDialog(txt.value, "Public");
            CreateDialogServer(Imya,txt.value);
            div_CreateDialog.style.display = 'none';
            txt.value = "";
        }
        else
        {
            alert("You are banned from this server =(");
        }
    });

    btnShow_Dialog.addEventListener("click", function(){
        ShowDialog();
    });

    btn_DeleteDialog.addEventListener("click", function(){
        var List = document.getElementById("listOfMyDialogs");
        var n = List.options.selectedIndex;
        var txt = List.options[n].text;
        CloseDialog(txt, Imya);
        var dialog = "dialogView"+txt;
        var el = document.getElementById(dialog);
        el.parentNode.removeChild(el);
        List.remove(List.selectedIndex);
    });

    btn_ToComeIn.addEventListener("click", function(){
        var n = document.getElementById("listOfDialogs").options.selectedIndex;
        var txt = document.getElementById("listOfDialogs").options[n].text;
        ToComeIn_TheDialog(txt, Imya);
        CreateDialog(txt, "Public");
    });

    btn_Private.addEventListener("click", function(){
        var n = document.getElementById("listOfUsers").options.selectedIndex;
        var txt = document.getElementById("listOfUsers").options[n].text;
        CreateDialog(txt, "Private");
    });

    btn_ChangePass.addEventListener("click", function(){
        var txrOldPass = document.getElementById("txtCP_OldPass");
        var txtNewPass = document.getElementById("txtCP_NewPass");
        ChangePassword(Imya, txtNewPass.value);
        div_ChangePass.style.display = 'none';
        txrOldPass.value = "";
        txtNewPass.value = "";
    });

    btn_SendEmailPass.addEventListener("click", function(){
        var tLogin = document.getElementById("txtFP_login");
        var tMail = document.getElementById("txtFP_email");
        if(tMail.value!="" || tLogin.value!="")
        {
            ForgotPassword(tLogin.value, tMail.value);
            tLogin.value = "";
            tMail.value = "";
            ReturnToMainPage();
            alert("Check your mail, we send your password to you!");
        }
    });

    btn_SignUp.addEventListener("click", function(){
        var tName = document.getElementById("txtSUP_name");
        var tLogin = document.getElementById("txtSUP_login");
        var tPass = document.getElementById("txtSUP_pass");
        SignUpOnServer(tName.value, tLogin.value, tPass.value);
        tName.value = "";
        tLogin.value = "";
        tPass.value = "";
        ReturnToMainPage();
        alert("Registration succces!");
    });

    t_ForgotPass.addEventListener("click", function(){
        ForgotPass();
    });

    t_LogIn.addEventListener("click", function(){
        ReturnToMainPage();
    });

    t_SignUp.addEventListener("click", function(){
        Show_SignUp();
    });

});

function onClientOpened(){
    alert("JS Client Opened!!!");
}

function onClientMessage(event) 
{
    var content = JSON.parse(event.data);
    var Authorization = document.getElementById("Authorization");
    var Chat = document.getElementById("room");
    var Dialogs = document.getElementById("tableDialogs");

    switch(content.Action)
    {
        case "Authorization"   : if (content.Login != "Not registred") { GoChat("Authorization"); Imya = content.NameDialog; } BanOrNot(content.Message);              break;
        case "SignUP"          : break;
        case "Invite"          : InviteToMe(content.NameDialog);                                                                                                       break;
        case "SendMessage"     : TakeMessage(content.Login,content.NameDialog,content.Message); Push("You have a new message in dialog "+content.NameDialog);          break;
        case "ShowOnlineUsers" : OnlineUsers(content.Message);                                                                                                         break;
        case "ShowAllDialogs"  : AllDialogs(content.Message);                                                                                                          break;
        case "PrivatMessage"   : PrivateDialog(content.NameDialog, content.Message);                                                                                   break;
        case "Banned"          : BanOrNot("True");                                                                                                                     break;
        case "Unbaned"         : BanOrNot("False");                                                                                                                    break;
        case "ChangePassword"  : alert("Your password has been changed" , "Succes");                                                                                   break;
    }
}

    function GoChat(str)
    {
        div_autoriz.style.display = 'none';
        div_bestchat.style.display = 'block';
        div_chat.style.display = 'block';
        div_singup.style.display = 'none';
        div_forgotpassword.style.display = 'none';
        div_login.style.display = 'none';
    }

function BanOrNot(check)
{
    if(check=="True")
    {
        Status = true;
    }

    else if(check="False")
    {
        Status = false;
    }
}

function TakeMessage(senderLogin,nameDialog, message) 
{
        var dialog = "listOfMessages"+nameDialog;
        var listOfMessage = document.getElementById(dialog);
            listOfMessage.options[listOfMessage.options.length] = new Option("["+senderLogin+"] : "+message, "значение");
}

function Show_Create()
{
    div_Users.style.display = 'none';
    div_AllDialogs.style.display = 'none';
    div_MyDialogs.style.display = 'none';
    div_CreateDialog.style.display = 'block';
}

function Show_My_Dialogs()
{
    div_Users.style.display = 'none';
    div_AllDialogs.style.display = 'none';
    div_CreateDialog.style.display = 'none';
    div_MyDialogs.style.display = 'block';
}

function Show_All_Dialog()
{
    div_Users.style.display = 'none';
    div_CreateDialog.style.display = 'none';
    div_AllDialogs.style.display = 'block';
    div_MyDialogs.style.display = 'none';
}

function Show_Online()
{
    div_Users.style.display = 'block';
    div_AllDialogs.style.display = 'none';
    div_MyDialogs.style.display = 'none';
    div_CreateDialog.style.display = 'none';
}

function ReturnToMainPage()
{
        div_autoriz.style.display = 'block';
        div_bestchat.style.display = 'none';
        div_chat.style.display = 'none';
        div_singup.style.display = 'none';
        div_forgotpassword.style.display = 'none';
        div_login.style.display = 'block';
}

function ForgotPass()
{
        div_autoriz.style.display = 'block';
        div_bestchat.style.display = 'none';
        div_chat.style.display = 'none';
        div_singup.style.display = 'none';
        div_forgotpassword.style.display = 'block';
        div_login.style.display = 'none';
}

function Show_SignUp()
{
        div_autoriz.style.display = 'block';
        div_bestchat.style.display = 'none';
        div_chat.style.display = 'none';
        div_singup.style.display = 'block';
        div_forgotpassword.style.display = 'none';
        div_login.style.display = 'none';
}

function ShowDialog()
{   
    var n = document.getElementById("listOfMyDialogs").options.selectedIndex;
    var txt = document.getElementById("listOfMyDialogs").options[n].text;
    var dialog = "dialogView"+txt;
    var tabPage = document.getElementById("tabPages");
    if (tabPage.hasChildNodes()) 
    {
        var children = tabPage.childNodes;
    }
        for (var i = 0; i < children.length; i++) 
        {
            if(children[i].id == dialog)
            {
                children[i].style.display = 'block';
            }
            else if(children[i].id == ActiveDialog)
            {
                children[i].style.display = 'none';
            }
        }
        ActiveDialog = dialog;
        DialogToSend = txt;
}

function LogOut_DeleteAll()
{
    var tabPage = document.getElementById("tabPages");
    if (tabPage.hasChildNodes()) 
    {
        var children = tabPage.childNodes;
    }
        for (var i = 0; i < children.length; i++) 
        {
           var el = document.getElementById(children[i].id);
           el.parentNode.removeChild(el);
        }
    document.getElementById("listOfDialogs").options.length = 0;
    document.getElementById("listOfUsers").options.length = 0;
    document.getElementById("listOfMyDialogs").options.length = 0;

}

function AllDialogs(dialogs)
{
        var dialog = dialogs.split(';');
        for(var i=0; i < dialog.length; i++)
        {
            listOfDialogs.options[listOfDialogs.options.length] = new Option(dialog[i], dialog[i]);
        }
}

function OnlineUsers(users)
{
        var user = users.split(';');
        for(var i=0; i < user.length; i++)
        {
            listOfUsers.options[listOfUsers.options.length] = new Option(user[i], user[i]);
        }
}

function InviteToMe(nameDialog)
{
    Push("You was invited to dialog "+nameDialog);
    CreateDialog(nameDialog, "Public");
}

function InviteInDialog()
{
    var n = document.getElementById("listOfUsers").options.selectedIndex;
    var txt = document.getElementById("listOfUsers").options[n].text;
    InviteToDialog(txt, DialogToSend);
}

function Push(message) 
{
    alert(message);
}

function PrivateDialog(nameDialog, message)
{
    var dialog = "dialogView"+nameDialog;
    var tabPage = document.getElementById("tabPages");
    if (tabPage.hasChildNodes()) {
        var children = tabPage.childNodes;
        }
        for (var i = 0; i < children.length; i++)
        {
            if(children[i].id == dialog)
            {
                TakeMessage(nameDialog,nameDialog,message);
                Push("You have a new message from "+ nameDialog);
                return 0;
            }
        }
        CreateDialog(nameDialog, "Private");
        TakeMessage(nameDialog, nameDialog, message);
}

function CreateDialog(nameDialog, priv)
    {
        var tabPage = document.getElementById("tabPages");
        var dialog = document.createElement('div');
        dialog.id = "dialogView"+nameDialog;
        dialog.value = "nameDialog";
        dialog.style.display = 'none';
        dialog.className = 'uk-animation-scale-up';
        tabPage.appendChild(dialog);
        var messageView = document.createElement('select');
        messageView.id ="listOfMessages"+nameDialog;
        messageView.style.width = '900px';
        messageView.style.height = '420px';
        messageView.name = priv;
        messageView.size="400";
        dialog.appendChild(messageView);
        var br = document.createElement('br');
        dialog.appendChild(br);
        var messageWriter = document.createElement('input');
        messageWriter.type="text";
        messageWriter.id="txtMessagee"+nameDialog;
        messageWriter.style.width = '800px';
        messageWriter.style.height = '50px';
        dialog.appendChild(messageWriter);
        var btnSend = document.createElement('button');
        btnSend.style.width = '100px';
        btnSend.style.height = '50px';
        btnSend.id="btnSendMessage"+nameDialog;
        btnSend.addEventListener('click', function(){MessageMaker(messageWriter.id,messageView.id, messageView.name);});
        btnSend.innerHTML = 'Send';
        dialog.appendChild(btnSend);

        listOfMyDialogs.options[listOfMyDialogs.options.length] = new Option(nameDialog, "значение");
    }

function MessageMaker(messageBox, viewBox, isPrivate) 
{
    var txtM = document.getElementById(messageBox);
    var vi = document.getElementById(viewBox);
    vi.options[vi.options.length] = new Option("["+Imya+"] : "+txtM.value, "значение");
    if(isPrivate=="Public")
    {
        SendMessageToDialog(DialogToSend, Imya, txtM.value);
    }
    else if(isPrivate=="Private")
    {
        SendPrivateMessage(Imya, DialogToSend, txtM.value);
    }
}

function SignUpOnServer(name, login, password)
{
    client.send("{'Action': 'SignUP', 'Login':'" + name + "' , 'Role': 'User', 'NameDialog':'" + login + "', 'Message': '" + password + "'}");
}

function InviteToDialog(nameUsers, dialog)
{
    client.send("{'Action': 'Invite', 'Login':'" + nameUsers + "' , 'Role': 'User', 'NameDialog':'" + dialog + "', 'Message': '*'}");
}

function SendPrivateMessage(login, takerLogin, sms)
{
    client.send("{'Action': 'PrivatMessage', 'Login':'" + login + "' , 'Role': 'User', 'NameDialog':'" + takerLogin + "', 'Message': '"+sms+"'}");
}

function SendMessageToDialog( dialog, login, sms)
{
    if(!Status)
        client.send("{'Action': 'SendMessage', 'Login':'" + login + "' , 'Role': 'User', 'NameDialog':'" + dialog + "', 'Message': '"+sms+"'}");
    else
        alert("You are banned from this server =(");
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

function CreateDialogServer(login, nameDialod)
{
    client.send("{'Action': 'CreateDialog', 'Login':'" + login + "' , 'Role': 'User', 'NameDialog':'" + nameDialod + "', 'Message': '*'}");
}

function LogOut(login)
{
    client.send("{'Action': 'LogOut', 'Login':'" + login + "' , 'Role': 'User', 'NameDialog':'*', 'Message': '*'}");
}

function ForgotPassword(login, email)
{
    client.send("{'Action': 'ForgotPassword', 'Login':'" + login + "' , 'Role': 'User', 'NameDialog':'*', 'Message': '"+email+"'}");
}

function ChangePassword(login ,newPass)
{
    client.send("{'Action': 'ChangePassword', 'Login':'" + login + "' , 'Role': 'User', 'NameDialog':'*', 'Message': '"+newPass+"'}");
}