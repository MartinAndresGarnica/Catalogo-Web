<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="APLICACION_WEB.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="container py-5">
            <div class="row">
                <div class="col-4">
                    <div class="mb-3">
                        <h3>Refiná tu búsqueda</h3>
                    </div>
                    <div class="mb-3">
                        <label for="formGroupExampleInput" class="form-label">Categoria</label> <br />
                        <asp:DropDownList ID="ddlCategoria" CssClass="dropdown btn btn-secondary dropdown-toggle" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label for="formGroupExampleInput" class="form-label">Categoria</label> <br />
                        <asp:DropDownList ID="ddlMarca" CssClass="dropdown btn btn-secondary dropdown-toggle" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <asp:Button runat="server" ID="btnFiltrar" CssClass="btn btn-light" Text="Filtrar" OnClick="btnFiltrar_Click" />
                    </div>
                </div>
                <div class="col-8">
                    <div class="row">

                        <div class="col-2">
                            <h5>Ordenar</h5>
                        </div>
                        <div class="col-2">
                            <asp:DropDownList ID="ddlOrden" runat="server" OnSelectedIndexChanged="ddlOrden_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="Mayor precio" />
                                <asp:ListItem Text="Menor precio" />
                                <asp:ListItem Text="Marca ascendente" />
                                <asp:ListItem Text="Marca descendente" />
                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="row row-cols-1 row-cols-md-3 g-4">
                    <asp:Repeater ID="repetidor" runat="server">
                        <ItemTemplate>
                            <div class="col">

                                <div class="card h-100">
                                    <a href="#" class="link-dark link-offset-2 link-underline-opacity-0">
                                        <img src="<%# Eval("imagen") %>" width="100%" height="250 vmax" class="card-img-top" alt="">
                                        <div class="card-body">
                                            <h5 class="card-title"><%# Eval("nombre") %></h5>
                                            <p class="card-text"><%# Eval("descripcion") %></p>
                                        </div>
                                    </a>
                                    <ul class="list-group list-group-flush">
                                        <li class="list-group-item"><%# Eval("Marca") %></li>
                                        <li class="list-group-item"><%# Eval("Precio") %></li>
                                    </ul>
                                    <div class="card-body">
                                        <a href="#" class="btn btn-outline-primary">Favorite ♥</a>
                                        <a href="#" class="btn btn-outline-success">Comprar +</a>
                                    </div>
                                </div>
                                </div>
                            
                        </ItemTemplate>
                    </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
