<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="moviesCreate.aspx.cs" Inherits="Filmatic.Pages.Admin.moviesCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container">
        <div class="row justify-content-center">
            <div class="col-md-10">
                <div class="card shadow-lg mt-5">
                    <div class="card-header text-center bg-primary text-white">
                        <h2>Crear Nueva Película</h2>
                    </div>
                    <div class="card-body p-4">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group mb-3">
                                    <label for="movieId">ID</label>
                                    <asp:TextBox ID="movieId" runat="server" CssClass="form-control" MaxLength="20" required></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="movieTitle">Título</label>
                                    <asp:TextBox ID="movieTitle" runat="server" CssClass="form-control" MaxLength="200" required></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="movieSynopsis">Sinopsis</label>
                                    <asp:TextBox ID="movieSynopsis" runat="server" TextMode="MultiLine" CssClass="form-control" MaxLength="2000"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="movieCountry">País</label>
                                    <asp:TextBox ID="movieCountry" runat="server" CssClass="form-control" MaxLength="5" required></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="movieDirectors">Directores</label>
                                    <asp:TextBox ID="movieDirectors" runat="server" CssClass="form-control" MaxLength="500"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="movieYear">Año</label>
                                    <asp:TextBox ID="movieYear" runat="server" CssClass="form-control" type="number"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="movieReleaseDate">Fecha de Estreno</label>
                                    <asp:TextBox ID="movieReleaseDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group mb-3">
                                    <label for="movieActors">Actores</label>
                                    <asp:TextBox ID="movieActors" runat="server" TextMode="MultiLine" CssClass="form-control" MaxLength="2000"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="movieWriters">Escritores</label>
                                    <asp:TextBox ID="movieWriters" runat="server" TextMode="MultiLine" CssClass="form-control" MaxLength="2000"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="moviePosterUrl">URL del Póster</label>
                                    <asp:TextBox ID="moviePosterUrl" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="movieClasification">Clasificación</label>
                                    <asp:TextBox ID="movieClasification" runat="server" CssClass="form-control" MaxLength="10" required></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="movieDuration">Duración</label>
                                    <asp:TextBox ID="movieDuration" runat="server" CssClass="form-control" type="number" step="0.1"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="movieLanguage">Idioma</label>
                                    <asp:TextBox ID="movieLanguage" runat="server" CssClass="form-control" MaxLength="5" required></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="movieCarrouselUrl">URL del Carrusel</label>
                                    <asp:TextBox ID="movieCarrouselUrl" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="text-center mt-4">
                            <%--<asp:Button ID="btnSubmit" runat="server" Text="Crear Película" CssClass="btn btn-primary btn-lg w-100" OnClick="SubmitMovieForm" />--%>
                            <asp:Button ID="btnSubmit" runat="server" Text="Crear Película" CssClass="btn btn-primary btn-lg w-100" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
