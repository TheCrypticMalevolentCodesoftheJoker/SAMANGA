using HOSPEDAJE.Areas.UsuarioArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioCRUD.CreateMS
{
    public interface ICreateUsuarioMS
    {
        Task<MensajePersonalizadoDTO> RegistrarUsuario(RegistrarUsuarioDTO registrarUsuarioDTO);
    }
}
