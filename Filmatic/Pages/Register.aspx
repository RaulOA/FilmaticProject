<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Filmatic._Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Contenedor principal que centra el contenido vertical y horizontalmente -->
    <div class="d-flex justify-content-center align-items-center vh-100">
        <div class="card shadow-lg p-4" style="width: 100%; max-width: 500px;">
            <h2 class="text-center mb-4">Crear una nueva cuenta</h2>

            <!-- Formulario de registro -->

                <!-- Campo de nombre -->
                <div class="mb-3">
                    <label for="inputName" class="form-label">Nombre Completo</label>
                    <input type="text" class="form-control" id="inputName" placeholder="Ingresá tu nombre completo" required>
                </div>

                <!-- Campo de correo electrónico -->
                <div class="mb-3">
                    <label for="inputEmail" class="form-label">Correo electrónico</label>
                    <input type="email" class="form-control" id="inputEmail" placeholder="Ingresá tu correo" required>
                </div>

                <!-- Campo de contraseña -->
                <div class="mb-3">
                    <label for="inputPassword" class="form-label">Contraseña</label>
                    <input type="password" class="form-control" id="inputPassword" placeholder="Ingresá tu contraseña" required>
                </div>

                <!-- Campo de confirmación de contraseña -->
                <div class="mb-3">
                    <label for="inputConfirmPassword" class="form-label">Confirmar contraseña</label>
                    <input type="password" class="form-control" id="inputConfirmPassword" placeholder="Confirmá tu contraseña" required>
                </div>

                <!-- Botón de registro -->
                <div class="d-grid">
                    <button type="submit" class="btn btn-primary btn-block">Registrarme</button>
                </div>

            <!-- Enlace para iniciar sesión si ya tiene cuenta -->
            <div class="text-center mt-3">
                <p class="small">¿Ya tenés una cuenta? <a href="Login.aspx">Iniciá sesión aquí</a></p>
            </div>
        </div>
    </div>
</asp:Content>
