namespace HOSPEDAJE.Areas.HabitacionArea.Payloads.EntidadesDTO
{
    public class HabitacionDTO
    {
        public int IdHabitacion { get; set; }
        public int IdCategoria { get; set; }
        public string? NombreCategoria { get; set; }
        public int IdEstado { get; set; }
        public string? NombreEstado { get; set; }
        public string Numero { get; set; } = null!;
        public decimal Precio { get; set; }
        public string? Descripcion { get; set; }
    }
}