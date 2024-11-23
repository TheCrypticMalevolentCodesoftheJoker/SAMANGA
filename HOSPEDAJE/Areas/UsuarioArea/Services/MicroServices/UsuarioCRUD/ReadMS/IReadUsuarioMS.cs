using HOSPEDAJE.Areas.UsuarioArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioCRUD.ReadMS
{
    public interface IReadUsuarioMS
    {
        Task<MensajeEstandarDTO> ValidarCorreo(string correo);
        Task<MensajeEstandarDTO> ValidarEstado(string correo);
        Task<DetalleUsuarioDTO> DetalleUsuario(int idUsuario);
    }
}
