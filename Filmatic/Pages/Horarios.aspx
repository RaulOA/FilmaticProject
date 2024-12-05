<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Horarios.aspx.cs" Inherits="Filmatic.Horarios" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="text-center my-5">
            <h1 class="display-4">Selecciona tu Horario, Sala y Entradas</h1>
            <p class="lead">Elige los detalles para disfrutar tu película.</p>
        </section>

        <div class="container">
            <div class="row">
                <div class="col-md-4 mb-4">
                    <div class="card shadow">
                        <div class="card-body">
                            <h5 class="card-title">Horarios disponibles</h5>
                            <asp:DropDownList ID="ddlHorarios" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="col-md-4 mb-4">
                    <div class="card shadow">
                        <div class="card-body">
                            <h5 class="card-title">Salas disponibles</h5>
                            <asp:DropDownList ID="ddlSalas" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="col-md-4 mb-4">
                    <div class="card shadow">
                        <div class="card-body">
                            <h5 class="card-title">Cantidad de entradas</h5>
                            <asp:DropDownList ID="ddlEntradas" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>

            <div class="text-center mt-4">
                <button type="button" class="btn btn-primary btn-lg">Confirmar Selección</button>
            </div>
        </div>
    </main>
</asp:Content>
