namespace SistemaVenta.AplicacionWeb.Models.ViewModels
{
    public class VMProducto
    {

        public int IdProducto { get; set; }

        //CodigoBarra fue creado
       // public string? CodigoBarra { get; set; }
        //Marca fue creado
        public string? Marca { get; set; }


        //lo cambie Descripcion a CodigoBarra
        public string? Descripcion { get; set; }
        public int? IdCategoria { get; set; }

        //NombreCategoria fue creado
        public string? NombreCategoria { get; set; }
        public int? Stock { get; set; }
        public string? UrlImagen { get; set; }
        //public string? NombreImagen { get; set; }
        public string? Precio { get; set; }
        public int? EsActivo { get; set; }
    }
}
