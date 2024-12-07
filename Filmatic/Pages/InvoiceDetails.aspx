<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InvoiceDetails.aspx.cs" Inherits="Filmatic.Pages.InvoiceDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div runat="server" class="alert" role="alert" id="alertMsg"></div>

        <div class="card">
            <div class="card-header bg-body position-sticky top-0 z-3">
                <header class="text-center m-0 py-2 bg-body" >
                    <h1 class="display-5">Detalle de la Factura</h1>
                    <p class="lead">Aquí puede ver todos los tiquetes que has adquirido con la factura</p>
                    <a class="btn btn-dark" href="/Pages/Invoices">Volver a las lista de Facturas</a>
                </header>
            </div>
            <div class="card-body">

                <section id="sectionInvoiceDetails" runat="server">

                    <article>
                        <asp:GridView 
                            ID="gvInvoiceDetails" 
                            runat="server"
                            AutoGenerateColumns="false" 
                            CssClass="table table-bordered table-hover text-left"
                            >
                        <Columns>
                            <asp:BoundField DataField="line" HeaderText="#Línea" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="detail" HeaderText="Detalle"/>
                            <asp:BoundField DataField="total_line" HeaderText="Monto Pagado" ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField HeaderText="Detalles Función">
                              <ItemTemplate>
                                <div class="card">
                                  <div class="row g-0">
                                    <!-- Imagen -->
                                    <div class="col-md-4">
                                      <img 
                                        class="img-fluid rounded-start" 
                                        src='<%# Eval("url_poster") %>' 
                                        alt='<%# Eval("title") %>' 
                                        title='<%# Eval("title") %>'
                                      />
                                    </div>
                                    <!-- Información -->
                                    <div class="col-md-8">
                                      <div class="card-body">
                                        <h5 class="card-title"><%# Eval("title") %></h5>
                                        <ul class="list-unstyled">
                                          <li><strong>Duración:</strong> <%# Eval("duration") %></li>
                                          <li><strong>Año:</strong> <%# Eval("year") %></li>
                                          <li><strong>Sinopsis:</strong> <%# Eval("synopsis") %></li>
                                          <li><strong>Clasificación:</strong> <%# Eval("clasification") %></li>
                                          <li><strong>Fecha de la función:</strong> El <%# GetDateFromDateTime((DateTime?)Eval("start_date")) %> a las  <%# GetTimeFromDateTime((DateTime?)Eval("start_date")) %></li>


                                        </ul>
                                      </div>
                                    </div>
                                  </div>
                                </div>
                              </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>               
                </article>
            </section>
            </div>

        </div>
        
    </main>
</asp:Content>
