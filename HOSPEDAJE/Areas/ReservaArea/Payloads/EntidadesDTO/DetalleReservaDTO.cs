namespace HOSPEDAJE.Areas.ReservaArea.Payloads.EntidadesDTO
{
    public class DetalleReservaDTO
    {
        public int IdReserva { get; set; }

        public int IdHabitacion { get; set; }

        public int CantidadPersonas { get; set; }

        public string? TipoServicio { get; set; }

        public decimal? CostoServicio { get; set; }

        public decimal? PagoParcial { get; set; }

        public DateTime? FechaPago { get; set; }

        public string? EstadoPago { get; set; }

        public DateTime? FechaUltimaModificacion { get; set; }
    }
}
