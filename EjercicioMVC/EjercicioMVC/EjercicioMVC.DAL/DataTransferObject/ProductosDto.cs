namespace EjercicioMVC.DAL
{
    public class ProductosDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public ProductosTiposDto productosTipoDto { get; set; }
    }
}
