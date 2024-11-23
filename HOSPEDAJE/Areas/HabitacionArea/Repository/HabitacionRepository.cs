using HOSPEDAJE.Data;
using Microsoft.EntityFrameworkCore;
using HOSPEDAJE.Areas.HabitacionArea.Payloads.EntidadesDTO;

namespace HOSPEDAJE.Areas.HabitacionArea.Repository
{
    public class HabitacionRepository : IHabitacionRepository
    {
        private readonly ApplicationDbContext _DbContext;
        public HabitacionRepository(ApplicationDbContext applicationDbContext)
        {
            _DbContext = applicationDbContext;
        }

        public async Task<List<CategoriaDTO>> ListaCategorias()
        {
            var categorias = await _DbContext.TblCategoria
                .Select(c => new CategoriaDTO
                {
                    IdCategoria = c.IdCategoria,
                    Categoria = c.Categoria,
                })
                .ToListAsync();

            return categorias;
        }
        public async Task<List<HabitacionesDisponiblesDTO>> ListaHabitacionesDisponibles()
        {
            var habitacionesDisponibles = await _DbContext.TblHabitacion
                .Include(h => h.IdEstadoNavigation)
                .Include(h => h.IdCategoriaNavigation)
                .Where(h => h.IdEstadoNavigation.Estado == "Disponible")
                .Select(h => new HabitacionesDisponiblesDTO
                {
                    IdHabitacion = h.IdHabitacion,
                    IdCategoria = h.IdCategoria,
                    NombreCategoria = h.IdCategoriaNavigation.Categoria,
                    IdEstado = h.IdEstado,
                    NombreEstado = h.IdEstadoNavigation.Estado,
                    Numero = h.Numero,
                    Precio = h.Precio,
                    Descripcion = h.Descripcion,
                    ImagenUrl = h.TblImagenHabitacion
                                .OrderBy(i => i.IdImagen)
                                .Select(i => i.UrlImagen)
                                .FirstOrDefault()
                })
                .ToListAsync();
            return habitacionesDisponibles;
        }
        public async Task<List<HabitacionesDisponiblesDTO>> FiltrarHabitacionesDisponibles(DateOnly fechaEntrada, DateOnly fechaSalida, int? idCategoria)
        {
            var habitacionesDisponibles = await _DbContext.TblHabitacion
                .Include(h => h.IdEstadoNavigation)
                .Include(h => h.IdCategoriaNavigation)
                .Where(h =>
                    h.IdEstadoNavigation.Estado == "Disponible" &&
                    (idCategoria == null || h.IdCategoria == idCategoria) &&
                    !_DbContext.TblDetalleReserva
                        .Where(dr => dr.IdHabitacion == h.IdHabitacion)
                        .Join(_DbContext.TblReserva,
                            dr => dr.IdReserva,
                            r => r.IdReserva,
                            (dr, r) => r)
                        .Any(r =>
                            (r.FechaEntrada >= fechaEntrada && r.FechaEntrada < fechaSalida) ||
                            (r.FechaSalida > fechaEntrada && r.FechaSalida <= fechaSalida) ||
                            (fechaEntrada >= r.FechaEntrada && fechaEntrada < r.FechaSalida) ||
                            (fechaSalida > r.FechaEntrada && fechaSalida <= r.FechaSalida))
                )
                .Select(h => new HabitacionesDisponiblesDTO
                {
                    IdHabitacion = h.IdHabitacion,
                    IdCategoria = h.IdCategoria,
                    NombreCategoria = h.IdCategoriaNavigation.Categoria,
                    IdEstado = h.IdEstado,
                    NombreEstado = h.IdEstadoNavigation.Estado,
                    Numero = h.Numero,
                    Precio = h.Precio,
                    Descripcion = h.Descripcion,
                    ImagenUrl = h.TblImagenHabitacion
                                .OrderBy(i => i.IdImagen)
                                .Select(i => i.UrlImagen)
                                .FirstOrDefault()
                })
                .ToListAsync();

            return habitacionesDisponibles;
        }
        public async Task<HabitacionDTO?> ConsultarHabitacion(int idHabitacion)
        {
            var habitacion = await _DbContext.TblHabitacion
                .Where(h => h.IdHabitacion == idHabitacion)
                .Include(h => h.IdEstadoNavigation)
                .Include(h => h.IdCategoriaNavigation)
                .Select(h => new
                {
                    h.IdHabitacion,
                    h.IdCategoria,
                    NombreCategoria = h.IdCategoriaNavigation.Categoria,
                    h.IdEstado,
                    NombreEstado = h.IdEstadoNavigation.Estado,
                    h.Numero,
                    h.Precio,
                    h.Descripcion
                })
                .FirstOrDefaultAsync();

            if (habitacion == null)
            {
                return null;
            }

            return new HabitacionDTO
            {
                IdHabitacion = habitacion.IdHabitacion,
                IdCategoria = habitacion.IdCategoria,
                NombreCategoria = habitacion.NombreCategoria,
                IdEstado = habitacion.IdEstado,
                NombreEstado = habitacion.NombreEstado,
                Numero = habitacion.Numero,
                Precio = habitacion.Precio,
                Descripcion = habitacion.Descripcion
            };
        }
        public async Task<DetalleHabitacionDTO?> ConsultarDetalleHabitacion(int idHabitacion)
        {
            var detalleHabitacion = await _DbContext.TblHabitacion
                .Where(h => h.IdHabitacion == idHabitacion)
                .Include(h => h.TblDetalleHabitacion)
                .Select(h => h.TblDetalleHabitacion.FirstOrDefault())
                .FirstOrDefaultAsync();

            if (detalleHabitacion == null)
            {
                return null;
            }

            return new DetalleHabitacionDTO
            {
                TamanioHabitacion = detalleHabitacion.TamanioHabitacion,
                TipoCama = detalleHabitacion.TipoCama,
                NumeroCamas = detalleHabitacion.NumeroCamas,
                CapacidadPersonas = detalleHabitacion.CapacidadPersonas,
                Vistas = detalleHabitacion.Vistas,
                Accesibilidad = detalleHabitacion.Accesibilidad,
                TipoBano = detalleHabitacion.TipoBano,
                Wifi = detalleHabitacion.Wifi,
                Television = detalleHabitacion.Television,
                Ducha = detalleHabitacion.Ducha,
                Ventilador = detalleHabitacion.Ventilador,
                Calefaccion = detalleHabitacion.Calefaccion,
                AireAcondicionado = detalleHabitacion.AireAcondicionado,
                FrigoBar = detalleHabitacion.FrigoBar,
                Piso = detalleHabitacion.Piso,
                Extras = detalleHabitacion.Extras,
                ServiciosAdicionales = detalleHabitacion.ServiciosAdicionales,
            };
        }
        public async Task<List<ImagenHabitacionDTO>> ConsultarImagenHabitacion(int idHabitacion)
        {
            var imagenes = await _DbContext.TblImagenHabitacion
                .Where(i => i.IdHabitacion == idHabitacion)
                .Select(i => new ImagenHabitacionDTO
                {
                    UrlImagen = i.UrlImagen,
                })
                .ToListAsync();

            return imagenes;
        }

    }
}
