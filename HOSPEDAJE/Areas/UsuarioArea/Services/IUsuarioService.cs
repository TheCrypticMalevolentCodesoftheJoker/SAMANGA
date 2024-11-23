using HOSPEDAJE.Areas.UsuarioArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.UsuarioArea.Services
{
    public interface IUsuarioService
    {
        Task<MensajePersonalizadoDTO> RegistrarUsuario(RegistrarUsuarioDTO registrarUsuarioDTO);
        Task<MensajePersonalizadoDTO> LoginUsuario(LoginUsuarioDTO loginUsuarioDTO);
        Task<DetalleUsuarioDTO> DetalleUsuario(int idUsuario);
        Task<MensajePersonalizadoDTO> ActualizarUsuario(DetalleUsuarioDTO detalleUsuarioDTO, int idUsuario);
        Task<MensajeEstandarDTO> EliminarUsuario(int idUsuario);
    }
}
