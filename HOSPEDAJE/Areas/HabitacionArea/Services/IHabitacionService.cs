using HOSPEDAJE.Areas.HabitacionArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.HabitacionArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.HabitacionArea.Services
{
    public interface IHabitacionService
    {
        Task<MensajePersonalizado1DTO<List<CategoriaDTO>>> ListaCategorias();
        Task<MensajePersonalizado1DTO<List<HabitacionesDisponiblesDTO>>> ListaHabitacionesDisponibles();
        Task<MensajePersonalizado1DTO<List<HabitacionesDisponiblesDTO>>> FiltrarHabitacionesDisponibles(FormBuscarHDDTO formBuscarHDDTO);
        Task<MensajePersonalizado3DTO<HabitacionDTO?, DetalleHabitacionDTO?, List<ImagenHabitacionDTO>>> DetalleHabitacion(int idHabitacion);
    }
}
