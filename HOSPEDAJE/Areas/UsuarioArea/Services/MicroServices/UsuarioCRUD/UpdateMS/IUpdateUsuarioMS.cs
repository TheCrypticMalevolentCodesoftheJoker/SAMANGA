using HOSPEDAJE.Areas.UsuarioArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioCRUD.UpdateMS
{
    public interface IUpdateUsuarioMS
    {
        Task<MensajePersonalizadoDTO> ActualizarUsuario(DetalleUsuarioDTO DetalleUsuarioDTO, int idUsuario);
        Task<MensajeEstandarDTO> ActualizarDetalleUsuario(DetalleUsuarioDTO DetalleUsuarioDTO, int idUsuario);
    }
}
