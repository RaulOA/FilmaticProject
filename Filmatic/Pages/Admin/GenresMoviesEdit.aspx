<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenresMoviesEdit.aspx.cs" Inherits="Filmatic.Pages.Admin.GenresMoviesEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        
        <div runat="server" class="alert" role="alert" id="alertMsg"></div>


        <div class="card">
            <div class="card-header">
                <h3 runat="server" ID="formTitle"></h3>
            </div>

            <div></div>

            <div class="card-body">
                <div>
                    <label for="txtCode" class="form-label">
                        Código: 
                        <asp:TextBox ID="txtCode" runat="server" CssClass="form-control" ></asp:TextBox>
                    </label>

                    <label for="txtCode" class="form-label">
                        Título: 
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" ></asp:TextBox>
                    </label>

                    <label for="txtCode" class="form-label">
                        Descripción: 
                        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>  
                    </label>
                </div>

                <div>
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Salvar" OnClick="btnSave_Click"/>
                    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnDelete_Click"/>
                    <a href="GenresMoviesList.aspx" class="btn btn-warning">Cancelar</a>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
