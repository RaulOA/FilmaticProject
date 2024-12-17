<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FunctionsList.aspx.cs" Inherits="Filmatic.Pages.Admin.FunctionsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <main>
    <header>
        <h3>Catalogo Funciones</h3>
        <a href="FunctionsEdit.aspx"
            class="btn btn-primary mb-2"
            >
            Crear Nuevo Registro
        </a> 
    </header>

    <section>
        <article>
            <asp:GridView  ID="gv_Functions" 
                runat="server"
                AutoGenerateColumns="false" 
                AllowPaging="true" 
                OnRowDataBound="gv_Functions_RowDataBound"
                CssClass="table table-bordered table-hover text-left"
                >

                <Columns>
                    <asp:BoundField DataField="id_function" HeaderText="#ID"/>
                    <asp:BoundField DataField="room_title" HeaderText="Sala"/>
                    <asp:BoundField DataField="movie_title" HeaderText="Pelicula"/>
                    <asp:BoundField DataField="function_duration_to_show" HeaderText="Duración"/>
                    <asp:BoundField DataField="function_start_date" HeaderText="Fecha"/>
                    <asp:BoundField DataField="function_format_movie" HeaderText="Estado"/>                   

                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <a href="FunctionsEdit.aspx?idFunction=<%# Eval("id_function") %>">
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
