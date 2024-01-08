using SistemaVenta.Entity;

namespace SistemaVenta.AplicacionWeb.Models.ViewModels
{
    public class VMVenta
    {

        public int IdVenta { get; set; }
        public string? NumeroVenta { get; set; }
        public int? IdUsuario { get; set; }

        //este Usuario fue creado
        public string? Usuario { get; set; }
        public string? DocumentoCliente { get; set; }
        //este NombreCliente fue creadi
        public string? NombreCliente { get; set; }
       // public string? NumeroCliente { get; set; }
        public string? SubTotal { get; set; }
        public string? ImpuestoTotal { get; set; }
        public string? Total { get; set; }
        //este FechaRegistro fue creado
        public string? FechaRegistro { get; set; }

        public virtual ICollection<VMDetalleVenta> DetalleVenta { get; set; }
    }
}
