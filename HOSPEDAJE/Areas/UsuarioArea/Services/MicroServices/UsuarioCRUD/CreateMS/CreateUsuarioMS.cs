using AutoMapper;
using HOSPEDAJE.Areas.UsuarioArea.Repository;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.MensajesDTO;
using HOSPEDAJE.Models;

namespace HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioCRUD.CreateMS
{
    public class CreateUsuarioMS : ICreateUsuarioMS
    {
        private readonly IMapper _IMapper;
        private readonly IUsuarioRepository _IUsuarioRepository;
        public CreateUsuarioMS(IMapper iMapper, IUsuarioRepository iUsuarioRepository)
        {
            _IMapper = iMapper;
            _IUsuarioRepository = iUsuarioRepository;
        }
        public async Task<MensajePersonalizadoDTO> RegistrarUsuario(RegistrarUsuarioDTO registrarUsuarioDTO)
        {
            try
            {
                var registrarUsuario = _IMapper.Map<TblUsuario>(registrarUsuarioDTO);
                await _IUsuarioRepository.RegistrarUsuario(registrarUsuario);

                return new MensajePersonalizadoDTO(true, "Usuario registrado exitosamente", registrarUsuario.IdUsuario, registrarUsuario.Nombre, registrarUsuario.Apellido, registrarUsuario.IdRol);
            }
            catch (Exception ex)
            {
                var mensajeError = $"Error al registrar Usuario: {ex.Message}";
                return new MensajePersonalizadoDTO(false, mensajeError, 0, null, null, 0);
            }
        }
    }
}
