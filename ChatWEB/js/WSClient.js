var socketUrl = "ws://localhost:62935/Server.ashx";
var client;
var Imya;
var Status;
var ActiveDialog = "nothin";
var DialogToSend = "nothin";
        

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
        if(txtLogin.value != "" && txtPassword.value != "")
        {
            client.send("{'Action': 'Authorization', 'Login':'" + txtLogin.value + "' ,'Password':'"+ txtPassword.value+"', 'Role': 'User', 'NameDialog':'*', 'Message': '*'}");
            txtLogin.value = ""; 
            txtPassword.value = "";
        }
        else
        {
            alert("Please put your login or password in fields");
        }
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
		if(tName.value!="" && tLogin.value!="" && tPass.value!="")
		{
			SignUpOnServer(tName.value, tLogin.value, tPass.value);
			alert("Registration success!");
		}
		else
		{
			alert("All fields must be filled");
		}
        tName.value = "";
        tLogin.value = "";
        tPass.value = "";
        ReturnToMainPage();
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
        case "Authorization"   : if (content.Name != "Not registred") { GoChat("Authorization"); Imya = content.Name; } else {alert("You are not registred!");} BanOrNot(content.Message);              break;
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