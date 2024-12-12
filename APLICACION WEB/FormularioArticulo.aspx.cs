using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace APLICACION_WEB
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            try
            {
                if (!IsPostBack)
                {
                    CategoriaNegocio cat_negocio = new CategoriaNegocio();
                    List<Categoria> lista_categoria = cat_negocio.listar();
                    MarcaNegocio mar_negocio = new MarcaNegocio();
                    List<Marca> lista_marca = mar_negocio.listar();

                    ddlCategoria.DataSource = lista_categoria;
                    ddlCategoria.DataValueField = "id";
                    ddlCategoria.DataTextField = "descripcion";
                    ddlCategoria.DataBind();

                    ddlMarca.DataSource = lista_marca;
                    ddlMarca.DataValueField = "id";
                    ddlMarca.DataTextField = "descripcion";
                    ddlMarca.DataBind();
                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ArticulosNegocio art_negocio = new ArticulosNegocio();
                    List<Articulo> lista_articulos = art_negocio.listar(id);
                    Articulo seleccionado = lista_articulos[0];

                    Session.Add("articulo_seleccionado", seleccionado);

                    txtID.Text = id;
                    txtCodigo.Text = seleccionado.codigo;
                    txtNombre.Text = seleccionado.nombre;
                    txtDescripcion.Text = seleccionado.descripcion;
                    txtPrecio.Text = seleccionado.precio.ToString();
                    txtImagenUrl.Text = seleccionado.imagen;

                    ddlMarca.SelectedValue = seleccionado.marca.id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.categoria.id.ToString();
                    txtImagenUrl_TextChanged(sender, e);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSubirImagen_Click(object sender, EventArgs e)
        {

            // Verifica si el usuario ha seleccionado un archivo
            if (fileUploadImagen.HasFile)
            {
                try
                {
                    // Define la ruta donde se guardará la imagen
                    string rutaCarpeta = Server.MapPath("~/UploadedImages/");
                    string nombreArchivo = fileUploadImagen.FileName;

                    // Verifica si la carpeta existe, y si no, la crea
                    if (!System.IO.Directory.Exists(rutaCarpeta))
                    {
                        System.IO.Directory.CreateDirectory(rutaCarpeta);
                    }

                    // Guarda el archivo en la carpeta
                    string rutaCompleta = rutaCarpeta + nombreArchivo;
                    fileUploadImagen.SaveAs(rutaCompleta);

                    // Asigna la URL de la imagen al TextBox y muestra una vista previa
                    txtImagenUrl.Text = "~/UploadedImages/" + nombreArchivo;
                    imgPreview.ImageUrl = "~/UploadedImages/" + nombreArchivo;
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Response.Write("<script>alert('Error al subir la imagen: " + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Por favor, seleccione un archivo.');</script>");
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtImagenUrl.Text))
            {
                imgPreview.ImageUrl = txtImagenUrl.Text;
            }
            else
            {
                imgPreview.ImageUrl = "~/Content/Images/place-holder.jpg";
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ArticulosNegocio negocio = new ArticulosNegocio();

                nuevo.codigo = txtCodigo.Text;
                nuevo.nombre = txtNombre.Text;
                nuevo.descripcion = txtDescripcion.Text;
                nuevo.precio = decimal.Parse(txtPrecio.Text);
                nuevo.imagen = txtImagenUrl.Text;

                nuevo.categoria = new Categoria();
                nuevo.categoria.id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.marca = new Marca();
                nuevo.marca.id = int.Parse(ddlMarca.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.id = int.Parse(Request.QueryString["id"].ToString());
                    negocio.modificar(nuevo);
                }
                else
                {
                    negocio.agregar(nuevo);
                }
                Response.Redirect("Lista.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticulosNegocio art_negocio = new ArticulosNegocio();
                art_negocio.eliminar(int.Parse(txtID.Text));
                Response.Redirect("Lista.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnGuardarMarca_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNuevaMarca.Text.Trim()))
            {
                Marca nueva_marca = new Marca();
                nueva_marca.descripcion = txtDescripcion.Text.Trim();

                try
                {
                    MarcaNegocio marca_negocio = new MarcaNegocio();
                    marca_negocio.agregar(nueva_marca);
                    lblMensaje.Text = "Marca agregada correctamente";
                    lblMensaje.CssClass = "text-success";

                    txtDescripcion.Text = "";

                    ddlMarca.Items.Add(nueva_marca.ToString());

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                lblMensaje.Text = "El campo marca es obligatorio";
                lblMensaje.CssClass = "text-danger";
                return;
            }
        }
    }

}