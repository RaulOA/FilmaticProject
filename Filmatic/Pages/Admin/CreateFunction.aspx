<%@ Page Title="CreateFunction" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateFunction.aspx.cs" Inherits="Filmatic.CreateFunction" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="d-flex justify-content-center align-items-center vh-100">
            <div class="card shadow-lg p-4" style="width: 100%; max-width: 800px;">
                <h2 class="text-center mb-4">Crear/Editar Función de Cine</h2>

                <div class="row">
                    <!-- ID Función -->
                    <div class="col-md-6 mb-3">
                        <label for="inputId" class="form-label">ID Función</label>
                        <asp:TextBox ID="inputId" runat="server" CssClass="form-control" placeholder="Ingresá el ID de la función" MaxLength="20" />
                    </div>

                    <!-- ID Sala -->
                    <div class="col-md-6 mb-3">
                        <label for="ddlIdRoom" class="form-label">ID Sala</label>
                        <asp:DropDownList ID="ddlIdRoom" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                            <asp:ListItem Text="Seleccione una sala" Value="" />
                        </asp:DropDownList>
                    </div>

                    <!-- Fecha de Creación -->
                    <div class="col-md-6 mb-3">
                        <label for="inputCreateAt" class="form-label">Fecha de Creación</label>
                        <asp:TextBox ID="inputCreateAt" runat="server" CssClass="form-control" TextMode="DateTime" />
                    </div>

                    <!-- Duración -->
                    <div class="col-md-6 mb-3">
                        <label for="inputDuration" class="form-label">Duración (Horas)</label>
                        <asp:TextBox ID="inputDuration" runat="server" CssClass="form-control" TextMode="Number" />
                    </div>

                    <!-- Fecha de Inicio -->
                    <div class="col-md-6 mb-3">
                        <label for="inputStartDate" class="form-label">Fecha de Inicio</label>
                        <asp:TextBox ID="inputStartDate" runat="server" CssClass="form-control" TextMode="DateTime" />
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
                        <label for="inputFormatMovie" class="form-label">Formato de Película</label>
                        <asp:TextBox ID="inputFormatMovie" runat="server" CssClass="form-control" MaxLength="20" />
                    </div>

                    <!-- Precio de Entrada -->
                    <div class="col-md-6 mb-3">
                        <label for="inputTicketPrice" class="form-label">Precio de Entrada</label>
                        <asp:TextBox ID="inputTicketPrice" runat="server" CssClass="form-control" TextMode="Number" />
                    </div>

                    <!-- Estado -->
                    <div class="col-md-6 mb-3">
                        <label for="inputStatus" class="form-label">Estado</label>
                        <asp:TextBox ID="inputStatus" runat="server" CssClass="form-control" MaxLength="5" />
                    </div>
                </div>

                <!-- Botón de Guardar -->
                <div class="d-grid">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-block" Text="Guardar Función" OnClick="SaveFunction" />
                </div>
            </div>
        </div>
    </main>
</asp:Content>
