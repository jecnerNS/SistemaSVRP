namespace SistemaVenta.AplicacionWeb.Models.ViewModels
{
    public class VMReporteVenta
    {

        public string? FechaRegistro { get; set; }

        public string? NumeroVenta { get; set; }

        public string? TipoDocumento { get; set; }

        public string? DocumentoCliente { get; set; }

        //lo cambie de NombreCliente a NumeroCliente
        public string? NumeroCliente { get; set; }

        public string? SubTotalVenta { get; set; }

        public string? ImpuestoTotalVenta { get; set; }

        public string? TotalVenta { get; set; }

        public string? Producto { get; set; }

        public int? Cantidad { get; set; }

        public string? Precio { get; set; }

        public string? Total { get; set; }


    }
}
