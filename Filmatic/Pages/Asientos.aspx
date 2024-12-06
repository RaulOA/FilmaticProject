<%@ Page Title="Asientos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Asientos.aspx.cs" Inherits="Filmatic.Asientos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Content/cinema_tickets_styles.css" />
    <script src="/Scripts/cinema_tickets_scripts.js" defer ></script>
    <script type="application/json" id="jsonDataSeatsNotAvailable">
        <%= hdfDataSeatsNoAvaible.Value %>
    </script>
    <asp:HiddenField ID="hdfDataSeatsNoAvaible" runat="server" />

    <main>
        <div runat="server" class="alert" role="alert" id="alertMsg"></div>
        <header>
            <h3>
                Elige los asientos para la pelicula <span ID="lblMovieName" runat="server"></span>
            </h3>
            
            <p>
                <strong>Sala: </strong><span runat="server" ID="lblTitleRoom"></span>
            </p>
            <p>
                <strong>Hora: </strong> <span runat="server" ID="lblFunctionDate"></span>            
            </p>
            
        </header>

        <section class="section-buy-tickets" runat="server" ID="sectionSelectSeats">

          <article class="select-tickets">
            <header>
              <h4>Selecciona los asientos</h4>
            </header>

            <div class="container-select-seats">
              <div class="grid-seats section-1"></div>
              <div class="aisle1"></div>
              <div class="grid-seats section-2"></div>
            </div>
            <div class="cinema-screen"><div>Pantalla</div></div>

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
                        <h4>Total: </h4>

                    </div>
                    <div class="col-md-5">
                        <asp:Button ID="btnGoToPay" runat="server" Text="Proceder al pago"  CssClass="btn btn-primary btn-lg" OnClick="btnGoToPay_Click"/>
                    </div>
                </div>

            </footer>
          </aside>
        </section>

    </main>
</asp:Content>
