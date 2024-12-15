<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Filmatic._Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Contenedor principal que centra el contenido vertical y horizontalmente -->
   
    <div class="d-flex justify-content-center align-items-center vh-100">

        <div class="card shadow-lg p-4" style="width: 100%; max-width: 400px;">
             <div class="alert alert-warning" role="alert" runat="server" id="alertMsgLogin">
               This is a warning alert—check it out!
             </div>

            <h2 class="text-center mb-4">Iniciar Sesión</h2>

            <!-- Formulario de login -->
                <div class="mb-3">
                    <label for="inputEmail" class="form-label">Correo electrónico</label>
                    <input runat="server" type="text" class="form-control" id="inputEmail" name="inputEmail" placeholder="Ingresá tu usuario" required>
                </div>

                <div class="mb-3">
                    <label for="inputPassword" class="form-label">Contraseña</label>
                    <input runat="server" type="password" class="form-control" id="inputPassword" name="inputPassword" placeholder="Ingresá tu contraseña" required>
                </div>

                <%--<!-- Checkbox de recordarme -->
                <div class="form-check mb-3">
                    <input type="checkbox" class="form-check-input" id="rememberMe">
                    <label class="form-check-label" for="rememberMe">Recordarme</label>
                </div>--%>

                <!-- Botón de login -->
                <div class="d-grid">
                    <button type="submit" class="btn btn-primary btn-block" runat="server" onserverclick="OnClickLoginUser">Ingresar</button>
                </div>

            <!-- Enlace para crear una nueva cuenta -->
            <div class="text-center mt-3">
                <p class="small">¿No tenés una cuenta? <a href="Register.aspx">Registrate aquí</a></p>
            </div>
        </div>
    </div>
</asp:Content>
