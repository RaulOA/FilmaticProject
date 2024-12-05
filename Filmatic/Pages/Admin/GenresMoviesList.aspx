<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenresMoviesList.aspx.cs" Inherits="Filmatic.Pages.Admin.GenresMoviesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <header>
            <h3>Catalogo Generos Peliculas</h3>
            <a href="GenresMoviesEdit.aspx?new=true"
                class="btn btn-primary mb-2"
                >
                Crear Nuevo Registro
            </a>

        </header>

        <section>
            <article>
                <asp:GridView  ID="gv_GenresMovie" 
                    runat="server"
                    AutoGenerateColumns="false" 
                    AllowPaging="true" 
                    PageSize="3" 
 
                    OnRowDataBound="gv_GenresMovie_RowDataBound"
                    CssClass="table table-bordered table-hover text-left"
                    >

                    <Columns>
                        <asp:BoundField DataField="code" HeaderText="Code"/>
                        <asp:BoundField DataField="title" HeaderText="Título"/>
                        <asp:BoundField DataField="description" HeaderText="Descripción"/>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <a href="GenresMoviesEdit.aspx?code=<%# Eval("code") %>">
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
