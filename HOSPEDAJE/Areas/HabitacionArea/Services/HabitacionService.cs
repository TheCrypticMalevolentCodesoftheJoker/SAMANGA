using HOSPEDAJE.Areas.HabitacionArea.Services.MicroServices.HabitacionCRUD.ReadMS;
using HOSPEDAJE.Areas.HabitacionArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.HabitacionArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.HabitacionArea.Services
{
    public class HabitacionService : IHabitacionService
    {
        private readonly IReadHabitacionMS _IReadHabitacionMS;
        public HabitacionService(IReadHabitacionMS iReadHabitacionMS)
        {
            _IReadHabitacionMS = iReadHabitacionMS;
        }

        public async Task<MensajePersonalizado1DTO<List<CategoriaDTO>>> ListaCategorias()
        {
            return await _IReadHabitacionMS.ListaCategorias();
        }
        public async Task<MensajePersonalizado1DTO<List<HabitacionesDisponiblesDTO>>> ListaHabitacionesDisponibles()
        {
            return await _IReadHabitacionMS.ListaHabitacionesDisponibles();
        }
        public async Task<MensajePersonalizado1DTO<List<HabitacionesDisponiblesDTO>>> FiltrarHabitacionesDisponibles(FormBuscarHDDTO formBuscarHDDTO)
        {
            return await _IReadHabitacionMS.FiltrarHabitacionesDisponibles(formBuscarHDDTO);
        }
        public async Task<MensajePersonalizado3DTO<HabitacionDTO?, DetalleHabitacionDTO?, List<ImagenHabitacionDTO>>> DetalleHabitacion(int idHabitacion)
        {
            return await _IReadHabitacionMS.DetalleHabitacion(idHabitacion);
        }
    }
}
