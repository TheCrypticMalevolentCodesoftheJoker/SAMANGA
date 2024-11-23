using HOSPEDAJE.Areas.HabitacionArea.Payloads.EntidadesDTO;

namespace HOSPEDAJE.Areas.HabitacionArea.Repository
{
    public interface IHabitacionRepository
    {
        Task<List<CategoriaDTO>> ListaCategorias();
        Task<List<HabitacionesDisponiblesDTO>> ListaHabitacionesDisponibles();
        Task<List<HabitacionesDisponiblesDTO>> FiltrarHabitacionesDisponibles(DateOnly fechaEntrada, DateOnly fechaSalida, int? idCategoria);
        Task<HabitacionDTO?> ConsultarHabitacion(int idHabitacion);
        Task<DetalleHabitacionDTO?> ConsultarDetalleHabitacion(int idHabitacion);
        Task<List<ImagenHabitacionDTO>> ConsultarImagenHabitacion(int idHabitacion);
    }
}
