using HOSPEDAJE.Areas.UsuarioArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioBcrypt
{
    public interface IBcryptUsuario
    {
        Task<MensajeEstandarDTO> EncriptarContraseña(string Contraseña);
        Task<MensajePersonalizadoDTO> DesencriptarContraseña(LoginUsuarioDTO loginUsuarioDTO);
    }
}
