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
                        <asp:TextBox ID="txtId" runat="server" CssClass="form-control" placeholder="Ingresá el ID de la función" MaxLength="20" />
                    </div>

                    <!-- ID Sala -->
                    <div class="col-md-6 mb-3">
                        <label for="ddlIdRoom" class="form-label">ID Sala</label>
                        <asp:DropDownList ID="ddlIdRoom" runat="server" CssClass="form-control" required>
                        </asp:DropDownList>
                    </div>

                    <!-- Fecha de Creación -->
                    <div class="col-md-6 mb-3">
                        <label for="lblCreateAt" class="form-label">Fecha de Creación</label>
                        <asp:TextBox ID="txtCreateAt" runat="server" CssClass="form-control" TextMode="DateTime" />
                    </div>

                    <!-- Duración -->
                    <div class="col-md-6 mb-3">
                        <label for="lblDuration" class="form-label">Duración (Minutos)</label>
                        <asp:TextBox ID="txtDuration" runat="server" CssClass="form-control" type="number" required/>
                    </div>

                    <!-- Fecha de Inicio -->
                    <div class="col-md-6 mb-3">
                        <label for="lblStartDate" class="form-label">Fecha de Inicio</label>
                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" type="datetime-local" step="900" required/>
                    </div>

                    <!-- ID Película -->
                    <div class="col-md-6 mb-3">
                        <label for="ddlIdMovie" class="form-label">Película</label>
                        <asp:DropDownList ID="ddlIdMovie" runat="server" CssClass="form-control"  required >
                        </asp:DropDownList>
                    </div>
                     
                    <!-- Formato de Película -->
                    <div class="col-md-6 mb-3">
                        <label for="ddlFormatMovie" class="form-label">Formato de Película</label>
                        <asp:DropDownList ID="ddlFormatMovie" runat="server" CssClass="form-control"  required>
                        </asp:DropDownList>                        
                    </div>

                    <!-- Precio de Entrada -->
                    <div class="col-md-6 mb-3">
                        <label for="lblTicketPrice" class="form-label">Precio de Entrada</label>
                        <asp:TextBox ID="txtTicketPrice" runat="server" CssClass="form-control" type="number" required />
                    </div>
 

                    <!-- Estado -->
                    <div class="col-md-6 mb-3">
                        <label for="lblStatus" class="form-label">Estado</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                            <asp:ListItem Text="-- Estado --" Value="" />
                            <asp:ListItem Text="Borrador" Value="B" />
                            <asp:ListItem Text="Programada" Value="P" />
                            <asp:ListItem Text="Activa" Value="A" />
                            <asp:ListItem Text="Finalizada" Value="F" />
                            <asp:ListItem Text="Cancelada" Value="C" />
                            <asp:ListItem Text="En pausa" Value="E" />
                            <asp:ListItem Text="Retrasada" Value="R" />
                            <asp:ListItem Text="Vendiendo entradas" Value="V" />
                            <asp:ListItem Text="Sin disponibilidad" Value="S" />
                        </asp:DropDownList>                        
                    </div>
                </div>

                <!-- Botón de Guardar -->
                <div class="d-flex justify-content-center">
                    <a href="/Pages/Admin/FunctionsList.aspx" class="btn btn-warning mx-2">Cancelar</a>
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary mx-2" Text="Guardar Función" OnClick="btnSave_Click" />
                    <asp:Button ID="btnGenerateFunctionTickets" runat="server" CssClass="btn btn-primary mx-2" Text="Generar Ticketes para la función" OnClick="btnGenerateFunctionTickets_Click" />
                </div>
            </div>
        </div>
    </main>
</asp:Content>
