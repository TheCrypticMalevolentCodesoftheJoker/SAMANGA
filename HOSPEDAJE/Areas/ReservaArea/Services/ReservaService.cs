using HOSPEDAJE.Areas.ReservaArea.Services.MicroServices.ReservaCRUD.ReadMS;
using HOSPEDAJE.Areas.ReservaArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Services.PatronUnitOfWork;
using HOSPEDAJE.Areas.ReservaArea.Services.MicroServices.ReservaCRUD.CreateMS;
using HOSPEDAJE.Areas.ReservaArea.Payloads.MensajesDTO;
using HOSPEDAJE.Areas.ReservaArea.Services.MicroServices.ReservaCRUD.UpdateMS;
using HOSPEDAJE.Areas.ReservaArea.Services.MicroServices.GestorCorreo;

namespace HOSPEDAJE.Areas.ReservaArea.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IGestorCorreo _IGestorCorreo;
        private readonly ICreateReservaMS _ICreateReservaMS;
        private readonly IReadReservaMS _IReadReservaMS;
        private readonly IUpdateReservaMS _IUpdateReservaMS;
        public ReservaService(IUnitOfWork iUnitOfWork, IGestorCorreo iGestorCorreo, ICreateReservaMS iCreateReservaMS, IReadReservaMS iReadReservaMS, IUpdateReservaMS iUpdateReservaMS)
        {
            _IUnitOfWork = iUnitOfWork;
            _IGestorCorreo = iGestorCorreo;
            _ICreateReservaMS = iCreateReservaMS;
            _IReadReservaMS = iReadReservaMS;
            _IUpdateReservaMS = iUpdateReservaMS;
        }

        public async Task<MensajeEstandarDTO> RegistrarReserva(ReservaDTO reservaDTO, DetalleReservaDTO detalleReservaDTO)
        {
            try
            {
                await _IUnitOfWork.BeginTransactionAsync();

                // Llamada al microservicio para registrar la reserva
                var registroReserva = await _ICreateReservaMS.RegistrarReserva(reservaDTO, detalleReservaDTO);
                if (!registroReserva.EsExito)
                {
                    await _IUnitOfWork.RollbackTransactionAsync();
                    return new MensajeEstandarDTO(false, "Error al registrar la reserva.");
                }

                // Llamada al microservicio para actualizar el estado de la habitación
                var estadoHabitacion = await _IUpdateReservaMS.ActualizarEstadoHabitacion(detalleReservaDTO.IdHabitacion);
                if (!estadoHabitacion.EsExito)
                {
                    await _IUnitOfWork.RollbackTransactionAsync();
                    return new MensajeEstandarDTO(false, estadoHabitacion.Descripcion);
                }

                // Confirmar los cambios en la base de datos
                await _IUnitOfWork.SaveChangesAsync();
                await _IUnitOfWork.CommitTransactionAsync();

                return registroReserva;
            }
            catch (Exception ex)
            {
                await _IUnitOfWork.RollbackTransactionAsync();
                var mensajeError = $"Fallo en el proceso de microservicios: {ex.Message}. Detalle: {ex.InnerException?.Message}";
                return new MensajeEstandarDTO(false, mensajeError);
            }
        }

    }
}
