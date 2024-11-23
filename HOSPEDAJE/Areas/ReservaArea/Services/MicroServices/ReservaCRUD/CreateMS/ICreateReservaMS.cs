using HOSPEDAJE.Areas.ReservaArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ReservaArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.ReservaArea.Services.MicroServices.ReservaCRUD.CreateMS
{
    public interface ICreateReservaMS
    {
        Task<MensajeEstandarDTO> RegistrarReserva(ReservaDTO reservaDTO, DetalleReservaDTO detalleReservaDTO);
    }
}
