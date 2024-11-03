<%@ Page Title="Billboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Billboard.aspx.cs" Inherits="Filmatic._Billboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <main>
        <div runat="server" class="alert alert-primary" role="alert" id="welcomeMsg"></div>
        <div runat="server" class="alert alert-primary" role="alert" id="loginMsg">
            <h4 class="alert-heading">Inicia session para continuar</h4>
            <p>Parece que no has iniciado session, para poder comprar ticketes debes ingresar con tus datos.</p>
            <hr>
            <a runat="server" href="/Pages/Login.aspx" class="btn btn-primary">
                Iniciar Session
            </a>
            <a runat="server" href="/Pages/Register.aspx" class="btn btn-outline-primary">
                ¡Registrate!
            </a>
        </div>
    </main>

</asp:Content>
