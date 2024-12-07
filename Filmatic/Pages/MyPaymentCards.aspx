<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyPaymentCards.aspx.cs" Inherits="Filmatic.Pages.MyPaymentCards1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <main>
            <header>
                <h3>Tarjetas Crédito/Debito</h3>
                <a href="CreatePaymentCard"class="btn btn-primary mb-2">
                    Crear Nuevo Registro
                </a>

            </header>

            <section>
                <article>
                    <asp:GridView 
                        ID="gvPaymentCards" 
                        runat="server"
                        AutoGenerateColumns="false" 
 
                        OnRowDataBound="gvPaymentCards_RowDataBound"
                        CssClass="table table-bordered table-hover text-left"
                        >

                        <Columns>
                            <asp:BoundField DataField="represent_name" HeaderText="Representate"/>
                            <asp:BoundField DataField="card_number" HeaderText="Número tarjeta"/>
                            <asp:BoundField DataField="card_year" HeaderText="Año Expiración"/>
                            <asp:BoundField DataField="card_month" HeaderText="Mes Expiración"/>

                            <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <a class="btn btn-danger" href="/Pages/CreatePaymentCard?idPaymentCard=<%# Eval("id") %>">
                                    Eliminar
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>               
                </article>
            </section>
     </main>
</asp:Content>
