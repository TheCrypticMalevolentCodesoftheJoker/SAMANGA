using HOSPEDAJE.Areas.ClienteArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ClienteArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteCRUD.CreateMS
{
    public interface ICreateClienteMS
    {
        Task<MensajePersonalizadoDTO> RegistrarCliente(RegistrarClienteDTO registrarClienteDTO);
    }
}