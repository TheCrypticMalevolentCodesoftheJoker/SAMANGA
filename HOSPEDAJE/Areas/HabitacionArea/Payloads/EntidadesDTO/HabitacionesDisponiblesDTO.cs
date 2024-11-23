namespace HOSPEDAJE.Areas.HabitacionArea.Payloads.EntidadesDTO
{
    public class HabitacionesDisponiblesDTO
    {
        public string? ImagenUrl { get; set; }
        public int IdHabitacion { get; set; }
        public int IdCategoria { get; set; }
        public string? NombreCategoria { get; set; }
        public int IdEstado { get; set; }
        public string? NombreEstado { get; set; }
        public string? Numero { get; set; }
        public decimal Precio { get; set; }
        public string? Descripcion { get; set; }
    }
}
