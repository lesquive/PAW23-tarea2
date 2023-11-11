namespace PAW23_tarea2.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaDeVencimiento { get; set; }

        public List<ProductoCategoria> ProductosCategorias { get; set; }
    }
}
