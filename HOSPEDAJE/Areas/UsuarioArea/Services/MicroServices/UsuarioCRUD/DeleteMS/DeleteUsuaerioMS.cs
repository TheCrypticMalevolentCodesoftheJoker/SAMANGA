using HOSPEDAJE.Areas.UsuarioArea.Repository;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioCRUD.DeleteMS
{
    public class DeleteUsuaerioMS : IDeleteUsuaerioMS
    {
        private readonly IUsuarioRepository _IUsuarioRepository;
        public DeleteUsuaerioMS(IUsuarioRepository iUsuarioRepository)
        {
            _IUsuarioRepository = iUsuarioRepository;
        }

        public async Task<MensajeEstandarDTO> EliminarUsuario(int idUsuario)
        {
            var BuscarUsuario = await _IUsuarioRepository.ObtenerUsuarioPorId(idUsuario);
            if (BuscarUsuario == null)
            {
                return new MensajeEstandarDTO(false, "No existe usuario");
            }
            var EliminarUsuario = await _IUsuarioRepository.EliminarUsuario(idUsuario, "I");
            if (!EliminarUsuario)
            {
                return new MensajeEstandarDTO(false, "Error al eliminar");
            }
            return new MensajeEstandarDTO(true, "Cuenta desactivada con exito");
        }
    }
}
