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

function GoChat(str)
    {
        div_autoriz.style.display = 'none';
        div_bestchat.style.display = 'block';
        div_chat.style.display = 'block';
        div_singup.style.display = 'none';
        div_forgotpassword.style.display = 'none';
        div_login.style.display = 'none';
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