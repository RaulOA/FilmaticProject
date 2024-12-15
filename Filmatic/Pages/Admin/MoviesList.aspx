<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MoviesList.aspx.cs" Inherits="Filmatic.Pages.Admin.MoviesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
    <header>
        <h3>Catalogo Peliculas</h3>
        <a href="MoviesEdit.aspx"
            class="btn btn-primary mb-2"
            >
            Crear Nuevo Registro
        </a> 
    </header>

    <section>
        <article>
            <asp:GridView  ID="gv_CatMovies" 
                runat="server"
                AutoGenerateColumns="false" 
                AllowPaging="true" 
                OnRowDataBound="gv_CatMovies_RowDataBound"
                CssClass="table table-bordered table-hover text-left"
                >

                <Columns>
                    <asp:BoundField DataField="id" HeaderText="#ID"/>
                    <asp:BoundField DataField="language" HeaderText="Lenguaje"/>
                    <asp:BoundField DataField="title" HeaderText="Título"/>
                    <asp:BoundField DataField="synopsis" HeaderText="Descripción"/>
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <a href="MoviesEdit.aspx?idMovie=<%# Eval("id") %>">
                            Modificar
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>               
        </article>
    </section>
</main>    

</asp:Content>
