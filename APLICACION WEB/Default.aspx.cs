using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;


namespace APLICACION_WEB
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> lista_articulo { get; set; }
        public List<Categoria> lista_categoria { get; set; }
        public List<Marca> lista_marca { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio art_negocio = new ArticulosNegocio();
            lista_articulo = art_negocio.listar();
            CategoriaNegocio cat_negocio = new CategoriaNegocio();
            lista_categoria = cat_negocio.listar();
            MarcaNegocio mar_negocio = new MarcaNegocio();
            lista_marca = mar_negocio.listar();

            if (!IsPostBack)
            {
                repetidor.DataSource = lista_articulo;
                repetidor.DataBind();
                ddlCategoria.DataSource = lista_categoria;
                ddlCategoria.DataBind();
                ddlCategoria.Items.Add("Todos");
                ddlMarca.DataSource = lista_marca;
                ddlMarca.DataBind();
                ddlMarca.Items.Add("Todos");
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {

        }

        protected void ddlOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ArticulosNegocio art_negocio = new ArticulosNegocio();
                repetidor.DataSource = art_negocio.ordenar(ddlOrden.SelectedItem.ToString());
                repetidor.DataBind();
            }
            catch (Exception)
            {

                throw ;
            }
        }
    }
}