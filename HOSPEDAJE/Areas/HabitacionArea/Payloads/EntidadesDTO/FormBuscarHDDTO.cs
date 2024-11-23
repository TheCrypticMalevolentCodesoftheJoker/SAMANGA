namespace HOSPEDAJE.Areas.HabitacionArea.Payloads.EntidadesDTO
{
    public class FormBuscarHDDTO
    {
        public DateOnly FechaEntrada { get; set; }
        public DateOnly FechaSalida { get; set; }
        public int IdCategoria { get; set; }
        public FormBuscarHDDTO() { }
    }
}
