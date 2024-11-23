using HOSPEDAJE.Areas.UsuarioArea.Repository;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioBcrypt
{
    public class BcryptUsuario : IBcryptUsuario
    {
        private readonly IUsuarioRepository _IUsuarioRepository;
        public BcryptUsuario(IUsuarioRepository iUsuarioRepository)
        {
            _IUsuarioRepository = iUsuarioRepository;
        }

        public Task<MensajeEstandarDTO> EncriptarContraseña(string Contraseña)
        {
            try
            {
                string contraseñaEncriptada = BCrypt.Net.BCrypt.HashPassword(Contraseña);
                return Task.FromResult(new MensajeEstandarDTO(true, contraseñaEncriptada));
            }
            catch (Exception ex)
            {
                string mensajeError = $"Error al encriptar contraseña: {ex.Message}";
                return Task.FromResult(new MensajeEstandarDTO(false, mensajeError));
            }
        }
        public async Task<MensajePersonalizadoDTO> DesencriptarContraseña(LoginUsuarioDTO loginUsuarioDTO)
        {
            var UsuarioValidado = await _IUsuarioRepository.ValidarCorreo(loginUsuarioDTO.Correo);

            if (UsuarioValidado == null)
            {
                return new MensajePersonalizadoDTO(false, "pipipi no figuras en la BD", 0, null, null, 0);
            }
            bool esValida = BCrypt.Net.BCrypt.Verify(loginUsuarioDTO.Contraseña, UsuarioValidado.Contraseña);
            if (!esValida)
            {
                return new MensajePersonalizadoDTO(false, "Contraseña incorrecta.", 0, null, null, 0);
            }

            return new MensajePersonalizadoDTO(true, "Contraseña verificada.", UsuarioValidado.IdUsuario, UsuarioValidado.Nombre, UsuarioValidado.Apellido, UsuarioValidado.IdRol);
        }
    }
}
