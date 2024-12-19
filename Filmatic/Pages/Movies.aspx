<%@ Page Title="Movies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="Filmatic._Movies" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>


        <div id="carouselExampleAutoplaying" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-inner">
                <asp:Repeater ID="rptCarouselItems" runat="server">
                    <ItemTemplate>
                        <div data-bs-interval="5000" class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                            <img style="max-height: 1000px; object-fit: cover;"  src="<%# Eval("ImageUrl") %>" class="d-block w-100" alt="<%# Eval("Title") %>">
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>

            <div class="carousel-indicators">
                <asp:Repeater ID="rptCarouselIndicators" runat="server">
                    <ItemTemplate>
                        <button type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide-to="<%# Container.ItemIndex %>"
                            class="<%# Container.ItemIndex == 0 ? "active" : "" %>" aria-label="Slide <%# Eval("SlideID") %>">
                        </button>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>



        <!-- Sección de películas en cards -->
        <section class="container mt-5">
            <div class="row">
                <asp:Repeater ID="MoviesRepeater" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 mb-4">
                            <div class="card">
                                <img class="card-img-top" src='<%# Eval("ImagePath") %>' alt='<%# Eval("Title") %>'>
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("Title") %></h5>
                                    <p class="card-text"><%# Eval("Description") %></p>
                                    <p><strong>Duración:</strong> <%# Eval("Duration") %></p>
                                    <p><strong>Clasificación:</strong> <%# Eval("Rating") %></p>
                                    <a href='Horarios.aspx?movieId=<%# Eval("Id") %>' class="btn btn-primary">Comprar Boletos</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>
    </main>
</asp:Content>
