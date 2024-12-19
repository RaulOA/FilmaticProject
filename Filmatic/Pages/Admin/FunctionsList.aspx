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
                    <asp:BoundField DataField="function_ticket_price" HeaderText="Precio"/>
                    <asp:BoundField DataField="function_duration_to_show" HeaderText="Duración"/>
                    <asp:BoundField DataField="function_start_date" HeaderText="Fecha"/>
                    <asp:BoundField DataField="function_format_movie" HeaderText="Formato"/>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <%# 
                                Eval("function_status").ToString().Trim() == "B" ? "Borrador" :
                                Eval("function_status").ToString().Trim() == "P" ? "Programada" :
                                Eval("function_status").ToString().Trim() == "A" ? "Activa" :
                                Eval("function_status").ToString().Trim() == "F" ? "Finalizada" :
                                Eval("function_status").ToString().Trim() == "C" ? "Cancelada" :
                                Eval("function_status").ToString().Trim() == "E" ? "En pausa" :
                                Eval("function_status").ToString().Trim() == "R" ? "Retrasada" :
                                Eval("function_status").ToString().Trim() == "V" ? "Vendiendo entradas" :
                                Eval("function_status").ToString().Trim() == "S" ? "Sin disponibilidad" : "Desconocido" 
                            %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <a href="/Pages/Admin/FunctionsEdit.aspx?idFunction=<%# Eval("id_function") %>">
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
