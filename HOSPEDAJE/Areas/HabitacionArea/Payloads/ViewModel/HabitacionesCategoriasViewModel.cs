using HOSPEDAJE.Areas.HabitacionArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.HabitacionArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.HabitacionArea.Payloads.ViewModel
{
    public class HabitacionesCategoriasViewModel
    {
        public MensajePersonalizado1DTO<List<HabitacionesDisponiblesDTO>>? Habitaciones { get; set; }
        public MensajePersonalizado1DTO<List<CategoriaDTO>>? Categorias { get; set; }
        public FormBuscarHDDTO FormBuscarHDDTO { get; set; } = new FormBuscarHDDTO();
    }
}
