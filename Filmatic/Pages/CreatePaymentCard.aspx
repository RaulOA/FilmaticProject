<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatePaymentCard.aspx.cs" Inherits="Filmatic.Pages.CreatePaymentCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
    <div runat="server" class="alert" role="alert" id="alertMsg"></div> 

    <div class="container" runat="server" id="sectionDetailsPaymen">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow">
                    <div class="card-body">
                        <h5 class="card-title">Detalles de Pago</h5>
                        
                         <div class="row">

                            <div class="col-md-6 mb-3">
                                <label for="nombreTarjeta">Nombre en la Tarjeta</label>
                                <asp:TextBox CssClass="form-control" ID="txtNameCard" name="nombreTarjeta" runat="server" MaxLength="20" placeholder="Nombre completo" type="text" required></asp:TextBox>
                            </div>

                            <div class="col-md-6 mb-3">
                                <label for="numeroTarjeta">Número de Tarjeta</label>
                                <asp:TextBox CssClass="form-control" ID="txtCardNumber" name="numeroTarjeta" runat="server" MaxLength="20" placeholder="XXXX XXXX XXXX XXXX" type="text" required></asp:TextBox>
                            </div>
                          
                            <div class="col-md-6 mb-3">
                                <label for="fechaExpiracion">Fecha de Expiración</label>
                                <asp:TextBox CssClass="form-control" ID="txtDateExp" name="fechaExpiracion" runat="server" MaxLength="5" placeholder="MM/AA" type="text" required></asp:TextBox>
                            </div>

                            <div class="col-md-6 mb-3">
                                <label for="cv">CV</label>
                                <asp:TextBox CssClass="form-control" ID="txtCV" name="cv" runat="server" MaxLength="6" placeholder="XXX" type="number" required></asp:TextBox>
                            </div>

                             <div class="col-md-12 mb-3">
                                  <asp:Button ID="btnCreate" runat="server" CssClass="btn btn-primary" Text="Crear" OnClick="btnCreate_Click" />
                                 <a class="btn btn-warning" href="MyPaymentCards.aspx">Regresar</a>
                             </div>
                        </div> 
                    </div>
                </div>
            </div>
        </div>
    </div>
    </main>
</asp:Content>
