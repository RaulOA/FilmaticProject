<%@ Page Title="CreateFunction" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FunctionsEdit.aspx.cs" Inherits="Filmatic.CreateFunction" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div runat="server" class="alert" role="alert" id="alertMsg"></div>
        <div class="d-flex justify-content-center align-items-center vh-100">
            <div class="card shadow-lg p-4" style="width: 100%; max-width: 800px;">
                <h2 class="text-center mb-4" runat="server" id="formTitle"> Crear/Editar Función de Cine</h2>

                <div class="row">
                    <!-- ID Función -->
                    <div class="col-md-6 mb-3">
                        <label for="lblId" class="form-label">ID Función</label>
                        <asp:TextBox ID="lblId" runat="server" CssClass="form-control" placeholder="Ingresá el ID de la función" MaxLength="20" />
                    </div>

                    <!-- ID Sala -->
                    <div class="col-md-6 mb-3">
                        <label for="ddlIdRoom" class="form-label">ID Sala</label>
                        <asp:DropDownList ID="ddlIdRoom" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                            <asp:ListItem Text="Seleccione una sala" Value="" required/>
                        </asp:DropDownList>
                    </div>

                    <!-- Fecha de Creación -->
                    <div class="col-md-6 mb-3">
                        <label for="lblCreateAt" class="form-label">Fecha de Creación</label>
                        <asp:TextBox ID="lblCreateAt" runat="server" CssClass="form-control" TextMode="DateTime" />
                    </div>

                    <!-- Duración -->
                    <div class="col-md-6 mb-3">
                        <label for="lblDuration" class="form-label">Duración (Horas)</label>
                        <asp:TextBox ID="lblDuration" runat="server" CssClass="form-control" TextMode="Number" required/>
                    </div>

                    <!-- Fecha de Inicio -->
                    <div class="col-md-6 mb-3">
                        <label for="lblStartDate" class="form-label">Fecha de Inicio</label>
                        <asp:TextBox ID="lblStartDate" runat="server" CssClass="form-control" type="datetime-local" required/>
                    </div>

                    <!-- ID Película -->
                    <div class="col-md-6 mb-3">
                        <label for="ddlIdMovie" class="form-label">Película</label>
                        <asp:DropDownList ID="ddlIdMovie" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                            <asp:ListItem Text="Seleccione una película" Value="" />
                        </asp:DropDownList>
                    </div>

                    <!-- Formato de Película -->
                    <div class="col-md-6 mb-3">
                        <label for="ddlFormatMovie" class="form-label">Formato de Película</label>
                        <asp:DropDownList ID="ddlFormatMovie" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                            <asp:ListItem Text="Seleccione una película" Value="" />
                        </asp:DropDownList>                        
                    </div>

                    <!-- Precio de Entrada -->
                    <div class="col-md-6 mb-3">
                        <label for="lblTicketPrice" class="form-label">Precio de Entrada</label>
                        <asp:TextBox ID="lblTicketPrice" runat="server" CssClass="form-control" TextMode="Number" required />
                    </div>

                    <!-- Estado -->
                    <div class="col-md-6 mb-3">
                        <label for="lblStatus" class="form-label">Estado</label>
                        <asp:TextBox ID="lblStatus" runat="server" CssClass="form-control" MaxLength="5" required/>
                    </div>
                </div>

                <!-- Botón de Guardar -->
                <div class="d-flex justify-content-center">
                    <a href="FunctionsList.aspx" class="btn btn-warning btn-lg">Cancelar</a>
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary " Text="Guardar Función" OnClick="SaveFunction" />
                </div>
            </div>
        </div>
    </main>
</asp:Content>
