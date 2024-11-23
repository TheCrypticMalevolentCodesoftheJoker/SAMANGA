using HOSPEDAJE.Areas.ClienteArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ClienteArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteCRUD.ReadMS
{
    public interface IReadClienteMS
    {
        Task<MensajeEstandarDTO> ValidarCorreo(string correo);
        Task<MensajeEstandarDTO> ValidarEstado(string correo);
        Task<DetalleClienteDTO> DetalleCliente(int idCliente);
    }
}
