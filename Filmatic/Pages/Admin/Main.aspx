<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Filmatic.Pages.Admin.Main1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <main>
        <header>
            <div runat="server" class="alert alert-primary" role="alert" id="welcomeAdminMsg">
                <h3>Bienvenido a la Pantalla Administración</h3>
                <p>Desde acá podras acceder a diversos mantenimientos</p>
            </div>
        </header>

        <section>
            <article>
                <a href="/Pages/Admin/FunctionsList.aspx" class="btn btn-primary">Ir Funciones</a>
                <a href="/Pages/Admin/MoviesList.aspx" class="btn btn-primary">Ir a Catalogo Pelicula</a>
                <%--<a href="/Pages/Admin/GenresMoviesList.aspx" class="btn btn-primary">Ir a Generos Pelicula</a>--%>
                <a href="/Pages/Admin/Reports/ReportMoreViewedMovies.aspx" class="btn btn-primary">Peliculas más vistas</a>
                <a href="/Pages/Admin/Reports/ReportTicketsByFunctions.aspx" class="btn btn-primary">Tiquetes por Función</a>
            </article>
        </section>
    </main>

</asp:Content>
