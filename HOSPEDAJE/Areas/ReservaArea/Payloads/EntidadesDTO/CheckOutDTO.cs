namespace HOSPEDAJE.Areas.ReservaArea.Payloads.EntidadesDTO
{
    public class CheckOutDTO
    {
        public int IdReserva { get; set; }
        public DateOnly FechaEntrada { get; set; }
        public DateOnly FechaSalida { get; set; }
        public int IdCliente { get; set; }
        public string? NombreCliente { get; set; }
        public int IdHabitacion { get; set; }
        public string? NumeroHabitacion { get; set; }
        public string? Estado { get; set; }
    }
}
