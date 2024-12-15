<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Filmatic._Admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <main>
        <header>
            <div runat="server" class="alert alert-primary" role="alert" id="welcomeAdminMsg">
                <h3>Bienvenido a la Pantalla Administración</h3>
                <p>Desde acá podras acceder a diversos mantenimientos</p>
            </div>
        </header>

        <section>
            <article>
                <a href="/Pages/Admin/GenresMoviesList.aspx" class="btn btn-primary">Ir Funciones</a>
                <a href="/Pages/Admin/MoviesList.aspx" class="btn btn-primary">Ir a Catalogo Pelicula</a>
                <a href="/Pages/Admin/GenresMoviesList.aspx" class="btn btn-primary">Ir a Generos Pelicula</a>
            </article>

        </section>


    </main>

</asp:Content>
