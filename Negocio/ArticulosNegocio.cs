using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using MySql.Data.MySqlClient;

namespace Negocio
{
    public class ArticulosNegocio
    {
        public List<Articulo> listar(string id = "")
        {
            List<Articulo> lista = new List<Articulo>();
            MySqlConnection conexion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();
            MySqlDataReader lector;


            try
            {
                conexion.ConnectionString = "Server=localhost;Database=CATALOGO_WEB_DB;Uid=martin;Pwd=123456789";
                comando.CommandType = System.Data.CommandType.Text;
                string tieneID = "";

                if (id != "")
                {
                    tieneID = "where " + id + " = a.id_articulo "; 
                }

                comando.Connection = conexion;
                comando.CommandText = "select a.id_articulo, a.codigo, a.nombre, a.descripcion, a.imagen, a.precio, " +
                    "c.id_categoria, m.id_marca, c.descripcion as categoria, m.descripcion as marca from articulo a " +
                    "JOIN categoria c ON a.id_categoria = c.id_categoria JOIN marca m ON a.id_marca = m.id_marca " + tieneID +"order by a.id_articulo;";

                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)lector["id_articulo"];
                    aux.codigo = (string)lector["codigo"];
                    aux.nombre = (string)lector["nombre"];
                    aux.descripcion = (string)lector["descripcion"];
                    if (!(lector["imagen"] is DBNull))
                        aux.imagen = (string)lector["imagen"];
                    if (string.IsNullOrEmpty(aux.imagen))
                        aux.imagen = "Content/Images/place-holder.jpg";
                    aux.precio = (decimal)lector["precio"];
                    aux.categoria = new Categoria();
                    aux.categoria.id = (int)lector["id_categoria"];
                    aux.categoria.descripcion = (string)lector["categoria"];
                    aux.marca = new Marca();
                    aux.marca.id = (int)lector["id_marca"];
                    aux.marca.descripcion = (string)lector["marca"];

                    lista.Add(aux);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Articulo> ordenar(string campo)
        {
            List<Articulo> lista_filtrada = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select a.id_articulo, a.codigo, a.nombre, a.descripcion, a.imagen, a.precio, " +
                    "c.id_categoria, m.id_marca, c.descripcion as categoria, m.descripcion as marca from articulo a " +
                    "JOIN categoria c ON a.id_categoria = c.id_categoria JOIN marca m ON a.id_marca = m.id_marca order by ";

                switch (campo)
                {
                    case "Mayor precio":
                        consulta += "precio desc";
                        break;
                    case "Menor precio":
                        consulta += "precio";
                        break;
                    case "Marca ascendente":
                        consulta += "marca";
                        break;
                    default:
                        consulta += "marca desc";
                        break;
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)datos.Lector["id_articulo"];
                    aux.codigo = (string)datos.Lector["codigo"];
                    aux.nombre = (string)datos.Lector["nombre"];
                    aux.descripcion = (string)datos.Lector["descripcion"];
                    if (!(datos.Lector["imagen"] is DBNull))
                        aux.imagen = (string)datos.Lector["imagen"];
                    aux.precio = (decimal)datos.Lector["precio"];
                    aux.categoria = new Categoria();
                    aux.categoria.id = (int)datos.Lector["id_categoria"];
                    aux.categoria.descripcion = (string)datos.Lector["categoria"];
                    aux.marca = new Marca();
                    aux.marca.id = (int)datos.Lector["id_marca"];
                    aux.marca.descripcion = (string)datos.Lector["marca"];

                    lista_filtrada.Add(aux);
                }
                datos.cerrarConexion();
                return lista_filtrada;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULO set codigo = @codigo, nombre = @nombre, descripcion = @descripcion," +
                    " imagen = @imagen, precio = @precio, id_marca = @id_marca, id_categoria = @id_categoria where id_articulo = @id_articulo");
                datos.setearParametros("@codigo", art.codigo);
                datos.setearParametros("@nombre", art.nombre);
                datos.setearParametros("@descripcion", art.descripcion);
                datos.setearParametros("@imagen", art.imagen);
                datos.setearParametros("@precio", art.precio);
                datos.setearParametros("@id_marca", art.marca.id);
                datos.setearParametros("@id_categoria", art.categoria.id);
                datos.setearParametros("@id_articulo", art.id);

                datos.ejecutarAccion();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void agregar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULO (codigo, nombre, descripcion, imagen, precio, id_marca, id_categoria)" +
                    "values (@codigo, @nombre, @descripcion, @imagen, @precio, @id_marca, @id_categoria)");
                datos.setearParametros("@codigo", art.codigo);
                datos.setearParametros("@nombre", art.nombre);
                datos.setearParametros("@descripcion", art.descripcion);
                datos.setearParametros("@imagen", art.imagen);
                datos.setearParametros("@precio", art.precio);
                datos.setearParametros("@id_marca", art.marca.id);
                datos.setearParametros("@id_categoria", art.categoria.id);

                datos.ejecutarAccion();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("Delete from Articulo where id_articulo = @id_articulo");
                datos.setearParametros("@id_articulo", id);
                datos.ejecutarAccion();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
