
namespace HOSPEDAJE.Areas.HabitacionArea.Payloads.MensajesDTO
{
    public class MensajePersonalizado3DTO<DATA1, DATA2, DATA3>
    {
        public bool EsExito { get; set; }
        public string? Descripcion { get; set; }
        public DATA1? DTO1 { get; set; }
        public DATA2? DTO2 { get; set; }
        public DATA3? DTO3 { get; set; }
        public MensajePersonalizado3DTO() { }
    }
}
