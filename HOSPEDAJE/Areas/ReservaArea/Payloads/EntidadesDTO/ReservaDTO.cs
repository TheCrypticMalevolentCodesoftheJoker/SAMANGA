namespace HOSPEDAJE.Areas.ReservaArea.Payloads.EntidadesDTO
{
    public class ReservaDTO
    {
        public int IdReserva { get; set; }

        public int IdCliente { get; set; }

        public DateTime? FechaReserva { get; set; }

        public DateOnly FechaEntrada { get; set; }

        public DateOnly FechaSalida { get; set; }

        public string? Estado { get; set; }

        public decimal TotalPago { get; set; }

        public string? MetodoPago { get; set; }

        public string Correo { get; set; }
    }
}
