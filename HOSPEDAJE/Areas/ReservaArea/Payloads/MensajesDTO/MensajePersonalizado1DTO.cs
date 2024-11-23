using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HOSPEDAJE.Areas.ReservaArea.Payloads.MensajesDTO
{
    public class MensajePersonalizado1DTO<DATA>
    {
        public bool EsExito { get; set; }
        public string? Descripcion { get; set; }
        public DATA? DTO { get; set; }
        public MensajePersonalizado1DTO() { }
    }
}
