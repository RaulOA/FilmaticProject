<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Filmatic._Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-center vh-100">
        <div class="card shadow-lg p-4" style="width: 100%; max-width: 800px;">
            <h2 class="text-center mb-4">Crear una nueva cuenta</h2>

            <div class="row">
                <!-- Nombre -->
                <div class="col-md-6 mb-3">
                    <label for="inputName" class="form-label">Nombre</label>
                    <input type="text" class="form-control" id="inputName" name="inputName" placeholder="Ingresá tu nombre" required 
                        pattern="[A-Za-z]+" title="El nombre solo puede contener letras." />
                    <span class="form-text">Debe contener solo letras.</span>
                </div>

                <!-- Apellidos -->
                <div class="col-md-6 mb-3">
                    <label for="inputLastName" class="form-label">Apellidos</label>
                    <input type="text" class="form-control" id="inputLastName" name="inputLastName" placeholder="Ingresá tus apellidos" required 
                        pattern="[A-Za-z\s]+" title="Los apellidos solo pueden contener letras y espacios." />
                    <span class="form-text">Debe contener solo letras y espacios.</span>
                </div>

                <!-- Correo electrónico -->
                <div class="col-md-6 mb-3">
                    <label for="inputEmail" class="form-label">Correo electrónico</label>
                    <input type="email" class="form-control" id="inputEmail" name="inputEmail" placeholder="Ingresá tu correo" required />
                    <span class="form-text">Formato: ejemplo@dominio.com</span>
                </div>

                <!-- Fecha de nacimiento -->
                <div class="col-md-6 mb-3">
                    <label for="inputBirthDate" class="form-label">Fecha de Nacimiento</label>
                    <input type="date" class="form-control" id="inputBirthDate" name="inputBirthDate" required />
                    <span class="form-text">Debe ser mayor de 15 años.</span>
                </div>

                <!-- Número de teléfono -->
                <div class="col-md-6 mb-3">
                    <label for="inputPhoneNumber" class="form-label">Número de Teléfono</label>
                    <input type="text" class="form-control" id="inputPhoneNumber" name="inputPhoneNumber" placeholder="Ingresá tu número de teléfono" required 
                        pattern="\d{8}" title="El número debe contener exactamente 8 dígitos numéricos." />
                    <span class="form-text">Debe contener 8 dígitos numéricos.</span>
                </div>

                <!-- Cédula (ID Document) -->
                <div class="col-md-6 mb-3">
                    <label for="inputIdDocument" class="form-label">Cédula</label>
                    <input type="text" class="form-control" id="inputIdDocument" name="inputIdDocument" placeholder="Ingresá tu cédula" required 
                        pattern="\d{9}" title="La cédula debe tener exactamente 9 dígitos numéricos." />
                    <span class="form-text">Debe contener 9 dígitos numéricos.</span>
                </div>

                <!-- Contraseña -->
                <div class="col-md-6 mb-3">
                    <label for="inputPassword" class="form-label">Contraseña</label>
                    <input type="password" class="form-control" id="inputPassword" name="inputPassword" placeholder="Ingresá tu contraseña" required 
                        pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$" 
                        title="Debe tener al menos 6 caracteres, incluyendo mayúsculas, minúsculas, números y un símbolo." />
                    <span class="form-text">Debe tener al menos 6 caracteres, incluyendo mayúsculas, minúsculas, números y un símbolo.</span>
                </div>

                <!-- Confirmar contraseña -->
                <div class="col-md-6 mb-3">
                    <label for="inputConfirmPassword" class="form-label">Confirmar contraseña</label>
                    <input type="password" class="form-control" id="inputConfirmPassword" name="inputConfirmPassword" placeholder="Confirmá tu contraseña" required />
                    <span class="form-text">Debe coincidir con la contraseña.</span>
                </div>
            </div>

            <!-- Botón de registro -->
            <div class="d-grid">
                <button type="submit" class="btn btn-primary btn-block" runat="server" onserverclick="RegisterUser">Registrarme</button>
            </div>

            <div class="text-center mt-3">
                <p class="small">¿Ya tenés una cuenta? <a href="Login.aspx">Iniciá sesión aquí</a></p>
            </div>
        </div>
    </div>
</asp:Content>
