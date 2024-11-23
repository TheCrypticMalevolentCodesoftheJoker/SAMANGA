using Microsoft.AspNetCore;
using HOSPEDAJE.Areas.ReservaArea.Payloads.MensajesDTO;
using HOSPEDAJE.Areas.ReservaArea.Repository;

namespace HOSPEDAJE.Areas.ReservaArea.Services.MicroServices.ReservaCRUD.UpdateMS
{
    public class UpdateReservaMS : IUpdateReservaMS
    {
        private readonly IReservaRepository _IReservaRepository;
        public UpdateReservaMS(IReservaRepository iReservaRepository)
        {
            _IReservaRepository = iReservaRepository;
        }

        public async Task<MensajeEstandarDTO> ActualizarEstadoHabitacion(int idHabitacion)
        {
            var resultado = await _IReservaRepository.ActualizarEstadoHabitacion(idHabitacion);
            if (!resultado)
            {
                return new MensajeEstandarDTO(false, "No se pudo actualizar el estado de la habitación.");
            }

            return new MensajeEstandarDTO(true, "Estado de la habitación actualizado exitosamente.");
        }
    }
}
