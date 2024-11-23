using HOSPEDAJE.Areas.HabitacionArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.HabitacionArea.Payloads.MensajesDTO;
using HOSPEDAJE.Areas.HabitacionArea.Repository;

namespace HOSPEDAJE.Areas.HabitacionArea.Services.MicroServices.HabitacionCRUD.ReadMS
{
    public class ReadHabitacionMS : IReadHabitacionMS
    {
        private readonly IHabitacionRepository _IHabitacionRepository;
        public ReadHabitacionMS(IHabitacionRepository iHabitacionRepository)
        {
            _IHabitacionRepository = iHabitacionRepository;
        }

        public async Task<MensajePersonalizado1DTO<List<CategoriaDTO>>> ListaCategorias()
        {
            var categorias = await _IHabitacionRepository.ListaCategorias();
            if (categorias == null || categorias.Count == 0)
            {
                return new MensajePersonalizado1DTO<List<CategoriaDTO>>
                {
                    EsExito = false,
                    Descripcion = "no hay categroias disponibles",
                    DTO = null
                };
            }
            return new MensajePersonalizado1DTO<List<CategoriaDTO>>
            {
                EsExito = true,
                Descripcion = "mi lista de categorias disponibles",
                DTO = categorias
            };
        }
        public async Task<MensajePersonalizado1DTO<List<HabitacionesDisponiblesDTO>>> ListaHabitacionesDisponibles()
        {
            var habitacionesDisponibles = await _IHabitacionRepository.ListaHabitacionesDisponibles();
            if (habitacionesDisponibles == null || habitacionesDisponibles.Count == 0)
            {
                return new MensajePersonalizado1DTO<List<HabitacionesDisponiblesDTO>>
                {
                    EsExito = false,
                    Descripcion = "Lo sentimos por ahora no hay habitacioens disponibles",
                    DTO = null
                };
            }
            return new MensajePersonalizado1DTO<List<HabitacionesDisponiblesDTO>>
            {
                EsExito = true,
                Descripcion = "Estas habiatciones estan disponibles para usted",
                DTO = habitacionesDisponibles
            };
        }
        public async Task<MensajePersonalizado1DTO<List<HabitacionesDisponiblesDTO>>> FiltrarHabitacionesDisponibles(FormBuscarHDDTO formBuscarHDDTO)
        {
            var habitacionesDisponibles = await _IHabitacionRepository.FiltrarHabitacionesDisponibles(formBuscarHDDTO.FechaEntrada, formBuscarHDDTO.FechaSalida, formBuscarHDDTO.IdCategoria);
            if (habitacionesDisponibles == null || habitacionesDisponibles.Count == 0)
            {
                return new MensajePersonalizado1DTO<List<HabitacionesDisponiblesDTO>>
                {
                    EsExito = false,
                    Descripcion = "Lo sentimos por ahora no hay habitacioens disponibles",
                    DTO = null
                };
            }
            return new MensajePersonalizado1DTO<List<HabitacionesDisponiblesDTO>>
            {
                EsExito = true,
                Descripcion = "Estas habiatciones estan disponibles para usted",
                DTO = habitacionesDisponibles
            };
        }
        public async Task<MensajePersonalizado3DTO<HabitacionDTO?, DetalleHabitacionDTO?, List<ImagenHabitacionDTO>>> DetalleHabitacion(int idHabitacion)
        {
            var habitacion = await _IHabitacionRepository.ConsultarHabitacion(idHabitacion);
            var detalleHabitacion = await _IHabitacionRepository.ConsultarDetalleHabitacion(idHabitacion);
            var imagenesHabitacion = await _IHabitacionRepository.ConsultarImagenHabitacion(idHabitacion);

            if (habitacion == null)
            {
                return new MensajePersonalizado3DTO<HabitacionDTO?, DetalleHabitacionDTO?, List<ImagenHabitacionDTO>>
                {
                    EsExito = false,
                    Descripcion = "Habitación no encontrada",
                    DTO1 = null,
                    DTO2 = null,
                    DTO3 = null
                };
            }

            if (detalleHabitacion == null)
            {
                return new MensajePersonalizado3DTO<HabitacionDTO?, DetalleHabitacionDTO?, List<ImagenHabitacionDTO>>
                {
                    EsExito = false,
                    Descripcion = "Detalle de la habitación no encontrado",
                    DTO1 = habitacion,
                    DTO2 = null,
                    DTO3 = imagenesHabitacion
                };
            }

            if (imagenesHabitacion == null || !imagenesHabitacion.Any())
            {
                return new MensajePersonalizado3DTO<HabitacionDTO?, DetalleHabitacionDTO?, List<ImagenHabitacionDTO>>
                {
                    EsExito = false,
                    Descripcion = "Imágenes de la habitación no encontradas",
                    DTO1 = habitacion,
                    DTO2 = detalleHabitacion,
                    DTO3 = null
                };
            }
            return new MensajePersonalizado3DTO<HabitacionDTO?, DetalleHabitacionDTO?, List<ImagenHabitacionDTO>>
            {
                EsExito = true,
                Descripcion = "Se encontró con éxito todos los detalles de la habitación",
                DTO1 = habitacion,
                DTO2 = detalleHabitacion,
                DTO3 = imagenesHabitacion
            };
        }
    }
}