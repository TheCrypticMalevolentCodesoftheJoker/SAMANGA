using HOSPEDAJE.Areas.ReservaArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.ReservaArea.Services.MicroServices.GestorCorreo
{
    public interface IGestorCorreo
    {
        Task<MensajeEstandarDTO> EmitirCorreo(string correoDestino);
    }
}
