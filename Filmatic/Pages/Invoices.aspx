<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Invoices.aspx.cs" Inherits="Filmatic.Pages.Invoices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
       

       <section>
           
           <div class="card">
                <div class="card-header bg-body position-sticky top-0 z-3">
                    <header class="text-center m-0 py-2 bg-body" >
                        <h1 class="display-5">Facturas</h1>
                        <p class="lead">Aquí puedes ver todas las facturas</p>
                    </header>
                </div>

               <div class="card-body">

               
                   <article>
                        <asp:GridView 
                            ID="gvInvoices" 
                            runat="server"
                            AutoGenerateColumns="false" 
                            CssClass="table table-bordered table-hover text-left"
                            >

                            <Columns>
                                <asp:BoundField DataField="id_invoice" HeaderText="#Factura"/>
                                <asp:BoundField DataField="total_amount" HeaderText="Total Pagado"/>
                                <asp:BoundField DataField="card_represent_name" HeaderText="Nombre"/>
                                <asp:BoundField DataField="card_number" HeaderText="Tarjeta"/>
                                <asp:TemplateField HeaderText="Detalles">
                                  <ItemTemplate>
                                      <a class="btn btn-primary" href="/Pages/InvoiceDetails?idInvoice=<%# Eval("id_invoice") %>">
                                      Detalles
                                      </a>
                                  </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>               
                    </article>
                  </div>
            </div>
           
       </section>
    </main>
</asp:Content>
