<%@ Page Title="Payments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payments.aspx.cs" Inherits="Filmatic._Payments" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="application/json" id="jsonDataSeatsSelectedByUser">
     <%= hdfDataSeatsSelectedByUser.Value %>
    </script>

    <asp:HiddenField ID="hdfDataSeatsSelectedByUser" runat="server" />
    <asp:HiddenField ID="hdfIdFunction" runat="server" />

    <main>
        <div runat="server" class="alert" role="alert" id="alertMsg"></div>
        <section class="text-center my-5">
            <h1 class="display-4">Pago de Entradas</h1>
            <p class="lead">Completa los detalles para finalizar la compra de tus entradas.</p>
        </section>


        <div class="container" runat="server" id="sectionDetailsPaymen">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card shadow">
                        <div class="card-body">
                            <h5 class="card-title">Detalles de Pago</h5>
                   

                            <div class="row">
                                 <div class="col-md-12 mb-4">
                                      <div class="card shadow">
                                             <div class="card-body">
                                                <h5 class="card-title">Selecciona la tarjeta</h5>
                                                <asp:DropDownList required ID="ddlPaymentCard" runat="server" CssClass="form-select"></asp:DropDownList>
                                            </div>
                                      </div>
                                 </div>

                                <div class="col-md-12 mb-4">
                                    <div class="card shadow">
                                        <div class="card-body">
                                            <div class="d-flex flex-row justify-content-between">

                                                <div>
                                                    <h5 class="card-title">Total: <span runat="server" id="totalAmount">0</span> </h5>
                                                </div>
                                                <div>                                                   
                                                    <a 
                                                        class="btn btn-warning"  
                                                        href="/Pages/Asientos?idFunction=<%= hdfIdFunction.Value %>"
                                                     >
                                                        Regresar
                                                    </a>
                                                    <asp:Button ID="btnPay" runat="server" Text="Pagar" CssClass="btn btn-primary" OnClick="btnPay_Click" />
                                                    
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <div class="col-md-12 mb-4">
                                    <div class="card shadow">
                                        <div class="card-body">
                                            <h5 class="card-title">Detalle</h5>
                                            <div>
                                                <asp:GridView 
                                                    ID="gvDetailLinesPayment" 
                                                    runat="server"
                                                    AutoGenerateColumns="false" 
                                                    CssClass="table table-bordered table-hover text-left"
                                                    >
                                                    <Columns>
                                                        <asp:BoundField DataField="detail" HeaderText="Detail"/>
                                                        <asp:BoundField DataField="price" HeaderText="Precio"/>
                                                    </Columns>
                                                </asp:GridView>               
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>

</asp:Content>
