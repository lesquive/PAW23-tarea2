namespace PAW23_tarea2.Models
{
    public class ProductoCategoria
    {
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }

}
