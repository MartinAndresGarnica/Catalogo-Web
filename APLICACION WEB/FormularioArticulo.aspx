<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="APLICACION_WEB.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function mostrarModal() {
            var mymodal = new bootstrap.Modal(document.getElementById('modalAgregarMarca'), { keyboard: false });
            mymodal.show();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="container mt-5">
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtID" class="form-label">ID</label>
                    <asp:TextBox CssClass="form-control" ID="txtID" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtCodigo" class="form-label">Codigo</label>
                    <asp:TextBox CssClass="form-control" ID="txtCodigo" placeholder="Ejemplo: A001" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox CssClass="form-control" ID="txtNombre" placeholder="Ejemplo: Iphone 14" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripcion</label>
                    <asp:TextBox CssClass="form-control" ID="txtDescripcion" TextMode="MultiLine" placeholder="Ejemplo: Último modelo de iPhone" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtPrecio" class="form-label">Precio</label>
                    <asp:TextBox CssClass="form-control" ID="txtPrecio" placeholder="Ejemplo: 999.99" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="ddlMarca" class="form-label">Marca</label>
                    <div class="row">
                        <div class="col-8">
                            <asp:DropDownList ID="ddlMarca" CssClass="dropdown-toggle form-select border-dark" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-2">
                            <asp:Button ID="btnMarca" CssClass="btn btn-outline-dark" OnClientClick="mostrarModal(); return false;" runat="server" Text="Agregar" />
                        </div>
                    </div>
                </div>

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal fade" id="modalAgregarMarca" tabindex="-1" aria-labelledby="modalAgregarMarcaLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="modalAgregarMarcaLabel">Agregar Nueva Marca</h5>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">
                                        <asp:TextBox type="text" ID="txtNuevaMarca" CssClass="form-control" placeholder="Ingresa el nombre de la marca" runat="server" />
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                                        <asp:Button ID="btnGuardarMarca" runat="server" CssClass="btn btn-primary" OnClick="btnGuardarMarca_Click" Text="Guardar Marca" />
                                        <asp:Label ID="lblMensaje" runat="server" CssClass="form-label mt-3" />
                                    </div>
                                </div>
                            </div>
                          </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnGuardarMarca" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <div class="mb-3">
                        <label for="ddlCategoria" class="form-label">Categoria</label>
                        <div class="row">
                            <div class="col-8">
                                <asp:DropDownList ID="ddlCategoria" CssClass="dropdown-toggle form-select border-dark" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-2">
                                <asp:Button ID="btnCategoria" CssClass="btn btn-outline-dark" runat="server" Text="Agregar" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-6">
                    <div class="mb-3">
                        <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control"
                            placeholder="Ingrese la URL de la imagen" OnTextChanged="txtImagenUrl_TextChanged"></asp:TextBox>
                        <br />
                        <br />

                        <asp:FileUpload ID="fileUploadImagen" runat="server" />
                        <asp:Button ID="btnSubirImagen" runat="server" Text="Cargar imagen desde archivo" OnClick="btnSubirImagen_Click" />
                        <br />
                        <br />

                        <asp:Image ImageUrl="~/Content/Images/place-holder.jpg" ID="imgPreview" runat="server" Width="350px" Height="350px" />
                    </div>
                    <div class="mb-3">
                        <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                        <a class="btn btn-warning mx-3" href="Lista.aspx">Cancelar</a>
                        <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" runat="server" />
                    </div>
                </div>
    </div>
    </div>
</asp:Content>
