<%@ Page Title="Payments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payments.aspx.cs" Inherits="Filmatic._Payments" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <main>
        <section class="text-center my-5">
            <h1 class="display-4">Pago de Entradas</h1>
            <p class="lead">Completa los detalles para finalizar la compra de tus entradas.</p>
        </section>

        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card shadow">
                        <div class="card-body">
                            <h5 class="card-title">Detalles de Pago</h5>
                            
                            <div class="form-group mb-3">
                                <label for="nombreTarjeta">Nombre en la Tarjeta</label>
                                <input type="text" class="form-control" id="nombreTarjeta" placeholder="Nombre completo">
                            </div>

                            <div class="form-group mb-3">
                                <label for="numeroTarjeta">Número de Tarjeta</label>
                                <input type="text" class="form-control" id="numeroTarjeta" placeholder="XXXX XXXX XXXX XXXX" maxlength="16">
                            </div>

                            <div class="row">
                                <div class="col-md-6 mb-3">
                                    <label for="fechaExpiracion">Fecha de Expiración</label>
                                    <input type="text" class="form-control" id="fechaExpiracion" placeholder="MM/AA" maxlength="5">
                                </div>

                                <div class="col-md-6 mb-3">
                                    <label for="cvv">CVV</label>
                                    <input type="text" class="form-control" id="cvv" placeholder="XXX" maxlength="3">
                                </div>
                            </div>

                            <div class="form-group mb-4">
                                <label for="correoElectronico">Correo Electrónico</label>
                                <input type="email" class="form-control" id="correoElectronico" placeholder="ejemplo@correo.com">
                            </div>

                            <div class="text-center">
                                <button type="button" class="btn btn-primary btn-lg">Pagar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>

</asp:Content>
