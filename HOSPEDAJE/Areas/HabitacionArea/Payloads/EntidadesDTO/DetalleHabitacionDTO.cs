namespace HOSPEDAJE.Areas.HabitacionArea.Payloads.EntidadesDTO
{
    public class DetalleHabitacionDTO
    {
        public int? IdHabitacion { get; set; }
        public decimal TamanioHabitacion { get; set; }
        public string? TipoCama { get; set; }
        public int NumeroCamas { get; set; }
        public int CapacidadPersonas { get; set; }
        public string? Vistas { get; set; }
        public string? Accesibilidad { get; set; }
        public string? TipoBano { get; set; }
        public string? Wifi { get; set; }
        public string? Television { get; set; }
        public string? Ducha { get; set; }
        public string? Ventilador { get; set; }
        public string? Calefaccion { get; set; }
        public string? AireAcondicionado { get; set; }
        public string? FrigoBar { get; set; }
        public string? Piso { get; set; }
        public string? Extras { get; set; }
        public string? ServiciosAdicionales { get; set; }
    }
}
