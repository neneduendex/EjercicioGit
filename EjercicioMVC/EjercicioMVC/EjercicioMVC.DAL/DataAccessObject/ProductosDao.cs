using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace EjercicioMVC.DAL
{
    public class ProductosDao : IProductosDao
    {
        public List<ProductosDto> GetProductos()
        {
            List<ProductosDto> productosDtos = new List<ProductosDto>();

            try
            {
                //obteniendo productos de la base de datos
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["StringCon"].ToString()))
                {
                    con.Open();

                    string queryCode = "SELECT Productos.ProductoId, Productos.ProductoNombre, Productos.Precio, ProductosTipo.ProductosTipoNombre" +
                        " FROM Productos INNER JOIN ProductosTipo ON Productos.ProductosTipoId = ProductosTipo.ProductosTipoId";

                    SqlCommand query = new SqlCommand(queryCode, con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ProductosDto productosDto = new ProductosDto();
                            productosDto.id = Convert.ToInt32(dr["ProductoId"]);
                            productosDto.nombre = dr["ProductoNombre"].ToString();
                            productosDto.precio = Convert.ToDecimal(dr["Precio"]);
                            productosDto.productosTipoDto = new ProductosTiposDto();
                            productosDto.productosTipoDto.nombre = dr["ProductosTipoNombre"].ToString();
                            productosDtos.Add(productosDto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
            }

            return productosDtos;
        }

        public ProductosDto GetProductosById(int id)
        {
            ProductosDto productosDto = new ProductosDto();
            //obtener el producto de la base de datos
            return productosDto;
        }
    }
}
