using HOSPEDAJE.Areas.ReservaArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.ReservaArea.Services.MicroServices.ReservaCRUD.UpdateMS
{
    public interface IUpdateReservaMS
    {
        Task<MensajeEstandarDTO> ActualizarEstadoHabitacion(int idHabitacion);
    }
}
