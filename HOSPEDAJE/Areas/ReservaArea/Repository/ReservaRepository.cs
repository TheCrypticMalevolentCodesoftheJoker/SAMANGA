
using HOSPEDAJE.Areas.ReservaArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Data;
using HOSPEDAJE.Models;
using Microsoft.EntityFrameworkCore;

namespace HOSPEDAJE.Areas.ReservaArea.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly ApplicationDbContext _DbContext;
        public ReservaRepository(ApplicationDbContext applicationDbContext)
        {
            _DbContext = applicationDbContext;
        }

        public async Task<ReservaDTO> RegistrarReserva(ReservaDTO reservaDTO)
        {
            var reserva = new TblReserva
            {
                IdCliente = reservaDTO.IdCliente,
                FechaReserva = DateTime.Now,
                FechaEntrada = reservaDTO.FechaEntrada,
                FechaSalida = reservaDTO.FechaSalida,
                Estado = reservaDTO.Estado,
                TotalPago = reservaDTO.TotalPago,
                MetodoPago = reservaDTO.MetodoPago
            };

            await _DbContext.TblReserva.AddAsync(reserva);
            await _DbContext.SaveChangesAsync();

            reservaDTO.IdReserva = reserva.IdReserva;
            return reservaDTO;
        }
        public async Task<DetalleReservaDTO> RegistrarDetalleReserva(DetalleReservaDTO detalleReservaDTO)
        {
            var detalleReserva = new TblDetalleReserva
            {
                IdReserva = detalleReservaDTO.IdReserva,
                IdHabitacion = detalleReservaDTO.IdHabitacion,
                CantidadPersonas = detalleReservaDTO.CantidadPersonas,
                TipoServicio = detalleReservaDTO.TipoServicio,
                CostoServicio = detalleReservaDTO.CostoServicio,
                PagoParcial = detalleReservaDTO.PagoParcial,
                FechaPago = detalleReservaDTO.FechaPago,
                EstadoPago = detalleReservaDTO.EstadoPago,
                FechaUltimaModificacion = DateTime.Now
            };

            await _DbContext.TblDetalleReserva.AddAsync(detalleReserva);
            await _DbContext.SaveChangesAsync(); // Guarda los cambios

            return detalleReservaDTO; // Retorna el DTO actualizado
        }


        public async Task<List<CheckOutDTO>> ListaCheckOut()
        {
            var listaCheckOut = await _DbContext.TblReserva
                .Include(r => r.IdClienteNavigation)
                .Include(r => r.TblDetalleReservas)
                .ThenInclude(dr => dr.IdHabitacionNavigation)
                .Select(r => new CheckOutDTO
                {
                    IdReserva = r.IdReserva,
                    FechaEntrada = r.FechaEntrada,
                    FechaSalida = r.FechaSalida,
                    IdCliente = r.IdCliente,
                    NombreCliente = r.IdClienteNavigation.Nombre + " " + r.IdClienteNavigation.Apellido,
                    IdHabitacion = r.TblDetalleReservas.FirstOrDefault().IdHabitacion,
                    NumeroHabitacion = r.TblDetalleReservas.FirstOrDefault().IdHabitacionNavigation.Numero,
                    Estado = r.Estado
                })
                .ToListAsync();
            return listaCheckOut;
        }




        public async Task<bool> ActualizarEstadoHabitacion(int idHabitacion)
        {
            var habitacion = await _DbContext.TblHabitacion.FindAsync(idHabitacion);
            if (habitacion == null)
            {
                return false;
            }
            habitacion.IdEstado = 2;
            _DbContext.TblHabitacion.Update(habitacion);
            await _DbContext.SaveChangesAsync();
            return true;
        }
    }
}
