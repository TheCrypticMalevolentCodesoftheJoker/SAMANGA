using HOSPEDAJE.Areas.ReservaArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ReservaArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.ReservaArea.Services
{
    public interface IReservaService
    {
        Task<MensajeEstandarDTO> RegistrarReserva(ReservaDTO reservaDTO, DetalleReservaDTO detalleReservaDTO);
    }
}
