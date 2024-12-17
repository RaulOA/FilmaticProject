<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MoviesEdit.aspx.cs" Inherits="Filmatic.Pages.Admin.moviesCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container">
        <div runat="server" class="alert" role="alert" id="alertMsg"></div>
        <div class="row justify-content-center">
            <div class="col-md-10">
                <div class="card shadow-lg mt-5">
                    <div class="card-header text-center bg-primary text-white">
                        <h2 runat="server" id="formTitle">Crear Nueva Película</h2>
                    </div>
                    <div class="card-body p-4">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group mb-3">
                                    <label for="txtMovieId">ID</label>
                                    <asp:TextBox ID="txtMovieId" runat="server" CssClass="form-control" MaxLength="20" required></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="txtMovieTitle">Título</label>
                                    <asp:TextBox ID="txtMovieTitle" runat="server" CssClass="form-control" MaxLength="200" required></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="txtMovieSynopsis">Sinopsis</label>
                                    <asp:TextBox ID="txtMovieSynopsis" runat="server" TextMode="MultiLine" CssClass="form-control" MaxLength="2000"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="txtMovieCountry">País</label>
                                    <asp:TextBox ID="txtMovieCountry" runat="server" CssClass="form-control" MaxLength="5" required></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="txtMovieDirectors">Directores</label>
                                    <asp:TextBox ID="txtMovieDirectors" runat="server" CssClass="form-control" MaxLength="500"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="txtMovieYear">Año</label>
                                    <asp:TextBox ID="txtMovieYear" runat="server" CssClass="form-control" type="number"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="txtMovieReleaseDate">Fecha de Estreno</label>
                                    <asp:TextBox ID="txtMovieReleaseDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group mb-3">
                                    <label for="txtMovieActors">Actores</label>
                                    <asp:TextBox ID="txtMovieActors" runat="server" TextMode="MultiLine" CssClass="form-control" MaxLength="2000"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="txtMovieWriters">Escritores</label>
                                    <asp:TextBox ID="txtMovieWriters" runat="server" TextMode="MultiLine" CssClass="form-control" MaxLength="2000"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="txtMoviePosterUrl">URL del Póster</label>
                                    <asp:TextBox ID="txtMoviePosterUrl" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="txtMovieClasification">Clasificación</label>
                                    <asp:TextBox ID="txtMovieClasification" runat="server" CssClass="form-control" MaxLength="10" required></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="txtMovieDuration">Duración</label>
                                    <asp:TextBox ID="txtMovieDuration" runat="server" CssClass="form-control" type="number" step="0.1"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="txtMovieLanguage">Idioma</label>
                                    <asp:DropDownList ID="ddlMovieLanguage" runat="server" CssClass="form-select" AutoPostBack="true" ></asp:DropDownList>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="txtMovieCarrouselUrl">URL del Carrusel</label>
                                    <asp:TextBox ID="txtMovieCarrouselUrl" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="text-center mt-4">
                            <a href="MoviesList.aspx" class="btn btn-warning btn-lg  ">Cancelar</a>
                            <%--<asp:Button ID="btnSubmit" runat="server" Text="Crear Película" CssClass="btn btn-primary btn-lg w-100" OnClick="SubmitMovieForm" />--%>
                            <asp:Button ID="btnSave" runat="server" Text="Crear Película" CssClass="btn btn-primary btn-lg" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
