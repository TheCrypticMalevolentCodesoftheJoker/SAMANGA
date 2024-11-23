using HOSPEDAJE.Areas.ReservaArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Models;

namespace HOSPEDAJE.Areas.ReservaArea.Repository
{
    public interface IReservaRepository
    {
        Task<ReservaDTO> RegistrarReserva(ReservaDTO reservaDTO);
        Task<DetalleReservaDTO> RegistrarDetalleReserva(DetalleReservaDTO detalleReservaDTO);

        Task<List<CheckOutDTO>> ListaCheckOut();
        Task<bool> ActualizarEstadoHabitacion(int idHabitacion);
    }
}
