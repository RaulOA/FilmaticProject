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
                                    <label for="lblMovieId">ID</label>
                                    <asp:TextBox ID="lblMovieId" runat="server" CssClass="form-control" MaxLength="20" required></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="lblMovieTitle">Título</label>
                                    <asp:TextBox ID="lblMovieTitle" runat="server" CssClass="form-control" MaxLength="200" required></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="lblMovieSynopsis">Sinopsis</label>
                                    <asp:TextBox ID="lblMovieSynopsis" runat="server" TextMode="MultiLine" CssClass="form-control" MaxLength="2000"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="lblMovieCountry">País</label>
                                    <asp:TextBox ID="lblMovieCountry" runat="server" CssClass="form-control" MaxLength="5" required></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="lblMovieDirectors">Directores</label>
                                    <asp:TextBox ID="lblMovieDirectors" runat="server" CssClass="form-control" MaxLength="500"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="lblMovieYear">Año</label>
                                    <asp:TextBox ID="lblMovieYear" runat="server" CssClass="form-control" type="number"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="lblMovieReleaseDate">Fecha de Estreno</label>
                                    <asp:TextBox ID="lblMovieReleaseDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group mb-3">
                                    <label for="lblMovieActors">Actores</label>
                                    <asp:TextBox ID="lblMovieActors" runat="server" TextMode="MultiLine" CssClass="form-control" MaxLength="2000"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="lblMovieWriters">Escritores</label>
                                    <asp:TextBox ID="lblMovieWriters" runat="server" TextMode="MultiLine" CssClass="form-control" MaxLength="2000"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="lblMoviePosterUrl">URL del Póster</label>
                                    <asp:TextBox ID="lblMoviePosterUrl" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="lblMovieClasification">Clasificación</label>
                                    <asp:TextBox ID="lblMovieClasification" runat="server" CssClass="form-control" MaxLength="10" required></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="lblMovieDuration">Duración</label>
                                    <asp:TextBox ID="lblMovieDuration" runat="server" CssClass="form-control" type="number" step="0.1"></asp:TextBox>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="lblMovieLanguage">Idioma</label>
                                    <asp:DropDownList ID="ddlMovieLanguage" runat="server" CssClass="form-select" AutoPostBack="true" ></asp:DropDownList>
                                </div>

                                <div class="form-group mb-3">
                                    <label for="lblMovieCarrouselUrl">URL del Carrusel</label>
                                    <asp:TextBox ID="lblMovieCarrouselUrl" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="text-center mt-4">
                            <a href="MoviesList.aspx" class="btn btn-warning btn-lg  ">Cancelar</a>
                            <%--<asp:Button ID="btnSubmit" runat="server" Text="Crear Película" CssClass="btn btn-primary btn-lg w-100" OnClick="SubmitMovieForm" />--%>
                            <asp:Button ID="btnSave" runat="server" Text="Crear Película" CssClass="btn btn-primary btn-lg w-100" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
