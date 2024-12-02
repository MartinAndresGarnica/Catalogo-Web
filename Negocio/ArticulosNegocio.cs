using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticulosNegocio
    {
        public List<Articulo> listar(string id = "")
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select a.id_articulo, a.codigo, a.nombre, a.descripcion, a.imagen, a.precio, c.id_categoria, m.id_marca " +
                    "c.descripcion as categoria, m.descripcion as marca from articulo a JOIN categoria c ON a.id_categoria = c.id_categoria " +
                    "JOIN marca m ON a.id_marca = m.id_marca ");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)datos.Lector["id"];
                    aux.codigo = (string)datos.Lector["codigo"];
                    aux.nombre = (string)datos.Lector["nombre"];
                    aux.descripcion = (string)datos.Lector["descripcion"];
                    aux.imagen = (string)datos.Lector["imagen"];
                    aux.precio = (decimal)datos.Lector["precio"];
                    aux.categoria = new Categoria();
                    aux.categoria.id = (int)datos.Lector["id_categoria"];
                    aux.categoria.descripcion = (string)datos.Lector["categoria"];
                    aux.marca = new Marca();
                    aux.marca.id = (int)datos.Lector["id_marca"];
                    aux.marca.descripcion = (string)datos.Lector["marca"];

                    lista.Add(aux);
                }
                datos.cerrarConexion();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
