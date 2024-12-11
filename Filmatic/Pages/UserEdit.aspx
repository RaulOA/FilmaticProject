<%@ Page Title="UserEdit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="Filmatic.UserEdit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex align-items-center justify-content-center" style="min-height: 100vh;">
        <div class="card shadow" style="width: 400px;">
            <div class="card-body">
                <h2 class="text-center">Editar Datos del Usuario</h2>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
                
                <div class="form-group">
                    <label for="txtUsername">Nombre de Usuario</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" ReadOnly="true" />
                </div>
                
                <div class="form-group">
                    <label for="txtEmail">Correo Electrónico</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                </div>

                <div class="form-group">
                    <label for="txtPhone">Número de Teléfono</label>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
                </div>

                <div class="form-group">
                    <label for="txtPassword">Nueva Contraseña</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                </div>

                <div class="form-group">
                    <label for="txtConfirmPassword">Confirmar Contraseña</label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" />
                </div>

                <asp:Button ID="btnSave" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary btn-block" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
