using HOSPEDAJE.Areas.ClienteArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ClienteArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteCRUD.UpdateMS
{
    public interface IUpdateClienteMS
    {
        Task<MensajePersonalizadoDTO> ActualizarCliente(DetalleClienteDTO detalleClienteDTO, int idCliente);
        Task<MensajeEstandarDTO> ActualizarDetalleCliente(DetalleClienteDTO detalleClienteDTO, int idCliente);
    }
}
