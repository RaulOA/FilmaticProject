<%@ Page Title="CrearteFunction" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearteFunction.aspx.cs" Inherits="Filmatic.CrearteFunction" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="d-flex justify-content-center align-items-center vh-100">
        <div class="card shadow-lg p-4" style="width: 100%; max-width: 800px;">
            <h2 class="text-center mb-4">Crear/Editar Función de Cine</h2>

            <div class="row">
                <!-- ID Función -->
                <div class="col-md-6 mb-3">
                    <label for="inputId" class="form-label">ID Función</label>
                    <input type="text" class="form-control" id="inputId" name="inputId" placeholder="Ingresá el ID de la función" required 
                        maxlength="20" pattern="[A-Za-z0-9]+" title="El ID debe contener hasta 20 caracteres alfanuméricos." />
                </div>

                <!-- ID Sala -->
                <div class="col-md-6 mb-3">
                    <label for="inputIdRoom" class="form-label">ID Sala</label>
                    <input type="text" class="form-control" id="inputIdRoom" name="inputIdRoom" placeholder="Ingresá el ID de la sala" required 
                        maxlength="5" pattern="[A-Za-z0-9]+" title="El ID de la sala debe contener hasta 5 caracteres alfanuméricos." />
                </div>

                <!-- Fecha de Creación -->
                <div class="col-md-6 mb-3">
                    <label for="inputCreateAt" class="form-label">Fecha de Creación</label>
                    <input type="datetime-local" class="form-control" id="inputCreateAt" name="inputCreateAt" required />
                </div>

                <!-- Duración -->
                <div class="col-md-6 mb-3">
                    <label for="inputDuration" class="form-label">Duración (Horas)</label>
                    <input type="number" step="0.1" class="form-control" id="inputDuration" name="inputDuration" placeholder="Ingresá la duración en horas" />
                </div>

                <!-- Fecha de Inicio -->
                <div class="col-md-6 mb-3">
                    <label for="inputStartDate" class="form-label">Fecha de Inicio</label>
                    <input type="datetime-local" class="form-control" id="inputStartDate" name="inputStartDate" />
                </div>

                <!-- ID Película -->
                <div class="col-md-6 mb-3">
                    <label for="inputIdMovie" class="form-label">ID Película</label>
                    <input type="text" class="form-control" id="inputIdMovie" name="inputIdMovie" placeholder="Ingresá el ID de la película" required 
                        maxlength="20" pattern="[A-Za-z0-9]+" title="El ID debe contener hasta 20 caracteres alfanuméricos." />
                </div>

                <!-- Formato de Película -->
                <div class="col-md-6 mb-3">
                    <label for="inputFormatMovie" class="form-label">Formato de Película</label>
                    <input type="text" class="form-control" id="inputFormatMovie" name="inputFormatMovie" placeholder="Ejemplo: 2D, 3D, IMAX" required 
                        maxlength="20" />
                </div>

                <!-- Precio de Entrada -->
                <div class="col-md-6 mb-3">
                    <label for="inputTicketPrice" class="form-label">Precio de Entrada</label>
                    <input type="number" step="0.00001" class="form-control" id="inputTicketPrice" name="inputTicketPrice" placeholder="Ingresá el precio de la entrada" required />
                </div>

                <!-- Estado -->
                <div class="col-md-6 mb-3">
                    <label for="inputStatus" class="form-label">Estado</label>
                    <input type="text" class="form-control" id="inputStatus" name="inputStatus" placeholder="Estado (Ej: Activo, Inactivo)" required 
                        maxlength="5" />
                </div>
            </div>

            <!-- Botón de Guardar -->
            <div class="d-grid">
                <%--<button type="submit" class="btn btn-primary btn-block" runat="server" onserverclick="SaveFunction">Guardar Función</button>--%>
                <button type="submit" class="btn btn-primary btn-block" runat="server">Guardar Función</button>
            </div>
        </div>

</asp:Content>
