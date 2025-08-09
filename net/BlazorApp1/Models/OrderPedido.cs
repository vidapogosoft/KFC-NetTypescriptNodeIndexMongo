namespace BlazorApp1.Models
{
    public class OrderPedido
    {
        public int IdOrderCab { get; set; }

        public int? IdOrderDispo { get; set; }

        public string? CodTienda { get; set; }

        public string? Tienda { get; set; }

        public string? Enviado { get; set; }

        public string? Observacion { get; set; }

        public string? UsuarioIngreso { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public string? FechaIngresoConsulta { get; set; }

        public DateTime? FechaSyncIngreso { get; set; }

        public string? FechaSyncIngresoConsulta { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public string? UsuarioModificacion { get; set; }

        public string? Estado { get; set; }

        public string? JsonOrder { get; set; }

        public string? Version { get; set; }

        public string? Detalle { get; set; }

        public string? GestionadoPor { get; set; }
    }
}
