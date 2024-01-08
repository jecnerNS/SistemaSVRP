using System;
using System.Collections.Generic;

namespace SistemaVenta.Entity
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        //agregue codigoBarra
       // public int? CodigoBarra { get; set; }

        //cambiamos el nombre Descripcion a CodigoBarra
        public string? Descripcion { get; set; }
        public int? IdCategoria { get; set; }
        public int? Stock { get; set; }
        public string? UrlImagen { get; set; }
        public string? NombreImagen { get; set; }
        public decimal? Precio { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual Categoria? IdCategoriaNavigation { get; set; }
    }
}
