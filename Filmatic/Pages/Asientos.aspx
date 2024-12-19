<%@ Page Title="Asientos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Asientos.aspx.cs" Inherits="Filmatic.Asientos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Content/cinema_tickets_styles.css" />
    <script src="/Scripts/cinema_tickets_scripts.js" defer></script>
    <script type="application/json" id="jsonPriceTicket">
        {
          "ticket_price": "<%= hdfPriceOfTicket.Value %>"
        }
        
    </script>

    <script type="application/json" id="jsonDataUser">
        <%= hdfDataUser.Value %>
    </script>

    <script type="application/json" id="jsonDataSeatsNotAvailable">
        <%= hdfDataSeatsNoAvaible.Value %>
    </script>
    <script type="application/json" id="jsonDataSeatsSelectedByUser">
        <%= hdfDataSeatsSelectedByUser.Value %>
    </script>

    <asp:HiddenField ID="hdfDataUser" runat="server" />
    <asp:HiddenField ID="hdfDataSeatsNoAvaible" runat="server" />
    <asp:HiddenField ID="hdfDataSeatsSelectedByUser" runat="server" />
    <asp:HiddenField ID="hdfPriceOfTicket" runat="server" />

    <main> 
        <div runat="server" class="alert" role="alert" id="alertMsg"></div>
        <header>
            <div class="card ">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-8">
                            <h3>Elige los asientos para la pelicula <span id="lblMovieName" runat="server"></span>
                            </h3>


                            <div style="display: flex; flex-direction: row; justify-content: space-between;">
                                <p>
                                    <strong>Sala: </strong><span runat="server" id="lblTitleRoom"></span>
                                </p>
                                <p>
                                    <strong>Hora: </strong><span runat="server" id="lblFunctionDate"></span>
                                </p>
                                <p>
                                    <strong>Precio: </strong><span runat="server" id="lblPrice"></span>
                                </p>
                            </div>

                        </div>

                        <div class="col-md-4">
                            <div class="m-auto">
                                <img style="display: none;" runat="server" id="imgPoster" title="" />
                            </div>
                        </div>
                    </div>


                </div>

            </div>
        </header>

        <section class="section-buy-tickets" runat="server" id="sectionSelectSeats">

            <article class="select-tickets">
                <header>
                    <h4>Selecciona los asientos</h4>
                </header>

                <div class="container-select-seats">
                    <div class="grid-seats section-1"></div>
                    <div class="aisle1"></div>
                    <div class="grid-seats section-2"></div>
                </div>
                <div class="cinema-screen">
                    <div>Pantalla</div>
                </div>

            </article>

            <aside class="summary-tickets">
                <header>
                    <h4>Resumen tickets seleccionados</h4>
                </header>

                <section>
                    <ul class="list-items-detail"></ul>
                </section>

                <footer>
                    <div class="row mt-2">
                        <div class="col-md-7">
                            <h4>Total: <span runat="server" id="totalAmount"></span> </h4>
                        </div>
                        <div class="col-md-5">
                            <%--<button type="button" onclick="gotToPayDotNet()" class="btn btn-primary btn-lg">Proceder al pago</button>--%>
                            <asp:Button ID="btnGoToPay" runat="server" Text="Proceder al pago" CssClass="btn btn-primary btn-lg" OnClick="btnGoToPay_Click" />
                        </div>
                    </div>

                </footer>
            </aside>
        </section>
    </main>
</asp:Content>
