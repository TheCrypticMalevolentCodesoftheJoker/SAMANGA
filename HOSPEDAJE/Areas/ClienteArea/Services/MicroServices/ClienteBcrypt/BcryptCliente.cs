using HOSPEDAJE.Areas.ClienteArea.Repository;
using HOSPEDAJE.Areas.ClienteArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ClienteArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteBcrypt
{
    public class BcryptCliente : IBcryptCliente
    {
        private readonly IClienteRepository _IClienteRepository;

        public BcryptCliente(IClienteRepository iClienteRepository)
        {
            _IClienteRepository = iClienteRepository;
        }

        public Task<MensajeEstandarDTO> EncriptarContraseña(string contraseña)
        {
            try
            {
                string contraseñaEncriptada = BCrypt.Net.BCrypt.HashPassword(contraseña);
                return Task.FromResult(new MensajeEstandarDTO(true, contraseñaEncriptada));
            }
            catch (Exception ex)
            {
                string mensajeError = $"Error al encriptar contraseña: {ex.Message}";
                return Task.FromResult(new MensajeEstandarDTO(false, mensajeError));
            }
        }
        public async Task<MensajePersonalizadoDTO> DesencriptarContraseña(LoginClienteDTO loginClienteDTO)
        {
            var clienteValidado = await _IClienteRepository.ValidarCorreo(loginClienteDTO.Correo);

            if (clienteValidado == null)
            {
                return new MensajePersonalizadoDTO(false, "pipipi no figuras en la BD", 0, null, null);
            }
            bool esValida = BCrypt.Net.BCrypt.Verify(loginClienteDTO.Contraseña, clienteValidado.Contraseña);
            if (!esValida)
            {
                return new MensajePersonalizadoDTO(false, "Contraseña incorrecta.", 0, null, null);
            }

            return new MensajePersonalizadoDTO(true, "Contraseña verificada.", clienteValidado.IdCliente, clienteValidado.Nombre, clienteValidado.Apellido);
        }
    }
}
