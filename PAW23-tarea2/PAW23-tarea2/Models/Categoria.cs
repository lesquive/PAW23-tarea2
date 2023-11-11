namespace PAW23_tarea2.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }

        public List<ProductoCategoria> ProductosCategorias { get; set; }
    }

}
