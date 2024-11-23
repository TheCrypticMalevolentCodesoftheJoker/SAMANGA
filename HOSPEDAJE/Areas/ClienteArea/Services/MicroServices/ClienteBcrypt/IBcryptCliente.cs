using HOSPEDAJE.Areas.ClienteArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ClienteArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteBcrypt
{
    public interface IBcryptCliente
    {
        Task<MensajeEstandarDTO> EncriptarContraseña(string contraseña);
        Task<MensajePersonalizadoDTO> DesencriptarContraseña(LoginClienteDTO loginClienteDTO);
    }
}
