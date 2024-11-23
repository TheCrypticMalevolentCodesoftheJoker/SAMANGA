using HOSPEDAJE.Areas.ClienteArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ClienteArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.ClienteArea.Services
{
    public interface IClienteService
    {
        Task<MensajePersonalizadoDTO> RegistrarCliente(RegistrarClienteDTO registrarClienteDTO);
        Task<MensajePersonalizadoDTO> LoginCliente(LoginClienteDTO loginClienteDTO);
        Task<DetalleClienteDTO> DetalleCliente(int Id_Cliente);
        Task<MensajePersonalizadoDTO> ActualizarCliente(DetalleClienteDTO detalleClienteDTO, int idCliente);
        Task<MensajeEstandarDTO> EliminarCliente(int idCliente);
    }
}
