<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="APLICACION_WEB.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="pt-3">Lista de articulos</h2>
    <asp:GridView CssClass="table table-dark" ID="dgvArticulos" runat="server" DataKeyNames="id"
        AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
        OnPageIndexChanging="dgvArticulos_PageIndexChanging" PageSize="5" AllowPaging="true">
        <Columns>
            <asp:BoundField HeaderText="Codigo" datafield="codigo" />
            <asp:BoundField HeaderText="Nombre" datafield="nombre" />
            <asp:BoundField HeaderText="Precio" datafield="precio" />
            <asp:BoundField HeaderText="Marca" datafield="marca.descripcion" />
            <asp:BoundField HeaderText="Descripcion" datafield="categoria.descripcion" />
            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />
        </Columns>
    </asp:GridView>
    <a href="FormularioArticulo.aspx">Agregar</a>

</asp:Content>
